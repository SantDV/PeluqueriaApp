using PeluqueriaApp.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeluqueriaApp
{
    public class DbConn
    {

        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["cadenaConexion"].ConnectionString;

        public DataTable BuscarCliente(string criterio, string campoBusqueda)
        {
            DataTable table = new DataTable();

            // Validar que el campo de búsqueda sea válido para prevenir SQL injection
            string[] camposValidos = { "Nombre", "Telefono", "Email" };
            if (!camposValidos.Contains(campoBusqueda))
            {
                throw new ArgumentException("Campo de búsqueda no válido");
            }

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = $"SELECT Id, Nombre, Telefono, Email, FechaCreacion " +
                             $"FROM Clientes " +
                             $"WHERE {campoBusqueda} LIKE @Criterio";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Criterio", "%" + criterio + "%");

                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                        return table;
                    }
                }
            }
        }

        public DataTable CargarTodosLosClientes()
        {
            DataTable table = new DataTable();

         

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT Id, Nombre, Telefono, Email, FechaCreacion FROM Clientes ORDER BY fechaCreacion DESC";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {


                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                        return table;
                    }
                }
            }
        }


        public int ObtenerUltimoCorteId(int clienteId)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT Id FROM Cortes 
                       WHERE ClienteId = @ClienteId 
                       ORDER BY FechaCreacion DESC 
                       LIMIT 1";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ClienteId", clienteId);

                    object result = cmd.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int corteId))
                    {
                        return corteId;
                    }
                }
            }

            return -1; // Si no se encontró corte
        }



        public Cliente BuscarClientePorId(int id)
        {
            DataTable table = new DataTable();


            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT Id, Nombre, Telefono, Email, FechaCreacion, Domicilio " +
                             "FROM Clientes " +
                             "WHERE Id = @Id";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    //using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                    //{
                    //    adapter.Fill(table);

                    //    return table;
                    //}

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Cliente cliente = new Cliente();

                                cliente.Id = reader.GetInt32(0);
                                cliente.Nombre = reader.GetString(1);
                                cliente.Telefono = reader.IsDBNull(2) ? null : reader.GetString(2);
                                cliente.Email = reader.IsDBNull(3) ? null : reader.GetString(3);
                                cliente.FechaCreacion = reader.GetDateTime(4);
                                cliente.Domicilio = reader.IsDBNull(5) ? null : reader.GetString(5);
                       

                            return cliente;
                            //return new Cliente
                            //{
                            //    Id = reader.GetInt32(0),
                            //    Nombre = reader.GetString(1),
                            //    Telefono = reader.IsDBNull(2) ? null : reader.GetString(2),
                            //    Email = reader.IsDBNull(3) ? null : reader.GetString(3),
                            //    FechaCreacion = reader.GetDateTime(4),
                            //    Domicilio = reader.IsDBNull(5) ? null : reader.GetString(5)
                            //};
                        }
                        else
                        {
                            return null; // No se encontró el cliente
                        }
                    }
                }
            }
        }


        public DataTable ObtenerCortesPorCliente(int clienteId)
        {
            DataTable tabla = new DataTable();

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string sql = @"SELECT Id, Descripcion, fechaCreacion, Cobro 
                       FROM Cortes 
                       WHERE ClienteId = @ClienteId 
                       ORDER BY fechaCreacion DESC";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ClienteId", clienteId);

                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                    {
                        adapter.Fill(tabla);
                    }
                }
            }

            return tabla;
        }


        public List<byte[]> MostrarFotosDelCorte(int corteId)
        {
            List<byte[]> listaImagenes = new List<byte[]>();

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT Imagen FROM FotosCorte WHERE CorteId = @CorteId ORDER BY Id";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CorteId", corteId);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() && !reader.IsDBNull(0))
                        {
                            byte[] imagenBytes = (byte[])reader["Imagen"];
                            listaImagenes.Add(imagenBytes);
                        }
                    }
                }
            }

            return listaImagenes;
        }


        public string AgregarCorte(Cliente cliente, List<byte[]> listaImagenes)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Actualizar los datos del cliente
                        string sqlCliente = @"UPDATE Clientes 
                                      SET Nombre = @Nombre, Telefono = @Telefono, Email = @Email 
                                      WHERE Id = @Id";

                        using (SQLiteCommand cmdCliente = new SQLiteCommand(sqlCliente, conn, transaction))
                        {
                            cmdCliente.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                            cmdCliente.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                            cmdCliente.Parameters.AddWithValue("@Email", cliente.Email);
                            cmdCliente.Parameters.AddWithValue("@Id", cliente.Id);

                            cmdCliente.ExecuteNonQuery();
                        }

                        // Insertar nuevo corte
                        string sqlCorte = "INSERT INTO Cortes (ClienteId, Descripcion, Cobro) " +
                                          "VALUES (@ClienteId, @Descripcion, @Cobro)";

                        long corteId;

                        using (SQLiteCommand cmdCorte = new SQLiteCommand(sqlCorte, conn, transaction))
                        {
                            cmdCorte.Parameters.AddWithValue("@ClienteId", cliente.Id);
                            cmdCorte.Parameters.AddWithValue("@Descripcion", cliente.Observaciones);
                            cmdCorte.Parameters.AddWithValue("@Cobro", cliente.PrecioCorte);

                            cmdCorte.ExecuteNonQuery();
                            corteId = conn.LastInsertRowId;
                        }

                        // Insertar imágenes en la nueva tabla FotosCorte
                        string sqlFoto = "INSERT INTO FotosCorte (CorteId, Imagen) VALUES (@CorteId, @Imagen)";

                        foreach (var img in listaImagenes)
                        {
                            using (SQLiteCommand cmdFoto = new SQLiteCommand(sqlFoto, conn, transaction))
                            {
                                cmdFoto.Parameters.AddWithValue("@CorteId", corteId);
                                cmdFoto.Parameters.Add("@Imagen", DbType.Binary).Value = img ?? (object)DBNull.Value;
                                cmdFoto.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        return "Corte registrado correctamente.";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return "Error al registrar el corte: " + ex.Message;
                    }
                }
            }
        }


        public void EliminarCorte(int idCorte)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                
                using (var cmd = new SQLiteCommand("DELETE FROM Cortes WHERE Id = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", idCorte);
                    cmd.ExecuteNonQuery();
                }
            }
        }



        //----------------------------------------------------------------------------------------------------------

        //ESTADISTICAS DE CLIENTES

        public class EstadisticasService
        {

            public EstadisticasService()
            {
           
            }

            private object EjecutarEscalar(string sql)
            {
                using (var conn = new SQLiteConnection(connectionString))
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }

            public int ObtenerTotalClientes()
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT COUNT(*) FROM Clientes";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        return result == DBNull.Value ? 0 : Convert.ToInt32(result);
                    }
                }
            }

            public int ObtenerCortesEsteMes()
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT COUNT(*) FROM Cortes WHERE strftime('%m-%Y', FechaCreacion) = strftime('%m-%Y', 'now')";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        return result == DBNull.Value ? 0 : Convert.ToInt32(result);
                    }
                }
            }

            public int ObtenerTotalCortes()
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT COUNT(*) FROM Cortes";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        return result == DBNull.Value ? 0 : Convert.ToInt32(result);
                    }
                }
            }

            public string ObtenerCorteMasReciente()
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT MAX(FechaCreacion) FROM Cortes";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        return result == DBNull.Value ? "Sin cortes" : Convert.ToDateTime(result).ToString("dd/MM/yyyy");
                    }
                }
            }

            public int ObtenerNuevosClientesEsteMes()
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT COUNT(*) FROM Clientes WHERE strftime('%m-%Y', FechaCreacion) = strftime('%m-%Y', 'now')";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        return result == DBNull.Value ? 0 : Convert.ToInt32(result);
                    }
                }
            }

            public string ObtenerClienteMasFrecuente()
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT Nombre FROM Clientes 
                       WHERE Id = (SELECT ClienteId 
                                   FROM Cortes 
                                   GROUP BY ClienteId 
                                   ORDER BY COUNT(*) DESC 
                                   LIMIT 1)";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        object result = cmd.ExecuteScalar();

                        if (result == null || result == DBNull.Value)
                            return "Sin datos";

                        return result.ToString();
                    }
                }
            }


            public double ObtenerPromedioCortesPorCliente()
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT COUNT(*) * 1.0 / (SELECT COUNT(*) FROM Clientes) FROM Cortes";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        return result == DBNull.Value ? 0 : Convert.ToDouble(result);
                    }
                }
            }

            public int ObtenerDiasDesdeUltimoCorte()
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT MAX(FechaCreacion) FROM Cortes";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result == DBNull.Value)
                            return -1;

                        DateTime ultimaFecha = Convert.ToDateTime(result);
                        return (DateTime.Now - ultimaFecha).Days;
                    }
                }
            }
        }


        public DataTable ObtenerClientesPorRangoFechas(DateTime desde, DateTime hasta)
        {
            

            // Asegurarse de que la fecha "hasta" incluya todo el día
            hasta = hasta.AddDays(1).AddSeconds(-1);

            string query = @"
                            SELECT Id, Nombre, Telefono, Email, FechaCreacion 
                            FROM Clientes 
                            WHERE FechaCreacion BETWEEN @Desde AND @Hasta
                            ORDER BY FechaCreacion DESC";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                DataTable table = new DataTable();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Desde", desde);
                    cmd.Parameters.AddWithValue("@Hasta", hasta);

                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                        return table;
                    }

                   
                }
            }

            
        }


    }
}
