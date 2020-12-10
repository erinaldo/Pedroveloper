using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistemaVentas.Logica;
using SistemaVentas.CONEXION;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Xml.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SistemaVentas.Datos
{
    public class Obtener_datos
    {
        private static string serialPC;
        private static int idcaja;

        public static void Obtener_id_caja_PorSerial(ref int idcaja)
        {

            try
            {
                Bases.Obtener_serialPC(ref serialPC);
                CONEXIONMAESTRA.abrir();
                SqlCommand com = new SqlCommand("mostrar_cajas_por_Serial_de_DiscoDuro", CONEXIONMAESTRA.conectar);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Serial", serialPC);
                idcaja = Convert.ToInt32(com.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);

            }
        }
        public static void BuscarDetalleProducto(ref DataTable dt, int idProducto)
        {

            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter com = new SqlDataAdapter("MostrarprodutosDetalle", CONEXIONMAESTRA.conectar);
                com.SelectCommand.CommandType = CommandType.StoredProcedure;
                com.SelectCommand.Parameters.AddWithValue("@idProducto", idProducto);
                com.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);

            }
        }



        public static void mostrarImpuestos(ref DataTable dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrarImpuestos", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);

            }
        }
        public static void mostrarDescuentos(ref DataTable dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrarDescuento", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);

            }
        }
        public static void buscarUnidades(ref DataTable dt, string buscador)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("buscarUnidades", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@buscar", buscador);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)    {
                MessageBox.Show(ex.StackTrace);

            }
        }
        public static void mostrarUnidades(ref DataTable dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrarUnidades", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);

            }
        }

        public static void mostrarAlmacen(ref DataTable dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrarAlmacen", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);

            }
        }

        public static void buscarDireccion(ref DataTable dt, string buscador)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("buscarImpuestos", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letra", buscador);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);

            }
        }

        public static void buscarTipoTelefono(ref DataTable dt, string buscador)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("buscarTipoVehiculo", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letra", buscador);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);

            }
        }
        public static int obtenerDocumentoid(string numeracion)
        {
            int idDocumento;
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("obtenerDocumentoid", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@documento", numeracion);
                idDocumento = Convert.ToInt32(cmd.ExecuteScalar());
                return idDocumento;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                return idDocumento = 0;
            }
        }
        public static int obtenerTelefonoid(string numeracion)
        {
            int idDocumento;
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("obtenerTelefonoid", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@telefono", numeracion);
                idDocumento = Convert.ToInt32(cmd.ExecuteScalar());
                return idDocumento;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                return idDocumento = 0;
            }
        }
        public static int obtenerPersonaid(string numeracion)
        {
            int idDocumento;
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("obtenerPersonaid", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@documento", numeracion);
                idDocumento = Convert.ToInt32(cmd.ExecuteScalar());
                return idDocumento;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                return idDocumento = 0;
            }
        }
        public static int obtenerDocumento()
        {
            int idDocumento;
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand com = new SqlCommand("obtenerDocumento", CONEXIONMAESTRA.conectar);
                com.CommandType = CommandType.StoredProcedure;
                idDocumento = Convert.ToInt32(com.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();
                return idDocumento;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return idDocumento = 0;
            }
        }
        public static string obtenerDireccion(string descripcion)
        {
            string idDocumento;
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand com = new SqlCommand("verificarDireccion", CONEXIONMAESTRA.conectar);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@descripcion", descripcion);
                idDocumento = (string)com.ExecuteScalar();
                CONEXIONMAESTRA.cerrar();
                return idDocumento;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return idDocumento = "";
            }
        }
        public static string verificarTipoTelefono(string descripcion)
        {
            string idDocumento;
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand com = new SqlCommand("verificarDireccion", CONEXIONMAESTRA.conectar);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@descripcion", descripcion);
                idDocumento = (string)com.ExecuteScalar();
                CONEXIONMAESTRA.cerrar();
                return idDocumento;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return idDocumento = "";
            }
        }
        public static int obtenerHorario()
        {
            int idHorario;
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand com = new SqlCommand("obtenerHorario", CONEXIONMAESTRA.conectar);
                com.CommandType = CommandType.StoredProcedure;
                idHorario = Convert.ToInt32(com.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();
                return idHorario;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return idHorario = 0;
            }
        }

        public static int obtenerTipoTelefono()
        {
            int idTipoTelefono;
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand com = new SqlCommand("obtenerTipoTelefono", CONEXIONMAESTRA.conectar);
                com.CommandType = CommandType.StoredProcedure;
                idTipoTelefono = Convert.ToInt32(com.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();
                return idTipoTelefono;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return idTipoTelefono = 0;
            }
        }
        public static int obtenerTipoTelefonoid( string tipotelefono)
        {
            int idTipoTelefono;
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand com = new SqlCommand("obtenerTipoTelefonoid", CONEXIONMAESTRA.conectar);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@TipoTelefono", tipotelefono);
                idTipoTelefono = Convert.ToInt32(com.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();
                return idTipoTelefono;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return idTipoTelefono = 0;
            }
        }
        public static int obtenerPersona()
        {
            int idPersona;
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand com = new SqlCommand("obtenerPersona", CONEXIONMAESTRA.conectar);
                com.CommandType = CommandType.StoredProcedure;
                idPersona = Convert.ToInt32(com.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();
                return idPersona;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return idPersona = 0;
            }
        }
        public static int obtenerTelefono()
        {
            int idTelefono;
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand com = new SqlCommand("obtenerTelefono", CONEXIONMAESTRA.conectar);
                com.CommandType = CommandType.StoredProcedure;
                idTelefono = Convert.ToInt32(com.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();
                return idTelefono;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return idTelefono = 0;
            }
        }
     
        public static int obtenerTipoHorarip()
        {
            int idTipoHorario;
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand com = new SqlCommand("obtenerTipoHorarip", CONEXIONMAESTRA.conectar);
                com.CommandType = CommandType.StoredProcedure;
                idTipoHorario = Convert.ToInt32(com.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();
                return idTipoHorario;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return idTipoHorario = 0;
            }
        }


        public static int ObtenerRegion()
        {
            int idRegion;
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand com = new SqlCommand("obtenerRegion", CONEXIONMAESTRA.conectar);
                com.CommandType = CommandType.StoredProcedure;
                idRegion = Convert.ToInt32(com.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();
                return idRegion;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return idRegion = 0;
            }
        }

        public static bool ObtenerDireccion(ref DataTable dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter com = new SqlDataAdapter("mostrarDireccion", CONEXIONMAESTRA.conectar);
                com.Fill(dt);
                CONEXIONMAESTRA.cerrar();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return true;
            }
        }
        public bool Mostrar_ticket_impresos(ref DataTable dt,int idfactura, string total_en_letras2)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("Mostrar_ticket_impreso", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Id_factura", idfactura);
                da.SelectCommand.Parameters.AddWithValue("@total_en_letras", total_en_letras2);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return true;
            }
        }

        public bool mostrarVehiculosV(ref DataTable dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrarVehiculosV", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return true;
            }
        }

        public bool mostrarEmpleadosV(ref DataTable dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MostrarempleadosvehiculosV", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return true;
            }
        }

        public static int ObtenerMunicipio()
        {
            int idMunicipio;
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand com = new SqlCommand("obtenerMunicipio", CONEXIONMAESTRA.conectar);
                com.CommandType = CommandType.StoredProcedure;
                idMunicipio = Convert.ToInt32(com.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();
                return idMunicipio;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return idMunicipio = 0;
            }
        }
        public static int ObtenerSector()
        {
            int idSector;
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand com = new SqlCommand("obtenerSector", CONEXIONMAESTRA.conectar);
                com.CommandType = CommandType.StoredProcedure;
                idSector = Convert.ToInt32(com.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();
                return idSector;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return idSector = 0;
            }
        }
        public static int ObtenerProvincia()
        {
            int idProvincia;
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand com = new SqlCommand("obtenerProvincia", CONEXIONMAESTRA.conectar);
                com.CommandType = CommandType.StoredProcedure;
                idProvincia = Convert.ToInt32(com.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();
                return idProvincia;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return idProvincia = 0;
            }
        }

        public static int ObtenerCalle()
        {
            int idCalle;
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand com = new SqlCommand("obtenerCalle", CONEXIONMAESTRA.conectar);
                com.CommandType = CommandType.StoredProcedure;
                idCalle = Convert.ToInt32(com.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();
                return idCalle;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return idCalle = 0;
            }
        }



        public static void mostrarVehiculos(ref DataTable dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrarVehiculos", CONEXIONMAESTRA.conectar);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);

            }
        }

        public static void mostrarPedido(ref DataTable dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrarPedidosEnCurso", CONEXIONMAESTRA.conectar);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void mostrarPedidoEspecifico(ref DataTable dt , int idPedido)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrarPedidoEspecifico", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idPedido", idPedido);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void EstadoPersonal(ref DataTable dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrarEmpleadosVehiculos", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //da.SelectCommand.Parameters.AddWithValue(@)
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void EstadoVehiculos(ref DataTable dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrarVehiculosDisponibles", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void BuscarVehiculos(ref DataTable dt, string buscador)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("Mostrartipovehiculo", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letra", buscador);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);

            }
        }
        public static void mostrar_ventas_en_espera_con_fecha_y_monto(ref DataTable dt)
        {

            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("Mostrar_facturas_en_espera_con_fecha_y_monto", CONEXIONMAESTRA.conectar);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void mostrar_compras_en_espera_con_fecha_y_monto(ref DataTable dt)
        {

            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("Mostrar_compras_en_espera_con_fecha_y_monto", CONEXIONMAESTRA.conectar);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);

            }
        }
        public static void mostrar_cotizacion_en_espera_con_fecha_y_monto(ref DataTable dt)
        {
            try
            {
                CONEXIONMAESTRA.cerrar();
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_cotizaciones_en_espera_con_fecha_y_monto", CONEXIONMAESTRA.conectar);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);

            }
        }
        public static void mostrar_productos_agregados_a_ventas_en_espera(ref DataTable dt, int idfactura)
        {

            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_productos_agregados_a_facturas_en_espera", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idfactura", idfactura);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);

            }
        }
        public static void mostrar_productos_agregados_a_compras_en_espera(ref DataTable dt, int idfactura)
        {

            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_productos_agregados_a_compras_en_espera", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idCompra", idfactura);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);

            }
        }
        public static void mostrar_productos_agregados_a_cotizaciones_en_espera(ref DataTable dt, int idfactura)
        {

            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_productos_agregados_a_cotizaciones_en_espera", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idfactura", idfactura);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);

            }
        }

        public static void buscar_conceptos(ref DataTable dt, string buscador)
        {

            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("buscar_conceptos", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letra", buscador);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);

            }
        }

        public static void mostrar_gastos_por_turnos(int idcaja, DateTime fi, DateTime ff, ref DataTable dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_gastos_por_turnos", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idcaja", idcaja);
                da.SelectCommand.Parameters.AddWithValue("@fi", fi);
                da.SelectCommand.Parameters.AddWithValue("@ff", ff);

                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);

            }

        }
        public static void mostrar_ingresos_por_turnos(int idcaja, DateTime fi, DateTime ff, ref DataTable dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_ingresos_por_turnos", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idcaja", idcaja);
                da.SelectCommand.Parameters.AddWithValue("@fi", fi);
                da.SelectCommand.Parameters.AddWithValue("@ff", ff);

                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);

            }

        }

        public static void mostrar_cierre_de_caja_pendiente(ref DataTable dt)
        {
            Obtener_id_caja_PorSerial(ref idcaja);

            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_cierre_de_caja_pendiente", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idcaja", idcaja);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);

            }

        }

        public static void mostrar_inicio_De_sesion(ref int idusuario)
        {
            Bases.Obtener_serialPC(ref serialPC);
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("mostrar_inicio_De_sesion", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_serial_pc", serialPC);
                idusuario = Convert.ToInt32(cmd.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }
        }
        public static void obtenerAccesoUsuarios(ref int idUsuario)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("obtenerAccesoUsuarios", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                idUsuario = Convert.ToInt32(cmd.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void mostrarUsuariosSesion(ref DataTable dt)
        {
            try
            {
                Bases.Obtener_serialPC(ref serialPC);
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_inicio_De_sesion", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@id_serial_pc", serialPC);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }
        }
        public static void mostrar_ventas_en_efectivo_por_turno(int idcaja, DateTime fi, DateTime ff, ref double monto)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand da = new SqlCommand("Mostrar_facturas_en_efectivo_por_turno", CONEXIONMAESTRA.conectar);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@idcaja", idcaja);
                da.Parameters.AddWithValue("@fi", fi);
                da.Parameters.AddWithValue("@ff", ff);
                monto = Convert.ToDouble(da.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();
            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            {

                monto = 0;

            }

        }
        public static void mostrar_cobros_en_efectivo_por_turno(int idcaja, DateTime fi, DateTime ff, ref double monto)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand da = new SqlCommand("mostrar_cobros_en_efectivo_por_turno", CONEXIONMAESTRA.conectar);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@idcaja", idcaja);
                da.Parameters.AddWithValue("@fi", fi);
                da.Parameters.AddWithValue("@ff", ff);
                monto = Convert.ToDouble(da.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();
            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            {

                monto = 0;

            }

        }
        public static void mostrar_cobros_tarjeta_por_turno(int idcaja, DateTime fi, DateTime ff, ref double monto)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand da = new SqlCommand("mostrar_cobros_tarjeta_por_turno", CONEXIONMAESTRA.conectar);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@idcaja", idcaja);
                da.Parameters.AddWithValue("@fi", fi);
                da.Parameters.AddWithValue("@ff", ff);
                monto = Convert.ToDouble(da.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();
            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            {

                monto = 0;

            }

        }

        public static void M_ventas_Tarjeta_por_turno(int idcaja, DateTime fi, DateTime ff, ref double monto)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand da = new SqlCommand("M_facturas_Tarjeta_por_turno", CONEXIONMAESTRA.conectar);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@idcaja", idcaja);
                da.Parameters.AddWithValue("@fi", fi);
                da.Parameters.AddWithValue("@ff", ff);
                monto = Convert.ToDouble(da.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();
            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            {
                monto = 0;
            }
        }
        public static void M_ventas_credito_por_turno(int idcaja, DateTime fi, DateTime ff, ref double monto)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand da = new SqlCommand("M_facturas_credito_por_turno", CONEXIONMAESTRA.conectar);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@idcaja", idcaja);
                da.Parameters.AddWithValue("@fi", fi);
                da.Parameters.AddWithValue("@ff", ff);
                monto = Convert.ToDouble(da.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();
            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            {

                monto = 0;
            }
        }

        public static void sumar_ingresos_por_turno(int idcaja, DateTime fi, DateTime ff, ref double monto)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand da = new SqlCommand("sumar_ingresos_por_turno", CONEXIONMAESTRA.conectar);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@idcaja", idcaja);
                da.Parameters.AddWithValue("@fi", fi);
                da.Parameters.AddWithValue("@ff", ff);
                monto = Convert.ToDouble(da.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();
            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            {
                monto = 0;

            }

        }
        public static void sumar_gastos_por_turno(int idcaja, DateTime fi, DateTime ff, ref double monto)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand da = new SqlCommand("sumar_gastos_por_turno", CONEXIONMAESTRA.conectar);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@idcaja", idcaja);
                da.Parameters.AddWithValue("@fi", fi);
                da.Parameters.AddWithValue("@ff", ff);
                monto = Convert.ToDouble(da.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();
            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            {
                monto = 0;

            }

        }
        public static void buscar_Proveedores(ref DataTable dt, string buscador)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("buscar_proveedores", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letra", buscador);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        public static void sumar_CreditoPorPagar(int idcaja, DateTime fi, DateTime ff, ref double monto)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand da = new SqlCommand("sumar_CreditoPorPagar", CONEXIONMAESTRA.conectar);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@idcaja", idcaja);
                da.Parameters.AddWithValue("@fi", fi);
                da.Parameters.AddWithValue("@ff", ff);
                monto = Convert.ToDouble(da.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception)
            {

                monto = 0;
            }
        }

        public static void sumar_CreditoPorCobrar(int idcaja, DateTime fi, DateTime ff, ref double monto)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand da = new SqlCommand("sumar_CreditoPorCobrar", CONEXIONMAESTRA.conectar);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@idcaja", idcaja);
                da.Parameters.AddWithValue("@fi", fi);
                da.Parameters.AddWithValue("@ff", ff);
                monto = Convert.ToDouble(da.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception)
            {

                monto = 0;
            }
        }

        public static void mostrar_cajas(ref DataTable dt)
        {
            try
            {
                Bases.Obtener_serialPC(ref serialPC);
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_cajas_por_Serial_de_DiscoDuro", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Serial", serialPC);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        public static void mostrar_empresa(ref DataTable dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("select * from EMPRESA", CONEXIONMAESTRA.conectar);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        public static void mostrarCorreoBase(ref DataTable dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("Select * from CorreoBase", CONEXIONMAESTRA.conectar);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        

        //Clientes
        public static void mostrar_clientes(ref DataTable dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_clientes", CONEXIONMAESTRA.conectar);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void mostrar_Empleados(ref DataTable dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_empleados", CONEXIONMAESTRA.conectar);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            
        }

        public static void buscar_empleados(ref DataTable dt, string buscador)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("buscarEmpleado", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letra", buscador);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void buscar_empleados2(ref DataTable dt, string buscador)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("buscarEmpleado2", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letra", buscador);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void Buscar_proveedores_(ref DataTable dt, string buscador)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("Buscar_proveedores_", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letra", buscador);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        public static void buscar_clientes(ref DataTable dt, string buscador)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("buscar_clientes", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letra", buscador);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        public static void buscarImpuestos(ref DataTable dt, string buscador)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("buscarImpuestos", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letra", buscador);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        public static void buscarDescuentos(ref DataTable dt, string buscador)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("buscarDescuentos", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letra", buscador);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        public static void mostrarEstadosCuentaCliente(ref DataTable dt, int idcliente)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrarEstadosCuentaCliente", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idcliente", idcliente);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);

            }
        }
        public static void mostrarEstadosCuentaProveedor(ref DataTable dt, int idProveedor)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrarEstadosCuentaProveedor", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idProveedor", idProveedor);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);

            }
        }
        public static void mostrarEstadosFacturas(ref DataTable dt, int idProveedor)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrarEstadosFacturas", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idProveedor", idProveedor);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);

            }
        }

        //controlCobros
        public static void mostrar_ControlCobros(ref DataTable dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_ControlCobros", CONEXIONMAESTRA.conectar);
                da.Fill(dt);

                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        public static void mostrarControlPago(ref DataTable dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrarControlPagos", CONEXIONMAESTRA.conectar);
                da.Fill(dt);

                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        public static void mostrarControlPagosFacturas(ref DataTable dt, string numFact)
        {
           // MessageBox.Show(numFact.ToString());
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrarControlCobros", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@numFact", numFact);
                da.Fill(dt);

                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        public static void ReportePorCobrar(ref double Monto )
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand da = new SqlCommand("ReportePorCobrar", CONEXIONMAESTRA.conectar);
                Monto =Convert.ToDouble ( da.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();

            }
            catch (Exception)
            {
                Monto = 0;
            }
        }
        public static void ReporteCantClientes(ref int Cantidad)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand da = new SqlCommand("select count(idclientev) from clientes", CONEXIONMAESTRA.conectar);
                Cantidad = Convert.ToInt32(da.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception)
            {
                Cantidad = 0;
            }
        }

      
    
        //Proveedores
        public static void ReportePorPagar(ref double Monto)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand da = new SqlCommand("ReportePorPagar", CONEXIONMAESTRA.conectar);
                Monto = Convert.ToDouble(da.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();

            }
            catch (Exception)
            {
                Monto = 0;
            }
        }
        public static void mostrar_Proveedores(ref DataTable dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_Proveedores", CONEXIONMAESTRA.conectar);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

     
        //facturas
        public static void mostrarVentasGrafica(ref DataTable dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrarfacturasGrafica", CONEXIONMAESTRA.conectar);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        public static void mostrarVentasGraficaFechas(ref DataTable dt,DateTime fi,DateTime ff)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrarfacturasGraficaFechas", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@fi", fi);
                da.SelectCommand.Parameters.AddWithValue("@ff", ff);

                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        public static void ReporteTotalVentas(ref double Monto)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand da = new SqlCommand("ReporteTotalfacturas", CONEXIONMAESTRA.conectar);
                Monto = Convert.ToDouble(da.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();

            }
            catch (Exception)
            {
                Monto = 0;
            }
        }
        public static void ReporteTotalVentasFechas(ref double Monto,DateTime fi, DateTime ff)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand  da = new SqlCommand("ReporteTotalfacturasFechas", CONEXIONMAESTRA.conectar);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@fi", fi);
                da.Parameters.AddWithValue("@ff", ff);
                Monto = Convert.ToDouble ( da.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();
            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            {
                Monto = 0;
            }
        }
        public static void Buscarfactura(ref DataTable dt, string buscador)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("Buscarfacturas", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@busqueda", buscador);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }
        }
        public static void BuscarCompra(ref DataTable dt, string buscador)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("BuscarCompras", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@busqueda", buscador);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }
        }
        public static void buscarVentasPorFechas(ref DataTable dt, DateTime fi, DateTime ff)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("buscarfacturasPorFechas", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@fi", fi);
                da.SelectCommand.Parameters.AddWithValue("@ff", ff);

                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }
        }
        public static void buscarComprasPorFechas(ref DataTable dt, DateTime fi, DateTime ff)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("Buscarcomprasporfechas", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@fi", fi);
                da.SelectCommand.Parameters.AddWithValue("@ff", ff);

                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }
        }
        public static void contarVentasEspera(ref int Contador)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand da = new SqlCommand("contarfacturasEspera", CONEXIONMAESTRA.conectar);
                Contador = Convert.ToInt32 ( da.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception)
            {
                Contador = 0;


            }
        }
        public static void contarCotizacionesEspera(ref int Contador)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand da = new SqlCommand("contarCotizacionesEspera", CONEXIONMAESTRA.conectar);
                Contador = Convert.ToInt32(da.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception)
            {
                Contador = 0;


            }
        }
        public static void ReporteResumenVentasHoy(ref DataTable dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("ReporteResumenfacturasHoy", CONEXIONMAESTRA.conectar);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        public static void ReporteResumenVentasHoyEmpleado(ref DataTable dt, int idEmpleado)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("ReporteResumenfacturasHoyEmpleado", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idEmpleado", idEmpleado);

                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void ReporteResumenVentasFechas(ref DataTable dt,DateTime fi , DateTime ff)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("ReporteResumenfacturasFechas", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@fi", fi);
                da.SelectCommand.Parameters.AddWithValue("@ff", ff);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        public static void ReporteResumenVentasEmpleadoFechas(ref DataTable dt, int idEmpleado, DateTime fi, DateTime ff)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("ReporteResumenfacturasEmpleadoFechas", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                da.SelectCommand.Parameters.AddWithValue("@fi", fi);
                da.SelectCommand.Parameters.AddWithValue("@ff", ff);

                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        //Detalle facturas
        public static void ReporteGanancias(ref double Monto)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand da = new SqlCommand("ReporteGanancias", CONEXIONMAESTRA.conectar);
                Monto = Convert.ToDouble(da.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();

            }
            catch (Exception)
            {
                Monto = 0;
            }
        }
        public static void ReporteGananciasFecha(ref double Monto, DateTime fi, DateTime ff)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand da = new SqlCommand("ReporteGananciasFecha", CONEXIONMAESTRA.conectar);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@fi", fi);
                da.Parameters.AddWithValue("@ff", ff);
                Monto = Convert.ToDouble(da.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();
            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            {
                Monto = 0;
            }
        }
        public static void MostrarDetalleVenta(ref DataTable dt, int idfactura)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_productos_agregados_a_factura", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idfactura", idfactura );
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }
        }
        public static void MostrarDetalleCompra (ref DataTable dt, int idfactura)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("Mostrar_productos_agregados_a_compra", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idCompra", idfactura);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }
        }
        //Productos
        public static void ReporteProductoBajoMinimo(ref int Monto)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand da = new SqlCommand("ReporteProductoBajoMinimo", CONEXIONMAESTRA.conectar);
                Monto = Convert.ToInt32(da.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception)
            {
                Monto = 0;
            }
        }
        public static void ReporteCantProductos(ref int Cantidad)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand da = new SqlCommand("select count(idProducto) from Producto", CONEXIONMAESTRA.conectar);
                Cantidad = Convert.ToInt32(da.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception)
            {
                Cantidad = 0;
            }
        }
        public static void mostrarPmasVendidos(ref DataTable dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrarPmasVendidos", CONEXIONMAESTRA.conectar);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);

            }
        }
        public static void imprimir_inventarios_todos(ref DataTable dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("imprimir_inventarios_todos", CONEXIONMAESTRA.conectar);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);

            }
        }
        public static void mostrar_productos_vencidos(ref DataTable dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_productos_vencidos", CONEXIONMAESTRA.conectar);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);

            }
        }
        public static void MOSTRAR_Inventarios_bajo_minimo(ref DataTable dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("MOSTRAR_Inventarios_bajo_minimo", CONEXIONMAESTRA.conectar);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }
        }
        public static void BUSCAR_PRODUCTOS_KARDEX(ref DataTable dt,string buscador)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("BUSCAR_PRODUCTOS_KARDEX", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letrab", buscador);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);

            }
        }

        //Empresa
        public static void MostrarMoneda(ref string moneda)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand da = new SqlCommand("select Moneda from EMPRESA", CONEXIONMAESTRA.conectar);
                moneda =Convert.ToString ( da.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
               
            }
        }
        //Gastos
        public static void ReporteGastosAnioCombo(ref DataTable dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("ReporteGastosAnioCombo", CONEXIONMAESTRA.conectar);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }
        }
        public static void ReporteGastosMesCombo(ref DataTable dt, int anio)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("ReporteGastosMesCombo", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@anio", anio);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void ReporteGastosAnio(ref DataTable dt, int año)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("ReporteGastosAnioGrafica", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@anio", año);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }
        }
        public static void ReporteGastosAnioMesGrafica(ref DataTable dt, int año, string mes)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("ReporteGastosAnioMesGrafica", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@anio", año);
                da.SelectCommand.Parameters.AddWithValue("@mes", mes);

                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }
        }
        //Caja
        public static void mostrarPuertos(ref DataTable dt)
        {
            try
            {
                Obtener_datos.Obtener_id_caja_PorSerial(ref idcaja);
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrarPuertos", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idcaja", idcaja);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }
        }
        public static bool VerificarItbis()
        {
            SqlCommand com = new SqlCommand("select Trabajas_con_impuestos from EMPRESA", CONEXION.CONEXIONMAESTRA.conectar);
            try
            {
                CONEXION.CONEXIONMAESTRA.abrir();
                string i = Convert.ToString(com.ExecuteScalar());
                CONEXION.CONEXIONMAESTRA.cerrar();
                if(i == "SI")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return false;
            }
        }
        public static void mostrarTemaCaja(ref string Tema)
        {
            try
            {
                Obtener_id_caja_PorSerial(ref idcaja);
                CONEXIONMAESTRA.abrir();
                SqlCommand  da = new SqlCommand("mostrarTemaCaja", CONEXIONMAESTRA.conectar);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@idcaja", idcaja);
                Tema = da.ExecuteScalar().ToString();
                CONEXIONMAESTRA.cerrar();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }
        }

        //Tickets
        public static void mostrar_ticket_impreso(ref DataTable dt,int idfactura,string TotalLetras)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_ticket_impreso", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Id_factura", idfactura);
                da.SelectCommand.Parameters.AddWithValue("@total_en_letras", TotalLetras);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }
        }
        //Usuarios
        public static void mostrarUsuarios(ref DataTable dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("SELECT u.idUsuario,p.nombre AS Nombre FROM USUARIO2 AS u INNER JOIN Empleados AS e ON u.idEmpleado = e.idEmpleado INNER JOIN Persona AS p ON e.idPersona = p.idPersona WHERE  u.Estado = 'ACTIVO'", CONEXIONMAESTRA.conectar);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        //Clientes
        public static void ReporteCuestasPorCobrar(ref DataTable dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("ReporteCuestasPorCobrar", CONEXIONMAESTRA.conectar);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        //Proveedores
        public static void ReporteCuestasPorPagar(ref DataTable dt)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("ReporteCuestasPorPagar", CONEXIONMAESTRA.conectar);
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static bool validar_Mail(string sMail)
        {
            return Regex.IsMatch(sMail, @"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$");

        }

        public static bool validarCedula(string sMail)
        {
            return Regex.IsMatch(sMail, @"^\\d{3}\\D?\\d{7}\\D?\\d$");

        }


    }
}
