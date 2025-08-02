using PeluqueriaApp.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
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
                        string sqlCorte = "INSERT INTO Cortes (ClienteId, Descripcion, Cobro, FechaCreacion) " +
                                          "VALUES (@ClienteId, @Descripcion, @Cobro, @FechaCreacion)";

                        long corteId;

                        using (SQLiteCommand cmdCorte = new SQLiteCommand(sqlCorte, conn, transaction))
                        {
                            cmdCorte.Parameters.AddWithValue("@ClienteId", cliente.Id);
                            cmdCorte.Parameters.AddWithValue("@Descripcion", cliente.Observaciones);
                            cmdCorte.Parameters.AddWithValue("@Cobro", cliente.PrecioCorte);
                            cmdCorte.Parameters.AddWithValue("@FechaCreacion", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                            cmdCorte.ExecuteNonQuery();
                            corteId = conn.LastInsertRowId;
                        }

                        // Insertar imágenes en la nueva tabla FotosCorte
                        string sqlFoto = "INSERT INTO FotosCorte (CorteId, Imagen, FechaSubida) VALUES (@CorteId, @Imagen, @FechaSubida)";

                        foreach (var img in listaImagenes)
                        {
                            using (SQLiteCommand cmdFoto = new SQLiteCommand(sqlFoto, conn, transaction))
                            {
                                cmdFoto.Parameters.AddWithValue("@CorteId", corteId);
                                cmdFoto.Parameters.Add("@Imagen", DbType.Binary).Value = img ?? (object)DBNull.Value;
                                cmdFoto.Parameters.AddWithValue("@FechaSubida", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
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


        public bool EliminarCorte(int idCorte)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                
                using (var cmd = new SQLiteCommand("DELETE FROM Cortes WHERE Id = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", idCorte);
                    cmd.ExecuteNonQuery();
                    return true; // Retorna true si la eliminación fue exitosa
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

            //WHERE date(c.FechaCreacion) BETWEEN date(@Desde) AND date(@Hasta)
            string query = @"
                            SELECT Id, Nombre, Telefono, Email, FechaCreacion 
                            FROM Clientes 
                            WHERE date(FechaCreacion) BETWEEN date(@Desde) AND date(@Hasta)
                            ORDER BY FechaCreacion DESC";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                DataTable table = new DataTable();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Desde", desde.Date);
                    cmd.Parameters.AddWithValue("@Hasta", hasta.Date);

                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                        return table;
                    }

                   
                }
            }

            
        }

        public (DataTable Table, decimal Total, int cantidadClientes) ObtenerCobrosPorRangoFechas(DateTime desde, DateTime hasta)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT c.Id, c.ClienteId as clienteId, c.FechaCreacion, 
              cl.Nombre AS Cliente,
              c.Descripcion, 
              c.Cobro
       FROM Cortes c
       JOIN Clientes cl ON cl.Id = c.ClienteId
       WHERE date(c.FechaCreacion) BETWEEN date(@Desde) AND date(@Hasta)
         AND c.Cobro IS NOT NULL AND TRIM(c.Cobro) != ''
       ORDER BY c.FechaCreacion ASC";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    // Aseguramos que solo se compare la parte de fecha
                    cmd.Parameters.AddWithValue("@Desde", desde.Date);
                    cmd.Parameters.AddWithValue("@Hasta", hasta.Date);

                    // Resto del código permanece igual...
                    using (var da = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        decimal total = 0;

                        foreach (DataRow row in dt.Rows)
                        {
                            string cobroTexto = row["Cobro"].ToString()
                                .Replace("$", "")
                                .Replace(" ", "")
                                .Replace(".", "")
                                .Replace(",", ".");

                            if (decimal.TryParse(cobroTexto, System.Globalization.NumberStyles.Any,
                                System.Globalization.CultureInfo.InvariantCulture, out decimal valor))
                                total += valor;
                        }

                        int cantidadClientes = dt
                            .AsEnumerable()
                            .Select(row => row.Field<long>("clienteId"))
                            .Distinct()
                            .Count();

                        return (dt, total, cantidadClientes);
                    }
                }
            }
        }


        public (DataTable Table, decimal Total, int cantidadClientes) ObtenerCobrosPorCriterio(
    string criterio, string campoBusqueda = null, int? idCorte = null, long? idCliente = null)

        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string sql = @"
            SELECT c.Id, c.FechaCreacion,
                   cl.Id AS ClienteId,
                   cl.Nombre AS Cliente,
                   c.Descripcion,
                   c.Cobro
            FROM Cortes c
            JOIN Clientes cl ON cl.Id = c.ClienteId
            WHERE c.Cobro IS NOT NULL AND TRIM(c.Cobro) != ''";

                // Validación de parámetros
                if (idCorte.HasValue)
                {
                    sql += " AND c.Id = @IdCorte";
                }
                else if (idCliente.HasValue)
                {
                    sql += " AND c.ClienteId = @IdCliente";
                }
                else if (!string.IsNullOrEmpty(campoBusqueda))
                {
                    // Validar campo para evitar inyecciones SQL
                    string[] camposValidos = { "cl.Nombre", "cl.Telefono", "cl.Email" };
                    if (!camposValidos.Contains(campoBusqueda))
                        throw new ArgumentException("Campo de búsqueda no válido");

                    sql += $" AND {campoBusqueda} LIKE @Criterio";
                }
                else
                {
                    throw new ArgumentException("Debe proporcionar un criterio de búsqueda válido");
                }

                sql += " ORDER BY c.FechaCreacion ASC";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    // Asignar parámetros según el tipo de búsqueda
                    if (idCorte.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@IdCorte", idCorte);
                    }
                    else if (idCliente.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@IdCliente", idCliente);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Criterio", "%" + criterio + "%");
                    }

                    using (var da = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        decimal total = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            string cobroTexto = row["Cobro"].ToString()
                                .Replace("$", "")
                                .Replace(" ", "")
                                .Replace(".", "")
                                .Replace(",", ".");

                            if (decimal.TryParse(cobroTexto, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valor))
                                total += valor;
                        }

                        int cantidadClientes = dt
                            .AsEnumerable()
                            .Select(row => row.Field<long>("ClienteId"))
                            .Distinct()
                            .Count();

                        return (dt, total, cantidadClientes);
                    }
                }
            }
        }

        public (DataTable Table, decimal Total, int cantidadClientes) ObtenerTodosLosCobros()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT c.Id, c.ClienteId as clienteId, c.FechaCreacion, 
                      cl.Nombre AS Cliente,
                      c.Descripcion, 
                      c.Cobro
               FROM Cortes c
               JOIN Clientes cl ON cl.Id = c.ClienteId
               WHERE c.Cobro IS NOT NULL AND TRIM(c.Cobro) != ''
               ORDER BY c.FechaCreacion ASC";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    using (var da = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        decimal total = 0;

                        foreach (DataRow row in dt.Rows)
                        {
                            string cobroTexto = row["Cobro"].ToString()
                                .Replace("$", "")
                                .Replace(" ", "")
                                .Replace(".", "")
                                .Replace(",", ".");

                            if (decimal.TryParse(cobroTexto, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal valor))
                                total += valor;
                        }

                        int cantidadClientes = dt
                            .AsEnumerable()
                            .Select(row => row.Field<long>("clienteId"))
                            .Distinct()
                            .Count();

                        return (dt, total, cantidadClientes);
                    }
                }
            }
        }


        public (DataTable Table, decimal Total, int cantidadClientes) ObtenerCobrosPorIdCorte(int idCorte)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT c.Id, c.ClienteId as clienteId, c.FechaCreacion, 
                      cl.Nombre AS Cliente,
                      c.Descripcion, 
                      c.Cobro
               FROM Cortes c
               JOIN Clientes cl ON cl.Id = c.ClienteId
               WHERE c.Id = @IdCorte
                 AND c.Cobro IS NOT NULL AND TRIM(c.Cobro) != ''";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@IdCorte", idCorte);

                    using (var da = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        decimal total = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            string cobroTexto = row["Cobro"].ToString()
                                .Replace("$", "")
                                .Replace(" ", "")
                                .Replace(".", "")
                                .Replace(",", ".");

                            if (decimal.TryParse(cobroTexto, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valor))
                                total += valor;
                        }

                        int cantidadClientes = dt.Rows.Count; // Solo habrá 1 cliente si el ID del corte es único

                        return (dt, total, cantidadClientes);
                    }
                }
            }
        }


        public (DataTable Table, decimal Total, int cantidadClientes) ObtenerCobrosPorIdCliente(long idCliente)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT c.Id, c.ClienteId as clienteId, c.FechaCreacion, 
                      cl.Nombre AS Cliente,
                      c.Descripcion, 
                      c.Cobro
               FROM Cortes c
               JOIN Clientes cl ON cl.Id = c.ClienteId
               WHERE c.ClienteId = @IdCliente
                 AND c.Cobro IS NOT NULL AND TRIM(c.Cobro) != ''
               ORDER BY c.FechaCreacion ASC";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@IdCliente", idCliente);

                    using (var da = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        decimal total = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            string cobroTexto = row["Cobro"].ToString()
                                .Replace("$", "")
                                .Replace(" ", "")
                                .Replace(".", "")
                                .Replace(",", ".");

                            if (decimal.TryParse(cobroTexto, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valor))
                                total += valor;
                        }

                        int cantidadClientes = 1; // Siempre es 1 porque filtras por un cliente específico

                        return (dt, total, cantidadClientes);
                    }
                }
            }
        }


        public bool ModificarCorte(Corte corte)
        {
            try
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"
                UPDATE Cortes 
                SET 
                    Descripcion = @Descripcion,
                    Cobro = @Cobro,
                    FechaCreacion = @FechaCreacion
                WHERE Id = @Id";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", corte.Id);
                        cmd.Parameters.AddWithValue("@Descripcion", string.IsNullOrEmpty(corte.Descripcion) ? " " : corte.Descripcion);
                        cmd.Parameters.AddWithValue("@Cobro", string.IsNullOrEmpty(corte.Cobro) ? 0.00 : corte.Cobro);
                        cmd.Parameters.AddWithValue("@FechaCreacion", corte.FechaCreacion.ToString("yyyy-MM-dd HH:mm:ss"));

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Puedes registrar el error o mostrarlo
                MessageBox.Show($"Error al modificar el corte: {ex.Message}");
                return false;
            }
        }

    }
}
