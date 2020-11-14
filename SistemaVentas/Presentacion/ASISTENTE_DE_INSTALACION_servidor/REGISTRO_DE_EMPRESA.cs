﻿using System;
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
namespace SistemaVentas.Presentacion.ASISTENTE_DE_INSTALACION_servidor
{
    public partial class REGISTRO_DE_EMPRESA : Form
    {
        public REGISTRO_DE_EMPRESA()
        {
            InitializeComponent();
        }
        string lblIDSERIAL;
        private void Panel6_Paint(object sender, PaintEventArgs e)
        {

        }
        public static string correo;
        public bool validar_Mail(string sMail)
        {
            return Regex.IsMatch(sMail, @"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$");

        }
        private void TSIGUIENTE_Y_GUARDAR__Click(object sender, EventArgs e)
        {
            if (validar_Mail(txtcorreo.Text) == false)
            {
                MessageBox.Show("Dirección de correo electronico no valida, el correo debe tener el formato: nombre@dominio.com, " + " por favor seleccione un correo valido", "Validación de correo electronico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtcorreo.Focus();
                txtcorreo.SelectAll();
            }
            else
            {

                if (txtempresa.Text != "")
                {
                    if (txtRuta.Text != "")
                    {
                        if (no.Checked == true)
                        {
                            TXTTRABAJASCONIMPUESTOS.Text = "NO";
                        }
                        if (si.Checked == true)
                        {
                            TXTTRABAJASCONIMPUESTOS.Text = "SI";
                        }
                        Ingresar_empresa();
                        Ingresar_caja();
                        insertar_3_COMPROBANTES_POR_DEFECTO();
                        insertarTipoHorario();
                        insertarTipoTelefono();
                        insertarTelefono();
                        insertarMunicipio();
                        insertarHorario();
                        insertarCalle();
                        insertarProvincia();
                        insertarRegion();
                        insertarSector();
                        InsertarDocumento();
                        insertarDireccion();
                        insertarImpuesto();
                        insertarDescuento();
                        InsertarCategoria();
                        Ingresar_Persona();
                        insertarEmpleado();
                        insertar_clientes();
                        insertar_Proveedores();
                        correo = txtcorreo.Text;
                        Dispose();

                        Presentacion.Empleados.EmpleadosOK frm1 = new Presentacion.Empleados.EmpleadosOK();
                        frm1.ShowDialog();
                        USUARIOS_AUTORIZADOS_AL_SISTEMA frm = new USUARIOS_AUTORIZADOS_AL_SISTEMA();
                        frm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Seleccione una Ruta para Guardar las Copias de Seguridad", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {
                    MessageBox.Show("Ingrese un Nombre de Empresa", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }


              
        }
        public void insertarImpuesto()
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarImpuestosgeneral", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", "Ventas");
                cmd.Parameters.AddWithValue("@Impuesto", 18/100);
                cmd.Parameters.AddWithValue("@Tipo", "IVA");
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
                cmd.Parameters.AddWithValue("@Impuesto", 18 / 100);
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
                cmd.Parameters.AddWithValue("@Impuesto", 18 / 100);
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
                cmd.Parameters.AddWithValue("@Destino", "FACTURAS");
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
                cmd.Parameters.AddWithValue("@Destino", "FACTURAS");
                cmd.Parameters.AddWithValue("@Por_defecto", "-");
                cmd.ExecuteNonQuery();
                con.Close();

                con.Open();
                cmd = new SqlCommand("insertar_Serializacion", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Serie", "F");
                cmd.Parameters.AddWithValue("@numeroinicio", 6);
                cmd.Parameters.AddWithValue("@numerofin", 0);
                cmd.Parameters.AddWithValue("@tipodoc", "FACTURA");
                cmd.Parameters.AddWithValue("@Destino", "FACTURAS");
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
                pass= Bases.Encriptar("-");
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
        public void insertar_Proveedores( )
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

        public bool insertar_clientes()
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
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
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
                cmd.Parameters.AddWithValue("@Correo", "-");
                cmd.Parameters.AddWithValue("@fechaNacimiento", DateTime.Now);
                cmd.Parameters.AddWithValue("@idDireccion", "1");
                cmd.Parameters.AddWithValue("@idDocumento", "1");
                cmd.Parameters.AddWithValue("@idTelefono", "1");

                cmd.ExecuteNonQuery();
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }
        public void insertarTipoTelefono( )
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarTipoTelefono", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TipoTelefono", "Generico");
                cmd.ExecuteNonQuery();
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }

        }
        public void insertarHorario( )
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

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }
        public void  InsertarDocumento( )
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarDocumento", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TipoDocumento","Generico");
                cmd.Parameters.AddWithValue("@numeracion", "-");
                cmd.ExecuteNonQuery();
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);

            }
        }

        public void insertarEmpleado( )
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarEmpleados", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPersona", 1);
                cmd.Parameters.AddWithValue("@idHorario", 1);
                cmd.Parameters.AddWithValue("@cuentaBanco","-");
                cmd.Parameters.AddWithValue("@departamento", "DEPARTAMENTO DE VENTAS");
                cmd.Parameters.AddWithValue("@banco", "-");
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                ImagenEmpresa.Image.Save(ms, ImagenEmpresa.Image.RawFormat);
                cmd.Parameters.AddWithValue("@icono", ms.GetBuffer());
                cmd.Parameters.AddWithValue("@estado", "ACTIVO");
                cmd.Parameters.AddWithValue("@idEmpresa", 1);
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
        public void insertarTipoHorario( )
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarTipoHorario", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TipoHorario", "Generico");
                cmd.ExecuteNonQuery();
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
                SqlCommand cmd = new SqlCommand("insertar_Direccion", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", "Generico");
                cmd.Parameters.AddWithValue("@idRegion", "1");
                cmd.Parameters.AddWithValue("@idMunicipio", "1");
                cmd.Parameters.AddWithValue("@idSector", "1");
                cmd.Parameters.AddWithValue("@idProvincia", "1");
                cmd.Parameters.AddWithValue("@idCalle", "1");
                cmd.ExecuteNonQuery();
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
                cmd.Parameters.AddWithValue("@TipoDescuento", "Descuento Categoria");
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
                cmd.Parameters.AddWithValue("@TipoDescuento", "Descuento Producto");
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
                cmd.Parameters.AddWithValue("@idDescuento", 1);
                cmd.Parameters.AddWithValue("@idItbis", 1);
                cmd.Parameters.AddWithValue("@descripcion", "Generico");
                cmd.Parameters.AddWithValue("@departamento", "Generico");
                cmd.Parameters.AddWithValue("@estado", "Activo");
                cmd.ExecuteNonQuery();
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        public void  insertarCalle( )
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertar_calle", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", "Generico");
                cmd.ExecuteNonQuery();

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }
        public void insertarProvincia( )
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertar_provincia", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", "Generico");
                cmd.ExecuteNonQuery();
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }
        public void insertarMunicipio( )
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertar_municipio", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", "Generico");
                cmd.ExecuteNonQuery();

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);

            }
        }
        public void insertarSector( )
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertar_sector", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", "Generico");
                cmd.ExecuteNonQuery();

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);

            }
        }

        public void insertarRegion( )
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertar_region", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", "Generico");
                cmd.ExecuteNonQuery();

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
        }
        private void Ingresar_empresa()
        {
            try
            {


                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
              
                cmd = new SqlCommand("insertar_Empresa", con);
              cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nombre_Empresa", txtempresa.Text);
                cmd.Parameters.AddWithValue("@Impuesto", txtimpuesto.Text);
                cmd.Parameters.AddWithValue("@Porcentaje_impuesto", txtporcentaje.Text);
                cmd.Parameters.AddWithValue("@Moneda", txtmoneda.Text);
                cmd.Parameters.AddWithValue("@Trabajas_con_impuestos", TXTTRABAJASCONIMPUESTOS.Text);

                cmd.Parameters.AddWithValue("@Carpeta_para_copias_de_seguridad", txtRuta.Text);
                cmd.Parameters.AddWithValue("@Correo_para_envio_de_reportes", txtcorreo.Text);
                cmd.Parameters.AddWithValue("@Ultima_fecha_de_copia_de_seguridad", "Ninguna");
                cmd.Parameters.AddWithValue("@Ultima_fecha_de_copia_date", txtfecha.Value);
                cmd.Parameters.AddWithValue("@Frecuencia_de_copias", 1);
                cmd.Parameters.AddWithValue("@Estado", "PENDIENTE");
                cmd.Parameters.AddWithValue("@Tipo_de_empresa", "GENERAL");

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
                cmd.Parameters.AddWithValue("@Pais", TXTPAIS.Text);
                cmd.Parameters.AddWithValue("@Redondeo_de_total", "NO");

                cmd.ExecuteNonQuery();
                con.Close();
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TXTCON_LECTORA_CheckedChanged(object sender, EventArgs e)
        {
            if (TXTCON_LECTORA.Checked==true)
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
                ImagenEmpresa .BackgroundImage = null;
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

        private void REGISTRO_DE_EMPRESA_Load(object sender, EventArgs e)
        {
            Bases.Obtener_serialPC(ref lblIDSERIAL);
            Panel16.Location = new Point((Width - Panel16.Width) / 2, (Height - Panel16.Height) / 2);       
            TXTCON_LECTORA.Checked = true;
            txtteclado.Checked = false;
            no.Checked = true;
            Panel11.Visible = false;
            Panel9.Visible = false;


            TSIGUIENTE.Visible = false;
            TSIGUIENTE_Y_GUARDAR.Visible = true;
        }

        private void si_CheckedChanged(object sender, EventArgs e)
        {
            Panel11.Visible = true;
        }

        private void no_CheckedChanged(object sender, EventArgs e)
        {
            Panel11.Visible = false;

        }
    }
 }

