﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Globalization;
using SistemaVentas.Logica;
using SistemaVentas.Presentacion.VENTAS_MENU_PRINCIPAL;
using SistemaVentas.Datos;
using System.Security.Cryptography.X509Certificates;
using SistemaVentas.Presentacion.Admin_nivel_dios;
using System.IO.Ports;
using System.Drawing.Imaging;
using SistemaVentas.Presentacion.Compras_proveedor;
namespace SistemaVentas.Presentacion.VENTAS_MENU_PRINCIPAL
{
    public partial class VENTAS_MENU_PRINCIPALOK : Form
    {
        public VENTAS_MENU_PRINCIPALOK()
        {
            InitializeComponent();
        }

        public static string txtdescripcion;
        double ImpuestoProducto;
        double ImpuestoCategoria;
        double DescuentoCategoria;
        double DescuentoProducto;
        string itbis;
        double descuento;
        int contador_stock_detalle_de_venta;
        int idproducto;
        int idClienteEstandar;
        public static int idusuario_que_inicio_sesion;
        public static int idVenta;
        int iddetalleventa;
        double preciounitario;
        int Contador;
        public static double txtpantalla;
        double lblStock_de_Productos;
        public static double total;
        public static int Id_caja;
        string SerialPC;
        private string unidadVenta;
        string sevendePor;
        public static string txtventagenerada;
        double txtprecio_unitario;
        string usainventarios;
        string ResultadoLicencia;
        string FechaFinal;
        double cantidad;
        string Tema;
        int contadorVentasEspera;
        int contadorCotizacionesEspera;

        string Ip;
        Panel panel_mostrador_de_productos = new Panel();
        public static int idcotizacion;

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void VENTAS_MENU_PRINCIPALOK_Load(object sender, EventArgs e)
        {
            txttotal.Enabled = false;
            PANELGRANEL.Visible = false;
            MOSTRAR_comprobante_serializado_POR_DEFECTO();
            validar_tipos_de_comprobantes();
            Bases.Cambiar_idioma_regional();
            Bases.Obtener_serialPC(ref SerialPC);
            Obtener_datos.Obtener_id_caja_PorSerial(ref Id_caja);
            MOSTRAR_TIPO_DE_BUSQUEDA();
            Obtener_id_de_cliente_estandar();
            Obtener_datos.mostrar_inicio_De_sesion(ref idusuario_que_inicio_sesion);
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("obtenerAccesoUsuarios", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idUsuario", idusuario_que_inicio_sesion);
                da.Fill(dt);
                datalistadousuario.DataSource = dt;
                con.Close();
                datalistadousuario.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (Tipo_de_busqueda == "TECLADO")
            {
                lbltipodebusqueda2.Text = "Buscar con TECLADO";
                BTNLECTORA.BackColor = Color.WhiteSmoke;
                BTNTECLADO.BackColor = Color.LightGreen;
            }
            else
            {
                lbltipodebusqueda2.Text = "Buscar con LECTORA de Codigos de Barras";
                BTNLECTORA.BackColor = Color.LightGreen;
                BTNTECLADO.BackColor = Color.WhiteSmoke;
            }
            ValidarTemaCaja();
            Limpiar_para_venta_nueva();
            ObtenerIpLocal();
            panelNotificacionEspera.Visible = true;

            int idRol;
            string Rol;
            string modulo;
            string Operacion;

            foreach (DataGridViewRow row in datalistadousuario.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario_que_inicio_sesion == idusuarioBuscar)
                {
                    if (modulo == "PanelButtomVentas")
                    {
                        if (Operacion == "ACCESO")
                        {
                            panelC4.Enabled = true;
                        }
                        else
                        {
                            panelC4.Enabled = false;
                        }
                    }
                }

            }

        }

        private void ObtenerIpLocal()
        {

            this.Text = Bases.ObtenerIp(ref Ip);
        } 
        private void ContarVentasEspera()
        {
            Obtener_datos.contarVentasEspera(ref contadorVentasEspera);
            if (contadorVentasEspera == 0)
            {
                panelNotificacionEspera.Visible = false;
            }
            else
            {
                panelNotificacionEspera.Visible = true;
                lblContadorEspera.Text = contadorVentasEspera.ToString();
            }
        }
        private void ContarCotizacionesEnEspera()
        {
            Obtener_datos.contarCotizacionesEspera(ref contadorCotizacionesEspera);
            if (contadorCotizacionesEspera == 0)
            {
                panel3.Visible = false;
            }
            else
            {
                panel3.Visible = true;
                CantidadCotizaciones.Text = contadorCotizacionesEspera.ToString();
            }
        }
        private void ValidarTemaCaja()
        {
            Obtener_datos.mostrarTemaCaja(ref Tema);
            if (Tema == "Redentor")
            {
                TemaClaro();
                IndicadorTema.Checked = false;
            }
            else
            {
                TemaOscuro();
                IndicadorTema.Checked = true;

            }
        }
       

        private void Limpiar_para_venta_nueva()
        {
            idVenta = 0;
            Listarproductosagregados();
            txtventagenerada = "factura NUEVA";
            lblsubtotal.Text = "0.00";
            lbldescuento.Text = "0.00";
            txt_total_suma.Text = "0.00";
            sumarItbis();
            sumar();
            sumar2();
            sumarDescuentos();
            PanelEnespera.Visible = false;
            panelBienvenida.Visible = true;
            PanelOperaciones.Visible = false;
            ContarVentasEspera();
            ContarCotizacionesEnEspera();
        }


        private void sumar()
        {
            try
            {

                int x;
                x = datalistadoDetalleVenta.Rows.Count;
                if (x == 0)
                {
                    txt_total_suma.Text = "0.00";
                    lblItbiss.Text = "0.00";
                    lblsubtotal.Text = "0.00";
                }

                double totalpagar;
                subtotal = 0;
                preciounitario = 0;
                cantidad = 0;
                preciounitario = 0;
                totalpagar = 0;
                foreach (DataGridViewRow fila in datalistadoDetalleVenta.Rows)
                {
                        totalpagar += Convert.ToDouble(fila.Cells["Importe"].Value);
                        txt_total_suma.Text = Convert.ToString(totalpagar + Convert.ToDouble(lblItbiss.Text));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        double subtotal;

        private void sumar2()
        {
            try
            {

                int x;
                x = datalistadoDetalleVenta.Rows.Count;
                if (x == 0)
                {
                    lblsubtotal.Text = "0.00";
                }

                subtotal = 0;
                foreach (DataGridViewRow fila in datalistadoDetalleVenta.Rows)
                {
                    subtotal += Convert.ToDouble(fila.Cells["Importe"].Value);
                    lblsubtotal.Text = Convert.ToString(subtotal);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void sumarItbis()
        {
            try
            {

                int x;
                x = datalistadoDetalleVenta.Rows.Count;
                if (x == 0)
                {
                    lblsubtotal.Text = "0.00";
                }

                subtotal = 0;
                foreach (DataGridViewRow fila in datalistadoDetalleVenta.Rows)
                {
                    subtotal += Convert.ToDouble(fila.Cells["Itbis"].Value);
                    lblItbiss.Text = Convert.ToString(subtotal);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void sumarDescuentos()
        {
            try
            {

                int x;
                x = datalistadoDetalleVenta.Rows.Count;
                if (x == 0)
                {
                    txt_total_suma.Text = "0.00";
                }

                double descuento;
                descuento = 0;
                foreach (DataGridViewRow fila in datalistadoDetalleVenta.Rows)
                {

                    descuento += Convert.ToDouble(fila.Cells["Descuento"].Value);
                    lbldescuento.Text = Convert.ToString(descuento);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        private void LISTAR_PRODUCTOS_Abuscador()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                CONEXION.CONEXIONMAESTRA.abrir();
                da = new SqlDataAdapter("BUSCAR_PRODUCTOS_oka", CONEXION.CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letrab", txtbuscar.Text);
                da.Fill(dt);
                DATALISTADO_PRODUCTOS_OKA.DataSource = dt;
                CONEXION.CONEXIONMAESTRA.cerrar();
                DATALISTADO_PRODUCTOS_OKA.Columns[0].Visible = false;
               DATALISTADO_PRODUCTOS_OKA.Columns[1].Visible = false;
                DATALISTADO_PRODUCTOS_OKA.Columns[2].Width = 600;
                DATALISTADO_PRODUCTOS_OKA.Columns[3].Visible = false;
                DATALISTADO_PRODUCTOS_OKA.Columns[4].Visible = false;
                DATALISTADO_PRODUCTOS_OKA.Columns[5].Visible = false;
                DATALISTADO_PRODUCTOS_OKA.Columns[6].Visible = false;
                DATALISTADO_PRODUCTOS_OKA.Columns[7].Visible = false;
                DATALISTADO_PRODUCTOS_OKA.Columns[8].Visible = false;
                DATALISTADO_PRODUCTOS_OKA.Columns[9].Visible = false;
                DATALISTADO_PRODUCTOS_OKA.Columns[10].Visible = false;
                DATALISTADO_PRODUCTOS_OKA.Columns[11].Visible = false;
                DATALISTADO_PRODUCTOS_OKA.Columns[12].Visible = false;
            }
            catch (Exception ex)
            {
                CONEXION.CONEXIONMAESTRA.cerrar();
                MessageBox.Show(ex.StackTrace);
            }
        }



        string Tipo_de_busqueda;
        private void MOSTRAR_TIPO_DE_BUSQUEDA()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
            SqlCommand com = new SqlCommand("Select Modo_de_busqueda  from EMPRESA", con);

            try
            {
                con.Open();
                Tipo_de_busqueda = Convert.ToString(com.ExecuteScalar());
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }


    
        int txtcontador;

        private void mostrar_descripcion_produco_sin_repetir()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("mostrar_descripcion_produco_sin_repetir", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@buscar", txtbuscar.Text);
                da.Fill(dt);
                DATALISTADO_PRODUCTOS_OKA.DataSource = dt;
                con.Close();

                DATALISTADO_PRODUCTOS_OKA.Columns[2].Width = 500;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void contar()
        {
            int x;

            x = DATALISTADO_PRODUCTOS_OKA.Rows.Count;
            txtcontador = (x);

        }


        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            //mostrar_descripcion_produco_sin_repetir();
            //contar();

            if (Tipo_de_busqueda == "LECTORA")
            {

                ValidarVentasNuevas();
                lbltipodebusqueda2.Visible = false;
                TimerBUSCADORcodigodebarras.Start();
            }
            else if (Tipo_de_busqueda == "TECLADO")
            {
                if (txtbuscar.Text == "")
                {
                    ocultar_mostrar_productos();
                }
                else if (txtbuscar.Text != "")
                {
                    mostrar_productos();
                }
                LISTAR_PRODUCTOS_Abuscador();

            }

        }
        private void mostrar_productos()
        {
            panel_mostrador_de_productos.Size = new System.Drawing.Size(600, 186);
            panel_mostrador_de_productos.BackColor = Color.White;
            panel_mostrador_de_productos.Location = new Point(panelReferenciaProductos.Location.X, panelReferenciaProductos.Location.Y);
            panel_mostrador_de_productos.Visible = true;
            DATALISTADO_PRODUCTOS_OKA.Visible = true;
            DATALISTADO_PRODUCTOS_OKA.Dock = DockStyle.Fill;
            DATALISTADO_PRODUCTOS_OKA.BackgroundColor = Color.White;
            lbltipodebusqueda2.Visible = false;
            panel_mostrador_de_productos.Controls.Add(DATALISTADO_PRODUCTOS_OKA);

            this.Controls.Add(panel_mostrador_de_productos);
            panel_mostrador_de_productos.BringToFront();
            
        }
        private void ocultar_mostrar_productos()
        {

            panel_mostrador_de_productos.Visible = false;
            DATALISTADO_PRODUCTOS_OKA.Visible = false;
            lbltipodebusqueda2.Visible = true;
        }
        private void DATALISTADO_PRODUCTOS_OKA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DATALISTADO_PRODUCTOS_OKA_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idproducto = Convert.ToInt32(DATALISTADO_PRODUCTOS_OKA.SelectedCells[1].Value.ToString());
            txtdescripcion = DATALISTADO_PRODUCTOS_OKA.SelectedCells[4].Value.ToString();
            txtProductoGranel.Text = txtdescripcion;
            txtbuscar.Text = DATALISTADO_PRODUCTOS_OKA.SelectedCells[7].Value.ToString();
            PANELGRANEL.Location = new Point((Width - PANELGRANEL.Width) / 2, (Height - PANELGRANEL.Height) / 2);
            vender_por_teclado();
            ValidarVentasNuevas();
        }

        public void ValidarVentasNuevas()
        {
            if (datalistadoDetalleVenta.RowCount == 0)
            {
                Limpiar_para_venta_nueva();
            }
        }

        private void vender_por_teclado()
        {
            // mostramos los registros del producto en el detalle de venta
            mostrar_stock_de_detalle_de_ventas();
            contar_stock_detalle_ventas();

            if (contador_stock_detalle_de_venta == 0)
            {
                // Si es producto no esta agregado a las ventas se tomara el Stock de la tabla Productos
                lblStock_de_Productos = Convert.ToDouble(DATALISTADO_PRODUCTOS_OKA.SelectedCells[3].Value.ToString());
               // MessageBox.Show("contador_stock_detalle_de_venta");

            }
            else
            {
                //en caso que el producto ya este agregado al detalle de venta se va a extraer el Stock de la tabla Detalle_de_venta
                lblStock_de_Productos = Convert.ToDouble(datalistado_stock_detalle_venta.SelectedCells[1].Value.ToString());
            }
            //Extraemos los datos del producto de la tabla Productos directamente
            lbldescripcion.Text = DATALISTADO_PRODUCTOS_OKA.SelectedCells[4].Value.ToString();
            lblcosto.Text = DATALISTADO_PRODUCTOS_OKA.SelectedCells[5].Value.ToString();
            lblcodigo.Text = DATALISTADO_PRODUCTOS_OKA.SelectedCells[7].Value.ToString();
            unidadVenta = DATALISTADO_PRODUCTOS_OKA.SelectedCells[8].Value.ToString();
            sevendePor = "Granel";

            txtprecio_unitario = Convert.ToDouble(DATALISTADO_PRODUCTOS_OKA.SelectedCells[6].Value.ToString());

            ImpuestoProducto = Convert.ToDouble(DATALISTADO_PRODUCTOS_OKA.SelectedCells[9].Value);
            DescuentoProducto = Convert.ToDouble(DATALISTADO_PRODUCTOS_OKA.SelectedCells[10].Value);
            ImpuestoCategoria  = Convert.ToDouble(DATALISTADO_PRODUCTOS_OKA.SelectedCells[11].Value);
            DescuentoCategoria  = Convert.ToDouble(DATALISTADO_PRODUCTOS_OKA.SelectedCells[12].Value);
            // 9 - 10 - 11 - 12
            if (ImpuestoCategoria > 0)
            {
                lblitbis_.Text = ImpuestoCategoria.ToString();
            }
            else
            {
                lblitbis_.Text = ImpuestoProducto.ToString();
            }

            if (DescuentoCategoria > 0)
            {
                lblDescuento_.Text = DescuentoCategoria.ToString();
            }
            else
            {
                lblDescuento_.Text = DescuentoProducto.ToString();
            }

            //Preguntamos que tipo de producto sera el que se agrege al detalle de venta
            if (sevendePor == "Granel")
            {
                vender_a_granel();
            }
            else if (sevendePor == "Unidad")
            {
                vender_por_unidad();
                txtpantalla = 1;
            }

        }
        private void vender_a_granel()
        {

            PANELGRANEL.Visible = true;
            
            PANELGRANEL.BringToFront();
            PANELGRANEL.Visible = true;
            PANELGRANEL.Location = new Point(527, 211);
        }

        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ejecutar_ventas_a_granel();
        }

        public void ejecutar_ventas_a_granel()
        {
           // MessageBox.Show(txtpantalla.ToString() + "ejecutar_ventas_a_granel");

            ejecutar_insertar_ventas();
            if (txtventagenerada == "factura GENERADA")
            {
               // MessageBox.Show(txtpantalla.ToString() + "txtventagenerada");
                insertar_detalle_venta();
                Listarproductosagregados();
                txtbuscar.Text = "";
                txtbuscar.Focus();
            }

        }
        private void Obtener_id_de_cliente_estandar()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
            SqlCommand com = new SqlCommand("select idclientev from clientes where Estado=0", con);
            try
            {

                con.Open();
                idClienteEstandar = Convert.ToInt32(com.ExecuteScalar());
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }

        }

        private void Obtener_id_venta_recien_Creada()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
            SqlCommand com = new SqlCommand("mostrar_id_factura_por_Id_caja", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id_caja", Id_caja);
            try
            {
                con.Open();
                idVenta = Convert.ToInt32(com.ExecuteScalar());
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("mostrar_id_venta_por_Id_caja");
            }
        }
        private void MOSTRAR_comprobante_serializado_POR_DEFECTO()
        {
            SqlCommand cmd = new SqlCommand("select tipodoc from Serializacion Where Por_defecto='SI'", CONEXION.CONEXIONMAESTRA.conectar);
            try
            {
                CONEXION.CONEXIONMAESTRA.abrir();
                lblComprobante.Text = Convert.ToString(cmd.ExecuteScalar());
                //MessageBox.Show(lblComprobante.Text);
                CONEXION.CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void buscar_Tipo_de_documentos_para_insertar_en_ventas()
        {
            DataTable dt = new DataTable();
            try
            {
                CONEXION.CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("Buscar_tipo_de_documentos_para_insertar_en_facturas", CONEXION.CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letra", lblComprobante.Text);
                da.Fill(dt);
                dtComprobantes.DataSource = dt;
                CONEXION.CONEXIONMAESTRA.cerrar();
            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            {
            }
        }
        int idcomprobante;

        void validar_tipos_de_comprobantes()
        {
            buscar_Tipo_de_documentos_para_insertar_en_ventas();
            try
            {
                int numerofin;

                txtserie.Text = dtComprobantes.SelectedCells[2].Value.ToString();

                numerofin = Convert.ToInt32(dtComprobantes.SelectedCells[4].Value);
                idcomprobante = Convert.ToInt32(dtComprobantes.SelectedCells[5].Value);
                txtnumerofin.Text = Convert.ToString(numerofin + 1);
                lblCantidad_de_numeros.Text = dtComprobantes.SelectedCells[3].Value.ToString();
                lblCorrelativoconCeros.Text = CONEXION.Agregar_ceros_adelante_De_numero.ceros(txtnumerofin.Text, Convert.ToInt32(lblCantidad_de_numeros.Text));
            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            {

            }
        }
        private void vender_por_unidad()
        {
            try
            {
                if (txtbuscar.Text == DATALISTADO_PRODUCTOS_OKA.SelectedCells[10].Value.ToString())
                {
                    DATALISTADO_PRODUCTOS_OKA.Visible = true;
                    ejecutar_insertar_ventas();
                    if (txtventagenerada == "factura GENERADA")
                    {
                        //MessageBox.Show("(txtventagenerada == factura GENERADA");
                        insertar_detalle_venta();
                        Listarproductosagregados();
                        txtbuscar.Text = "";
                        txtbuscar.Focus();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        private void ejecutar_insertar_ventas()
        {
            //MessageBox.Show("ejecutar_insertar_ventas",txtventagenerada);
            if (txtventagenerada == "factura NUEVA")
            {
                try
                {
                    //MessageBox.Show("insertar_venta");
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand("insertar_factura", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idcliente", idClienteEstandar);
                    cmd.Parameters.AddWithValue("@fecha_factura", DateTime.Today);
                    cmd.Parameters.AddWithValue("@nume_documento", 0);
                    cmd.Parameters.AddWithValue("@montototal", 0);
                    cmd.Parameters.AddWithValue("@Tipo_de_pago", 0);
                    cmd.Parameters.AddWithValue("@estado", "EN ESPERA");
                    cmd.Parameters.AddWithValue("@Comprobante", lblComprobante.Text);
                    cmd.Parameters.AddWithValue("@id_usuario", idusuario_que_inicio_sesion);
                    cmd.Parameters.AddWithValue("@Fecha_de_pago", DateTime.Today);
                    cmd.Parameters.AddWithValue("@ACCION", "factura");
                    cmd.Parameters.AddWithValue("@Saldo", 0);
                    cmd.Parameters.AddWithValue("@Pago_con", 0);
                    cmd.Parameters.AddWithValue("@Id_caja", Id_caja);
                    cmd.Parameters.AddWithValue("@Referencia_tarjeta", 0);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Obtener_id_venta_recien_Creada();
                    txtventagenerada = "factura GENERADA";
                    mostrar_panel_de_Cobro();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("insertar_venta");
                }

            }
        }
        private void mostrar_panel_de_Cobro()
        {
            panelBienvenida.Visible = false;
            PanelOperaciones.Visible = true;
        }
        private void Listarproductosagregados()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                da = new SqlDataAdapter("mostrar_productos_agregados_a_factura", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idfactura", idVenta);
                da.Fill(dt);
                datalistadoDetalleVenta.DataSource = dt;
                con.Close();
               datalistadoDetalleVenta.Columns[0].Width = 50;
                datalistadoDetalleVenta.Columns[1].Width = 50;
                datalistadoDetalleVenta.Columns[2].Width = 50;
                datalistadoDetalleVenta.Columns[3].Visible = false;
                datalistadoDetalleVenta.Columns[4].Width = 250;
                datalistadoDetalleVenta.Columns[5].Width = 100;
                datalistadoDetalleVenta.Columns[6].Width = 100;
                datalistadoDetalleVenta.Columns[7].Width = 100;
                datalistadoDetalleVenta.Columns[8].Visible = false;
                datalistadoDetalleVenta.Columns[9].Visible = false;
                datalistadoDetalleVenta.Columns[10].Visible = false;
                datalistadoDetalleVenta.Columns[11].Width = datalistadoDetalleVenta.Width - (datalistadoDetalleVenta.Columns[0].Width - datalistadoDetalleVenta.Columns[1].Width - datalistadoDetalleVenta.Columns[2].Width -
                datalistadoDetalleVenta.Columns[4].Width - datalistadoDetalleVenta.Columns[5].Width - datalistadoDetalleVenta.Columns[6].Width - datalistadoDetalleVenta.Columns[7].Width);
                datalistadoDetalleVenta.Columns[12].Visible = false;
                datalistadoDetalleVenta.Columns[13].Visible = false;
                datalistadoDetalleVenta.Columns[14].Visible = false;
                datalistadoDetalleVenta.Columns[15].Visible = false;
                datalistadoDetalleVenta.Columns[16].Visible = false;
                datalistadoDetalleVenta.Columns[17].Visible = false;
               /* datalistadoDetalleVenta.Columns[18].Visible = false;
                datalistadoDetalleVenta.Columns[19].Visible = false;*/
                if (Tema == "Redentor")
                {
                    Bases.Multilinea(ref datalistadoDetalleVenta);
                }
                else
                {
                    Bases.MultilineaTemaOscuro(ref datalistadoDetalleVenta);
                }
                sumarItbis();
                sumar();
                sumar2();
                sumarDescuentos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        private void insertar_detalle_venta()
        {
            try
            {
                    if (lblStock_de_Productos >= txtpantalla)
                    {
                    //MessageBox.Show(txtpantalla.ToString() + "insertar_detalle_venta vvv");

                    insertar_detalle_venta_Validado();
                    }
                    else
                    {
                        TimerLABEL_STOCK.Start();
                    }
                    insertar_detalle_venta_SIN_VALIDAR();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }

        }

        private void insertar_detalle_venta_Validado()
        {
           // MessageBox.Show(txtpantalla.ToString() + "insertar_detalle_venta_Validado");

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("insertar_detalle_factura", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idfactura", idVenta);
                cmd.Parameters.AddWithValue("@Id_presentacionfraccionada", idproducto);
                cmd.Parameters.AddWithValue("@cantidad", txtpantalla);
                cmd.Parameters.AddWithValue("@preciounitario", txtprecio_unitario);
                cmd.Parameters.AddWithValue("@moneda", "DOP");
                cmd.Parameters.AddWithValue("@Descuento", Convert.ToDouble(lblDescuento_.Text));
                cmd.Parameters.AddWithValue("@unidades", unidadVenta);
                cmd.Parameters.AddWithValue("@Estado", "EN ESPERA");
                cmd.Parameters.AddWithValue("@Descripcion", lbldescripcion.Text);
                cmd.Parameters.AddWithValue("@Codigo", lblcodigo.Text);
                cmd.Parameters.AddWithValue("@Stock", lblStock_de_Productos);
                cmd.Parameters.AddWithValue("@Se_vende_a", sevendePor);
                cmd.Parameters.AddWithValue("@Costo", lblcosto.Text);
                cmd.Parameters.AddWithValue("@itbis_calculado", Convert.ToDecimal(lblitbis_.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                disminuir_stock_en_detalle_de_venta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + ex.Message);
            }
        }

        private void insertar_detalle_venta_SIN_VALIDAR()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("insertar_detalle_factura", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idfactura", idVenta);
                cmd.Parameters.AddWithValue("@Id_presentacionfraccionada", idproducto);
                cmd.Parameters.AddWithValue("@cantidad", txtpantalla);
                cmd.Parameters.AddWithValue("@preciounitario", txtprecio_unitario);
                cmd.Parameters.AddWithValue("@moneda", "DOP");
                cmd.Parameters.AddWithValue("@Descuento", Convert.ToDouble(lblDescuento_.Text));
                cmd.Parameters.AddWithValue("@unidades", unidadVenta);
                cmd.Parameters.AddWithValue("@Estado", "EN ESPERA");
                cmd.Parameters.AddWithValue("@Descripcion", lbldescripcion.Text);
                cmd.Parameters.AddWithValue("@Codigo", lblcodigo.Text);
                cmd.Parameters.AddWithValue("@Stock", lblStock_de_Productos);
                cmd.Parameters.AddWithValue("@Se_vende_a", sevendePor);
                cmd.Parameters.AddWithValue("@Costo", lblcosto.Text);
                cmd.Parameters.AddWithValue("@itbis_calculado", Convert.ToDecimal(lblitbis_.Text));
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + ex.Message);
            }
        }

        private void contar_stock_detalle_ventas()
        {
            int x;
            x = datalistado_stock_detalle_venta.Rows.Count;
            contador_stock_detalle_de_venta = (x);
        }
        private void mostrar_stock_de_detalle_de_ventas()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                da = new SqlDataAdapter("mostrar_stock_de_detalle_de_facturas", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Id_producto", idproducto);
                da.Fill(dt);
                datalistado_stock_detalle_venta.DataSource = dt;
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + ex.Message);
            }
        }
        private void ejecutar_detalle_venta_decuento()
        {
            try
            {
                SqlCommand cmd;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                cmd = new SqlCommand("editar_detalle_factura_descuento", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_producto", idproducto);
                cmd.Parameters.AddWithValue("@cantidad", txtpantalla);
                cmd.Parameters.AddWithValue("@Id_factura", idVenta);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {


            }

        }

        private void ejecutar_editar_detalle_venta_sumar()
        {
            try
            {
                SqlCommand cmd;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                cmd = new SqlCommand("editar_detalle_factura_sumar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_producto", idproducto);
                cmd.Parameters.AddWithValue("@cantidad", txtpantalla);
                cmd.Parameters.AddWithValue("@Id_factura", idVenta);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {


            }

        }
        private void disminuir_stock_en_detalle_de_venta()
        {
            try
            {
                CONEXION.CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("disminuir_stock_en_detalle_de_factura", CONEXION.CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Producto1", idproducto);
                cmd.Parameters.AddWithValue("@cantidad", txtpantalla);
                cmd.ExecuteNonQuery();
                CONEXION.CONEXIONMAESTRA.cerrar();
            }
            catch (Exception)
            {


            }
        }
        private void Obtener_datos_del_detalle_de_venta()
        {

            try
            {
                iddetalleventa = Convert.ToInt32(datalistadoDetalleVenta.SelectedCells[9].Value.ToString());
                idproducto = Convert.ToInt32(datalistadoDetalleVenta.SelectedCells[8].Value.ToString());
                sevendePor = datalistadoDetalleVenta.SelectedCells[17].Value.ToString();
                cantidad = Convert.ToDouble(datalistadoDetalleVenta.SelectedCells[5].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void editar_detalle_venta_sumar()
        {


            lblStock_de_Productos = Convert.ToDouble(datalistadoDetalleVenta.SelectedCells[15].Value.ToString());
            if (lblStock_de_Productos > 0)
            {

                ejecutar_editar_detalle_venta_sumar();
                disminuir_stock_en_detalle_de_venta();
            }
            else
            {
                TimerLABEL_STOCK.Start();
            }
            Listarproductosagregados();
        }

        private void editar_detalle_venta_restar()
        {
                ejecutar_editar_detalle_venta_restar();
                aumentar_stock_en_detalle_de_venta();
    
            Listarproductosagregados();
        }
        private void aumentar_stock_en_detalle_de_venta()
        {
            try
            {

                CONEXION.CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("aumentar_stock_en_detalle_de_factura", CONEXION.CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Producto1", idproducto);
                cmd.Parameters.AddWithValue("@cantidad", txtpantalla);
                cmd.ExecuteNonQuery();
                CONEXION.CONEXIONMAESTRA.cerrar();
            }
            catch (Exception)
            {

            }
        }
        private void ejecutar_editar_detalle_venta_restar()
        {
            try
            {
                SqlCommand cmd;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                cmd = new SqlCommand("editar_detalle_factura_restar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@iddetalle_factura", iddetalleventa);
                cmd.Parameters.AddWithValue("cantidad", txtpantalla);
                cmd.Parameters.AddWithValue("@Id_producto", idproducto);
                cmd.Parameters.AddWithValue("@Id_factura", idVenta);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void datalistadoDetalleVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            Obtener_datos_del_detalle_de_venta();


            if (e.ColumnIndex == this.datalistadoDetalleVenta.Columns["S"].Index)
            {
                txtpantalla = 1;
                editar_detalle_venta_sumar();
            }
            if (e.ColumnIndex == this.datalistadoDetalleVenta.Columns["R"].Index)
            {
                txtpantalla = 1;
                editar_detalle_venta_restar();
                EliminarVentas();
            }


            if (e.ColumnIndex == this.datalistadoDetalleVenta.Columns["EL"].Index)
            {

                int iddetalle_venta = Convert.ToInt32(datalistadoDetalleVenta.SelectedCells[9].Value);
                try
                {
                    SqlCommand cmd;
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                    con.Open();
                    cmd = new SqlCommand("eliminar_detalle_factura", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@iddetallefactura", iddetalle_venta);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    txtpantalla = Convert.ToDouble(datalistadoDetalleVenta.SelectedCells[5].Value);
                    aumentar_stock_en_detalle_de_venta();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Listarproductosagregados();
                EliminarVentas();
            }
        }
        private void EliminarVentas()
        {
            contar_tablas_ventas();
            if (Contador == 0)
            {
                eliminar_venta_al_agregar_productos();
                Limpiar_para_venta_nueva();
            }
        }
        private void eliminar_venta_al_agregar_productos()
        {
            try
            {
                SqlCommand cmd;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                cmd = new SqlCommand("eliminar_factura", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idfactura", idVenta);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void contar_tablas_ventas()
        {
            int x;
            x = datalistadoDetalleVenta.Rows.Count;
            Contador = (x);
        }


        private void datalistadoDetalleVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            Obtener_datos_del_detalle_de_venta();
            if (e.KeyChar == Convert.ToChar("+"))
            {
                editar_detalle_venta_sumar();
            }
            if (e.KeyChar == Convert.ToChar("-"))
            {
                editar_detalle_venta_restar();
                contar_tablas_ventas();
                if (Contador == 0)
                {
                    eliminar_venta_al_agregar_productos();
                    txtventagenerada = "factura NUEVA";
                }
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "2";

        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
        }
        bool SECUENCIA = true;
        private void btnSeparador_Click(object sender, EventArgs e)
        {
            if (SECUENCIA == true)
            {
                txtmonto.Text = txtmonto.Text + ".";
                SECUENCIA = false;
            }
            else
            {
                return;
            }
        }

        private void txtmonto_TextChanged(object sender, EventArgs e)
        {
            //if (SECUENCIA == true)
            //{
            //    txtmonto.Text = txtmonto.Text + ".";
            //    SECUENCIA = false;
            //}
            //else
            //{
            //    return;
            //}
        }
        private void txtmonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txtmonto, e);
        }

        private void btnborrartodo_Click(object sender, EventArgs e)
        {
            txtmonto.Clear();
            SECUENCIA = true;
        }

        private void TimerBUSCADORcodigodebarras_Tick(object sender, EventArgs e)
        {
            TimerBUSCADORcodigodebarras.Stop();
            vender_por_lectora_de_barras();
        }
        private void vender_por_lectora_de_barras()
        {
            try
            {
                if (txtbuscar.Text == "")
                {
                    DATALISTADO_PRODUCTOS_OKA.Visible = false;
                    lbltipodebusqueda2.Visible = true;
                }
                if (txtbuscar.Text != "")
                {
                    DATALISTADO_PRODUCTOS_OKA.Visible = true;
                    lbltipodebusqueda2.Visible = false;
                    LISTAR_PRODUCTOS_Abuscador();

                    idproducto = Convert.ToInt32(DATALISTADO_PRODUCTOS_OKA.SelectedCells[1].Value.ToString());
                    mostrar_stock_de_detalle_de_ventas();
                    contar_stock_detalle_ventas();

                    if (contador_stock_detalle_de_venta == 0)
                    {
                        lblStock_de_Productos = Convert.ToDouble(DATALISTADO_PRODUCTOS_OKA.SelectedCells[4].Value.ToString());
                    }
                    else
                    {
                        lblStock_de_Productos = Convert.ToDouble(datalistado_stock_detalle_venta.SelectedCells[1].Value.ToString());
                    }
                    //usainventarios = DATALISTADO_PRODUCTOS_OKA.SelectedCells[3].Value.ToString();
                    lbldescripcion.Text = DATALISTADO_PRODUCTOS_OKA.SelectedCells[9].Value.ToString();
                    lblcodigo.Text = DATALISTADO_PRODUCTOS_OKA.SelectedCells[10].Value.ToString();
                    lblcosto.Text = DATALISTADO_PRODUCTOS_OKA.SelectedCells[5].Value.ToString();
                    txtprecio_unitario = Convert.ToDouble(DATALISTADO_PRODUCTOS_OKA.SelectedCells[6].Value.ToString());

                    sevendePor = DATALISTADO_PRODUCTOS_OKA.SelectedCells[8].Value.ToString();
                    if (sevendePor == "Unidad")
                    {
                        txtpantalla = 1;
                        vender_por_unidad();
                    }

                }
            }
            catch (Exception)
            {


            }

        }
        private void lbltipodebusqueda2_Click(object sender, EventArgs e)
        {

        }
        private void editar_detalle_venta_CANTIDAD()
        {
            try
            {
                SqlCommand cmd;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                cmd = new SqlCommand("editar_detalle_factura_CANTIDAD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_producto", idproducto);
                cmd.Parameters.AddWithValue("@cantidad", txtmonto.Text);
                cmd.Parameters.AddWithValue("@Id_factura", idVenta);
                cmd.ExecuteNonQuery();
                con.Close();
                Listarproductosagregados();
                txtmonto.Clear();
                txtmonto.Focus();
                idVenta = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Button21_Click(object sender, EventArgs e)
        {
            if (iddetalleventa == 0)
            {
                MessageBox.Show("Seleccione un producto para realizar la edición", "Editar cantidad del Articulo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (!string.IsNullOrEmpty(txtmonto.Text))
                {
                    if (datalistadoDetalleVenta.RowCount > 0)
                    {

                        /*if (sevendePor == "Unidad")
                        {
                            string cadena = txtmonto.Text;
                            if (cadena.Contains("."))
                            {
                                MessageBox.Show("Este Producto no acepta decimales ya que esta configurado para ser vendido por UNIDAD", "Formato Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                BotonCantidad();
                            }
                        }*/
                        if (sevendePor == "Granel")
                        {
                            BotonCantidad();
                        }
                    }
                    else
                    {
                        txtmonto.Clear();
                        txtmonto.Focus();
                    }
                    txtmonto.Focus();
                    txtmonto.Clear();
                }
            }
        }

        private void BotonCantidad()
        {
            double MontoaIngresar;
            MontoaIngresar = Convert.ToDouble(txtmonto.Text);
            double Cantidad;
            Cantidad = Convert.ToDouble(datalistadoDetalleVenta.SelectedCells[5].Value);

            double stock;
            double condicional;
            string ControlStock;
            ControlStock = datalistadoDetalleVenta.SelectedCells[16].Value.ToString();
            if (ControlStock == "SI")
            {
                stock = Convert.ToDouble(datalistadoDetalleVenta.SelectedCells[11].Value);
                condicional = Cantidad + stock;
                if (condicional >= MontoaIngresar)
                {
                    BotonCantidadEjecuta();
                }
                else
                {
                    TimerLABEL_STOCK.Start();
                }
            }
            else
            {
                BotonCantidadEjecuta();
            }
        }

        private void BotonDescuento()
        {
            double MontoaIngresar;
            MontoaIngresar = Convert.ToDouble(txtmonto.Text);
            double Cantidad;
            Cantidad = Convert.ToDouble(datalistadoDetalleVenta.SelectedCells[18].Value);
            double stock;
            double condicional;
            string ControlStock;
            ControlStock = datalistadoDetalleVenta.SelectedCells[16].Value.ToString();
            if (ControlStock == "SI")
            {
                stock = Convert.ToDouble(datalistadoDetalleVenta.SelectedCells[11].Value);
                condicional = Cantidad + stock;
                if (condicional >= MontoaIngresar)
                {
                    BotonCantidadEjecuta();
                }
                else
                {
                    TimerLABEL_STOCK.Start();
                }
            }
            else
            {
                BotonCantidadEjecuta();
            }


        }
        private void BotonCantidadEjecuta()
        {
            double MontoaIngresar;
            MontoaIngresar = Convert.ToDouble(txtmonto.Text);
            double Cantidad;
            Cantidad = Convert.ToDouble(datalistadoDetalleVenta.SelectedCells[5].Value);

            if (MontoaIngresar > Cantidad)
            {
                txtpantalla = MontoaIngresar - Cantidad;
                editar_detalle_venta_sumar();
            }
            else if (MontoaIngresar < Cantidad)
            {
                txtpantalla = Cantidad - MontoaIngresar;
                editar_detalle_venta_restar();
            }
        }
        private void frm_FormClosed(Object sender, FormClosedEventArgs e)
        {
            Limpiar_para_venta_nueva();
        }

        private void Panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TimerLABEL_STOCK_Tick(object sender, EventArgs e)
        {
            if (ProgressBarETIQUETA_STOCK.Value < 100)
            {
                ProgressBarETIQUETA_STOCK.Value = ProgressBarETIQUETA_STOCK.Value + 10;
                LABEL_STOCK.Visible = true;
                LABEL_STOCK.Dock = DockStyle.Fill;
            }
            else
            {
                LABEL_STOCK.Visible = false;
                LABEL_STOCK.Dock = DockStyle.None;
                ProgressBarETIQUETA_STOCK.Value = 0;
                TimerLABEL_STOCK.Stop();
            }
        }

        private void befectivo_Click_1(object sender, EventArgs e)
        {
            if (datalistadoDetalleVenta.Rows.Count == 0)
            {

            }
            else
            {
                total = Convert.ToDouble(txt_total_suma.Text);
                MEDIOS_DE_PAGO frm = new MEDIOS_DE_PAGO();
                frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                frm.ShowDialog();
            }
        }



        private void btnrestaurar_Click_1(object sender, EventArgs e)
        {
            Ventas_en_espera frm = new Ventas_en_espera();
            frm.FormClosing += Frm_FormClosing1;
            frm.ShowDialog();
        }

        private void Frm_FormClosing1(object sender, FormClosingEventArgs e)
        {
            Listarproductosagregados();
            mostrar_panel_de_Cobro();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (datalistadoDetalleVenta.RowCount > 0)
            {
                DialogResult pregunta = MessageBox.Show("¿Realmente desea eliminar esta Venta?", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (pregunta == DialogResult.OK)
                {
                    Eliminar_datos.eliminar_factura(idVenta);
                    Limpiar_para_venta_nueva();
                }
            }


        }

        private void btnespera_Click(object sender, EventArgs e)
        {
            if (datalistadoDetalleVenta.RowCount > 0)
            {
                MOSTRAR_comprobante_serializado_POR_DEFECTO();
                PanelEnespera.Visible = true;
                PanelEnespera.BringToFront();
                PanelEnespera.Dock = DockStyle.Fill;
                txtnombre.Clear();
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            ocularPanelenEspera();
        }

        private void ocularPanelenEspera()
        {
            PanelEnespera.Visible = false;
            PanelEnespera.Dock = DockStyle.None;
        }
        private void btnGuardarEspera_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtnombre.Text))
            {
                editarVentaEspera();
            }
            else
            {
                MessageBox.Show("Ingrese una referencia");
            }

        }
        private void editarVentaEspera()

        {
            Editar_datos.ingresar_nombre_a_venta_en_espera(idVenta, txtnombre.Text);
            Limpiar_para_venta_nueva();
            ocularPanelenEspera();
        }
        private void btnAutomaticoEspera_Click(object sender, EventArgs e)
        {
            //OJOOOOOOO
            txtnombre.Text = "Ticket" + idVenta;
            editarVentaEspera();
        }
        


        private void BTNLECTORA_Click_1(object sender, EventArgs e)
        {
            lbltipodebusqueda2.Text = "Buscar con LECTORA de Codigos de Barras";
            Tipo_de_busqueda = "LECTORA";
            BTNLECTORA.BackColor = Color.LightGreen;
            BTNTECLADO.BackColor = Color.WhiteSmoke;
            txtbuscar.Clear();
            txtbuscar.Focus();
        }

        private void BTNTECLADO_Click_1(object sender, EventArgs e)
        {
            lbltipodebusqueda2.Text = "Buscar con  TECLADO";
            Tipo_de_busqueda = "TECLADO";
            BTNTECLADO.BackColor = Color.LightGreen;
            BTNLECTORA.BackColor = Color.WhiteSmoke;
            txtbuscar.Clear();
            txtbuscar.Focus();
        }

        private void btnverMovimientosCaja_Click(object sender, EventArgs e)
        {
            CAJA.Listado_gastos_ingresos frm = new CAJA.Listado_gastos_ingresos();
            frm.ShowDialog();
        }

        private void btnGastos_Click(object sender, EventArgs e)
        {
            int idRol;
            string Rol;
            string modulo;
            string Operacion;

            foreach (DataGridViewRow row in datalistadousuario.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario_que_inicio_sesion == idusuarioBuscar)
                {
                    if (modulo == "Egresos")
                    {
                        if (Operacion == "ACCESO")
                        {
                            Gastos_varios.Gastos frm = new Gastos_varios.Gastos();
                            frm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Acceso restringido\nComunicate con tu administrador", "Panel de Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

            }
           
        }

        private void btnIngresosCaja_Click(object sender, EventArgs e)
        {
            int idRol;
            string Rol;
            string modulo;
            string Operacion;

            foreach (DataGridViewRow row in datalistadousuario.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario_que_inicio_sesion == idusuarioBuscar)
                {
                    if (modulo == "Ingresos")
                    {
                        if (Operacion == "ACCESO")
                        {
                            Ingresos_varios.IngresosVarios frm = new Ingresos_varios.IngresosVarios();
                            frm.ShowDialog();

                        }
                        else
                        {
                            MessageBox.Show("Acceso restringido\nComunicate con tu administrador", "Panel de Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

            }
            
          
        }

        private void BtnCerrar_turno_Click(object sender, EventArgs e)
        {
            int idRol;
            string Rol;
            string modulo;
            string Operacion;

            foreach (DataGridViewRow row in datalistadousuario.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario_que_inicio_sesion == idusuarioBuscar)
                {
                    if (modulo == "Cerrar turno")
                    {
                        if (Operacion == "ACCESO")
                        {
                            Dispose();
                            CAJA.CIERRE_DE_CAJA frm = new CAJA.CIERRE_DE_CAJA();
                            frm.ShowDialog();

                        }
                        else
                        {
                            MessageBox.Show("Acceso restringido\nComunicate con tu administrador", "Panel de Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

            }
           

        }

        private void btnCreditoPagar_Click(object sender, EventArgs e)
        {
            Apertura_de_credito.PorPagar frm = new Apertura_de_credito.PorPagar();
            frm.ShowDialog();
        }

        private void btnCreditoCobrar_Click(object sender, EventArgs e)
        {
            Apertura_de_credito.PorCobrarOk frm = new Apertura_de_credito.PorCobrarOk();
            frm.ShowDialog();
        }

        private void btnadmin_Click(object sender, EventArgs e)
        {
            int idRol;
            string Rol;
            string modulo;
            string Operacion;

            foreach (DataGridViewRow row in datalistadousuario.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario_que_inicio_sesion == idusuarioBuscar)
                {
                    if (modulo == "Configuracion")
                    {
                        if (Operacion == "ACCESO")
                        {
                            Dispose();
                            DASHBOARD_PRINCIPAL frm = new DASHBOARD_PRINCIPAL();
                            frm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Acceso restringido\nComunicate con tu administrador", "Panel de Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }

        private void VENTAS_MENU_PRINCIPALOK_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlgRes = MessageBox.Show("¿Realmente desea Cerrar el Sistema?", "Cerrando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgRes == DialogResult.Yes)
            {
                Dispose();
                CopiasBd.GeneradorAutomatico frm = new CopiasBd.GeneradorAutomatico();
                frm.ShowDialog();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void VENTAS_MENU_PRINCIPALOK_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void btnCobros_Click(object sender, EventArgs e)
        {
            int idRol;
            string Rol;
            string modulo;
            string Operacion;

            foreach (DataGridViewRow row in datalistadousuario.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario_que_inicio_sesion == idusuarioBuscar)
                {
                    if (modulo == "Cobros creditos clientes")
                    {
                        if (Operacion == "ACCESO")
                        {
                            Cobros.CobrosForm frm = new Cobros.CobrosForm();
                            frm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Acceso restringido\nComunicate con tu administrador", "Panel de Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

            }

            
        }

        private void btnMayoreo_Click(object sender, EventArgs e)
        {
            aplicar_precio_mayoreo();
        }
        private void aplicar_precio_mayoreo()
        {
            if (datalistadoDetalleVenta.Rows.Count > 0)
            {
                Ldetallefactura parametros = new Ldetallefactura();
                Editar_datos funcion = new Editar_datos();
                parametros.Id_producto = idproducto;
                parametros.iddetalle_factura = iddetalleventa;
                if (funcion.aplicar_precio_mayoreo(parametros) == true)
                {
                    Listarproductosagregados();
                }
            }

        }

        private void datalistadoDetalleVenta_Click(object sender, EventArgs e)
        {

        }

        private void btnprecio_Click(object sender, EventArgs e)
        {
            //double precio = Convert.ToDouble(datalistadoDetalleVenta.SelectedCells[5].Value);
            if (iddetalleventa == 0)
            { 
                MessageBox.Show("Seleccione un producto para realizar la edición", "Editar precio del Articulo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (!string.IsNullOrEmpty(txtmonto.Text))
                {
                    Ldetallefactura parametros = new Ldetallefactura();
                    Editar_datos funcion = new Editar_datos();
                    parametros.iddetalle_factura = iddetalleventa;
                    parametros.preciounitario = Convert.ToDouble(txtmonto.Text);

                    if (funcion.editarPrecioVenta(parametros) == true)
                    {
                        Listarproductosagregados();
                        
                    }
                }
                txtmonto.Focus();
                txtmonto.Clear();
                iddetalleventa = 0;
            }
        }

        private void Descuento_Click(object sender, EventArgs e)
        {
            
            if (iddetalleventa == 0)
            {
                MessageBox.Show("Seleccione un producto para aplicarle descuento", "Editar descuento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                double precio = Convert.ToDouble(datalistadoDetalleVenta.SelectedCells[6].Value);
                //MessageBox.Show(precio.ToString());
                if (!string.IsNullOrEmpty(txtmonto.Text))
                {
                    if((Convert.ToInt32(txtmonto.Text) < precio))
                    {
                        Ldetallefactura parametros = new Ldetallefactura();
                        Editar_datos funcion = new Editar_datos();
                        parametros.iddetalle_factura = iddetalleventa;
                        parametros.Descuento = Convert.ToDouble(txtmonto.Text);
                        if (funcion.editarDescuentofactura(parametros) == true)
                        {
                            Listarproductosagregados();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Asigne un descuento menor a el precio de la unidad", "Editar descuento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                iddetalleventa = 0;
                txtmonto.Focus();
                txtmonto.Clear();
            }
        }

        private void btndevoluciones_Click(object sender, EventArgs e)
        {
            HistorialVentas.HistorialVentasForm frm = new HistorialVentas.HistorialVentasForm();
            frm.ShowDialog();
        }



        private void IndicadorTema_CheckedChanged(object sender, EventArgs e)
        {
            if (IndicadorTema.Checked == true)
            {
                Tema = "Oscuro";
                EditarTemaCaja();
                TemaOscuro();
                Listarproductosagregados();
                PictureBox4.Visible = true;
                pictureBox5.Visible = false;
            }
            else
            {
                Tema = "Redentor";
                EditarTemaCaja();
                TemaClaro();
                Listarproductosagregados();
                PictureBox4.Visible = false;
                pictureBox5.Visible = true;
            }
        }
        private void EditarTemaCaja()
        {
            Lcaja parametros = new Lcaja();
            Editar_datos funcion = new Editar_datos();
            parametros.Tema = Tema;
            funcion.EditarTemaCaja(parametros);

        }
        private void TemaOscuro()
        {
            //PanelC1 Encabezado
            label9.ForeColor = Color.White;
            label9.BackColor = Color.FromArgb(35, 35, 35);
            PanelC1.BackColor = Color.FromArgb(35, 35, 35);
            lblNombreSoftware.ForeColor = Color.White;
            btnadmin.ForeColor = Color.White;
            txtbuscar.BackColor = Color.FromArgb(20, 20, 20);
            txtbuscar.ForeColor = Color.White;
            lbltipodebusqueda2.BackColor = Color.FromArgb(20, 20, 20);
            //PanelC2 Intermedio
            panelC2.BackColor = Color.FromArgb(35, 35, 35);
            btnCobros.BackColor = Color.FromArgb(45, 45, 45);
            btnCobros.ForeColor = Color.White;

            
            /*btnCreditoCobrar.BackColor = Color.FromArgb(45, 45, 45);
            btnCreditoCobrar.ForeColor = Color.White;
            btnCreditoPagar.BackColor = Color.FromArgb(45, 45, 45);
            btnCreditoPagar.ForeColor = Color.White;
            */
            //PanelC3
            PanelC3.BackColor = Color.FromArgb(35, 35, 35);
            btnMayoreo.BackColor = Color.FromArgb(45, 45, 45);
            btnMayoreo.ForeColor = Color.White;
            btnIngresosCaja.BackColor = Color.FromArgb(45, 45, 45);
            btnIngresosCaja.ForeColor = Color.White;
            btnGastos.BackColor = Color.FromArgb(45, 45, 45);
            btnGastos.ForeColor = Color.White;
            BtnTecladoV.BackColor = Color.FromArgb(45, 45, 45);
            BtnTecladoV.ForeColor = Color.White;
            //PanelC4 Pie de pagina
            panelC4.BackColor = Color.FromArgb(20, 20, 20);
            btnespera.BackColor = Color.FromArgb(20, 20, 20);
            btnespera.ForeColor = Color.White;
            btnrestaurar.BackColor = Color.FromArgb(20, 20, 20);
            btnrestaurar.ForeColor = Color.White;
            btneliminar.BackColor = Color.FromArgb(20, 20, 20);
            btneliminar.ForeColor = Color.White;
            button7.BackColor = Color.FromArgb(20, 20, 20);
            button7.ForeColor = Color.White;
            button6.BackColor = Color.FromArgb(20, 20, 20);
            button6.ForeColor = Color.White;
            btndevoluciones.BackColor = Color.FromArgb(20, 20, 20);
            btndevoluciones.ForeColor = Color.White;
            //PanelOperaciones
            PanelOperaciones.BackColor = Color.FromArgb(35, 35, 35);
            txt_total_suma.ForeColor = Color.WhiteSmoke;
            //PanelBienvenida
            panelBienvenida.BackColor = Color.FromArgb(35, 35, 35);
            label8.ForeColor = Color.WhiteSmoke;
            button4.BackColor = Color.FromArgb(45, 45, 45);
            button4.ForeColor = Color.White;
            btn4.ForeColor = Color.WhiteSmoke;
            btn4.BackColor = Color.FromArgb(45, 45, 45);
            Listarproductosagregados();



        }
        private void TemaClaro()
        {
            button4.ForeColor = Color.Black;
            button4.BackColor = Color.WhiteSmoke;
            button6.ForeColor = Color.Black;
            button6.BackColor = Color.Gainsboro;
            button7.ForeColor = Color.Black;
            button7.BackColor = Color.Gainsboro;
            //PanelC1 encabezado
            label9.ForeColor = Color.Black;
            label9.BackColor = Color.White;
            PanelC1.BackColor = Color.White;
            lblNombreSoftware.ForeColor = Color.Black;
            btnadmin.ForeColor = Color.Black;
            txtbuscar.BackColor = Color.White;
            txtbuscar.ForeColor = Color.Black;
            lbltipodebusqueda2.BackColor = Color.White;
            btn4.ForeColor = Color.WhiteSmoke;
            btn4.BackColor = Color.White;
           
            //PanelC2 intermedio
            panelC2.BackColor = Color.White;
            btnCobros.BackColor = Color.WhiteSmoke;
            btnCobros.ForeColor = Color.Black;
            btn4.BackColor = Color.WhiteSmoke;
            btn4.ForeColor = Color.White;

          /*  btnCreditoCobrar.BackColor = Color.WhiteSmoke;
            btnCreditoCobrar.ForeColor = Color.Black;
            btnCreditoPagar.BackColor = Color.WhiteSmoke;
            btnCreditoPagar.ForeColor = Color.Black;*/

            //PanelC3
            PanelC3.BackColor = Color.White;
            btnMayoreo.BackColor = Color.WhiteSmoke;
            btnMayoreo.ForeColor = Color.Black;
            btnIngresosCaja.BackColor = Color.WhiteSmoke;
            btnIngresosCaja.ForeColor = Color.Black;
            btnGastos.BackColor = Color.WhiteSmoke;
            btnGastos.ForeColor = Color.Black;
            BtnTecladoV.BackColor = Color.WhiteSmoke;
            BtnTecladoV.ForeColor = Color.Black;
            //PanelC4 pie de pagina
            panelC4.BackColor = Color.Gainsboro;
            btnespera.BackColor = Color.Gainsboro;
            btnespera.ForeColor = Color.Black;
            btnrestaurar.BackColor = Color.Gainsboro;
            btnrestaurar.ForeColor = Color.Black;
            btneliminar.BackColor = Color.Gainsboro;
            btneliminar.ForeColor = Color.Black;
            btndevoluciones.BackColor = Color.Gainsboro;
            btndevoluciones.ForeColor = Color.Black;

            //PanelOperaciones
            PanelOperaciones.BackColor = Color.White;

            txt_total_suma.ForeColor = Color.Black;
            //PanelBienvenida
            panelBienvenida.BackColor = Color.White;
            label8.ForeColor = Color.FromArgb(64, 64, 64);
            Listarproductosagregados();


        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int idRol;
            string Rol;
            string modulo;
            string Operacion;

            foreach (DataGridViewRow row in datalistadousuario.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario_que_inicio_sesion == idusuarioBuscar)
                {
                    if (modulo == "Cotizacion")
                    {
                        if (Operacion == "ACCESO")
                        {
                            Cotizacion.Cotizaciones frm = new Cotizacion.Cotizaciones();
                            frm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Acceso restringido\nComunicate con tu administrador", "Panel de Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

            }
          
        }

        private void button6_Click(object sender, EventArgs e)
        {

            Cotizaciones_En_Espera frm = new Cotizaciones_En_Espera();
            frm.FormClosing += Frm_FormClosing1;
            frm.ShowDialog();
        }

        private void datalistadocotizacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Pedidos_En_Espera frm = new Pedidos_En_Espera();
            frm.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "0";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int idRol;
            string Rol;
            string modulo;
            string Operacion;

            foreach (DataGridViewRow row in datalistadousuario.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario_que_inicio_sesion == idusuarioBuscar)
                {
                    if (modulo == "Compras")
                    {
                        if (Operacion == "ACCESO")
                        {
                            Compras_proveedor.Compras_proveedor frm = new Compras_proveedor.Compras_proveedor();
                            frm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Acceso restringido\nComunicate con tu administrador", "Panel de Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

            }
          
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            string numero;
            bool entero = true;


            numero = txtCantidad.Text;

            char[] test = numero.ToCharArray();

            for (int i = 0; i < test.Length; i++)
            {
                if (test[i] == '.')
                {
                    entero = false;
                }
            }

            if (entero)
            {
                txtpantalla = Convert.ToInt32(numero);
            }
            else
            {
                txtpantalla = Convert.ToDouble(numero);
            }
            PANELGRANEL.Visible = false;
            PANELGRANEL.BringToFront();
            txtCantidad.Focus();
            DATALISTADO_PRODUCTOS_OKA.Visible = false;
            ejecutar_ventas_a_granel();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

            calcularTotal();
        }
        private void calcularTotal()
        {
            try
            {
                double total;
                double cantidad;
                cantidad = Convert.ToDouble(txtCantidad.Text);
                total = txtprecio_unitario * cantidad;
                txttotal.Text = Convert.ToString(total);
                txtprecio_unitario2.Text= txttotal.Text;
            }
            catch (Exception)
            {

            }

        }

        private void PANELGRANEL_Paint(object sender, PaintEventArgs e)
        {
            //txtCantidad.Clear();
            //txttotal.Clear();
           // txtprecio_unitario2.Text = "0";
            //stockgranel.Text = "0";
            txtprecio_unitario2.Text = Convert.ToString(txtprecio_unitario);
            stockgranel.Text = Convert.ToString(lblStock_de_Productos);
        }

        private void btnCancelarGRANEL_Click(object sender, EventArgs e)
        {
            PANELGRANEL.Visible = false;
            txtbuscar.Focus();
            txtbuscar.SelectAll();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int idRol;
            string Rol;
            string modulo;
            string Operacion;

            foreach (DataGridViewRow row in datalistadousuario.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario_que_inicio_sesion == idusuarioBuscar)
                {
                    if (modulo == "Productos")
                    {
                        if (Operacion == "ACCESO")
                        {
                            PRODUCTOS_OK.Productos_ok frm = new PRODUCTOS_OK.Productos_ok();
                            frm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Acceso restringido\nComunicate con tu administrador", "Panel de Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

            }
            
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txtCantidad, e);

        }

        private void button12_Click(object sender, EventArgs e)
        {
            Presentacion.Pagos.Pagos frm = new Presentacion.Pagos.Pagos();
            frm.ShowDialog();
        }
    }
}