using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Logica
{
    public class LHorario
    {
        public int idHorario { get; set; }
        public string horaEntrada { get; set; }
        public string horaSalida { get; set; }
        public int idTipoHorario { get; set; }

        public string Descripcion_TipoHorario { get; set; }


    }
}
