
namespace PeluqueriaApp
{
    partial class ClienteCortes
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
            btnFullScreen = new CuoreUI.Controls.cuiButton();
            btnSizeMode = new CuoreUI.Controls.cuiButton();
            btnRotar = new CuoreUI.Controls.cuiButton();
            ptbCliente = new PictureBox();
            txtObservacion = new RichTextBox();
            txtEmail = new CuoreUI.Controls.cuiTextBox();
            txtTelefono = new CuoreUI.Controls.cuiTextBox();
            txtNombre = new CuoreUI.Controls.cuiTextBox();
            dgvCortes = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            fecha = new DataGridViewTextBoxColumn();
            descripcion = new DataGridViewTextBoxColumn();
            costo = new DataGridViewTextBoxColumn();
            lblNuevoCorte = new Label();
            lblEliminarCorte = new Label();
            btnGuardar = new CuoreUI.Controls.cuiButton();
            txtPrecio = new CuoreUI.Controls.cuiTextBox();
            btnGaleria = new CuoreUI.Controls.cuiButton();
            txtDomicilio = new CuoreUI.Controls.cuiTextBox();
            ((System.ComponentModel.ISupportInitialize)ptbCliente).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCortes).BeginInit();
            SuspendLayout();
            // 
            // btnFullScreen
            // 
            btnFullScreen.CheckButton = false;
            btnFullScreen.Checked = false;
            btnFullScreen.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnFullScreen.CheckedForeColor = Color.White;
            btnFullScreen.CheckedImageTint = Color.White;
            btnFullScreen.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnFullScreen.Content = "";
            btnFullScreen.DialogResult = DialogResult.None;
            btnFullScreen.Font = new Font("Microsoft Sans Serif", 9.75F);
            btnFullScreen.ForeColor = Color.Black;
            btnFullScreen.HoverBackground = Color.White;
            btnFullScreen.HoveredImageTint = Color.White;
            btnFullScreen.HoverForeColor = Color.Black;
            btnFullScreen.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnFullScreen.Image = Properties.Resources.fullScreen1;
            btnFullScreen.ImageAutoCenter = true;
            btnFullScreen.ImageExpand = new Point(2, 2);
            btnFullScreen.ImageOffset = new Point(0, 0);
            btnFullScreen.Location = new Point(517, 47);
            btnFullScreen.Name = "btnFullScreen";
            btnFullScreen.NormalBackground = SystemColors.Control;
            btnFullScreen.NormalForeColor = Color.Black;
            btnFullScreen.NormalImageTint = Color.White;
            btnFullScreen.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnFullScreen.OutlineThickness = 1F;
            btnFullScreen.PressedBackground = Color.WhiteSmoke;
            btnFullScreen.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnFullScreen.PressedImageTint = Color.White;
            btnFullScreen.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnFullScreen.Rounding = new Padding(4);
            btnFullScreen.Size = new Size(24, 25);
            btnFullScreen.TabIndex = 19;
            btnFullScreen.TextAlignment = StringAlignment.Center;
            btnFullScreen.TextOffset = new Point(0, 0);
            btnFullScreen.Click += btnFullScreen_Click;
            // 
            // btnSizeMode
            // 
            btnSizeMode.CheckButton = false;
            btnSizeMode.Checked = false;
            btnSizeMode.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnSizeMode.CheckedForeColor = Color.White;
            btnSizeMode.CheckedImageTint = Color.White;
            btnSizeMode.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnSizeMode.Content = "";
            btnSizeMode.DialogResult = DialogResult.None;
            btnSizeMode.Font = new Font("Microsoft Sans Serif", 9.75F);
            btnSizeMode.ForeColor = Color.Black;
            btnSizeMode.HoverBackground = Color.White;
            btnSizeMode.HoveredImageTint = Color.White;
            btnSizeMode.HoverForeColor = Color.Black;
            btnSizeMode.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnSizeMode.Image = Properties.Resources.sizeMode1;
            btnSizeMode.ImageAutoCenter = true;
            btnSizeMode.ImageExpand = new Point(2, 2);
            btnSizeMode.ImageOffset = new Point(0, 0);
            btnSizeMode.Location = new Point(487, 47);
            btnSizeMode.Name = "btnSizeMode";
            btnSizeMode.NormalBackground = SystemColors.Control;
            btnSizeMode.NormalForeColor = Color.Black;
            btnSizeMode.NormalImageTint = Color.White;
            btnSizeMode.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnSizeMode.OutlineThickness = 1F;
            btnSizeMode.PressedBackground = Color.WhiteSmoke;
            btnSizeMode.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnSizeMode.PressedImageTint = Color.White;
            btnSizeMode.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnSizeMode.Rounding = new Padding(4);
            btnSizeMode.Size = new Size(24, 25);
            btnSizeMode.TabIndex = 18;
            btnSizeMode.TextAlignment = StringAlignment.Center;
            btnSizeMode.TextOffset = new Point(0, 0);
            btnSizeMode.Click += btnSizeMode_Click;
            // 
            // btnRotar
            // 
            btnRotar.CheckButton = false;
            btnRotar.Checked = false;
            btnRotar.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnRotar.CheckedForeColor = Color.White;
            btnRotar.CheckedImageTint = Color.White;
            btnRotar.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnRotar.Content = "";
            btnRotar.DialogResult = DialogResult.None;
            btnRotar.Font = new Font("Microsoft Sans Serif", 9.75F);
            btnRotar.ForeColor = Color.Black;
            btnRotar.HoverBackground = Color.White;
            btnRotar.HoveredImageTint = Color.White;
            btnRotar.HoverForeColor = Color.Black;
            btnRotar.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnRotar.Image = Properties.Resources.rotateRight1;
            btnRotar.ImageAutoCenter = true;
            btnRotar.ImageExpand = new Point(2, 2);
            btnRotar.ImageOffset = new Point(0, 0);
            btnRotar.Location = new Point(457, 47);
            btnRotar.Name = "btnRotar";
            btnRotar.NormalBackground = SystemColors.Control;
            btnRotar.NormalForeColor = Color.Black;
            btnRotar.NormalImageTint = Color.White;
            btnRotar.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnRotar.OutlineThickness = 1F;
            btnRotar.PressedBackground = Color.WhiteSmoke;
            btnRotar.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnRotar.PressedImageTint = Color.White;
            btnRotar.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnRotar.Rounding = new Padding(4);
            btnRotar.Size = new Size(24, 25);
            btnRotar.TabIndex = 17;
            btnRotar.TextAlignment = StringAlignment.Center;
            btnRotar.TextOffset = new Point(0, 0);
            btnRotar.Click += btnRotar_Click;
            // 
            // ptbCliente
            // 
            ptbCliente.BackColor = Color.Gainsboro;
            ptbCliente.BackgroundImage = Properties.Resources.addPhoto;
            ptbCliente.BackgroundImageLayout = ImageLayout.Center;
            ptbCliente.Enabled = false;
            ptbCliente.Location = new Point(330, 62);
            ptbCliente.Name = "ptbCliente";
            ptbCliente.Size = new Size(324, 286);
            ptbCliente.SizeMode = PictureBoxSizeMode.Zoom;
            ptbCliente.TabIndex = 16;
            ptbCliente.TabStop = false;
            ptbCliente.Click += ptbCliente_Click;
            // 
            // txtObservacion
            // 
            txtObservacion.Location = new Point(12, 240);
            txtObservacion.Name = "txtObservacion";
            txtObservacion.Size = new Size(237, 108);
            txtObservacion.TabIndex = 5;
            txtObservacion.Text = "";
            // 
            // txtEmail
            // 
            txtEmail.BackgroundColor = Color.White;
            txtEmail.Content = "";
            txtEmail.Enabled = false;
            txtEmail.FocusBackgroundColor = Color.White;
            txtEmail.FocusImageTint = Color.White;
            txtEmail.FocusOutlineColor = Color.FromArgb(255, 106, 0);
            txtEmail.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.ForeColor = Color.Gray;
            txtEmail.Image = null;
            txtEmail.ImageExpand = new Point(0, 0);
            txtEmail.ImageOffset = new Point(0, 0);
            txtEmail.Location = new Point(13, 134);
            txtEmail.Margin = new Padding(4);
            txtEmail.Multiline = false;
            txtEmail.Name = "txtEmail";
            txtEmail.NormalImageTint = Color.White;
            txtEmail.OutlineColor = Color.White;
            txtEmail.Padding = new Padding(15, 7, 15, 0);
            txtEmail.PasswordChar = false;
            txtEmail.PlaceholderColor = Color.FromArgb(64, 64, 64);
            txtEmail.PlaceholderText = "Email";
            txtEmail.Rounding = new Padding(6);
            txtEmail.Size = new Size(237, 28);
            txtEmail.TabIndex = 2;
            txtEmail.TextOffset = new Size(0, 0);
            txtEmail.UnderlinedStyle = true;
            // 
            // txtTelefono
            // 
            txtTelefono.BackgroundColor = Color.White;
            txtTelefono.Content = "";
            txtTelefono.Enabled = false;
            txtTelefono.FocusBackgroundColor = Color.White;
            txtTelefono.FocusImageTint = Color.White;
            txtTelefono.FocusOutlineColor = Color.FromArgb(255, 106, 0);
            txtTelefono.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTelefono.ForeColor = Color.Gray;
            txtTelefono.Image = null;
            txtTelefono.ImageExpand = new Point(0, 0);
            txtTelefono.ImageOffset = new Point(0, 0);
            txtTelefono.Location = new Point(13, 98);
            txtTelefono.Margin = new Padding(4);
            txtTelefono.Multiline = false;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.NormalImageTint = Color.White;
            txtTelefono.OutlineColor = Color.White;
            txtTelefono.Padding = new Padding(15, 7, 15, 0);
            txtTelefono.PasswordChar = false;
            txtTelefono.PlaceholderColor = Color.FromArgb(64, 64, 64);
            txtTelefono.PlaceholderText = "Teléfono";
            txtTelefono.Rounding = new Padding(6);
            txtTelefono.Size = new Size(237, 28);
            txtTelefono.TabIndex = 1;
            txtTelefono.TextOffset = new Size(0, 0);
            txtTelefono.UnderlinedStyle = true;
            // 
            // txtNombre
            // 
            txtNombre.BackgroundColor = Color.White;
            txtNombre.Content = "";
            txtNombre.Enabled = false;
            txtNombre.FocusBackgroundColor = Color.White;
            txtNombre.FocusImageTint = Color.White;
            txtNombre.FocusOutlineColor = Color.FromArgb(255, 106, 0);
            txtNombre.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.ForeColor = Color.Gray;
            txtNombre.Image = null;
            txtNombre.ImageExpand = new Point(0, 0);
            txtNombre.ImageOffset = new Point(0, 0);
            txtNombre.Location = new Point(13, 62);
            txtNombre.Margin = new Padding(4);
            txtNombre.Multiline = false;
            txtNombre.Name = "txtNombre";
            txtNombre.NormalImageTint = Color.White;
            txtNombre.OutlineColor = Color.White;
            txtNombre.Padding = new Padding(15, 7, 15, 0);
            txtNombre.PasswordChar = false;
            txtNombre.PlaceholderColor = Color.FromArgb(64, 64, 64);
            txtNombre.PlaceholderText = "Nombre";
            txtNombre.Rounding = new Padding(6);
            txtNombre.Size = new Size(237, 28);
            txtNombre.TabIndex = 0;
            txtNombre.TextOffset = new Size(0, 0);
            txtNombre.UnderlinedStyle = true;
            // 
            // dgvCortes
            // 
            dgvCortes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCortes.Columns.AddRange(new DataGridViewColumn[] { id, fecha, descripcion, costo });
            dgvCortes.Location = new Point(12, 371);
            dgvCortes.Name = "dgvCortes";
            dgvCortes.Size = new Size(642, 221);
            dgvCortes.TabIndex = 5;
            dgvCortes.CellClick += dgvCortes_CellClick;
            dgvCortes.CellMouseEnter += dgvCortes_CellMouseEnter;
            dgvCortes.CellMouseLeave += dgvCortes_CellMouseLeave;
            // 
            // id
            // 
            id.HeaderText = "ID";
            id.Name = "id";
            // 
            // fecha
            // 
            fecha.HeaderText = "Fecha";
            fecha.Name = "fecha";
            // 
            // descripcion
            // 
            descripcion.HeaderText = "Descripción";
            descripcion.Name = "descripcion";
            // 
            // costo
            // 
            costo.HeaderText = "Costo";
            costo.Name = "costo";
            // 
            // lblNuevoCorte
            // 
            lblNuevoCorte.AutoSize = true;
            lblNuevoCorte.Cursor = Cursors.Hand;
            lblNuevoCorte.Location = new Point(13, 9);
            lblNuevoCorte.Name = "lblNuevoCorte";
            lblNuevoCorte.Size = new Size(100, 15);
            lblNuevoCorte.TabIndex = 22;
            lblNuevoCorte.Text = "[+] Agregar Corte";
            lblNuevoCorte.Click += lblNuevoCorte_Click;
            lblNuevoCorte.MouseEnter += lblNuevoCorte_MouseEnter;
            lblNuevoCorte.MouseLeave += lblNuevoCorte_MouseLeave;
            // 
            // lblEliminarCorte
            // 
            lblEliminarCorte.AutoSize = true;
            lblEliminarCorte.Cursor = Cursors.Hand;
            lblEliminarCorte.ForeColor = Color.Red;
            lblEliminarCorte.Location = new Point(13, 26);
            lblEliminarCorte.Name = "lblEliminarCorte";
            lblEliminarCorte.Size = new Size(98, 15);
            lblEliminarCorte.TabIndex = 23;
            lblEliminarCorte.Text = "[-] Eliminar Corte";
            lblEliminarCorte.Click += lblEliminarCorte_Click;
            lblEliminarCorte.MouseEnter += lblEliminarCorte_MouseEnter;
            lblEliminarCorte.MouseLeave += lblEliminarCorte_MouseLeave;
            // 
            // btnGuardar
            // 
            btnGuardar.CheckButton = false;
            btnGuardar.Checked = false;
            btnGuardar.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnGuardar.CheckedForeColor = Color.White;
            btnGuardar.CheckedImageTint = Color.White;
            btnGuardar.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnGuardar.Content = "";
            btnGuardar.DialogResult = DialogResult.None;
            btnGuardar.Enabled = false;
            btnGuardar.Font = new Font("Microsoft Sans Serif", 9.75F);
            btnGuardar.ForeColor = Color.Black;
            btnGuardar.HoverBackground = Color.White;
            btnGuardar.HoveredImageTint = Color.White;
            btnGuardar.HoverForeColor = Color.Black;
            btnGuardar.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnGuardar.Image = Properties.Resources.save1;
            btnGuardar.ImageAutoCenter = true;
            btnGuardar.ImageExpand = new Point(10, 10);
            btnGuardar.ImageOffset = new Point(0, 0);
            btnGuardar.Location = new Point(217, 9);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.NormalBackground = Color.White;
            btnGuardar.NormalForeColor = Color.Black;
            btnGuardar.NormalImageTint = Color.White;
            btnGuardar.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnGuardar.OutlineThickness = 1F;
            btnGuardar.PressedBackground = Color.WhiteSmoke;
            btnGuardar.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnGuardar.PressedImageTint = Color.White;
            btnGuardar.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnGuardar.Rounding = new Padding(3);
            btnGuardar.Size = new Size(32, 32);
            btnGuardar.TabIndex = 6;
            btnGuardar.TextAlignment = StringAlignment.Center;
            btnGuardar.TextOffset = new Point(0, 0);
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtPrecio
            // 
            txtPrecio.BackgroundColor = Color.White;
            txtPrecio.Content = "";
            txtPrecio.Enabled = false;
            txtPrecio.FocusBackgroundColor = Color.White;
            txtPrecio.FocusImageTint = Color.White;
            txtPrecio.FocusOutlineColor = Color.FromArgb(255, 106, 0);
            txtPrecio.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPrecio.ForeColor = Color.Gray;
            txtPrecio.Image = null;
            txtPrecio.ImageExpand = new Point(0, 0);
            txtPrecio.ImageOffset = new Point(0, 0);
            txtPrecio.Location = new Point(13, 205);
            txtPrecio.Margin = new Padding(4);
            txtPrecio.Multiline = false;
            txtPrecio.Name = "txtPrecio";
            txtPrecio.NormalImageTint = Color.White;
            txtPrecio.OutlineColor = Color.White;
            txtPrecio.Padding = new Padding(15, 7, 15, 0);
            txtPrecio.PasswordChar = false;
            txtPrecio.PlaceholderColor = Color.FromArgb(64, 64, 64);
            txtPrecio.PlaceholderText = "Precio";
            txtPrecio.Rounding = new Padding(6);
            txtPrecio.Size = new Size(237, 28);
            txtPrecio.TabIndex = 4;
            txtPrecio.TextOffset = new Size(0, 0);
            txtPrecio.UnderlinedStyle = true;
            txtPrecio.KeyPress += txtPrecio_KeyPress;
            txtPrecio.Leave += txtPrecio_Leave;
            // 
            // btnGaleria
            // 
            btnGaleria.CheckButton = false;
            btnGaleria.Checked = false;
            btnGaleria.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnGaleria.CheckedForeColor = Color.White;
            btnGaleria.CheckedImageTint = Color.White;
            btnGaleria.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnGaleria.Content = "";
            btnGaleria.DialogResult = DialogResult.None;
            btnGaleria.Font = new Font("Microsoft Sans Serif", 9.75F);
            btnGaleria.ForeColor = Color.Black;
            btnGaleria.HoverBackground = Color.White;
            btnGaleria.HoveredImageTint = Color.White;
            btnGaleria.HoverForeColor = Color.Black;
            btnGaleria.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnGaleria.Image = Properties.Resources.gallery3;
            btnGaleria.ImageAutoCenter = true;
            btnGaleria.ImageExpand = new Point(10, 10);
            btnGaleria.ImageOffset = new Point(0, 0);
            btnGaleria.Location = new Point(622, 9);
            btnGaleria.Name = "btnGaleria";
            btnGaleria.NormalBackground = Color.White;
            btnGaleria.NormalForeColor = Color.Black;
            btnGaleria.NormalImageTint = Color.White;
            btnGaleria.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnGaleria.OutlineThickness = 1F;
            btnGaleria.PressedBackground = Color.WhiteSmoke;
            btnGaleria.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnGaleria.PressedImageTint = Color.White;
            btnGaleria.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnGaleria.Rounding = new Padding(3);
            btnGaleria.Size = new Size(32, 32);
            btnGaleria.TabIndex = 25;
            btnGaleria.TextAlignment = StringAlignment.Center;
            btnGaleria.TextOffset = new Point(0, 0);
            btnGaleria.Click += btnGaleria_Click_1;
            // 
            // txtDomicilio
            // 
            txtDomicilio.BackgroundColor = Color.White;
            txtDomicilio.Content = "";
            txtDomicilio.Enabled = false;
            txtDomicilio.FocusBackgroundColor = Color.White;
            txtDomicilio.FocusImageTint = Color.White;
            txtDomicilio.FocusOutlineColor = Color.FromArgb(255, 106, 0);
            txtDomicilio.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDomicilio.ForeColor = Color.Gray;
            txtDomicilio.Image = null;
            txtDomicilio.ImageExpand = new Point(0, 0);
            txtDomicilio.ImageOffset = new Point(0, 0);
            txtDomicilio.Location = new Point(13, 170);
            txtDomicilio.Margin = new Padding(4);
            txtDomicilio.Multiline = false;
            txtDomicilio.Name = "txtDomicilio";
            txtDomicilio.NormalImageTint = Color.White;
            txtDomicilio.OutlineColor = Color.White;
            txtDomicilio.Padding = new Padding(15, 7, 15, 0);
            txtDomicilio.PasswordChar = false;
            txtDomicilio.PlaceholderColor = Color.FromArgb(64, 64, 64);
            txtDomicilio.PlaceholderText = "Domicilio";
            txtDomicilio.Rounding = new Padding(6);
            txtDomicilio.Size = new Size(237, 28);
            txtDomicilio.TabIndex = 3;
            txtDomicilio.TextOffset = new Size(0, 0);
            txtDomicilio.UnderlinedStyle = true;
            // 
            // ClienteCortes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(666, 604);
            Controls.Add(txtDomicilio);
            Controls.Add(btnGaleria);
            Controls.Add(txtPrecio);
            Controls.Add(btnGuardar);
            Controls.Add(lblEliminarCorte);
            Controls.Add(lblNuevoCorte);
            Controls.Add(dgvCortes);
            Controls.Add(btnFullScreen);
            Controls.Add(btnSizeMode);
            Controls.Add(btnRotar);
            Controls.Add(ptbCliente);
            Controls.Add(txtObservacion);
            Controls.Add(txtEmail);
            Controls.Add(txtTelefono);
            Controls.Add(txtNombre);
            Name = "ClienteCortes";
            Text = "Cliente";
            Load += Cliente_Load;
            ((System.ComponentModel.ISupportInitialize)ptbCliente).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCortes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private CuoreUI.Controls.cuiButton btnFullScreen;
        private CuoreUI.Controls.cuiButton btnSizeMode;
        private CuoreUI.Controls.cuiButton btnRotar;
        private PictureBox ptbCliente;
        private RichTextBox txtObservacion;
        private CuoreUI.Controls.cuiTextBox txtEmail;
        private CuoreUI.Controls.cuiTextBox txtTelefono;
        private CuoreUI.Controls.cuiTextBox txtNombre;
        private DataGridView dgvCortes;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn fecha;
        private DataGridViewTextBoxColumn descripcion;
        private DataGridViewTextBoxColumn costo;
        private Label lblNuevoCorte;
        private Label lblEliminarCorte;
        private CuoreUI.Controls.cuiButton btnGuardar;
        private CuoreUI.Controls.cuiTextBox txtPrecio;
        private CuoreUI.Controls.cuiButton btnGaleria;
        private CuoreUI.Controls.cuiTextBox txtDomicilio;
    }
}