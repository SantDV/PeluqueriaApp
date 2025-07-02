using ClosedXML.Excel;
using ClosedXML.Excel;
using PeluqueriaApp.Entidades;
using System.Data;
using System.Drawing; // para Color
using System.Globalization;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Color = System.Drawing.Color;
using Font = System.Drawing.Font;


namespace PeluqueriaApp
{
    public partial class FrmFacturacion : Form
    {

        DataTable table = new DataTable();
        DataView view = new DataView();
        DbConn dbConn = new DbConn();
        public FrmFacturacion()
        {
            InitializeComponent();
            EstilizarDataGridView(dgvFacturacion);





            table.Columns.Add("id", typeof(string));
            table.Columns.Add("fechaCreacion", typeof(string));
            table.Columns.Add("cliente", typeof(string));
            table.Columns.Add("descripcion", typeof(string));
            table.Columns.Add("cobro", typeof(string));
            table.Columns.Add("clienteId", typeof(string));


            //dgvFacturacion.AutoGenerateColumns = false;
            dgvFacturacion.Columns["id"].DataPropertyName = "id";
            dgvFacturacion.Columns["fechaCreacion"].DataPropertyName = "fechaCreacion";
            dgvFacturacion.Columns["cliente"].DataPropertyName = "cliente";
            dgvFacturacion.Columns["descripcion"].DataPropertyName = "descripcion";
            dgvFacturacion.Columns["cobro"].DataPropertyName = "cobro";
            dgvFacturacion.Columns["clienteId"].DataPropertyName = "ClienteId";

            BuscarPorFecha();
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
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30); // Negro mate
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

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            BuscarPorFecha();
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            BuscarPorFecha();
        }

        public void BuscarPorFecha()
        {
            try
            {
                if (dtpHasta.Enabled == false)
                {
                    DateTime desde = dtpDesde.Value.Date; // Fecha inicial (00:00:00)
                    DateTime hasta = desde; // Fecha final (se ajustará para incluir todo el día)


                    var resultado = dbConn.ObtenerCobrosPorRangoFechas(desde, hasta);
                    table = resultado.Table;
                    view = table.DefaultView;

                    dgvFacturacion.DataSource = view;

                    txtTotalPesos.Text = $"$ {resultado.Total:N2}";


                    int cantidadCortes = table.Rows.Count;


                    // Mostrarlos en los TextBox
                    txtCortesNum.Content = cantidadCortes.ToString();
                    txtClientesNum.Content = resultado.cantidadClientes.ToString();

                }
                else
                {
                    DateTime desde = dtpDesde.Value.Date; // Fecha inicial (00:00:00)
                    DateTime hasta = dtpHasta.Value.Date; // Fecha final (se ajustará para incluir todo el día)


                    var resultado = dbConn.ObtenerCobrosPorRangoFechas(desde, hasta);
                    table = resultado.Table;
                    view = table.DefaultView;

                    dgvFacturacion.DataSource = view;

                    txtTotalPesos.Text = $"$ {resultado.Total:N2}";


                    int cantidadCortes = table.Rows.Count;


                    // Mostrarlos en los TextBox
                    txtCortesNum.Content = cantidadCortes.ToString();
                    txtClientesNum.Content = resultado.cantidadClientes.ToString();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar clientes: {ex.Message}");
            }
        }



        void BuscarCliente()
        {


            try
            {
                string valorBusqueda = "";
                string tipoBusqueda = "";
                int? idCliente = null;
                int? idCorte = null;

                // Determinar qué campo usar para la búsqueda
                if (!string.IsNullOrWhiteSpace(txtIdCorte.Content))
                {
                    if (int.TryParse(txtIdCorte.Content.Trim(), out int id))
                    {
                        idCorte = id;
                    }
                    else
                    {
                        MessageBox.Show("El ID de Corte debe ser un número válido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else if (!string.IsNullOrWhiteSpace(txtIdCliente.Content))
                {
                    if (int.TryParse(txtIdCliente.Content.Trim(), out int id))
                    {
                        idCliente = id;
                    }
                    else
                    {
                        MessageBox.Show("El ID de Cliente debe ser un número válido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else if (!string.IsNullOrWhiteSpace(txtBuscarNombre.Content))
                {
                    valorBusqueda = txtBuscarNombre.Content.Trim();
                    tipoBusqueda = "cl.Nombre";
                }
                else if (!string.IsNullOrWhiteSpace(txtBuscarTelefono.Content))
                {
                    valorBusqueda = txtBuscarTelefono.Content.Trim();
                    tipoBusqueda = "cl.Telefono";
                }
                else if (!string.IsNullOrWhiteSpace(txtBuscarEmail.Content))
                {
                    valorBusqueda = txtBuscarEmail.Content.Trim();
                    tipoBusqueda = "cl.Email";
                }
                else
                {
                    MessageBox.Show("Ingrese al menos un criterio de búsqueda (ID, Nombre, Teléfono o Email).", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var resultado = idCorte.HasValue
                    ? dbConn.ObtenerCobrosPorCriterio(null, null, idCorte, null)
                    : idCliente.HasValue
                        ? dbConn.ObtenerCobrosPorCriterio(null, null, null, idCliente)
                        : dbConn.ObtenerCobrosPorCriterio(valorBusqueda, tipoBusqueda);

                table = resultado.Table;
                view = table.DefaultView;

                dgvFacturacion.DataSource = view;
                txtTotalPesos.Text = $"$ {resultado.Total:N2}";

                int cantidadCortes = table.Rows.Count;
                txtClientesNum.Content = resultado.cantidadClientes.ToString();
                txtCortesNum.Content = cantidadCortes.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar Cobros: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtIdCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrEmpty(txtIdCliente.Content))
            {
                BuscarIdCliente();
            }
        }

        void BuscarIdCliente()
        {
            var resultado = dbConn.ObtenerCobrosPorCriterio(criterio: null, campoBusqueda: null, idCliente: Convert.ToInt32(txtIdCliente.Content));
            table = resultado.Table;
            view = table.DefaultView;

            dgvFacturacion.DataSource = view;

            txtTotalPesos.Text = $"$ {resultado.Total:N2}";


            int cantidadCortes = table.Rows.Count;


            // Mostrarlos en los TextBox
            txtClientesNum.Content = resultado.cantidadClientes.ToString();
            txtCortesNum.Content = cantidadCortes.ToString();

        }

        private void txtBuscarNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrEmpty(txtBuscarNombre.Content))
            {
                BuscarCliente();

            }
        }

        private void txtBuscarTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrEmpty(txtBuscarTelefono.Content))
            {
                BuscarCliente();

            }
        }

        private void txtBuscarEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrEmpty(txtBuscarEmail.Content))
            {
                BuscarCliente();

            }
        }

        private void lblCargarTodos_Click(object sender, EventArgs e)
        {
            var resultado = dbConn.ObtenerTodosLosCobros();
            table = resultado.Table;
            view = table.DefaultView;

            dgvFacturacion.DataSource = view;

            txtTotalPesos.Text = $"$ {resultado.Total:N2}";


            int cantidadCortes = table.Rows.Count;

            txtBuscarEmail.Content = string.Empty;
            txtBuscarTelefono.Content = string.Empty;
            txtBuscarNombre.Content = string.Empty;
            txtIdCliente.Content = string.Empty;
            txtIdCorte.Content = string.Empty;


            // Mostrarlos en los TextBox
            txtClientesNum.Content = resultado.cantidadClientes.ToString();
            txtCortesNum.Content = cantidadCortes.ToString();
        }

        private void txtBuscarNombre_Enter(object sender, EventArgs e)
        {
            txtBuscarEmail.Content = string.Empty;
            txtBuscarTelefono.Content = string.Empty;
            txtIdCliente.Content = string.Empty;
        }

        private void txtBuscarTelefono_Enter(object sender, EventArgs e)
        {
            txtBuscarEmail.Content = string.Empty;
            txtBuscarNombre.Content = string.Empty;
            txtIdCliente.Content = string.Empty;
        }

        private void txtBuscarEmail_Enter(object sender, EventArgs e)
        {
            txtBuscarTelefono.Content = string.Empty;
            txtBuscarNombre.Content = string.Empty;
            txtIdCliente.Content = string.Empty;
        }

        private void txtIdCorte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrEmpty(txtIdCorte.Content))
            {

                BuscarIdCorte();
            }
        }

        void BuscarIdCorte()
        {
            var resultado = dbConn.ObtenerCobrosPorCriterio(criterio: null, campoBusqueda: null, idCorte: Convert.ToInt32(txtIdCorte.Content));
            table = resultado.Table;
            view = table.DefaultView;

            dgvFacturacion.DataSource = view;

            txtTotalPesos.Text = $"$ {resultado.Total:N2}";


            int cantidadCortes = table.Rows.Count;


            // Mostrarlos en los TextBox
            txtClientesNum.Content = resultado.cantidadClientes.ToString();
            txtCortesNum.Content = cantidadCortes.ToString();
        }

        private void txtIdCliente_Enter(object sender, EventArgs e)
        {
            txtBuscarEmail.Content = string.Empty;
            txtBuscarNombre.Content = string.Empty;
            txtBuscarTelefono.Content = string.Empty;
            txtIdCorte.Content = string.Empty;
        }

        private void txtIdCorte_Enter(object sender, EventArgs e)
        {
            txtBuscarEmail.Content = string.Empty;
            txtBuscarNombre.Content = string.Empty;
            txtBuscarTelefono.Content = string.Empty;
            txtIdCliente.Content = string.Empty;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportarResumenFacturacion();
        }


        private void ExportarResumenFacturacion()
        {
            if (dgvFacturacion.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivo Excel (*.xlsx)|*.xlsx";
                sfd.FileName = $"Resumen_Facturacion_{DateTime.Now:yyyyMMdd}.xlsx";

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                using (var workbook = new XLWorkbook())
                {
                    var ws = workbook.Worksheets.Add("Resumen");

                    // --- Encabezados tabla ---
                    ws.Cell(1, 1).Value = "ID PAGO/CORTE";
                    ws.Cell(1, 2).Value = "Fecha";
                    ws.Cell(1, 3).Value = "Cliente";
                    ws.Cell(1, 4).Value = "Descripción";
                    ws.Cell(1, 5).Value = "Cobro";

                    ws.Range("A1:E1").Style.Font.Bold = true;
                    ws.Range("A1:E1").Style.Fill.BackgroundColor = XLColor.LightGray;
                    ws.Range("A1:E1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    // --- Datos de la tabla ---
                    int fila = 2;
                    foreach (DataGridViewRow row in dgvFacturacion.Rows)
                    {
                        if (row.IsNewRow) continue;

                        ws.Cell(fila, 1).Value = row.Cells["Id"].Value?.ToString();
                        ws.Cell(fila, 2).Value = Convert.ToDateTime(row.Cells["FechaCreacion"].Value).ToString("dd/MM/yyyy");
                        ws.Cell(fila, 3).Value = row.Cells["Cliente"].Value?.ToString();
                        ws.Cell(fila, 4).Value = row.Cells["Descripcion"].Value?.ToString();

                        string cobroTexto = row.Cells["Cobro"].Value?.ToString() ?? "0";
                        cobroTexto = cobroTexto.Replace("$", "").Replace(".", "").Replace(",", ".");
                        decimal.TryParse(cobroTexto, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal cobroValor);

                        ws.Cell(fila, 5).Value = cobroValor;
                        ws.Cell(fila, 5).Style.NumberFormat.Format = "$ #,##0.00";

                        fila++;
                    }

                    // --- Resumen arriba a la derecha ---
                    int resumenCol = 9; // Columna I
                    int resumenFila = 2;

                    ws.Cell(resumenFila, resumenCol).Value = "Resumen";
                    ws.Cell(resumenFila, resumenCol).Style.Font.Bold = true;
                    ws.Cell(resumenFila, resumenCol).Style.Font.FontSize = 14;
                    ws.Cell(resumenFila, resumenCol).Style.Fill.BackgroundColor = XLColor.LightSteelBlue;
                    ws.Cell(resumenFila, resumenCol).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    ws.Range(resumenFila, resumenCol, resumenFila, resumenCol + 1).Merge();

                    ws.Cell(resumenFila + 1, resumenCol).Value = "Cantidad de cortes:";
                    ws.Cell(resumenFila + 1, resumenCol + 1).Value = txtCortesNum.Content;

                    ws.Cell(resumenFila + 2, resumenCol).Value = "Cantidad de clientes:";
                    ws.Cell(resumenFila + 2, resumenCol + 1).Value = txtClientesNum.Content;

                    ws.Cell(resumenFila + 3, resumenCol).Value = "Total facturado:";
                    string totalTexto = txtTotalPesos.Text.Replace("$", "").Replace(".", "").Replace(",", ".");
                    decimal.TryParse(totalTexto, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal total);
                    ws.Cell(resumenFila + 3, resumenCol + 1).Value = total;
                    ws.Cell(resumenFila + 3, resumenCol + 1).Style.NumberFormat.Format = "$ #,##0.00";

                    // Estilos resumen
                    ws.Range(resumenFila + 1, resumenCol, resumenFila + 3, resumenCol + 1).Style.Fill.BackgroundColor = XLColor.WhiteSmoke;
                    ws.Range(resumenFila + 1, resumenCol, resumenFila + 3, resumenCol).Style.Font.Bold = true;
                    ws.Range(resumenFila + 1, resumenCol, resumenFila + 3, resumenCol + 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

                    ws.Columns().AdjustToContents();

                    workbook.SaveAs(sfd.FileName);
                }

                MessageBox.Show("Archivo exportado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cckbRango_CheckedChanged(object sender, EventArgs e)
        {
            if (cckbRango.Checked == true)
            {
                dtpHasta.Enabled = true;
                BuscarPorFecha();
            }
            else
            {
                dtpHasta.Enabled = false;
                BuscarPorFecha();
            }
        }

        private void dgvFacturacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int idCorte = dgvFacturacion.Rows[e.RowIndex].Cells["Id"].Value != null ?
              Convert.ToInt32(dgvFacturacion.Rows[e.RowIndex].Cells["Id"].Value) : 0;

                string fecha = dgvFacturacion.Rows[e.RowIndex].Cells["fechaCreacion"].Value?.ToString() ?? string.Empty;
                string cliente = dgvFacturacion.Rows[e.RowIndex].Cells["cliente"].Value?.ToString() ?? string.Empty;
                string descripcion = dgvFacturacion.Rows[e.RowIndex].Cells["descripcion"].Value?.ToString() ?? string.Empty;
                string cobro = dgvFacturacion.Rows[e.RowIndex].Cells["cobro"].Value?.ToString() ?? string.Empty;
                int clienteId = dgvFacturacion.Rows[e.RowIndex].Cells["clienteId"].Value != null ?
              Convert.ToInt32(dgvFacturacion.Rows[e.RowIndex].Cells["clienteId"].Value) : 0;


                DetalleCobro detalleCobro = new DetalleCobro(new Corte
                {
                    Id = idCorte,
                    FechaCreacion = Convert.ToDateTime(fecha),
                    NombreCliente = cliente,
                    ClienteId = clienteId,
                    Descripcion = descripcion,
                    Cobro = cobro
                });

                detalleCobro.ShowDialog();

            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarCliente();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscarEmail.Content = string.Empty;
            txtBuscarNombre.Content = string.Empty;
            txtBuscarTelefono.Content = string.Empty;
            txtIdCliente.Content = string.Empty;
            txtIdCorte.Content = string.Empty;
            txtCortesNum.Content = string.Empty;
            txtClientesNum.Content = string.Empty;
            txtTotalPesos.Text = "$ 0,00";
            table.Clear();
        }
    }
}
