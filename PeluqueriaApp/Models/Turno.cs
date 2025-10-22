using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeluqueriaApp.Models
{
    public class Turno
    {
        public string Nombre { get; set; } = "";
        public string Telefono { get; set; } = "";
        public DateTime FechaHora { get; set; }
        public string Nota { get; set; } = "";
    }
}