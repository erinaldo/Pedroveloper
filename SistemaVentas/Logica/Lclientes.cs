using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Logica
{
 public   class Lclientes
    {
        public int idcliente { set; get; }
        public int idPersona { set; get; }
        public string IdentificadorFiscal { set; get; }
        public string Estado { set; get; }
        public double Saldo { set; get; }
    }
}
