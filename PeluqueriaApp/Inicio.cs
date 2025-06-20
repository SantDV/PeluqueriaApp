using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Security.Policy;
using System.Windows.Forms;

namespace PeluqueriaApp
{
    public partial class Form1 : Form
    {

        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["cadenaConexion"].ConnectionString;

        DataTable table = new();
        DataView view = new();
        public Form1()
        {
            InitializeComponent();
            EstilizarDataGridView(dgvClientes);

            table.Columns.Add("id", typeof(string));
            table.Columns.Add("nombre", typeof(string));
            table.Columns.Add("telefono", typeof(string));
            table.Columns.Add("mail", typeof(string));



            dgvClientes.Columns["id"].DataPropertyName = "id";
            dgvClientes.Columns["nombre"].DataPropertyName = "nombre";
            dgvClientes.Columns["telefono"].DataPropertyName = "telefono";
            dgvClientes.Columns["mail"].DataPropertyName = "mail";



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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            RegistroCliente registroCliente = new RegistroCliente();

            registroCliente.ShowDialog();
        }


        private void txtBuscarNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrEmpty(txtBuscarNombre.Content))
            {
                DbConn dbConn = new DbConn();

                try
                {


                    table = dbConn.BuscarClientePorNombre(txtBuscarNombre.Content.Trim());
                    view = table.DefaultView;

                    dgvClientes.DataSource = view;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Asegura que no se hizo clic en el encabezado
            {
                int clienteId = Convert.ToInt32(dgvClientes.Rows[e.RowIndex].Cells["id"].Value);

                // Abrir el formulario Cliente y pasarle el ID
                Cliente frm = new Cliente(clienteId);
                frm.ShowDialog();
            }
        }
    }
}
