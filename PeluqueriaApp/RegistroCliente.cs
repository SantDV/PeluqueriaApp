using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeluqueriaApp
{
    public partial class RegistroCliente : Form
    {

        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["cadenaConexion"].ConnectionString;

        public RegistroCliente()
        {
            InitializeComponent();
        }

        private byte[] imagenBytes;
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNombre.Content)) // Cambio: txtNombre.Text (en WinForms) en lugar de Content
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Insertar en Clientes
                            string sqlCliente = "INSERT INTO Clientes (Nombre, Telefono, Email) " +
                                                "VALUES (@Nombre, @Telefono, @Email)";

                            using (SQLiteCommand cmdCliente = new SQLiteCommand(sqlCliente, conn, transaction))
                            {
                                cmdCliente.Parameters.AddWithValue("@Nombre", txtNombre.Content); 
                                cmdCliente.Parameters.AddWithValue("@Telefono", txtTelefono.Content);
                                cmdCliente.Parameters.AddWithValue("@Email", txtEmail.Content);

                                cmdCliente.ExecuteNonQuery();
                            }

                            // 2. Obtener el ID del cliente recién insertado
                            long clienteId = conn.LastInsertRowId;

                            // 3. Insertar en Cortes
                            string sqlCorte = "INSERT INTO Cortes (ClienteId, Descripcion, Foto) " +
                                              "VALUES (@ClienteId, @Descripcion, @Foto)";

                            using (SQLiteCommand cmdCorte = new SQLiteCommand(sqlCorte, conn, transaction))
                            {
                                cmdCorte.Parameters.AddWithValue("@ClienteId", clienteId);
                                cmdCorte.Parameters.AddWithValue("@Descripcion", txtObservacion.Text);
                                cmdCorte.Parameters.Add("@Foto", DbType.Binary).Value = imagenBytes ?? (object)DBNull.Value;

                                cmdCorte.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            MessageBox.Show("Cliente y corte registrados correctamente.");
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error al registrar: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar un nombre para continuar.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void ptbCliente_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    ptbCliente.Image = Image.FromFile(ofd.FileName);
                    imagenBytes = File.ReadAllBytes(ofd.FileName);
                }
            }
        }

        private void btnSizeMode_Click(object sender, EventArgs e)
        {
            switch (ptbCliente.SizeMode)
            {
                case PictureBoxSizeMode.Normal:
                    ptbCliente.SizeMode = PictureBoxSizeMode.StretchImage;
                    break;
                case PictureBoxSizeMode.StretchImage:
                    ptbCliente.SizeMode = PictureBoxSizeMode.AutoSize;
                    break;
                case PictureBoxSizeMode.AutoSize:
                    ptbCliente.SizeMode = PictureBoxSizeMode.CenterImage;
                    break;
                case PictureBoxSizeMode.CenterImage:
                    ptbCliente.SizeMode = PictureBoxSizeMode.Zoom;
                    break;
                case PictureBoxSizeMode.Zoom:
                    ptbCliente.SizeMode = PictureBoxSizeMode.Normal;
                    break;
            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (ptbCliente.Image == null) return;

            // Crear una copia para no modificar la imagen original
            Image img = ptbCliente.Image;
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            ptbCliente.Image = img;
        }

        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            if (ptbCliente.Image != null)
            {
                var imagenCopia = (Image)ptbCliente.Image.Clone(); // importante: clonar la imagen
                var formCompleto = new FormImagenCompleta(imagenCopia);
                formCompleto.ShowDialog();
            }
            else
            {
                MessageBox.Show("No hay imagen para mostrar.");
            }
        }
    }
}
