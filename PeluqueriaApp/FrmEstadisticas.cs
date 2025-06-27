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

                // Plan en pseudocódigo:
                // 1. Revisar cada llamada a stats.ObtenerXxx() para detectar posibles valores null o DBNull.
                // 2. Para cada valor, comprobar si es null o DBNull antes de llamar a ToString() o concatenar.
                // 3. Si es null o DBNull, mostrar un valor por defecto como "N/A".
                // 4. Modificar la creación del array 'estadisticas' para aplicar esta lógica.

                var estadisticas = new (string Titulo, string Valor)[]
                {
                        ("Total de clientes", stats.ObtenerTotalClientes() == null ? "N/A" : stats.ObtenerTotalClientes().ToString()),
                        ("Total de cortes", stats.ObtenerTotalCortes() == null ? "N/A" : stats.ObtenerTotalCortes().ToString()),
                        ("Cortes este mes", stats.ObtenerCortesEsteMes() == null ? "N/A" : stats.ObtenerCortesEsteMes().ToString()),
                        ("Último corte", stats.ObtenerCorteMasReciente() == null ? "N/A" : stats.ObtenerCorteMasReciente().ToString()),
                        ("Nuevos clientes este mes", stats.ObtenerNuevosClientesEsteMes() == null ? "N/A" : stats.ObtenerNuevosClientesEsteMes().ToString()),
                        ("Cliente más frecuente", stats.ObtenerClienteMasFrecuente() == null ? "N/A" : stats.ObtenerClienteMasFrecuente().ToString()),
                        ("Promedio de cortes por cliente", stats.ObtenerPromedioCortesPorCliente() == null ? "N/A" : ((double)stats.ObtenerPromedioCortesPorCliente()).ToString("0.00")),
                        ("Días desde último corte", stats.ObtenerDiasDesdeUltimoCorte() == null ? "N/A" : stats.ObtenerDiasDesdeUltimoCorte() + " días"),
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
                tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F)); // Columna título
                tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F)); // Columna valor

                // Añadir filas dinámicamente
                for (int i = 0; i < estadisticas.Length; i++)
                {
                    // Label título
                    Label lblTitulo = new Label
                    {
                        Text = estadisticas[i].Titulo,
                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                        Anchor = AnchorStyles.Left,
                        AutoSize = true
                    };

                    // Label valor
                    Label lblValor = new Label
                    {
                        Text = estadisticas[i].Valor,
                        Font = new Font("Segoe UI", 11, FontStyle.Regular),
                        ForeColor = Color.DarkSlateGray,
                        Anchor = AnchorStyles.Left,
                        AutoSize = true
                    };

                    tablePanel.Controls.Add(lblTitulo, 0, i);
                    tablePanel.Controls.Add(lblValor, 1, i);
                    tablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F)); // Altura de fila
                }

                this.Controls.Add(tablePanel);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar estadísticas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //private void FrmEstadisticas_Load(object sender, EventArgs e)
        //{
        //    var stats = new EstadisticasService();

        //    var estadisticas = new (string Titulo, string Valor)[]
        //    {
        //("Total de clientes", stats.ObtenerTotalClientes().ToString()),
        //("Total de cortes", stats.ObtenerTotalCortes().ToString()),
        //("Cortes este mes", stats.ObtenerCortesEsteMes().ToString()),
        //("Último corte", stats.ObtenerCorteMasReciente()),
        //("Nuevos clientes este mes", stats.ObtenerNuevosClientesEsteMes().ToString()),
        //("Cliente más frecuente", stats.ObtenerClienteMasFrecuente()),
        //("Promedio de cortes por cliente", stats.ObtenerPromedioCortesPorCliente().ToString("0.00")),
        //("Días desde último corte", stats.ObtenerDiasDesdeUltimoCorte() + " días"),
        //    };

        //    int y = 20;
        //    int espacio = 45;

        //    foreach (var est in estadisticas)
        //    {
        //        // Label de título
        //        Label lblTitulo = new Label();
        //        lblTitulo.Text = est.Titulo;
        //        lblTitulo.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        //        lblTitulo.Location = new Point(20, y);
        //        lblTitulo.AutoSize = true;
        //        this.Controls.Add(lblTitulo);

        //        // Label de valor
        //        Label lblValor = new Label();
        //        lblValor.Text = est.Valor;
        //        lblValor.Font = new Font("Segoe UI", 11, FontStyle.Regular);
        //        lblValor.ForeColor = Color.DarkSlateGray;
        //        lblValor.Location = new Point(250, y);
        //        lblValor.AutoSize = true;
        //        this.Controls.Add(lblValor);

        //        y += espacio;
        //    }
        //}
    }
}
