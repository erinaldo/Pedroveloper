using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Logica
{
   public class Pedidos
    {
        public int idPedido { get; set; }
        public int idCliente { get; set; }
        public int idfactura { get; set; }
        public int idEmpleado { get; set; }
        public int idVehiculo { get; set; }
        public DateTime FechaEnvio { get; set; }
        public string Destinatario { get; set; }
        public string DireccionDestinatario { get; set; }
        public string Estado { get; set; }
    }
}
