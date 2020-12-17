using System;
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
using SistemaVentas.CONEXION;

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
        public int idProductoSelectL;
        public double precioNuevo;
        int contador_stock_detalle_de_venta;
        double precio;
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

        private void VENTAS_MENU_PRINCIPALOK_Load(object sender, EventArgs e)
        {
            pictureBox5.Enabled = false;
            panelListaPrecios.Visible = false;
            ListaPreciosAlPorMayor.Visible = false;

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
            }
            else
            {
                lbltipodebusqueda2.Text = "Buscar con LECTORA de Codigos de Barras";
            }
            //ValidarTemaCaja();
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
                            wrapperProduct.Enabled = true;
                        }
                        else
                        {
                            wrapperProduct.Enabled = false;
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
                //panel3.Visible = false;
            }
            else
            {
                //   panel3.Visible = true;
                //   CantidadCotizaciones.Text = contadorCotizacionesEspera.ToString();
            }
        }
        private void ValidarTemaCaja()
        {
            Obtener_datos.mostrarTemaCaja(ref Tema);
            if (Tema == "Redentor")
            {
                TemaClaro();
                //IndicadorTema.Checked = false;
            }
            else
            {
                TemaOscuro();
                //IndicadorTema.Checked = true;

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
            totalsub.Text = "0.00";
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
                x = tablaProductos.Rows.Count;
                if (x == 0)
                {
                    txt_total_suma.Text = "0.00";
                    totalsub.Text = "0.00";
                    lblItbiss.Text = "0.00";
                    lblsubtotal.Text = "0.00";
                }

                double totalpagar;
                subtotal = 0;
                preciounitario = 0;
                cantidad = 0;
                preciounitario = 0;
                totalpagar = 0;
                foreach (DataGridViewRow fila in tablaProductos.Rows)
                {
                    totalpagar += Convert.ToDouble(fila.Cells["Importe"].Value);
                    txt_total_suma.Text = Convert.ToString(totalpagar + Convert.ToDouble(lblItbiss.Text));
                    totalsub.Text = txt_total_suma.Text;
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
                x = tablaProductos.Rows.Count;
                if (x == 0)
                {
                    lblsubtotal.Text = "0.00";
                    txt_total_suma.Text = "0.00";
                    totalsub.Text = "0.00";
                    lblItbiss.Text = "0.00";
                }

                subtotal = 0;
                foreach (DataGridViewRow fila in tablaProductos.Rows)
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
                x = tablaProductos.Rows.Count;
                if (x == 0)
                {
                    lblsubtotal.Text = "0.00";
                    txt_total_suma.Text = "0.00";
                    totalsub.Text = "0.00";
                    lblItbiss.Text = "0.00";
                }

                subtotal = 0;
                foreach (DataGridViewRow fila in tablaProductos.Rows)
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
                x = tablaProductos.Rows.Count;
                if (x == 0)
                {
                    lblsubtotal.Text = "0.00";
                    txt_total_suma.Text = "0.00";
                    totalsub.Text = "0.00";
                    lblItbiss.Text = "0.00";
                }

                double descuento;
                descuento = 0;
                foreach (DataGridViewRow fila in tablaProductos.Rows)
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
            //panel_mostrador_de_productos.Size = new System.Drawing.Size(600, 186);
            //panel_mostrador_de_productos.BackColor = Color.White;
            //panel_mostrador_de_productos.Location = new Point(panelReferenciaProductos.Location.X, panelReferenciaProductos.Location.Y);
            //panel_mostrador_de_productos.Visible = true;
            DATALISTADO_PRODUCTOS_OKA.Visible = true;
            //  DATALISTADO_PRODUCTOS_OKA.Dock = DockStyle.Fill;
            DATALISTADO_PRODUCTOS_OKA.BackgroundColor = Color.White;
            DATALISTADO_PRODUCTOS_OKA.BringToFront();
            lbltipodebusqueda2.Visible = false;
            /* panel_mostrador_de_productos.Controls.Add(DATALISTADO_PRODUCTOS_OKA);
             this.Controls.Add(panel_mostrador_de_productos);
             panel_mostrador_de_productos.BringToFront();
             */
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
            PANELGRANEL.Visible = true;
            vender_por_teclado();
            ValidarVentasNuevas();
        }

        public void ValidarVentasNuevas()
        {
            if (tablaProductos.RowCount == 0)
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
            ImpuestoCategoria = Convert.ToDouble(DATALISTADO_PRODUCTOS_OKA.SelectedCells[11].Value);
            DescuentoCategoria = Convert.ToDouble(DATALISTADO_PRODUCTOS_OKA.SelectedCells[12].Value);
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
            PANELGRANEL.BringToFront();
            PANELGRANEL.Visible = true;
            DATALISTADO_PRODUCTOS_OKA.Visible = false;
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
        public void HideWidthColumns()
        {

            tablaProductos.Columns[0].Width = 100;
            tablaProductos.Columns[1].Width = 100;
            tablaProductos.Columns[2].Width = 100;
            tablaProductos.Columns[4].Width = 150;
            tablaProductos.Columns[5].Width = 90;
            tablaProductos.Columns[6].Width = 100;
            tablaProductos.Columns[16].Width = 8;
            tablaProductos.Columns[17].Width = 8;
            tablaProductos.Columns[18].Width = 90;
            tablaProductos.Columns[20].Width = 150;
            tablaProductos.Columns[3].Visible = false;
            tablaProductos.Columns[8].Visible = false;
            tablaProductos.Columns[9].Visible = false;
            tablaProductos.Columns[10].Visible = false;
            tablaProductos.Columns[11].Visible = false;
            tablaProductos.Columns[12].Visible = false;
            tablaProductos.Columns[13].Visible = false;
            tablaProductos.Columns[14].Visible = false;
            tablaProductos.Columns[15].Visible = false;
            tablaProductos.Columns[16].Visible = false;
            tablaProductos.Columns[17].Visible = false;
            tablaProductos.Columns[20].Visible = false;
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
                tablaProductos.DataSource = dt;
                HideWidthColumns();
                con.Close();
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
            // LBL
            try
            {
                double aux = Convert.ToDouble(txtpantalla);
                // if()
                aux /= 2;
                if (lblStock_de_Productos >= txtpantalla)
                {
                    // MessageBox.Show(txtpantalla.ToString() + "insertar_detalle_venta vvv");

                    insertar_detalle_venta_Validado();
                }
                else
                {
                    TimerLABEL_STOCK.Start();
                }
                // insertar_detalle_venta_SIN_VALIDAR();

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
                #region insertarDetalleVenta
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
                cmd.Parameters.AddWithValue("@itbis_calculado", (Convert.ToDecimal(lblitbis_.Text) / 100));
                cmd.ExecuteNonQuery();
                con.Close();
                disminuir_stock_en_detalle_de_venta();
            #endregion
                //ObtenerUltimoDetalleFactutra
                #region obtenerDetalleFactura
                CONEXIONMAESTRA.abrir();
                SqlCommand com = new SqlCommand("ObtenerUltimoDetalleFactura", CONEXIONMAESTRA.conectar);
                com.CommandType = CommandType.StoredProcedure;
                int idkey = Convert.ToInt32(com.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();
                #endregion
                #region ListaPrecios
                //InsertarAuxParaListaPrecios
                SqlConnection cone = new SqlConnection();
                cone.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                SqlCommand command = new SqlCommand();
                command = new SqlCommand("insertAux", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idFactura", idVenta);
                command.Parameters.AddWithValue("@idProducto", idproducto);
                command.Parameters.AddWithValue("@idDetalleFactura", idkey);
                command.ExecuteNonQuery();
                con.Close();
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + ex.Message);
            }


        }

        private void insertar_detalle_venta_SIN_VALIDAR()
        {/*
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
            }*/
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
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
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
            catch (Exception ex)
            {
                //       MessageBox.Show(ex.Message);
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
            catch (Exception ex)
            {
                //   MessageBox.Show(ex.Message);
            }
        }
        private void editar_detalle_venta_sumar()
        {
            //ACA

            //lblStock_de_Productos = Convert.ToDouble(tablaProductos.SelectedCells[15].Value.ToString());
            if (lblStock_de_Productos > 0)
            {
                //SUMAR ERROR
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
                cmd.Parameters.AddWithValue("@idProducto", idproducto);
                cmd.Parameters.AddWithValue("@cantidad", txtpantalla);
                cmd.ExecuteNonQuery();
                CONEXION.CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                //   MessageBox.Show(ex.Message);
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
            x = tablaProductos.Rows.Count;
            Contador = (x);
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

        }

        private void BotonCantidad()
        {
            double MontoaIngresar;
            MontoaIngresar = Convert.ToDouble(txtmonto.Text);
            double Cantidad;
            Cantidad = Convert.ToDouble(tablaProductos.SelectedCells[5].Value);

            double stock;
            double condicional;
            stock = Convert.ToDouble(tablaProductos.SelectedCells[11].Value);
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

        private void BotonDescuento()
        {
            double MontoaIngresar;
            MontoaIngresar = Convert.ToDouble(txtmonto.Text);
            double Cantidad;
            Cantidad = Convert.ToDouble(tablaProductos.SelectedCells[18].Value);
            double stock;
            double condicional;
            string ControlStock;
            stock = Convert.ToDouble(tablaProductos.SelectedCells[11].Value);
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
        private void BotonCantidadEjecuta()
        {
            double MontoaIngresar;
            MontoaIngresar = Convert.ToDouble(txtmonto.Text);
            double Cantidad;
            Cantidad = Convert.ToDouble(tablaProductos.SelectedCells[5].Value);

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

        }
        private void Frm_FormClosing1(object sender, FormClosingEventArgs e)
        {
            Listarproductosagregados();
            mostrar_panel_de_Cobro();
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

        private void editarVentaEspera()

        {
            Editar_datos.ingresar_nombre_a_venta_en_espera(idVenta, txtnombre.Text);
            Limpiar_para_venta_nueva();
            ocularPanelenEspera();
        }

        private void VENTAS_MENU_PRINCIPALOK_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnMayoreo_Click(object sender, EventArgs e)
        {
            aplicar_precio_mayoreo();
        }
        private void aplicar_precio_mayoreo()
        {
            if (tablaProductos.Rows.Count > 0)
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


        /*
        private void IndicadorTema_CheckedChanged(object sender, EventArgs e)
        {
            if (IndicadorTema.Checked == true)
            {
                Tema = "Oscuro";
                EditarTemaCaja();
                TemaOscuro();
                Listarproductosagregados();
            }
            else
            {
                Tema = "Redentor";
                EditarTemaCaja();
                TemaClaro();
                Listarproductosagregados();
            }
        }
        */

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
            txtbuscar.BackColor = Color.FromArgb(20, 20, 20);
            txtbuscar.ForeColor = Color.White;
            lbltipodebusqueda2.BackColor = Color.FromArgb(20, 20, 20);
            //PanelC2 Intermedio


            /*btnCreditoCobrar.BackColor = Color.FromArgb(45, 45, 45);
            btnCreditoCobrar.ForeColor = Color.White;
            btnCreditoPagar.BackColor = Color.FromArgb(45, 45, 45);
            btnCreditoPagar.ForeColor = Color.White;
            */
          
            //wrapperProduct Pie de pagina
            //PanelOperaciones
            PanelOperaciones.BackColor = Color.FromArgb(35, 35, 35);
            txt_total_suma.ForeColor = Color.WhiteSmoke;
            //PanelBienvenida
            panelBienvenida.BackColor = Color.FromArgb(35, 35, 35);
            label8.ForeColor = Color.WhiteSmoke;
            Listarproductosagregados();
        }
        private void TemaClaro()
        {
            //PanelC1 encabezado
            label9.ForeColor = Color.Black;
            label9.BackColor = Color.White;
            PanelC1.BackColor = Color.White;
            txtbuscar.BackColor = Color.White;
            txtbuscar.ForeColor = Color.Black;
            lbltipodebusqueda2.BackColor = Color.White;

            //PanelC2 intermedio

            /*  btnCreditoCobrar.BackColor = Color.WhiteSmoke;
              btnCreditoCobrar.ForeColor = Color.Black;
              btnCreditoPagar.BackColor = Color.WhiteSmoke;
              btnCreditoPagar.ForeColor = Color.Black;*/

            //wrapperProduct pie de pagina

            //PanelOperaciones
            PanelOperaciones.BackColor = Color.White;

            txt_total_suma.ForeColor = Color.Black;
            //PanelBienvenida
            panelBienvenida.BackColor = Color.White;
            label8.ForeColor = Color.FromArgb(64, 64, 64);
            Listarproductosagregados();


        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "0";
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
                txtprecio_unitario2.Text = txttotal.Text;
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
            txtCantidad.SelectAll();
            txtCantidad.Focus();
            txtprecio_unitario2.Text = Convert.ToString(txtprecio_unitario);
            stockgranel.Text = Convert.ToString(lblStock_de_Productos);
        }




        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txtCantidad, e);

        }

        private void teclado_Click(object sender, EventArgs e)
        {

            lbltipodebusqueda2.Text = "Buscar con TECLADO";
            Tipo_de_busqueda = "TECLADO";
            // BTNTECLADO.BackColor = Color.LightGreen;
            //BTNLECTORA.BackColor = Color.WhiteSmoke;
            txtbuscar.Clear();
            txtbuscar.Focus();
        }

        private void lector_Click(object sender, EventArgs e)
        {
            lbltipodebusqueda2.Text = "Buscar con LECTORA de Codigos de Barras";
            Tipo_de_busqueda = "LECTORA";
            //BTNLECTORA.BackColor = Color.LightGreen;
            //BTNTECLADO.BackColor = Color.WhiteSmoke;
            txtbuscar.Clear();
            txtbuscar.Focus();

        }


        #region btnVolverPanelVentasEspera
        private void btnVolverPanelVentasEspera_Click(object sender, EventArgs e)
        {
            ocularPanelenEspera();

        }
        #endregion
        #region botonGuardarVentaEspera
        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
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

        #endregion
        #region btnGenerarCodigoAutomatico
        private void gunaAdvenceButton1_Click_1(object sender, EventArgs e)
        {
            txtnombre.Text = "Ticket" + idVenta;
            editarVentaEspera();
        }
        #endregion

        /// <summary>
        /// Agregar productos a ventas.
        /// </summary>
        #region btnAgregarProductos
        private void btnAgregarProductos_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text != "")
            {
                string numero;
                bool entero = true;
                double variable = Convert.ToDouble(txtCantidad.Text);
                variable *= 2;
                numero = Convert.ToString(variable);
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
        }
        #endregion
        #region btnCancelarAgregarProductosGranel
        private void btnCancelarAgregarProductosGRANEL_Click(object sender, EventArgs e)
        {
            PANELGRANEL.Visible = false;
            txtbuscar.Focus();
            txtbuscar.SelectAll();
        }

        #endregion
        //lblStock_de_Productos = Convert.ToDouble(tablaProductos.Rows[e.RowIndex].Cells["Stock"].Value);

        private void tablaProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (tablaProductos.Rows.Count <= 0)
                    return;
                precio = Convert.ToDouble(tablaProductos.Rows[e.RowIndex].Cells["PrecioUnidad"].Value);
                iddetalleventa = Convert.ToInt32(tablaProductos.Rows[e.RowIndex].Cells["iddetalle_factura"].Value);
                idproducto = Convert.ToInt32(tablaProductos.Rows[e.RowIndex].Cells["Id_producto"].Value);
                sevendePor = tablaProductos.Rows[e.RowIndex].Cells["se_vende_a"].Value.ToString();
                cantidad = Convert.ToDouble(tablaProductos.Rows[e.RowIndex].Cells["Cantidad"].Value);
                lblStock_de_Productos = Convert.ToDouble(tablaProductos.Rows[e.RowIndex].Cells["stock"].Value.ToString());
                if (tablaProductos.Rows[e.RowIndex].Cells["s"].Selected)
                {
                    txtpantalla = 1;
                    editar_detalle_venta_sumar();
                }
                if (e.ColumnIndex == this.tablaProductos.Columns["r"].Index)
                {
                    txtpantalla = 1;
                    editar_detalle_venta_restar();
                    EliminarVentas();
                }
                if (e.ColumnIndex == this.tablaProductos.Columns["e"].Index)
                {
                    int iddetalle_venta;
                    if (tablaProductos.Rows[e.RowIndex].Cells["e"].Selected)
                    {

                        iddetalle_venta = Convert.ToInt32(tablaProductos.Rows[e.RowIndex].Cells["iddetalle_factura"].Value);
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
                            idproducto = Convert.ToInt32(tablaProductos.Rows[e.RowIndex].Cells["Id_producto"].Value.ToString());
                            txtpantalla = Convert.ToDouble(tablaProductos.Rows[e.RowIndex].Cells["Cantidad"].Value.ToString());
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }


        private void tablaProductos_KeyPress(object sender, KeyPressEventArgs e)
        {
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

        private void pictureBox9_Click(object sender, EventArgs e)
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

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Presentacion.Pagos.Pagos frm = new Presentacion.Pagos.Pagos();
            frm.ShowDialog();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
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
                    if (modulo == "Proveedores")
                    {
                        if (Operacion == "ACCESO")
                        {
                            showFormInWrapper(new Presentacion.CLIENTES_PROVEEDORES.Proveedores());
                        }
                        else
                        {
                            MessageBox.Show("Acceso restringido\nComunicate con tu administrador", "Panel de Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
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

        private void pictureBox14_Click(object sender, EventArgs e)
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

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            CAJA.Listado_gastos_ingresos frm = new CAJA.Listado_gastos_ingresos();
            frm.ShowDialog();
        }

        private void btnPONERESPERA_Click(object sender, EventArgs e)
        {
            if (tablaProductos.RowCount > 0)
            {
                MOSTRAR_comprobante_serializado_POR_DEFECTO();
                PanelEnespera.Visible = true;
                PanelEnespera.BringToFront();
                PanelEnespera.Dock = DockStyle.Fill;
                txtnombre.Clear();
            }
        }

        private void BTNESPERAA_Click(object sender, EventArgs e)
        {
            Ventas_en_espera frm = new Ventas_en_espera();
            frm.FormClosing += Frm_FormClosing1;
            frm.ShowDialog();
        }

        private void deletefactura_Click(object sender, EventArgs e)
        {
            if (tablaProductos.RowCount > 0)
            {
                DialogResult pregunta = MessageBox.Show("¿Realmente desea eliminar esta Factura?", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (pregunta == DialogResult.OK)
                {
                    Eliminar_datos.eliminar_factura(idVenta);
                    Limpiar_para_venta_nueva();
                }
            }
        }



        private void pictureBox16_Click(object sender, EventArgs e)
        {
            HistorialVentas.HistorialVentasForm frm = new HistorialVentas.HistorialVentasForm();
            frm.ShowDialog();
        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {

        }

        private void btnN1_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "1";

        }

        private void btnN2_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "2";

        }

        private void btnN3_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "3";

        }

        private void btnN4_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "4";
        }

        private void btnN5_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "5";
        }

        private void btnN6_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "6";
        }

        private void btnN7_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "7";
        }

        private void btnN8_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "8";
        }

        private void btnN9_Click(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "9";

        }

        private void btnN0_Click(object sender, EventArgs e)
        {

        }

        private void btnNcoma_Click(object sender, EventArgs e)
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

        private void btnNborrar_Click(object sender, EventArgs e)
        {
            txtmonto.Clear();
            SECUENCIA = true;
        }

        private void btnCambiarCantidad_Click(object sender, EventArgs e)
        {
            if (iddetalleventa == 0)
            {
                MessageBox.Show("Seleccione un producto para realizar la edición", "Editar cantidad del Articulo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (!string.IsNullOrEmpty(txtmonto.Text))
                {
                    if (tablaProductos.RowCount > 0)
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

        private void gunaAdvenceButton2_Click_1(object sender, EventArgs e)
        {

            if (iddetalleventa == 0)
            {
                MessageBox.Show("Seleccione un producto para aplicarle descuento", "Editar descuento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                //MessageBox.Show(precio.ToString());
                if (!string.IsNullOrEmpty(txtmonto.Text))
                {
                    if ((Convert.ToInt32(txtmonto.Text) < precio))
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

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            if (tablaProductos.Rows.Count <= 0)
            {
                animacionCierre();
            }
            else
            {
                LVentasPrecios lVentasPrecios = new LVentasPrecios();
                panelListaPrecios.Visible = true;
                panelListaPrecios.BringToFront();
                txtProductoL.DataSource = lVentasPrecios.CargarCombo(idVenta);
                txtProductoL.DisplayMember = "Producto";
                txtProductoL.ValueMember = "idProducto";
            }
        }
        private Form FormActive = null;

        private void showFormInWrapper(Form FormSon)
        {
            if (FormActive != null)
                FormActive.Close();
            FormActive = FormSon;
            FormSon.TopLevel = false;
            FormSon.Dock = DockStyle.Fill;
            wrapper.Controls.Add(FormSon);
            wrapper.Tag = FormSon;
            FormSon.BringToFront();
            FormSon.Show();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (tablaProductos.Rows.Count == 0)
            {

            }
            else
            {
                selectedBotons((Bunifu.Framework.UI.BunifuFlatButton)sender);
                arrowGuide((Bunifu.Framework.UI.BunifuFlatButton)sender);
                total = Convert.ToDouble(txt_total_suma.Text);
                showFormInWrapper(new Presentacion.VENTAS_MENU_PRINCIPAL.MEDIOS_DE_PAGO());
            }
        }
        public void arrowGuide(Bunifu.Framework.UI.BunifuFlatButton sender)
        {
            //arrow.Top = sender.Top;
        }
        public void selectedBotons(Bunifu.Framework.UI.BunifuFlatButton sender)
        {
        }

        private void PanelEnespera_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelListaPrecios_Paint(object sender, PaintEventArgs e)
        {
            idProductoSelectL = Convert.ToInt32(txtProductoL.SelectedValue.ToString());
            LVentasPrecios lVentasPrecios = new LVentasPrecios();
            DataTable dt = new DataTable();
            dt = lVentasPrecios.CargarComboLista(idProductoSelectL);
            listapreciosdt.DataSource = dt;

            //MessageBox.Show(idProductoSelectL.ToString());
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            if (tablaProductos.Rows.Count <= 0)
            {
                animacionCierre();
            }
            else
            {
                LVentasPrecios lVentasPrecios = new LVentasPrecios();
                panelListaPrecios.Visible = true;
                panelListaPrecios.BringToFront();
                txtProductoL.DataSource = lVentasPrecios.CargarCombo(idVenta);
                txtProductoL.DisplayMember = "Producto";
                txtProductoL.ValueMember = "idProducto";
            }

        }
        private void animacionCierre()
        {
            try
            {
                NOTIFICACIONES.Notificacion.confirmarForm("PRIMERO AGREGA UN PRODUCTO");
                txtbuscar.Focus();
                txtbuscar.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el registro" + ex);
            }
        }

        private void gunaAdvenceButton1_Click_2(object sender, EventArgs e)
        {
            panelListaPrecios.Visible = false;
        }
        int cont = 0;
        private int idProductoSelectM;

        private void txtProductoL_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPrecioL.Items.Clear();
            ObtenerListaDePrecios_por_Productos();
        }

        private void ObtenerListaDePrecios_por_Productos()
        {
            double precio;

            if (listapreciosdt.Rows.Count > 0)
            {
                precio = Convert.ToDouble(listapreciosdt.CurrentRow.Cells[0].Value);
                txtPrecioL.Items.Add(precio.ToString());
                precio = Convert.ToDouble(listapreciosdt.CurrentRow.Cells[1].Value);
                txtPrecioL.Items.Add(precio.ToString());
                precio = Convert.ToDouble(listapreciosdt.CurrentRow.Cells[2].Value);
                txtPrecioL.Items.Add(precio.ToString());
                precio = Convert.ToDouble(listapreciosdt.CurrentRow.Cells[3].Value);
                txtPrecioL.Items.Add(precio.ToString());

            }
        }

        private void btnCambiarPrecio_Click(object sender, EventArgs e)
        {
            //double precio = Convert.ToDouble(tablaProductos.SelectedCells[5].Value);
            CONEXIONMAESTRA.abrir();
            SqlCommand com = new SqlCommand("ObtenerDetalleVenta", CONEXIONMAESTRA.conectar);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@idFactura", idVenta);
            com.Parameters.AddWithValue("@idProducto", idProductoSelectL);
             iddetalleventa = Convert.ToInt32(com.ExecuteScalar());
            CONEXIONMAESTRA.cerrar();
          /*  MessageBox.Show(idVenta.ToString());
            MessageBox.Show(idProductoSelectL.ToString());
            MessageBox.Show(iddetalleventa.ToString());
            MessageBox.Show(precioNuevo.ToString());*/
            if (iddetalleventa == 0)
            {
                MessageBox.Show("Seleccione un producto para realizar la edición", "Editar precio del Articulo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (precioNuevo>0)
                {
                    Ldetallefactura parametros = new Ldetallefactura();
                    Editar_datos funcion = new Editar_datos();
                    parametros.iddetalle_factura = iddetalleventa;
                    parametros.preciounitario = precioNuevo;

                    if (funcion.editarPrecioVenta(parametros) == true)
                    {
                        Listarproductosagregados();
                        txtbuscar.Focus();
                        txtbuscar.Clear();
                        panelListaPrecios.Visible = false;
                        txtPrecioL.Items.Clear();
                    }
                }
                
                iddetalleventa = 0;
            }
        }

        private void txtPrecioL_MouseClick(object sender, MouseEventArgs e)
        {
          

        }

        private void txtPrecioL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtPrecioL.Text !="")
            {
                precioNuevo = Convert.ToDouble(txtPrecioL.Text);
                //MessageBox.Show("precio nuevo" + precioNuevo.ToString());
            }
        }

        private void txtPrecioL_Click(object sender, EventArgs e)
        {
          
        }

        private void ListaPreciosAlPorMayor_Paint(object sender, PaintEventArgs e)
        {
            idProductoSelectM = Convert.ToInt32(txtProductoSelectAM.SelectedValue.ToString());
            LVentasPrecios lVentasPrecios = new LVentasPrecios();
            DataTable dt = new DataTable();
            dt = lVentasPrecios.CargarComboLista(idProductoSelectM);
            listapreciosmayor.DataSource = dt;
            DataTable dt_ = new DataTable();
            dt_ = lVentasPrecios.CargarComboListaMayor(idProductoSelectM);
            listaalpormayor.DataSource = dt_;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (tablaProductos.Rows.Count <= 0)
            {
                animacionCierre();
            }
            else
            {
                LVentasPrecios lVentasPrecios = new LVentasPrecios();
                ListaPreciosAlPorMayor.Visible = true;
                ListaPreciosAlPorMayor.BringToFront();

                txtProductoSelectAM.DataSource = lVentasPrecios.CargarCombo(idVenta);
                txtProductoSelectAM.DisplayMember = "Producto";
                txtProductoSelectAM.ValueMember = "idProducto";
            }
        }

        private void btnCancelarPreciosM_Click(object sender, EventArgs e)
        {
            ListaPreciosAlPorMayor.Visible = false;

        }

        private void btnCambioPrecioM_Click(object sender, EventArgs e)
        {
            //double precio = Convert.ToDouble(tablaProductos.SelectedCells[5].Value);
            CONEXIONMAESTRA.abrir();
            SqlCommand com = new SqlCommand("ObtenerDetalleVenta", CONEXIONMAESTRA.conectar);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@idFactura", idVenta);
            com.Parameters.AddWithValue("@idProducto", idProductoSelectL);
            iddetalleventa = Convert.ToInt32(com.ExecuteScalar());
            CONEXIONMAESTRA.cerrar();
            /*  MessageBox.Show(idVenta.ToString());
              MessageBox.Show(idProductoSelectL.ToString());
              MessageBox.Show(iddetalleventa.ToString());
              MessageBox.Show(precioNuevo.ToString());*/
            if (iddetalleventa == 0)
            {
                MessageBox.Show("Seleccione un producto para realizar la edición", "Editar precio del Articulo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (Convert.ToDouble(lblPrecioAlPorMayor.Text) > 0.00)
                {
                    Ldetallefactura parametros = new Ldetallefactura();
                    Editar_datos funcion = new Editar_datos();
                    parametros.iddetalle_factura = iddetalleventa;
                    parametros.preciounitario =Convert.ToDouble( lblPrecioAlPorMayor.Text);
                    if (funcion.editarPrecioVenta(parametros))
                    {
                        //funcion.editarCantidad
                        Listarproductosagregados();
                        txtbuscar.Focus();
                        txtbuscar.Clear();
                        ListaPreciosAlPorMayor.Visible = false;
                        txtNoUnidades.Items.Clear();
                    }
                }
                iddetalleventa = 0;
            }
        }

        private void txtNoUnidades_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(txtNoUnidades.SelectedIndex == 0)
            {
                lblPrecioAlPorMayor.Text = (listapreciosmayor.CurrentRow.Cells[0].Value).ToString();
                lblCantidadNueva.Text = (listaalpormayor.CurrentRow.Cells[0].Value).ToString();
            }
            if (txtNoUnidades.SelectedIndex == 1)
            {
                lblPrecioAlPorMayor.Text = (listapreciosmayor.CurrentRow.Cells[1].Value).ToString();
                lblCantidadNueva.Text = (listaalpormayor.CurrentRow.Cells[1].Value).ToString();

            }
            if (txtNoUnidades.SelectedIndex == 2)
            {
                lblPrecioAlPorMayor.Text = (listapreciosmayor.CurrentRow.Cells[2].Value).ToString();
                lblCantidadNueva.Text = (listaalpormayor.CurrentRow.Cells[2].Value).ToString();

            }
            if (txtNoUnidades.SelectedIndex == 3)
            {
                lblPrecioAlPorMayor.Text = (listapreciosmayor.CurrentRow.Cells[3].Value).ToString();
                lblCantidadNueva.Text = (listaalpormayor.CurrentRow.Cells[3].Value).ToString();

            }

        }

        private void txtProductoSelectAM_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNoUnidades.Items.Clear();
            obtenerListaDeAlPorMayor();
        }

        private void obtenerListaDeAlPorMayor()
        {
            double unidades;

            if (listaalpormayor.Rows.Count > 0 && listapreciosmayor.Rows.Count > 0)
            {
                /*    precio = Convert.ToDouble(listapreciosmayor.CurrentRow.Cells[0].Value);
                    txt.Items.Add(precio.ToString());
                    precio = Convert.ToDouble(listapreciosmayor.CurrentRow.Cells[1].Value);
                    txtPrecioL.Items.Add(precio.ToString());
                    precio = Convert.ToDouble(listapreciosmayor.CurrentRow.Cells[2].Value);
                    txtPrecioL.Items.Add(precio.ToString());
                    precio = Convert.ToDouble(listapreciosmayor.CurrentRow.Cells[3].Value);
                    txtPrecioL.Items.Add(precio.ToString());
                */
                unidades = Convert.ToDouble(listaalpormayor.CurrentRow.Cells[0].Value);
                txtNoUnidades.Items.Add("1");
                unidades = Convert.ToDouble(listaalpormayor.CurrentRow.Cells[1].Value);
                txtNoUnidades.Items.Add(unidades.ToString());
                unidades = Convert.ToDouble(listaalpormayor.CurrentRow.Cells[2].Value);
                txtNoUnidades.Items.Add(unidades.ToString());
                unidades = Convert.ToDouble(listaalpormayor.CurrentRow.Cells[3].Value);
                txtNoUnidades.Items.Add(unidades.ToString());
            }
        }
    }
}

