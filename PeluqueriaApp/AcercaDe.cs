using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeluqueriaApp
{
    public partial class AcercaDe : Form
    {
        public AcercaDe()
        {
            InitializeComponent();
            this.Text = "Acerca de";
            this.Size = new Size(450, 340);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.White;

            // Título
            Label lblTitulo = new Label();
            lblTitulo.Text = "✂ LEMOTIFF - Sergio Coiffeur";
            lblTitulo.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblTitulo.ForeColor = Color.DarkMagenta;
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(20, 20);

            // Datos de peluquería
            Label lblPelu = new Label();
            lblPelu.Text = "Propietario: Sergio De Filippo\nDirección: Marcos Paz 1526";
            lblPelu.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblPelu.ForeColor = Color.DimGray;
            lblPelu.AutoSize = true;
            lblPelu.Location = new Point(25, 60);

            // Línea divisoria
            Label linea = new Label();
            linea.BorderStyle = BorderStyle.Fixed3D;
            linea.Width = 380;
            linea.Height = 2;
            linea.Location = new Point(20, 110);

            // Datos del desarrollador
            Label lblDev = new Label();
            lblDev.Text = "Sistema desarrollado por:\nSantiago Viva\nEmail: santiagoviva90@gmail.com\nWhatsApp: +54 9 381 539 8223\nAño: 2025";
            lblDev.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblDev.ForeColor = Color.Black;
            lblDev.AutoSize = true;
            lblDev.Location = new Point(25, 130);

            // Imagen alineada a la derecha, misma altura que lblDev
            PictureBox pbLogo = new PictureBox();
            pbLogo.Image = Properties.Resources.agm;
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.Size = new Size(80, 80);
            pbLogo.Location = new Point(this.ClientSize.Width - pbLogo.Width - 30, lblDev.Top + 10);
            pbLogo.Cursor = Cursors.Hand;

            ToolTip tooltip = new ToolTip();
            tooltip.SetToolTip(pbLogo, "Escribime por WhatsApp");

            pbLogo.Click += (s, e) =>
            {
                string url = "https://wa.me/5493813273910";

                try
                {
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                    }
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    {
                        Process.Start("xdg-open", url);
                    }
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                    {
                        Process.Start("open", url);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo abrir el navegador.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            // Botón cerrar
            Button btnCerrar = new Button();
            btnCerrar.Text = "Cerrar";
            btnCerrar.Width = 80;
            btnCerrar.Height = 30;
            btnCerrar.Location = new Point(this.ClientSize.Width - 100, this.ClientSize.Height - 50);
            btnCerrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCerrar.Click += (s, e) => this.Close();

            // Versión
            Label lblVersion = new Label();
            lblVersion.Text = $"Versión: {AppInfo.Version}";
            lblVersion.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            lblVersion.ForeColor = Color.Gray;
            lblVersion.AutoSize = true;
            lblVersion.Location = new Point(25, this.ClientSize.Height - 30);
            lblVersion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

            // Agregar controles
            this.Controls.Add(lblTitulo);
            this.Controls.Add(lblPelu);
            this.Controls.Add(linea);
            this.Controls.Add(lblDev);
            this.Controls.Add(pbLogo);
            this.Controls.Add(btnCerrar);
            this.Controls.Add(lblVersion);
        }



        private void Info_Load(object sender, EventArgs e)
        {
            
        }
    }
}
