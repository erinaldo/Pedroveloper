using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;
using Telerik.Reporting.Processing;
using Telerik.Reporting.Drawing;
using SistemaVentas.Logica;
using SistemaVentas.Datos;

namespace SistemaVentas.Presentacion.Cotizacion
{
    public partial class PagosCotizaciones : Form
    {
        public PagosCotizaciones()
        {
            InitializeComponent();
        }
        private PrintDocument DOCUMENTO;
        string moneda;
        string correoCliente;
        int idcliente;
        int idcotizacion;
        double total;
        double vuelto = 0;
#pragma warning disable CS0414 // El campo 'PagosCotizaciones.efectivo_calculado' está asignado pero su valor nunca se usa
        double efectivo_calculado = 0;
#pragma warning restore CS0414 // El campo 'PagosCotizaciones.efectivo_calculado' está asignado pero su valor nunca se usa
        double restante = 0;
#pragma warning disable CS0169 // El campo 'PagosCotizaciones.INDICADOR_DE_FOCO' nunca se usa
        int INDICADOR_DE_FOCO;
#pragma warning restore CS0169 // El campo 'PagosCotizaciones.INDICADOR_DE_FOCO' nunca se usa
#pragma warning disable CS0414 // El campo 'PagosCotizaciones.SECUENCIA1' está asignado pero su valor nunca se usa
        bool SECUENCIA1 = true;
#pragma warning restore CS0414 // El campo 'PagosCotizaciones.SECUENCIA1' está asignado pero su valor nunca se usa
#pragma warning disable CS0414 // El campo 'PagosCotizaciones.SECUENCIA2' está asignado pero su valor nunca se usa
        bool SECUENCIA2 = true;
#pragma warning restore CS0414 // El campo 'PagosCotizaciones.SECUENCIA2' está asignado pero su valor nunca se usa
#pragma warning disable CS0414 // El campo 'PagosCotizaciones.SECUENCIA3' está asignado pero su valor nunca se usa
        bool SECUENCIA3 = true;
#pragma warning restore CS0414 // El campo 'PagosCotizaciones.SECUENCIA3' está asignado pero su valor nunca se usa
        string indicador;
#pragma warning disable CS0414 // El campo 'PagosCotizaciones.indicador_de_tipo_de_pago_string' está asignado pero su valor nunca se usa
        string indicador_de_tipo_de_pago_string;
#pragma warning restore CS0414 // El campo 'PagosCotizaciones.indicador_de_tipo_de_pago_string' está asignado pero su valor nunca se usa
#pragma warning disable CS0649 // El campo 'PagosCotizaciones.txttipo' nunca se asigna y siempre tendrá el valor predeterminado null
        string txttipo;
#pragma warning restore CS0649 // El campo 'PagosCotizaciones.txttipo' nunca se asigna y siempre tendrá el valor predeterminado null
        string TXTTOTAL_STRING;
        string lblproceso;
#pragma warning disable CS0414 // El campo 'PagosCotizaciones.credito' está asignado pero su valor nunca se usa
        double credito = 0;
#pragma warning restore CS0414 // El campo 'PagosCotizaciones.credito' está asignado pero su valor nunca se usa
        int idcomprobante;
        string lblSerialPC;
        private void MEDIOS_DE_PAGO_Load(object sender, EventArgs e)
        {
            
            //PanelEnviarCorreo.Visible = false;
            cambiar_el_formato_de_separador_de_decimales();
            MOSTRAR_comprobante_serializado_POR_DEFECTO();
            validar_tipos_de_comprobantes();
            obtener_serial_pc();
            //mostrar_moneda_de_empresa();
            moneda = "DOP";
            configuraciones_de_diseño();
            Obtener_id_de_venta();
            mostrar_impresora();
            cargar_impresoras_del_equipo();
            validarPedidodeCliente();
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
                MessageBox.Show(ex.StackTrace );
            }
        }
        void cargar_impresoras_del_equipo()
        {
            txtImpresora.Items.Clear();
            for (var I=0;I< PrinterSettings.InstalledPrinters.Count;I++)
            {
                txtImpresora.Items.Add(PrinterSettings.InstalledPrinters[I]);
            }
            txtImpresora.Items.Add("Ninguna");
        }
        void Obtener_id_de_venta()
        {
            idcotizacion = Cotizaciones.idCotizacion;
        }
        void configuraciones_de_diseño()
        {
          
            TXTTOTAL.Text = moneda + " " + Cotizaciones.total;
            total = Cotizaciones.total;
            idcliente = 0;

        }
        void mostrar_moneda_de_empresa()
        {
            SqlCommand cmd = new SqlCommand("Select Moneda From Empresa", CONEXION.CONEXIONMAESTRA.conectar);
            try
            {
                CONEXION.CONEXIONMAESTRA.abrir();
                moneda =Convert.ToString  (cmd.ExecuteScalar());
                CONEXION.CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        public void obtener_serial_pc()
        {
           Bases.Obtener_serialPC (ref lblSerialPC);
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
                CONEXION.CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dibujarCOMPROBANTES();
        }
        string tipoImpresion;
        private void dibujarCOMPROBANTES()
        {
            FlowLayoutPanel3.Controls.Clear();
            try
            {
                CONEXION.CONEXIONMAESTRA.abrir();
                string query = "select tipodoc from Serializacion where Destino='FACTURAS'";
                SqlCommand cmd = new SqlCommand(query, CONEXION.CONEXIONMAESTRA.conectar);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Button b = new Button();
                    b.Text = rdr["tipodoc"].ToString();
                    b.Size = new System.Drawing.Size(191, 60);
                    b.BackColor = Color.FromArgb(70, 70, 71);
                    b.Font = new System.Drawing.Font("Segoe UI", 13);
                    b.FlatStyle = FlatStyle.Flat;
                    b.ForeColor = Color.WhiteSmoke;
                    FlowLayoutPanel3.Controls.Add(b);
                    if (b.Text == lblComprobante.Text)
                    {
                        tipoImpresion = b.Text;
                        b.Visible = false;
                    }
                    b.Click += miEvento;
                }
                    CONEXION.CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace );
            }
        }
        private void miEvento(System.Object sender, EventArgs e)
        {
            lblComprobante.Text = ((Button)sender).Text;
            dibujarCOMPROBANTES();
            validar_tipos_de_comprobantes();       
            identificar_el_tipo_de_pago();
            validarPedidodeCliente();
        }
        private void validarPedidodeCliente()
        {
            
          
          if (lblComprobante.Text =="FACTURA" && txttipo =="CREDITO")
            {
                panelClienteFactura.Visible = false;
            }
            if (lblComprobante.Text == "FACTURA" && txttipo == "EFECTIVO")
            {
                panelClienteFactura.Visible = true;
                lblindicador_de_factura_1.Text = "Cliente: (Obligatorio)";
                lblindicador_de_factura_1.ForeColor = Color.FromArgb(255, 192, 192);

            }
            else if (lblComprobante.Text != "FACTURA" && txttipo == "EFECTIVO")
            {
                panelClienteFactura.Visible = true;
                lblindicador_de_factura_1.Text = "Cliente: (Opcional)";
                lblindicador_de_factura_1.ForeColor = Color.DimGray;

            }

            if (lblComprobante.Text == "FACTURA" && txttipo == "TARJETA")
            {
                panelClienteFactura.Visible = true;
                lblindicador_de_factura_1.Text = "Cliente: (Obligatorio)";
                lblindicador_de_factura_1.ForeColor = Color.FromArgb(255, 192, 192);

            }
            else if (lblComprobante.Text != "FACTURA" && txttipo == "TARJETA")
            {
                panelClienteFactura.Visible = true;
                lblindicador_de_factura_1.Text = "Cliente: (Opcional)";
                lblindicador_de_factura_1.ForeColor = Color.DimGray;
            }


        }
        void validar_tipos_de_comprobantes()
        {
            buscar_Tipo_de_documentos_para_insertar_en_ventas();
            try
            {
                int numerofin;
                
                txtserie.Text = dtComprobantes.SelectedCells[2].Value.ToString();

                numerofin = Convert.ToInt32 ( dtComprobantes.SelectedCells[4].Value);
                idcomprobante= Convert.ToInt32(dtComprobantes.SelectedCells[5].Value);
                txtnumerofin.Text =Convert.ToString  ( numerofin + 1);
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
                CONEXION.CONEXIONMAESTRA .abrir();
                SqlDataAdapter da = new SqlDataAdapter("buscar_Tipo_de_documentos_para_insertar_en_facturas", CONEXION.CONEXIONMAESTRA.conectar);
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
       

        void ValidarPanelCredito()
        {
        }

        
        void limpiar_datos_de_registrodeclientes()
        {
        }

       
        void INGRESAR_LOS_DATOS()
        {
            CONVERTIR_TOTAL_A_LETRAS();
            completar_con_ceros_los_texbox_de_otros_medios_de_pago();
            vender_en_efectivo();
        }
        void vender_en_efectivo()
        {
            if (idcliente==0 )
            {
                MOSTRAR_cliente_standar();
            }
            if (lblComprobante.Text == "FACTURA" && idcliente == 0 && txttipo != "CREDITO")
            {
                MessageBox.Show("Seleccione un Cliente, para Facturas es Obligatorio", "Datos Incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (lblComprobante.Text == "FACTURA" && idcliente != 0)
            {
                procesar_venta_efectivo();
            }

            else if (lblComprobante.Text != "FACTURA" && txttipo != "CREDITO")
            {
                procesar_venta_efectivo();
            }
            else if (lblComprobante.Text != "FACTURA" && txttipo == "CREDITO")
            {
                procesar_venta_efectivo();
            }



           
        }
        void procesar_venta_efectivo()
        {
            actualizar_serie_mas_uno();
            validar_tipos_de_comprobantes();
            CONFIRMAR_VENTA_EFECTIVO();
            if (lblproceso=="PROCEDE")
            {                            
                //disminuir_stock_productos();
               // INSERTAR_KARDEX_SALIDA();
               
                validar_tipo_de_impresion();
            }
        }

        void mostrar_productos_agregados_a_factura()
        {
            try
            {
                DataTable dt = new DataTable();
                CONEXION.CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_productos_agregados_a_facturas", CONEXION.CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idFactura", idcotizacion);
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
   
        void actualizar_serie_mas_uno()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                CONEXION .CONEXIONMAESTRA.abrir();
                cmd = new SqlCommand("actualizar_serializacion_mas_uno", CONEXION .CONEXIONMAESTRA.conectar );
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

        void mostrar_factura_impresa_VISTA_PREVIA()
        {
           /* if (idcotizacion != 0)
            {
                bool estado;
                ReemplazarHtml();
                estado = Bases.enviarCorreo(correobase, contraseña, htmldeEnvio.Text, "Cotizacion", txtCorreo.Text, "");
                if (estado == true)
                {
                    MessageBox.Show("FacturaEnviada");
                }
                else
                {
                   // MessageBox.Show("Error de envio al correo");
                }
            }*/
            PanelImpresionvistaprevia.Visible = true;
            PanelImpresionvistaprevia.Dock = DockStyle.Fill;
            panelGuardado_de_datos.Dock = DockStyle.None;
            panelGuardado_de_datos.Visible = false;

            Presentacion.REPORTES.Impresion_de_comprobantes.Factura_report rpt = new Presentacion.REPORTES.Impresion_de_comprobantes.Factura_report();
            DataTable dt = new DataTable();
            try
            {
                asdasd();
                CONEXION.CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_factura_impreso", CONEXION.CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Id_factura", idcotizacion);
                da.SelectCommand.Parameters.AddWithValue("@total_en_letras", txtnumeroconvertidoenletra.Text);
                da.Fill(dt);
                rpt = new Presentacion.REPORTES.Impresion_de_comprobantes.Factura_report();
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
                da = new SqlDataAdapter("mostrar_factura_impreso", CONEXION.CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Id_factura", idcotizacion);
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
        void validar_tipo_de_impresion()
        {
            if (indicador == "VISTA PREVIA")
            {
                // MessageBox.Show(tipoImpresion);
                if (tipoImpresion == "FACTURA")
                {
                   
                    mostrar_factura_impresa_VISTA_PREVIA();
                }
                else if (tipoImpresion == "TICKET")
                {
                    mostrar_ticket_impreso_VISTA_PREVIA();
                }
            }
            else if (indicador == "DIRECTO")
            {
                if (tipoImpresion == "FACTURA")
                {
                    imprimir_directo_factura();
                }
                else if (tipoImpresion == "TICKET")
                {
                    imprimir_directo();

                }
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
                da.SelectCommand.Parameters.AddWithValue("@Id_factura", idcotizacion);
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
        void imprimir_directo()
        {
            mostrar_Ticket_lleno();
            try
            {
                DOCUMENTO = new PrintDocument();
                DOCUMENTO.PrinterSettings.PrinterName = txtImpresora.Text;
                if (DOCUMENTO.PrinterSettings.IsValid )
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
                MessageBox.Show (ex.StackTrace);
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
                da.SelectCommand.Parameters.AddWithValue("@Id_factura", idcotizacion);
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
                da.SelectCommand.Parameters.AddWithValue("@Id_factura", idcotizacion);
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

        void CONFIRMAR_VENTA_EFECTIVO()
        {
            try
            {
                CONEXION.CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("confirmar_factura", CONEXION.CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idFactura", idcotizacion);
                cmd.Parameters.AddWithValue("@montototal", total);
                cmd.Parameters.AddWithValue("@Saldo", vuelto);
                cmd.Parameters.AddWithValue("@Tipo_de_pago","EFECTIVO");
                cmd.Parameters.AddWithValue("@Estado", "EN ESPERA");
                cmd.Parameters.AddWithValue("@idcliente", idcliente);
                cmd.Parameters.AddWithValue("@Comprobante", lblComprobante.Text );
                cmd.Parameters.AddWithValue("@Numero_de_doc", (txtserie.Text + "-" + lblCorrelativoconCeros.Text ));
                cmd.Parameters.AddWithValue("@fecha_factura", DateTime.Now);
                cmd.Parameters.AddWithValue("@ACCION", "COTIZACION");
                cmd.Parameters.AddWithValue("@Fecha_de_pago", DateTime.Now);
                cmd.Parameters.AddWithValue("@Pago_con", TXTTOTAL.Text);
                cmd.Parameters.AddWithValue("@Referencia_tarjeta", "NULO");
                cmd.Parameters.AddWithValue("@Vuelto", vuelto);
                cmd.Parameters.AddWithValue("@Efectivo", TXTTOTAL.Text);
                cmd.Parameters.AddWithValue("@Credito", 0);
                cmd.Parameters.AddWithValue("@Tarjeta", 0);
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
     
        void MOSTRAR_cliente_standar()
        {
            SqlCommand com = new SqlCommand("select idclientev from clientes where Estado = 0", CONEXION.CONEXIONMAESTRA.conectar);
            try
            {
                CONEXION.CONEXIONMAESTRA.abrir();
                idcliente = Convert.ToInt32(com.ExecuteScalar());
                CONEXION.CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        void completar_con_ceros_los_texbox_de_otros_medios_de_pago()
        {
           
        }
        void CONVERTIR_TOTAL_A_LETRAS()
        {
            try
            {
             TXTTOTAL.Text = Convert.ToString(total);
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
                indicador_de_tipo_de_pago_string = "EFECTIVO";
        }

        void editar_eleccion_de_impresora()
        {
            try
            {
                CONEXION.CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("editar_eleccion_impresoras", CONEXION.CONEXIONMAESTRA.conectar );
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Impresora_Ticket", txtImpresora.Text);
                cmd.Parameters.AddWithValue("@idcaja", Cotizaciones.Id_caja);
                cmd.ExecuteNonQuery();
                CONEXION.CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void TXTTOTAL_Click(object sender, EventArgs e)
        {
        }

        private void btnGuardarImprimirdirecto_Click_1(object sender, EventArgs e)
        {
            if (restante == 0)
            {
                if (txtImpresora.Text != "Ninguna")
                {
                    editar_eleccion_de_impresora();
                    indicador = "DIRECTO";
                    identificar_el_tipo_de_pago();
                    INGRESAR_LOS_DATOS();
                }
                else
                {
                    MessageBox.Show("Seleccione una Impresora", "Impresora Inexistente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("El restante debe ser 0", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void TGuardarSinImprimir_Click_1(object sender, EventArgs e)
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


        private void btnagregarCliente_Click(object sender, EventArgs e)
        {
            
            limpiar_datos_de_registrodeclientes();
        }

        private void datalistadoclientes3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void txtclientesolicitabnte3_TextChanged(object sender, EventArgs e)
        {
            buscarclientes3();
            datalistadoclientes3.Visible = true;
        }
    
    void buscarclientes2()
    {


        try
        {
            DataTable dt = new DataTable();
            Obtener_datos.buscar_clientes(ref dt, txtclientesolicitabnte3.Text);
            datalistadoclientes2.DataSource = dt;
                /* datalistadoclientes2.Columns[1].Visible = false;
                 datalistadoclientes2.Columns[3].Visible = false;
                 datalistadoclientes2.Columns[4].Visible = false;
                 datalistadoclientes2.Columns[5].Visible = false;
                datalistadoclientes3.Columns[6].Visible = false;*/
                datalistadoclientes2.Columns[2].Width = 420;
            CONEXION.CONEXIONMAESTRA.cerrar();
        }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
        catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
        {

        }
    }
    void buscarclientes3()
    {
        try
        {
            DataTable dt = new DataTable();
            Obtener_datos.buscar_clientes(ref dt, txtclientesolicitabnte3.Text);
            datalistadoclientes3.DataSource = dt;
            /*datalistadoclientes3.Columns[1].Visible = false;
            datalistadoclientes3.Columns[3].Visible = false;
            datalistadoclientes3.Columns[4].Visible = false;
            datalistadoclientes3.Columns[5].Visible = false;
            datalistadoclientes3.Columns[6].Visible = false;*/
            datalistadoclientes3.Columns[2].Width = 420;
            CONEXION.CONEXIONMAESTRA.cerrar();
        }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
        catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
        {

        }
    }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        void mostrarDatos(int idcot)
        {
            /*DataTable dt = new DataTable();
            Obtener_datos obtener = new Obtener_datos();
            if(obtener.Mostrar_ticket_impresos(ref dt,idcot, Convert.ToString(txtnumeroconvertidoenletra)) == true)*/
        }

        public void ReemplazarHtml()
        {
           /* htmldeEnvio.Text = htmldeEnvio.Text.Replace("@Producto", datalistadoticket.SelectedCells[1].Value.ToString());
            htmldeEnvio.Text = htmldeEnvio.Text.Replace("@Cant", datalistadoticket.SelectedCells[2].Value.ToString());
            htmldeEnvio.Text = htmldeEnvio.Text.Replace("@P_Unit", datalistadoticket.SelectedCells[3].Value.ToString());
            htmldeEnvio.Text = htmldeEnvio.Text.Replace("@Direccion", datalistadoticket.SelectedCells[10].Value.ToString());
            htmldeEnvio.Text = htmldeEnvio.Text.Replace("@fecha", datalistadoticket.SelectedCells[18].Value.ToString());
            htmldeEnvio.Text = htmldeEnvio.Text.Replace("@Impuesto", datalistadoticket.SelectedCells[19].Value.ToString());

            htmldeEnvio.Text = htmldeEnvio.Text.Replace("@Subtotal_Impuesto", datalistadoticket.SelectedCells[20].Value.ToString());
            htmldeEnvio.Text = htmldeEnvio.Text.Replace("@Importe", datalistadoticket.SelectedCells[21].Value.ToString());
            htmldeEnvio.Text = htmldeEnvio.Text.Replace("@usuario", datalistadoticket.SelectedCells[22].Value.ToString());
            htmldeEnvio.Text = htmldeEnvio.Text.Replace("@Nombre", datalistadoticket.SelectedCells[26].Value.ToString());
            htmldeEnvio.Text = htmldeEnvio.Text.Replace("@Descuento", datalistadoticket.SelectedCells[28].Value.ToString());
            htmldeEnvio.Text = htmldeEnvio.Text.Replace("@Descuentos", datalistadoticket.SelectedCells[29].Value.ToString());
            htmldeEnvio.Text = htmldeEnvio.Text.Replace("@Numero_de_doc", datalistadoticket.SelectedCells[31].Value.ToString());
            htmldeEnvio.Text = htmldeEnvio.Text.Replace("@DescripcionDireccion", datalistadoticket.SelectedCells[32].Value.ToString());
            htmldeEnvio.Text = htmldeEnvio.Text.Replace("@Calle", datalistadoticket.SelectedCells[33].Value.ToString());
            htmldeEnvio.Text = htmldeEnvio.Text.Replace("@Municipio", datalistadoticket.SelectedCells[34].Value.ToString());
            htmldeEnvio.Text = htmldeEnvio.Text.Replace("@Telefono", datalistadoticket.SelectedCells[35].Value.ToString()); 
           */
        }
        string estado;
        string correobase;
        string contraseña;
        private void mostrarCorreoBase()
        {
            DataTable dt = new DataTable();
            Obtener_datos.mostrarCorreoBase(ref dt);
            foreach (DataRow row in dt.Rows)
            {
                estado = Bases.Desencriptar(row["EstadoEnvio"].ToString());
                correobase = Bases.Desencriptar(row["Correo"].ToString());
                contraseña = Bases.Desencriptar(row["Password"].ToString());
            }
        }
        private void datalistadoclientes3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtclientesolicitabnte3.Text = datalistadoclientes3.SelectedCells[2].Value.ToString();
            idcliente = Convert.ToInt32(datalistadoclientes3.SelectedCells[1].Value.ToString());
            correoCliente = datalistadoclientes3.SelectedCells[8].Value.ToString();
            //txtCorreo.Text = correoCliente;
            datalistadoclientes3.Visible = false;
        }


    }
}
