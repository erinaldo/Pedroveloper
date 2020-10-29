using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Logica
{
    public class LVehiculos
    {
        public int idVehiculo { set; get; }
        public string NPlaca { set; get; }
        public string Transmision { set; get; }
        public string Color { set; get; }
        public string Marca { set; get; }
        public string Modelo { set; get; }
        public int Ano { set; get; }
        public string Estado { set; get; }
        public byte[] icono { set; get; }
        public int idTipoVehiculo { set; get; }
        public string TipoVehiculo { set; get; }
        public string Carga { set; get; }


    }
}
