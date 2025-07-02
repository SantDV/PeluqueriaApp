namespace PeluqueriaApp
{
    partial class DetalleCobro
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
            txtNombre = new CuoreUI.Controls.cuiTextBox();
            lblIdCliente1 = new Label();
            lblNombre = new Label();
            lblMonto = new Label();
            dtpFecha = new DateTimePicker();
            lblIdCliente = new Label();
            txtMonto = new CuoreUI.Controls.cuiTextBox();
            txtDescripcion = new RichTextBox();
            btnEliminar = new CuoreUI.Controls.cuiButton();
            btnModificar = new CuoreUI.Controls.cuiButton();
            btnGuardar = new CuoreUI.Controls.cuiButton();
            lblIdCobro = new Label();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.BackgroundColor = Color.White;
            txtNombre.Content = "";
            txtNombre.Enabled = false;
            txtNombre.FocusBackgroundColor = Color.White;
            txtNombre.FocusImageTint = Color.White;
            txtNombre.FocusOutlineColor = Color.FromArgb(15, 108, 189);
            txtNombre.Font = new Font("Microsoft Sans Serif", 12F);
            txtNombre.ForeColor = Color.Gray;
            txtNombre.Image = null;
            txtNombre.ImageExpand = new Point(0, 0);
            txtNombre.ImageOffset = new Point(0, 0);
            txtNombre.Location = new Point(116, 88);
            txtNombre.Margin = new Padding(4);
            txtNombre.Multiline = false;
            txtNombre.Name = "txtNombre";
            txtNombre.NormalImageTint = Color.White;
            txtNombre.OutlineColor = Color.White;
            txtNombre.Padding = new Padding(19, 5, 19, 0);
            txtNombre.PasswordChar = false;
            txtNombre.PlaceholderColor = Color.FromArgb(64, 64, 64);
            txtNombre.PlaceholderText = "Nombre";
            txtNombre.Rounding = new Padding(6);
            txtNombre.Size = new Size(248, 28);
            txtNombre.TabIndex = 2;
            txtNombre.TextOffset = new Size(0, 0);
            txtNombre.UnderlinedStyle = true;
            // 
            // lblIdCliente1
            // 
            lblIdCliente1.AutoSize = true;
            lblIdCliente1.Cursor = Cursors.Hand;
            lblIdCliente1.Font = new Font("Segoe UI Semibold", 12.75F, FontStyle.Bold);
            lblIdCliente1.Location = new Point(13, 50);
            lblIdCliente1.Name = "lblIdCliente1";
            lblIdCliente1.Size = new Size(96, 23);
            lblIdCliente1.TabIndex = 32;
            lblIdCliente1.Text = "ID CLIENTE";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Cursor = Cursors.Hand;
            lblNombre.Font = new Font("Segoe UI Semibold", 12.75F, FontStyle.Bold);
            lblNombre.Location = new Point(13, 95);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(96, 23);
            lblNombre.TabIndex = 33;
            lblNombre.Text = "ID CLIENTE";
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.Cursor = Cursors.Hand;
            lblMonto.Font = new Font("Segoe UI Semibold", 12.75F, FontStyle.Bold);
            lblMonto.Location = new Point(13, 139);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(73, 23);
            lblMonto.TabIndex = 34;
            lblMonto.Text = "MONTO";
            // 
            // dtpFecha
            // 
            dtpFecha.Enabled = false;
            dtpFecha.Font = new Font("Segoe UI", 13F);
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(116, 12);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(248, 31);
            dtpFecha.TabIndex = 35;
            // 
            // lblIdCliente
            // 
            lblIdCliente.AutoSize = true;
            lblIdCliente.Cursor = Cursors.Hand;
            lblIdCliente.Enabled = false;
            lblIdCliente.Font = new Font("Segoe UI", 12.75F);
            lblIdCliente.Location = new Point(116, 50);
            lblIdCliente.Name = "lblIdCliente";
            lblIdCliente.Size = new Size(96, 23);
            lblIdCliente.TabIndex = 36;
            lblIdCliente.Text = "ID CLIENTE";
            // 
            // txtMonto
            // 
            txtMonto.BackgroundColor = Color.White;
            txtMonto.Content = "";
            txtMonto.Enabled = false;
            txtMonto.FocusBackgroundColor = Color.White;
            txtMonto.FocusImageTint = Color.White;
            txtMonto.FocusOutlineColor = Color.FromArgb(15, 108, 189);
            txtMonto.Font = new Font("Microsoft Sans Serif", 12F);
            txtMonto.ForeColor = Color.Gray;
            txtMonto.Image = null;
            txtMonto.ImageExpand = new Point(0, 0);
            txtMonto.ImageOffset = new Point(0, 0);
            txtMonto.Location = new Point(116, 139);
            txtMonto.Margin = new Padding(4);
            txtMonto.Multiline = false;
            txtMonto.Name = "txtMonto";
            txtMonto.NormalImageTint = Color.White;
            txtMonto.OutlineColor = Color.White;
            txtMonto.Padding = new Padding(19, 5, 19, 0);
            txtMonto.PasswordChar = false;
            txtMonto.PlaceholderColor = Color.FromArgb(64, 64, 64);
            txtMonto.PlaceholderText = "0,00";
            txtMonto.Rounding = new Padding(6);
            txtMonto.Size = new Size(248, 28);
            txtMonto.TabIndex = 37;
            txtMonto.TextOffset = new Size(0, 0);
            txtMonto.UnderlinedStyle = true;
            txtMonto.KeyPress += txtMonto_KeyPress;
            txtMonto.Leave += txtMonto_Leave;
            // 
            // txtDescripcion
            // 
            txtDescripcion.BackColor = Color.White;
            txtDescripcion.Font = new Font("Segoe UI", 13F);
            txtDescripcion.Location = new Point(21, 199);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.ReadOnly = true;
            txtDescripcion.Size = new Size(343, 109);
            txtDescripcion.TabIndex = 38;
            txtDescripcion.Text = "";
            // 
            // btnEliminar
            // 
            btnEliminar.CheckButton = false;
            btnEliminar.Checked = false;
            btnEliminar.CheckedBackground = Color.WhiteSmoke;
            btnEliminar.CheckedForeColor = Color.FromArgb(51, 51, 51);
            btnEliminar.CheckedImageTint = Color.White;
            btnEliminar.CheckedOutline = Color.FromArgb(221, 221, 221);
            btnEliminar.Content = "";
            btnEliminar.DialogResult = DialogResult.None;
            btnEliminar.Font = new Font("Microsoft Sans Serif", 12F);
            btnEliminar.ForeColor = Color.FromArgb(51, 51, 51);
            btnEliminar.HoverBackground = Color.FromArgb(224, 224, 224);
            btnEliminar.HoveredImageTint = Color.White;
            btnEliminar.HoverForeColor = Color.FromArgb(34, 34, 34);
            btnEliminar.HoverOutline = Color.FromArgb(204, 204, 204);
            btnEliminar.Image = Properties.Resources.delete;
            btnEliminar.ImageAutoCenter = true;
            btnEliminar.ImageExpand = new Point(7, 7);
            btnEliminar.ImageOffset = new Point(0, 0);
            btnEliminar.Location = new Point(220, 314);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.NormalBackground = Color.WhiteSmoke;
            btnEliminar.NormalForeColor = Color.FromArgb(51, 51, 51);
            btnEliminar.NormalImageTint = Color.White;
            btnEliminar.NormalOutline = Color.FromArgb(221, 221, 221);
            btnEliminar.OutlineThickness = 1F;
            btnEliminar.PressedBackground = Color.FromArgb(208, 208, 208);
            btnEliminar.PressedForeColor = Color.FromArgb(17, 17, 17);
            btnEliminar.PressedImageTint = Color.White;
            btnEliminar.PressedOutline = Color.FromArgb(187, 187, 187);
            btnEliminar.Rounding = new Padding(4);
            btnEliminar.Size = new Size(32, 36);
            btnEliminar.TabIndex = 39;
            btnEliminar.TextAlignment = StringAlignment.Center;
            btnEliminar.TextOffset = new Point(0, 0);
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.CheckButton = false;
            btnModificar.Checked = false;
            btnModificar.CheckedBackground = Color.WhiteSmoke;
            btnModificar.CheckedForeColor = Color.FromArgb(51, 51, 51);
            btnModificar.CheckedImageTint = Color.White;
            btnModificar.CheckedOutline = Color.FromArgb(221, 221, 221);
            btnModificar.Content = "";
            btnModificar.DialogResult = DialogResult.None;
            btnModificar.Font = new Font("Microsoft Sans Serif", 12F);
            btnModificar.ForeColor = Color.FromArgb(51, 51, 51);
            btnModificar.HoverBackground = Color.FromArgb(224, 224, 224);
            btnModificar.HoveredImageTint = Color.White;
            btnModificar.HoverForeColor = Color.FromArgb(34, 34, 34);
            btnModificar.HoverOutline = Color.FromArgb(204, 204, 204);
            btnModificar.Image = Properties.Resources.edit;
            btnModificar.ImageAutoCenter = true;
            btnModificar.ImageExpand = new Point(7, 7);
            btnModificar.ImageOffset = new Point(0, 0);
            btnModificar.Location = new Point(258, 314);
            btnModificar.Name = "btnModificar";
            btnModificar.NormalBackground = Color.WhiteSmoke;
            btnModificar.NormalForeColor = Color.FromArgb(51, 51, 51);
            btnModificar.NormalImageTint = Color.White;
            btnModificar.NormalOutline = Color.FromArgb(221, 221, 221);
            btnModificar.OutlineThickness = 1F;
            btnModificar.PressedBackground = Color.FromArgb(208, 208, 208);
            btnModificar.PressedForeColor = Color.FromArgb(17, 17, 17);
            btnModificar.PressedImageTint = Color.White;
            btnModificar.PressedOutline = Color.FromArgb(187, 187, 187);
            btnModificar.Rounding = new Padding(4);
            btnModificar.Size = new Size(32, 36);
            btnModificar.TabIndex = 40;
            btnModificar.TextAlignment = StringAlignment.Center;
            btnModificar.TextOffset = new Point(0, 0);
            btnModificar.Click += btnModificar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.CheckButton = false;
            btnGuardar.Checked = false;
            btnGuardar.CheckedBackground = Color.WhiteSmoke;
            btnGuardar.CheckedForeColor = Color.FromArgb(51, 51, 51);
            btnGuardar.CheckedImageTint = Color.White;
            btnGuardar.CheckedOutline = Color.FromArgb(221, 221, 221);
            btnGuardar.Content = "";
            btnGuardar.DialogResult = DialogResult.None;
            btnGuardar.Enabled = false;
            btnGuardar.Font = new Font("Microsoft Sans Serif", 12F);
            btnGuardar.ForeColor = Color.FromArgb(51, 51, 51);
            btnGuardar.HoverBackground = Color.FromArgb(224, 224, 224);
            btnGuardar.HoveredImageTint = Color.White;
            btnGuardar.HoverForeColor = Color.FromArgb(34, 34, 34);
            btnGuardar.HoverOutline = Color.FromArgb(204, 204, 204);
            btnGuardar.Image = Properties.Resources.save2;
            btnGuardar.ImageAutoCenter = true;
            btnGuardar.ImageExpand = new Point(8, 8);
            btnGuardar.ImageOffset = new Point(0, 0);
            btnGuardar.Location = new Point(296, 314);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.NormalBackground = Color.WhiteSmoke;
            btnGuardar.NormalForeColor = Color.FromArgb(51, 51, 51);
            btnGuardar.NormalImageTint = Color.White;
            btnGuardar.NormalOutline = Color.FromArgb(221, 221, 221);
            btnGuardar.OutlineThickness = 1F;
            btnGuardar.PressedBackground = Color.FromArgb(208, 208, 208);
            btnGuardar.PressedForeColor = Color.FromArgb(17, 17, 17);
            btnGuardar.PressedImageTint = Color.White;
            btnGuardar.PressedOutline = Color.FromArgb(187, 187, 187);
            btnGuardar.Rounding = new Padding(4);
            btnGuardar.Size = new Size(68, 36);
            btnGuardar.TabIndex = 41;
            btnGuardar.TextAlignment = StringAlignment.Center;
            btnGuardar.TextOffset = new Point(0, 0);
            btnGuardar.Click += btnGuardar_Click;
            // 
            // lblIdCobro
            // 
            lblIdCobro.AutoSize = true;
            lblIdCobro.Cursor = Cursors.Hand;
            lblIdCobro.Font = new Font("Segoe UI Semibold", 12.75F, FontStyle.Bold);
            lblIdCobro.Location = new Point(13, 18);
            lblIdCobro.Name = "lblIdCobro";
            lblIdCobro.Size = new Size(27, 23);
            lblIdCobro.TabIndex = 42;
            lblIdCobro.Text = "ID";
            // 
            // DetalleCobro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(376, 362);
            Controls.Add(lblIdCobro);
            Controls.Add(btnGuardar);
            Controls.Add(btnModificar);
            Controls.Add(btnEliminar);
            Controls.Add(txtDescripcion);
            Controls.Add(txtMonto);
            Controls.Add(lblIdCliente);
            Controls.Add(dtpFecha);
            Controls.Add(lblMonto);
            Controls.Add(lblNombre);
            Controls.Add(lblIdCliente1);
            Controls.Add(txtNombre);
            Name = "DetalleCobro";
            Text = "DetalleCobro";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CuoreUI.Controls.cuiTextBox txtNombre;
        private Label lblIdCliente1;
        private Label lblNombre;
        private Label lblMonto;
        private DateTimePicker dtpFecha;
        private Label lblIdCliente;
        private CuoreUI.Controls.cuiTextBox txtMonto;
        private RichTextBox txtDescripcion;
        private CuoreUI.Controls.cuiButton btnEliminar;
        private CuoreUI.Controls.cuiButton btnModificar;
        private CuoreUI.Controls.cuiButton btnGuardar;
        private Label lblIdCobro;
    }
}