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

        public DataTable BuscarClientePorNombre(string nombre)
        {
            DataTable table = new DataTable();


            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT Id, Nombre, Telefono, Email, FechaCreacion " +
                             "FROM Clientes " +
                             "WHERE Nombre LIKE @Nombre";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", "%" + nombre + "%");

                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                    {
                        adapter.Fill(table);

                        return table;
                    }
                }
            }
        }

        public Entidades.Cliente BuscarClientePorId(int id)
        {
            DataTable table = new DataTable();


            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT Id, Nombre, Telefono, Email, FechaCreacion " +
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
                            return new Entidades.Cliente
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Telefono = reader.IsDBNull(2) ? null : reader.GetString(2),
                                Email = reader.IsDBNull(3) ? null : reader.GetString(3),
                                FechaCreacion = reader.GetDateTime(4)
                            };
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
                        string sqlCorte = "INSERT INTO Cortes (ClienteId, Descripcion, Foto) " +
                                          "VALUES (@ClienteId, @Descripcion, @Foto)";

                        using (SQLiteCommand cmdCorte = new SQLiteCommand(sqlCorte, conn, transaction))
                        {
                            cmdCorte.Parameters.AddWithValue("@ClienteId", cliente.Id);
                            cmdCorte.Parameters.AddWithValue("@Descripcion", cliente.Observaciones);
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


    }
}
