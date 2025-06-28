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
    public partial class FrmGaleriaTodos : Form
    {

        
        public FrmGaleriaTodos()
        {
            InitializeComponent();
            
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

                string sql = @"
            SELECT f.Imagen, c.FechaCreacion, cl.Id AS ClienteId, cl.Nombre AS Cliente
            FROM FotosCorte f
            JOIN Cortes c ON c.Id = f.CorteId
            JOIN Clientes cl ON cl.Id = c.ClienteId
            ORDER BY c.FechaCreacion DESC";

                using (var cmd = new SQLiteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        byte[] bytes = (byte[])reader["Imagen"];
                        DateTime fecha = DateTime.Parse(reader["FechaCreacion"].ToString());
                        string nombreCliente = reader["Cliente"].ToString();
                        int clienteId = Convert.ToInt32(reader["ClienteId"]);

                        if (bytes.Length > 0)
                        {
                            using (MemoryStream ms = new MemoryStream(bytes))
                            {
                                Image img = Image.FromStream(ms);

                                // Panel contenedor
                                Panel contenedor = new Panel();
                                contenedor.Width = 120;
                                contenedor.Height = 170;
                                contenedor.Margin = new Padding(10);

                                // PictureBox
                                PictureBox pb = new PictureBox();
                                pb.Image = img;
                                pb.SizeMode = PictureBoxSizeMode.Zoom;
                                pb.Width = 100;
                                pb.Height = 100;
                                pb.Top = 0;
                                pb.Left = 10;
                                pb.Cursor = Cursors.Hand;

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

                                // Label del cliente
                                Label lblCliente = new Label();
                                lblCliente.Text = nombreCliente;
                                lblCliente.TextAlign = ContentAlignment.MiddleCenter;
                                lblCliente.Dock = DockStyle.Bottom;
                                lblCliente.Height = 20;
                                lblCliente.Cursor = Cursors.Hand;
                                lblCliente.ForeColor = Color.DarkBlue;
                                lblCliente.Font = new Font(lblCliente.Font, FontStyle.Underline);
                                lblCliente.Tag = clienteId;

                                lblCliente.Click += (s, e) =>
                                {
                                    int id = (int)((Label)s).Tag;
                                    ClienteCortes clienteCortes = new ClienteCortes(id);
                                    clienteCortes.ShowDialog();
                                };

                                // Label de la fecha
                                Label lblFecha = new Label();
                                lblFecha.Text = fecha.ToString("dd/MM/yyyy");
                                lblFecha.TextAlign = ContentAlignment.MiddleCenter;
                                lblFecha.Dock = DockStyle.Bottom;
                                lblFecha.Height = 20;
                                lblFecha.Cursor = Cursors.Hand;
                                lblFecha.Tag = fecha;

                                lblFecha.Click += (s, e) =>
                                {
                                    DateTime f = (DateTime)((Label)s).Tag;
                                    MessageBox.Show($"Ver cortes del día {f:dd/MM/yyyy}", "Fecha");
                                };

                                contenedor.Controls.Add(pb);
                                contenedor.Controls.Add(lblFecha);
                                contenedor.Controls.Add(lblCliente);
                                flpGaleria.Controls.Add(contenedor);
                            }
                        }
                    }
                }
            }
        }



        private void btnExport_Click(object sender, EventArgs e)
        {
           
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivo Excel (*.xlsx)|*.xlsx";
                sfd.FileName = DateTime.Now.ToString("yyyyMMdd") + ".xlsx";

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
                           WHERE c.Foto IS NOT NULL 
                           ORDER BY c.FechaCreacion DESC";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        

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
