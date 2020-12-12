using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Management;
using SistemaVentas.Logica;
using SistemaVentas.CONEXION;
using SistemaVentas.Datos;
using System.IO;

namespace SistemaVentas.Presentacion.ASISTENTE_DE_INSTALACION_servidor
{
    public partial class REGISTRO_DE_EMPRESA : Form
    {
        public REGISTRO_DE_EMPRESA()
        {
            InitializeComponent();
        }
        string lblIDSERIAL;
        bool RegistroInformacionAdicional = false;
        public static string correo;
        public int idEmpresa = 0;
        public int idCiudad;
        public int idDireccionEditar;
        public int idCalle;
        public int idMunicipio;
        public int idCorreoEditar; 
        public int idCelular;
        public int idTelefono;

        public bool validar_Mail(string sMail)
        {
            return Regex.IsMatch(sMail, @"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$");

        }
        public void insertarUnidadEstandar()
        {
            /* try
             {
                 CONEXIONMAESTRA.abrir();
                 SqlCommand cmd = new SqlCommand("insertarUnidad", CONEXIONMAESTRA.conectar);
                 cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.AddWithValue("@nombre", "Ventas");
                 cmd.Parameters.AddWithValue("@Impuesto", 0.00);
                 cmd.Parameters.AddWithValue("@Tipo", "IVA");
                 cmd.ExecuteNonQuery();
             }
             catch (Exception EX)
             {
                 MessageBox.Show(EX.Message);
             }*/
        }
        public void insertarImpuesto()
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarImpuestosgeneral", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", "Ventas");
                cmd.Parameters.AddWithValue("@Impuesto", 0.18);
                cmd.Parameters.AddWithValue("@Tipo", "Impuesto Productos");

                cmd.ExecuteNonQuery();
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }

            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarImpuestosgeneral", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", "Ventas");
                cmd.Parameters.AddWithValue("@Impuesto", 0.18);
                cmd.Parameters.AddWithValue("@Tipo", "Impuesto Categoria");

                cmd.ExecuteNonQuery();
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        public void insertarImpuestoGenerico()
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarImpuestosgeneral", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", "Generico");
                cmd.Parameters.AddWithValue("@Impuesto", 0.00);
                cmd.Parameters.AddWithValue("@Tipo", "Impuesto Productos");
                cmd.ExecuteNonQuery();
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }

            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarImpuestosgeneral", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", "Generico");
                cmd.Parameters.AddWithValue("@Impuesto", 0.00);
                cmd.Parameters.AddWithValue("@Tipo", "Impuesto Categoria");
                cmd.ExecuteNonQuery();
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }
        private void Ingresar_caja()
        {
            try
            {


                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("Insertar_caja", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@descripcion", txtcaja.Text);
                cmd.Parameters.AddWithValue("@Tema", "Redentor");
                cmd.Parameters.AddWithValue("@Serial_PC", lblIDSERIAL);
                cmd.Parameters.AddWithValue("@Impresora_Ticket", "Ninguna");
                cmd.Parameters.AddWithValue("@Impresora_A4", "Ninguna");
                cmd.Parameters.AddWithValue("@Tipo", "PRINCIPAL");
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void insertar_3_COMPROBANTES_POR_DEFECTO()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("insertar_Serializacion", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Serie", "T");
                cmd.Parameters.AddWithValue("@numeroinicio", 6);
                cmd.Parameters.AddWithValue("@numerofin", 0);
                cmd.Parameters.AddWithValue("@tipodoc", "TICKET");
                cmd.Parameters.AddWithValue("@Destino", "facturaS");
                cmd.Parameters.AddWithValue("@Por_defecto", "SI");
                cmd.ExecuteNonQuery();
                con.Close();

                con.Open();
                cmd = new SqlCommand("insertar_Serializacion", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Serie", "B");
                cmd.Parameters.AddWithValue("@numeroinicio", 6);
                cmd.Parameters.AddWithValue("@numerofin", 0);
                cmd.Parameters.AddWithValue("@tipodoc", "BOLETA");
                cmd.Parameters.AddWithValue("@Destino", "facturaS");
                cmd.Parameters.AddWithValue("@Por_defecto", "-");
                cmd.ExecuteNonQuery();
                con.Close();

                con.Open();
                cmd = new SqlCommand("insertar_Serializacion", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Serie", "F");
                cmd.Parameters.AddWithValue("@numeroinicio", 6);
                cmd.Parameters.AddWithValue("@numerofin", 0);
                cmd.Parameters.AddWithValue("@tipodoc", "factura");
                cmd.Parameters.AddWithValue("@Destino", "facturaS");
                cmd.Parameters.AddWithValue("@Por_defecto", "-");
                cmd.ExecuteNonQuery();
                con.Close();

                con.Open();
                cmd = new SqlCommand("insertar_Serializacion", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Serie", "I");
                cmd.Parameters.AddWithValue("@numeroinicio", 6);
                cmd.Parameters.AddWithValue("@numerofin", 0);
                cmd.Parameters.AddWithValue("@tipodoc", "INGRESO");
                cmd.Parameters.AddWithValue("@Destino", "INGRESO DE COBROS");
                cmd.Parameters.AddWithValue("@Por_defecto", "-");
                cmd.ExecuteNonQuery();
                con.Close();

                con.Open();
                cmd = new SqlCommand("insertar_Serializacion", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Serie", "E");
                cmd.Parameters.AddWithValue("@numeroinicio", 6);
                cmd.Parameters.AddWithValue("@numerofin", 0);
                cmd.Parameters.AddWithValue("@tipodoc", "EGRESO");
                cmd.Parameters.AddWithValue("@Destino", "EGRESO DE PAGOS");
                cmd.Parameters.AddWithValue("@Por_defecto", "-");
                cmd.ExecuteNonQuery();
                con.Close();

                con.Open();
                cmd = new SqlCommand("Insertar_FORMATO_TICKET", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Identificador_fiscal", "RNC Identificador Fiscal de la Empresa");
                cmd.Parameters.AddWithValue("@Direccion", "Calle, Nro, avenida");
                cmd.Parameters.AddWithValue("@Provincia_Departamento_Pais", "Provincia - Departamento - Pais");
                cmd.Parameters.AddWithValue("@Nombre_de_Moneda", "Nombre de Moneda");
                cmd.Parameters.AddWithValue("@Agradecimiento", "Agradecimiento");
                cmd.Parameters.AddWithValue("@pagina_Web_Facebook", "pagina Web ó Facebook");
                cmd.Parameters.AddWithValue("@Anuncio", "Anuncio");
                cmd.Parameters.AddWithValue("@Datos_fiscales_de_autorizacion", "Datos Fiscales - Numero de Autorizacion, Resolucion...");
                cmd.Parameters.AddWithValue("@Por_defecto", "Ticket No Fiscal");
                cmd.ExecuteNonQuery();
                con.Close();

                con.Open();
                cmd = new SqlCommand("insertarCorreoBase", con);
                cmd.CommandType = CommandType.StoredProcedure;
                string correo;
                string pass;
                string estado;
                correo = Bases.Encriptar("-");
                pass = Bases.Encriptar("-");
                estado = "Sin confirmar";
                cmd.Parameters.AddWithValue("@Correo", correo);
                cmd.Parameters.AddWithValue("@Password", pass);
                cmd.Parameters.AddWithValue("@Estado_De_envio", estado);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void insertar_Proveedores()
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertar_Proveedores", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPersona", 1);
                cmd.Parameters.AddWithValue("@IdentificadorFiscal", "-");
                cmd.Parameters.AddWithValue("@Estado", "-");
                cmd.Parameters.AddWithValue("@Saldo", 0);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }

        private void insertarPermisosRol()
        {
            int cant = 0;
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand da = new SqlCommand("select count(idIOperacion) from Operaciones", CONEXIONMAESTRA.conectar);
                cant = Convert.ToInt32(da.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            string operacion = "";
            int res = cant / 3;
            int idRol = 1;
            int res2 = res * 2;
            for (int i = 1; i <= cant; i++)
            {
                if (i == res + 1)
                {
                    idRol = 2;
                }
                if (i == res2 + 1)
                {
                    idRol = 3;
                }
                try
                {
                    CONEXIONMAESTRA.abrir();
                    SqlCommand cmd = new SqlCommand("insertarRolVsOperaciones", CONEXIONMAESTRA.conectar);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idRol", idRol);
                    cmd.Parameters.AddWithValue("@idOperacion", i);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    CONEXIONMAESTRA.cerrar();
                }
            }
        }
        
        private void insertarPermisos()
        {

            int cant = 0;
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand da = new SqlCommand("select count(idModulo) from Modulo", CONEXIONMAESTRA.conectar);
                cant = Convert.ToInt32(da.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
            string operacion = "";

            for (int i = 1; i <= cant; i++)
            {
                try
                {
                    CONEXIONMAESTRA.abrir();
                    SqlCommand cmd = new SqlCommand("insertarOperaciones", CONEXIONMAESTRA.conectar);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Operacion", "ACCESO");
                    cmd.Parameters.AddWithValue("@idModulo", i);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    CONEXIONMAESTRA.cerrar();
                }
            }

            for (int i = 1; i <= cant; i++)
            {
                switch (i)
                {
                    case 1:
                        operacion = "SIN ACCESO";
                        break;
                    case 2:
                        operacion = "SIN ACCESO";
                        break;
                    case 3:
                        operacion = "ACCESO";

                        break;
                    case 4:
                        operacion = "SIN ACCESO";
                        break;
                    case 5:
                        operacion = "ACCESO";

                        break;
                    case 6:
                        operacion = "ACCESO";

                        break;
                    case 7:
                        operacion = "ACCESO";

                        break;
                    case 8:
                        operacion = "SIN ACCESO";
                        break;
                    case 9:
                        operacion = "ACCESO";

                        break;
                    case 10:
                        operacion = "SIN ACCESO";
                        break;
                    case 11:
                        operacion = "SIN ACCESO";
                        break;
                    case 12:
                        operacion = "ACCESO";

                        break;
                    case 13:
                        operacion = "ACCESO";

                        break;
                    case 14:
                        operacion = "SIN ACCESO";
                        break;
                    case 15:
                        operacion = "SIN ACCESO";
                        break;
                    case 16:
                        operacion = "SIN ACCESO";
                        break;
                    case 17:
                        operacion = "SIN ACCESO";
                        break;
                    case 18:
                        operacion = "SIN ACCESO";
                        break;
                    case 19:
                        operacion = "ACCESO";

                        break;
                    case 20:
                        operacion = "ACCESO";

                        break;
                    case 21:
                        operacion = "ACCESO";

                        break;
                    case 22:
                        operacion = "ACCESO";

                        break;
                    case 23:
                        operacion = "ACCESO";

                        break;
                    case 24:
                        operacion = "ACCESO";

                        break;
                    case 25:
                        operacion = "ACCESO";
                        break;
                    case 26:
                        operacion = "ACCESO";
                        break;
                    case 27:
                        operacion = "SIN ACCESO";
                        break;
                    case 28:
                        operacion = "ACCESO";
                        break;
                    case 29:
                        operacion = "ACCESO";
                        break;
                    case 30:
                        operacion = "ACCESO";
                        break;
                    case 31:
                        operacion = "ACCESO";
                        break;
                    case 32:
                        operacion = "SIN ACCESO";
                        break;
                }

                try
                {
                    CONEXIONMAESTRA.abrir();
                    SqlCommand cmd = new SqlCommand("insertarOperaciones", CONEXIONMAESTRA.conectar);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Operacion", operacion);
                    cmd.Parameters.AddWithValue("@idModulo", i);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    CONEXIONMAESTRA.cerrar();
                }
            }

        }
        private void permisosrolfactura()
        {
            int cant = 0;
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand da = new SqlCommand("select count(idModulo) from Modulo", CONEXIONMAESTRA.conectar);
                cant = Convert.ToInt32(da.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
            string operacion = "";
            for (int i = 1; i <= cant; i++)
            {
                switch (i)
                {
                    case 1:
                        operacion = "SIN ACCESO";
                        break;
                    case 2:
                        operacion = "SIN ACCESO";
                        break;
                    case 3:
                        operacion = "ACCESO";

                        break;
                    case 4:
                        operacion = "SIN ACCESO";
                        break;
                    case 5:
                        operacion = "SIN ACCESO";
                        break;
                    case 6:
                        operacion = "SIN ACCESO";

                        break;
                    case 7:
                        operacion = "SIN ACCESO";

                        break;
                    case 8:
                        operacion = "SIN ACCESO";
                        break;
                    case 9:
                        operacion = "SIN ACCESO";

                        break;
                    case 10:
                        operacion = "SIN ACCESO";
                        break;
                    case 11:
                        operacion = "SIN ACCESO";
                        break;
                    case 12:
                        operacion = "SIN ACCESO";

                        break;
                    case 13:
                        operacion = "SIN ACCESO";

                        break;
                    case 14:
                        operacion = "SIN ACCESO";
                        break;
                    case 15:
                        operacion = "SIN ACCESO";
                        break;
                    case 16:
                        operacion = "SIN ACCESO";
                        break;
                    case 17:
                        operacion = "SIN ACCESO";
                        break;
                    case 18:
                        operacion = "SIN ACCESO";
                        break;
                    case 19:
                        operacion = "SIN ACCESO";

                        break;
                    case 20:
                        operacion = "SIN ACCESO";

                        break;
                    case 21:
                        operacion = "SIN ACCESO";
                        break;
                    case 22:
                        operacion = "SIN ACCESO";
                        break;
                    case 23:
                        operacion = "SIN ACCESO";

                        break;
                    case 24:
                        operacion = "SIN ACCESO";

                        break;
                    case 25:
                        operacion = "SIN ACCESO";

                        break;
                    case 26:
                        operacion = "SIN ACCESO";
                        break;
                    case 27:
                        operacion = "SIN ACCESO";
                        break;
                    case 28:
                        operacion = "SIN ACCESO";
                        break;
                    case 29:
                        operacion = "SIN ACCESO";
                        break;
                    case 30:
                        operacion = "SIN ACCESO";
                        break;
                    case 31:
                        operacion = "SIN ACCESO";
                        break;
                    case 32:
                        operacion = "SIN ACCESO";
                        break;
                }
                try
                {
                    CONEXIONMAESTRA.abrir();
                    SqlCommand cmd = new SqlCommand("insertarOperaciones", CONEXIONMAESTRA.conectar);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Operacion", operacion);
                    cmd.Parameters.AddWithValue("@idModulo", i);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                CONEXIONMAESTRA.cerrar();

            }
        }
        public void insertarModulos()
        {
            List<string> listaModulos = new List<string>()
                {        "Impuestos",
                        "Descuentos",
                        "Ventas",
                        "Reportes",
                        "Configuracion",
                        "Clientes",
                        "Productos",
                        "Empresa",
                        "Proveedores",
                        "Cajas",
                        "Serializacion",
                        "Categorias",
                        "Almacen",
                        "Comprobantes",
                        "Impresoras",
                        "Notificaciones",
                        "BackUp",
                        "Inventarios",
                        "Cotizacion",
                        "Compras",
                        "Ingresos",
                        "Egresos",
                        "Cerrar turno",
                        "Cobros creditos clientes",
                        "PanelButtomVentas",
                        "Dashboard",
                        "Usuarios",
                        "Empleados",
                        "Unidades",
                        "Proveedores",
                        "Vehiculos",
                        "Roles"
            };

            foreach (string modulo in listaModulos)
            {
                try
                {
                    CONEXIONMAESTRA.abrir();
                    SqlCommand cmd = new SqlCommand("insertarModulos", CONEXIONMAESTRA.conectar);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Modulo", modulo);
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    CONEXIONMAESTRA.cerrar();
                }
            }
        }

        public void insertarRol()
        {


            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarRol", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", "Administrador(Control total)");
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarRol", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", "Cajero(Si esta autorizado para manejar dinero)");
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarRol", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", "Solo facturas(no esta autorizado para manejar dinero)");
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }

        public void insertar_clientes()
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertar_clientes", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPersona", 1);
                cmd.Parameters.AddWithValue("@IdentificadorFiscal", "-");
                cmd.Parameters.AddWithValue("@Estado", "0");
                cmd.Parameters.AddWithValue("@Saldo", 0);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }

        #region Insertar Correo Stored Procedure
        public void IngresarCorreoEmpresa()
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarCorreo", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@correo", "Generico");
                cmd.Parameters.AddWithValue("@TipoCorreo", "Generico");
                cmd.ExecuteNonQuery();


            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }

            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarCorreo", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@correo", txtcorreo.Text);
                cmd.Parameters.AddWithValue("@TipoCorreo", "Correo empresarial");
                cmd.ExecuteNonQuery();
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }
        #endregion

        public void editarCorreoEmpresa()
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("editar_correo", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCorreo", idCorreoEditar);
                cmd.Parameters.AddWithValue("@correo", txtcorreo.Text);
                cmd.ExecuteNonQuery();
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        private void Ingresar_Persona()
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarPersona", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", "Generico");
                cmd.Parameters.AddWithValue("@apellido", "-");
                cmd.Parameters.AddWithValue("@fechaNacimiento", DateTime.Now);
                cmd.Parameters.AddWithValue("@idDireccion", "1");
                cmd.Parameters.AddWithValue("@idDocumento", "1");
                cmd.Parameters.AddWithValue("@idTelefono", "1");
                cmd.Parameters.AddWithValue("@idCorreo ", "1");

                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.cerrar();

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }

            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarPersona", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", "Administrador");
                cmd.Parameters.AddWithValue("@apellido", "-");
                cmd.Parameters.AddWithValue("@fechaNacimiento", DateTime.Now);
                cmd.Parameters.AddWithValue("@idDireccion", "1");
                cmd.Parameters.AddWithValue("@idDocumento", "1");
                cmd.Parameters.AddWithValue("@idTelefono", "1");
                cmd.Parameters.AddWithValue("@idCorreo ", "2");

                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.cerrar();

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }
        public void insertarTipoTelefono()
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarTipoTelefono", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TipoTelefono", "Generico");
                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.cerrar();

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }

            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarTipoTelefono", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TipoTelefono", "Telefono Empresarial");
                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.cerrar();

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }


            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarTipoTelefono", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TipoTelefono", "Celular Empresarial");
                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.cerrar();

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }

        }
        public void insertarHorario()
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarHorario", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@HoraEntrada", 7);
                cmd.Parameters.AddWithValue("@HoraSalida", 12);
                cmd.Parameters.AddWithValue("@TipoHorario", 1);
                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.cerrar();

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }
        public void InsertarDocumento()
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarDocumento", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TipoDocumento", "Generico");
                cmd.Parameters.AddWithValue("@numeracion", "-");
                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.cerrar();

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);

            }
        }

        public void insertarEmpleado()
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarEmpleados", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPersona", 1);
                cmd.Parameters.AddWithValue("@idHorario", 1);
                cmd.Parameters.AddWithValue("@cuentaBanco", "-");
                cmd.Parameters.AddWithValue("@departamento", "DEPARTAMENTO DE VENTAS");
                cmd.Parameters.AddWithValue("@banco", "-");
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                ImagenEmpresa.Image.Save(ms, ImagenEmpresa.Image.RawFormat);
                cmd.Parameters.AddWithValue("@icono", ms.GetBuffer());
                cmd.Parameters.AddWithValue("@estado", "ACTIVO");
                cmd.Parameters.AddWithValue("@idEmpresa", 1);
                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.cerrar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarEmpleados", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPersona", 2);
                cmd.Parameters.AddWithValue("@idHorario", 1);
                cmd.Parameters.AddWithValue("@cuentaBanco", "-");
                cmd.Parameters.AddWithValue("@departamento", "DEPARTAMENTO DE VENTAS");
                cmd.Parameters.AddWithValue("@banco", "-");
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                ImagenEmpresa.Image.Save(ms, ImagenEmpresa.Image.RawFormat);
                cmd.Parameters.AddWithValue("@icono", ms.GetBuffer());
                cmd.Parameters.AddWithValue("@estado", "ACTIVO");
                cmd.Parameters.AddWithValue("@idEmpresa", 1);
                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.cerrar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }
        public void insertarTipoHorario()
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarTipoHorario", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TipoHorario", "Generico");
                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.cerrar();

            }
            catch (Exception EX)
            {

                MessageBox.Show(EX.Message);

            }
        }

        public void insertarDireccion()
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarDireccion", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", "Generico");
                cmd.Parameters.AddWithValue("@idRegion", "1");
                cmd.Parameters.AddWithValue("@idMunicipio", "1");
                cmd.Parameters.AddWithValue("@idSector", "1");
                cmd.Parameters.AddWithValue("@idProvincia", "1");
                cmd.Parameters.AddWithValue("@idCalle", "1");
                cmd.Parameters.AddWithValue("@idCiudad", "1");
                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.cerrar();

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        public void insertarDescuento()
        {


            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarDescuento", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Descuento", 0.00);
                cmd.Parameters.AddWithValue("@TipoDescuento", "Descuento Producto");
                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarDescuento", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Descuento", 0.00);
                cmd.Parameters.AddWithValue("@TipoDescuento", "Descuento Categoria");
                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void InsertarCategoria()
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarCategoria", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idDescuento", 2);
                cmd.Parameters.AddWithValue("@idItbis", 2);
                cmd.Parameters.AddWithValue("@descripcion", "Generico");
                cmd.Parameters.AddWithValue("@departamento", "Generico");
                cmd.Parameters.AddWithValue("@estado", "Activo");
                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.cerrar();

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        public void insertarCalle()
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertar_calle", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", "Generico");
                cmd.ExecuteNonQuery();

                SqlCommand cmd_ = new SqlCommand("insertar_calle", CONEXIONMAESTRA.conectar);
                cmd_.CommandType = CommandType.StoredProcedure;
                cmd_.Parameters.AddWithValue("@descripcion", txtCalle.Text);
                cmd_.ExecuteNonQuery();
                CONEXIONMAESTRA.cerrar();

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        public void editarCalle()
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("editarCalle", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCalle", idCalle);
                cmd.Parameters.AddWithValue("@descripcion", txtCalle.Text);
                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.cerrar();

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }
        public void insertarCiudad()
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarCiudad", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", "Generico");
                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.cerrar();

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }

            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarCiudad", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", txtCiudad.Text);
                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.cerrar();

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        public void editarCiudad()
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("editarCiudad", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCiudad", idCiudad);
                cmd.Parameters.AddWithValue("@ciudad", txtCiudad.Text);
                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        public void insertarProvincia()
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertar_provincia", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", "Generico");
                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.cerrar();

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }
        public void insertarMunicipio()
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertar_municipio", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", "Generico");
                cmd.ExecuteNonQuery();

                SqlCommand cmd_ = new SqlCommand("insertar_municipio", CONEXIONMAESTRA.conectar);
                cmd_.CommandType = CommandType.StoredProcedure;
                cmd_.Parameters.AddWithValue("@descripcion", txtMunicipio.Text);
                cmd_.ExecuteNonQuery();
                CONEXIONMAESTRA.cerrar();

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);

            }
        }
        public void editarMunicipio()
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd_ = new SqlCommand("Editarmunicipio", CONEXIONMAESTRA.conectar);
                cmd_.CommandType = CommandType.StoredProcedure;
                cmd_.Parameters.AddWithValue("@idMunicipio", idMunicipio);
                cmd_.Parameters.AddWithValue("@descripcion", txtMunicipio.Text);
                cmd_.ExecuteNonQuery();
                CONEXIONMAESTRA.cerrar();

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);

            }
        }
        public void insertarSector()
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertar_sector", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", "Generico");
                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.cerrar();

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);

            }
        }

        public void insertarRegion()
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertar_region", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", "Generico");
                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.cerrar();

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);

            }
        }

        public void insertarUnidadesCompra()
        {
            LUnidadesMedida parametros = new LUnidadesMedida();
            Insertar_datos insertar = new Insertar_datos();

            parametros.Clave = "H87";
            parametros.descripcion = "Unidad de conteo que define el numero de piezas";
            parametros.nombre = "Pieza (pza)";

            insertar.insertarClavesSat(parametros);

            parametros.Clave = "KGM";
            parametros.descripcion = "Una unidad de masa igual a mil gramos";
            parametros.nombre = "Kilogramo (kg)";

            insertar.insertarClavesSat(parametros);

            parametros.Clave = "MTR";
            parametros.descripcion = "El metro (Simbolo m) es la principal unidad de logitud del sistema";
            parametros.nombre = "Metro (m)";

            insertar.insertarClavesSat(parametros);

            parametros.Clave = "CMT";
            parametros.descripcion = "Una unidad de longitud. Es el segundo submultiplo del metro";
            parametros.nombre = "Centímetro (cm)";

            insertar.insertarClavesSat(parametros);

            parametros.Clave = "INH";
            parametros.descripcion = "Una unidad de longitud antropométrica que equivale al ancho de la primera falange del pulgar";
            parametros.nombre = "Pulgada (plg)";

            insertar.insertarClavesSat(parametros);

            parametros.Clave = "FOT";
            parametros.descripcion = "Una unidad de longitud en los sistemas de medida anglosajones";
            parametros.nombre = "Pie (pe)";

            insertar.insertarClavesSat(parametros);

            parametros.Clave = "YRD";
            parametros.descripcion = "Una unidad de medida de longitud del sistema inglés que equivale a 91,4 centímetros.";
            parametros.nombre = "Yarda (yd)";

            insertar.insertarClavesSat(parametros);

            parametros.Clave = "SMI";
            parametros.descripcion = "Lo habitual es que se trate de una unidad de longitud que equivale a 1609 metros";
            parametros.nombre = "Milla (mi)";

            insertar.insertarClavesSat(parametros);

            parametros.Clave = "MTK";
            parametros.descripcion = "Medida de longitud, especialmente utilizada por el Sistema internacional de unidades";
            parametros.nombre = "Métro cuadrado (m2)";

            insertar.insertarClavesSat(parametros);

            parametros.Clave = "CMK";
            parametros.descripcion = "Una unidad básica de superficie en el Sistema internacional unidades";
            parametros.nombre = "Centimetro cuadrado (cm2)";

            insertar.insertarClavesSat(parametros);

            parametros.Clave = "MTQ";
            parametros.descripcion = "Una unidad sinonimo de Métro Cúbico";
            parametros.nombre = "Métro cubico (m3)";

            insertar.insertarClavesSat(parametros);

            parametros.Clave = "LTR";
            parametros.descripcion = "Una unidad de de volumen equivalente a un decímetro cúbico (1 dm3)";
            parametros.nombre = "Litro (lt)";

            insertar.insertarClavesSat(parametros);

            parametros.Clave = "GLI";
            parametros.descripcion = "Es una unidad de volumen que se emplea en los países anglófonos (especialmente Estados Unidos)";
            parametros.nombre = "Galón (UK)";

            insertar.insertarClavesSat(parametros);

            parametros.Clave = "CJA";
            parametros.descripcion = "Objeto utilizado para representar la compra o venta de cajas x producto";
            parametros.nombre = "CAJA";

            insertar.insertarClavesSat(parametros);

            parametros.Clave = "UND";
            parametros.descripcion = "Unidad de compra\venta que se utiliza para vender o comprar por unidad";
            parametros.nombre = "UNIDAD";

            insertar.insertarClavesSat(parametros);
        }
        public void insertarTelefono()
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarTelefono", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Telefono", "Generico");
                cmd.Parameters.AddWithValue("@idTipoTelefono", "1");
                cmd.ExecuteNonQuery();

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarTelefono", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Telefono", txtTelefono);
                cmd.Parameters.AddWithValue("@idTipoTelefono", 2);
                cmd.ExecuteNonQuery();

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }

            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarTelefono", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Telefono", txtCelular);
                cmd.Parameters.AddWithValue("@idTipoTelefono", 3);
                cmd.ExecuteNonQuery();

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }
        public void editarTelefono()
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("editarTelefono_", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idTelefono", idTelefono);
                cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                cmd.ExecuteNonQuery();
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }

            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("editarTelefono_", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idTelefono", idCelular);
                cmd.Parameters.AddWithValue("@Telefono", txtCelular.Text);
                cmd.ExecuteNonQuery();

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        public int idCorreo;
        public int idDireccion;
        public int idDatosFiscales;

        private void obtenerids()
        {
            CONEXIONMAESTRA.abrir();
            SqlCommand da = new SqlCommand("Select idCorreo from Correos where TipoCorreo = 'Correo empresarial'", CONEXIONMAESTRA.conectar);
            idCorreo = Convert.ToInt32(da.ExecuteScalar());

            SqlCommand da_ = new SqlCommand("Select idDireccion from Direccion where Descripcion = 'Direccion empresarial'", CONEXIONMAESTRA.conectar);
            idDireccion = Convert.ToInt32(da_.ExecuteScalar());

            SqlCommand da__ = new SqlCommand("Select idDatosFiscales from DatosFiscales", CONEXIONMAESTRA.conectar);
            idDatosFiscales = Convert.ToInt32(da__.ExecuteScalar());
            CONEXIONMAESTRA.cerrar();
        }

        private void Ingresar_empresa()
        {
            obtenerids();
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();

                cmd = new SqlCommand("insertarEmpresa", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nombre_Empresa", txtempresa.Text);
                cmd.Parameters.AddWithValue("@Moneda", txtmoneda.Text);
                cmd.Parameters.AddWithValue("@Carpeta_para_copias_de_seguridad", txtRuta.Text);
                cmd.Parameters.AddWithValue("@Ultima_fecha_de_copia_de_seguridad", "Ninguna");
                cmd.Parameters.AddWithValue("@Ultima_fecha_de_copia_date", txtfecha.Value);
                cmd.Parameters.AddWithValue("@idCorreo", idCorreo);
                cmd.Parameters.AddWithValue("@idDireccion", idDireccion);
                cmd.Parameters.AddWithValue("@idDatosFiscales", idDatosFiscales);
                cmd.Parameters.AddWithValue("@Frecuencia_de_copias", 1);
                if (TXTCON_LECTORA.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@Modo_de_busqueda", "LECTORA");
                }
                if (txtteclado.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@Modo_de_busqueda", "TECLADO");
                }

                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                ImagenEmpresa.Image.Save(ms, ImagenEmpresa.Image.RawFormat);
                cmd.Parameters.AddWithValue("@logo", ms.GetBuffer());
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void editarEmpresa()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();

                cmd = new SqlCommand("editarEmpresa", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idEmpresa", idEmpresa);
                cmd.Parameters.AddWithValue("@Nombre_Empresa", txtempresa.Text);
                cmd.Parameters.AddWithValue("@Moneda", txtmoneda.Text);
                cmd.Parameters.AddWithValue("@Carpeta_para_copias_de_seguridad", txtRuta.Text);
                cmd.Parameters.AddWithValue("@idCorreo", idCorreoEditar);
                cmd.Parameters.AddWithValue("@idDireccion", idDireccionEditar);
                cmd.Parameters.AddWithValue("@idDatosFiscales", idDatosFiscales);
                cmd.Parameters.AddWithValue("@idTelefono", idTelefono);
                cmd.Parameters.AddWithValue("@idCelular", idCelular);
                if (TXTCON_LECTORA.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@Modo_de_busqueda", "LECTORA");
                }
                if (txtteclado.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@Modo_de_busqueda", "TECLADO");
                }
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                ImagenEmpresa.Image.Save(ms, ImagenEmpresa.Image.RawFormat);
                cmd.Parameters.AddWithValue("@logo", ms.GetBuffer());
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void editarDatosFiscales()
        {
            LDatosFiscales DF = new LDatosFiscales();
            Insertar_datos datos = new Insertar_datos();

            DF.idDatosFiscales = idDatosFiscales;
            DF.NombreFiscal = txtNombreFiscal.Text;
            DF.infoAdicional = txtInfoAdicional.Text;
            DF.RegimenFiscal = txtRegimenFiscal.Text;
            DF.RNC = txtRNC.Text;
            DF.NoFiscal = txtNoFiscal.Text;
            DF.CodPostal = txtCodPostal.Text;
            DF.Localidad = txtLocalidadF.Text;
            DF.Domicilio = txtDomicilioF.Text;
            DF.NoInt = txtInterno.Text;
            DF.NoExt = txtExt.Text;
            DF.CDL = txtCedula.Text;
            DF.Provincia = txtProvinciaF.Text;
            DF.Ciudad = txtCiudadF.Text;

            if (datos.editarDatosFiscales(DF) == true)
            {
            }
        }
        private void ingresarDatosFiscales()
        {
            LDatosFiscales DF = new LDatosFiscales();
            Insertar_datos datos = new Insertar_datos();

            DF.NombreFiscal = txtNombreFiscal.Text;
            DF.infoAdicional = txtInfoAdicional.Text;
            DF.RegimenFiscal = txtRegimenFiscal.Text;
            DF.RNC = txtRNC.Text;
            DF.NoFiscal = txtNoFiscal.Text;
            DF.CodPostal = txtCodPostal.Text;
            DF.Localidad = txtLocalidadF.Text;
            DF.Domicilio = txtDomicilioF.Text;
            DF.NoInt = txtInterno.Text;
            DF.NoExt = txtExt.Text;
            DF.CDL = txtCedula.Text;
            DF.Provincia = txtProvinciaF.Text;
            DF.Ciudad = txtCiudadF.Text;

            if (datos.insertarDatosFiscales(DF) == true)
            {

            }
        }
        public void IngresarDireccionEmpresa()
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarDireccion", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", "Direccion empresarial");
                cmd.Parameters.AddWithValue("@idRegion", "1");
                cmd.Parameters.AddWithValue("@idMunicipio", "2");
                cmd.Parameters.AddWithValue("@idSector", "1");
                cmd.Parameters.AddWithValue("@idProvincia", "1");
                cmd.Parameters.AddWithValue("@idCalle", "2");
                cmd.Parameters.AddWithValue("@idCiudad", "2");
                cmd.ExecuteNonQuery();
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        private void TXTCON_LECTORA_CheckedChanged(object sender, EventArgs e)
        {
            if (TXTCON_LECTORA.Checked == true)
            {
                txtteclado.Checked = false;
            }
            if (TXTCON_LECTORA.Checked == false)
            {
                txtteclado.Checked = true;
            }
        }

        private void txtteclado_CheckedChanged(object sender, EventArgs e)
        {
            if (txtteclado.Checked == true)
            {
                TXTCON_LECTORA.Checked = false;
            }
            if (txtteclado.Checked == false)
            {
                TXTCON_LECTORA.Checked = true;
            }
        }

        private void TXTPAIS_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtmoneda.SelectedIndex = TXTPAIS.SelectedIndex;

        }

        private void txtmoneda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbleditarLogo_Click(object sender, EventArgs e)
        {
            dlg.InitialDirectory = "";
            dlg.Filter = "Imagenes|*.jpg;*.png";
            dlg.FilterIndex = 2;
            dlg.Title = "";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ImagenEmpresa.BackgroundImage = null;
                ImagenEmpresa.Image = new Bitmap(dlg.FileName);
                ImagenEmpresa.SizeMode = PictureBoxSizeMode.Zoom;

            }
        }

        private void Label9_Click(object sender, EventArgs e)

        {
            if (FolderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string ruta = txtRuta.Text;
                if (ruta.Contains(@"C:\"))
                {
                    MessageBox.Show("Selecciona un Disco Diferente al Disco C:", "Ruta Invalida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtRuta.Text = "";
                }
                else
                {
                    txtRuta.Text = FolderBrowserDialog1.SelectedPath;
                }


            }

        }

        private void ToolStripButton22_Click(object sender, EventArgs e)
        {
            if (FolderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtRuta.Text = FolderBrowserDialog1.SelectedPath;
                string ruta = txtRuta.Text;
                if (ruta.Contains(@"C:\"))
                {
                    MessageBox.Show("Selecciona un Disco Diferente al Disco C:", "Ruta Invalida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtRuta.Text = "";
                }
                else
                {
                    txtRuta.Text = FolderBrowserDialog1.SelectedPath;
                }


            }
        }

        private bool verificar()
        {
            CONEXIONMAESTRA.abrir();
            SqlCommand com = new SqlCommand("verificarEmpresa", CONEXIONMAESTRA.conectar);
            com.CommandType = CommandType.StoredProcedure;
            idEmpresa = Convert.ToInt32(com.ExecuteScalar());
            CONEXIONMAESTRA.cerrar();
            if (idEmpresa > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ObtenerDatos()
        {
            DataTable dt = new DataTable();
            Obtener_datos datos = new Obtener_datos();
            datos.obtenerDatosEmpresa(ref dt);
            tablaEmpresa.DataSource = dt;

            foreach (DataGridViewRow row in tablaEmpresa.SelectedRows)
            {
                ///<summary>
                ///Datos de la Empresa
                /// </summary>
                idEmpresa = Convert.ToInt32(row.Cells["id_empresa"].Value.ToString());
                LBLIDEMPRESA.Text = row.Cells["id_empresa"].Value.ToString();
                txtempresa.Text = row.Cells["Nombre_Empresa"].Value.ToString();
                ImagenEmpresa.BackgroundImage = null;
                byte[] b = (Byte[])row.Cells["Logo"].Value;
                MemoryStream ms = new MemoryStream(b);
                ImagenEmpresa.Image = Image.FromStream(ms);
                txtmoneda.Text = row.Cells["Moneda"].Value.ToString();
                string modo_busqueda;
                modo_busqueda = row.Cells["modo_de_busqueda"].Value.ToString();
                if (modo_busqueda.Equals("TECLADO"))
                {
                    txtteclado.Checked = true;
                    TXTCON_LECTORA.Checked = false;
                }
                else
                {
                    txtteclado.Checked = true;
                    TXTCON_LECTORA.Checked = false;
                }
                txtRuta.Text = row.Cells["Carpeta_para_copias_de_seguridad"].Value.ToString();
                idCorreoEditar = Convert.ToInt32(row.Cells["idCorreo"].Value.ToString());
                idDireccionEditar = Convert.ToInt32(row.Cells["idDireccionE"].Value.ToString());
                idDatosFiscales = Convert.ToInt32(row.Cells["idDatosFiscales"].Value.ToString());
                idCalle = Convert.ToInt32(row.Cells["idCalle"].Value.ToString());
                idMunicipio = Convert.ToInt32(row.Cells["idMunicipio"].Value.ToString());
                idCiudad = Convert.ToInt32(row.Cells["idCiudadE"].Value.ToString());
                txtCalle.Text = (row.Cells["Calle"].Value.ToString());
                txtCiudad.Text = (row.Cells["CiudadE"].Value.ToString());
                txtMunicipio.Text = (row.Cells["Municipio"].Value.ToString());
                ///<summary>
                ///Datos Fiscales
                ///</summary>
                txtNombreFiscal.Text = (row.Cells["NombreFiscal"].Value.ToString());
                txtInfoAdicional.Text = (row.Cells["InfoAdicional"].Value.ToString());
                txtRegimenFiscal.Text = (row.Cells["RegimenFiscal"].Value.ToString());
                txtRNC.Text = (row.Cells["RNC"].Value.ToString());
                txtNoFiscal.Text = (row.Cells["NoFiscal"].Value.ToString());
                txtCodPostal.Text = (row.Cells["CodPostal"].Value.ToString());
                txtLocalidadF.Text = (row.Cells["Localidad"].Value.ToString());
                txtDomicilioF.Text = (row.Cells["Domicilio"].Value.ToString());
                txtInterno.Text = (row.Cells["NoInt"].Value.ToString());
                txtExt.Text = (row.Cells["NoExt"].Value.ToString());
                txtCedula.Text = (row.Cells["CDL"].Value.ToString());
                txtProvinciaF.Text = (row.Cells["Provincia"].Value.ToString());
                txtCiudadF.Text = (row.Cells["Ciudad"].Value.ToString());
                txtcorreo.Text = (row.Cells["Correo"].Value.ToString());
                txtTelefono.Text = (row.Cells["Telefono"].Value.ToString());
                idTelefono = Convert.ToInt32(row.Cells["idTelefono"].Value.ToString());
                idCelular = Convert.ToInt32(row.Cells["idCelular"].Value.ToString());
                txtCelular.Text = (row.Cells["Celular"].Value.ToString());
            }
        }

        private void REGISTRO_DE_EMPRESA_Load(object sender, EventArgs e)
        {
            //El label 44 es para las direcciones(CLICK EVENT)
            label44.Visible = false;
            TXTPAIS.Text = "República Dominicana";
            //lbl1 es el label de la Caja
            lbl1.Visible = false;
            //panel5 panel impuestos
            panel5.Enabled = false;

            Bases.Obtener_serialPC(ref lblIDSERIAL);
            if (verificar() == true)
            {
                label44.Visible = true;
                txtcaja.Enabled = false;
                lbl1.Visible = true;
                ObtenerDatos();
                panelVDatosFiscales.Visible = false;
                btnSiguiente.Visible = false;
            }
            else
            {
                panel5.Enabled = true;
                panelInfoBasica.Enabled = false;
                panelInfoBasicaDetalle.Enabled = false;
                Salir.Enabled = false;
                TXTPAIS.SelectedIndex = 0;
                txtPorcentaje.SelectedIndex = 0;
                txtImpuesto.SelectedIndex = 0;
                txtmoneda.SelectedIndex = 0;

                Panel16.Location = new Point((Width - Panel16.Width) / 2, (Height - Panel16.Height) / 2);
                TXTCON_LECTORA.Checked = true;
                txtteclado.Checked = false;
                no.Checked = true;
                if (no.Checked)
                {
                    panelImpuestos.Visible = false;
                }
            }

        }

        private void si_CheckedChanged(object sender, EventArgs e)
        {
            panelImpuestos.Visible = true;
        }

        private void no_CheckedChanged(object sender, EventArgs e)
        {
            panelImpuestos.Visible = false;

        }

        private void Salir_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void Restaurar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            Restaurar.Visible = false;
            Maximizar.Visible = true;
        }

        private void Maximizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            Maximizar.Visible = false;
            Restaurar.Visible = true;
        }

        private void Minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (RegistroInformacionAdicional == true)
            {
                if (txtRNC.Text.Length > 4)
                {
                    if (txtCodPostal.Text.Length == 5)
                    {
                        if (txtCedula.Text.Length == 12)
                        {
                            RegistrarEmpresa();
                        }
                        else
                        {
                            MessageBox.Show("Cedula no válida, la cedula debe tener el formato: xxx-xxxxxx-x," +
                                " " + " por favor seleccione una cedula valida", "Validación de cedula", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Código postal no válido, el Cod.Postal debe tener el formato: xxxxx, " + " por favor digite un Código postal válido",
                            "Validación de Código postal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("R.N.C no válido, el R.N.C debe tener 9 digitos, " + " por favor digite un R.N.C válido",
                        "Validación de R.N.C ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                RegistrarEmpresa();
            }
        }
       private void RegistrarEmpresa()
        {
            if (txtTelefono.Text.Length == 12)
            {
                if (validar_Mail(txtcorreo.Text) == false)
                {
                    MessageBox.Show("Dirección de correo electronico no valida, el correo debe tener el formato: nombre@dominio.com, " + " por favor seleccione un correo valido", "Validación de correo electronico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtcorreo.Focus();
                    txtcorreo.SelectAll();
                }
                else
                {
                    TextBox[] array_;
                    // Utilizo v para la verificacion del los campos a verificar
                    if (RegistroInformacionAdicional == true)
                    {
                        TextBox[] array = { txtempresa, txtcaja, txtCalle, txtCedula, txtTelefono, txtCelular, txtMunicipio,
                        txtCiudad, txtCiudadF, txtNombreFiscal,txtRNC, txtRegimenFiscal, txtInfoAdicional, txtInterno,
                        txtExt, txtProvinciaF, txtLocalidadF, txtDomicilioF, txtCiudad, txtCodPostal, txtNoFiscal};
                        array_ = array;
                    }
                    else
                    {
                        TextBox[] array = { txtempresa, txtcaja, txtCalle, txtTelefono, txtCelular, txtMunicipio, txtDomicilioF, txtCiudad };
                        array_ = array;

                    }

                    if (Insertar_datos.ValidTextIsNotNullOrEmpty(array_))
                    {
                        if (no.Checked)
                        {
                            TXTTRABAJASCONIMPUESTOS.Text = "NO";
                            insertarImpuestoGenerico();
                        }
                        if (si.Checked)
                        {
                            TXTTRABAJASCONIMPUESTOS.Text = "SI";
                            insertarImpuesto();
                        }

                        //Direcciones
                        insertarCalle();
                        insertarMunicipio();
                        insertarCiudad();
                        IngresarCorreoEmpresa();

                        insertarRegion();
                        insertarSector();
                        insertarProvincia();

                        //insertarDireccion
                        insertarDireccion();
                        IngresarDireccionEmpresa();
                        ingresarDatosFiscales();

                        Ingresar_empresa();

                        Ingresar_caja();

                        insertar_3_COMPROBANTES_POR_DEFECTO();

                        insertarTipoHorario();
                        insertarTipoTelefono();
                        insertarTelefono();
                        insertarHorario();
                        InsertarDocumento();
                        insertarDescuento();
                        InsertarCategoria();


                        Ingresar_Persona();
                        insertarEmpleado();
                        insertar_clientes();
                        insertar_Proveedores();

                        insertarRol();
                        insertarModulos();
                        insertarPermisos();
                        permisosrolfactura();
                        insertarPermisosRol();
                        insertarUnidadesCompra();
                        insertarUnidadEstandar();
                        correo = txtcorreo.Text;
                        Dispose();
                        USUARIOS_AUTORIZADOS_AL_SISTEMA frm = new USUARIOS_AUTORIZADOS_AL_SISTEMA();
                        frm.ShowDialog();
                    }
                }
            }
            else
            {
                MessageBox.Show("Telefono no válido, el Telefono debe tener el formato: 809-555-5555, " + " por favor digite un telefono válido",
                    "Validación de Telefono", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void panelInformacion_Paint(object sender, PaintEventArgs e)
        {



        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            panelVDatosFiscales.Visible = false;
            DatosFiscalesPanel.Enabled = true;
            RegistroInformacionAdicional = true;

            panelInfoBasica.Enabled = true;
            panelInfoBasicaDetalle.Enabled = true;
        }

        private void btnno_Click(object sender, EventArgs e)
        {
            panelVDatosFiscales.Visible = false;
            DatosFiscalesPanel.Enabled = false;
            RegistroInformacionAdicional = false;

            panelInfoBasica.Enabled = true;
            panelInfoBasicaDetalle.Enabled = true;
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txtCedula, e);
        }

        private void panelVDatosFiscales_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label19_Click(object sender, EventArgs e)
        {
            Presentacion.CAJA.Cajas_form frm = new CAJA.Cajas_form();
            frm.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            if (RegistroInformacionAdicional == true)
            {
                if (txtRNC.Text.Length > 4)
                {
                    if (txtCodPostal.Text.Length == 5)
                    {
                        if (txtCedula.Text.Length == 12)
                        {
                            RegistrarEmpresa();
                        }
                        else
                        {
                            MessageBox.Show("Cedula no válida, la cedula debe tener el formato: xxx-xxxxxx-x," +
                                " " + " por favor seleccione una cedula valida", "Validación de cedula", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Código postal no válido, el Cod.Postal debe tener el formato: xxxxx, " + " por favor digite un Código postal válido",
                            "Validación de Código postal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("R.N.C no válido, el R.N.C debe tener 9 digitos, " + " por favor digite un R.N.C válido",
                        "Validación de R.N.C ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                EditarEmpresa();
            }
        }

        private void EditarEmpresa()
        {
            if (txtTelefono.Text.Length == 12)
            {
                if (validar_Mail(txtcorreo.Text) == false)
                {
                    MessageBox.Show("Dirección de correo electronico no valida, el correo debe tener el formato: nombre@dominio.com, " + " por favor seleccione un correo valido", "Validación de correo electronico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtcorreo.Focus();
                    txtcorreo.SelectAll();
                }
                else
                {
                    // Utilizo v para la verificacion del los campos a verificar
                    TextBox[] array = { txtempresa, txtCalle, txtCedula, txtTelefono, txtCelular, txtMunicipio,
                        txtCiudad, txtCiudadF, txtNombreFiscal,txtRNC, txtRegimenFiscal, txtInfoAdicional, txtInterno,
                        txtExt, txtProvinciaF, txtLocalidadF, txtDomicilioF, txtCiudad, txtCodPostal, txtNoFiscal};
                    if (Insertar_datos.ValidTextIsNotNullOrEmpty(array))
                    {
                        //Direcciones
                        editarCalle();
                        editarMunicipio();
                        editarCiudad();
                        editarCorreoEmpresa();
                        editarTelefono();

                        editarDatosFiscales();
                        editarEmpresa();

                    }
                }
            }
            else
            {
                MessageBox.Show("Telefono no válido, el Telefono debe tener el formato: 809-555-5555, " + " por favor digite un telefono válido",
                    "Validación de Telefono", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void label44_Click(object sender, EventArgs e)
        {
            Direccion.Direcciones frm = new Direccion.Direcciones();
            frm.ShowDialog();
        }
    }
}