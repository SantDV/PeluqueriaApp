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
        private Label lblTitulo;
        private Label lblSub;

        public FrmSplash()
        {
            InicializarComponentes();
        }

        private void InicializarComponentes()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
            this.Size = new Size(400, 250);
            this.TopMost = true;

            // Contenedor para centrar elementos
            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 3,
                ColumnCount = 1,
                BackColor = Color.White,
            };
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 40F)); // Espaciado superior
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));     // Título
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 60F)); // Subtítulo y margen

            // Label principal
            lblTitulo = new Label
            {
                Text = "✂ LEMOTIFF",
                Font = new Font("Segoe UI", 26, FontStyle.Bold),
                ForeColor = Color.MediumVioletRed,
                AutoSize = true,
                Anchor = AnchorStyles.None,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Subtítulo
            lblSub = new Label
            {
                Text = "Cargando sistema...",
                Font = new Font("Segoe UI", 12, FontStyle.Italic),
                ForeColor = Color.Gray,
                AutoSize = true,
                Anchor = AnchorStyles.None,
                TextAlign = ContentAlignment.MiddleCenter
            };

            layout.Controls.Add(lblTitulo, 0, 1);
            layout.Controls.Add(lblSub, 0, 2);

            this.Controls.Add(layout);
        }

        public async Task MostrarYSaltarAsync()
        {
            this.Show();
            await Task.Delay(2500); // Espera 2.5 segundos
            this.Close();
        }
    }
}
