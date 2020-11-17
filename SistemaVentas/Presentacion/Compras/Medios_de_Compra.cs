using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;
using Telerik.Reporting.Processing;
using SistemaVentas.Logica;
using SistemaVentas.Datos;

namespace SistemaVentas.Presentacion.Medios_de_Compra
{
    public partial class Medios_de_Compra : Form
    {
        public Medios_de_Compra()
        {
            InitializeComponent();
        }
        private PrintDocument DOCUMENTO;
        string moneda;
        int idProveedor;
        int idProveedorasignado;
        double total;
        int idCompra;
        double totalcalculado;
        double vuelto = 0;
        double efectivo_calculado = 0;
        double restante = 0;
        int INDICADOR_DE_FOCO;
        bool SECUENCIA1 = true;
        bool SECUENCIA2 = true;
        bool SECUENCIA3 = true;
        string indicador;
        string indicador_de_tipo_de_pago_string;
        string txttipo;
        string TXTTOTAL_STRING;
        string lblproceso;
        double credito = 0;
        int idcomprobante;
        string lblSerialPC;
        int idEmpleado;
        string nombreEmpleado;
        string departamentoEmpleado;
        string estadoEmpleado;
        int idvehiculo;
        string estadovehiculo;
        string direccioncliente;
        string nombreCliente;
        private void MEDIOS_DE_PAGO_Load(object sender, EventArgs e)
        {
            panelClientefactura.Visible = true;
            lblindicador_de_factura_1.Text = "Proveedor: (Obligatorio)";
            lblindicador_de_factura_1.ForeColor = Color.FromArgb(255, 192, 192);
            FlowLayoutPanel1.Visible = false;
            //chkContado.Checked = true;
            txtMonto.Enabled = false;
            chkTrans.Visible = false;
            chkTrans.Checked = false;
            txtTransferencia.Visible = false;
            label2.Visible = false;
            asd1.Visible = false;
            cambiar_el_formato_de_separador_de_decimales();
            MOSTRAR_comprobante_serializado_POR_DEFECTO();
            validar_tipos_de_comprobantes();
            obtener_serial_pc();
            mostrar_moneda_de_empresa();
            configuraciones_de_diseño();
            Obtener_id_de_venta();
            mostrar_impresora();
            cargar_impresoras_del_equipo();

            calcular_restante();
            validarPedidodeProveedor();
            // datalistadoempleado.Visible = false;
            //label7.Visible = false;

        }

        void calcular_restante()
        {
            try
            {
                double efectivo = 0;
                double tarjeta = 0;
                double importe_bruto = 0;

                if (txtMonto.Text == "")
                {
                    importe_bruto = 0;
                }
                else
                {
                    importe_bruto = Convert.ToDouble(txtMonto.Text);
                }

                if (txtMonto.Text == "0.00")
                {
                    importe_bruto = 0;
                }
                if (txtMonto.Text == ".")
                {
                    importe_bruto = 0;
                }

                try
                {
                    if (efectivo > total)
                    {
                        efectivo_calculado = efectivo - (total + credito + tarjeta + importe_bruto);
                        if (efectivo_calculado < 0)
                        {
                            vuelto = 0;
                            TXTVUELTO.Text = "0";
                            txtrestante.Text = Convert.ToString(efectivo_calculado);
                            restante = efectivo_calculado;
                        }
                        else
                        {
                            vuelto = efectivo - (total - credito - tarjeta - importe_bruto);
                            TXTVUELTO.Text = Convert.ToString(vuelto);
                            restante = efectivo - (total + credito + tarjeta + efectivo_calculado + importe_bruto);
                            txtrestante.Text = Convert.ToString(restante);
                            txtrestante.Text = decimal.Parse(txtrestante.Text).ToString("##0.00");
                        }

                    }
                    else
                    {
                        vuelto = 0;
                        TXTVUELTO.Text = "0";
                        efectivo_calculado = efectivo;
                        restante = total - efectivo_calculado - credito - tarjeta - importe_bruto;
                        txtrestante.Text = Convert.ToString(restante);
                        txtrestante.Text = decimal.Parse(txtrestante.Text).ToString("##0.00");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        void mostrar_impresora()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("mostrar_impresoras_por_caja", CONEXION.CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Serial", lblSerialPC);
                try
                {
                    CONEXION.CONEXIONMAESTRA.abrir();
                    txtImpresora.Text = Convert.ToString(cmd.ExecuteScalar());
                    CONEXION.CONEXIONMAESTRA.cerrar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        void cargar_impresoras_del_equipo()
        {
            txtImpresora.Items.Clear();
            for (var I = 0; I < PrinterSettings.InstalledPrinters.Count; I++)
            {
                txtImpresora.Items.Add(PrinterSettings.InstalledPrinters[I]);
            }
            txtImpresora.Items.Add("Ninguna");
        }
        void Obtener_id_de_venta()
        {
            idCompra = Compras_proveedor.Compras_proveedor.idVenta;
        }
        void configuraciones_de_diseño()
        {
            TXTVUELTO.Text = "0.0";
            txtrestante.Text = "0.0";
            TXTTOTAL.Text = moneda + " " + Compras_proveedor.Compras_proveedor.total;
            total = Compras_proveedor.Compras_proveedor.total;
            txtMonto.Text = Convert.ToString(total);
            idProveedor = 0;

        }
        void mostrar_moneda_de_empresa()
        {
            SqlCommand cmd = new SqlCommand("Select Moneda From Empresa", CONEXION.CONEXIONMAESTRA.conectar);
            try
            {
                CONEXION.CONEXIONMAESTRA.abrir();
                moneda = Convert.ToString(cmd.ExecuteScalar());
                CONEXION.CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        public void obtener_serial_pc()
        {
            Bases.Obtener_serialPC(ref lblSerialPC);
        }
        public void cambiar_el_formato_de_separador_de_decimales()
        {
            CONEXION.cambiar_el_formato_de_separador_de_decimales.cambiar();
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
            dibujarCOMPROBANTES();
            //lblComprobante.Text = lblcomprobantecompra.Text;
        }
        string tipoImpresion;

        public object Compras { get; private set; }

        private void dibujarCOMPROBANTES()
        {
            FlowLayoutPanel3.Controls.Clear();
            try
            {
                /* CONEXION.CONEXIONMAESTRA.abrir();
                 string query = "select tipodoc from Serializacion where Destino='facturaS'";
                 SqlCommand cmd = new SqlCommand(query, CONEXION.CONEXIONMAESTRA.conectar);
                 SqlDataReader rdr = cmd.ExecuteReader();
                 while (rdr.Read())
                 {*/
                Button b = new Button();
                b.Text = "COMPRA";
                b.Size = new System.Drawing.Size(191, 60);
                b.BackColor = Color.FromArgb(70, 70, 71);
                b.Font = new System.Drawing.Font("Segoe UI", 13);
                b.FlatStyle = FlatStyle.Flat;
                b.ForeColor = Color.WhiteSmoke;
                FlowLayoutPanel3.Controls.Add(b);

                // // if (b.Text == lblComprobante.Text)
                //   {
                //
                tipoImpresion = b.Text;
                lblcomprobantecompra.Text = b.Text;
                // b.Visible = false;
                //}
                b.Click += miEvento;
                // }
                CONEXION.CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        private void miEvento(System.Object sender, EventArgs e)
        {
            lblComprobante.Text = ((Button)sender).Text;
            dibujarCOMPROBANTES();
            validar_tipos_de_comprobantes();
            identificar_el_tipo_de_pago();
            validarPedidodeProveedor();
        }
        private void validarPedidodeProveedor()
        {
            if (lblComprobante.Text == "factura" && txttipo == "CREDITO")
            {
                panelClientefactura.Visible = false;
            }
            if (lblComprobante.Text == "factura" && txttipo == "CONTADO")
            {
                panelClientefactura.Visible = true;
                lblindicador_de_factura_1.Text = "Proveedor: (Obligatorio)";
                lblindicador_de_factura_1.ForeColor = Color.FromArgb(255, 192, 192);
            }
            else if (lblComprobante.Text != "factura" && txttipo == "CONTADO - Transferencia bancaria")
            {
                panelClientefactura.Visible = true;
                lblindicador_de_factura_1.Text = "Proveedor: (Obligatorio)";
                lblindicador_de_factura_1.ForeColor = Color.FromArgb(255, 192, 192);
            }
            else if (lblComprobante.Text == "factura" && txttipo == "CONTADO - Transferencia bancaria")
            {
                panelClientefactura.Visible = true;
                lblindicador_de_factura_1.Text = "Proveedor: (Obligatorio)";
                lblindicador_de_factura_1.ForeColor = Color.FromArgb(255, 192, 192);

            }
        }
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
        void buscar_Tipo_de_documentos_para_insertar_en_ventas()
        {
            DataTable dt = new DataTable();
            try
            {
                CONEXION.CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("Buscar_tipo_de_documentos_para_insertar_en_facturas", CONEXION.CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letra", lblComprobante.Text);
                //MessageBox.Show(lblComprobante.Text);
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
        private void txtefectivo2_TextChanged(object sender, EventArgs e)
        {
            calcular_restante();
        }

        private void txttarjeta2_TextChanged(object sender, EventArgs e)
        {
            calcular_restante();
        }

        private void txtcredito2_TextChanged(object sender, EventArgs e)
        {
            calcular_restante();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (INDICADOR_DE_FOCO == 1)
            {
                txtMonto.Text = txtMonto.Text + "1";
            }

        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (INDICADOR_DE_FOCO == 1)
            {
                txtMonto.Text = txtMonto.Text + "2";
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (INDICADOR_DE_FOCO == 1)
            {
                txtMonto.Text = txtMonto.Text + "3";
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (INDICADOR_DE_FOCO == 1)
            {
                txtMonto.Text = txtMonto.Text + "4";
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (INDICADOR_DE_FOCO == 1)
            {
                txtMonto.Text = txtMonto.Text + "5";
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (INDICADOR_DE_FOCO == 1)
            {
                txtMonto.Text = txtMonto.Text + "6";

            }
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (INDICADOR_DE_FOCO == 1)
            {
                txtMonto.Text = txtMonto.Text + "7";

            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (INDICADOR_DE_FOCO == 1)
            {
                txtMonto.Text = txtMonto.Text + "8";

            }
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (INDICADOR_DE_FOCO == 1)
            {
                txtMonto.Text = txtMonto.Text + "9";

            }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (INDICADOR_DE_FOCO == 1)
            {
                txtMonto.Text = txtMonto.Text + "0";

            }
        }

        private void btnpunto_Click(object sender, EventArgs e)
        {
            if (INDICADOR_DE_FOCO == 1)
            {
                if (SECUENCIA1 == true)
                {
                    txtMonto.Text = txtMonto.Text + ".";
                    txtMonto_Click(sender, e);
                    SECUENCIA1 = false;
                }

                else
                {
                    return;
                }

            }
        }

        private void btnborrartodo_Click(object sender, EventArgs e)
        {
            if (INDICADOR_DE_FOCO == 1)
            {
                txtMonto.Clear();
                SECUENCIA1 = true;
            }
        }

        private void FlowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtclientesolicitabnte3_TextChanged(object sender, EventArgs e)
        {
            buscarProveedor();
            datalistadoclientes3.Visible = true;
        }

        private void txtclientesolicitabnte2_TextChanged(object sender, EventArgs e)
        {
            buscarProveedor2();
            datalistadoProveedores.Visible = true;
        }
        void buscarProveedor2()
        {
            try
            {
                DataTable dt = new DataTable();
                Obtener_datos.buscar_Proveedores(ref dt, txtProveedorCredito.Text);
                datalistadoProveedores.DataSource = dt;
                datalistadoProveedores.Columns[1].Visible = false;
                datalistadoProveedores.Columns[3].Visible = false;
                datalistadoProveedores.Columns[4].Visible = false;
                datalistadoProveedores.Columns[5].Visible = false;
                datalistadoProveedores.Columns[2].Width = 420;
                CONEXION.CONEXIONMAESTRA.cerrar();
            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            {

            }
        }
        void buscarProveedor()
        {
            try
            {
                DataTable dt = new DataTable();
                Obtener_datos.buscar_Proveedores(ref dt, txtProveedor.Text);
                datalistadoclientes3.DataSource = dt;
                datalistadoclientes3.Columns[1].Visible = false;
                datalistadoclientes3.Columns[3].Visible = false;
                datalistadoclientes3.Columns[4].Visible = false;
                datalistadoclientes3.Columns[5].Visible = false;
                datalistadoclientes3.Columns[2].Width = 420;
                CONEXION.CONEXIONMAESTRA.cerrar();
            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            {

            }
        }


        private void datalistadoclientes2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void datalistadoclientes2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idProveedor = Convert.ToInt32(datalistadoProveedores.SelectedCells[1].Value.ToString());
            txtProveedorCredito.Text = datalistadoProveedores.SelectedCells[2].Value.ToString();
            datalistadoProveedores.Visible = false;
        }       

        void INGRESAR_LOS_DATOS()
        {
            CONVERTIR_TOTAL_A_LETRAS();
            completar_con_ceros_los_texbox_de_otros_medios_de_pago();
            if (txttipo == "CONTADO - Transferencia bancaria" && vuelto >= 0)
            {
                COMPRAR_CONTADO();
            } else if (txttipo == "CONTADO" && vuelto < 0)
            {
                MessageBox.Show("El vuelto no puede ser menor a el Total pagado ", "Datos Incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (txttipo == "CONTADO" && vuelto >= 0)
            {
                COMPRAR_CONTADO();
            }
            else if (txttipo == "CONTADO" && vuelto < 0)
            {
                MessageBox.Show("El vuelto no puede ser menor a el Total pagado ", "Datos Incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            // condicional para creditos
            if (txttipo == "CREDITO" && datalistadoProveedores.Visible == false)
            {
                COMPRAR_CONTADO();
            }
            else if (txttipo == "CREDITO" && datalistadoProveedores.Visible == true)
            {
                MessageBox.Show("Seleccione un Proveedor para Activar Pago a Credito", "Datos Incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        void COMPRAR_CONTADO()
        {
            if (idProveedor == 0 || idProveedor == 1)
            {
                mostrar_proveedor_estandar();
            }
            if (lblComprobante.Text == "COMPRA" && idProveedor > -1 && idProveedor < 2 && txttipo != "CREDITO")
            {
                MessageBox.Show("Seleccione un Proveedor, para Compras es Obligatorio", "Datos Incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (lblComprobante.Text == "COMPRA" && idProveedor != 0)
            {
                procesar_compra_contado();
            }
            else if (lblComprobante.Text != "COMPRA" && txttipo != "CREDITO")
            {
                procesar_compra_contado();
            }
            else if (lblComprobante.Text != "COMPRA" && txttipo == "CREDITO")
            {
                procesar_compra_contado();
            }




        }
        void procesar_compra_contado()
        {
            actualizar_serie_mas_uno();
            validar_tipos_de_comprobantes();
            CONFIRMAR_VENTA_EFECTIVO();
            if (lblproceso == "PROCEDE")
            {
                disminuir_stock_productos();
                INSERTAR_KARDEX_SALIDA();
                aumentar_monto_a_proveedor();
                validar_tipo_de_impresion();
            }
        }
        void aumentar_monto_a_proveedor()
        {
            if (chkCredito.Checked == true)
            {
                try
                {
                    CONEXION.CONEXIONMAESTRA.abrir();
                    SqlCommand cmd = new SqlCommand("aumentar_saldo_a_proveedor", CONEXION.CONEXIONMAESTRA.conectar);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Saldo", txtMonto.Text);
                    cmd.Parameters.AddWithValue("@idProveedor", idProveedor);
                    cmd.ExecuteNonQuery();
                    CONEXION.CONEXIONMAESTRA.cerrar();
                }
                catch (Exception ex)
                {
                    CONEXION.CONEXIONMAESTRA.cerrar();
                    MessageBox.Show(ex.StackTrace);
                }
            }

        }
        void INSERTAR_KARDEX_SALIDA()
        {
            try
            {
                foreach (DataGridViewRow row in datalistadoDetalleVenta.Rows)
                {
                    int Id_producto = Convert.ToInt32(row.Cells["Id_producto"].Value);
                    double cantidad = Convert.ToDouble(row.Cells["Cantidad"].Value);
                    string STOCK = Convert.ToString(row.Cells["Stock"].Value);

                    CONEXION.CONEXIONMAESTRA.abrir();
                    SqlCommand cmd = new SqlCommand("Insertar_kardex_entrada", CONEXION.CONEXIONMAESTRA.conectar);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fecha", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Motivo", "Compra #" + lblComprobante.Text + " " + lblCorrelativoconCeros.Text);
                    cmd.Parameters.AddWithValue("@Cantidad ", cantidad);
                    cmd.Parameters.AddWithValue("@Id_producto", Id_producto);
                    cmd.Parameters.AddWithValue("@Id_usuario", Compras_proveedor.Compras_proveedor.idusuario_que_inicio_sesion);
                    cmd.Parameters.AddWithValue("@Tipo", "ENTRADA");
                    cmd.Parameters.AddWithValue("@Estado", "ATENCION CONFIRMADA");
                    cmd.Parameters.AddWithValue("@Id_caja", Compras_proveedor.Compras_proveedor.Id_caja);
                    cmd.ExecuteNonQuery();
                    CONEXION.CONEXIONMAESTRA.cerrar();



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
        }
        void mostrar_productos_agregados_a_factura()
        {
            try
            {
                DataTable dt = new DataTable();
                CONEXION.CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_productos_agregados_a_compra", CONEXION.CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idCompra", idCompra);
                da.Fill(dt);
                datalistadoDetalleVenta.DataSource = dt;
                CONEXION.CONEXIONMAESTRA.cerrar();

            }
            catch (Exception ex)
            {
                CONEXION.CONEXIONMAESTRA.cerrar();
                MessageBox.Show(ex.Message);
            }
        }
        void disminuir_stock_productos()
        {
            mostrar_productos_agregados_a_factura();
            foreach (DataGridViewRow row in datalistadoDetalleVenta.Rows)
            {
                int idproducto = Convert.ToInt32(row.Cells["Id_producto"].Value);
                double cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                try
                {
                    //MessageBox.Show("entramos");
                    CONEXION.CONEXIONMAESTRA.abrir();
                    SqlCommand cmd = new SqlCommand("Aumentarstock", CONEXION.CONEXIONMAESTRA.conectar);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idproducto", idproducto);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    cmd.ExecuteNonQuery();
                    CONEXION.CONEXIONMAESTRA.cerrar();
                }
                catch (Exception ex)
                {
                    CONEXION.CONEXIONMAESTRA.cerrar();
                    MessageBox.Show(ex.Message);
                }
            }


        }
        void actualizar_serie_mas_uno()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                CONEXION.CONEXIONMAESTRA.abrir();
                cmd = new SqlCommand("actualizar_serializacion_mas_uno", CONEXION.CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idserie", idcomprobante);
                cmd.ExecuteNonQuery();
                CONEXION.CONEXIONMAESTRA.cerrar();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void validar_tipo_de_impresion()
        {
            if (indicador == "VISTA PREVIA")
            {
                if (tipoImpresion == "COMPRA")
                {
                    mostrar_compra_impresa_VISTA_PREVIA();
                }
            }
            else if (indicador == "DIRECTO")
            {
                if (tipoImpresion == "factura")
                {
                    //imprimir_directo_factura();
                }
                else if (tipoImpresion == "TICKET")
                {
                    //imprimir_directo();

                }
            }
        }
        void imprimir_directo()
        {
            mostrar_Ticket_lleno();
            try
            {
                DOCUMENTO = new PrintDocument();
                DOCUMENTO.PrinterSettings.PrinterName = txtImpresora.Text;
                if (DOCUMENTO.PrinterSettings.IsValid)
                {
                    PrinterSettings printerSettings = new PrinterSettings();
                    printerSettings.PrinterName = txtImpresora.Text;
                    ReportProcessor reportProcessor = new ReportProcessor();
                    reportProcessor.PrintReport(reportViewer2.ReportSource, printerSettings);
                }
                Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        void imprimir_directo_factura()
        {
            mostrar_factura_llena();
            try
            {
                DOCUMENTO = new PrintDocument();
                DOCUMENTO.PrinterSettings.PrinterName = txtImpresora.Text;
                if (DOCUMENTO.PrinterSettings.IsValid)
                {
                    PrinterSettings printerSettings = new PrinterSettings();
                    printerSettings.PrinterName = txtImpresora.Text;
                    ReportProcessor reportProcessor = new ReportProcessor();
                    reportProcessor.PrintReport(reportViewer2.ReportSource, printerSettings);
                }
                Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        void mostrar_factura_llena()
        {
            Presentacion.REPORTES.Impresion_de_comprobantes.Ticket_report rpt = new Presentacion.REPORTES.Impresion_de_comprobantes.Ticket_report();
            DataTable dt = new DataTable();
            try
            {
                CONEXION.CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_factura_impreso", CONEXION.CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Id_Compra", idCompra);
                da.SelectCommand.Parameters.AddWithValue("@total_en_letras", txtnumeroconvertidoenletra.Text);
                da.Fill(dt);
                rpt = new Presentacion.REPORTES.Impresion_de_comprobantes.Ticket_report();
                rpt.table1.DataSource = dt;
                rpt.DataSource = dt;
#pragma warning disable CS0618 // 'ReportViewerBase.Report' está obsoleto: 'Telerik.ReportViewer.WinForms.ReportViewer.Report is now obsolete. Please use the Telerik.ReportViewer.WinForms.ReportViewer.ReportSource property instead. For more information, please visit: http://www.telerik.com/support/kb/reporting/general/q2-2012-api-changes-reportsources.aspx#winformsviewer.'
                reportViewer2.Report = rpt;
#pragma warning restore CS0618 // 'ReportViewerBase.Report' está obsoleto: 'Telerik.ReportViewer.WinForms.ReportViewer.Report is now obsolete. Please use the Telerik.ReportViewer.WinForms.ReportViewer.ReportSource property instead. For more information, please visit: http://www.telerik.com/support/kb/reporting/general/q2-2012-api-changes-reportsources.aspx#winformsviewer.'
                reportViewer2.RefreshReport();
                CONEXION.CONEXIONMAESTRA.cerrar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        void mostrar_Ticket_lleno()
        {
            Presentacion.REPORTES.Impresion_de_comprobantes.Ticket_report rpt = new Presentacion.REPORTES.Impresion_de_comprobantes.Ticket_report();
            DataTable dt = new DataTable();
            try
            {
                CONEXION.CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_ticket_impreso", CONEXION.CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Id_Compra", idCompra);
                da.SelectCommand.Parameters.AddWithValue("@total_en_letras", txtnumeroconvertidoenletra.Text);
                da.Fill(dt);
                rpt = new Presentacion.REPORTES.Impresion_de_comprobantes.Ticket_report();
                rpt.table1.DataSource = dt;
                rpt.DataSource = dt;
#pragma warning disable CS0618 // 'ReportViewerBase.Report' está obsoleto: 'Telerik.ReportViewer.WinForms.ReportViewer.Report is now obsolete. Please use the Telerik.ReportViewer.WinForms.ReportViewer.ReportSource property instead. For more information, please visit: http://www.telerik.com/support/kb/reporting/general/q2-2012-api-changes-reportsources.aspx#winformsviewer.'
                reportViewer2.Report = rpt;
#pragma warning restore CS0618 // 'ReportViewerBase.Report' está obsoleto: 'Telerik.ReportViewer.WinForms.ReportViewer.Report is now obsolete. Please use the Telerik.ReportViewer.WinForms.ReportViewer.ReportSource property instead. For more information, please visit: http://www.telerik.com/support/kb/reporting/general/q2-2012-api-changes-reportsources.aspx#winformsviewer.'
                reportViewer2.RefreshReport();
                CONEXION.CONEXIONMAESTRA.cerrar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        void mostrar_ticket_impreso_VISTA_PREVIA()
        {
            PanelImpresionvistaprevia.Visible = true;
            PanelImpresionvistaprevia.Dock = DockStyle.Fill;
            panelGuardado_de_datos.Dock = DockStyle.None;
            panelGuardado_de_datos.Visible = false;

            Presentacion.REPORTES.Impresion_de_comprobantes.Ticket_report rpt = new Presentacion.REPORTES.Impresion_de_comprobantes.Ticket_report();
            DataTable dt = new DataTable();
            try
            {
                CONEXION.CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_ticket_impreso", CONEXION.CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Id_Compra", idCompra);
                da.SelectCommand.Parameters.AddWithValue("@total_en_letras", txtnumeroconvertidoenletra.Text);
                da.Fill(dt);
                rpt = new Presentacion.REPORTES.Impresion_de_comprobantes.Ticket_report();
                rpt.table1.DataSource = dt;
                rpt.DataSource = dt;
#pragma warning disable CS0618 // 'ReportViewerBase.Report' está obsoleto: 'Telerik.ReportViewer.WinForms.ReportViewer.Report is now obsolete. Please use the Telerik.ReportViewer.WinForms.ReportViewer.ReportSource property instead. For more information, please visit: http://www.telerik.com/support/kb/reporting/general/q2-2012-api-changes-reportsources.aspx#winformsviewer.'
                reportViewer1.Report = rpt;
#pragma warning restore CS0618 // 'ReportViewerBase.Report' está obsoleto: 'Telerik.ReportViewer.WinForms.ReportViewer.Report is now obsolete. Please use the Telerik.ReportViewer.WinForms.ReportViewer.ReportSource property instead. For more information, please visit: http://www.telerik.com/support/kb/reporting/general/q2-2012-api-changes-reportsources.aspx#winformsviewer.'
                reportViewer1.RefreshReport();
                CONEXION.CONEXIONMAESTRA.cerrar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }

        }
        void mostrar_compra_impresa_VISTA_PREVIA()
        {
            PanelImpresionvistaprevia.Visible = true;
            PanelImpresionvistaprevia.Dock = DockStyle.Fill;
            panelGuardado_de_datos.Dock = DockStyle.None;
            panelGuardado_de_datos.Visible = false;

            Presentacion.REPORTES.Impresion_de_comprobantes.Compra_report rpt = new Presentacion.REPORTES.Impresion_de_comprobantes.Compra_report();
            DataTable dt = new DataTable();
            try
            {
                asdasd();
                CONEXION.CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_compra_impreso", CONEXION.CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Id_factura", idCompra);
                da.SelectCommand.Parameters.AddWithValue("@total_en_letras", txtnumeroconvertidoenletra.Text);
                da.Fill(dt);
                rpt = new Presentacion.REPORTES.Impresion_de_comprobantes.Compra_report();
                rpt.table1.DataSource = dt;
                rpt.DataSource = dt;
#pragma warning disable CS0618 // 'ReportViewerBase.Report' está obsoleto: 'Telerik.ReportViewer.WinForms.ReportViewer.Report is now obsolete. Please use the Telerik.ReportViewer.WinForms.ReportViewer.ReportSource property instead. For more information, please visit: http://www.telerik.com/support/kb/reporting/general/q2-2012-api-changes-reportsources.aspx#winformsviewer.'
                reportViewer1.Report = rpt;
#pragma warning restore CS0618 // 'ReportViewerBase.Report' está obsoleto: 'Telerik.ReportViewer.WinForms.ReportViewer.Report is now obsolete. Please use the Telerik.ReportViewer.WinForms.ReportViewer.ReportSource property instead. For more information, please visit: http://www.telerik.com/support/kb/reporting/general/q2-2012-api-changes-reportsources.aspx#winformsviewer.'
                reportViewer1.RefreshReport();
                CONEXION.CONEXIONMAESTRA.cerrar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }

        }
        private void asdasd()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                CONEXION.CONEXIONMAESTRA.abrir();
                da = new SqlDataAdapter("mostrar_compra_impreso", CONEXION.CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Id_factura", idCompra);
                da.SelectCommand.Parameters.AddWithValue("@total_en_letras", txtnumeroconvertidoenletra.Text);
                da.Fill(dt);
                datalistadoprueba.DataSource = dt;
                CONEXION.CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                CONEXION.CONEXIONMAESTRA.cerrar();
                MessageBox.Show(ex.StackTrace);
            }
        }
        void CONFIRMAR_VENTA_EFECTIVO()
        {
            try
            {
                MessageBox.Show(txttipo);
                CONEXION.CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("confirmar_compra", CONEXION.CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCompra", idCompra);
                cmd.Parameters.AddWithValue("@montototal", total);
                cmd.Parameters.AddWithValue("@Saldo", vuelto);
                cmd.Parameters.AddWithValue("@Tipo_de_pago", txttipo);
                cmd.Parameters.AddWithValue("@Estado", "CONFIRMADO");
                cmd.Parameters.AddWithValue("@idProveedor", idProveedor);
                cmd.Parameters.AddWithValue("@Comprobante", lblComprobante.Text);
                cmd.Parameters.AddWithValue("@Numero_de_doc", (txtserie.Text + "--" + lblCorrelativoconCeros.Text));
                cmd.Parameters.AddWithValue("@fecha_compra", DateTime.Now);
                cmd.Parameters.AddWithValue("@ACCION", "COMPRA");
                cmd.Parameters.AddWithValue("@Fecha_de_pago", txtfecha_de_pago.Value);
                cmd.Parameters.AddWithValue("@Vuelto", vuelto);
                cmd.Parameters.AddWithValue("@TotalPagado", total);
                if (txttipo == "CONTADO - Transferencia bancaria")
                {
                    cmd.Parameters.AddWithValue("@Transferencia_Bancaria", txtTransferencia.Text);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Transferencia_Bancaria", "SIN TRANSFERENCIA BANCARIA");
                }
                cmd.ExecuteNonQuery();
                CONEXION.CONEXIONMAESTRA.cerrar();
                lblproceso = "PROCEDE";
            }
            catch (Exception ex)
            {
                CONEXION.CONEXIONMAESTRA.cerrar();
                lblproceso = "NO PROCEDE";
                MessageBox.Show(ex.Message);
            }
        }

        void mostrar_proveedor_estandar()
        {
            SqlCommand com = new SqlCommand("select idProveedor from Proveedores where Estado = 0", CONEXION.CONEXIONMAESTRA.conectar);
            try
            {
                CONEXION.CONEXIONMAESTRA.abrir();
                idProveedor = Convert.ToInt32(com.ExecuteScalar());
                CONEXION.CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        void completar_con_ceros_los_texbox_de_otros_medios_de_pago()
        {

            if (TXTVUELTO.Text == "")
            {
                TXTVUELTO.Text = "0";
            }
        }
        void CONVERTIR_TOTAL_A_LETRAS()
        {
            try
            {
                TXTTOTAL.Text = Convert.ToString(total);
                totalcalculado = Convert.ToDouble(TXTTOTAL.Text);

                TXTTOTAL.Text = decimal.Parse(TXTTOTAL.Text).ToString("##0.00");
                int numero = Convert.ToInt32(Math.Floor(Convert.ToDouble(total)));
                TXTTOTAL_STRING = CONEXION.total_en_letras.Num2Text(numero);
                string[] a = TXTTOTAL.Text.Split('.');
                txttotaldecimal.Text = a[1];
                txtnumeroconvertidoenletra.Text = TXTTOTAL_STRING + " CON " + txttotaldecimal.Text + "/100 ";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        void identificar_el_tipo_de_pago()
        {
            int indicadorContado = 4;
            int indicadorContadoTransferencia = 2;
            int indicadorCredito = 3;
            int indicadorCreditoTransferemcia = 1;

            if (chkContado.Checked == true && chkTrans.Checked == false)
            {
                indicadorContadoTransferencia = 0;
                indicadorCredito = 0;
                indicadorCreditoTransferemcia = 0;
            } else if (chkContado.Checked == true && chkTrans.Checked == true)
            {
                indicadorCredito = 0;
                indicadorCreditoTransferemcia = 0;
            }

            if (chkCredito.Checked == true)
            {
                indicadorContado = 0;
                indicadorContadoTransferencia = 0;
                indicadorCreditoTransferemcia = 0;
            }
            /*if (txtMonto.Text == "0")
            {
                indicadorContado = 0;
            }*/

            //calculo de indicador
            int calculo_identificacion = indicadorCredito + indicadorContado + indicadorContadoTransferencia + indicadorCreditoTransferemcia;
            //consulta al identificador
            if (calculo_identificacion == 4)
            {
                indicador_de_tipo_de_pago_string = "CONTADO";
            }
            if (calculo_identificacion == 6)
            {
                indicador_de_tipo_de_pago_string = "CONTADO - Transferencia bancaria";
            }
            if (calculo_identificacion == 3)
            {
                indicador_de_tipo_de_pago_string = "CREDITO";
            }
            txttipo = indicador_de_tipo_de_pago_string;
        }

        private void btnGuardarImprimirdirecto_Click(object sender, EventArgs e)
        {

        }
        void editar_eleccion_de_impresora()
        {
            try
            {
                CONEXION.CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("editar_eleccion_impresoras", CONEXION.CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Impresora_Ticket", txtImpresora.Text);
                cmd.Parameters.AddWithValue("@idcaja", Compras_proveedor.Compras_proveedor.Id_caja);
                cmd.ExecuteNonQuery();
                CONEXION.CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void TXTTOTAL_Click(object sender, EventArgs e)
        {
        }

        public void ImprimirDirecto()
        {
            if (restante == 0)
            {
                editar_eleccion_de_impresora();
                indicador = "DIRECTO";
                identificar_el_tipo_de_pago();
                INGRESAR_LOS_DATOS();
            }
            else
            {
                MessageBox.Show("El restante debe ser 0", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnGuardarImprimirdirecto_Click_1(object sender, EventArgs e)
        {
            if (chkContado.Checked || chkCredito.Checked)
            {
                if (chkTrans.Checked)
                {
                    if (!string.IsNullOrEmpty(txtTransferencia.Text)){
                        GuardarSinImprimir();
                    }
                    else
                    {
                        MessageBox.Show("Asigne el numero de transferencia", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    GuardarSinImprimir();
                }
            }
            else
            {
                MessageBox.Show("Selecciona un tipo de Compra", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void GuardarSinImprimir()
        {
            if (restante == 0)
            {
                indicador = "VISTA PREVIA";
                identificar_el_tipo_de_pago();
                INGRESAR_LOS_DATOS();
            }
            else
            {
                MessageBox.Show("El restante debe ser 0", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void TGuardarSinImprimir_Click_1(object sender, EventArgs e)
        {

            if (chkContado.Checked || chkCredito.Checked)
            {
                if (chkTrans.Checked)
                {
                    if (!string.IsNullOrEmpty(txtTransferencia.Text)){
                        GuardarSinImprimir();
                    }
                    else
                    {
                        MessageBox.Show("Asigne el numero de transferencia", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    GuardarSinImprimir();
                }
            }
            else
            {
                MessageBox.Show("Selecciona un tipo de Compra", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }
        private void btnagregarCliente_Click(object sender, EventArgs e)
        {
            Presentacion.CLIENTES_PROVEEDORES.Proveedores frm = new Presentacion.CLIENTES_PROVEEDORES.Proveedores();
            frm.ShowDialog();
        }

        private void datalistadoclientes3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idProveedor = Convert.ToInt32(datalistadoclientes3.SelectedCells[1].Value.ToString());
            //MessageBox.Show(idProveedor.ToString());
            txtProveedor.Text = datalistadoclientes3.SelectedCells[2].Value.ToString();
            datalistadoclientes3.Visible = false;
        }

        private void panelGuardado_de_datos_Paint(object sender, PaintEventArgs e)
        {

        }

        public void VerificarEstadoPersonal()
        {
         /*   DataTable dt = new DataTable();
            Obtener_datos.EstadoPersonal(ref dt);
            datalistadoempleado.DataSource = dt;
            
            if(datalistadoempleado.Rows.Count > 0)
            {
                return true;
            } else
            {
                return false;
            }*/
        }
        public bool VerificarEstadoVehiculos()
        {
            DataTable dt = new DataTable();
            Obtener_datos.EstadoVehiculos(ref dt);
            datalistadovehiculo.DataSource = dt;
            if (datalistadovehiculo.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ObtenerEmpleado()
        {
           /* idEmpleado = Convert.ToInt32(datalistadoempleado.SelectedCells[0].Value);
            nombreEmpleado = datalistadoempleado.SelectedCells[1].Value.ToString();
            departamentoEmpleado = datalistadoempleado.SelectedCells[2].Value.ToString();
            estadoEmpleado = datalistadoempleado.SelectedCells[3].Value.ToString();*/
        }

        public void ObtenerVehiculo()
        {
            idvehiculo = Convert.ToInt32(datalistadovehiculo.SelectedCells[0].Value);
            estadovehiculo = datalistadovehiculo.SelectedCells[1].Value.ToString();
        }

        public bool verificarCliente()
        {
            try
            {
                idProveedorasignado = 0;
                CONEXION.CONEXIONMAESTRA.abrir();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("verificarCliente", CONEXION.CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@nombre", txtProveedor.Text);
                da.Fill(dt);
                CONEXION.CONEXIONMAESTRA.cerrar();
                DATALISTADOVERIFICAR.DataSource = dt;
                idProveedorasignado = Convert.ToInt32(DATALISTADOVERIFICAR.SelectedCells[0].Value);
                nombreCliente = DATALISTADOVERIFICAR.SelectedCells[1].Value.ToString();
                direccioncliente = DATALISTADOVERIFICAR.SelectedCells[2].Value.ToString();

                CONEXION.CONEXIONMAESTRA.cerrar();
                if (idProveedorasignado > 1)
                {
                    return true;
                } else
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
        private void datalistadoempleado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ObtenerEmpleado();
            
        }

        public void actualizarVehiculo(int idVehiculo)
        {
            try
            {
                CONEXION.CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("actualizarEstadoVehiculo", CONEXION.CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idVehiculo", idVehiculo);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CONEXION.CONEXIONMAESTRA.cerrar();
            }
        }
        public void actualizarEmpleado(int idEmpleado)
        {
            try
            {
                CONEXION.CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("actualizarEstadoEmpleado", CONEXION.CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CONEXION.CONEXIONMAESTRA.cerrar();
            }
        }

        private void datalistadoempleado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MenuStrip9_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Presentacion.CLIENTES_PROVEEDORES.Proveedores frm = new Presentacion.CLIENTES_PROVEEDORES.Proveedores();
            frm.ShowDialog();
        }

        private void chkTrans_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTrans.Checked == true)
            {
                //panel2.Visible = false;
                txttipo = "TRANSFERENCIA BANCARIA";
                txtTransferencia.Visible = true;
                label2.Visible = true;
                asd1.Visible = true;
            }
            else
            {
              //  txtefectivo2_Click(sender, e);
                ///panel2.Visible = true;
                txtTransferencia.Visible = false;
                label2.Visible = false;
                asd1.Visible = false;
            }
        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            calcular_restante();
        }

        private void txtMonto_Click(object sender, EventArgs e)
        {
            calcular_restante();
            INDICADOR_DE_FOCO = 1;
            if (txtrestante.Text =="0.00")
            {
                txtMonto.Text = "";
            }
            else
            {
                txtMonto.Text = txtrestante.Text;
            }
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txtMonto, e);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(chkCredito.Checked == true)
            {
                chkContado.Checked = false;
                FlowLayoutPanel1.Visible = true;
                AsignarTipoComprobante();
                chkTrans.Checked = false;
                chkTrans.Visible = false;
                asd1.Visible = false;
                txtTransferencia.Visible = false;
                txtTransferencia.Clear();
                pcredito.Visible = true;
                ValidarChkCredito();
            }
            else
            {
                panelClientefactura.Visible = true;
                AsignarTipoComprobante();
                FlowLayoutPanel1.Visible = true;
                pcredito.Visible = false;
                chkContado.Checked = true;
                txtTransferencia.Clear();
                chkTrans.Checked = false;
            }
        }
        public void AsignarTipoComprobante()
        {
            lblcomprobantecompra.Text = tipoImpresion;
            lblComprobante.Text = lblcomprobantecompra.Text;
            txtserie.Text = "C";
        }
        private void chkContado_CheckedChanged(object sender, EventArgs e)
        {
            if (chkContado.Checked == true)
            {
                FlowLayoutPanel1.Visible = true;
                // label2.Visible = true;
                // asd1.Visible = true;
                AsignarTipoComprobante();
                chkCredito.Checked = false;
                chkTrans.Visible = true;
                chkTrans.Checked = false;
                txtTransferencia.Clear();
               // txtTransferencia.Visible = true;
               // txtTransferencia.Focus();
            }
            else
            {
                FlowLayoutPanel1.Visible = true;

                lblcomprobantecompra.Text = tipoImpresion;
                lblComprobante.Text = lblcomprobantecompra.Text;
                txtserie.Text = "C";
               // label2.Visible = false;
               // asd1.Visible = false;
                txtTransferencia.Visible = false;
                chkTrans.Visible = false;
                AsignarTipoComprobante();
                chkTrans.Checked = false;
            }
        }

        void ValidarChkCredito()
        {
            try
            {
                double textocredito = 0;
                if (txtMonto.Text == ".")
                {
                    textocredito = 0;
                }
                if (txtMonto.Text == "")
                {
                    textocredito = 0;
                }
                else
                {
                    textocredito = Convert.ToDouble(txtMonto.Text);
                }
                if (textocredito > 0)
                {
                    pcredito.Visible = true;
                    panelClientefactura.Visible = false;
                }
                else
                {
                    pcredito.Visible = false;
                    panelClientefactura.Visible = true;
                    idProveedor = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void txtefectivo2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txtefectivo2, e);
        }
            double result;

        private void txtefectivo2_TextChanged_1(object sender, EventArgs e)
        {
            if(txtefectivo2.Text != "")
            {
                result = Convert.ToDouble(txtMonto.Text) + Convert.ToDouble(txtefectivo2.Text);
                calculototal();
            }
            else
            {
                txtefectivo2.Text = "";
            }
        }

        private void calculototal()
        {
            txtMonto.Text = Convert.ToString(result);
        }
    }
}
