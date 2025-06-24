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
        }

        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            // Busca si ya hay una instancia del formulario abierto
            MiForm form = this.MdiChildren.OfType<MiForm>().FirstOrDefault();

            // Si no hay una instancia abierta, crea una nueva
            if (form == null)
            {
                form = new MiForm();
                //form.TopLevel = false;
                //form.FormBorderStyle = FormBorderStyle.None;
                form.MdiParent = this;  // Establece el formulario principal como el padre MDI
                form.Dock = DockStyle.Fill;
                form.FormClosed += (s, args) => form = null;  // Maneja el evento de cierre del formulario para liberar la referencia
                form.Show();
            }

            // Trae el formulario al frente
            form.BringToFront();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirClientes();
        }

        private void AbrirClientes()
        {
            AbrirFormulario<ClientesGestion>();


            //ClientesGestion clientes = Application.OpenForms.OfType<ClientesGestion>().FirstOrDefault();

            //clientes.empleado = this.empleado;

            //if (this.usuario.IdRol == 1)
            //{
            //    clientes.btnEliminar.Enabled = false;
            //    clientes.btnEliminar.BackColor = Color.LightCoral;

            //    clientes.Refresh();
            //}
            //else
            //{
            //    clientes.btnEliminar.Enabled = true;

            //    clientes.Refresh();
            //}
        }



        private void btnInicio_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FrmEstadisticas>();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            flpanel.Width = flpanel.Width == 122 ? 42 : 122;
            btnMenu.Margin = new Padding(btnMenu.Margin.Left == 95 ? 3 : 95, btnMenu.Margin.Top, btnMenu.Margin.Right, btnMenu.Margin.Bottom);
            if (btnMenu.Margin.Left == 95)
            {
                btnMenu.Image = Properties.Resources.arrow_menu_close; // por ejemplo: un ícono de flecha izquierda
            }
            else
            {
                btnMenu.Image = Properties.Resources.arrow_menu_open; // por ejemplo: ícono de flecha derecha
            }

            btnClientes.Width = btnClientes.Width == 115 ? 38 : 115;
            btnInicio.Width = btnInicio.Width == 115 ? 38 : 115;
            btnGaleria.Width = btnInicio.Width == 115 ? 38 : 115;

            // Solución: Crear una nueva instancia de Padding para modificar la propiedad Rounding
            var rounding = btnInicio.Rounding;
            rounding = new Padding(8, 8, 8, 8);
            btnInicio.Rounding = rounding;
            btnInicio.Invalidate();

            var rounding1 = btnClientes.Rounding;
            rounding1 = new Padding(8, 8, 8, 8);
            btnClientes.Rounding = rounding1;
            btnClientes.Invalidate();

            var rounding2 = btnGaleria.Rounding;
            rounding1 = new Padding(8, 8, 8, 8);
            btnGaleria.Rounding = rounding2;
            btnGaleria.Invalidate();
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
            lblTitulo.Text = "💈 LEMOTIFF - Sergio Coiffeur";
            lblTitulo.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblTitulo.ForeColor = Color.DarkMagenta;
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(15, 10);

            // Label con nombre y dirección
            Label lblSubtitulo = new Label();
            lblSubtitulo.Text = "Sergio De Filippo - Marcos Paz 1526";
            lblSubtitulo.Font = new Font("Segoe UI", 10, FontStyle.Regular);
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
    }
}
