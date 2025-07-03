namespace PeluqueriaApp
{
    partial class FrmGaleria
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
            flpGaleria = new FlowLayoutPanel();
            btnExport = new CuoreUI.Controls.cuiButton();
            SuspendLayout();
            // 
            // flpGaleria
            // 
            flpGaleria.AutoScroll = true;
            flpGaleria.Dock = DockStyle.Left;
            flpGaleria.Location = new Point(0, 0);
            flpGaleria.Name = "flpGaleria";
            flpGaleria.Size = new Size(715, 420);
            flpGaleria.TabIndex = 0;
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
            btnExport.Location = new Point(738, 12);
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
            btnExport.Size = new Size(31, 34);
            btnExport.TabIndex = 1;
            btnExport.TextAlignment = StringAlignment.Center;
            btnExport.TextOffset = new Point(0, 0);
            btnExport.Click += btnExport_Click_1;
            // 
            // FrmGaleria
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(795, 420);
            Controls.Add(btnExport);
            Controls.Add(flpGaleria);
            Name = "FrmGaleria";
            Text = "Galeria";
            Load += FrmGaleria_Load;
            KeyPress += FrmGaleria_KeyPress;
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpGaleria;
        private CuoreUI.Controls.cuiButton btnExport;
        
    }
}