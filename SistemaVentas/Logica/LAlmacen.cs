using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Logica
{
    public class LAlmacen
    {
        public int idAlmacen { get; set; }
        public string localizaicon { get; set; }
        public string Anaquel { get; set; }
        public string Zona{ get; set; }
        public int idLocalizacion { get; set; }
        public string almacen { get; set; }
        public double stockminimo { get; set; }
        public int idDireccion { get; set; }

    }
}
