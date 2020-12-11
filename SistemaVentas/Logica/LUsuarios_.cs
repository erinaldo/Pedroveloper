using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SistemaVentas.Logica
{
    public class LUsuarios_
    {
        public DataTable CargarCombo()
        {
            CONEXION.CONEXIONMAESTRA.abrir();
            SqlDataAdapter da = new SqlDataAdapter("obtenerUsuariosRestaurar", CONEXION.CONEXIONMAESTRA.conectar);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            CONEXION.CONEXIONMAESTRA.cerrar();
            return dt;
        }
    }
}
