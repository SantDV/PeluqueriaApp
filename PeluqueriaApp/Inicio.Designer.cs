namespace PeluqueriaApp
{
    partial class Inicio
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
            flpanel = new FlowLayoutPanel();
            btnInicio = new CuoreUI.Controls.cuiButton();
            btnClientes = new CuoreUI.Controls.cuiButton();
            btnGaleria = new CuoreUI.Controls.cuiButton();
            btnFacturacion = new CuoreUI.Controls.cuiButton();
            btnInfo = new CuoreUI.Controls.cuiButton();
            panelContenedor = new Panel();
            flpanel.SuspendLayout();
            SuspendLayout();
            // 
            // flpanel
            // 
            flpanel.Controls.Add(btnInicio);
            flpanel.Controls.Add(btnClientes);
            flpanel.Controls.Add(btnGaleria);
            flpanel.Controls.Add(btnFacturacion);
            flpanel.Controls.Add(btnInfo);
            flpanel.Dock = DockStyle.Left;
            flpanel.Location = new Point(0, 0);
            flpanel.Margin = new Padding(0, 3, 3, 3);
            flpanel.Name = "flpanel";
            flpanel.Size = new Size(122, 525);
            flpanel.TabIndex = 0;
            // 
            // btnInicio
            // 
            btnInicio.CheckButton = false;
            btnInicio.Checked = false;
            btnInicio.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnInicio.CheckedForeColor = Color.White;
            btnInicio.CheckedImageTint = Color.White;
            btnInicio.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnInicio.Content = "Inicio";
            btnInicio.DialogResult = DialogResult.None;
            btnInicio.Font = new Font("Segoe UI", 12F);
            btnInicio.ForeColor = Color.Black;
            btnInicio.HoverBackground = Color.White;
            btnInicio.HoveredImageTint = Color.White;
            btnInicio.HoverForeColor = Color.Black;
            btnInicio.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnInicio.Image = Properties.Resources.home;
            btnInicio.ImageAutoCenter = false;
            btnInicio.ImageExpand = new Point(15, 15);
            btnInicio.ImageOffset = new Point(12, 0);
            btnInicio.Location = new Point(3, 3);
            btnInicio.Name = "btnInicio";
            btnInicio.NormalBackground = Color.White;
            btnInicio.NormalForeColor = Color.Black;
            btnInicio.NormalImageTint = Color.White;
            btnInicio.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnInicio.OutlineThickness = 1F;
            btnInicio.PressedBackground = Color.WhiteSmoke;
            btnInicio.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnInicio.PressedImageTint = Color.White;
            btnInicio.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnInicio.Rounding = new Padding(8);
            btnInicio.Size = new Size(115, 45);
            btnInicio.TabIndex = 1;
            btnInicio.TextAlignment = StringAlignment.Near;
            btnInicio.TextOffset = new Point(-7, 0);
            btnInicio.Click += btnInicio_Click;
            // 
            // btnClientes
            // 
            btnClientes.CheckButton = false;
            btnClientes.Checked = false;
            btnClientes.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnClientes.CheckedForeColor = Color.White;
            btnClientes.CheckedImageTint = Color.White;
            btnClientes.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnClientes.Content = "Clientes";
            btnClientes.DialogResult = DialogResult.None;
            btnClientes.Font = new Font("Segoe UI", 12F);
            btnClientes.ForeColor = Color.Black;
            btnClientes.HoverBackground = Color.White;
            btnClientes.HoveredImageTint = Color.White;
            btnClientes.HoverForeColor = Color.Black;
            btnClientes.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnClientes.Image = Properties.Resources.person;
            btnClientes.ImageAutoCenter = false;
            btnClientes.ImageExpand = new Point(15, 15);
            btnClientes.ImageOffset = new Point(12, 0);
            btnClientes.Location = new Point(3, 54);
            btnClientes.Name = "btnClientes";
            btnClientes.NormalBackground = Color.White;
            btnClientes.NormalForeColor = Color.Black;
            btnClientes.NormalImageTint = Color.White;
            btnClientes.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnClientes.OutlineThickness = 1F;
            btnClientes.PressedBackground = Color.WhiteSmoke;
            btnClientes.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnClientes.PressedImageTint = Color.White;
            btnClientes.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnClientes.Rounding = new Padding(8);
            btnClientes.Size = new Size(115, 45);
            btnClientes.TabIndex = 0;
            btnClientes.TextAlignment = StringAlignment.Near;
            btnClientes.TextOffset = new Point(-7, 0);
            btnClientes.Click += btnClientes_Click;
            // 
            // btnGaleria
            // 
            btnGaleria.CheckButton = false;
            btnGaleria.Checked = false;
            btnGaleria.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnGaleria.CheckedForeColor = Color.White;
            btnGaleria.CheckedImageTint = Color.White;
            btnGaleria.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnGaleria.Content = "Galería";
            btnGaleria.DialogResult = DialogResult.None;
            btnGaleria.Font = new Font("Segoe UI", 12F);
            btnGaleria.ForeColor = Color.Black;
            btnGaleria.HoverBackground = Color.White;
            btnGaleria.HoveredImageTint = Color.White;
            btnGaleria.HoverForeColor = Color.Black;
            btnGaleria.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnGaleria.Image = Properties.Resources.gallery3;
            btnGaleria.ImageAutoCenter = false;
            btnGaleria.ImageExpand = new Point(15, 15);
            btnGaleria.ImageOffset = new Point(12, 0);
            btnGaleria.Location = new Point(3, 105);
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
            btnGaleria.Rounding = new Padding(8);
            btnGaleria.Size = new Size(115, 45);
            btnGaleria.TabIndex = 3;
            btnGaleria.TextAlignment = StringAlignment.Near;
            btnGaleria.TextOffset = new Point(-7, 0);
            btnGaleria.Click += btnGaleria_Click;
            // 
            // btnFacturacion
            // 
            btnFacturacion.CheckButton = false;
            btnFacturacion.Checked = false;
            btnFacturacion.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnFacturacion.CheckedForeColor = Color.White;
            btnFacturacion.CheckedImageTint = Color.White;
            btnFacturacion.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnFacturacion.Content = "Cobros";
            btnFacturacion.DialogResult = DialogResult.None;
            btnFacturacion.Font = new Font("Segoe UI", 12F);
            btnFacturacion.ForeColor = Color.Black;
            btnFacturacion.HoverBackground = Color.White;
            btnFacturacion.HoveredImageTint = Color.White;
            btnFacturacion.HoverForeColor = Color.Black;
            btnFacturacion.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnFacturacion.Image = Properties.Resources.wallet;
            btnFacturacion.ImageAutoCenter = false;
            btnFacturacion.ImageExpand = new Point(15, 15);
            btnFacturacion.ImageOffset = new Point(12, 0);
            btnFacturacion.Location = new Point(3, 156);
            btnFacturacion.Name = "btnFacturacion";
            btnFacturacion.NormalBackground = Color.White;
            btnFacturacion.NormalForeColor = Color.Black;
            btnFacturacion.NormalImageTint = Color.White;
            btnFacturacion.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnFacturacion.OutlineThickness = 1F;
            btnFacturacion.PressedBackground = Color.WhiteSmoke;
            btnFacturacion.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnFacturacion.PressedImageTint = Color.White;
            btnFacturacion.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnFacturacion.Rounding = new Padding(8);
            btnFacturacion.Size = new Size(115, 45);
            btnFacturacion.TabIndex = 5;
            btnFacturacion.TextAlignment = StringAlignment.Near;
            btnFacturacion.TextOffset = new Point(-7, 0);
            btnFacturacion.Click += btnFacturacion_Click;
            // 
            // btnInfo
            // 
            btnInfo.CheckButton = false;
            btnInfo.Checked = false;
            btnInfo.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnInfo.CheckedForeColor = Color.White;
            btnInfo.CheckedImageTint = Color.White;
            btnInfo.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnInfo.Content = "";
            btnInfo.DialogResult = DialogResult.None;
            btnInfo.Font = new Font("Microsoft Sans Serif", 9.75F);
            btnInfo.ForeColor = Color.Black;
            btnInfo.HoverBackground = Color.White;
            btnInfo.HoveredImageTint = Color.White;
            btnInfo.HoverForeColor = Color.Black;
            btnInfo.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnInfo.Image = Properties.Resources.info;
            btnInfo.ImageAutoCenter = true;
            btnInfo.ImageExpand = new Point(0, 0);
            btnInfo.ImageOffset = new Point(0, 0);
            btnInfo.Location = new Point(3, 494);
            btnInfo.Margin = new Padding(3, 290, 3, 3);
            btnInfo.Name = "btnInfo";
            btnInfo.NormalBackground = Color.White;
            btnInfo.NormalForeColor = Color.Black;
            btnInfo.NormalImageTint = Color.White;
            btnInfo.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnInfo.OutlineThickness = 1F;
            btnInfo.PressedBackground = Color.WhiteSmoke;
            btnInfo.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnInfo.PressedImageTint = Color.White;
            btnInfo.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnInfo.Rounding = new Padding(8);
            btnInfo.Size = new Size(22, 25);
            btnInfo.TabIndex = 4;
            btnInfo.TextAlignment = StringAlignment.Center;
            btnInfo.TextOffset = new Point(0, 0);
            btnInfo.Click += btnInfo_Click;
            // 
            // panelContenedor
            // 
            panelContenedor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelContenedor.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelContenedor.BackColor = SystemColors.ActiveCaption;
            panelContenedor.Location = new Point(124, 54);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(811, 459);
            panelContenedor.TabIndex = 1;
            // 
            // Inicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(935, 525);
            Controls.Add(panelContenedor);
            Controls.Add(flpanel);
            Name = "Inicio";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inicio";
            Load += Inicio_Load;
            flpanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpanel;
        private CuoreUI.Controls.cuiButton btnClientes;
        private CuoreUI.Controls.cuiButton btnInicio;
        private CuoreUI.Controls.cuiButton btnGaleria;
        private CuoreUI.Controls.cuiButton btnInfo;
        private Panel panelContenedor;
        private CuoreUI.Controls.cuiButton btnFacturacion;
    }
}