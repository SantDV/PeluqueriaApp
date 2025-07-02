namespace PeluqueriaApp
{
    partial class FrmFacturacion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvFacturacion = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            fechaCreacion = new DataGridViewTextBoxColumn();
            cliente = new DataGridViewTextBoxColumn();
            descripcion = new DataGridViewTextBoxColumn();
            cobro = new DataGridViewTextBoxColumn();
            clienteId = new DataGridViewTextBoxColumn();
            lblCargarTodos = new Label();
            btnBuscar = new CuoreUI.Controls.cuiButton();
            btnLimpiar = new CuoreUI.Controls.cuiButton();
            dtpHasta = new DateTimePicker();
            dtpDesde = new DateTimePicker();
            txtBuscarEmail = new CuoreUI.Controls.cuiTextBox();
            txtBuscarTelefono = new CuoreUI.Controls.cuiTextBox();
            txtBuscarNombre = new CuoreUI.Controls.cuiTextBox();
            txtIdCliente = new CuoreUI.Controls.cuiTextBox();
            gpBox = new GroupBox();
            txtTotalPesos = new TextBox();
            lblExcel = new Label();
            txtClientesNum = new CuoreUI.Controls.cuiTextBox();
            lblCortes = new Label();
            txtCortesNum = new CuoreUI.Controls.cuiTextBox();
            lblClientes = new Label();
            btnExport = new CuoreUI.Controls.cuiButton();
            lblTotalFacturado = new Label();
            txtIdCorte = new CuoreUI.Controls.cuiTextBox();
            cckbRango = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dgvFacturacion).BeginInit();
            gpBox.SuspendLayout();
            SuspendLayout();
            // 
            // dgvFacturacion
            // 
            dgvFacturacion.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dgvFacturacion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFacturacion.Columns.AddRange(new DataGridViewColumn[] { Id, fechaCreacion, cliente, descripcion, cobro, clienteId });
            dgvFacturacion.Location = new Point(12, 99);
            dgvFacturacion.Name = "dgvFacturacion";
            dgvFacturacion.Size = new Size(780, 239);
            dgvFacturacion.TabIndex = 0;
            dgvFacturacion.CellClick += dgvFacturacion_CellClick;
            // 
            // Id
            // 
            Id.HeaderText = "ID PAGO/CORTE";
            Id.Name = "Id";
            // 
            // fechaCreacion
            // 
            fechaCreacion.HeaderText = "Fecha";
            fechaCreacion.Name = "fechaCreacion";
            // 
            // cliente
            // 
            cliente.HeaderText = "Cliente";
            cliente.Name = "cliente";
            // 
            // descripcion
            // 
            descripcion.HeaderText = "Descripción";
            descripcion.Name = "descripcion";
            // 
            // cobro
            // 
            cobro.HeaderText = "Cobro";
            cobro.Name = "cobro";
            // 
            // clienteId
            // 
            clienteId.HeaderText = "ClienteId";
            clienteId.Name = "clienteId";
            clienteId.Visible = false;
            // 
            // lblCargarTodos
            // 
            lblCargarTodos.AutoSize = true;
            lblCargarTodos.Cursor = Cursors.Hand;
            lblCargarTodos.Font = new Font("Segoe UI", 12F);
            lblCargarTodos.Location = new Point(586, 50);
            lblCargarTodos.Name = "lblCargarTodos";
            lblCargarTodos.Size = new Size(60, 21);
            lblCargarTodos.TabIndex = 31;
            lblCargarTodos.Text = "[Todos]";
            lblCargarTodos.Click += lblCargarTodos_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.CheckButton = false;
            btnBuscar.Checked = false;
            btnBuscar.CheckedBackground = Color.FromArgb(52, 152, 219);
            btnBuscar.CheckedForeColor = Color.White;
            btnBuscar.CheckedImageTint = Color.White;
            btnBuscar.CheckedOutline = Color.FromArgb(52, 152, 219);
            btnBuscar.Content = "Buscar";
            btnBuscar.DialogResult = DialogResult.None;
            btnBuscar.Font = new Font("Microsoft Sans Serif", 12F);
            btnBuscar.ForeColor = Color.White;
            btnBuscar.HoverBackground = Color.FromArgb(41, 128, 185);
            btnBuscar.HoveredImageTint = Color.White;
            btnBuscar.HoverForeColor = Color.White;
            btnBuscar.HoverOutline = Color.FromArgb(41, 128, 185);
            btnBuscar.Image = null;
            btnBuscar.ImageAutoCenter = true;
            btnBuscar.ImageExpand = new Point(0, 0);
            btnBuscar.ImageOffset = new Point(0, 0);
            btnBuscar.Location = new Point(693, 13);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.NormalBackground = Color.FromArgb(52, 152, 219);
            btnBuscar.NormalForeColor = Color.White;
            btnBuscar.NormalImageTint = Color.White;
            btnBuscar.NormalOutline = Color.FromArgb(52, 152, 219);
            btnBuscar.OutlineThickness = 1F;
            btnBuscar.PressedBackground = Color.FromArgb(36, 114, 164);
            btnBuscar.PressedForeColor = Color.White;
            btnBuscar.PressedImageTint = Color.White;
            btnBuscar.PressedOutline = Color.FromArgb(36, 114, 164);
            btnBuscar.Rounding = new Padding(4);
            btnBuscar.Size = new Size(102, 28);
            btnBuscar.TabIndex = 30;
            btnBuscar.TextAlignment = StringAlignment.Center;
            btnBuscar.TextOffset = new Point(0, 0);
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.CheckButton = false;
            btnLimpiar.Checked = false;
            btnLimpiar.CheckedBackground = Color.WhiteSmoke;
            btnLimpiar.CheckedForeColor = Color.FromArgb(51, 51, 51);
            btnLimpiar.CheckedImageTint = Color.White;
            btnLimpiar.CheckedOutline = Color.FromArgb(221, 221, 221);
            btnLimpiar.Content = "Limpiar";
            btnLimpiar.DialogResult = DialogResult.None;
            btnLimpiar.Font = new Font("Microsoft Sans Serif", 12F);
            btnLimpiar.ForeColor = Color.FromArgb(51, 51, 51);
            btnLimpiar.HoverBackground = Color.FromArgb(224, 224, 224);
            btnLimpiar.HoveredImageTint = Color.White;
            btnLimpiar.HoverForeColor = Color.FromArgb(34, 34, 34);
            btnLimpiar.HoverOutline = Color.FromArgb(204, 204, 204);
            btnLimpiar.Image = null;
            btnLimpiar.ImageAutoCenter = true;
            btnLimpiar.ImageExpand = new Point(0, 0);
            btnLimpiar.ImageOffset = new Point(0, 0);
            btnLimpiar.Location = new Point(690, 49);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.NormalBackground = Color.WhiteSmoke;
            btnLimpiar.NormalForeColor = Color.FromArgb(51, 51, 51);
            btnLimpiar.NormalImageTint = Color.White;
            btnLimpiar.NormalOutline = Color.FromArgb(221, 221, 221);
            btnLimpiar.OutlineThickness = 1F;
            btnLimpiar.PressedBackground = Color.FromArgb(208, 208, 208);
            btnLimpiar.PressedForeColor = Color.FromArgb(17, 17, 17);
            btnLimpiar.PressedImageTint = Color.White;
            btnLimpiar.PressedOutline = Color.FromArgb(187, 187, 187);
            btnLimpiar.Rounding = new Padding(4);
            btnLimpiar.Size = new Size(102, 28);
            btnLimpiar.TabIndex = 29;
            btnLimpiar.TextAlignment = StringAlignment.Center;
            btnLimpiar.TextOffset = new Point(0, 0);
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // dtpHasta
            // 
            dtpHasta.CalendarFont = new Font("Segoe UI", 10F);
            dtpHasta.CalendarForeColor = Color.Gray;
            dtpHasta.Enabled = false;
            dtpHasta.Font = new Font("Segoe UI", 12F);
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(292, 48);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(172, 29);
            dtpHasta.TabIndex = 28;
            dtpHasta.ValueChanged += dtpHasta_ValueChanged;
            // 
            // dtpDesde
            // 
            dtpDesde.CalendarFont = new Font("Segoe UI", 10F);
            dtpDesde.CalendarForeColor = Color.Gray;
            dtpDesde.Font = new Font("Segoe UI", 12F);
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(114, 48);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(172, 29);
            dtpDesde.TabIndex = 27;
            dtpDesde.ValueChanged += dtpDesde_ValueChanged;
            // 
            // txtBuscarEmail
            // 
            txtBuscarEmail.BackgroundColor = Color.White;
            txtBuscarEmail.Content = "";
            txtBuscarEmail.FocusBackgroundColor = Color.White;
            txtBuscarEmail.FocusImageTint = Color.White;
            txtBuscarEmail.FocusOutlineColor = Color.FromArgb(15, 108, 189);
            txtBuscarEmail.Font = new Font("Microsoft Sans Serif", 12F);
            txtBuscarEmail.ForeColor = Color.Gray;
            txtBuscarEmail.Image = null;
            txtBuscarEmail.ImageExpand = new Point(0, 0);
            txtBuscarEmail.ImageOffset = new Point(0, 0);
            txtBuscarEmail.Location = new Point(474, 13);
            txtBuscarEmail.Margin = new Padding(4);
            txtBuscarEmail.Multiline = false;
            txtBuscarEmail.Name = "txtBuscarEmail";
            txtBuscarEmail.NormalImageTint = Color.White;
            txtBuscarEmail.OutlineColor = Color.White;
            txtBuscarEmail.Padding = new Padding(19, 5, 19, 0);
            txtBuscarEmail.PasswordChar = false;
            txtBuscarEmail.PlaceholderColor = Color.FromArgb(64, 64, 64);
            txtBuscarEmail.PlaceholderText = "Email";
            txtBuscarEmail.Rounding = new Padding(6);
            txtBuscarEmail.Size = new Size(172, 28);
            txtBuscarEmail.TabIndex = 26;
            txtBuscarEmail.TextOffset = new Size(0, 0);
            txtBuscarEmail.UnderlinedStyle = true;
            txtBuscarEmail.Enter += txtBuscarEmail_Enter;
            txtBuscarEmail.KeyPress += txtBuscarEmail_KeyPress;
            // 
            // txtBuscarTelefono
            // 
            txtBuscarTelefono.BackgroundColor = Color.White;
            txtBuscarTelefono.Content = "";
            txtBuscarTelefono.FocusBackgroundColor = Color.White;
            txtBuscarTelefono.FocusImageTint = Color.White;
            txtBuscarTelefono.FocusOutlineColor = Color.FromArgb(15, 108, 189);
            txtBuscarTelefono.Font = new Font("Microsoft Sans Serif", 12F);
            txtBuscarTelefono.ForeColor = Color.Gray;
            txtBuscarTelefono.Image = null;
            txtBuscarTelefono.ImageExpand = new Point(0, 0);
            txtBuscarTelefono.ImageOffset = new Point(0, 0);
            txtBuscarTelefono.Location = new Point(294, 13);
            txtBuscarTelefono.Margin = new Padding(4);
            txtBuscarTelefono.Multiline = false;
            txtBuscarTelefono.Name = "txtBuscarTelefono";
            txtBuscarTelefono.NormalImageTint = Color.White;
            txtBuscarTelefono.OutlineColor = Color.White;
            txtBuscarTelefono.Padding = new Padding(19, 5, 19, 0);
            txtBuscarTelefono.PasswordChar = false;
            txtBuscarTelefono.PlaceholderColor = Color.FromArgb(64, 64, 64);
            txtBuscarTelefono.PlaceholderText = "Teléfono";
            txtBuscarTelefono.Rounding = new Padding(6);
            txtBuscarTelefono.Size = new Size(172, 28);
            txtBuscarTelefono.TabIndex = 25;
            txtBuscarTelefono.TextOffset = new Size(0, 0);
            txtBuscarTelefono.UnderlinedStyle = true;
            txtBuscarTelefono.Enter += txtBuscarTelefono_Enter;
            txtBuscarTelefono.KeyPress += txtBuscarTelefono_KeyPress;
            // 
            // txtBuscarNombre
            // 
            txtBuscarNombre.BackgroundColor = Color.White;
            txtBuscarNombre.Content = "";
            txtBuscarNombre.FocusBackgroundColor = Color.White;
            txtBuscarNombre.FocusImageTint = Color.White;
            txtBuscarNombre.FocusOutlineColor = Color.FromArgb(15, 108, 189);
            txtBuscarNombre.Font = new Font("Microsoft Sans Serif", 12F);
            txtBuscarNombre.ForeColor = Color.Gray;
            txtBuscarNombre.Image = null;
            txtBuscarNombre.ImageExpand = new Point(0, 0);
            txtBuscarNombre.ImageOffset = new Point(0, 0);
            txtBuscarNombre.Location = new Point(114, 13);
            txtBuscarNombre.Margin = new Padding(4);
            txtBuscarNombre.Multiline = false;
            txtBuscarNombre.Name = "txtBuscarNombre";
            txtBuscarNombre.NormalImageTint = Color.White;
            txtBuscarNombre.OutlineColor = Color.White;
            txtBuscarNombre.Padding = new Padding(19, 5, 19, 0);
            txtBuscarNombre.PasswordChar = false;
            txtBuscarNombre.PlaceholderColor = Color.FromArgb(64, 64, 64);
            txtBuscarNombre.PlaceholderText = "Nombre";
            txtBuscarNombre.Rounding = new Padding(6);
            txtBuscarNombre.Size = new Size(172, 28);
            txtBuscarNombre.TabIndex = 24;
            txtBuscarNombre.TextOffset = new Size(0, 0);
            txtBuscarNombre.UnderlinedStyle = true;
            txtBuscarNombre.Enter += txtBuscarNombre_Enter;
            txtBuscarNombre.KeyPress += txtBuscarNombre_KeyPress;
            // 
            // txtIdCliente
            // 
            txtIdCliente.BackgroundColor = Color.White;
            txtIdCliente.Content = "";
            txtIdCliente.FocusBackgroundColor = Color.White;
            txtIdCliente.FocusImageTint = Color.White;
            txtIdCliente.FocusOutlineColor = Color.FromArgb(15, 108, 189);
            txtIdCliente.Font = new Font("Microsoft Sans Serif", 12F);
            txtIdCliente.ForeColor = Color.Gray;
            txtIdCliente.Image = null;
            txtIdCliente.ImageExpand = new Point(0, 0);
            txtIdCliente.ImageOffset = new Point(0, 0);
            txtIdCliente.Location = new Point(12, 13);
            txtIdCliente.Margin = new Padding(4);
            txtIdCliente.Multiline = false;
            txtIdCliente.Name = "txtIdCliente";
            txtIdCliente.NormalImageTint = Color.White;
            txtIdCliente.OutlineColor = Color.White;
            txtIdCliente.Padding = new Padding(9, 5, 9, 0);
            txtIdCliente.PasswordChar = false;
            txtIdCliente.PlaceholderColor = Color.FromArgb(64, 64, 64);
            txtIdCliente.PlaceholderText = "ID Cliente";
            txtIdCliente.Rounding = new Padding(6);
            txtIdCliente.Size = new Size(94, 28);
            txtIdCliente.TabIndex = 33;
            txtIdCliente.TextOffset = new Size(-10, 0);
            txtIdCliente.UnderlinedStyle = true;
            txtIdCliente.Enter += txtIdCliente_Enter;
            txtIdCliente.KeyPress += txtIdCliente_KeyPress;
            // 
            // gpBox
            // 
            gpBox.Controls.Add(txtTotalPesos);
            gpBox.Controls.Add(lblExcel);
            gpBox.Controls.Add(txtClientesNum);
            gpBox.Controls.Add(lblCortes);
            gpBox.Controls.Add(txtCortesNum);
            gpBox.Controls.Add(lblClientes);
            gpBox.Controls.Add(btnExport);
            gpBox.Controls.Add(lblTotalFacturado);
            gpBox.Location = new Point(12, 352);
            gpBox.Name = "gpBox";
            gpBox.Size = new Size(780, 98);
            gpBox.TabIndex = 34;
            gpBox.TabStop = false;
            // 
            // txtTotalPesos
            // 
            txtTotalPesos.BackColor = Color.FromArgb(33, 33, 33);
            txtTotalPesos.BorderStyle = BorderStyle.None;
            txtTotalPesos.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            txtTotalPesos.ForeColor = Color.FromArgb(0, 255, 200);
            txtTotalPesos.Location = new Point(549, 19);
            txtTotalPesos.Name = "txtTotalPesos";
            txtTotalPesos.ReadOnly = true;
            txtTotalPesos.Size = new Size(226, 34);
            txtTotalPesos.TabIndex = 43;
            txtTotalPesos.Text = "0.00";
            txtTotalPesos.TextAlign = HorizontalAlignment.Right;
            // 
            // lblExcel
            // 
            lblExcel.AutoSize = true;
            lblExcel.Font = new Font("Segoe UI", 13F);
            lblExcel.Location = new Point(407, 62);
            lblExcel.Name = "lblExcel";
            lblExcel.Size = new Size(133, 25);
            lblExcel.TabIndex = 42;
            lblExcel.Text = "DescargarExcel:";
            // 
            // txtClientesNum
            // 
            txtClientesNum.BackgroundColor = Color.White;
            txtClientesNum.Content = "";
            txtClientesNum.FocusBackgroundColor = Color.White;
            txtClientesNum.FocusImageTint = Color.White;
            txtClientesNum.FocusOutlineColor = Color.FromArgb(15, 108, 189);
            txtClientesNum.Font = new Font("Microsoft Sans Serif", 12F);
            txtClientesNum.ForeColor = Color.Gray;
            txtClientesNum.Image = null;
            txtClientesNum.ImageExpand = new Point(0, 0);
            txtClientesNum.ImageOffset = new Point(0, 0);
            txtClientesNum.Location = new Point(277, 59);
            txtClientesNum.Margin = new Padding(4);
            txtClientesNum.Multiline = false;
            txtClientesNum.Name = "txtClientesNum";
            txtClientesNum.NormalImageTint = Color.White;
            txtClientesNum.OutlineColor = Color.White;
            txtClientesNum.Padding = new Padding(19, 5, 19, 0);
            txtClientesNum.PasswordChar = false;
            txtClientesNum.PlaceholderColor = Color.FromArgb(64, 64, 64);
            txtClientesNum.PlaceholderText = "0";
            txtClientesNum.RightToLeft = RightToLeft.Yes;
            txtClientesNum.Rounding = new Padding(6);
            txtClientesNum.Size = new Size(123, 28);
            txtClientesNum.TabIndex = 41;
            txtClientesNum.TextOffset = new Size(0, 0);
            txtClientesNum.UnderlinedStyle = true;
            // 
            // lblCortes
            // 
            lblCortes.AutoSize = true;
            lblCortes.Font = new Font("Segoe UI", 13F);
            lblCortes.Location = new Point(193, 62);
            lblCortes.Name = "lblCortes";
            lblCortes.Size = new Size(77, 25);
            lblCortes.TabIndex = 40;
            lblCortes.Text = "Clientes:";
            // 
            // txtCortesNum
            // 
            txtCortesNum.BackgroundColor = Color.White;
            txtCortesNum.Content = "";
            txtCortesNum.FocusBackgroundColor = Color.White;
            txtCortesNum.FocusImageTint = Color.White;
            txtCortesNum.FocusOutlineColor = Color.FromArgb(15, 108, 189);
            txtCortesNum.Font = new Font("Microsoft Sans Serif", 12F);
            txtCortesNum.ForeColor = Color.Gray;
            txtCortesNum.Image = null;
            txtCortesNum.ImageExpand = new Point(0, 0);
            txtCortesNum.ImageOffset = new Point(0, 0);
            txtCortesNum.Location = new Point(277, 23);
            txtCortesNum.Margin = new Padding(4);
            txtCortesNum.Multiline = false;
            txtCortesNum.Name = "txtCortesNum";
            txtCortesNum.NormalImageTint = Color.White;
            txtCortesNum.OutlineColor = Color.White;
            txtCortesNum.Padding = new Padding(19, 5, 19, 0);
            txtCortesNum.PasswordChar = false;
            txtCortesNum.PlaceholderColor = Color.FromArgb(64, 64, 64);
            txtCortesNum.PlaceholderText = "0";
            txtCortesNum.RightToLeft = RightToLeft.Yes;
            txtCortesNum.Rounding = new Padding(6);
            txtCortesNum.Size = new Size(123, 28);
            txtCortesNum.TabIndex = 39;
            txtCortesNum.TextOffset = new Size(0, 0);
            txtCortesNum.UnderlinedStyle = true;
            // 
            // lblClientes
            // 
            lblClientes.AutoSize = true;
            lblClientes.Font = new Font("Segoe UI", 13F);
            lblClientes.Location = new Point(193, 26);
            lblClientes.Name = "lblClientes";
            lblClientes.Size = new Size(67, 25);
            lblClientes.TabIndex = 38;
            lblClientes.Text = "Cortes:";
            // 
            // btnExport
            // 
            btnExport.CheckButton = false;
            btnExport.Checked = false;
            btnExport.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnExport.CheckedForeColor = Color.White;
            btnExport.CheckedImageTint = Color.White;
            btnExport.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnExport.Content = "";
            btnExport.DialogResult = DialogResult.None;
            btnExport.Font = new Font("Microsoft Sans Serif", 9.75F);
            btnExport.ForeColor = Color.Black;
            btnExport.HoverBackground = Color.White;
            btnExport.HoveredImageTint = Color.White;
            btnExport.HoverForeColor = Color.Black;
            btnExport.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnExport.Image = Properties.Resources.download;
            btnExport.ImageAutoCenter = true;
            btnExport.ImageExpand = new Point(10, 10);
            btnExport.ImageOffset = new Point(0, 0);
            btnExport.Location = new Point(546, 62);
            btnExport.Name = "btnExport";
            btnExport.NormalBackground = SystemColors.Control;
            btnExport.NormalForeColor = Color.Black;
            btnExport.NormalImageTint = Color.White;
            btnExport.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnExport.OutlineThickness = 1F;
            btnExport.PressedBackground = Color.WhiteSmoke;
            btnExport.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnExport.PressedImageTint = Color.White;
            btnExport.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnExport.Rounding = new Padding(6);
            btnExport.Size = new Size(228, 27);
            btnExport.TabIndex = 37;
            btnExport.TextAlignment = StringAlignment.Center;
            btnExport.TextOffset = new Point(0, 0);
            btnExport.Click += btnExport_Click;
            // 
            // lblTotalFacturado
            // 
            lblTotalFacturado.AutoSize = true;
            lblTotalFacturado.Font = new Font("Segoe UI", 13F);
            lblTotalFacturado.Location = new Point(409, 26);
            lblTotalFacturado.Name = "lblTotalFacturado";
            lblTotalFacturado.Size = new Size(134, 25);
            lblTotalFacturado.TabIndex = 36;
            lblTotalFacturado.Text = "Total facturado:";
            // 
            // txtIdCorte
            // 
            txtIdCorte.BackgroundColor = Color.White;
            txtIdCorte.Content = "";
            txtIdCorte.FocusBackgroundColor = Color.White;
            txtIdCorte.FocusImageTint = Color.White;
            txtIdCorte.FocusOutlineColor = Color.FromArgb(15, 108, 189);
            txtIdCorte.Font = new Font("Microsoft Sans Serif", 12F);
            txtIdCorte.ForeColor = Color.Gray;
            txtIdCorte.Image = null;
            txtIdCorte.ImageExpand = new Point(0, 0);
            txtIdCorte.ImageOffset = new Point(0, 0);
            txtIdCorte.Location = new Point(12, 49);
            txtIdCorte.Margin = new Padding(4);
            txtIdCorte.Multiline = false;
            txtIdCorte.Name = "txtIdCorte";
            txtIdCorte.NormalImageTint = Color.White;
            txtIdCorte.OutlineColor = Color.White;
            txtIdCorte.Padding = new Padding(9, 5, 9, 0);
            txtIdCorte.PasswordChar = false;
            txtIdCorte.PlaceholderColor = Color.FromArgb(64, 64, 64);
            txtIdCorte.PlaceholderText = "ID Corte";
            txtIdCorte.Rounding = new Padding(6);
            txtIdCorte.Size = new Size(94, 28);
            txtIdCorte.TabIndex = 35;
            txtIdCorte.TextOffset = new Size(-10, 0);
            txtIdCorte.UnderlinedStyle = true;
            txtIdCorte.Enter += txtIdCorte_Enter;
            txtIdCorte.KeyPress += txtIdCorte_KeyPress;
            // 
            // cckbRango
            // 
            cckbRango.AutoSize = true;
            cckbRango.Location = new Point(474, 54);
            cckbRango.Name = "cckbRango";
            cckbRango.Size = new Size(60, 19);
            cckbRango.TabIndex = 36;
            cckbRango.Text = "Rango";
            cckbRango.UseVisualStyleBackColor = true;
            cckbRango.CheckedChanged += cckbRango_CheckedChanged;
            // 
            // FrmFacturacion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(804, 462);
            Controls.Add(cckbRango);
            Controls.Add(txtIdCorte);
            Controls.Add(gpBox);
            Controls.Add(txtIdCliente);
            Controls.Add(lblCargarTodos);
            Controls.Add(btnBuscar);
            Controls.Add(btnLimpiar);
            Controls.Add(dtpHasta);
            Controls.Add(dtpDesde);
            Controls.Add(txtBuscarEmail);
            Controls.Add(txtBuscarTelefono);
            Controls.Add(txtBuscarNombre);
            Controls.Add(dgvFacturacion);
            Name = "FrmFacturacion";
            Text = "FrmFacturacion";
            ((System.ComponentModel.ISupportInitialize)dgvFacturacion).EndInit();
            gpBox.ResumeLayout(false);
            gpBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvFacturacion;
        private Label lblCargarTodos;
        private CuoreUI.Controls.cuiButton btnBuscar;
        private CuoreUI.Controls.cuiButton btnLimpiar;
        private DateTimePicker dtpHasta;
        private DateTimePicker dtpDesde;
        private CuoreUI.Controls.cuiTextBox txtBuscarEmail;
        private CuoreUI.Controls.cuiTextBox txtBuscarTelefono;
        private CuoreUI.Controls.cuiTextBox txtBuscarNombre;
        private CuoreUI.Controls.cuiTextBox txtIdCliente;
        private GroupBox gpBox;
        private Label lblTotalFacturado;
        private CuoreUI.Controls.cuiButton btnExport;
        private Label lblClientes;
        private CuoreUI.Controls.cuiTextBox txtCortesNum;
        private CuoreUI.Controls.cuiTextBox txtClientesNum;
        private Label lblCortes;
        private Label lblExcel;
        private TextBox txtTotalPesos;
        private CuoreUI.Controls.cuiTextBox txtIdCorte;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn fechaCreacion;
        private DataGridViewTextBoxColumn cliente;
        private DataGridViewTextBoxColumn descripcion;
        private DataGridViewTextBoxColumn cobro;
        private DataGridViewTextBoxColumn clienteId;
        private CheckBox cckbRango;
    }
}