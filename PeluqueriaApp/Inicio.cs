using PeluqueriaApp.Entidades;
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
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
            this.MaximizeBox = false;

            // Opcional: Establece el borde como fijo
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void AbrirFormulario<Formulario>() where Formulario : Form, new()
        {
            Form form = panelContenedor.Controls.OfType<Formulario>().FirstOrDefault();
            if (form == null)
            {
                form = new Formulario();
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;


                panelContenedor.Controls.Clear(); // Opcional si querés un solo formulario a la vez
                panelContenedor.Controls.Add(form);
                form.Show();
            }
            else
            {
                form.BringToFront();
            }
        }


        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario<ClientesGestion>();
        }

     
        private void btnInicio_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmEstadisticas>();
        }



        private void btnGaleria_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmGaleriaTodos>();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            AcercaDe info = new();
            info.ShowDialog();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            // Panel para contener los datos
            Panel panelCaratula = new Panel();
            panelCaratula.Height = 60;
            panelCaratula.Dock = DockStyle.Top;
            panelCaratula.BackColor = Color.FromArgb(245, 245, 245); // color claro y neutro

            // Label con nombre de la peluquería
            Label lblTitulo = new Label();
            lblTitulo.Text = "✂ LEMOTIFF - Sergio Coiffeur";
            lblTitulo.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblTitulo.ForeColor = Color.DarkMagenta;
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(15, 10);

            // Label con nombre y dirección
            Label lblSubtitulo = new Label();
            lblSubtitulo.Text = "Sergio De Filippo - Marcos Paz 1526";
            lblSubtitulo.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            lblSubtitulo.ForeColor = Color.DimGray;
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Location = new Point(18, 35);

            // Agregamos los controles
            panelCaratula.Controls.Add(lblTitulo);
            panelCaratula.Controls.Add(lblSubtitulo);

            // Finalmente, lo agregás al formulario (antes del buscador)
            this.Controls.Add(panelCaratula);
            this.Controls.SetChildIndex(panelCaratula, 0); // Para que quede arriba

        }

        private void btnFacturacion_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmFacturacion>();
        }
    }
}
