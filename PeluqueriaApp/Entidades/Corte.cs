using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeluqueriaApp.Entidades
{
    public class Corte
    {

        public int Id { get; set; }
        public int ClienteId { get; set; }

        public string NombreCliente { get; set; }
        public string Descripcion { get; set; }
        public byte[] Foto { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Cobro { get; set; }

    }
}
