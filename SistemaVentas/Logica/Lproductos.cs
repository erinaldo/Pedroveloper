using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Logica
{
   public  class Lproductos
    {
        public int idProducto { get; set; }
        public int idCategoria { get; set; }
        public int idPrecios { get; set; }
        public int idDescuento { get; set; }
        public int idUnidad { get; set; }
        public int idImpuesto { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public double Stock { get; set; }
        public double Preciodecompra { get; set; }


        // Detalle

        public int idDetalleProductos { get; set; }
        public int idProveedor { get; set; }
        public string Localizacion { get; set; }
        public double StockMinimo { get; set; }
        public string usointerno { get; set; }
        public string granel { get; set; }
        public string Peso { get; set; }
        public string FechaVencimiento { get; set; }

    }
}
