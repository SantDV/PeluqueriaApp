namespace PeluqueriaApp
{
    partial class FrmGaleriaTodos
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
            btnExport = new CuoreUI.Controls.cuiButton();
            tableLayoutPanel1 = new TableLayoutPanel();
            flpGaleria = new FlowLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnExport
            // 
            btnExport.Anchor = AnchorStyles.Top;
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
            btnExport.Location = new Point(733, 15);
            btnExport.Margin = new Padding(3, 15, 3, 3);
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
            btnExport.Size = new Size(48, 48);
            btnExport.TabIndex = 0;
            btnExport.TextAlignment = StringAlignment.Center;
            btnExport.TextOffset = new Point(0, 0);
            btnExport.Click += btnExport_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 75F));
            tableLayoutPanel1.Controls.Add(btnExport, 1, 0);
            tableLayoutPanel1.Controls.Add(flpGaleria, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(795, 420);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // flpGaleria
            // 
            flpGaleria.AutoScroll = true;
            flpGaleria.Dock = DockStyle.Fill;
            flpGaleria.Location = new Point(3, 3);
            flpGaleria.Name = "flpGaleria";
            flpGaleria.Size = new Size(714, 414);
            flpGaleria.TabIndex = 1;
            // 
            // FrmGaleriaTodos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(795, 420);
            Controls.Add(tableLayoutPanel1);
            Name = "FrmGaleriaTodos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmGaleria";
            Load += FrmGaleria_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private CuoreUI.Controls.cuiButton btnExport;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flpGaleria;
    }
}