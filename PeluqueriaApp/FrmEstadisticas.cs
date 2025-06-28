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
            try
            {
                var stats = new EstadisticasService();

                // Convertidores seguros para null o DBNull
                string SafeToString(object val) =>
                    val == null || val == DBNull.Value ? "N/A" : val.ToString();

                string SafeToDecimal(object val) =>
                    val == null || val == DBNull.Value ? "N/A" : ((double)val).ToString("0.00");

                string SafeToDias(object val) =>
                    val == null || val == DBNull.Value ? "N/A" : val + " días";

                var estadisticas = new (string Titulo, string Valor)[]
                {
            ("Total de clientes", SafeToString(stats.ObtenerTotalClientes())),
            ("Total de cortes", SafeToString(stats.ObtenerTotalCortes())),
            ("Cortes este mes", SafeToString(stats.ObtenerCortesEsteMes())),
            ("Último corte", SafeToString(stats.ObtenerCorteMasReciente())),
            ("Nuevos clientes este mes", SafeToString(stats.ObtenerNuevosClientesEsteMes())),
            ("Cliente más frecuente", SafeToString(stats.ObtenerClienteMasFrecuente())),
            ("Promedio de cortes por cliente", SafeToDecimal(stats.ObtenerPromedioCortesPorCliente())),
            ("Días desde último corte", SafeToDias(stats.ObtenerDiasDesdeUltimoCorte()))
                };

                // Configurar TableLayoutPanel
                TableLayoutPanel tablePanel = new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    AutoScroll = true,
                    ColumnCount = 2,
                    RowCount = estadisticas.Length,
                    Padding = new Padding(10)
                };
                tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F)); // Títulos
                tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F)); // Valores

                for (int i = 0; i < estadisticas.Length; i++)
                {
                    Label lblTitulo = new Label
                    {
                        Text = estadisticas[i].Titulo,
                        Font = new Font("Segoe UI", 12, FontStyle.Bold),
                        Anchor = AnchorStyles.Left,
                        AutoSize = true
                    };

                    Label lblValor = new Label
                    {
                        Text = estadisticas[i].Valor,
                        Font = new Font("Segoe UI", 12, FontStyle.Regular),
                        ForeColor = Color.DarkSlateGray,
                        Anchor = AnchorStyles.Left,
                        AutoSize = true
                    };

                    tablePanel.Controls.Add(lblTitulo, 0, i);
                    tablePanel.Controls.Add(lblValor, 1, i);
                    tablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
                }

                this.Controls.Add(tablePanel);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar estadísticas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
