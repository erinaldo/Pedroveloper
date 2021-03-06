using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using SistemaVentas.Logica;
using SistemaVentas.Datos;

namespace SistemaVentas.Presentacion.Cotizacion
{
    public partial class Cotizaciones : Form
    {
        public Cotizaciones()
        {
            InitializeComponent();
        }

        public static string txtdescripcion;
        double ImpuestoProducto;
        double ImpuestoCategoria;
        double DescuentoCategoria;
        double DescuentoProducto;
        // -------------- Variables --------------
        int contador_stock_detalle_de_venta;
        int idproducto;
        int idClienteEstandar;
        public static int idusuario_que_inicio_sesion;
        public static int idCotizacion;
        int iddetallecotizacion;
        int Contador;
        public static double txtpantalla;
        double lblStock_de_Productos;
        public static double total;
        public static int Id_caja = VENTAS_MENU_PRINCIPAL.VENTAS_MENU_PRINCIPALOK.Id_caja;
        string SerialPC;
        private string unidadVenta;
        string sevendePor;
        public static string txtventagenerada;
        double txtprecio_unitario;
        string Ip;
        double cantidad;
        Panel panel_mostrador_de_productos = new Panel();



        private void VENTAS_MENU_PRINCIPALOK_Load(object sender, EventArgs e)
        {
            btnCambiarCantidad.Enabled = false;
            btnDescuento.Enabled = false;
            btnPrecio.Enabled = false;

            PanelEnespera.Visible = false;
            txttotal.Enabled = false;
            MOSTRAR_comprobante_serializado_POR_DEFECTO();
            PANELGRANEL.Visible = false;

            Bases.Cambiar_idioma_regional();
            Bases.Obtener_serialPC(ref SerialPC);

            Obtener_datos.Obtener_id_caja_PorSerial(ref Id_caja);
            MOSTRAR_TIPO_DE_BUSQUEDA();
            Obtener_id_de_cliente_estandar();
            Obtener_datos.mostrar_inicio_De_sesion(ref idusuario_que_inicio_sesion);

            if (Tipo_de_busqueda == "TECLADO")
            {
                lbltipodebusqueda2.Text = "Buscar con TECLADO";
            }
            else
            {
                lbltipodebusqueda2.Text = "Buscar con LECTORA de Codigos de Barras";
            }
            Limpiar_para_venta_nueva();
            ObtenerIpLocal();
        }

        private void ObtenerIpLocal()
        {

            this.Text = Bases.ObtenerIp(ref Ip);
        }

        private void Limpiar_para_venta_nueva()
        {
            idCotizacion = 0;
            Listarproductosagregados();
            txtventagenerada = "COTIZACION NUEVA";
            sumarItbis();
            sumar();
            sumar2();
            sumarDescuentos();
            lblsubtotal.Text = "0.00";
            lbldescuento.Text = "0.00";
            txt_total_suma.Text = "0.00";
            lblItbiss.Text = "0.00";
            //       panelBienvenida.Visible = true;
            PanelOperaciones.Visible = false;
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
                    lblItbiss.Text = "0.00";
                    lblsubtotal.Text = "0.00";
                }
                double preciounitario;
                double cantidad;
                double itbis1;
                subtotal = 0.0;
                preciounitario = 0;
                cantidad = 0;
                preciounitario = 0;
                itbis1 = 0;
                double descuento = 0;
                double totalpagar;
                totalpagar = 0;
                foreach (DataGridViewRow fila in tablaProductos.Rows)
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

        private void sumar2()
        {
            try
            {
                int x;
                x = tablaProductos.Rows.Count;
                if (x == 0)
                {
                    lblsubtotal.Text = "0.00";
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

        private void mostrar_productos()
        {
            //panel_mostrador_de_productos.Size = new System.Drawing.Size(600, 186);
            //panel_mostrador_de_productos.BackColor = Color.White;
            //panel_mostrador_de_productos.Location = new Point(panelReferenciaProductos.Location.X, panelReferenciaProductos.Location.Y);
            //panel_mostrador_de_productos.Visible = true;
            DATALISTADO_PRODUCTOS_OKA.Visible = true;
            //  DATALISTADO_PRODUCTOS_OKA.Dock = DockStyle.Fill;
            DATALISTADO_PRODUCTOS_OKA.BackgroundColor = Color.White;
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
            // mostramos los registros del producto en el detalle de factura
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

        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ejecutar_ventas_a_granel();
        }

        public void ejecutar_ventas_a_granel()
        {

            ejecutar_insertar_ventas();
            if (txtventagenerada == "COTIZACION GENERADA")
            {
                insertar_detalle_factura();
                Listarproductosagregados();
                txtbuscar.Text = "";
                txtbuscar.Focus();

            }

        }

        private void Obtener_id_de_cliente_estandar()
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
            SqlCommand com = new SqlCommand("select idclientev  from clientes where Estado=0", con);
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
                idCotizacion = Convert.ToInt32(com.ExecuteScalar());
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    if (txtventagenerada == "COTIZACION GENERADA")
                    {
                        insertar_detalle_factura();
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
        private void ejecutar_insertar_ventas()
        {
            // MOSTRAR_comprobante_serializado_POR_DEFECTO();
            if (txtventagenerada == "COTIZACION NUEVA")
            {
                try
                {
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
                    cmd.Parameters.AddWithValue("@ACCION", "COTIZACION");
                    cmd.Parameters.AddWithValue("@Saldo", 0);
                    cmd.Parameters.AddWithValue("@Pago_con", 0);
                    cmd.Parameters.AddWithValue("@Id_caja", Id_caja);
                    cmd.Parameters.AddWithValue("@Referencia_tarjeta", 0);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Obtener_id_venta_recien_Creada();
                    txtventagenerada = "COTIZACION GENERADA";
                    mostrar_panel_de_Cobro();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
        private void mostrar_panel_de_Cobro()
        {
            //  panelBienvenida.Visible = false;
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
                da.SelectCommand.Parameters.AddWithValue("@idfactura", idCotizacion);
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
        private void sumarItbis()
        {
            try
            {

                int x;
                x = tablaProductos.Rows.Count;
                if (x == 0)
                {
                    lblsubtotal.Text = "0.00";
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
        private void insertar_detalle_factura()
        {
            try
            {
                if (lblStock_de_Productos >= txtpantalla)
                {
                    insertar_detalle_venta_Validado();
                }
                else
                {
                    TimerLABEL_STOCK.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        private void insertar_detalle_venta_Validado()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("insertar_detalle_factura2", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idfactura", idCotizacion);
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
                //disminuir_stock_en_detalle_de_venta();
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
                cmd.Parameters.AddWithValue("@idfactura", idCotizacion);
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

        private void ejecutar_editar_detalle_venta_sumar()
        {
            try
            {
                SqlCommand cmd;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                cmd = new SqlCommand("Editar_detalle_factura_sumar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_producto", idproducto);
                cmd.Parameters.AddWithValue("@cantidad", txtpantalla);
                cmd.Parameters.AddWithValue("@Id_factura", idCotizacion);
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
                SqlCommand cmd = new SqlCommand("disminuir_stock_en_detalle_de_venta", CONEXION.CONEXIONMAESTRA.conectar);
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
                iddetallecotizacion = Convert.ToInt32(tablaProductos.SelectedCells[9].Value.ToString());
                idproducto = Convert.ToInt32(tablaProductos.SelectedCells[8].Value.ToString());
                sevendePor = tablaProductos.SelectedCells[17].Value.ToString();
                cantidad = Convert.ToDouble(tablaProductos.SelectedCells[5].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Editar_detalle_factura_sumar()
        {

            //    lblStock_de_Productos = Convert.ToDouble(tablaProductos.SelectedCells[15].Value.ToString());
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
        private void Editar_detalle_factura_restar()
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
                cmd = new SqlCommand("Editar_detalle_factura_restar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@iddetalle_factura", iddetallecotizacion);
                cmd.Parameters.AddWithValue("cantidad", txtpantalla);
                cmd.Parameters.AddWithValue("@Id_producto", idproducto);
                cmd.Parameters.AddWithValue("@Id_factura", idCotizacion);
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


            if (e.ColumnIndex == this.tablaProductos.Columns["S"].Index)
            {
                txtpantalla = 1;
                Editar_detalle_factura_sumar();
            }
            if (e.ColumnIndex == this.tablaProductos.Columns["R"].Index)
            {
                txtpantalla = 1;
                Editar_detalle_factura_restar();
                Eliminarfacturas();
            }


            if (e.ColumnIndex == this.tablaProductos.Columns["EL"].Index)
            {

                int iddetalle_cotizacion = Convert.ToInt32(tablaProductos.SelectedCells[9].Value);
                try
                {
                    SqlCommand cmd;
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                    con.Open();
                    cmd = new SqlCommand("eliminar_detalle_factura", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idDetallefactura", iddetalle_cotizacion);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    txtpantalla = Convert.ToDouble(tablaProductos.SelectedCells[5].Value);
                    aumentar_stock_en_detalle_de_venta();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Listarproductosagregados();
                Eliminarfacturas();
            }
        }
        private void Eliminarfacturas()
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
                cmd.Parameters.AddWithValue("@idfactura", idCotizacion);
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


        private void datalistadoDetalleVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            Obtener_datos_del_detalle_de_venta();
            if (e.KeyChar == Convert.ToChar("+"))
            {
                Editar_detalle_factura_sumar();
            }
            if (e.KeyChar == Convert.ToChar("-"))
            {
                Editar_detalle_factura_restar();
                contar_tablas_ventas();
                if (Contador == 0)
                {
                    eliminar_venta_al_agregar_productos();
                    txtventagenerada = "COTIZACION NUEVA";
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
            txtmonto.Text = txtmonto.Text + "0";
        }
        bool SECUENCIA = true;
        private double subtotal;

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
        private void Editar_detalle_factura_cantidad()
        {
            try
            {
                SqlCommand cmd;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                cmd = new SqlCommand("editar_detalle_cotizacion_CANTIDAD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_producto", idproducto);
                cmd.Parameters.AddWithValue("@cantidad", txtmonto.Text);
                cmd.Parameters.AddWithValue("@Id_cotizacion", idCotizacion);
                cmd.ExecuteNonQuery();
                con.Close();
                Listarproductosagregados();
                txtmonto.Clear();
                txtmonto.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Button21_Click(object sender, EventArgs e)
        {
            if (iddetallecotizacion == 0)
            {
                MessageBox.Show("Seleccione un producto para realizar la edición", "Editar cantidad del Articulo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (!string.IsNullOrEmpty(txtmonto.Text))
                {
                    if (tablaProductos.RowCount > 0)
                    {

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
            Cantidad = Convert.ToDouble(tablaProductos.SelectedCells[5].Value);

            double stock;
            double condicional;
            string ControlStock;
            ControlStock = tablaProductos.SelectedCells[16].Value.ToString();
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
                Editar_detalle_factura_sumar();
            }
            else if (MontoaIngresar < Cantidad)
            {
                txtpantalla = Cantidad - MontoaIngresar;
                Editar_detalle_factura_restar();
            }
        }
        private void frm_FormClosed (Object sender, FormClosedEventArgs e)
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
            if (ProgressBarETIQUETA_STOCK.Value <100)
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

   

        private void VENTAS_MENU_PRINCIPALOK_FormClosing(object sender, FormClosingEventArgs e)
        {
               Dispose();
               //Presentacion.VENTAS_MENU_PRINCIPAL.VENTAS_MENU_PRINCIPALOK frm = new Presentacion.VENTAS_MENU_PRINCIPAL.VENTAS_MENU_PRINCIPALOK();
               //frm.ShowDialog();
        }

        private void VENTAS_MENU_PRINCIPALOK_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
      

        private void datalistadoDetalleVenta_Click(object sender, EventArgs e)
        {

        }

        private void btnprecio_Click(object sender, EventArgs e)
        {
            //double precio = Convert.ToDouble(tablaProductos.SelectedCells[5].Value);
            if (iddetallecotizacion == 0)
            {
                MessageBox.Show("Seleccione un producto para realizar la edición", "Editar precio del Articulo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (!string.IsNullOrEmpty(txtmonto.Text))
                {
                    Ldetallefactura parametros = new Ldetallefactura();
                    Editar_datos funcion = new Editar_datos();
                    parametros.iddetalle_factura = iddetallecotizacion;
                    parametros.preciounitario = Convert.ToDouble(txtmonto.Text);
                    if (funcion.editarPrecioVenta(parametros) == true)
                    {
                        Listarproductosagregados();
                    }
                }
                txtmonto.Focus();
                txtmonto.Clear();
                iddetallecotizacion = 0;
            }
        }

        private void btn0_Click_1(object sender, EventArgs e)
        {
            txtmonto.Text = txtmonto.Text + "0";

        }
        private void sumarDescuentos()
        {
            try
            {

                int x;
                x = tablaProductos.Rows.Count;
                if (x == 0)
                {
                    txt_total_suma.Text = "0.00";
                }

                double descuento;
                descuento = 0;
                foreach (DataGridViewRow fila in tablaProductos.Rows)
                {

                    descuento += Convert.ToDouble(fila.Cells["Descuento"].Value);
                    lbldescuento.Text = Convert.ToString(descuento);
                    //  lblsubtotal.Text = lbldescuento.Text;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {

            if (iddetallecotizacion == 0)
            {
                MessageBox.Show("Seleccione un producto para aplicarle descuento", "Editar descuento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                double precio = Convert.ToDouble(tablaProductos.SelectedCells[6].Value);
                //MessageBox.Show(precio.ToString());
                if (!string.IsNullOrEmpty(txtmonto.Text))
                {
                    if ((Convert.ToInt32(txtmonto.Text) < precio))
                    {
                        Ldetallefactura parametros = new Ldetallefactura();
                        Editar_datos funcion = new Editar_datos();
                        parametros.iddetalle_factura = iddetallecotizacion;
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
                iddetallecotizacion = 0;
                txtmonto.Focus();
                txtmonto.Clear();
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

      
        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void txtbuscar_TextChanged_1(object sender, EventArgs e)
        {
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

        private void teclado_Click(object sender, EventArgs e)
        {

            lbltipodebusqueda2.Text = "Buscar con LECTORA de Codigos de Barras";
            Tipo_de_busqueda = "LECTORA";
            txtbuscar.Clear();
            txtbuscar.Focus();
        }

        private void lector_Click(object sender, EventArgs e)
        {

            lbltipodebusqueda2.Text = "Buscar con  TECLADO";
            Tipo_de_busqueda = "TECLADO";
            txtbuscar.Clear();
            txtbuscar.Focus();
        }

        private void txtCantidad_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txtCantidad, e);

        }

        private void txtCantidad_TextChanged_1(object sender, EventArgs e)
        {
            calcularTotal();
        }

        private void btnAgregarProductos_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text != "")
            {
                string numero;
                bool entero = true;
                double variable = Convert.ToDouble(txtCantidad.Text);
                variable *= 1;
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

        private void btnCancelarAgregarProductosGRANEL_Click(object sender, EventArgs e)
        {

            PANELGRANEL.Visible = false;
            txtbuscar.Focus();
            txtbuscar.SelectAll();
        }

        private void PANELGRANEL_Paint(object sender, PaintEventArgs e)
        {
            txtCantidad.SelectAll();
            txtCantidad.Focus();
            txtprecio_unitario2.Text = Convert.ToString(txtprecio_unitario);
            stockgranel.Text = Convert.ToString(lblStock_de_Productos);
        }

        private void tablaProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (tablaProductos.Rows.Count <= 0)
                    return;
                iddetallecotizacion = Convert.ToInt32(tablaProductos.Rows[e.RowIndex].Cells["iddetalle_factura"].Value);
                idproducto = Convert.ToInt32(tablaProductos.Rows[e.RowIndex].Cells["Id_producto"].Value);
                sevendePor = tablaProductos.Rows[e.RowIndex].Cells["se_vende_a"].Value.ToString();
                cantidad = Convert.ToDouble(tablaProductos.Rows[e.RowIndex].Cells["Cantidad"].Value);
                lblStock_de_Productos = Convert.ToDouble(tablaProductos.Rows[e.RowIndex].Cells["stock"].Value.ToString());
                if (tablaProductos.Rows[e.RowIndex].Cells["s"].Selected)
                {
                    txtpantalla = 1;
                    Editar_detalle_factura_sumar();
                }
                if (e.ColumnIndex == this.tablaProductos.Columns["r"].Index)
                {
                    txtpantalla = 1;
                    Editar_detalle_factura_restar();
                    EliminarCotizacion();
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
                        EliminarCotizacion();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        private void EliminarCotizacion()
        {
            contar_tablas_ventas();
            if (Contador == 0)
            {
                eliminar_venta_al_agregar_productos();
                Limpiar_para_venta_nueva();
            }
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
            if (iddetallecotizacion == 0)
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

        private void btnPrecio_Click_1(object sender, EventArgs e)
        {
            //double precio = Convert.ToDouble(tablaProductos.SelectedCells[5].Value);
            if (iddetallecotizacion == 0)
            {
                MessageBox.Show("Seleccione un producto para realizar la edición", "Editar precio del Articulo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (!string.IsNullOrEmpty(txtmonto.Text))
                {
                    Ldetallefactura parametros = new Ldetallefactura();
                    Editar_datos funcion = new Editar_datos();
                    parametros.iddetalle_factura = iddetallecotizacion;
                    parametros.preciounitario = Convert.ToDouble(txtmonto.Text);

                    if (funcion.editarPrecioVenta(parametros) == true)
                    {
                        Listarproductosagregados();

                    }
                }
                txtmonto.Focus();
                txtmonto.Clear();
                iddetallecotizacion = 0;
            }
        }

        private void btnDescuento_Click(object sender, EventArgs e)
        {
            if (iddetallecotizacion == 0)
            {
                MessageBox.Show("Seleccione un producto para aplicarle descuento", "Editar descuento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                double precio = Convert.ToDouble(tablaProductos.SelectedCells[6].Value);
                //MessageBox.Show(precio.ToString());
                if (!string.IsNullOrEmpty(txtmonto.Text))
                {
                    if ((Convert.ToInt32(txtmonto.Text) < precio))
                    {
                        Ldetallefactura parametros = new Ldetallefactura();
                        Editar_datos funcion = new Editar_datos();
                        parametros.iddetalle_factura = iddetallecotizacion;
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
                iddetallecotizacion = 0;
                txtmonto.Focus();
                txtmonto.Clear();
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
        private void btnVentasMediosPago_Click(object sender, EventArgs e)
        {
            if (tablaProductos.Rows.Count == 0)
            {

            }
            else
            {
                showFormInWrapper(new PagosCotizaciones());
                total = Convert.ToDouble(txt_total_suma.Text);
            }
            
        }

        private void btnRestaurarr_Click(object sender, EventArgs e)
        {
            VENTAS_MENU_PRINCIPAL.Cotizaciones_En_Espera frm = new VENTAS_MENU_PRINCIPAL.Cotizaciones_En_Espera();
            frm.ShowDialog();
        }

        private void deletefactura_Click(object sender, EventArgs e)
        {
            if (tablaProductos.RowCount > 0)
            {
                DialogResult pregunta = MessageBox.Show("¿Realmente desea eliminar esta Cotización?", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (pregunta == DialogResult.OK)
                {
                    Eliminar_datos.eliminar_factura(idCotizacion);
                    Limpiar_para_venta_nueva();
                }
            }
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

        private void btnguardarventaespera_Click(object sender, EventArgs e)
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

        private void btnVolverPanelVentasEspera_Click(object sender, EventArgs e)
        {
            ocularPanelenEspera();
        }

        private void btnGenerarCodigoAutomatico_Click(object sender, EventArgs e)
        {
            txtnombre.Text = "Ticket" + idCotizacion;
            editarVentaEspera();
        }
        private void editarVentaEspera()

        {
            Editar_datos.ingresar_nombre_a_venta_en_espera(idCotizacion, txtnombre.Text);
            Limpiar_para_venta_nueva();
            ocularPanelenEspera();
        }
        private void ocularPanelenEspera()
        {
            PanelEnespera.Visible = false;
            PanelEnespera.Dock = DockStyle.None;
        }

    }
}


