using PeluqueriaApp.Entidades;
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
    public partial class DetalleCobro : Form
    {
        private readonly Corte corte = new Corte();
        DbConn DbConn = new DbConn();
        public DetalleCobro(Corte corte)
        {

            this.corte = corte;
            InitializeComponent();

            this.MaximizeBox = false;

            // Opcional: Establece el borde como fijo
            this.FormBorderStyle = FormBorderStyle.FixedSingle;


            lblIdCobro.Text = corte.Id.ToString();
            lblIdCliente.Text = corte.ClienteId.ToString();
            dtpFecha.Value = corte.FechaCreacion;
            txtDescripcion.Text = corte.Descripcion;
            txtNombre.Content = corte.NombreCliente;
            txtMonto.Content = corte.Cobro;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            bool resultado = DbConn.ModificarCorte(new Corte { Id = Convert.ToInt32(lblIdCobro.Text), Descripcion = txtDescripcion.Text, Cobro = string.IsNullOrWhiteSpace(txtMonto.Content) ? "$ 0,00" : txtMonto.Content, FechaCreacion = dtpFecha.Value });

            if (resultado)
            {
                MessageBox.Show("Cambios guardados correctamente");
                txtMonto.Enabled = false;
                txtDescripcion.ReadOnly = true;
                btnGuardar.Enabled = false;
                dtpFecha.Enabled = false;

            }

        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrWhiteSpace(txtMonto.Content))
            {
                FormatearAPesosArgentinos();
                e.Handled = true;
            }
        }

        private void txtMonto_Leave(object sender, EventArgs e)
        {
            FormatearAPesosArgentinos();
        }

        private void FormatearAPesosArgentinos()
        {
            // Cultura argentina
            var cultura = CultureInfo.GetCultureInfo("es-AR");

            // Limpiar símbolo de moneda y espacios
            string texto = txtMonto.Content
                .Replace("$", "")
                .Replace("ARS", "")
                .Trim();

            if (decimal.TryParse(texto, NumberStyles.Any, cultura, out decimal monto))
            {
                txtMonto.Content = monto.ToString("C2", cultura); // "$ 1.000,00"
            }
            else
            {
                txtMonto.Content = 0m.ToString("C2", cultura); // "$ 0,00"
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            txtMonto.Enabled = true;
            txtDescripcion.ReadOnly = false;
            btnGuardar.Enabled = true;
            dtpFecha.Enabled = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {


            // Mostrar mensaje de confirmación antes de eliminar
            DialogResult confirmacion = MessageBox.Show(
                "¿Está seguro que desea eliminar este cobro?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2); // Por defecto selecciona "No"

            // Solo proceder si el usuario confirma
            if (confirmacion == DialogResult.Yes)
            {
                bool resultado = DbConn.EliminarCorte(Convert.ToInt32(lblIdCobro.Text));

                if (resultado)
                {
                    MessageBox.Show("Se eliminó el cobro correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Actualizar el formulario principal si está abierto
                    FrmFacturacion form = Application.OpenForms.OfType<FrmFacturacion>().FirstOrDefault();
                    if (form != null)
                    {
                        form.BuscarPorFecha();
                    }

                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el cobro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
        }
    }
}
