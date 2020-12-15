using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SistemaVentas.Logica
{
    public class LVentasPrecios
    {
        public DataTable CargarCombo(int id)
        {
            CONEXION.CONEXIONMAESTRA.abrir();
            SqlDataAdapter da = new SqlDataAdapter("ObtenerListaProductos", CONEXION.CONEXIONMAESTRA.conectar);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@idFactura", id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CONEXION.CONEXIONMAESTRA.cerrar();
            return dt;
        }
        public DataTable CargarComboLista(int id)
        {
            CONEXION.CONEXIONMAESTRA.abrir();
            SqlDataAdapter da = new SqlDataAdapter("ObtenerListaPrecioPorProductos", CONEXION.CONEXIONMAESTRA.conectar);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@idProducto", id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CONEXION.CONEXIONMAESTRA.cerrar();
            return dt;
        }

        public DataTable CargarComboListaMayor(int id)
        {
            CONEXION.CONEXIONMAESTRA.abrir();
            SqlDataAdapter da = new SqlDataAdapter("ObtenerListaPrecioMayorPorProductos", CONEXION.CONEXIONMAESTRA.conectar);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@idProducto", id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CONEXION.CONEXIONMAESTRA.cerrar();
            return dt;
        }

    }
}
