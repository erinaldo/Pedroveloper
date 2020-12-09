using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Logica
{
   public  class Lproveedores
    {
        public int idFactura { get; set; }
        public int IdProveedor { set; get; }
        public int idPersona { set; get; }

        public string  Nombre { set; get; }
        public string Direccion { set; get; }
        public string IdentificadorFiscal { set; get; }
        public string Celular { set; get; }
        public string Estado { set; get; }
        public double  Saldo { set; get; }

    }
}
