using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Logica
{
   public  class Ldetallefactura
    {
        public int iddetalle_factura { get; set; }
        public int iddetalle_compra { get; set; }

        public int idfactura { get; set; }
        public int Id_producto { get; set; }
        public double  cantidad { get; set; }
        public double preciounitario { get; set; }
        public string Moneda { get; set; }
        public double Total_a_pagar { get; set; }
        public string Unidad_de_medida { get; set; }
        public double Cantidad_mostrada { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public string Stock { get; set; }
        public string Se_vende_a { get; set; }
        public string Usa_inventarios { get; set; }
        public double  Costo { get; set; }
        public double  Ganancia { get; set; }
        public double Itbis { get; set; }
        public double Descuento { get; set; }
    }
}
