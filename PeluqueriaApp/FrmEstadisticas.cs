using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PeluqueriaApp.DbConn;

namespace PeluqueriaApp
{
    public partial class FrmEstadisticas : Form
    {
        public FrmEstadisticas()
        {
            InitializeComponent();
        }

        private void FrmEstadisticas_Load(object sender, EventArgs e)
        {
            var stats = new EstadisticasService();

            var estadisticas = new (string Titulo, string Valor)[]
            {
        ("Total de clientes", stats.ObtenerTotalClientes().ToString()),
        ("Total de cortes", stats.ObtenerTotalCortes().ToString()),
        ("Cortes este mes", stats.ObtenerCortesEsteMes().ToString()),
        ("Último corte", stats.ObtenerCorteMasReciente()),
        ("Nuevos clientes este mes", stats.ObtenerNuevosClientesEsteMes().ToString()),
        ("Cliente más frecuente", stats.ObtenerClienteMasFrecuente()),
        ("Promedio de cortes por cliente", stats.ObtenerPromedioCortesPorCliente().ToString("0.00")),
        ("Días desde último corte", stats.ObtenerDiasDesdeUltimoCorte() + " días"),
            };

            int y = 20;
            int espacio = 45;

            foreach (var est in estadisticas)
            {
                // Label de título
                Label lblTitulo = new Label();
                lblTitulo.Text = est.Titulo;
                lblTitulo.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                lblTitulo.Location = new Point(20, y);
                lblTitulo.AutoSize = true;
                this.Controls.Add(lblTitulo);

                // Label de valor
                Label lblValor = new Label();
                lblValor.Text = est.Valor;
                lblValor.Font = new Font("Segoe UI", 11, FontStyle.Regular);
                lblValor.ForeColor = Color.DarkSlateGray;
                lblValor.Location = new Point(250, y);
                lblValor.AutoSize = true;
                this.Controls.Add(lblValor);

                y += espacio;
            }
        }
    }
}
