using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPrestamos.Modelos
{
    public class Cuenta
    {
        public int ID { get; set; } // ID de la cuenta
        public int ID_Cliente { get; set; } // ID del cliente relacionado
        public decimal Saldo { get; set; } // Saldo disponible en la cuenta
    }
}
