using PeluqueriaApp.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeluqueriaApp
{
    public partial class Cliente : Form
    {

        DataTable table = new();
        DataView view = new();
        int idCliente = 0;
        DbConn dbConn = new DbConn();

        public Cliente(int id)
        {
            InitializeComponent();
            idCliente = id;

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

            Entidades.Cliente cliente = dbConn.BuscarClientePorId(idCliente);
            if (cliente != null)
            {
                txtNombre.Content = cliente.Nombre;
                txtTelefono.Content = cliente.Telefono;
                txtEmail.Content = cliente.Email;
            }
            else
            {
                MessageBox.Show("Cliente no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            ptbCliente.Image = dbConn.MostrarFotoDelCorte(idCliente, -1);
        }

        private void CargarCortes()
        {
            table = dbConn.ObtenerCortesPorCliente(idCliente);
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
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Estilo de las filas
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64); // Gris oscuro para mejor legibilidad
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
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

        private void dgvCortes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int corteId = Convert.ToInt32(dgvCortes.Rows[e.RowIndex].Cells["Id"].Value);
                ptbCliente.Image = dbConn.MostrarFotoDelCorte(-1, corteId);
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

            txtNombre.Enabled = true;
            txtTelefono.Enabled = true;
            txtEmail.Enabled = true;
            ptbCliente.Enabled = true;
            ptbCliente.Cursor = Cursors.Hand;
            btnGuardar.Enabled = true;

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
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    ptbCliente.Image = Image.FromFile(ofd.FileName);
                    imagenBytes = File.ReadAllBytes(ofd.FileName);
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
            if (!string.IsNullOrWhiteSpace(txtNombre.Content)) // Cambio: txtNombre.Text (en WinForms) en lugar de Content
            {


                MessageBox.Show(dbConn.AgregarCorte(new Entidades.Cliente { Id = idCliente, Nombre = txtNombre.Content.Trim(), Telefono = txtTelefono.Content.Trim(), Email = txtEmail.Content.Trim(), Observaciones = txtObservacion.Text, Foto = imagenBytes }));
                btnGuardar.Enabled = false;
                CargarCortes();

            }
            else
            {
                MessageBox.Show("Debe ingresar un nombre para continuar.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
