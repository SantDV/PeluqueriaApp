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


        public Image MostrarFotoDelCorte(int clienteId = -1, int corteId = -1)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string sql;
                int parametroId;

                if (clienteId != -1)
                {
                    sql = "SELECT Foto FROM Cortes WHERE ClienteId = @Id ORDER BY FechaCreacion DESC LIMIT 1";
                    parametroId = clienteId;
                }
                else
                {
                    sql = "SELECT Foto FROM Cortes WHERE Id = @Id";
                    parametroId = corteId;
                }

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", parametroId);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() && !reader.IsDBNull(0))
                        {
                            byte[] imagenBytes = (byte[])reader["Foto"];
                            using (MemoryStream ms = new MemoryStream(imagenBytes))
                            {
                                return Image.FromStream(ms);
                            }
                        }
                    }
                }
            }

            return null; // No hay imagen
        }


        public string AgregarCorte(Entidades.Cliente cliente)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                     

                        string sqlCliente = @"UPDATE Clientes SET Nombre = @Nombre, Telefono = @Telefono, Email = @Email WHERE Id = @Id";


                        using (SQLiteCommand cmdCliente = new SQLiteCommand(sqlCliente, conn, transaction))
                        {
                            cmdCliente.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                            cmdCliente.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                            cmdCliente.Parameters.AddWithValue("@Email", cliente.Email);
                            cmdCliente.Parameters.AddWithValue("@Id", cliente.Id);

                            cmdCliente.ExecuteNonQuery();
                        }


                        // 3. Insertar en Cortes
                        string sqlCorte = "INSERT INTO Cortes (ClienteId, Descripcion, cobro, Foto) " +
                                          "VALUES (@ClienteId, @Descripcion, @Cobro, @Foto)";

                        using (SQLiteCommand cmdCorte = new SQLiteCommand(sqlCorte, conn, transaction))
                        {
                            cmdCorte.Parameters.AddWithValue("@ClienteId", cliente.Id);
                            cmdCorte.Parameters.AddWithValue("@Descripcion", cliente.Observaciones);
                            cmdCorte.Parameters.AddWithValue("@Cobro", cliente.PrecioCorte);
                            cmdCorte.Parameters.Add("@Foto", DbType.Binary).Value = cliente.Foto ?? (object)DBNull.Value;

                            cmdCorte.ExecuteNonQuery();
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
                return Convert.ToInt32(EjecutarEscalar("SELECT COUNT(*) FROM Clientes"));
            }

            public int ObtenerCortesEsteMes()
            {
                return Convert.ToInt32(EjecutarEscalar(@"
            SELECT COUNT(*) FROM Cortes 
            WHERE strftime('%Y-%m', FechaCreacion) = strftime('%Y-%m', 'now')
        "));
            }

            public int ObtenerTotalCortes()
            {
                return Convert.ToInt32(EjecutarEscalar("SELECT COUNT(*) FROM Cortes"));
            }

            public string ObtenerCorteMasReciente()
            {
                using (var conn = new SQLiteConnection(connectionString))
                using (var cmd = new SQLiteCommand(@"
            SELECT cl.Nombre || ' ' || cl.Apellido || ' - ' || c.FechaCreacion 
            FROM Cortes c
            JOIN Clientes cl ON cl.Id = c.ClienteId
            ORDER BY c.FechaCreacion DESC LIMIT 1
        ", conn))
                {
                    conn.Open();
                    return cmd.ExecuteScalar()?.ToString() ?? "N/A";
                }
            }

            public int ObtenerNuevosClientesEsteMes()
            {
                return Convert.ToInt32(EjecutarEscalar(@"
            SELECT COUNT(*) FROM Clientes 
            WHERE strftime('%Y-%m', FechaCreacion) = strftime('%Y-%m', 'now')
        "));
            }

            public string ObtenerClienteMasFrecuente()
            {
                using (var conn = new SQLiteConnection(connectionString))
                using (var cmd = new SQLiteCommand(@"
            SELECT cl.Nombre || ' ' || cl.Apellido || ' (' || COUNT(*) || ' cortes)' 
            FROM Cortes c
            JOIN Clientes cl ON cl.Id = c.ClienteId
            GROUP BY ClienteId
            ORDER BY COUNT(*) DESC
            LIMIT 1
        ", conn))
                {
                    conn.Open();
                    return cmd.ExecuteScalar()?.ToString() ?? "N/A";
                }
            }

            public double ObtenerPromedioCortesPorCliente()
            {
                using (var conn = new SQLiteConnection(connectionString))
                using (var cmd = new SQLiteCommand(@"
            SELECT ROUND(1.0 * COUNT(*) / (SELECT COUNT(*) FROM Clientes), 2)
            FROM Cortes
        ", conn))
                {
                    conn.Open();
                    return Convert.ToDouble(cmd.ExecuteScalar());
                }
            }

            public int ObtenerDiasDesdeUltimoCorte()
            {
                using (var conn = new SQLiteConnection(connectionString))
                using (var cmd = new SQLiteCommand("SELECT MAX(FechaCreacion) FROM Cortes", conn))
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result == DBNull.Value) return -1;

                    DateTime fechaUltimoCorte = Convert.ToDateTime(result);
                    return (DateTime.Today - fechaUltimoCorte.Date).Days;
                }
            }
        }



    }
}
