
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeluqueriaApp
{
    public partial class Ajustes : Form
    {

        public Ajustes()
        {
            InitializeComponent();

        }


        private void Ajustes_Load(object sender, EventArgs e)
        {

        }

        private void txtPesos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrEmpty(txtPesos.Content))
            {
                FormatearAPesosArgentinos();
                e.Handled = true; // Evitar el "beep" al presionar Enter
            }
        }

        private void FormatearAPesosArgentinos()
        {
            // Obtener el texto sin símbolos no numéricos
            string texto = txtPesos.Content.Replace("$", "").Replace(".", "").Trim();

            if (decimal.TryParse(texto, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal monto))
            {
                // Formatear como pesos argentinos: $ 1.234,56
                txtPesos.Content = monto.ToString("C2", CultureInfo.GetCultureInfo("es-AR"));
            }
            else
            {
                // Si no es un número válido, mostrar $ 0,00
                txtPesos.Content = 0m.ToString("C2", CultureInfo.GetCultureInfo("es-AR"));
            }
        }

        private void txtPesos_Leave(object sender, EventArgs e)
        {
            FormatearAPesosArgentinos();
        }
    }
}
