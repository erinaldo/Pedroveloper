using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Logica
{
    public class LCategoria
    {
        public int idCategoria { get; set; }
        public int idImpuesto { get; set; }
        public int idDescuento { get; set; }
        public string Departamento { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    }
}
