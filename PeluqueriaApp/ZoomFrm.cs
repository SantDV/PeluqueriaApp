using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeluqueriaApp
{
    public partial class ZoomFrm : Form
    {
        public ZoomFrm(Image img)
        {
            InitializeComponent();
            this.KeyPreview = true;
            pictureBox.Image = img;
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image == null) return;

            // Crear una copia para no modificar la imagen original
            Image img = pictureBox.Image;
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox.Image = img;
        }

        private void ZoomFrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
                e.Handled = true;
            }

        }
    }
}
