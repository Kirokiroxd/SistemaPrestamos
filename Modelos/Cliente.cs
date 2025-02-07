using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPrestamos.Modelos
{
    public class Cliente 
    {
        public int ID { get; set; } // ID del cliente
        public string Nombre { get; set; } // Nombre completo
        public string Telefono { get; set; } // Teléfono del cliente
    }
}
