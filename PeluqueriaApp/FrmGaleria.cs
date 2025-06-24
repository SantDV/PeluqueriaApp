using ClosedXML.Excel;
using PeluqueriaApp.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeluqueriaApp
{
    public partial class FrmGaleria : Form
    {

        private Cliente cliente = new();
        public FrmGaleria(Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
        }

        private void FrmGaleria_Load(object sender, EventArgs e)
        {
            CargarFotosDeCortes();
        }


        private void CargarFotosDeCortes()
        {
            string conexion = "Data Source=peluqueriaDB.db; Version=3;";
            using (var conn = new SQLiteConnection(conexion))
            {
                conn.Open();
                string sql = "SELECT Foto, FechaCreacion FROM Cortes WHERE Foto IS NOT NULL ORDER BY FechaCreacion DESC";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    //cmd.Parameters.AddWithValue("@ClienteId", cliente.Id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            byte[] bytes = (byte[])reader["Foto"];
                            DateTime fecha = DateTime.Parse(reader["FechaCreacion"].ToString());

                            if (bytes.Length > 0)
                            {
                                using (MemoryStream ms = new MemoryStream(bytes))
                                {
                                    Image img = Image.FromStream(ms);

                                    // Contenedor Panel
                                    Panel contenedor = new Panel();
                                    contenedor.Width = 110;
                                    contenedor.Height = 130;
                                    contenedor.Margin = new Padding(10);

                                    // PictureBox
                                    PictureBox pb = new PictureBox();
                                    pb.Image = img;
                                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                                    pb.Width = 100;
                                    pb.Height = 100;
                                    pb.Top = 0;
                                    pb.Left = 5;
                                    pb.Cursor = Cursors.Hand;
                                    pb.Tag = fecha.ToShortDateString();

                                    pb.Click += (s, e) =>
                                    {
                                        var zoomForm = new Form();
                                        zoomForm.StartPosition = FormStartPosition.CenterParent;
                                        zoomForm.Size = new Size(500, 500);
                                        var zoomPb = new PictureBox
                                        {
                                            Dock = DockStyle.Fill,
                                            Image = ((PictureBox)s).Image,
                                            SizeMode = PictureBoxSizeMode.Zoom
                                        };
                                        zoomForm.Controls.Add(zoomPb);
                                        zoomForm.ShowDialog();
                                    };

                                    // Label de la fecha
                                    Label lblFecha = new Label();
                                    lblFecha.Text = fecha.ToString("dd/MM/yyyy");
                                    lblFecha.TextAlign = ContentAlignment.MiddleCenter;
                                    lblFecha.Dock = DockStyle.Bottom;
                                    lblFecha.Height = 30;

                                    contenedor.Controls.Add(pb);
                                    contenedor.Controls.Add(lblFecha);
                                    flpGaleria.Controls.Add(contenedor);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (cliente.Id == 0)
            {
                MessageBox.Show("Seleccioná un cliente primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivo Excel (*.xlsx)|*.xlsx";
                sfd.FileName = $"c_{this.cliente.Nombre}" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                string conexion = "Data Source=peluqueriaDB.db; Version=3;";
                string carpetaImagenes = Path.Combine(Path.GetDirectoryName(sfd.FileName), "imagenes");
                Directory.CreateDirectory(carpetaImagenes);

                using (var conn = new SQLiteConnection(conexion))
                {
                    conn.Open();
                    string sql = @"SELECT c.FechaCreacion, c.Descripcion, c.Foto, 
                                  cl.Nombre || ' ' || cl.Apellido AS Cliente 
                           FROM Cortes c 
                           JOIN Clientes cl ON cl.Id = c.ClienteId 
                           WHERE c.ClienteId = @ClienteId AND c.Foto IS NOT NULL 
                           ORDER BY c.FechaCreacion DESC";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ClienteId", cliente.Id);

                        using (var reader = cmd.ExecuteReader())
                        {
                            var wb = new XLWorkbook();
                            var ws = wb.Worksheets.Add("Cortes");

                            // Encabezados
                            ws.Cell(1, 1).Value = "Cliente";
                            ws.Cell(1, 2).Value = "Fecha";
                            ws.Cell(1, 3).Value = "Observación";
                            ws.Cell(1, 4).Value = "Foto";

                            ws.Row(1).Style.Font.Bold = true;
                            ws.Columns().AdjustToContents();

                            int fila = 2;

                            while (reader.Read())
                            {
                                string cliente = reader["Cliente"].ToString();
                                DateTime fecha = Convert.ToDateTime(reader["FechaCreacion"]);
                                string obs = reader["Descripcion"].ToString();
                                byte[] fotoBytes = (byte[])reader["Foto"];

                                string nombreImg = $"corte_{fecha:yyyyMMdd}_{fila}.jpg";
                                string rutaFinalImagen = Path.Combine(carpetaImagenes, nombreImg);

                                // Guardar imagen completa en carpeta
                                using (MemoryStream ms = new MemoryStream(fotoBytes))
                                using (Image img = Image.FromStream(ms))
                                {
                                    img.Save(rutaFinalImagen, ImageFormat.Jpeg);
                                }

                                // Insertar datos
                                ws.Cell(fila, 1).Value = cliente;
                                ws.Cell(fila, 2).Value = fecha.ToString("dd/MM/yyyy");
                                ws.Cell(fila, 3).Value = obs;

                                // Insertar imagen miniatura con hipervínculo
                                ws.Row(fila).Height = 80;
                                ws.Column(4).Width = 15;

                                var imgExcel = ws.AddPicture(rutaFinalImagen)
                                    .MoveTo(ws.Cell(fila, 4), new Point(5, 5))
                                    .WithSize(80, 80); // miniatura

                                ws.Cell(fila, 4).SetHyperlink(new XLHyperlink("imagenes/" + nombreImg));


                                fila++;
                            }

                            // Guardar Excel
                            wb.SaveAs(sfd.FileName);
                        }
                    }
                }

                MessageBox.Show("Exportación completa. El archivo y las imágenes se guardaron correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
