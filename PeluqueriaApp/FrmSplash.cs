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
    public partial class FrmSplash : Form
    {
        public FrmSplash()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
            this.Size = new Size(400, 250);
            this.TopMost = true;

            // Label principal
            Label lblTitulo = new Label();
            lblTitulo.Text = "💈 LEMOTIFF";
            lblTitulo.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            lblTitulo.ForeColor = Color.DarkMagenta;
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point((this.Width - lblTitulo.Width) / 2, 60);
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // Subtítulo
            Label lblSub = new Label();
            lblSub.Text = "Cargando sistema...";
            lblSub.Font = new Font("Segoe UI", 12, FontStyle.Italic);
            lblSub.ForeColor = Color.Gray;
            lblSub.AutoSize = true;
            lblSub.Location = new Point((this.Width - lblSub.Width) / 2, 120);
            lblSub.TextAlign = ContentAlignment.MiddleCenter;

            // Agregamos manualmente centrados
            lblTitulo.Left = (this.ClientSize.Width - lblTitulo.Width) / 2;
            lblSub.Left = (this.ClientSize.Width - lblSub.Width) / 2;

            this.Controls.Add(lblTitulo);
            this.Controls.Add(lblSub);
        }

        public async Task MostrarYSaltarAsync()
        {
            this.Show();
            await Task.Delay(2500); // Espera 2.5 segundos
            this.Close();
        }
    }
}
