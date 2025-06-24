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
            flpGaleria.SuspendLayout();
            SuspendLayout();
            // 
            // flpGaleria
            // 
            flpGaleria.AutoScroll = true;
            flpGaleria.Controls.Add(btnExport);
            flpGaleria.Dock = DockStyle.Fill;
            flpGaleria.Location = new Point(0, 0);
            flpGaleria.Name = "flpGaleria";
            flpGaleria.Size = new Size(800, 450);
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
            btnExport.Content = "Your text here!";
            btnExport.DialogResult = DialogResult.None;
            btnExport.Font = new Font("Microsoft Sans Serif", 9.75F);
            btnExport.ForeColor = Color.Black;
            btnExport.HoverBackground = Color.White;
            btnExport.HoveredImageTint = Color.White;
            btnExport.HoverForeColor = Color.Black;
            btnExport.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnExport.Image = null;
            btnExport.ImageAutoCenter = true;
            btnExport.ImageExpand = new Point(0, 0);
            btnExport.ImageOffset = new Point(0, 0);
            btnExport.Location = new Point(3, 3);
            btnExport.Name = "btnExport";
            btnExport.NormalBackground = Color.White;
            btnExport.NormalForeColor = Color.Black;
            btnExport.NormalImageTint = Color.White;
            btnExport.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnExport.OutlineThickness = 1F;
            btnExport.PressedBackground = Color.WhiteSmoke;
            btnExport.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnExport.PressedImageTint = Color.White;
            btnExport.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnExport.Rounding = new Padding(8);
            btnExport.Size = new Size(153, 45);
            btnExport.TabIndex = 0;
            btnExport.TextAlignment = StringAlignment.Center;
            btnExport.TextOffset = new Point(0, 0);
            btnExport.Click += btnExport_Click;
            // 
            // FrmGaleria
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(flpGaleria);
            Name = "FrmGaleria";
            Text = "FrmGaleria";
            Load += FrmGaleria_Load;
            flpGaleria.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpGaleria;
        private CuoreUI.Controls.cuiButton btnExport;
    }
}