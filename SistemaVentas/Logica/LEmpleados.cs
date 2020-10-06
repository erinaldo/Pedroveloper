using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Logica
{
   public class LEmpleados
    {
        public int idEmpleado { set; get; }
        public string nombre { set; get; }
        public string cedula { set; get; }
        public string correoElectronico { set; get; }
        public string cuentaBanco { set; get; }
        public DateTime fechaNacimiento { set; get; }
        public string departamento { set; get; }
        public string banco { set; get; }
        public byte[] icono { set; get; }

        public string Departamento { set; get; }

    }
}
