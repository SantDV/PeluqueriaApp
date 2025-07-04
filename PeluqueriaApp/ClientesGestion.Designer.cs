namespace PeluqueriaApp
{
    partial class ClientesGestion
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientesGestion));
            dgvClientes = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            nombre = new DataGridViewTextBoxColumn();
            telefono = new DataGridViewTextBoxColumn();
            email = new DataGridViewTextBoxColumn();
            fechaCreacion = new DataGridViewTextBoxColumn();
            txtBuscarNombre = new CuoreUI.Controls.cuiTextBox();
            txtBuscarTelefono = new CuoreUI.Controls.cuiTextBox();
            txtBuscarEmail = new CuoreUI.Controls.cuiTextBox();
            btnNuevo = new CuoreUI.Controls.cuiButton();
            dtpDesde = new DateTimePicker();
            dtpHasta = new DateTimePicker();
            btnLimpiar = new CuoreUI.Controls.cuiButton();
            btnBuscar = new CuoreUI.Controls.cuiButton();
            lblCargarTodo = new Label();
            cckbRango = new CheckBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvClientes
            // 
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Columns.AddRange(new DataGridViewColumn[] { id, nombre, telefono, email, fechaCreacion });
            dgvClientes.Dock = DockStyle.Fill;
            dgvClientes.Location = new Point(0, 119);
            dgvClientes.Margin = new Padding(3, 3, 10, 3);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.Size = new Size(811, 340);
            dgvClientes.TabIndex = 0;
            dgvClientes.CellClick += dgvClientes_CellClick;
            // 
            // id
            // 
            id.HeaderText = "ID";
            id.Name = "id";
            id.ReadOnly = true;
            // 
            // nombre
            // 
            nombre.HeaderText = "Nombre";
            nombre.Name = "nombre";
            nombre.ReadOnly = true;
            // 
            // telefono
            // 
            telefono.HeaderText = "Teléfono";
            telefono.Name = "telefono";
            telefono.ReadOnly = true;
            // 
            // email
            // 
            email.HeaderText = "Email";
            email.Name = "email";
            email.ReadOnly = true;
            // 
            // fechaCreacion
            // 
            fechaCreacion.HeaderText = "Feche Creación";
            fechaCreacion.Name = "fechaCreacion";
            fechaCreacion.ReadOnly = true;
            // 
            // txtBuscarNombre
            // 
            txtBuscarNombre.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
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
            txtBuscarNombre.Location = new Point(3, 15);
            txtBuscarNombre.Margin = new Padding(3, 15, 3, 3);
            txtBuscarNombre.MaximumSize = new Size(230, 35);
            txtBuscarNombre.Multiline = false;
            txtBuscarNombre.Name = "txtBuscarNombre";
            txtBuscarNombre.NormalImageTint = Color.White;
            txtBuscarNombre.OutlineColor = Color.White;
            txtBuscarNombre.Padding = new Padding(19, 5, 19, 0);
            txtBuscarNombre.PasswordChar = false;
            txtBuscarNombre.PlaceholderColor = Color.FromArgb(64, 64, 64);
            txtBuscarNombre.PlaceholderText = "Nombre";
            txtBuscarNombre.Rounding = new Padding(6);
            txtBuscarNombre.Size = new Size(156, 28);
            txtBuscarNombre.TabIndex = 1;
            txtBuscarNombre.TextOffset = new Size(0, 0);
            txtBuscarNombre.UnderlinedStyle = true;
            txtBuscarNombre.Enter += txtBuscarNombre_Enter;
            txtBuscarNombre.KeyPress += txtBuscarNombre_KeyPress;
            // 
            // txtBuscarTelefono
            // 
            txtBuscarTelefono.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
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
            txtBuscarTelefono.Location = new Point(165, 15);
            txtBuscarTelefono.Margin = new Padding(3, 15, 3, 3);
            txtBuscarTelefono.MaximumSize = new Size(230, 35);
            txtBuscarTelefono.Multiline = false;
            txtBuscarTelefono.Name = "txtBuscarTelefono";
            txtBuscarTelefono.NormalImageTint = Color.White;
            txtBuscarTelefono.OutlineColor = Color.White;
            txtBuscarTelefono.Padding = new Padding(19, 5, 19, 0);
            txtBuscarTelefono.PasswordChar = false;
            txtBuscarTelefono.PlaceholderColor = Color.FromArgb(64, 64, 64);
            txtBuscarTelefono.PlaceholderText = "Teléfono";
            txtBuscarTelefono.Rounding = new Padding(6);
            txtBuscarTelefono.Size = new Size(156, 28);
            txtBuscarTelefono.TabIndex = 2;
            txtBuscarTelefono.TextOffset = new Size(0, 0);
            txtBuscarTelefono.UnderlinedStyle = true;
            txtBuscarTelefono.Enter += txtBuscarTelefono_Enter;
            txtBuscarTelefono.KeyPress += txtBuscarTelefono_KeyPress;
            // 
            // txtBuscarEmail
            // 
            txtBuscarEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
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
            txtBuscarEmail.Location = new Point(327, 15);
            txtBuscarEmail.Margin = new Padding(3, 15, 3, 3);
            txtBuscarEmail.MaximumSize = new Size(230, 35);
            txtBuscarEmail.Multiline = false;
            txtBuscarEmail.Name = "txtBuscarEmail";
            txtBuscarEmail.NormalImageTint = Color.White;
            txtBuscarEmail.OutlineColor = Color.White;
            txtBuscarEmail.Padding = new Padding(19, 5, 19, 0);
            txtBuscarEmail.PasswordChar = false;
            txtBuscarEmail.PlaceholderColor = Color.FromArgb(64, 64, 64);
            txtBuscarEmail.PlaceholderText = "Email";
            txtBuscarEmail.Rounding = new Padding(6);
            txtBuscarEmail.Size = new Size(156, 28);
            txtBuscarEmail.TabIndex = 3;
            txtBuscarEmail.TextOffset = new Size(0, 0);
            txtBuscarEmail.UnderlinedStyle = true;
            txtBuscarEmail.Enter += txtBuscarEmail_Enter;
            txtBuscarEmail.KeyPress += txtBuscarEmail_KeyPress;
            // 
            // btnNuevo
            // 
            btnNuevo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnNuevo.CheckButton = false;
            btnNuevo.Checked = false;
            btnNuevo.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnNuevo.CheckedForeColor = Color.White;
            btnNuevo.CheckedImageTint = Color.White;
            btnNuevo.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnNuevo.Content = "";
            btnNuevo.DialogResult = DialogResult.None;
            btnNuevo.Font = new Font("Microsoft Sans Serif", 9.75F);
            btnNuevo.ForeColor = Color.Black;
            btnNuevo.HoverBackground = Color.White;
            btnNuevo.HoveredImageTint = Color.White;
            btnNuevo.HoverForeColor = Color.Black;
            btnNuevo.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnNuevo.Image = Properties.Resources.add1;
            btnNuevo.ImageAutoCenter = true;
            btnNuevo.ImageExpand = new Point(6, 6);
            btnNuevo.ImageOffset = new Point(0, 0);
            btnNuevo.Location = new Point(651, 15);
            btnNuevo.Margin = new Padding(3, 15, 3, 3);
            btnNuevo.MaximumSize = new Size(230, 35);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.NormalBackground = Color.Gainsboro;
            btnNuevo.NormalForeColor = Color.Black;
            btnNuevo.NormalImageTint = Color.White;
            btnNuevo.NormalOutline = Color.WhiteSmoke;
            btnNuevo.OutlineThickness = 1F;
            btnNuevo.PressedBackground = Color.WhiteSmoke;
            btnNuevo.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnNuevo.PressedImageTint = Color.White;
            btnNuevo.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnNuevo.Rounding = new Padding(4);
            btnNuevo.Size = new Size(157, 28);
            btnNuevo.TabIndex = 4;
            btnNuevo.TextAlignment = StringAlignment.Center;
            btnNuevo.TextOffset = new Point(0, 0);
            btnNuevo.Click += btnNuevo_Click;
            // 
            // dtpDesde
            // 
            dtpDesde.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpDesde.CalendarFont = new Font("Segoe UI", 10F);
            dtpDesde.CalendarForeColor = Color.Gray;
            dtpDesde.Font = new Font("Segoe UI", 12F);
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(3, 74);
            dtpDesde.Margin = new Padding(3, 15, 3, 3);
            dtpDesde.MaximumSize = new Size(230, 35);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(156, 29);
            dtpDesde.TabIndex = 5;
            dtpDesde.ValueChanged += dtpDesde_ValueChanged;
            // 
            // dtpHasta
            // 
            dtpHasta.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpHasta.CalendarFont = new Font("Segoe UI", 10F);
            dtpHasta.CalendarForeColor = Color.Gray;
            dtpHasta.Enabled = false;
            dtpHasta.Font = new Font("Segoe UI", 12F);
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(165, 74);
            dtpHasta.Margin = new Padding(3, 15, 3, 3);
            dtpHasta.MaximumSize = new Size(230, 35);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(156, 29);
            dtpHasta.TabIndex = 6;
            dtpHasta.ValueChanged += hasta_ValueChanged;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
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
            btnLimpiar.Location = new Point(489, 74);
            btnLimpiar.Margin = new Padding(3, 15, 3, 3);
            btnLimpiar.MaximumSize = new Size(230, 35);
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
            btnLimpiar.Size = new Size(156, 28);
            btnLimpiar.TabIndex = 7;
            btnLimpiar.TextAlignment = StringAlignment.Center;
            btnLimpiar.TextOffset = new Point(0, 0);
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
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
            btnBuscar.Location = new Point(489, 15);
            btnBuscar.Margin = new Padding(3, 15, 3, 3);
            btnBuscar.MaximumSize = new Size(230, 35);
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
            btnBuscar.Size = new Size(156, 28);
            btnBuscar.TabIndex = 8;
            btnBuscar.TextAlignment = StringAlignment.Center;
            btnBuscar.TextOffset = new Point(0, 0);
            btnBuscar.Click += btnBuscar_Click;
            // 
            // lblCargarTodo
            // 
            lblCargarTodo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblCargarTodo.AutoSize = true;
            lblCargarTodo.Cursor = Cursors.Hand;
            lblCargarTodo.Font = new Font("Segoe UI", 12F);
            lblCargarTodo.Location = new Point(83, 5);
            lblCargarTodo.Name = "lblCargarTodo";
            lblCargarTodo.Size = new Size(60, 21);
            lblCargarTodo.TabIndex = 23;
            lblCargarTodo.Text = "[Todos]";
            lblCargarTodo.Click += lblCargarTodo_Click;
            lblCargarTodo.MouseEnter += lblCargarTodo_MouseEnter;
            lblCargarTodo.MouseLeave += lblCargarTodo_MouseLeave;
            // 
            // cckbRango
            // 
            cckbRango.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cckbRango.AutoSize = true;
            cckbRango.Font = new Font("Segoe UI", 12F);
            cckbRango.Location = new Point(3, 3);
            cckbRango.Name = "cckbRango";
            cckbRango.Size = new Size(74, 25);
            cckbRango.TabIndex = 37;
            cckbRango.Text = "Rango";
            cckbRango.UseVisualStyleBackColor = true;
            cckbRango.CheckedChanged += cckbRango_CheckedChanged;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 5;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.Controls.Add(btnNuevo, 4, 0);
            tableLayoutPanel2.Controls.Add(txtBuscarNombre, 0, 0);
            tableLayoutPanel2.Controls.Add(dtpDesde, 0, 1);
            tableLayoutPanel2.Controls.Add(dtpHasta, 1, 1);
            tableLayoutPanel2.Controls.Add(txtBuscarTelefono, 1, 0);
            tableLayoutPanel2.Controls.Add(btnBuscar, 3, 0);
            tableLayoutPanel2.Controls.Add(txtBuscarEmail, 2, 0);
            tableLayoutPanel2.Controls.Add(flowLayoutPanel1, 2, 1);
            tableLayoutPanel2.Controls.Add(btnLimpiar, 3, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(811, 119);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(cckbRango);
            flowLayoutPanel1.Controls.Add(lblCargarTodo);
            flowLayoutPanel1.Location = new Point(327, 62);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(155, 54);
            flowLayoutPanel1.TabIndex = 10;
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(811, 119);
            panel1.TabIndex = 39;
            // 
            // ClientesGestion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(811, 459);
            Controls.Add(dgvClientes);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ClientesGestion";
            Text = "CorteApp";
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvClientes;
        private CuoreUI.Controls.cuiTextBox txtBuscarNombre;
        private CuoreUI.Controls.cuiTextBox txtBuscarTelefono;
        private CuoreUI.Controls.cuiTextBox txtBuscarEmail;
        private CuoreUI.Controls.cuiButton btnNuevo;
        private DateTimePicker dtpDesde;
        private DateTimePicker dtpHasta;
        private CuoreUI.Controls.cuiButton btnLimpiar;
        private CuoreUI.Controls.cuiButton btnBuscar;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn nombre;
        private DataGridViewTextBoxColumn telefono;
        private DataGridViewTextBoxColumn email;
        private DataGridViewTextBoxColumn fechaCreacion;
        private Label lblCargarTodo;
        private CheckBox cckbRango;
        private TableLayoutPanel tableLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel1;
    }
}
