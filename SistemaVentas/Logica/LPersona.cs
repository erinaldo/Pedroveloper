using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Logica
{
    public class LPersona
    {
        public int idPersona { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime fechaNacimiento { set; get; }

        public int idDireccion { get; set; }
        public int idDocumento { get; set; }
        public int idTelefono { get; set; }
        public string correo { get; set; }

    }
}
