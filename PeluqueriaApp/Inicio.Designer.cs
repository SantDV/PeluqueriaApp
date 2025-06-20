namespace PeluqueriaApp
{
    partial class Form1
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
            dgvClientes = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            nombre = new DataGridViewTextBoxColumn();
            telefono = new DataGridViewTextBoxColumn();
            mail = new DataGridViewTextBoxColumn();
            txtBuscarNombre = new CuoreUI.Controls.cuiTextBox();
            cuiTextBox2 = new CuoreUI.Controls.cuiTextBox();
            cuiTextBox3 = new CuoreUI.Controls.cuiTextBox();
            btnNuevo = new CuoreUI.Controls.cuiButton();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // dgvClientes
            // 
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Columns.AddRange(new DataGridViewColumn[] { id, nombre, telefono, mail });
            dgvClientes.Location = new Point(12, 84);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.Size = new Size(646, 356);
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
            // mail
            // 
            mail.HeaderText = "Mail";
            mail.Name = "mail";
            // 
            // txtBuscarNombre
            // 
            txtBuscarNombre.BackgroundColor = Color.White;
            txtBuscarNombre.Content = "";
            txtBuscarNombre.FocusBackgroundColor = Color.White;
            txtBuscarNombre.FocusImageTint = Color.White;
            txtBuscarNombre.FocusOutlineColor = Color.FromArgb(255, 106, 0);
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
            // cuiTextBox2
            // 
            cuiTextBox2.BackgroundColor = Color.White;
            cuiTextBox2.Content = "";
            cuiTextBox2.FocusBackgroundColor = Color.White;
            cuiTextBox2.FocusImageTint = Color.White;
            cuiTextBox2.FocusOutlineColor = Color.FromArgb(255, 106, 0);
            cuiTextBox2.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cuiTextBox2.ForeColor = Color.Gray;
            cuiTextBox2.Image = null;
            cuiTextBox2.ImageExpand = new Point(0, 0);
            cuiTextBox2.ImageOffset = new Point(0, 0);
            cuiTextBox2.Location = new Point(192, 32);
            cuiTextBox2.Margin = new Padding(4);
            cuiTextBox2.Multiline = false;
            cuiTextBox2.Name = "cuiTextBox2";
            cuiTextBox2.NormalImageTint = Color.White;
            cuiTextBox2.OutlineColor = Color.White;
            cuiTextBox2.Padding = new Padding(15, 7, 15, 0);
            cuiTextBox2.PasswordChar = false;
            cuiTextBox2.PlaceholderColor = Color.FromArgb(64, 64, 64);
            cuiTextBox2.PlaceholderText = "Teléfono";
            cuiTextBox2.Rounding = new Padding(6);
            cuiTextBox2.Size = new Size(172, 28);
            cuiTextBox2.TabIndex = 2;
            cuiTextBox2.TextOffset = new Size(0, 0);
            cuiTextBox2.UnderlinedStyle = true;
            // 
            // cuiTextBox3
            // 
            cuiTextBox3.BackgroundColor = Color.White;
            cuiTextBox3.Content = "";
            cuiTextBox3.FocusBackgroundColor = Color.White;
            cuiTextBox3.FocusImageTint = Color.White;
            cuiTextBox3.FocusOutlineColor = Color.FromArgb(255, 106, 0);
            cuiTextBox3.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cuiTextBox3.ForeColor = Color.Gray;
            cuiTextBox3.Image = null;
            cuiTextBox3.ImageExpand = new Point(0, 0);
            cuiTextBox3.ImageOffset = new Point(0, 0);
            cuiTextBox3.Location = new Point(372, 32);
            cuiTextBox3.Margin = new Padding(4);
            cuiTextBox3.Multiline = false;
            cuiTextBox3.Name = "cuiTextBox3";
            cuiTextBox3.NormalImageTint = Color.White;
            cuiTextBox3.OutlineColor = Color.White;
            cuiTextBox3.Padding = new Padding(15, 7, 15, 0);
            cuiTextBox3.PasswordChar = false;
            cuiTextBox3.PlaceholderColor = Color.FromArgb(64, 64, 64);
            cuiTextBox3.PlaceholderText = "Email";
            cuiTextBox3.Rounding = new Padding(6);
            cuiTextBox3.Size = new Size(172, 28);
            cuiTextBox3.TabIndex = 3;
            cuiTextBox3.TextOffset = new Size(0, 0);
            cuiTextBox3.UnderlinedStyle = true;
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
            btnNuevo.Image = Properties.Resources.add;
            btnNuevo.ImageAutoCenter = true;
            btnNuevo.ImageExpand = new Point(6, 6);
            btnNuevo.ImageOffset = new Point(0, 0);
            btnNuevo.Location = new Point(630, 32);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.NormalBackground = Color.Gainsboro;
            btnNuevo.NormalForeColor = Color.Black;
            btnNuevo.NormalImageTint = Color.White;
            btnNuevo.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnNuevo.OutlineThickness = 1F;
            btnNuevo.PressedBackground = Color.WhiteSmoke;
            btnNuevo.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnNuevo.PressedImageTint = Color.White;
            btnNuevo.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnNuevo.Rounding = new Padding(4);
            btnNuevo.Size = new Size(28, 28);
            btnNuevo.TabIndex = 4;
            btnNuevo.TextAlignment = StringAlignment.Center;
            btnNuevo.TextOffset = new Point(0, 0);
            btnNuevo.Click += btnNuevo_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(670, 452);
            Controls.Add(btnNuevo);
            Controls.Add(cuiTextBox3);
            Controls.Add(cuiTextBox2);
            Controls.Add(txtBuscarNombre);
            Controls.Add(dgvClientes);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvClientes;
        private CuoreUI.Controls.cuiTextBox txtBuscarNombre;
        private CuoreUI.Controls.cuiTextBox cuiTextBox2;
        private CuoreUI.Controls.cuiTextBox cuiTextBox3;
        private CuoreUI.Controls.cuiButton btnNuevo;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn nombre;
        private DataGridViewTextBoxColumn telefono;
        private DataGridViewTextBoxColumn mail;
    }
}
