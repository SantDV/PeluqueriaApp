using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeluqueriaApp
{
    public partial class RegistroCliente : Form
    {

        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["cadenaConexion"].ConnectionString;
        private List<byte[]> imageList = new List<byte[]>(); // ← ya lo tenés con tus imágenes
        public RegistroCliente()
        {
            InitializeComponent();
            this.KeyPreview = true; // Podés ponerlo en el constructor o en Load

            this.MaximizeBox = false;

            // Opcional: Establece el borde como fijo
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNombre.Content))
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Insertar cliente
                            string sqlCliente = "INSERT INTO Clientes (Nombre, Telefono, Email, Domicilio, FechaCreacion) " +
                                                "VALUES (@Nombre, @Telefono, @Email, @Domicilio, @FechaCreacion)";

                            using (SQLiteCommand cmdCliente = new SQLiteCommand(sqlCliente, conn, transaction))
                            {
                                cmdCliente.Parameters.AddWithValue("@Nombre", txtNombre.Content);
                                cmdCliente.Parameters.AddWithValue("@Telefono", txtTelefono.Content);
                                cmdCliente.Parameters.AddWithValue("@Email", txtEmail.Content);
                                cmdCliente.Parameters.AddWithValue("@Domicilio", txtDomicilio.Content);
                                cmdCliente.Parameters.AddWithValue("@FechaCreacion", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                cmdCliente.ExecuteNonQuery();
                            }

                            long clienteId = conn.LastInsertRowId;

                            // 2. Insertar corte (sin foto)
                            string sqlCorte = "INSERT INTO Cortes (ClienteId, Descripcion, Cobro, FechaCreacion) " +
                                              "VALUES (@ClienteId, @Descripcion, @Cobro, @FechaCreacion)";

                            long corteId;

                            using (SQLiteCommand cmdCorte = new SQLiteCommand(sqlCorte, conn, transaction))
                            {
                                cmdCorte.Parameters.AddWithValue("@ClienteId", clienteId);
                                cmdCorte.Parameters.AddWithValue("@Descripcion", txtObservacion.Text);
                                cmdCorte.Parameters.AddWithValue("@FechaCreacion", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                cmdCorte.Parameters.AddWithValue("@Cobro", string.IsNullOrWhiteSpace(txtPrecio.Content) ? "$ 0,00" : txtPrecio.Content);
                                cmdCorte.ExecuteNonQuery();

                                corteId = conn.LastInsertRowId; // Obtener ID del corte
                            }

                            // 3. Insertar fotos del corte
                            string sqlFoto = "INSERT INTO FotosCorte (CorteId, Imagen) VALUES (@CorteId, @Imagen)";

                            foreach (var imgBytes in imageList)
                            {
                                using (SQLiteCommand cmdFoto = new SQLiteCommand(sqlFoto, conn, transaction))
                                {
                                    cmdFoto.Parameters.AddWithValue("@CorteId", corteId);
                                    cmdFoto.Parameters.Add("@Imagen", DbType.Binary).Value = imgBytes;
                                    cmdFoto.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();
                            MessageBox.Show("Cliente, corte y fotos registrados correctamente.");
                            LimpiarFormulario();

                            ClientesGestion clientesGestion = Application.OpenForms.OfType<ClientesGestion>().FirstOrDefault();

                            if (clientesGestion != null)
                            {
                                clientesGestion.BuscarPorFecha(); // Actualizar la lista de clientes en el formulario principal
                            }
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
                ofd.Multiselect = true; // Habilita selección múltiple

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imageList.Clear(); // Limpiá la lista anterior si estás cargando nuevas imágenes

                    foreach (string file in ofd.FileNames)
                    {
                        byte[] bytes = File.ReadAllBytes(file);
                        imageList.Add(bytes);
                    }

                    // Mostrar la primera imagen como vista previa
                    if (imageList.Count > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(imageList[0]))
                        {
                            ptbCliente.Image = Image.FromStream(ms);
                        }
                    }
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

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrWhiteSpace(txtPrecio.Content))
            {
                FormatearAPesosArgentinos();
                e.Handled = true;
            }
        }

        private void txtPrecio_Leave(object sender, EventArgs e)
        {
            FormatearAPesosArgentinos();
        }
        private decimal _valorNumerico; // Variable de clase

        private void FormatearAPesosArgentinos()
        {
            // Cultura argentina
            var cultura = CultureInfo.GetCultureInfo("es-AR");

            // Limpiar símbolo de moneda y espacios
            string texto = txtPrecio.Content
                .Replace("$", "")
                .Replace("ARS", "")
                .Trim();

            if (decimal.TryParse(texto, NumberStyles.Any, cultura, out decimal monto))
            {
                txtPrecio.Content = monto.ToString("C2", cultura); // "$ 1.000,00"
            }
            else
            {
                txtPrecio.Content = 0m.ToString("C2", cultura); // "$ 0,00"
            }
        }


        private void RegistroCliente_Load(object sender, EventArgs e)
        {

        }

        private void txtPrecio_Enter(object sender, EventArgs e)
        {
            txtPrecio.Content = _valorNumerico.ToString(CultureInfo.GetCultureInfo("es-AR"));
        }


        int contadorImg = 0; // Empezamos en 0 (primera imagen)

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (imageList.Count > 0)
            {
                contadorImg++;

                if (contadorImg >= imageList.Count)
                {
                    contadorImg = 0;
                }

                MostrarImagenActual();
            }
            else
            {
                MessageBox.Show("No hay imágenes para mostrar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (imageList.Count > 0)
            {
                contadorImg--;

                if (contadorImg < 0)
                {
                    contadorImg = imageList.Count - 1;
                }

                MostrarImagenActual();
            }
            else
            {
                MessageBox.Show("No hay imágenes para mostrar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MostrarImagenActual()
        {
            using (MemoryStream ms = new MemoryStream(imageList[contadorImg]))
            {
                ptbCliente.Image = Image.FromStream(ms);
            }
        }


        private void LimpiarFormulario()
        {
            // Limpiar campos de texto
            txtNombre.Content = string.Empty;
            txtTelefono.Content = string.Empty;
            txtEmail.Content = string.Empty;
            txtDomicilio.Content = string.Empty;
            txtObservacion.Text = string.Empty;

            // Reiniciar el campo de precio
            _valorNumerico = 0m;
            txtPrecio.Content = _valorNumerico.ToString(CultureInfo.GetCultureInfo("es-AR"));

            // Limpiar imágenes
            imageList.Clear();
            contadorImg = 0;
            ptbCliente.Image = null;

            // Opcional: enfocar el primer campo
            txtNombre.Focus();
        }

        private void RegistroCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
                e.Handled = true;
            }

        }
    }
}

