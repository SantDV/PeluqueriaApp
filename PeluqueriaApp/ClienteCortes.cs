using PeluqueriaApp.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PeluqueriaApp
{
    public partial class ClienteCortes : Form
    {

        Cliente cliente = new();
        DataTable table = new();
        DataView view = new();
        List<byte[]> imageList = new List<byte[]>();

        DbConn dbConn = new DbConn();
        int idCorte = -1;

        public ClienteCortes(int id)
        {
            InitializeComponent();

            this.KeyPreview = true; // Podés ponerlo en el constructor o en Load

            this.MaximizeBox = false;

            // Opcional: Establece el borde como fijo
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            cliente.Id = id;

            table.Columns.Add("Id", typeof(string));
            table.Columns.Add("Descripcion", typeof(string));
            table.Columns.Add("fechaCreacion", typeof(string));
            table.Columns.Add("Cobro", typeof(string));

            dgvCortes.Columns["id"].DataPropertyName = "Id";
            dgvCortes.Columns["descripcion"].DataPropertyName = "Descripcion";
            dgvCortes.Columns["fecha"].DataPropertyName = "fechaCreacion";
            dgvCortes.Columns["costo"].DataPropertyName = "Cobro";

        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            EstilizarDataGridView(dgvCortes);

            CargarCortes();

            this.cliente = dbConn.BuscarClientePorId(cliente.Id);
            if (cliente != null)
            {
                txtNombre.Content = cliente.Nombre;
                txtTelefono.Content = cliente.Telefono;
                txtEmail.Content = cliente.Email;
                txtDomicilio.Content = cliente.Domicilio;
                //txtObservacion.Text = cliente.Observaciones;
                //txtPrecio.Content = cliente.PrecioCorte.ToString("C2"); // Formatear como moneda
            }
            else
            {
                MessageBox.Show("Cliente no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            int ultimoIdCorte = dbConn.ObtenerUltimoCorteId(cliente.Id);

            imageList = dbConn.MostrarFotosDelCorte(ultimoIdCorte);

            if (imageList.Count > 0)
            {
                using (MemoryStream ms = new MemoryStream(imageList[0]))
                {
                    ptbCliente.Image = Image.FromStream(ms);
                }
            }
            else
            {
                ptbCliente.Image = null;
            }
        }

        private void CargarCortes()
        {
            table = dbConn.ObtenerCortesPorCliente(cliente.Id);
            view = table.DefaultView;
            dgvCortes.DataSource = view;


        }


        private void EstilizarDataGridView(DataGridView dgv)
        {
            // Configuración general
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = Color.White;
            dgv.EnableHeadersVisualStyles = false;
            dgv.GridColor = Color.FromArgb(230, 230, 230);
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Estilo de los encabezados de columna
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 145, 225); // Azul moderno
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Estilo de las filas
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64); // Gris oscuro para mejor legibilidad
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 13F);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 240, 255); // Azul muy claro
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(64, 64, 64);
            dgv.DefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            dgv.RowTemplate.Height = 36;
            dgv.RowTemplate.DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);
            dgv.AllowUserToResizeRows = false;

            // Estilo de filas alternas
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 250); // Azul muy claro
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);

            // Autoajuste de columnas
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Encabezados de fila
            dgv.RowHeadersVisible = false;
            dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            // Selección y scroll
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ScrollBars = ScrollBars.Vertical;
            dgv.MultiSelect = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToOrderColumns = false;

            // Efectos visuales modernos
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgv.ShowCellToolTips = true;

            // Bordes redondeados (requiere override de OnPaint si quieres bordes completamente personalizados)
            dgv.Region = new Region(new Rectangle(0, 0, dgv.Width, dgv.Height));
        }



        int contadorImg = 0;
        private void dgvCortes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idCorte = Convert.ToInt32(dgvCortes.Rows[e.RowIndex].Cells["Id"].Value);
                string descripcion = dgvCortes.Rows[e.RowIndex].Cells["descripcion"].Value.ToString();

                imageList = dbConn.MostrarFotosDelCorte(idCorte); // Ahora obtenés todas

                txtObservacion.Text = descripcion;

                if (imageList.Count > 0)
                {
                    using (MemoryStream ms = new MemoryStream(imageList[contadorImg]))
                    {
                        ptbCliente.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    ptbCliente.Image = null;
                }
            }
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

        private void btnRotar_Click(object sender, EventArgs e)
        {
            if (ptbCliente.Image == null) return;

            // Crear una copia para no modificar la imagen original
            Image img = ptbCliente.Image;
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            ptbCliente.Image = img;
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

        private void lblNuevoCorte_Click(object sender, EventArgs e)
        {

            txtObservacion.Text = string.Empty;
            ptbCliente.Image = null;
            txtPrecio.Enabled = true;
            txtNombre.Enabled = true;
            txtTelefono.Enabled = true;
            txtDomicilio.Enabled = true;

            txtEmail.Enabled = true;
            ptbCliente.Enabled = true;
            ptbCliente.Cursor = Cursors.Hand;
            btnGuardar.Enabled = true;

            imageList.Clear(); // Limpiar la lista de imágenes al iniciar un nuevo corte

        }

        private void lblNuevoCorte_MouseEnter(object sender, EventArgs e)
        {
            lblNuevoCorte.ForeColor = Color.Silver;
        }

        private void lblNuevoCorte_MouseLeave(object sender, EventArgs e)
        {
            lblNuevoCorte.ForeColor = Color.Black;
        }

        private byte[] imagenBytes;
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

        private void lblEliminarCorte_MouseEnter(object sender, EventArgs e)
        {
            lblEliminarCorte.ForeColor = Color.PaleVioletRed;
        }

        private void lblEliminarCorte_MouseLeave(object sender, EventArgs e)
        {
            lblEliminarCorte.ForeColor = Color.Red;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNombre.Content))
            {
                var clienteParaGuardar = new Cliente
                {
                    Id = cliente.Id,
                    Nombre = txtNombre.Content.Trim(),
                    Telefono = txtTelefono.Content.Trim(),
                    Email = txtEmail.Content.Trim(),
                    Observaciones = txtObservacion.Text,
                    PrecioCorte = string.IsNullOrWhiteSpace(txtPrecio.Content) ? "$ 0,00" : txtPrecio.Content
                };

                string resultado = dbConn.AgregarCorte(clienteParaGuardar, imageList);
                MessageBox.Show(resultado);
                btnGuardar.Enabled = false;
                ptbCliente.Enabled = false;
                CargarCortes();
            }
            else
            {
                MessageBox.Show("Debe ingresar un nombre para continuar.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }



        private void lblEliminarCorte_Click(object sender, EventArgs e)
        {
            if (idCorte == 0)
            {
                MessageBox.Show("No hay ningún corte seleccionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var resultado = MessageBox.Show("¿Estás seguro de que querés eliminar este corte?", "Confirmar eliminación",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                dbConn.EliminarCorte(idCorte);

                MessageBox.Show("Corte eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Actualizar interfaz (por ejemplo, recargar lista de cortes)
                CargarCortes();
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



        private System.Windows.Forms.ToolTip tooltip = new(); // Variable de clase
        private void dgvCortes_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView dgv = (DataGridView)sender;

                // Obtener el rectángulo de la celda y su posición en pantalla
                Rectangle cellDisplayRect = dgv.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                Point cellLocation = dgv.PointToScreen(cellDisplayRect.Location);

                // Obtener el valor de la celda de descripción
                string descripcion = dgv.Rows[e.RowIndex].Cells["descripcion"].Value?.ToString() ?? "Sin descripción";

                // Configurar el ToolTip
                System.Windows.Forms.ToolTip tooltip = new();

                // Mostrar el ToolTip
                tooltip.Show(
                    descripcion,
                    dgv,
                    dgv.PointToClient(cellLocation).X + 10,
                    dgv.PointToClient(cellLocation).Y + 10,
                    5000); // Duración de 5 segundos
            }
        }

        private void dgvCortes_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            var tooltips = this.Controls.OfType<System.Windows.Forms.ToolTip>();
            foreach (var tt in tooltips)
            {
                tt.Hide((DataGridView)sender);
            }
        }
        private void btnGaleria_Click_1(object sender, EventArgs e)
        {
            FrmGaleria frmGaleria = new FrmGaleria(cliente);

            frmGaleria.ShowDialog();
        }

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

        private void MostrarImagenActual()
        {
            if (ptbCliente.Image != null)
            {
                ptbCliente.Image.Dispose();
                ptbCliente.Image = null;
            }

            if (imageList.Count > 0 && contadorImg < imageList.Count)
            {
                using (MemoryStream ms = new MemoryStream(imageList[contadorImg]))
                {
                    ptbCliente.Image = Image.FromStream(ms);
                }
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarClienteSeleccionado();

        }

        private void EliminarClienteSeleccionado()
        {



            int clienteId = cliente.Id;

            DialogResult resultado = MessageBox.Show("¿Estás seguro que querés eliminar este cliente y todos sus datos?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resultado != DialogResult.Yes)
                return;

            string conexion = "Data Source=peluqueriaDB.db; Version=3;";

            using (var conn = new SQLiteConnection(conexion))
            {
                conn.Open();

                using (var transaccion = conn.BeginTransaction())
                {
                    try
                    {
                        // Primero eliminar cortes y fotos si no tenés ON DELETE CASCADE (opcional)
                        // Si ya tenés ON DELETE CASCADE, podés omitir esto.

                        // 1. Eliminar registros relacionados de FotosCorte (si fuera necesario)
                        string eliminarFotos = @"
                    DELETE FROM FotosCorte 
                    WHERE CorteId IN (SELECT Id FROM Cortes WHERE ClienteId = @ClienteId)";
                        using (var cmd = new SQLiteCommand(eliminarFotos, conn))
                        {
                            cmd.Parameters.AddWithValue("@ClienteId", clienteId);
                            cmd.ExecuteNonQuery();
                        }

                        // 2. Eliminar cortes (si no hay ON DELETE CASCADE en Clientes -> Cortes)
                        string eliminarCortes = "DELETE FROM Cortes WHERE ClienteId = @ClienteId";
                        using (var cmd = new SQLiteCommand(eliminarCortes, conn))
                        {
                            cmd.Parameters.AddWithValue("@ClienteId", clienteId);
                            cmd.ExecuteNonQuery();
                        }

                        // 3. Eliminar el cliente
                        string eliminarCliente = "DELETE FROM Clientes WHERE Id = @ClienteId";
                        using (var cmd = new SQLiteCommand(eliminarCliente, conn))
                        {
                            cmd.Parameters.AddWithValue("@ClienteId", clienteId);
                            cmd.ExecuteNonQuery();
                        }

                        transaccion.Commit();

                        MessageBox.Show("Cliente eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ClientesGestion clienteGestion = Application.OpenForms.OfType<ClientesGestion>().FirstOrDefault();
                        if (clienteGestion != null)
                        {
                            clienteGestion.BuscarPorFecha(); 
                        }

                        this.Close(); // Cerrar el formulario actual
                        // Actualizar DataGridView
                        // Asegurate de tener una función así para refrescar los datos
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                        MessageBox.Show("Ocurrió un error al eliminar el cliente:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ClienteCortes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
                e.Handled = true;
            }
        }
    }
}
