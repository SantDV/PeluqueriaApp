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
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            btnLimpiar = new CuoreUI.Controls.cuiButton();
            btnBuscar = new CuoreUI.Controls.cuiButton();
            customerCount = new CuoreUI.Controls.cuiButton();
            lblCustomerCount = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // dgvClientes
            // 
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Columns.AddRange(new DataGridViewColumn[] { id, nombre, telefono, email, fechaCreacion });
            dgvClientes.Location = new Point(12, 114);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.Size = new Size(706, 373);
            dgvClientes.TabIndex = 0;
            dgvClientes.CellClick += dgvClientes_CellClick;
            // 
            // id
            // 
            id.HeaderText = "ID";
            id.Name = "id";
            // 
            // nombre
            // 
            nombre.HeaderText = "Nombre";
            nombre.Name = "nombre";
            // 
            // telefono
            // 
            telefono.HeaderText = "Teléfono";
            telefono.Name = "telefono";
            // 
            // email
            // 
            email.HeaderText = "Email";
            email.Name = "email";
            // 
            // fechaCreacion
            // 
            fechaCreacion.HeaderText = "Feche Creación";
            fechaCreacion.Name = "fechaCreacion";
            // 
            // txtBuscarNombre
            // 
            txtBuscarNombre.BackgroundColor = Color.White;
            txtBuscarNombre.Content = "";
            txtBuscarNombre.FocusBackgroundColor = Color.White;
            txtBuscarNombre.FocusImageTint = Color.White;
            txtBuscarNombre.FocusOutlineColor = Color.FromArgb(15, 108, 189);
            txtBuscarNombre.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscarNombre.ForeColor = Color.Gray;
            txtBuscarNombre.Image = null;
            txtBuscarNombre.ImageExpand = new Point(0, 0);
            txtBuscarNombre.ImageOffset = new Point(0, 0);
            txtBuscarNombre.Location = new Point(12, 32);
            txtBuscarNombre.Margin = new Padding(4);
            txtBuscarNombre.Multiline = false;
            txtBuscarNombre.Name = "txtBuscarNombre";
            txtBuscarNombre.NormalImageTint = Color.White;
            txtBuscarNombre.OutlineColor = Color.White;
            txtBuscarNombre.Padding = new Padding(15, 7, 15, 0);
            txtBuscarNombre.PasswordChar = false;
            txtBuscarNombre.PlaceholderColor = Color.FromArgb(64, 64, 64);
            txtBuscarNombre.PlaceholderText = "Nombre";
            txtBuscarNombre.Rounding = new Padding(6);
            txtBuscarNombre.Size = new Size(172, 28);
            txtBuscarNombre.TabIndex = 1;
            txtBuscarNombre.TextOffset = new Size(0, 0);
            txtBuscarNombre.UnderlinedStyle = true;
            txtBuscarNombre.KeyPress += txtBuscarNombre_KeyPress;
            // 
            // txtBuscarTelefono
            // 
            txtBuscarTelefono.BackgroundColor = Color.White;
            txtBuscarTelefono.Content = "";
            txtBuscarTelefono.FocusBackgroundColor = Color.White;
            txtBuscarTelefono.FocusImageTint = Color.White;
            txtBuscarTelefono.FocusOutlineColor = Color.FromArgb(15, 108, 189);
            txtBuscarTelefono.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscarTelefono.ForeColor = Color.Gray;
            txtBuscarTelefono.Image = null;
            txtBuscarTelefono.ImageExpand = new Point(0, 0);
            txtBuscarTelefono.ImageOffset = new Point(0, 0);
            txtBuscarTelefono.Location = new Point(192, 32);
            txtBuscarTelefono.Margin = new Padding(4);
            txtBuscarTelefono.Multiline = false;
            txtBuscarTelefono.Name = "txtBuscarTelefono";
            txtBuscarTelefono.NormalImageTint = Color.White;
            txtBuscarTelefono.OutlineColor = Color.White;
            txtBuscarTelefono.Padding = new Padding(15, 7, 15, 0);
            txtBuscarTelefono.PasswordChar = false;
            txtBuscarTelefono.PlaceholderColor = Color.FromArgb(64, 64, 64);
            txtBuscarTelefono.PlaceholderText = "Teléfono";
            txtBuscarTelefono.Rounding = new Padding(6);
            txtBuscarTelefono.Size = new Size(172, 28);
            txtBuscarTelefono.TabIndex = 2;
            txtBuscarTelefono.TextOffset = new Size(0, 0);
            txtBuscarTelefono.UnderlinedStyle = true;
            txtBuscarTelefono.KeyPress += txtBuscarTelefono_KeyPress;
            // 
            // txtBuscarEmail
            // 
            txtBuscarEmail.BackgroundColor = Color.White;
            txtBuscarEmail.Content = "";
            txtBuscarEmail.FocusBackgroundColor = Color.White;
            txtBuscarEmail.FocusImageTint = Color.White;
            txtBuscarEmail.FocusOutlineColor = Color.FromArgb(15, 108, 189);
            txtBuscarEmail.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscarEmail.ForeColor = Color.Gray;
            txtBuscarEmail.Image = null;
            txtBuscarEmail.ImageExpand = new Point(0, 0);
            txtBuscarEmail.ImageOffset = new Point(0, 0);
            txtBuscarEmail.Location = new Point(372, 32);
            txtBuscarEmail.Margin = new Padding(4);
            txtBuscarEmail.Multiline = false;
            txtBuscarEmail.Name = "txtBuscarEmail";
            txtBuscarEmail.NormalImageTint = Color.White;
            txtBuscarEmail.OutlineColor = Color.White;
            txtBuscarEmail.Padding = new Padding(15, 7, 15, 0);
            txtBuscarEmail.PasswordChar = false;
            txtBuscarEmail.PlaceholderColor = Color.FromArgb(64, 64, 64);
            txtBuscarEmail.PlaceholderText = "Email";
            txtBuscarEmail.Rounding = new Padding(6);
            txtBuscarEmail.Size = new Size(172, 28);
            txtBuscarEmail.TabIndex = 3;
            txtBuscarEmail.TextOffset = new Size(0, 0);
            txtBuscarEmail.UnderlinedStyle = true;
            txtBuscarEmail.KeyPress += txtBuscarEmail_KeyPress;
            // 
            // btnNuevo
            // 
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
            btnNuevo.Image = Properties.Resources.register;
            btnNuevo.ImageAutoCenter = true;
            btnNuevo.ImageExpand = new Point(6, 6);
            btnNuevo.ImageOffset = new Point(0, 0);
            btnNuevo.Location = new Point(682, 24);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.NormalBackground = Color.WhiteSmoke;
            btnNuevo.NormalForeColor = Color.Black;
            btnNuevo.NormalImageTint = Color.White;
            btnNuevo.NormalOutline = Color.WhiteSmoke;
            btnNuevo.OutlineThickness = 1F;
            btnNuevo.PressedBackground = Color.WhiteSmoke;
            btnNuevo.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnNuevo.PressedImageTint = Color.White;
            btnNuevo.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnNuevo.Rounding = new Padding(4);
            btnNuevo.Size = new Size(36, 36);
            btnNuevo.TabIndex = 4;
            btnNuevo.TextAlignment = StringAlignment.Center;
            btnNuevo.TextOffset = new Point(0, 0);
            btnNuevo.Click += btnNuevo_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarFont = new Font("Segoe UI", 10F);
            dateTimePicker1.CalendarForeColor = Color.Gray;
            dateTimePicker1.Font = new Font("Segoe UI", 10F);
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(14, 72);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(172, 25);
            dateTimePicker1.TabIndex = 5;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CalendarFont = new Font("Segoe UI", 10F);
            dateTimePicker2.CalendarForeColor = Color.Gray;
            dateTimePicker2.Font = new Font("Segoe UI", 10F);
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Location = new Point(192, 72);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(172, 25);
            dateTimePicker2.TabIndex = 6;
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
            btnLimpiar.Font = new Font("Microsoft Sans Serif", 9.75F);
            btnLimpiar.ForeColor = Color.FromArgb(51, 51, 51);
            btnLimpiar.HoverBackground = Color.FromArgb(224, 224, 224);
            btnLimpiar.HoveredImageTint = Color.White;
            btnLimpiar.HoverForeColor = Color.FromArgb(34, 34, 34);
            btnLimpiar.HoverOutline = Color.FromArgb(204, 204, 204);
            btnLimpiar.Image = null;
            btnLimpiar.ImageAutoCenter = true;
            btnLimpiar.ImageExpand = new Point(0, 0);
            btnLimpiar.ImageOffset = new Point(0, 0);
            btnLimpiar.Location = new Point(508, 72);
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
            btnLimpiar.TabIndex = 7;
            btnLimpiar.TextAlignment = StringAlignment.Center;
            btnLimpiar.TextOffset = new Point(0, 0);
            btnLimpiar.Click += btnLimpiar_Click;
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
            btnBuscar.Font = new Font("Microsoft Sans Serif", 9.75F);
            btnBuscar.ForeColor = Color.White;
            btnBuscar.HoverBackground = Color.FromArgb(41, 128, 185);
            btnBuscar.HoveredImageTint = Color.White;
            btnBuscar.HoverForeColor = Color.White;
            btnBuscar.HoverOutline = Color.FromArgb(41, 128, 185);
            btnBuscar.Image = null;
            btnBuscar.ImageAutoCenter = true;
            btnBuscar.ImageExpand = new Point(0, 0);
            btnBuscar.ImageOffset = new Point(0, 0);
            btnBuscar.Location = new Point(616, 72);
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
            btnBuscar.TabIndex = 8;
            btnBuscar.TextAlignment = StringAlignment.Center;
            btnBuscar.TextOffset = new Point(0, 0);
            // 
            // customerCount
            // 
            customerCount.CheckButton = false;
            customerCount.Checked = false;
            customerCount.CheckedBackground = Color.FromArgb(255, 106, 0);
            customerCount.CheckedForeColor = Color.White;
            customerCount.CheckedImageTint = Color.White;
            customerCount.CheckedOutline = Color.FromArgb(255, 106, 0);
            customerCount.Content = "";
            customerCount.DialogResult = DialogResult.None;
            customerCount.Font = new Font("Microsoft Sans Serif", 9.75F);
            customerCount.ForeColor = Color.Black;
            customerCount.HoverBackground = Color.White;
            customerCount.HoveredImageTint = Color.White;
            customerCount.HoverForeColor = Color.Black;
            customerCount.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            customerCount.Image = Properties.Resources.cliente;
            customerCount.ImageAutoCenter = true;
            customerCount.ImageExpand = new Point(6, 6);
            customerCount.ImageOffset = new Point(0, 0);
            customerCount.Location = new Point(12, 493);
            customerCount.Name = "customerCount";
            customerCount.NormalBackground = SystemColors.Control;
            customerCount.NormalForeColor = Color.Black;
            customerCount.NormalImageTint = Color.White;
            customerCount.NormalOutline = Color.WhiteSmoke;
            customerCount.OutlineThickness = 1F;
            customerCount.PressedBackground = Color.WhiteSmoke;
            customerCount.PressedForeColor = Color.FromArgb(32, 32, 32);
            customerCount.PressedImageTint = Color.White;
            customerCount.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            customerCount.Rounding = new Padding(4);
            customerCount.Size = new Size(26, 26);
            customerCount.TabIndex = 9;
            customerCount.TextAlignment = StringAlignment.Center;
            customerCount.TextOffset = new Point(0, 0);
            // 
            // lblCustomerCount
            // 
            lblCustomerCount.AutoSize = true;
            lblCustomerCount.Location = new Point(44, 499);
            lblCustomerCount.Name = "lblCustomerCount";
            lblCustomerCount.Size = new Size(38, 15);
            lblCustomerCount.TabIndex = 10;
            lblCustomerCount.Text = "label1";
            // 
            // ClientesGestion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(730, 520);
            Controls.Add(lblCustomerCount);
            Controls.Add(customerCount);
            Controls.Add(btnBuscar);
            Controls.Add(btnLimpiar);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(btnNuevo);
            Controls.Add(txtBuscarEmail);
            Controls.Add(txtBuscarTelefono);
            Controls.Add(txtBuscarNombre);
            Controls.Add(dgvClientes);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ClientesGestion";
            Text = "CorteApp";
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvClientes;
        private CuoreUI.Controls.cuiTextBox txtBuscarNombre;
        private CuoreUI.Controls.cuiTextBox txtBuscarTelefono;
        private CuoreUI.Controls.cuiTextBox txtBuscarEmail;
        private CuoreUI.Controls.cuiButton btnNuevo;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private CuoreUI.Controls.cuiButton btnLimpiar;
        private CuoreUI.Controls.cuiButton btnBuscar;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn nombre;
        private DataGridViewTextBoxColumn telefono;
        private DataGridViewTextBoxColumn email;
        private DataGridViewTextBoxColumn fechaCreacion;
        private CuoreUI.Controls.cuiButton customerCount;
        private Label lblCustomerCount;
    }
}
