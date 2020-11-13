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

namespace SistemaVentas.Presentacion.VENTAS_MENU_PRINCIPAL
{
    public partial class MEDIOS_DE_PAGO : Form
    {
        public MEDIOS_DE_PAGO()
        {
            InitializeComponent();
        }
        private PrintDocument DOCUMENTO;
        string moneda;
        int idcliente;
        int idclienteasignado;

        int idFactura;
        double total;
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
            validarPedidodeCliente();
            datalistadoempleado.Visible = false;
            label7.Visible = false;
        }

        void calcular_restante()
        {
            try
            {
                double efectivo = 0;
                double tarjeta = 0;
              
                if(txtefectivo2.Text =="")
                {
                    efectivo = 0;
                }
                else
                {
                    efectivo = Convert.ToDouble(txtefectivo2.Text);
                }
                if (txtcredito2.Text =="")
                {
                    credito = 0;
                }
                else
                {
                    credito = Convert.ToDouble (txtcredito2.Text);
                }
                if(txttarjeta2.Text =="")
                {
                    tarjeta = 0;
                } 
                else
                {
                    tarjeta = Convert.ToDouble(txttarjeta2.Text);
                }

                if (txtefectivo2.Text == "0.00")
                {
                    efectivo = 0;
                }
                if (txtcredito2.Text == "0.00")
                {
                    credito = 0;
                }
                if (txttarjeta2.Text == "0.00")
                {
                    tarjeta = 0;

                }

                if (txtefectivo2.Text == ".")
                {
                    efectivo = 0;
                }
                if (txtcredito2.Text == ".")
                {
                    tarjeta = 0;
                }
                if (txttarjeta2.Text == ".")
                {
                    credito = 0;
                }
                ///////
                //Total= 5 
                //Efectivo= 10
                // Tarjeta = 22
                //EC=E-(T+TA)
                //EC= 10-(5+22)
                //EC= 3
                //V=E-(T-TA)
                //V=10-(5-2)
                //V=7
       
                try
                {
                    if (efectivo>total)
                    {
                        efectivo_calculado = efectivo - (total + credito + tarjeta);
                        if (efectivo_calculado <0)
                        {
                            vuelto = 0;
                                TXTVUELTO.Text = "0";
                            txtrestante.Text =Convert.ToString ( efectivo_calculado);
                            restante = efectivo_calculado;
                        }
                        else
                        {
                            vuelto = efectivo - (total - credito - tarjeta);
                            TXTVUELTO.Text = Convert.ToString ( vuelto);
                            restante = efectivo - (total + credito + tarjeta+efectivo_calculado );
                            txtrestante.Text = Convert.ToString ( restante);
                            txtrestante.Text = decimal.Parse(txtrestante.Text).ToString("##0.00");
                        }
                      
                    }
                    else
                    {
                        vuelto = 0;
                        TXTVUELTO.Text = "0";
                        efectivo_calculado = efectivo;
                        restante = total - efectivo_calculado - credito - tarjeta;
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
            idFactura = VENTAS_MENU_PRINCIPALOK.idVenta;
        }
        void configuraciones_de_diseño()
        {
            TXTVUELTO.Text = "0.0";
            txtrestante.Text = "0.0";
            TXTTOTAL.Text = moneda + " " + VENTAS_MENU_PRINCIPALOK.total;
            total = VENTAS_MENU_PRINCIPALOK.total;
            txtefectivo2.Text =Convert.ToString (total);
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
                //MessageBox.Show(lblComprobante.Text);
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
            ValidarPanelCredito();
        }
        void ValidarPanelCredito()
        {
            try
            {
                double textocredito = 0;
                if (txtcredito2.Text ==".")
                {
                    textocredito = 0;
                }
                if (txtcredito2.Text =="")
                {
                    textocredito = 0;
                }
                else
                {
                    textocredito = Convert.ToDouble(txtcredito2.Text);
                }

                if (textocredito>0)
                {
                    pcredito.Visible = true;
                    panelClienteFactura.Visible = false;
                }
                else
                {
                    pcredito.Visible = false;
                    panelClienteFactura.Visible = true;

                    idcliente = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            if (INDICADOR_DE_FOCO==1)
            {
                txtefectivo2.Text = txtefectivo2.Text + "1";
            }
            else if (INDICADOR_DE_FOCO==2)
            {
                txttarjeta2.Text = txttarjeta2.Text + "1";
            }
            else if (INDICADOR_DE_FOCO==3)
            {
                txtcredito2.Text = txtcredito2.Text + "1";
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (INDICADOR_DE_FOCO == 1)
            {
                txtefectivo2.Text = txtefectivo2.Text + "2";
            }
            else if (INDICADOR_DE_FOCO == 2)
            {
                txttarjeta2.Text = txttarjeta2.Text + "2";
            }
            else if (INDICADOR_DE_FOCO == 3)
            {
                txtcredito2.Text = txtcredito2.Text + "2";
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (INDICADOR_DE_FOCO == 1)
            {
                txtefectivo2.Text = txtefectivo2.Text + "3";
            }
            else if (INDICADOR_DE_FOCO == 2)
            {
                txttarjeta2.Text = txttarjeta2.Text + "3";
            }
            else if (INDICADOR_DE_FOCO == 3)
            {
                txtcredito2.Text = txtcredito2.Text + "3";
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (INDICADOR_DE_FOCO == 1)
            {
                txtefectivo2.Text = txtefectivo2.Text + "4";

            }
            else if (INDICADOR_DE_FOCO == 2)
            {
                txttarjeta2.Text = txttarjeta2.Text + "4";
            }
            else if (INDICADOR_DE_FOCO == 3)
            {
                txtcredito2.Text = txtcredito2.Text + "4";
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (INDICADOR_DE_FOCO == 1)
            {
                txtefectivo2.Text = txtefectivo2.Text + "5";

            }
            else if (INDICADOR_DE_FOCO == 2)
            {
                txttarjeta2.Text = txttarjeta2.Text + "5";
            }
            else if (INDICADOR_DE_FOCO == 3)
            {
                txtcredito2.Text = txtcredito2.Text + "5";
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (INDICADOR_DE_FOCO == 1)
            {
                txtefectivo2.Text = txtefectivo2.Text + "6";

            }
            else if (INDICADOR_DE_FOCO == 2)
            {
                txttarjeta2.Text = txttarjeta2.Text + "6";
            }
            else if (INDICADOR_DE_FOCO == 3)
            {
                txtcredito2.Text = txtcredito2.Text + "6";
            }
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (INDICADOR_DE_FOCO == 1)
            {
                txtefectivo2.Text = txtefectivo2.Text + "7";

            }
            else if (INDICADOR_DE_FOCO == 2)
            {
                txttarjeta2.Text = txttarjeta2.Text + "7";
            }
            else if (INDICADOR_DE_FOCO == 3)
            {
                txtcredito2.Text = txtcredito2.Text + "7";
            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (INDICADOR_DE_FOCO == 1)
            {
                txtefectivo2.Text = txtefectivo2.Text + "8";

            }
            else if (INDICADOR_DE_FOCO == 2)
            {
                txttarjeta2.Text = txttarjeta2.Text + "8";
            }
            else if (INDICADOR_DE_FOCO == 3)
            {
                txtcredito2.Text = txtcredito2.Text + "8";
            }
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (INDICADOR_DE_FOCO == 1)
            {
                txtefectivo2.Text = txtefectivo2.Text + "9";

            }
            else if (INDICADOR_DE_FOCO == 2)
            {
                txttarjeta2.Text = txttarjeta2.Text + "9";
            }
            else if (INDICADOR_DE_FOCO == 3)
            {
                txtcredito2.Text = txtcredito2.Text + "9";
            }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (INDICADOR_DE_FOCO == 1)
            {
                txtefectivo2.Text = txtefectivo2.Text + "0";

            }
            else if (INDICADOR_DE_FOCO == 2)
            {
                txttarjeta2.Text = txttarjeta2.Text + "0";
            }
            else if (INDICADOR_DE_FOCO == 3)
            {
                txtcredito2.Text = txtcredito2.Text + "0";
            }
        }

        private void btnpunto_Click(object sender, EventArgs e)
        {
            if (INDICADOR_DE_FOCO == 1)
            {
                if (SECUENCIA1 == true  ) 
                {
                    txtefectivo2.Text = txtefectivo2.Text + ".";
                    SECUENCIA1 = false;
                }
           
                 else
               {
                    return;
                }

            }
            else if (INDICADOR_DE_FOCO == 2)
            {
                if (SECUENCIA2 == true)
                {
                    txttarjeta2 .Text = txttarjeta2.Text + ".";
                    SECUENCIA2 = false;
                }

                else
                {
                    return;
                }

            }
            else if (INDICADOR_DE_FOCO == 3)
            {
                if (SECUENCIA3 == true)
                {
                    txtcredito2 .Text = txtcredito2.Text + ".";
                    SECUENCIA3 = false;
                }

                else
                {
                    return;
                }

            }

        }

        private void btnborrartodo_Click(object sender, EventArgs e)
        {
            if (INDICADOR_DE_FOCO==1)
            {
                txtcredito2.Clear();
                SECUENCIA1 = true;
            }
            else if (INDICADOR_DE_FOCO==2)
            {
                txttarjeta2.Clear();
                SECUENCIA2 = true;
            }
            else if (INDICADOR_DE_FOCO ==3)
            {
                txtcredito2.Clear();
                SECUENCIA3 = true;
            }
        }

        private void FlowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtclientesolicitabnte3_TextChanged(object sender, EventArgs e)
        {
            buscarclientes3();
            datalistadoclientes3.Visible = true;
        }

        private void txtclientesolicitabnte2_TextChanged(object sender, EventArgs e)
        {
            buscarclientes2();
            datalistadoclientes2.Visible = true;
        }
        void buscarclientes2()
        {
        

            try
            {


                DataTable dt = new DataTable();
                Obtener_datos.buscar_clientes(ref dt, txtclientesolicitabnte2.Text);
                datalistadoclientes2.DataSource = dt;
                datalistadoclientes2.Columns[1].Visible = false;
                datalistadoclientes2.Columns[3].Visible = false;
                datalistadoclientes2.Columns[4].Visible = false;
                datalistadoclientes2.Columns[5].Visible = false;
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
            idcliente = Convert.ToInt32(datalistadoclientes2.SelectedCells[1].Value.ToString());
            txtclientesolicitabnte2.Text = datalistadoclientes2.SelectedCells[2].Value.ToString();
            datalistadoclientes2.Visible = false;
        }

        private void txtefectivo2_Click(object sender, EventArgs e)
        {
            calcular_restante();
            INDICADOR_DE_FOCO = 1;
            if (txtrestante.Text =="0.00")
            {
                txtefectivo2.Text = "";
            }
            else
            {
                txtefectivo2.Text = txtrestante.Text;
            }
        }

        private void txttarjeta2_Click(object sender, EventArgs e)
        {
            calcular_restante();
            INDICADOR_DE_FOCO = 2;
            if (txtrestante.Text == "0.00")
            {
                txttarjeta2 .Text = "";
            }
            else
            {
                txttarjeta2.Text = txtrestante.Text;
            }
        }

        private void txtcredito2_Click(object sender, EventArgs e)
        {
            calcular_restante();
            INDICADOR_DE_FOCO = 3;
            if (txtrestante.Text == "0.00")
            {
                txtcredito2 .Text = "";
            }
            else
            {
                txtcredito2.Text = txtrestante.Text;
                ValidarPanelCredito();
            }
        }

        private void TGuardarSinImprimir_Click(object sender, EventArgs e)
        {
          
        }
 
        void INGRESAR_LOS_DATOS()
        {
            CONVERTIR_TOTAL_A_LETRAS();
            completar_con_ceros_los_texbox_de_otros_medios_de_pago();
            if (txttipo =="EFECTIVO" && vuelto >=0)
            {
                vender_en_efectivo();

            }
            else if (txttipo == "EFECTIVO" && vuelto < 0)
            {
               MessageBox.Show("El vuelto no puede ser menor a el Total pagado ", "Datos Incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            // condicional para creditos
            if (txttipo == "CREDITO" && datalistadoclientes2.Visible == false)
            {
                vender_en_efectivo();
            }
            else if (txttipo == "CREDITO" && datalistadoclientes2.Visible == true)
            {
             MessageBox.Show("Seleccione un Cliente para Activar Pago a Credito", "Datos Incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (txttipo == "TARJETA")
            {
                vender_en_efectivo();
            }


            if (txttipo == "MIXTO")
            {
                vender_en_efectivo();
            }

        }
        void vender_en_efectivo()
        {
            if (idcliente==0 || idcliente==1 )
            {
                MOSTRAR_cliente_standar();
            }
            if (lblComprobante.Text == "FACTURA" && idcliente > -1 && idcliente < 2 && txttipo != "CREDITO")
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
                disminuir_stock_productos();
                INSERTAR_KARDEX_SALIDA();
                aumentar_monto_a_cliente();
                validar_tipo_de_impresion();
            }
        }
        void INSERTAR_KARDEX_SALIDA()
        {
            try
            {
                foreach (DataGridViewRow row in datalistadoDetalleVenta.Rows )
                {
                    int Id_producto = Convert.ToInt32(row.Cells["Id_producto"].Value);
                    double cantidad = Convert.ToDouble(row.Cells["Cantidad"].Value);
                    string STOCK = Convert.ToString(row.Cells["Stock"].Value);
                    if (STOCK != "Ilimitado")
                    {
                        CONEXION.CONEXIONMAESTRA.abrir();
                        SqlCommand cmd = new SqlCommand("insertar_KARDEX_SALIDA", CONEXION.CONEXIONMAESTRA.conectar );
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Fecha", DateTime.Now);
                        cmd.Parameters.AddWithValue("@Motivo", "Factura #" + lblComprobante.Text + " " + lblCorrelativoconCeros.Text);
                        cmd.Parameters.AddWithValue("@Cantidad ", cantidad);
                        cmd.Parameters.AddWithValue("@Id_producto", Id_producto);
                        cmd.Parameters.AddWithValue("@Id_usuario", VENTAS_MENU_PRINCIPALOK.idusuario_que_inicio_sesion);
                        cmd.Parameters.AddWithValue("@Tipo", "SALIDA");
                        cmd.Parameters.AddWithValue("@Estado", "DESPACHO CONFIRMADO");
                        cmd.Parameters.AddWithValue("@Id_caja", VENTAS_MENU_PRINCIPALOK.Id_caja);
                        cmd.ExecuteNonQuery();
                        CONEXION.CONEXIONMAESTRA.cerrar();

                    }

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
                SqlDataAdapter da = new SqlDataAdapter("mostrar_productos_agregados_a_factura", CONEXION.CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idFactura", idFactura);
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
            foreach (DataGridViewRow row in datalistadoDetalleVenta.Rows )
            {
                int idproducto = Convert.ToInt32(row.Cells["Id_producto"].Value);
                double cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                try
                  {
                    //MessageBox.Show("entramos");
                     CONEXION.CONEXIONMAESTRA.abrir();
                     SqlCommand cmd = new SqlCommand("disminuir_stock", CONEXION.CONEXIONMAESTRA.conectar);
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

        void validar_tipo_de_impresion()
        {
           if ( indicador =="VISTA PREVIA")
            {
               // MessageBox.Show(tipoImpresion);
                if(tipoImpresion == "FACTURA")
                {
                    mostrar_factura_impresa_VISTA_PREVIA();
                }
                else if(tipoImpresion == "TICKET")
                {
                    mostrar_ticket_impreso_VISTA_PREVIA();
                }
            }
           else if (indicador =="DIRECTO")
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
                da.SelectCommand.Parameters.AddWithValue("@Id_factura", idFactura);
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
                da.SelectCommand.Parameters.AddWithValue("@Id_factura", idFactura);
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
                da.SelectCommand.Parameters.AddWithValue("@Id_factura", idFactura);
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
        void mostrar_factura_impresa_VISTA_PREVIA()
        {
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
                da.SelectCommand.Parameters.AddWithValue("@Id_factura", idFactura);
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
                da.SelectCommand.Parameters.AddWithValue("@Id_factura", idFactura);
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
                CONEXION.CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("confirmar_factura", CONEXION.CONEXIONMAESTRA.conectar );
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idFactura", idFactura);
                cmd.Parameters.AddWithValue("@montototal", total);
                cmd.Parameters.AddWithValue("@Saldo", vuelto);
                cmd.Parameters.AddWithValue("@Tipo_de_pago",txttipo );
                cmd.Parameters.AddWithValue("@Estado", "CONFIRMADO");
                cmd.Parameters.AddWithValue("@idcliente", idcliente);
                cmd.Parameters.AddWithValue("@Comprobante", lblComprobante.Text );
                cmd.Parameters.AddWithValue("@Numero_de_doc", (txtserie.Text + "-" + lblCorrelativoconCeros.Text ));
                cmd.Parameters.AddWithValue("@fecha_factura", DateTime.Now);
                cmd.Parameters.AddWithValue("@ACCION", "Factura");
                cmd.Parameters.AddWithValue("@Fecha_de_pago", txtfecha_de_pago.Value );
                cmd.Parameters.AddWithValue("@Pago_con", txtefectivo2.Text);
                cmd.Parameters.AddWithValue("@Referencia_tarjeta", "NULO");
                cmd.Parameters.AddWithValue("@Vuelto", vuelto);
                cmd.Parameters.AddWithValue("@Efectivo", efectivo_calculado);
                cmd.Parameters.AddWithValue("@Credito", txtcredito2.Text);
                cmd.Parameters.AddWithValue("@Tarjeta", txttarjeta2.Text);
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
        void aumentar_monto_a_cliente()
        {
            if (credito>0)
            {
             try
             {
                CONEXION.CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("aumentar_saldo_a_cliente", CONEXION.CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Saldo", txtcredito2.Text);
                cmd.Parameters.AddWithValue("@idcliente", idcliente);
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
            if (txtefectivo2.Text == "")
            {
                txtefectivo2.Text = "0";
            }
            if (txtcredito2.Text == "")
            {
                txtcredito2.Text = "0";
            }
            if (txttarjeta2.Text == "")
            {
                txttarjeta2.Text = "0";
            }
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
            int indicadorEfectivo = 4;
            int indicadorCredito = 2;
            int indicadorTarjeta = 3;

            // validacion para evitar valores vacios
            if (txtefectivo2.Text =="")
            {
                txtefectivo2.Text = "0";
            }
            if (txttarjeta2 .Text == "")
            {
                txttarjeta2.Text = "0";
            }
            if (txtcredito2 .Text == "")
            {
                txtcredito2.Text = "0";
            }
            //validacion de .
            if (txtefectivo2.Text ==".")
            {
                txtefectivo2.Text = "0";
            }
            if (txttarjeta2 .Text == ".")
            {
                txttarjeta2.Text = "0";
            }
            if (txtcredito2 .Text == ".")
            {
                txtcredito2.Text = "0";
            }
            //validacion de 0
            if (txtefectivo2.Text =="0")
            {
                indicadorEfectivo = 0;
            }
            if (txttarjeta2 .Text == "0")
            {
                indicadorTarjeta = 0;
            }
            if (txtcredito2 .Text == "0")
            {
                indicadorCredito  = 0;
            }
            //calculo de indicador
            int calculo_identificacion = indicadorCredito + indicadorEfectivo + indicadorTarjeta;
            //consulta al identificador
            if (calculo_identificacion ==4)
            {
                indicador_de_tipo_de_pago_string = "EFECTIVO";
            }
            if (calculo_identificacion == 2)
            {
                indicador_de_tipo_de_pago_string = "CREDITO";
            }
            if (calculo_identificacion == 3)
            {
                indicador_de_tipo_de_pago_string = "TARJETA";
            }
            if (calculo_identificacion >4)
            {
                indicador_de_tipo_de_pago_string = "MIXTO";
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
                SqlCommand cmd = new SqlCommand("editar_eleccion_impresoras", CONEXION.CONEXIONMAESTRA.conectar );
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Impresora_Ticket", txtImpresora.Text);
                cmd.Parameters.AddWithValue("@idcaja", VENTAS_MENU_PRINCIPALOK.Id_caja);
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
                if (txtImpresora.Text != "Ninguna")
                {
                    if (Envio.Checked == true)
                    {
                        if (idEmpleado != 0)
                        {
                            editar_eleccion_de_impresora();
                            indicador = "DIRECTO";
                            identificar_el_tipo_de_pago();
                            INGRESAR_LOS_DATOS();
                            AsignarPersonalEnvio();
                            actualizarVehiculo(idvehiculo);
                            actualizarEmpleado(idEmpleado);
                        }
                        else
                        {
                            MessageBox.Show("Selecciona un Empleado", "Empleados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    } else
                    {
                        editar_eleccion_de_impresora();
                        indicador = "DIRECTO";
                        identificar_el_tipo_de_pago();
                        INGRESAR_LOS_DATOS();
                    }
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

        private void btnGuardarImprimirdirecto_Click_1(object sender, EventArgs e)
        {
            if (idEmpleado !=0)
            {
                ImprimirDirecto();
            }
            else
            {
            }
        }

        public void GuardarSinImprimir()
        {
            if (restante == 0)
            {
                if (Envio.Checked == true)
                {
                    if(idEmpleado != 0)
                    {
                        indicador = "VISTA PREVIA";
                        identificar_el_tipo_de_pago();
                        INGRESAR_LOS_DATOS();
                        AsignarPersonalEnvio();
                        actualizarVehiculo(idvehiculo);
                        actualizarEmpleado(idEmpleado);
                    } else
                    {
                        MessageBox.Show("Selecciona un Empleado", "Empleados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                } else
                {
                    indicador = "VISTA PREVIA";
                    identificar_el_tipo_de_pago();
                    INGRESAR_LOS_DATOS();
                }
            }
            else
            {
                MessageBox.Show("El restante debe ser 0", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void TGuardarSinImprimir_Click_1(object sender, EventArgs e)
        {
            
                GuardarSinImprimir();
            
        }

        private void txtefectivo2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txtefectivo2, e);

        }

        private void txttarjeta2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txttarjeta2, e);

        }

        private void txtcredito2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txtcredito2, e);

        }

        private void btnagregarCliente_Click(object sender, EventArgs e)
        {
            Presentacion.CLIENTES_PROVEEDORES.ClientesOk frm = new Presentacion.CLIENTES_PROVEEDORES.ClientesOk();
            frm.ShowDialog();
        }

        private void datalistadoclientes3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idcliente = Convert.ToInt32(datalistadoclientes3.SelectedCells[1].Value.ToString());
            //MessageBox.Show(idcliente.ToString());
            txtclientesolicitabnte3.Text = datalistadoclientes3.SelectedCells[2].Value.ToString();
            datalistadoclientes3.Visible = false;
        }

        private void Envio_CheckedChanged(object sender, EventArgs e)
        {

            if (Envio.Checked == true)
            {
                // Verificacion disponibilidad de Personal. ---------------GOOD-------------
                // Verificar vehiculos disponibles
                // Determinar disponibilidad: Asignar personal para el envio.
                // Verificar personal capacitado.
                if (txtclientesolicitabnte3.TextLength > 0)
                {
                    if (VerificarEstadoPersonal() && verificarCliente() && VerificarEstadoVehiculos())
                    {
                        label7.Visible = true;
                        datalistadoempleado.Visible = true;
                        if (Envio.Checked == false)
                        {
                            datalistadoempleado.Visible = false;
                            label7.Visible = false;

                        }
                        ObtenerVehiculo();

                    }
                    else
                    {
                        MessageBox.Show("Verifica el Estado del Personal, Clientes o Vehiculos", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
                else
                {
                    MessageBox.Show("Seleccione un cliente correctamente", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                datalistadoempleado.Visible = false;
                label7.Visible = false;
            }
        }

        private void panelGuardado_de_datos_Paint(object sender, PaintEventArgs e)
        {

        }

        public bool VerificarEstadoPersonal()
        {
            DataTable dt = new DataTable();
            Obtener_datos.EstadoPersonal(ref dt);
            datalistadoempleado.DataSource = dt;
            
            if(datalistadoempleado.Rows.Count > 0)
            {
                return true;
            } else
            {
                return false;
            }
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
            idEmpleado = Convert.ToInt32(datalistadoempleado.SelectedCells[0].Value);
            nombreEmpleado = datalistadoempleado.SelectedCells[1].Value.ToString();
            departamentoEmpleado = datalistadoempleado.SelectedCells[2].Value.ToString();
            estadoEmpleado = datalistadoempleado.SelectedCells[3].Value.ToString();
            MessageBox.Show("El Empleado " + nombreEmpleado + " llevara el pedido", "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                idclienteasignado = 0;
                CONEXION.CONEXIONMAESTRA.abrir();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("verificarCliente", CONEXION.CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@nombre", txtclientesolicitabnte3.Text);
                da.Fill(dt);
                CONEXION.CONEXIONMAESTRA.cerrar();
                DATALISTADOVERIFICAR.DataSource = dt;
                idclienteasignado = Convert.ToInt32(DATALISTADOVERIFICAR.SelectedCells[0].Value);
                nombreCliente = DATALISTADOVERIFICAR.SelectedCells[1].Value.ToString();
                direccioncliente = DATALISTADOVERIFICAR.SelectedCells[2].Value.ToString();

                CONEXION.CONEXIONMAESTRA.cerrar();
                if (idclienteasignado > 1)
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

        public void AsignarPersonalEnvio()
        {
            Logica.Pedidos parametros = new Logica.Pedidos();
            Insertar_datos datos = new Insertar_datos();
            parametros.idCliente = idclienteasignado;
            parametros.idFactura = idFactura;
            parametros.idEmpleado = idEmpleado;
            parametros.idVehiculo = idvehiculo;
            parametros.FechaEnvio = DateTime.Now;
            parametros.Destinatario = nombreCliente;
            parametros.DireccionDestinatario = direccioncliente;
            parametros.Estado = "EN CURSO";
            if (datos.insertarPedido(parametros) == true)
            {
                //mostrar();
            }
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
            Presentacion.CLIENTES_PROVEEDORES.ClientesOk frm = new Presentacion.CLIENTES_PROVEEDORES.ClientesOk();
            frm.ShowDialog();
        }

        private void datalistadoclientes3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
