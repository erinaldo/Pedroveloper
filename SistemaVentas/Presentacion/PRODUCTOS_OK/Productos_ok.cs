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
using System.Globalization;
using System.Data.OleDb;
using System.IO;
using System.Threading;
using System.Management;
using SistemaVentas.Logica;
using SistemaVentas.Datos;
namespace SistemaVentas.Presentacion.PRODUCTOS_OK
{
    public partial class Productos_ok : Form
    {
        int txtcontador;

        public Productos_ok()
        {
            InitializeComponent();
        }
        public static int idcaja;
        private int idUnidadCompra;
        private int idClaveSatCompra;
        public int idClaveSat;
        private void PictureBox2_Click(object sender, EventArgs e)
        {

            PANELREGISTRO.Visible = true;
            PANELINFOR.Visible = true;

            LIMPIAR();
            //PANELDEPARTAMENTO.Visible = true;
            /* CheckInventarios.Checked = true;
             PANELINVENTARIO.Visible = true;*/
            //PANELCATEGORIASELECT.Visible = true;
            /* btnGuardar_grupo.Visible = false;
             BtnGuardarCambios.Visible = false;
             BtnCancelar.Visible = false;
             btnNuevoGrupo.Visible = true;
             mostrar_grupos();
             txtCategoria.Text = "";
             txtPorcentajeGanancia.Clear();*/

            /*blEstadoCodigo.Text = "NUEVO";
            //PANELCATEGORIASELECT.Visible = true;
            btnGuardar_grupo.Visible = false;
            BtnGuardarCambios.Visible = false;
            BtnCancelar.Visible = false;
            btnNuevoGrupo.Visible = true;
            mostrar_grupos();*/

           /* txtapartirde.Text = "0";
            txtstock2.ReadOnly = false;
            Panel25.Enabled = true;
            Panel21.Visible = false;
            Panel22.Visible = false;
            Panel18.Visible = false;
            TXTIDPRODUCTOOk.Text = "0";*/

            //PANELINVENTARIO.Visible = true;

            /*  txtdescripcion.AutoCompleteCustomSource = CONEXION.DataHelper.LoadAutoComplete();
              txtdescripcion.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
              txtdescripcion.AutoCompleteSource = AutoCompleteSource.CustomSource;*/

            /* PANELDEPARTAMENTO.Visible = true;
             porunidad.Checked = true;
             No_aplica_fecha.Checked = false;
             Panel6.Visible = false;

             btnagregaryguardar.Visible = true;
             btnagregar.Visible = false;


             txtdescripcion.Text = "";
             PANELINVENTARIO.Visible = true;


             TGUARDAR.Visible = true;
             TGUARDARCAMBIOS.Visible = false;

                 */

        }
        internal void LIMPIAR()
        {
            txtidproducto.Text = "";
            txtdescripcion.Text = "";
            txtcosto.Text = "0";
            TXTPRECIODEVENTA2.Text = "0";
            // txtpreciomayoreo.Text = "0";
            txtCategoria.Text = "";

            agranel.Checked = false;
            txtstockminimo.Text = "0";
            txtstock2.Text = "0";
            lblEstadoCodigo.Text = "NUEVO";
        }

        public static int idusuario;





        private void Productos_ok_Load(object sender, EventArgs e)
        {
            PANELREGISTRO.Visible = false;
            panelProveedor.Visible = false;
            datalistadoCategoriasInformacionBasicaPanel.Visible = false;
            PanelInformacionAdicional.Visible = false;
            panelCategoria.Visible = false;
            panelUnidad.Visible = false;
            panelClaveUnidadSat.Visible = false;
            txtDepartamento.Enabled = false;
            panelCategoriaAgregar.Visible = false;
            PANELINFOR.Visible = false;
            
            Obtener_datos.mostrar_inicio_De_sesion(ref idusuario);
            Obtener_datos.Obtener_id_caja_PorSerial(ref idcaja);


            /*
            if (Obtener_datos.VerificarItbis() == true)
            {
                Impuestos.Visible = true;
            }
            Bases.Cambiar_idioma_regional();

            PANELDEPARTAMENTO.Visible = false;
            txtbusca.Focus();
            txtbusca.SelectAll();
            sumar_costo_de_inventario_CONTAR_PRODUCTOS();
            buscar();
            mostrar_grupos();
            */
        }

        private void BtnGuardarCambios_Click_1(object sender, EventArgs e)
        {

        }

        private void mostrar_grupos()
        {
            //PANELCATEGORIASELECT.Visible = true;
           /* try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("mostrar_grupos", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@buscar", txtgrupo.Text);
                da.Fill(dt);
                datalistadoCategorias.DataSource = dt;
                con.Close();

                datalistadoCategorias.DataSource = dt;
                datalistadoCategorias.Columns[2].Visible = false;
                datalistadoCategorias.Columns[3].Width = 500;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Bases.Multilinea(ref datalistado);*/
        }

        private void btnGuardar_grupo_Click_1(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("insertar_Grupo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Grupo", txtCategoria.Text);
                cmd.Parameters.AddWithValue("@Por_defecto", "NO");
                cmd.ExecuteNonQuery();
                con.Close();
                mostrar_grupos();

                lblIdGrupo.Text = datalistadoCategorias.SelectedCells[2].Value.ToString();
                txtCategoria.Text = datalistadoCategorias.SelectedCells[3].Value.ToString();

                //PANELCATEGORIASELECT.Visible = false;
                btnGuardar_grupo.Visible = false;
                BtnGuardarCambios.Visible = false;
                BtnCancelar.Visible = false;
                btnNuevoGrupo.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnNuevoGrupo_Click(object sender, EventArgs e)
        {
            txtCategoria.Text = "Escribe el Nuevo GRUPO";
            txtCategoria.SelectAll();
            txtCategoria.Focus();

            //PANELCATEGORIASELECT.Visible = false;
            btnGuardar_grupo.Visible = true;
            BtnGuardarCambios.Visible = false;
            BtnCancelar.Visible = true;
            btnNuevoGrupo.Visible = false;
        }

        private void txtgrupo_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnCancelar_Click_1(object sender, EventArgs e)
        {
            //PANELCATEGORIASELECT.Visible = false;
            btnGuardar_grupo.Visible = false;
            BtnGuardarCambios.Visible = false;
            BtnCancelar.Visible = false;
            btnNuevoGrupo.Visible = true;
            txtCategoria.Clear();
            mostrar_grupos();

        }
        private void TGUARDAR_Click_1(object sender, EventArgs e)
        {
            /*TextBox[] array = {  txtdescripcion, txtcodigodebarras, txtcosto, TXTPRECIODEVENTA2, txtgrupo };
             if (Insertar_datos.ValidTextIsNotNullOrEmpty(array))
             {
                 if(txtstock2.Text != "0" && txtcosto.Text !="0" && TXTPRECIODEVENTA2.Text != "0")
                 {
                    // double txtpreciomayoreoV = Convert.ToDouble(txtpreciomayoreo.Text);
                     double txtapartirdeV = Convert.ToDouble(txtapartirde.Text);
                     double txtcostoV = Convert.ToDouble(txtcosto.Text);
                     double TXTPRECIODEVENTA2V = Convert.ToDouble(TXTPRECIODEVENTA2.Text);
                    // if (txtpreciomayoreo.Text == "") txtpreciomayoreo.Text = "0";
                     if (txtapartirde.Text == "") txtapartirde.Text = "0";
                    // if ((txtpreciomayoreoV > 0 & Convert.ToDouble(txtapartirde.Text) > 0) | (txtpreciomayoreoV == 0 & txtapartirdeV == 0))
                    // {
                         if (txtcostoV >= TXTPRECIODEVENTA2V)
                         {

                             DialogResult result;
                             result = MessageBox.Show("El precio del Articulo es menor o igual que el costo, Esto te puede generar perdidas", "Producto con Perdidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                             if (result == DialogResult.OK)
                             {
                                 TXTPRECIODEVENTA2.Focus();
                                 TXTPRECIODEVENTA2.SelectAll();
                             }
                         }
                         else if (txtcostoV < TXTPRECIODEVENTA2V)
                         {
                             if(Convert.ToDouble(txtpreciomayoreo.Text) <= Convert.ToDouble(txtcosto.Text) && 
                                 (Convert.ToDouble(txtpreciomayoreo.Text) != 0 || Convert.ToDouble(txtpreciomayoreo.Text) != 0.00))
                             {

                                 MessageBox.Show("El precio al por mayor es menor o igual que el costo, Esto te puede generar perdidas", "Producto con Perdidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                 txtpreciomayoreo.Focus();
                                 txtpreciomayoreo.SelectAll();
                             }
                             else
                             {
                                 insertar_productos();
                             }
                         }
                     }
                     else if (txtpreciomayoreoV != 0 | txtapartirdeV != 0)
                     {
                         MessageBox.Show("Estas configurando Precio mayoreo, debes completar los campos de Precio mayoreo y A partir de, si no deseas configurarlo dejalos en blanco", "Datos incompletos", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                     }
                 }
                 else
                 {
                     MessageBox.Show("Los datos estan incorrectos, el formato es:" + "\nPrecio costo = 100\nPrecio articulo mayor a 100\n%Ganancia puede ser 0", "Datos incompletos", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                 }
             }*/
        }
        private void insertar_productos()
        {
            /* double itbis;
             if (txtpreciomayoreo.Text == "0" | txtpreciomayoreo.Text == "") txtapartirde.Text = "0";

                 if (Impuestos.Checked)
                 {
                     itbis = 0.18;
                 }
                 else
                 {
                     itbis = 0.00;
                 }
                 try
                 {
                     SqlConnection con = new SqlConnection();
                     con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                     con.Open();
                     SqlCommand cmd = new SqlCommand();
                     cmd = new SqlCommand("insertar_Producto", con);
                     cmd.CommandType = CommandType.StoredProcedure;
                     cmd.Parameters.AddWithValue("@Descripcion", txtdescripcion.Text);
                     cmd.Parameters.AddWithValue("@Imagen", ".");
                     cmd.Parameters.AddWithValue("@Precio_de_compra", txtcosto.Text);
                     cmd.Parameters.AddWithValue("@precio_de_factura", TXTPRECIODEVENTA2.Text);
                     cmd.Parameters.AddWithValue("@Codigo", txtcodigodebarras.Text);
                     cmd.Parameters.AddWithValue("@A_partir_de", txtapartirde.Text);
                     cmd.Parameters.AddWithValue("@Impuesto", itbis);
                     cmd.Parameters.AddWithValue("@Precio_mayoreo", txtpreciomayoreo.Text);
                     if (porunidad.Checked == true) txtse_vende_a.Text = "Unidad";
                     if (agranel.Checked == true) txtse_vende_a.Text = "Granel";

                     cmd.Parameters.AddWithValue("@Se_vende_a", txtse_vende_a.Text);
                     cmd.Parameters.AddWithValue("@Id_grupo", lblIdGrupo.Text);
                     if (PANELINVENTARIO.Visible == true)
                     {
                         cmd.Parameters.AddWithValue("@Usa_inventarios", "SI");
                         cmd.Parameters.AddWithValue("@Stock_minimo", txtstockminimo.Text);
                         cmd.Parameters.AddWithValue("@Stock", txtstock2.Text);

                         if (No_aplica_fecha.Checked == true)
                         {
                             cmd.Parameters.AddWithValue("@Fecha_de_vencimiento", "NO APLICA");
                         }

                         if (No_aplica_fecha.Checked == false)
                         {
                             cmd.Parameters.AddWithValue("@Fecha_de_vencimiento", txtfechaoka.Text);
                         }


                     }
                     if (PANELINVENTARIO.Visible == false)
                     {
                         cmd.Parameters.AddWithValue("@Usa_inventarios", "NO");
                         cmd.Parameters.AddWithValue("@Stock_minimo", 0);
                         cmd.Parameters.AddWithValue("@Fecha_de_vencimiento", "NO APLICA");
                         cmd.Parameters.AddWithValue("@Stock", "Ilimitado");

                     }
                     cmd.Parameters.AddWithValue("@Fecha", DateTime.Today);
                     cmd.Parameters.AddWithValue("@Motivo", "Registro inicial de Producto");
                     cmd.Parameters.AddWithValue("@Cantidad ", txtstock2.Text);
                     cmd.Parameters.AddWithValue("@Id_usuario", idusuario);
                     cmd.Parameters.AddWithValue("@Tipo", "ENTRADA");
                     cmd.Parameters.AddWithValue("@Estado", "CONFIRMADO");
                     cmd.Parameters.AddWithValue("@Id_caja", idcaja);

                     cmd.ExecuteNonQuery();


                     con.Close();
                     PANELDEPARTAMENTO.Visible = false;
                     //txtbusca.Text = txtdescripcion.Text;
                     txtbusca.Focus();
                     buscar();
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.Message);
                 }*/
        }
        private void editar_productos()
        {
            /*if (txtpreciomayoreo.Text == "0" | txtpreciomayoreo.Text == "") txtapartirde.Text = "0";*/

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("editar_Producto1", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Producto1", TXTIDPRODUCTOOk.Text);
                cmd.Parameters.AddWithValue("@Descripcion", txtdescripcion.Text);
                cmd.Parameters.AddWithValue("@Imagen", ".");

                cmd.Parameters.AddWithValue("@Precio_de_compra", txtcosto.Text);
                cmd.Parameters.AddWithValue("@precio_de_factura", TXTPRECIODEVENTA2.Text);
                cmd.Parameters.AddWithValue("@Codigo", txtcodigodebarras.Text);
                cmd.Parameters.AddWithValue("@A_partir_de", txtapartirde.Text);
                cmd.Parameters.AddWithValue("@Impuesto", 0);
                //cmd.Parameters.AddWithValue("@Precio_mayoreo", txtpreciomayoreo.Text);
                if (porunidad.Checked == true) txtse_vende_a.Text = "Unidad";
                if (agranel.Checked == true) txtse_vende_a.Text = "Granel";

                cmd.Parameters.AddWithValue("@Se_vende_a", txtse_vende_a.Text);
                cmd.Parameters.AddWithValue("@Id_grupo", lblIdGrupo.Text);
                if (PANELINVENTARIO.Visible == true)
                {
                    cmd.Parameters.AddWithValue("@Usa_inventarios", "SI");
                    cmd.Parameters.AddWithValue("@Stock_minimo", txtstockminimo.Text);
                    cmd.Parameters.AddWithValue("@Stock", txtstock2.Text);

                    if (No_aplica_fecha.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@Fecha_de_vencimiento", "NO APLICA");
                    }

                    if (No_aplica_fecha.Checked == false)
                    {
                        cmd.Parameters.AddWithValue("@Fecha_de_vencimiento", txtfechaoka.Text);
                    }


                }
                if (PANELINVENTARIO.Visible == false)
                {
                    cmd.Parameters.AddWithValue("@Usa_inventarios", "NO");
                    cmd.Parameters.AddWithValue("@Stock_minimo", 0);
                    cmd.Parameters.AddWithValue("@Fecha_de_vencimiento", "NO APLICA");
                    cmd.Parameters.AddWithValue("@Stock", "Ilimitado");

                }

                cmd.ExecuteNonQuery();


                con.Close();
                PANELDEPARTAMENTO.Visible = false;
                //txtbusca.Text = txtdescripcion.Text;
                txtbusca.Focus();
                buscar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void buscar()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("buscar_producto_por_descripcion", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letra", txtbusca.Text);
                da.Fill(dt);
                datalistado.DataSource = dt;
                con.Close();

                datalistado.Columns[2].Visible = false;
                datalistado.Columns[7].Visible = false;
                datalistado.Columns[10].Visible = false;
                datalistado.Columns[15].Visible = false;
                datalistado.Columns[16].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            Bases.Multilinea(ref datalistado);
            sumar_costo_de_inventario_CONTAR_PRODUCTOS();
        }
        internal void sumar_costo_de_inventario_CONTAR_PRODUCTOS()
        {

            //string resultado;
            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
            //SqlCommand da = new SqlCommand("buscar_USUARIO_por_correo", con);
            //da.CommandType = CommandType.StoredProcedure;
            //da.Parameters.AddWithValue("@correo", txtcorreo.Text);

            //con.Open();
            //lblResultadoContraseña.Text = Convert.ToString(da.ExecuteScalar());
            //con.Close();

            string resultado;
            string queryMoneda;
            queryMoneda = "SELECT Moneda  FROM EMPRESA";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
            SqlCommand comMoneda = new SqlCommand(queryMoneda, con);
            try
            {
                con.Open();
                resultado = Convert.ToString(comMoneda.ExecuteScalar()); //asignamos el valor del importe
                con.Close();
            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            {
                con.Close();
                resultado = "";
            }

            string importe;
            string query;
            query = "SELECT      CONVERT(NUMERIC(18,2),sum(Producto1.Precio_de_compra * Stock )) as suma FROM  Producto1 where  Usa_inventarios ='SI'";

            SqlCommand com = new SqlCommand(query, con);
            try
            {
                con.Open();
                importe = Convert.ToString(com.ExecuteScalar()); //asignamos el valor del importe
                con.Close();
                lblcosto_inventario.Text = resultado + " " + importe;
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);

                lblcosto_inventario.Text = resultado + " " + 0;
            }

            string conteoresultado;
            string querycontar;
            querycontar = "select count(Id_Producto1 ) from Producto1 ";
            SqlCommand comcontar = new SqlCommand(querycontar, con);
            try
            {
                con.Open();
                conteoresultado = Convert.ToString(comcontar.ExecuteScalar()); //asignamos el valor del importe
                con.Close();
                lblcantidad_productos.Text = conteoresultado;
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);

                conteoresultado = "";
                lblcantidad_productos.Text = "0";
            }

        }
        private void CheckInventarios_CheckedChanged(object sender, EventArgs e)
        {



            if (TXTIDPRODUCTOOk.Text != "0" & Convert.ToDouble(txtstock2.Text) > 0)
            {
                if (CheckInventarios.Checked == false)
                {
                    MessageBox.Show("Hay Aun En Stock, Dirijete al Modulo Inventarios para Ajustar el Inventario a cero", "Stock Existente", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    PANELINVENTARIO.Visible = true;
                    CheckInventarios.Checked = true;
                }
            }

            if (TXTIDPRODUCTOOk.Text != "0" & Convert.ToDouble(txtstock2.Text) == 0)
            {
                if (CheckInventarios.Checked == false)
                {
                    PANELINVENTARIO.Visible = false;

                }
            }

            if (TXTIDPRODUCTOOk.Text == "0")
            {
                if (CheckInventarios.Checked == false)
                {
                    PANELINVENTARIO.Visible = false;

                }
            }

            if (CheckInventarios.Checked == true)
            {

                PANELINVENTARIO.Visible = true;
            }

        }

        private void PANELINVENTARIO_Paint(object sender, PaintEventArgs e)
        {

        }

        private void datalistadoGrupos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void GENERAR_CODIGO_DE_BARRAS_AUTOMATICO()
        {
            Double resultado;
            string queryMoneda;
            queryMoneda = "SELECT max(Id_Producto1)  FROM Producto1";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
            SqlCommand comMoneda = new SqlCommand(queryMoneda, con);
            try
            {
                con.Open();
                resultado = Convert.ToDouble(comMoneda.ExecuteScalar()) + 1;
                con.Close();
            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            {
                resultado = 1;
            }

            string Cadena = txtCategoria.Text;
            string[] Palabra;
            String espacio = " ";
            Palabra = Cadena.Split(Convert.ToChar(espacio));
            try
            {

                txtcodigodebarras.Text = resultado + Palabra[0].Substring(0, 2) + 369;
            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            {
            }
        }
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
                da.SelectCommand.Parameters.AddWithValue("@buscar", txtdescripcion.Text);
                da.Fill(dt);
                DATALISTADO_PRODUCTOS_OKA.DataSource = dt;
                con.Close();

                datalistado.Columns[1].Width = 500;


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
        private void txtdescripcion_TextChanged_1(object sender, EventArgs e)
        {

            mostrar_descripcion_produco_sin_repetir();
            contar();


            if (txtcontador == 0)
            {
                DATALISTADO_PRODUCTOS_OKA.Visible = false;
            }
            if (txtcontador > 0)
            {
                DATALISTADO_PRODUCTOS_OKA.Visible = true;
            }
            if (TGUARDAR.Visible == false)
            {
                DATALISTADO_PRODUCTOS_OKA.Visible = false;
            }
        }

        private void DATALISTADO_PRODUCTOS_OKA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DATALISTADO_PRODUCTOS_OKA_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtdescripcion.Text = DATALISTADO_PRODUCTOS_OKA.SelectedCells[1].Value.ToString();
                DATALISTADO_PRODUCTOS_OKA.Visible = false;
            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            {

            }
        }
#pragma warning disable CS0414 // El campo 'Productos_ok.SECUENCIA' está asignado pero su valor nunca se usa
        bool SECUENCIA = true;
#pragma warning restore CS0414 // El campo 'Productos_ok.SECUENCIA' está asignado pero su valor nunca se usa
        private void txtcosto_TextChanged_1(object sender, EventArgs e)
        {
            //if (SECUENCIA == true)
            //{
            //    txtcosto .Text = txtcosto.Text + ".";
            //    SECUENCIA = false;
            //}
            //else
            //{
            //    return;

            //}
        }


        private void txtcosto_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            Bases.Separador_de_Numeros(txtcosto, e);

        }


        private void txtbusca_TextChanged(object sender, EventArgs e)
        {
            buscar();
        }

        private void TGUARDARCAMBIOS_Click_1(object sender, EventArgs e)
        {
            /*TextBox[] array = { txtpreciomayoreo, txtdescripcion, txtcodigodebarras, txtcosto, TXTPRECIODEVENTA2, txtpreciomayoreo, txtgrupo };
             if (Insertar_datos.ValidTextIsNotNullOrEmpty(array))
             {
                 if (txtstock2.Text != "0" && txtcosto.Text != "0" && TXTPRECIODEVENTA2.Text != "0")
                 {
                     double txtpreciomayoreoV = Convert.ToDouble(txtpreciomayoreo.Text);

                     double txtapartirdeV = Convert.ToDouble(txtapartirde.Text);
                     double txtcostoV = Convert.ToDouble(txtcosto.Text);
                     double TXTPRECIODEVENTA2V = Convert.ToDouble(TXTPRECIODEVENTA2.Text);
                     if (txtpreciomayoreo.Text == "") txtpreciomayoreo.Text = "0";
                     if (txtapartirde.Text == "") txtapartirde.Text = "0";
                     //TXTPRECIODEVENTA2.Text = TXTPRECIODEVENTA2.Text.Replace(lblmoneda.Text + " ", "");
                     //TXTPRECIODEVENTA2.Text = System.String.Format(((decimal)TXTPRECIODEVENTA2.Text), "##0.00");
                     if ((txtpreciomayoreoV > 0 & Convert.ToDouble(txtapartirde.Text) > 0) | (txtpreciomayoreoV == 0 & txtapartirdeV == 0))
                     {
                         if (txtcostoV >= TXTPRECIODEVENTA2V)
                         {

                             DialogResult result;
                             result = MessageBox.Show("El precio del Articulo es menor o igual que el costo, Esto te puede generar perdidas", "Producto con Perdidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                             if (result == DialogResult.OK)
                             {
                                 TXTPRECIODEVENTA2.Focus();
                                 TXTPRECIODEVENTA2.SelectAll();
                             }
                         }
                         else if (txtcostoV < TXTPRECIODEVENTA2V)
                         {
                             if (Convert.ToDouble(txtpreciomayoreo.Text) <= Convert.ToDouble(txtcosto.Text) &&
                                 (Convert.ToDouble(txtpreciomayoreo.Text) != 0 || Convert.ToDouble(txtpreciomayoreo.Text) != 0.00))
                             {

                                 MessageBox.Show("El precio al por mayor es menor o igual que el costo, Esto te puede generar perdidas", "Producto con Perdidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                 txtpreciomayoreo.Focus();
                                 txtpreciomayoreo.SelectAll();
                             }
                             else
                             {
                                 editar_productos();
                             }
                         }
                     }
                     else if (txtpreciomayoreoV != 0 | txtapartirdeV != 0)
                     {
                         MessageBox.Show("Estas configurando Precio mayoreo, debes completar los campos de Precio mayoreo y A partir de, si no deseas configurarlo dejalos en blanco", "Datos incompletos", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                     }
                 }
                 else
                 {
                     MessageBox.Show("Los datos estan incorrectos, el formato es:" + "\nPrecio costo = 100\nPrecio articulo mayor a 100\n%Ganancia puede ser 0", "Datos incompletos", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                 }
             }*/
        }

        private void datalistado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        internal void proceso_para_obtener_datos_de_productos()
        {
            try
            {

                Panel25.Enabled = true;
                DATALISTADO_PRODUCTOS_OKA.Visible = false;

                Panel6.Visible = false;
                TGUARDAR.Visible = false;
                TGUARDARCAMBIOS.Visible = true;
                PANELDEPARTAMENTO.Visible = true;


                btnNuevoGrupo.Visible = true;
                TXTIDPRODUCTOOk.Text = datalistado.SelectedCells[2].Value.ToString();
                lblEstadoCodigo.Text = "EDITAR";
                //PANELCATEGORIASELECT.Visible = false;
                BtnGuardarCambios.Visible = false;
                btnGuardar_grupo.Visible = false;
                BtnCancelar.Visible = false;
                btnNuevoGrupo.Visible = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {

                txtidproducto.Text = datalistado.SelectedCells[2].Value.ToString();
                txtcodigodebarras.Text = datalistado.SelectedCells[3].Value.ToString();
                txtCategoria.Text = datalistado.SelectedCells[4].Value.ToString();

                txtdescripcion.Text = datalistado.SelectedCells[5].Value.ToString();
                txtnumeroigv.Text = datalistado.SelectedCells[6].Value.ToString();
                lblIdGrupo.Text = datalistado.SelectedCells[15].Value.ToString();


                LBL_ESSERVICIO.Text = datalistado.SelectedCells[7].Value.ToString();



                txtcosto.Text = datalistado.SelectedCells[8].Value.ToString();
                //txtpreciomayoreo.Text = datalistado.SelectedCells[9].Value.ToString();
                LBLSEVENDEPOR.Text = datalistado.SelectedCells[10].Value.ToString();
                if (LBLSEVENDEPOR.Text == "Unidad")
                {
                    porunidad.Checked = true;

                }
                if (LBLSEVENDEPOR.Text == "Granel")
                {
                    agranel.Checked = true;
                }
                txtstockminimo.Text = datalistado.SelectedCells[11].Value.ToString();
                lblfechasvenci.Text = datalistado.SelectedCells[12].Value.ToString();
                if (lblfechasvenci.Text == "NO APLICA")
                {
                    No_aplica_fecha.Checked = true;
                }
                if (lblfechasvenci.Text != "NO APLICA")
                {
                    No_aplica_fecha.Checked = false;
                }
                txtstock2.Text = datalistado.SelectedCells[13].Value.ToString();
                TXTPRECIODEVENTA2.Text = datalistado.SelectedCells[14].Value.ToString();
                try
                {

                    double TotalVentaVariabledouble;
                    double TXTPRECIODEVENTA2V = Convert.ToDouble(TXTPRECIODEVENTA2.Text);
                    double txtcostov = Convert.ToDouble(txtcosto.Text);

                    TotalVentaVariabledouble = ((TXTPRECIODEVENTA2V - txtcostov) / (txtcostov)) * 100;

                    if (TotalVentaVariabledouble > 0)
                    {
                        this.txtPorcentajeGanancia.Text = Convert.ToString(TotalVentaVariabledouble);
                    }
                    else
                    {
                        //Me.txtPorcentajeGanancia.Text = 0
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
                if (LBL_ESSERVICIO.Text == "SI")
                {

                    PANELINVENTARIO.Visible = true;
                    PANELINVENTARIO.Visible = true;
                    txtstock2.ReadOnly = true;
                    CheckInventarios.Checked = true;

                }
                if (LBL_ESSERVICIO.Text == "NO")
                {
                    CheckInventarios.Checked = false;

                    PANELINVENTARIO.Visible = false;
                    PANELINVENTARIO.Visible = false;
                    txtstock2.ReadOnly = true;
                    txtstock2.Text = "0";
                    txtstockminimo.Text = "0";
                    No_aplica_fecha.Checked = true;
                    txtstock2.ReadOnly = false;
                }
                txtapartirde.Text = datalistado.SelectedCells[16].Value.ToString();


                //PANELCATEGORIASELECT.Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void datalistado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.datalistado.Columns["Eliminar"].Index)
            {
                DialogResult result;
                result = MessageBox.Show("¿Realmente desea eliminar este Producto?", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    SqlCommand cmd;
                    try
                    {
                        foreach (DataGridViewRow row in datalistado.SelectedRows)
                        {

                            int onekey = Convert.ToInt32(row.Cells["Id_Producto"].Value);

                            try
                            {

                                try
                                {

                                    SqlConnection con = new SqlConnection();
                                    con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                                    con.Open();
                                    cmd = new SqlCommand("eliminar_Producto1", con);
                                    cmd.CommandType = CommandType.StoredProcedure;

                                    cmd.Parameters.AddWithValue("@id", onekey);
                                    cmd.ExecuteNonQuery();

                                    con.Close();

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }

                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show(ex.Message);
                            }

                        }
                        buscar();
                    }

#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
                    catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
                    {

                    }



                }



            }
            if (e.ColumnIndex == this.datalistado.Columns["Editar"].Index)
            {
                proceso_para_obtener_datos_de_productos();
            }

        }

        private void txtstock2_MouseClick_1(object sender, MouseEventArgs e)
        {
            try
            {
                if (TXTIDPRODUCTOOk.Text != "0")
                {
                    Tmensajes.SetToolTip(txtstock2, "Para modificar el Stock Hazlo desde el Modulo de Inventarios");
                    Tmensajes.ToolTipTitle = "Accion denegada";
                    Tmensajes.ToolTipIcon = ToolTipIcon.Info;

                }
            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            {

            }
        }

        private void ToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            DATALISTADO_PRODUCTOS_OKA.Visible = false;
        }

        private void btnGenerarCodigo_Click_1(object sender, EventArgs e)
        {
            GENERAR_CODIGO_DE_BARRAS_AUTOMATICO();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            PANELDEPARTAMENTO.Visible = false;
        }

        private void Panel25_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtPorcentajeGanancia_TextChanged_1(object sender, EventArgs e)
        {
            /* TimerCalucular_porcentaje_ganancia.Stop();

             TimerCalcular_precio_venta.Start();
             TimerCalucular_porcentaje_ganancia.Stop();*/
        }

        private void TimerCalucular_porcentaje_ganancia_Tick(object sender, EventArgs e)
        {
            TimerCalucular_porcentaje_ganancia.Stop();
            try
            {


                double TotalVentaVariabledouble;
                double TXTPRECIODEVENTA2V = Convert.ToDouble(TXTPRECIODEVENTA2.Text);
                double txtcostov = Convert.ToDouble(txtcosto.Text);

                TotalVentaVariabledouble = ((TXTPRECIODEVENTA2V - txtcostov) / (txtcostov)) * 100;

                if (TotalVentaVariabledouble > 0)
                {
                    this.txtPorcentajeGanancia.Text = Convert.ToString(TotalVentaVariabledouble);
                }
                else
                {
                    //Me.txtPorcentajeGanancia.Text = 0
                }


            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            {

            }
        }

        private void TimerCalcular_precio_venta_Tick(object sender, EventArgs e)
        {
            TimerCalcular_precio_venta.Stop();

            try
            {
                double TotalVentaVariabledouble;
                double txtcostov = Convert.ToDouble(txtcosto.Text);
                double txtPorcentajeGananciav = Convert.ToDouble(txtPorcentajeGanancia.Text);

                TotalVentaVariabledouble = txtcostov + ((txtcostov * txtPorcentajeGananciav) / 100);

                if (TotalVentaVariabledouble > 0 & txtPorcentajeGanancia.Focused == true)
                {
                    this.TXTPRECIODEVENTA2.Text = Convert.ToString(TotalVentaVariabledouble);
                }
                else
                {
                    //Me.txtPorcentajeGanancia.Text = 0
                }
            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            {

            }
        }

        private void datalistado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            proceso_para_obtener_datos_de_productos();
        }

        private void ToolStripMenuItem15_Click(object sender, EventArgs e)
        {
            Presentacion.PRODUCTOS_OK.Asistente_de_importacionExcel frm = new Presentacion.PRODUCTOS_OK.Asistente_de_importacionExcel();
            frm.ShowDialog();
        }

        private void Productos_ok_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
            CONFIGURACION.PANEL_CONFIGURACIONES frm = new CONFIGURACION.PANEL_CONFIGURACIONES();
            frm.ShowDialog();
        }

        private void txtPorcentajeGanancia_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            // Bases.Separador_de_Numeros(txtPorcentajeGanancia, e);

        }

        private void TXTPRECIODEVENTA2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(TXTPRECIODEVENTA2, e);

        }

        private void txtpreciomayoreo_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //Bases.Separador_de_Numeros(txtpreciomayoreo, e);

        }

        private void txtapartirde_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txtapartirde, e);

        }

        private void txtstock2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txtstock2, e);

        }

        private void txtstockminimo_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txtstockminimo, e);
        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtgrupo_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        int idCategoriaAgregar;
        string descripcionCategoria;
        string departamentoCategoria;

        private void button6_Click(object sender, EventArgs e)
        {
            panelUnidad.Visible = false;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            panelInformacionBasica.Location = new Point(36, 1);
            panelInformacionBasica.Size = new Size(979, 634);
            panelInformacionBasica.Visible = true;
            panelInfoAduana.Visible = false;
            PanelInformacionAdicional.Visible = false;
            panelProveedor.Visible = false;
            panelUnidad.Visible = false;
            panelCategoria.Visible = false;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            //PanelInformacionAdicional.Location = new Point((Width - panelInformacionBasica.Width) / 2, (Height - panelInformacionBasica.Height) / 2);
            //PanelInformacionAdicional.Size = 1040; 634;
            panelInformacionBasica.Visible = false;
            panelInfoAduana.Visible = false;
            PanelInformacionAdicional.Visible = true;
            panelProveedor.Visible = false;
            panelUnidad.Visible = false;
            panelCategoria.Visible = false;
            //PanelInformacionAdicional.add = DockStyle.Fill;
            PanelInformacionAdicional.Location = new Point(36, 1);
            PanelInformacionAdicional.Size = new Size(979, 634);


        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            panelInformacionBasica.Visible = false;
            panelInfoAduana.Visible = false;
            PanelInformacionAdicional.Visible = false;
            panelProveedor.Visible = true;
            panelUnidad.Visible = false;
            panelCategoria.Visible = false;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            panelInformacionBasica.Visible = false;
            panelInfoAduana.Visible = true;
            PanelInformacionAdicional.Visible = false;
            panelProveedor.Visible = false;
            panelUnidad.Visible = false;
            panelCategoria.Visible = false;
        }

        private void btnAgregarCategoriaForm_Click(object sender, EventArgs e)
        {
            panelCategoriaAgregar.Visible = true;
            panelCategoriaAgregar.Location = new Point(93, 106);
            panelCategoriaAgregar.Size = new Size(276, 249);
            inhabilitarCategoria();
            txtCategoriaAgregar.Clear();
            txtDepartamentoAgregar.Clear();
        }
        private void inhabilitarCategoria()
        {
            txtCategoriaProductos.Enabled = false;
            datalistadoCategorias.Enabled = false;
            btnAgregarCategoriaForm.Enabled = false;
        }
        private void habilitarCategoria()
        {
            txtCategoriaProductos.Enabled = true;
            datalistadoCategorias.Enabled = true;
            btnAgregarCategoriaForm.Enabled = true;
        }
        private void txtCategoriaProductos_TextChanged(object sender, EventArgs e)
        {
            if(txtCategoriaProductos.Text != "")
            mostarCategoriaCompleta(txtCategoriaProductos.Text);
        }


        private void button10_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(txtCategoriaAgregar.Text)) && (!string.IsNullOrEmpty(txtDepartamentoAgregar.Text)))
            {
                LCategoria parametros = new LCategoria();
                Insertar_datos funcion = new Insertar_datos();

                parametros.Descripcion = txtCategoriaAgregar.Text;
                parametros.Departamento = txtDepartamentoAgregar.Text;
                parametros.Estado = "ACTIVO";

                if (lblBanderaCategoria.Text == "TRUE")
                {
                    parametros.idCategoria = idCategoriaAgregar;
                    lblBanderaCategoria.Text = "FALSE";
                    if (funcion.editarCategoria(parametros) == true)
                    {
                        mostrarCategoriaAgregar();

                    }
                }
                else
                {
                    if (funcion.InsertarCategoria(parametros) == true)
                    {
                        mostrarCategoriaAgregar();
                    }
                }

            }
            else
            {
                MessageBox.Show("Introduzca los campos correctamente", "Categorias", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarCategorias_Click(object sender, EventArgs e)
        {
            DialogResult dlgRes = MessageBox.Show("¿Realmente no desea agregar una Categoria?", "Categorias", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgRes == DialogResult.Yes)
            {
                habilitarCategoria();
                panelCategoriaAgregar.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtCategoriaAgregar.Clear();
            panelCategoria.Visible = false;
        }

        private void mostrarCategoriaAgregar()
        {
            habilitarCategoria();
            txtCategoriaAgregar.Clear();
            txtDepartamentoAgregar.Clear();
            panelCategoriaAgregar.Visible = false;
            mostarCategoriaCompleta(txtCategoriaProductos.Text);
        }

        private void mostarCategoriaCompleta(string categoria)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("mostrarCategorias", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@buscar", categoria);
                da.Fill(dt);
                datalistadoCategorias.DataSource = dt;
                con.Close();

                datalistadoCategorias.DataSource = dt;
                datalistadoCategorias.Columns[2].Visible = false;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Bases.Multilinea(ref datalistadoCategorias);
        }
        public void mostrarCategoria()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("mostrarCategorias_parametros", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
              
                da.Fill(dt);
                datalistadoCategorias.DataSource = dt;
                con.Close();

                datalistadoCategorias.DataSource = dt;
                datalistadoCategorias.Columns[2].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Bases.Multilinea(ref datalistadoCategorias);
        }
        private void panelCategoria_Paint(object sender, PaintEventArgs e)
        {
            txtCategoriaAgregar.Focus();
            mostarCategoriaCompleta(txtCategoriaProductos.Text);
            panelCategoriaAgregar.Visible = false;

        }



        private void obtenerDatosCategoriaAgregar()
        {
            idCategoriaAgregar = Convert.ToInt32(datalistadoCategorias.SelectedCells[2].Value);
            descripcionCategoria = (datalistadoCategorias.SelectedCells[3].Value.ToString());
            departamentoCategoria = (datalistadoCategorias.SelectedCells[4].Value.ToString());

            txtCategoriaAgregar.Text = descripcionCategoria;
            txtDepartamentoAgregar.Text = departamentoCategoria;
        }
        private void datalistadoCategorias_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == datalistadoCategorias.Columns["EditarCat"].Index)
            {
                lblBanderaCategoria.Text = "TRUE";
                obtenerDatosCategoriaAgregar();
                panelCategoriaAgregar.Visible = true;
            }


            if (e.ColumnIndex == datalistadoCategorias.Columns["EliminarCat"].Index)
            {
                DialogResult result = MessageBox.Show("¿Realmente desea eliminar esta Categoria?", "Eliminando categorias", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    obtenerDatosCategoriaAgregar();
                    eliminarCategoriaAgregar();
                }

            }
        }

        private void eliminarCategoriaAgregar()
        {
            SqlCommand cmd;
            try
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                    con.Open();
                    cmd = new SqlCommand("eliminarCategorias", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", idCategoriaAgregar);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                mostrarCategoriaAgregar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            mostrarCategoria();
           
            panelCategoria.BringToFront();
            panelCategoria.Visible = true;
            panelCategoria.Location = new Point(387, 110);
            panelCategoria.Size = new Size(467, 365);
            txtCategoriaProductos.Focus();
        }

        private void txtCategoria_TextChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(txtCategoria.TextLength.ToString());
            if(txtCategoria.TextLength > 0)
            {
                datalistadoCategoriasInformacionBasicaPanel.BringToFront();
                datalistadoCategoriasInformacionBasicaPanel.Location = new Point(61, 209);
                datalistadoCategoriasInformacionBasicaPanel.Size = new Size(174, 72);
                mostarCategoria();
                datalistadoCategoriasInformacionBasicaPanel.Visible = true;
            }
            else
            {
                mostarCategoria();
                datalistadoCategoriasInformacionBasicaPanel.SendToBack();
                datalistadoCategoriasInformacionBasicaPanel.Visible = false;
            }
        }

        private void mostarCategoria()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("mostrarCategorias", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@buscar", txtCategoria.Text);
                da.Fill(dt);
                con.Close();
                datalistadoCategoriasInformacionBasica.DataSource = dt;
                datalistadoCategoriasInformacionBasica.Columns[0].Visible = false;
                datalistadoCategoriasInformacionBasica.Columns[2].Visible = false;
                datalistadoCategoriasInformacionBasica.Columns[1].Width = 150;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Bases.Multilinea(ref datalistadoCategoriasInformacionBasica);
        }

        private void datalistadoCategoriasInformacionBasica_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            obtenerCategoriaDepartamento();
        }

        int idCategoria;
        string descripcion;
        string departamento;
        private int idUnidadVenta;
        private int idClaveSatVenta;

        private void obtenerCategoriaDepartamento()
        {
            idCategoriaAgregar = Convert.ToInt32(datalistadoCategoriasInformacionBasica.SelectedCells[0].Value);
            descripcion = (datalistadoCategoriasInformacionBasica.SelectedCells[1].Value.ToString());
            departamento = (datalistadoCategoriasInformacionBasica.SelectedCells[2].Value.ToString());

            txtCategoria.Text = descripcion;
            txtDepartamento.Text = departamento;
            datalistadoCategoriasInformacionBasicaPanel.Visible = false;
        }

        private void PClaveSAT_DoubleClick(object sender, EventArgs e)
        {
            panelClaveUnidadSat.Visible = true;
            panelUnidad.Visible = true;
            panelClaveUnidadSat.Location = new Point(387, 80);
            panelClaveUnidadSat.Size = new Size(670, 362);
            panelClaveUnidadSat.BringToFront();
            mostrarClavesSAT();
        }
        public void mostrarClavesSAT()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("mostrarClavesSat", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@buscar", txtUnidadBuscar.Text + "");
                da.Fill(dt);
                datalistadoUnidadesSAT.DataSource = dt;
                con.Close();

                datalistadoUnidadesSAT.DataSource = dt;
                datalistadoUnidadesSAT.Columns[0].Visible = false;
                datalistadoUnidadesSAT.Columns[2].Width = 300;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Bases.Multilinea(ref datalistadoUnidadesSAT);
        }
        private void btnGuardarMedida_Click(object sender, EventArgs e)
        {
            LUnidadProductos parametros = new LUnidadProductos();
            Insertar_datos insertar = new Insertar_datos();
            panelInformacionBasica.Enabled = true;

            parametros.descripcion = txtUnidadVenta.Text;
            parametros.idClaveSat = idClaveSat;

            if(insertar.insertarUnidad(parametros) == true){
                panelUnidad.Visible = false;
                txtUnidadCompra.Text = txtUnidadVenta.Text;
                txtUnidadDeVenta.Text = txtUnidadVenta.Text;
            }
        }

        private void txtUnidadBuscar_TextChanged(object sender, EventArgs e)
        {

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("mostrarClavesSat", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@buscar", txtUnidadBuscar.Text + "");
                da.Fill(dt);
                datalistadoUnidadesSAT.DataSource = dt;
                con.Close();

                datalistadoUnidadesSAT.DataSource = dt;
                datalistadoUnidadesSAT.Columns[0].Visible = false;
               // datalistadoUnidadesSAT.AutoResizeColumns = true;
                //datalistadoUnidadesSAT.Columns[2].Width = 300;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Bases.Multilinea(ref datalistadoUnidadesSAT);
        }

        private void panelClaveUnidadSat_Paint(object sender, PaintEventArgs e)
        {
            txtUnidadBuscar.Focus();

        }

        private void PClaveSAT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = false;
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnAbrirPanelUnidad_Click(object sender, EventArgs e)
        {
            panelUnidad.Visible = true;
            panelUnidad.Location = new Point(387, 110);
            panelUnidad.Size = new Size(300, 329);
            panelUnidad.BringToFront();
            panelUnidad.Visible = true;
            txtUnidadVenta.Focus();
        }

        private void datalistadoUnidadesSAT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            panelClaveUnidadSat.Visible = false;
            idClaveSat = Convert.ToInt32(datalistadoUnidadesSAT.SelectedCells[0].Value.ToString());
            PClaveSAT.Text = datalistadoUnidadesSAT.SelectedCells[2].Value.ToString();
            txtUnidadVenta.Focus();
        }

        private void txtUnidadCompra_TextChanged(object sender, EventArgs e)
        {
            if (txtUnidadCompra.TextLength > 0)
            {
                datalistadoUnidadCompraPanel.BringToFront();
                datalistadoUnidadCompraPanel.Location = new Point(491, 208);
                datalistadoUnidadCompraPanel.Size = new Size(174, 72);
                mostrarUnidadesCompra();
                datalistadoUnidadCompraPanel.Visible = true;
            }
            else
            {
                mostrarUnidadesCompra();
                datalistadoUnidadCompraPanel.SendToBack();
                datalistadoUnidadCompraPanel.Visible = false;
            }
        }

        public void mostrarUnidadesCompra()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("mostrarUnidades", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@buscar", txtUnidadCompra.Text);
                da.Fill(dt);
                con.Close();
                datalistadoUnidadCompra.DataSource = dt;
                datalistadoUnidadCompra.Columns[0].Visible = false;
                datalistadoUnidadCompra.Columns[1].Visible = false;
                datalistadoUnidadCompra.Columns[2].Width = 400;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Bases.Multilinea(ref datalistadoUnidadCompra);
        }

        private void panelInformacionBasica_Paint(object sender, PaintEventArgs e)
        {
            datalistadoUnidadCompraPanel.Visible = false;
            panelUnidadVenta.Visible = false;

        }

        private void datalistadoUnidadCompra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idUnidadCompra = Convert.ToInt32(datalistadoUnidadCompra.SelectedCells[0].Value);
            idClaveSatCompra = Convert.ToInt32(datalistadoUnidadCompra.SelectedCells[1].Value);
            txtUnidadCompra.Text = datalistadoUnidadCompra.SelectedCells[2].Value.ToString();
            datalistadoUnidadCompraPanel.Visible = false;
            txtUnidadDeVenta.Text = txtUnidadCompra.Text;
            UnidadMultiplicada1.Text = txtUnidadCompra.Text;
            UnidadMultiplicada2.Text = txtUnidadCompra.Text;
            //UnidadMultiplicada3.Text = txtUnidadCompra.Text;
        }

        private void txtUnidadDeVenta_TextChanged(object sender, EventArgs e)
        {
            if (txtUnidadDeVenta.TextLength > 0)
            {
                panelUnidadVenta.BringToFront();
                panelUnidadVenta.Location = new Point(732, 322);
                panelUnidadVenta.Size = new Size(174, 72);
                mostrarUnidadesVenta();
                panelUnidadVenta.Visible = true;
            }
            else
            {
                mostrarUnidadesVenta();
                panelUnidadVenta.SendToBack();
                panelUnidadVenta.Visible = false;
            }
        }
        public void mostrarUnidadesVenta()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("mostrarUnidades", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@buscar", txtUnidadVenta.Text);
                da.Fill(dt);
                con.Close();
                datalistadoUnidadVenta.DataSource = dt;
                datalistadoUnidadVenta.Columns[0].Visible = false;
                datalistadoUnidadVenta.Columns[1].Visible = false;
                datalistadoUnidadVenta.Columns[2].Width = 400;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Bases.Multilinea(ref datalistadoUnidadVenta);
        }

        private void datalistadoUnidadVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idUnidadVenta = Convert.ToInt32(datalistadoUnidadCompra.SelectedCells[0].Value);
            idClaveSatVenta = Convert.ToInt32(datalistadoUnidadCompra.SelectedCells[1].Value);
            txtUnidadVenta.Text = datalistadoUnidadCompra.SelectedCells[2].Value.ToString();
            datalistadoUnidadCompraPanel.Visible = false;
            
           
            UnidadMultiplicada3.Text = txtUnidadCompra.Text;
        }

        private void PANELINFOR_Paint(object sender, PaintEventArgs e)
        {
        }

        private void PANELREGISTRO_Paint(object sender, PaintEventArgs e)
        {
            panelInformacionBasica.Visible = true;
            panelInformacionBasica.Location = new Point(36, 1);
            panelInformacionBasica.Size = new Size(979, 634);
    }

        private void btnCancelarRegistro_Click(object sender, EventArgs e)
        {
            PANELREGISTRO.Visible = false;
        }
    }
}