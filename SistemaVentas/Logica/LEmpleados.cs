using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Logica
{
   public class LEmpleados
    {
        public int idEmpleado { set; get; }
        public int idPersona { get; set; }
        public string cuentaBanco { set; get; }
        public string departamento { set; get; }
        public string banco { set; get; }
        public byte[] icono { set; get; }
        public int idHorario { get; set; }
    }
}
