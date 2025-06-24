using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Security.Policy;
using System.Windows.Forms;

namespace PeluqueriaApp
{
    public partial class ClientesGestion : Form
    {

        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["cadenaConexion"].ConnectionString;

        DataTable table = new();
        DataView view = new();
        public ClientesGestion()
        {
            InitializeComponent();
            EstilizarDataGridView(dgvClientes);
            ConfigurarMonitoreoCambios();
            table.Columns.Add("id", typeof(string));
            table.Columns.Add("nombre", typeof(string));
            table.Columns.Add("telefono", typeof(string));
            table.Columns.Add("email", typeof(string));
            table.Columns.Add("fechaCreacion", typeof(string));



            dgvClientes.Columns["id"].DataPropertyName = "id";
            dgvClientes.Columns["nombre"].DataPropertyName = "nombre";
            dgvClientes.Columns["telefono"].DataPropertyName = "telefono";
            dgvClientes.Columns["email"].DataPropertyName = "email";
            dgvClientes.Columns["fechaCreacion"].DataPropertyName = "fechaCreacion";



        }


        private void EstilizarDataGridView(DataGridView dgv)
        {
            // Configuraci�n general
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

            // Selecci�n y scroll
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


                    table = dbConn.BuscarCliente(txtBuscarNombre.Content.Trim(), "Nombre");
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
                ClienteCortes frm = new ClienteCortes(clienteId);
                frm.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ajustes ajustes = new Ajustes();

            ajustes.ShowDialog();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            table.Clear();
        }

        private void ConfigurarMonitoreoCambios()
        {
            // Todos estos eventos llamar�n a ActualizarConteoClientes()
            //dgvClientes.CellValueChanged += (s, e) => ActualizarConteoClientes();
            //dgvClientes.RowsAdded += (s, e) => ActualizarConteoClientes();
            //dgvClientes.RowsRemoved += (s, e) => ActualizarConteoClientes();
            //dgvClientes.DataSourceChanged += (s, e) => ActualizarConteoClientes();
        }

        //private void ActualizarConteoClientes()
        //{
        //    int filasValidas = dgvClientes.Rows
        //        .Cast<DataGridViewRow>()
        //        .Count(r => !r.IsNewRow && r.Cells[0].Value != null);

        //    lblCustomerCount.Text = filasValidas.ToString();

        //    // Opcional: Cambiar color si hay muchas filas
        //    lblCustomerCount.ForeColor = filasValidas > 10 ? Color.Red : Color.Black;
        //}

        private void txtBuscarTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrEmpty(txtBuscarTelefono.Content))
            {
                DbConn dbConn = new DbConn();

                try
                {


                    table = dbConn.BuscarCliente(txtBuscarTelefono.Content.Trim(), "Telefono");
                    view = table.DefaultView;

                    dgvClientes.DataSource = view;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void txtBuscarEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrEmpty(txtBuscarEmail.Content))
            {
                DbConn dbConn = new DbConn();

                try
                {


                    table = dbConn.BuscarCliente(txtBuscarEmail.Content.Trim(), "Email");
                    view = table.DefaultView;

                    dgvClientes.DataSource = view;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }



        private void lblCargarTodo_MouseLeave(object sender, EventArgs e)
        {
            lblCargarTodo.ForeColor = Color.Black;
        }

        private void lblCargarTodo_MouseEnter(object sender, EventArgs e)
        {
            lblCargarTodo.ForeColor = Color.Silver;
        }

        private void lblCargarTodo_Click(object sender, EventArgs e)
        {

            DbConn dbConn = new DbConn();

            try
            {

                table = dbConn.CargarTodosLosClientes();
                view = table.DefaultView;

                dgvClientes.DataSource = view;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
