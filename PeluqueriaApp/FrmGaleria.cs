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

                string sql = @"
            SELECT f.Imagen, c.FechaCreacion
            FROM FotosCorte f
            JOIN Cortes c ON c.Id = f.CorteId
            WHERE c.ClienteId = @ClienteId
            ORDER BY c.FechaCreacion DESC";

                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ClienteId", cliente.Id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            byte[] bytes = (byte[])reader["Imagen"];
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

        }

        void Exportar()
        {
            if (cliente.Id == 0)
            {
                MessageBox.Show("Seleccioná un cliente primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivo Excel (*.xlsx)|*.xlsx";
                sfd.FileName = $"c_{cliente.Nombre}_{DateTime.Now:yyyyMMdd}.xlsx";

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                string conexion = "Data Source=peluqueriaDB.db; Version=3;";
                string carpetaImagenes = Path.Combine(Path.GetDirectoryName(sfd.FileName), "imagenes");
                Directory.CreateDirectory(carpetaImagenes);

                using (var conn = new SQLiteConnection(conexion))
                {
                    conn.Open();
                    string sql = @"
                SELECT 
                    c.FechaCreacion, 
                    c.Descripcion, 
                    cl.Nombre AS Cliente,
                    f.Imagen,
                    f.FechaSubida
                FROM Cortes c
                JOIN Clientes cl ON cl.Id = c.ClienteId
                JOIN FotosCorte f ON f.CorteId = c.Id
                WHERE c.ClienteId = @ClienteId
                ORDER BY c.FechaCreacion DESC, f.FechaSubida DESC";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ClienteId", cliente.Id);

                        using (var reader = cmd.ExecuteReader())
                        {
                            var wb = new XLWorkbook();
                            var ws = wb.Worksheets.Add("Cortes");

                            // Encabezados
                            ws.Cell(1, 1).Value = "Cliente";
                            ws.Cell(1, 2).Value = "Fecha del Corte";
                            ws.Cell(1, 3).Value = "Observación";
                            ws.Cell(1, 4).Value = "Foto";

                            ws.Row(1).Style.Font.Bold = true;
                            ws.Range("A1:D1").Style.Fill.BackgroundColor = XLColor.LightGray;
                            ws.Columns().AdjustToContents();

                            int fila = 2;

                            while (reader.Read())
                            {
                                string nombreCliente = reader["Cliente"].ToString();
                                DateTime fechaCorte = Convert.ToDateTime(reader["FechaCreacion"]);
                                string obs = reader["Descripcion"]?.ToString() ?? "";
                                byte[] imagenBytes = reader["Imagen"] as byte[];

                                if (imagenBytes == null || imagenBytes.Length == 0)
                                    continue;

                                string nombreImagen = $"corte_{fechaCorte:yyyyMMdd}_{fila}.jpg";
                                string rutaImagen = Path.Combine(carpetaImagenes, nombreImagen);

                                try
                                {
                                    using (MemoryStream ms = new MemoryStream(imagenBytes))
                                    using (Image img = Image.FromStream(ms))
                                    {
                                        img.Save(rutaImagen, ImageFormat.Jpeg);
                                    }

                                    // Escribir datos
                                    ws.Cell(fila, 1).Value = nombreCliente;
                                    ws.Cell(fila, 2).Value = fechaCorte.ToString("dd/MM/yyyy");
                                    ws.Cell(fila, 3).Value = obs;

                                    // Ajustar celda y agregar imagen
                                    ws.Row(fila).Height = 80;
                                    ws.Column(4).Width = 15;

                                    var pic = ws.AddPicture(rutaImagen)
                                        .MoveTo(ws.Cell(fila, 4), new Point(5, 5))
                                        .WithSize(80, 80);

                                    ws.Cell(fila, 4).SetHyperlink(new XLHyperlink("imagenes/" + nombreImagen));

                                    fila++;
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error al procesar una imagen:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }

                            wb.SaveAs(sfd.FileName);
                        }
                    }
                }

                MessageBox.Show("Exportación completa.\nEl archivo y las imágenes se guardaron correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnExport_Click_1(object sender, EventArgs e)
        {
            Exportar();
        }
    }
}
