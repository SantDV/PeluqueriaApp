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
    public partial class FormImagenCompleta : Form
    {
        public FormImagenCompleta(Image imagen)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.Black;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.KeyDown += (s, e) => { if (e.KeyCode == Keys.Escape) this.Close(); }; // cerrar con ESC

            var pb = new PictureBox
            {
                Dock = DockStyle.Fill,
                Image = imagen,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Black
            };

            this.Controls.Add(pb);
            this.TopMost = true; // Opcional: siempre al frente
        }
    }
}
