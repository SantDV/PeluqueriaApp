namespace PeluqueriaApp
{
    partial class Ajustes
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
            txtPesos = new CuoreUI.Controls.cuiTextBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtPesos
            // 
            txtPesos.BackgroundColor = Color.White;
            txtPesos.Content = "";
            txtPesos.FocusBackgroundColor = Color.White;
            txtPesos.FocusImageTint = Color.White;
            txtPesos.FocusOutlineColor = Color.FromArgb(255, 106, 0);
            txtPesos.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPesos.ForeColor = Color.Gray;
            txtPesos.Image = null;
            txtPesos.ImageExpand = new Point(0, 0);
            txtPesos.ImageOffset = new Point(0, 0);
            txtPesos.Location = new Point(46, 107);
            txtPesos.Margin = new Padding(4);
            txtPesos.Multiline = false;
            txtPesos.Name = "txtPesos";
            txtPesos.NormalImageTint = Color.White;
            txtPesos.OutlineColor = Color.White;
            txtPesos.Padding = new Padding(15, 7, 15, 0);
            txtPesos.PasswordChar = false;
            txtPesos.PlaceholderColor = Color.FromArgb(64, 64, 64);
            txtPesos.PlaceholderText = "Pesos";
            txtPesos.Rounding = new Padding(6);
            txtPesos.Size = new Size(201, 28);
            txtPesos.TabIndex = 3;
            txtPesos.TextOffset = new Size(0, 0);
            txtPesos.UnderlinedStyle = true;
            txtPesos.KeyPress += txtPesos_KeyPress;
            txtPesos.Leave += txtPesos_Leave;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.agm;
            pictureBox1.Location = new Point(-51, 92);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(654, 245);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // Ajustes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(526, 349);
            Controls.Add(pictureBox1);
            Controls.Add(txtPesos);
            Name = "Ajustes";
            Text = "Ajustes";
            Load += Ajustes_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private CuoreUI.Controls.cuiTextBox txtPesos;
        private PictureBox pictureBox1;
    }
}