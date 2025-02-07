using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPrestamos.Modelos
{
    public class Prestamo
    {
        public int ID { get; set; } // ID del préstamo
        public int ID_Cliente { get; set; } // ID del cliente relacionado
        public decimal Monto { get; set; } // Monto del préstamo
        public decimal Interes { get; set; } // Tasa de interés (%)
        public int Plazo { get; set; } // Plazo en meses
    }
}
