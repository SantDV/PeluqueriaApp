using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeluqueriaApp.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }               // Clave primaria
        public string Nombre { get; set; }        // No nulo
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Observaciones { get; set; }
        public string PrecioCorte { get; set; } // Precio del corte, no nulo
        public string Domicilio { get; set; } // Precio del corte, no nulo

        public byte[]? Foto { get; set; } // Puede ser nulo, si no se proporciona una foto
        public DateTime FechaCreacion { get; set; }
    }

}
