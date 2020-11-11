using SistemaVentas.CONEXION;
using SistemaVentas.Datos;
using SistemaVentas.Logica;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
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
        double itbis;
        int idMayoreo;
        int idImpuestoAgregar;
        int idDescuentoAgregar;
        double precioCompra;

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            PANELREGISTRO.Visible = true;
            PANELINFOR.Visible = true;
            chkImpuestos.Checked = true;
            LIMPIAR();


            /* CheckInventarios.Checked = true;
            /*  txtdescripcion.AutoCompleteCustomSource = CONEXION.DataHelper.LoadAutoComplete();
              txtdescripcion.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
              txtdescripcion.AutoCompleteSource = AutoCompleteSource.CustomSource;*/



        }
        internal void LIMPIAR()
        {

            txtdescripcion.Text = "";


            agranel.Checked = false;
            txtstockminimo.Text = "0";
            txtstock2.Text = "0";


            txtUnidadCompra.Text = "";
            txtUnidadVenta.Text = "";
            txtCategoria.Text = "";
            txtDepartamento.Text = "";
            txtdescripcion.Text = "";
            txtcodigodebarras.Text = "";

            txtPrecioCompra.Text = "0";
            txtPrecioCompraImpuestos.Text = "0";
            txtVenta.Text = "0";
            txtUnidadDeVenta.Text = "";

            txtUnidadMayoreo1.Text = "0";
            txtUnidadMayoreo2.Text = "0";
            txtUnidadMayoreo3.Text = "0";
            txtUnidadMayoreo4.Text = "0";

            txtPrecioVentaPrecio1.Text = "0";
            txtPrecioVentaPrecio2.Text = "0";
            txtPrecioVentaPrecio3.Text = "0";
            txtPrecioVentaPrecio4.Text = "0";

            txtPorcentajeGanancia1.Text = "0";
            txtPorcentajeGanancia2.Text = "0";
            txtPorcentajeGanancia3.Text = "0";
            txtPorcentajeGanancia4.Text = "0";

            txtPrecioVentaPrecio1.Text = "0";
            txtPrecioVentaPrecio2.Text = "0";
            txtPrecioVentaPrecio3.Text = "0";
            txtPrecioVentaPrecio4.Text = "0";
        }

        public static int idusuario;


        private void Productos_ok_Load(object sender, EventArgs e)
        {
            mostrarProductos();
            //chkListaItbis.CheckOnClick = true;
            ObtenerImpuestos();

            //Visible
            PANELREGISTRO.Visible = false;
            panelProveedor.Visible = false;
            datalistadoCategoriasInformacionBasicaPanel.Visible = false;
            PanelInformacionAdicional.Visible = false;
            panelCategoria.Visible = false;
            panelUnidad.Visible = false;
            panelClaveUnidadSat.Visible = false;
            panelCategoriaAgregar.Visible = false;
            PANELINFOR.Visible = false;
            panelImpuestosAgregar.Visible = false;

            //Enabled
            txtPorcentajeGanancia1.Enabled = false;
            txtPorcentajeGanancia2.Enabled = false;
            txtPorcentajeGanancia3.Enabled = false;
            txtPorcentajeGanancia4.Enabled = false;

            panelPrecios.Enabled = false;
            txtDepartamento.Enabled = false;
            txtVenta.Enabled = false;
            txtPrecioCompraImpuestos.Enabled = false;
            Obtener_datos.mostrar_inicio_De_sesion(ref idusuario);
            Obtener_datos.Obtener_id_caja_PorSerial(ref idcaja);
            Bases.Cambiar_idioma_regional();


            /*

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



        private void btnGuardar_grupo_Click_1(object sender, EventArgs e)
        {

        }
        private void btnNuevoGrupo_Click(object sender, EventArgs e)
        {

        }

        private void txtgrupo_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnCancelar_Click_1(object sender, EventArgs e)
        {
        }

        private void editar_productos()
        {
            /* /*if (txtpreciomayoreo.Text == "0" | txtpreciomayoreo.Text == "") txtapartirde.Text = "0";*/
            /*
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("editar_Producto", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Producto", TXTIDPRODUCTOOk.Text);
                cmd.Parameters.AddWithValue("@Descripcion", txtdescripcion.Text);
                cmd.Parameters.AddWithValue("@Imagen", ".");

                cmd.Parameters.AddWithValue("@Precio_de_compra", txtPrecioCompra.Text);
                cmd.Parameters.AddWithValue("@precio_de_factura", txtPrecioVentaPrecio1.Text);
                cmd.Parameters.AddWithValue("@Codigo", txtcodigodebarras.Text);
                cmd.Parameters.AddWithValue("@A_partir_de", txtUnidadMayoreo1.Text);
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
                //txtbusca.Focus();
                // buscar();
                
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
        }

        private void datalistadoMostrarDescuentoCategoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idDescuentoAgregar = Convert.ToInt32(datalistadoMostrarDescuentoCategoria.SelectedCells[0].Value);
            txtDescuentosCategoria.Text = datalistadoMostrarDescuentoCategoria.SelectedCells[1].Value.ToString();
            panelMostrarDescuentoCategoria.Visible = false;

        }

        private void datalistadiImpuestosCategoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idImpuestoAgregar = Convert.ToInt32(datalistadiImpuestosCategoria.SelectedCells[0].Value);
            txtImpuestosCategoria.Text = datalistadiImpuestosCategoria.SelectedCells[1].Value.ToString();
            panelImpuestosCategoria.Visible = false;

        }

        private void buscar()
        {
            /*try
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
            sumar_costo_de_inventario_CONTAR_PRODUCTOS();*/
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
            query = "SELECT      CONVERT(NUMERIC(18,2),sum(Producto.Precio_de_compra * Stock )) as suma FROM  Producto where  Usa_inventarios ='SI'";

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
            querycontar = "select count(idProducto) from Producto ";
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



        }

        private void GENERAR_CODIGO_DE_BARRAS_AUTOMATICO()
        {
            
            Double resultado;
            string queryMoneda;
            queryMoneda = "SELECT max(idProducto) FROM Producto";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
            SqlCommand comMoneda = new SqlCommand(queryMoneda, con);
            try
            {
                con.Open();
                resultado = Convert.ToDouble(comMoneda.ExecuteScalar()) + 1;
                con.Close();
            }
            catch (Exception ex)
            {
                resultado = 1;
            }

            string Cadena = txtCategoria.Text;
            string[] Palabra;
            String espacio = " ";
            Palabra = Cadena.Split(Convert.ToChar(espacio));
            try
            {

                txtcodigodebarras.Text = resultado + Palabra[0].Substring(0, 2) + 321;
            }
            catch (Exception ex)
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
                //DATALISTADO_PRODUCTOS_OKA.DataSource = dt;
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
          /* int x;

            x = DATALISTADO_PRODUCTOS_OKA.Rows.Count;
            txtcontador = (x);*/

        }
        private void txtdescripcion_TextChanged_1(object sender, EventArgs e)
        {

           /* mostrar_descripcion_produco_sin_repetir();
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
           */
        }

      

        private void txtcosto_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            Bases.Separador_de_Numeros(txtPrecioCompra, e);

        }


        private void txtbusca_TextChanged(object sender, EventArgs e)
        {
            // buscar();
        }

        private void TGUARDARCAMBIOS_Click_1(object sender, EventArgs e)
        {

        }

        private void datalistado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        internal void proceso_para_obtener_datos_de_productos()
        {
            /* try
             {

                 Panel25.Enabled = true;
                 DATALISTADO_PRODUCTOS_OKA.Visible = false;

                 Panel6.Visible = false;
                 //TGUARDAR.Visible = false;
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

                 txtcodigodebarras.Text = datalistado.SelectedCells[3].Value.ToString();
                 txtCategoria.Text = datalistado.SelectedCells[4].Value.ToString();

                 txtdescripcion.Text = datalistado.SelectedCells[5].Value.ToString();
                 txtnumeroigv.Text = datalistado.SelectedCells[6].Value.ToString();
                 lblIdGrupo.Text = datalistado.SelectedCells[15].Value.ToString();





                 txtPrecioCompra.Text = datalistado.SelectedCells[8].Value.ToString();
                 //txtpreciomayoreo.Text = datalistado.SelectedCells[9].Value.ToString();
                 txtstockminimo.Text = datalistado.SelectedCells[11].Value.ToString();
                 txtstock2.Text = datalistado.SelectedCells[13].Value.ToString();
                 txtPrecioVentaPrecio1.Text = datalistado.SelectedCells[14].Value.ToString();
                 try
                 {

                     double TotalVentaVariabledouble;
                     double TXTPRECIODEVENTA2V = Convert.ToDouble(txtPrecioVentaPrecio1.Text);
                     double txtPrecioComprav = Convert.ToDouble(txtPrecioCompra.Text);

                     TotalVentaVariabledouble = ((TXTPRECIODEVENTA2V - txtPrecioComprav) / (txtPrecioComprav)) * 100;

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
                 txtstock2.ReadOnly = true;
                 CheckInventarios.Checked = true;

             }
                     CheckInventarios.Checked = false;
             txtstock2.ReadOnly = true;
             txtstock2.Text = "0";
             txtstockminimo.Text = "0";
             No_aplica_fecha.Checked = true;
             txtstock2.ReadOnly = false;



             //PANELCATEGORIASELECT.Visible = false;

         }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }*/
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
                                    cmd = new SqlCommand("eliminar_Producto", con);
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
            
        }

        private void ToolStripMenuItem11_Click(object sender, EventArgs e)
        {
        }

        private void btnGenerarCodigo_Click_1(object sender, EventArgs e)
        {
            if (idCategoria != 0)
            {
                GENERAR_CODIGO_DE_BARRAS_AUTOMATICO();
            }
            else
            {
                MessageBox.Show("No se puede generar el Código de barras\nSeleccione una Categoria");
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
            Bases.Separador_de_Numeros(txtPrecioVentaPrecio1, e);

        }

        private void txtpreciomayoreo_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //Bases.Separador_de_Numeros(txtpreciomayoreo, e);

        }

        private void txtapartirde_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txtUnidadMayoreo1, e);

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
            PanelInformacionBasicaATRAS.BringToFront();
            PanelInformacionBasicaATRAS.Visible = true;
            PanelInformacionBasicaATRAS.Location = new Point(36, 1);
            PanelInformacionBasicaATRAS.Size = new Size(979, 634);
            PanelInformacionBasicaATRAS.Dock = DockStyle.Fill;
            panelInformacionBasica.Dock = DockStyle.Fill;

            panelInformacionAdicionalATRAS.Visible = false;
            panelProveedorATRAS.Visible = false;

            panelInfoAduana.Visible = false;
            panelProveedor.Visible = false;
            panelUnidad.Visible = false;
            panelCategoria.Visible = false;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            panelInformacionAdicionalATRAS.Visible = false;
            panelProveedorATRAS.Visible = false;
            PanelInformacionBasicaATRAS.Visible = false;

            panelProveedorATRAS.Location = new Point(36, 1);
            panelProveedorATRAS.Size = new Size(979, 634);
            panelProveedorATRAS.Visible = true;
            panelProveedorATRAS.Dock = DockStyle.Fill;
            panelProveedorATRAS.BringToFront();
            panelProveedor.Dock = DockStyle.Fill;

            panelProveedor.Visible = true;

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            PanelInformacionBasicaATRAS.Visible = false;

            panelInfoAduana.Visible = false;
            panelProveedor.Visible = false;
            panelUnidad.Visible = false;
            panelCategoria.Visible = false;

            panelInformacionAdicionalATRAS.Location = new Point(36, 1);
            panelInformacionAdicionalATRAS.Size = new Size(979, 634);
            panelInformacionAdicionalATRAS.BringToFront();
            panelInformacionAdicionalATRAS.Dock = DockStyle.Fill;
            panelInformacionAdicionalATRAS.Visible = true;

            PanelInformacionAdicional.Visible = true;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            panelAlmacenAtras.BringToFront();
            panelAlmacenAtras.Visible = true;
            panelAlmacenAtras.Location = new Point(36, 1);
            panelAlmacenAtras.Size = new Size(979, 634);
            panelAlmacenAtras.Dock = DockStyle.Fill;
            panelAlmacenAtras.Dock = DockStyle.Fill;

            panelInformacionAdicionalATRAS.Visible = false;
            PanelInformacionBasicaATRAS.Visible = false;
            panelProveedorATRAS.Visible = false;

            panelInfoAduana.Visible = false;
            panelProveedor.Visible = false;
            panelUnidad.Visible = false;
            panelCategoria.Visible = false;
        }

        private void btnAgregarCategoriaForm_Click(object sender, EventArgs e)
        {
            txtImpuestosCategoria.Clear();
            txtDescuentosCategoria.Clear();
            panelCategoriaAgregar.Visible = true;
            panelCategoriaAgregar.Location = new Point(93, 106);
            panelCategoriaAgregar.Size = new Size(256, 410);
            inhabilitarCategoria();
            txtCategoriaAgregar.Clear();
            txtDepartamentoAgregar.Clear();
        }
        private void inhabilitarCategoria()
        {
            txtCategoriaProductos.Enabled = false;
            datalistadoCategorias.Enabled = false;
        }
        private void habilitarCategoria()
        {
            txtCategoriaProductos.Enabled = true;
            datalistadoCategorias.Enabled = true;
            btnAgregarCategoriaForm.Enabled = true;
        }
        private void txtCategoriaProductos_TextChanged(object sender, EventArgs e)
        {
            if (txtCategoriaProductos.Text != "")
                mostarCategoriaCompleta(txtCategoriaProductos.Text);
        }


        private void button10_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(txtCategoriaAgregar.Text)) && (!string.IsNullOrEmpty(txtDepartamentoAgregar.Text)) && (!string.IsNullOrEmpty(txtImpuestosCategoria.Text)) && (!string.IsNullOrEmpty(txtDescuentosCategoria.Text)))
            {
                LCategoria parametros = new LCategoria();
                Insertar_datos funcion = new Insertar_datos();

                parametros.idDescuento = idDescuentoAgregar;
                parametros.idImpuesto = idImpuestoAgregar;
                parametros.Descripcion = txtCategoriaAgregar.Text;
                parametros.Departamento = txtDepartamentoAgregar.Text;
                parametros.Estado = "ACTIVO";

                if (lblBanderaCategoria.Text == "TRUE")
                {
                    parametros.idCategoria = idCategoriaAgregar;
                    parametros.idDescuento = idDescuentoAgregar;
                    parametros.idImpuesto = idImpuestoAgregar;
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

                da = new SqlDataAdapter("mostrarCategorias2", con);
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

        private void mostarCategoria(string categoria)
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

                da = new SqlDataAdapter("mostrarCategorias", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                da.Fill(dt);
                datalistadoCategorias.DataSource = dt;
                con.Close();

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
            mostarCategoria();
            panelImpuestosCategoria.Visible = false;
            panelImpuestosAgregar.Visible = false;
            panelImpuestosAgregar.SendToBack();
            panelDescuentos.Visible = false;

            txtCategoriaAgregar.Focus();
            mostarCategoriaCompleta(txtCategoriaProductos.Text);
            panelCategoriaAgregar.Visible = false;

        }



        private void obtenerDatosCategoriaAgregar()
        {
            idCategoriaAgregar = Convert.ToInt32(datalistadoCategorias.SelectedCells[2].Value);
            descripcionCategoria = (datalistadoCategorias.SelectedCells[3].Value.ToString());
            departamentoCategoria = (datalistadoCategorias.SelectedCells[4].Value.ToString());
            txtImpuestosCategoria.Text = (datalistadoCategorias.SelectedCells[5].Value.ToString());
            txtDescuentosCategoria.Text = (datalistadoCategorias.SelectedCells[6].Value.ToString());

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
            panelImpuestosCategoria.Visible = false; mostrarCategoria();

            panelCategoria.BringToFront();
            panelCategoria.Visible = true;
            panelCategoria.Location = new Point(387, 110);
            panelCategoria.Size = new Size(481, 530);
            txtCategoriaProductos.Focus();
        }

        private void txtCategoria_TextChanged(object sender, EventArgs e)
        {
            if (txtCategoria.Text !="")
            {
                datalistadoCategoriasInformacionBasicaPanel.BringToFront();
                datalistadoCategoriasInformacionBasicaPanel.Location = new Point(19, 201);
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

                da = new SqlDataAdapter("mostrarCategorias2", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@buscar", txtCategoria.Text);
                da.Fill(dt);
                con.Close();
                datalistadoCategoriasInformacionBasica.DataSource = dt;
                datalistadoCategoriasInformacionBasica.Columns[0].Visible = false;
                datalistadoCategoriasInformacionBasica.Columns[2].Visible = false;
                datalistadoCategoriasInformacionBasica.Columns[3].Visible = false;
                datalistadoCategoriasInformacionBasica.Columns[4].Visible = false;
                datalistadoCategoriasInformacionBasica.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

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
            idCategoria = Convert.ToInt32(datalistadoCategoriasInformacionBasica.SelectedCells[0].Value);
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
                datalistadoUnidadesSAT.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

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

            if (insertar.insertarUnidad(parametros) == true)
            {
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
                datalistadoUnidadesSAT.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

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
            if (txtUnidadCompra.Text != "")
            {
                datalistadoUnidadCompraPanel.BringToFront();
                datalistadoUnidadCompraPanel.Location = new Point(449, 201);
                datalistadoUnidadCompraPanel.Size = new Size(174, 72);
                mostrarUnidadesCompra();
                datalistadoUnidadCompraPanel.Visible = true;
            }
            else
            {
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
                datalistadoUnidadCompra.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

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
            UnidadMultiplicada1.Text = "x " + txtUnidadCompra.Text;
            UnidadMultiplicada2.Text = "x " + txtUnidadCompra.Text;
        }

        private void txtUnidadDeVenta_TextChanged(object sender, EventArgs e)
        {
            if (txtUnidadDeVenta.Text != "")
            {
                panelUnidadVenta.BringToFront();
                panelUnidadVenta.Location = new Point(674, 201);
                panelUnidadVenta.Size = new Size(174, 72);
                mostrarUnidadesVenta();
                panelUnidadVenta.Visible = true;
            }
            else
            {

                //mostrarUnidadesVenta();
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
                // datalistadoUnidadVenta.Columns[2].Width = 800;
                datalistadoUnidadVenta.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Bases.Multilinea(ref datalistadoUnidadVenta);
        }

        private void PANELINFOR_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void PANELREGISTRO_Paint(object sender, PaintEventArgs e)
        {
            PanelInformacionBasicaATRAS.BringToFront();
            PanelInformacionBasicaATRAS.Visible = true;
            PanelInformacionBasicaATRAS.Location = new Point(36, 1);
            PanelInformacionBasicaATRAS.Size = new Size(979, 634);
            PanelInformacionBasicaATRAS.Dock = DockStyle.Fill;
            panelInformacionBasica.Dock = DockStyle.Fill;

            panelInformacionAdicionalATRAS.Visible = false;
            panelProveedorATRAS.Visible = false;

            panelInfoAduana.Visible = false;
            panelProveedor.Visible = false;
            panelUnidad.Visible = false;
            panelCategoria.Visible = false;

            CalcularItbis();
        }

        private void btnCancelarRegistro_Click(object sender, EventArgs e)
        {
            PANELREGISTRO.Visible = false;
        }

        private void datalistadoUnidadVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void datalistadoUnidadVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idUnidadVenta = Convert.ToInt32(datalistadoUnidadVenta.SelectedCells[0].Value);
            idClaveSatVenta = Convert.ToInt32(datalistadoUnidadVenta.SelectedCells[1].Value);
            txtUnidadDeVenta.Text = datalistadoUnidadVenta.SelectedCells[2].Value.ToString();


            UnidadMultiplicada3.Text = "x " + txtUnidadDeVenta.Text;
            panelUnidadVenta.Visible = false;
        }

        private void cerrarPANELCLAVESAT_Click(object sender, EventArgs e)
        {
            cerrarPANELCLAVESAT.Visible = false;
        }

        private void ObtenerImpuestos()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                da = new SqlDataAdapter("mostrarImpuestoGeneral", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
                con.Close();
                datalistadoImpuestos.DataSource = dt;
                datalistadoImpuestos.Columns[0].Visible = false;
                datalistadoImpuestos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                datalistadoImpuestos.Columns[4].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Bases.Multilinea(ref datalistadoImpuestos);
        }

        private void txtPrecioCompra_TextChanged(object sender, EventArgs e)
        {
            if (txtPrecioCompra.Text != "")
            {
                if (chkImpuestos.Checked == true)
                {
                    try
                    {
                        double totalImpuesto;
                        double txtPrecioComprav = Convert.ToDouble(txtPrecioCompra.Text);
                        totalImpuesto = txtPrecioComprav * itbis;

                        if (totalImpuesto >= 0 && txtPrecioCompra.Focused == true)
                        {
                            double total = totalImpuesto + Convert.ToDouble(txtPrecioCompra.Text);
                            txtPrecioCompraImpuestos.Text = total.ToString();
                        }
                        else
                        {
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                if(Convert.ToDouble(txtPrecioCompra.Text) > 0)
                {
                    panelPrecios.Enabled = true;
                }
            }
            else
            {
                panelPrecios.Enabled = false;
                txtPrecioCompraImpuestos.Text = txtPrecioCompra.Text;
            }
        }

        private void CalcularItbis()
        {
            foreach (DataGridViewRow row in datalistadoImpuestos.Rows)
            {
                itbis += Convert.ToDouble(row.Cells["Itbis"].Value);
            }
        }

        private void timerCalcularItbis_Tick(object sender, EventArgs e)
        {

        }

        private void TXTPRECIODEVENTA2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void chkImpuestos_CheckedChanged(object sender, EventArgs e)
        {
            ObtenerImpuestos();
            if (chkImpuestos.Checked == false)
            {
                txtPrecioCompraImpuestos.Text = txtPrecioCompra.Text;
            }
            else if(chkImpuestos.Checked == true)
            {
                try
                {
                    double totalImpuesto;
                    double txtPrecioComprav = Convert.ToDouble(txtPrecioCompra.Text);
                    totalImpuesto = txtPrecioComprav * itbis;

                    if (totalImpuesto >= 0)
                    {
                        double total = totalImpuesto + Convert.ToDouble(txtPrecioCompra.Text);
                        txtPrecioCompraImpuestos.Text = total.ToString();
                       
                    }
                    else
                    {
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtPrecioCompraImpuestos_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txtPrecioCompraImpuestos, e);

        }

        private void txtVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txtVenta, e);

        }

  
        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrecioVentaPrecio1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txtPrecioVentaPrecio1, e);
        }

        private void txtPorcentajeGanancia1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txtPorcentajeGanancia1, e);

        }

        private void txtPorcentajeGanancia2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txtPorcentajeGanancia2, e);

        }

        private void txtPorcentajeGanancia3_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txtPorcentajeGanancia3, e);

        }

        private void txtPorcentajeGanancia4_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txtPorcentajeGanancia4, e);

        }

        private void txtPrecioVentaPrecio2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txtPrecioVentaPrecio2, e);

        }

        private void txtPrecioVentaPrecio4_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txtPrecioVentaPrecio4, e);

        }

        private void txtPrecioVentaPrecio3_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txtPrecioVentaPrecio3, e);
        }

        private void txtPorcentajeGanancia1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtPrecioVentaPrecio1_TextChanged(object sender, EventArgs e)
        {
            if((Convert.ToDouble(txtPrecioCompra.Text) > 0) && (Convert.ToDouble(txtPrecioCompraImpuestos.Text) > 0))
            {
                panelPrecios.Enabled = true;
                txtVenta.Text = txtPrecioVentaPrecio1.Text;
                if (txtPrecioVentaPrecio1.Text != "")
                {
                    double precioVenta1;
                    double precioCompra1;
                    precioVenta1 = Convert.ToDouble(txtPrecioVentaPrecio1.Text);
                    precioCompra1 = Convert.ToDouble(txtPrecioCompraImpuestos.Text);
                    double total = ((precioVenta1 - precioCompra1) / (precioCompra1)) * 100;
                    if (precioVenta1 > 0)
                    {
                        txtPorcentajeGanancia1.Text = Convert.ToString(Math.Round(total,2));
                    }
                }
            }
        }

        private void TimerCalucular_porcentaje_ganancia_Tick(object sender, EventArgs e)
        {
           
        }

        private void TimerCalcular_precio_venta_Tick(object sender, EventArgs e)
        {
            TimerCalcular_precio_venta.Stop();
            try
            {
                double totalPrecioVenta1;
                double txtpreciocompra1 = Convert.ToDouble(txtPrecioCompraImpuestos.Text);
                double porcentaje1 = Convert.ToDouble(txtPorcentajeGanancia1.Text);

                totalPrecioVenta1 = txtpreciocompra1 + ((txtpreciocompra1 * porcentaje1) / 100);

                if (totalPrecioVenta1 > 0 & txtPorcentajeGanancia1.Focused == true)
                {
                    this.txtPrecioVentaPrecio1.Text = Convert.ToString(totalPrecioVenta1);
                }
                else
                {
                    //Me.txtPorcentajeGanancia.Text = 0
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void TimerCalcular_precio_venta2(object sender, EventArgs e)
        {
            timer1.Stop();
            try
            {
                double totalPrecioVenta2;
                double txtpreciocompra2 = Convert.ToDouble(txtPrecioCompraImpuestos.Text);
                double porcentaje2 = Convert.ToDouble(txtPorcentajeGanancia2.Text);

                totalPrecioVenta2 = txtpreciocompra2 + ((txtpreciocompra2 * porcentaje2) / 100);

                if (totalPrecioVenta2 > 0 & txtPorcentajeGanancia2.Focused == true)
                {
                    this.txtPrecioVentaPrecio2.Text = Convert.ToString(totalPrecioVenta2);
                }
                else
                {
                    //Me.txtPorcentajeGanancia.Text = 0
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void txtPrecioVentaPrecio2_TextChanged(object sender, EventArgs e)
        {
            if ((Convert.ToDouble(txtPrecioCompra.Text) > 0) && (Convert.ToDouble(txtPrecioCompraImpuestos.Text) > 0))
            {
                panelPrecios.Enabled = true;
                if (txtPrecioVentaPrecio2.Text != "")
                {
                    double precioVenta2;
                    double precioCompra2;
                    precioVenta2 = Convert.ToDouble(txtPrecioVentaPrecio2.Text);
                    precioCompra2 = Convert.ToDouble(txtPrecioCompraImpuestos.Text);
                    double total = ((precioVenta2 - precioCompra2) / (precioCompra2)) * 100;
                    if (precioVenta2 > 0)
                    {
                        txtPorcentajeGanancia2.Text = Convert.ToString(Math.Round(total, 2));
                    }
                }
            }
        }

        private void TimerCalcular_precio_venta3(object sender, EventArgs e)
        {
            timer2.Stop();
            try
            {
                double totalPrecioVenta3;
                double txtpreciocompra3 = Convert.ToDouble(txtPrecioCompraImpuestos.Text);
                double porcentaje3 = Convert.ToDouble(txtPorcentajeGanancia3.Text);

                totalPrecioVenta3 = txtpreciocompra3 + ((txtpreciocompra3 * porcentaje3) / 100);

                if (totalPrecioVenta3 > 0 & txtPorcentajeGanancia3.Focused == true)
                {
                    this.txtPrecioVentaPrecio3.Text = Convert.ToString(totalPrecioVenta3);
                }
                else
                {
                    //Me.txtPorcentajeGanancia.Text = 0
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void txtPrecioVentaPrecio3_TextChanged(object sender, EventArgs e)
        {
            if ((Convert.ToDouble(txtPrecioCompra.Text) > 0) && (Convert.ToDouble(txtPrecioCompraImpuestos.Text) > 0))
            {
                panelPrecios.Enabled = true;
                if (txtPrecioVentaPrecio3.Text != "")
                {
                    double precioVenta3;
                    double precioCompra3;
                    precioVenta3 = Convert.ToDouble(txtPrecioVentaPrecio3.Text);
                    precioCompra3 = Convert.ToDouble(txtPrecioCompraImpuestos.Text);
                    double total = ((precioVenta3 - precioCompra3) / (precioCompra3)) * 100;
                    if (precioVenta3 > 0)
                    {
                        txtPorcentajeGanancia3.Text = Convert.ToString(Math.Round(total, 2));
                    }
                }
            }
        }

        private void txtPrecioVentaPrecio4_TextChanged(object sender, EventArgs e)
        {
            if ((Convert.ToDouble(txtPrecioCompra.Text) > 0) && (Convert.ToDouble(txtPrecioCompraImpuestos.Text) > 0))
            {
                panelPrecios.Enabled = true;
                if (txtPrecioVentaPrecio4.Text != "")
                {
                    double precioVenta4;
                    double precioCompra4;
                    precioVenta4 = Convert.ToDouble(txtPrecioVentaPrecio4.Text);
                    precioCompra4 = Convert.ToDouble(txtPrecioCompraImpuestos.Text);
                    double total = ((precioVenta4 - precioCompra4) / (precioCompra4)) * 100;
                    if (precioVenta4 > 0)
                    {
                        txtPorcentajeGanancia4.Text = Convert.ToString(Math.Round(total, 2));
                    }
                }
            }
        }

        private void TimerCalcular_precio_venta4(object sender, EventArgs e)
        {
            timer3.Stop();
            try
            {
                double totalPrecioVenta4;
                double txtpreciocompra4 = Convert.ToDouble(txtPrecioCompraImpuestos.Text);
                double porcentaje4 = Convert.ToDouble(txtPorcentajeGanancia4.Text);

                totalPrecioVenta4 = txtpreciocompra4 + ((txtpreciocompra4 * porcentaje4) / 100);

                if (totalPrecioVenta4 > 0 & txtPorcentajeGanancia4.Focused == true)
                {
                    this.txtPrecioVentaPrecio4.Text = Convert.ToString(totalPrecioVenta4);
                }
                else
                {
                    //Me.txtPorcentajeGanancia.Text = 0
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnGuardarInformacionBasica_Click(object sender, EventArgs e)
        {
            TextBox[] array = {  txtdescripcion, txtcodigodebarras, txtCategoria, txtUnidadCompra, txtUnidadDeVenta, txtPrecioCompra, txtPrecioCompraImpuestos, txtStock};

            if (idDescuento != 0 && idCategoria != 0 && idUnidadVenta != 0 && idUnidadCompra != 0) {
                if (Insertar_datos.ValidTextIsNotNullOrEmpty(array))
                {
                    if (txtPrecioVentaPrecio1.Text != "0" && txtPrecioVentaPrecio2.Text != "0" && txtPrecioVentaPrecio3.Text != "0" && txtPrecioVentaPrecio4.Text != "0" &&
                       txtPrecioCompra.Text != "0" && txtUnidadDeVenta.Text != "0" && txtUnidadVenta.Text != "0")
                    {
                        if (Convert.ToDouble((Convert.ToDouble(txtPrecioCompra.Text)) <= (Convert.ToDouble(txtPrecioVentaPrecio1.Text))
                            && (Convert.ToDouble(txtPrecioCompra.Text)) <= (Convert.ToDouble(txtPrecioVentaPrecio2.Text))
                            && (Convert.ToDouble(txtPrecioCompra.Text)) <= (Convert.ToDouble(txtPrecioVentaPrecio3.Text))
                            && (Convert.ToDouble(txtPrecioCompra.Text)) <= (Convert.ToDouble(txtPrecioVentaPrecio4.Text))) > 0)
                        {
                            insertarMayoreo();
                        }
                        else
                        {
                            MessageBox.Show("Los datos estan incorrectos.\n El formato es Precio de Compra > Precio de venta(1,2,3,4)", "Datos incompletos", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Los datos estan incorrectos\nExisten campos con 0", "Datos incompletos", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Los datos estan incorrectos\n Selecciona todos los campos correctamente ", "Datos incompletos", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }


     
        private void insertarMayoreo()
        {
            Insertar_datos insertar = new Insertar_datos();
            Mayoreo mayoreo = new Mayoreo();

            mayoreo.mayoreo1 = Convert.ToDouble(txtUnidadMayoreo1.Text);
            mayoreo.mayoreo2 = Convert.ToDouble(txtUnidadMayoreo2.Text);
            mayoreo.mayoreo3 = Convert.ToDouble(txtUnidadMayoreo3.Text);
            mayoreo.mayoreo4 = Convert.ToDouble(txtUnidadMayoreo4.Text);

            if(insertar.insertarMayoreo(mayoreo) == true)
            {
                insertarPrecios();
            }
        }

        private void ObteneridMayoreo()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
            SqlCommand com = new SqlCommand("SELECT idMayoreo FROM VentasMayoreo WHERE idMayoreo = (SELECT Max(idMayoreo) FROM VentasMayoreo)", con);
            try
            {
                con.Open();
                idMayoreo = Convert.ToInt32(com.ExecuteScalar());
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        private void insertarPrecios()
        {
            Insertar_datos insertar = new Insertar_datos();
            Precios precios = new Precios();

            ObteneridMayoreo();
            precios.idMayoreo = idMayoreo;
            precios.precio1 = Convert.ToDouble(txtPrecioVentaPrecio1.Text);
            precios.precio2 = Convert.ToDouble(txtPrecioVentaPrecio2.Text);
            precios.precio3 = Convert.ToDouble(txtPrecioVentaPrecio3.Text);
            precios.precio4 = Convert.ToDouble(txtPrecioVentaPrecio4.Text);
             
            if (insertar.insertarPrecios(precios) == true)
            {
                insertarProductos();
            }
        }

        private void insertarProductos()
        {
            if (idDescuento == 0 || idUnidadCompra == 0 || idUnidadVenta == 0) { 
                MessageBox.Show("ASD");
        }
            UnidadesProductos parametros = new UnidadesProductos();
            LKardex kardex = new LKardex();
            Lproductos lproductos = new Lproductos();
            Insertar_datos insertar = new Insertar_datos();

            lproductos.idCategoria = idCategoria;   
            
            lproductos.Codigo = txtcodigodebarras.Text;
            lproductos.Descripcion = txtdescripcion.Text;
            lproductos.Stock = Convert.ToDouble(txtStock.Text);
            lproductos.Preciodecompra = Convert.ToDouble(txtPrecioCompraImpuestos.Text);
            lproductos.idImpuesto = 1;
            lproductos.idDescuento = idDescuento;
            
            kardex.Fecha = DateTime.Today;
            kardex.Motivo = "Registro inicial de Producto";
            kardex.Cantidad = Convert.ToDouble(txtStock.Text);
            kardex.Id_usuario = idusuario;
            kardex.Id_caja = idcaja;
            kardex.Tipo = "ENTRADA";
            kardex.Estado = "CONFIRMADO";
            kardex.Id_caja = idcaja;

            parametros.idUnidadVenta = idUnidadVenta;
            parametros.idUnidadCompra = idUnidadCompra;

            if(insertar.insertarProducto(lproductos, kardex, parametros) == true)
            {
                PANELREGISTRO.Visible = false;
                mostrarProductos();
            }

        }


     /*   private void buscar()
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
     */
        private void mostrarProductos()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("Mostrarprodutos", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                da.Fill(dt);
                datalistado.DataSource = dt;
                con.Close();

                datalistado.Columns[2].Visible = false;
                datalistado.Columns[3].Visible = false;
                datalistado.Columns[4].Visible = false;
                datalistado.Columns[9].Visible = false;
                datalistado.Columns[10].Visible = false;
                datalistado.Columns[13].Visible = false;
                datalistado.Columns[15].Visible = false;
                datalistado.Columns[16].Visible = false;
                datalistado.Columns[17].Visible = false;
                datalistado.Columns[18].Visible = false;
                datalistado.Columns[19].Visible = false;
                datalistado.Columns[20].Visible = false;
                datalistado.Columns[21].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Bases.Multilinea(ref datalistado);
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
                     cmd.Parameters.AddWithValue("@Precio_de_compra", txtPrecioCompra.Text);
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

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txtStock, e);
        }

        private void btnGuardarCambiosInformacionBasica_Click(object sender, EventArgs e)
        {
            /*TextBox[] array = { txtpreciomayoreo, txtdescripcion, txtcodigodebarras, txtcosto, TXTPRECIODEVENTA2, txtpreciomayoreo, txtgrupo };
            if (Insertar_datos.ValidTextIsNotNullOrEmpty(array))
            {
                if (txtstock2.Text != "0" && txtPrecioCompra.Text != "0" && TXTPRECIODEVENTA2.Text != "0")
                {
                    double txtpreciomayoreoV = Convert.ToDouble(txtpreciomayoreo.Text);

                    double txtapartirdeV = Convert.ToDouble(txtapartirde.Text);
                    double txtPrecioCompraV = Convert.ToDouble(txtPrecioCompra.Text);
                    double TXTPRECIODEVENTA2V = Convert.ToDouble(TXTPRECIODEVENTA2.Text);
                    if (txtpreciomayoreo.Text == "") txtpreciomayoreo.Text = "0";
                    if (txtapartirde.Text == "") txtapartirde.Text = "0";
                    //TXTPRECIODEVENTA2.Text = TXTPRECIODEVENTA2.Text.Replace(lblmoneda.Text + " ", "");
                    //TXTPRECIODEVENTA2.Text = System.String.Format(((decimal)TXTPRECIODEVENTA2.Text), "##0.00");
                    if ((txtpreciomayoreoV > 0 & Convert.ToDouble(txtapartirde.Text) > 0) | (txtpreciomayoreoV == 0 & txtapartirdeV == 0))
                    {
                        if (txtPrecioCompraV >= TXTPRECIODEVENTA2V)
                        {

                            DialogResult result;
                            result = MessageBox.Show("El precio del Articulo es menor o igual que el costo, Esto te puede generar perdidas", "Producto con Perdidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            if (result == DialogResult.OK)
                            {
                                TXTPRECIODEVENTA2.Focus();
                                TXTPRECIODEVENTA2.SelectAll();
                            }
                        }
                        else if (txtPrecioCompraV < TXTPRECIODEVENTA2V)
                        {
                            if (Convert.ToDouble(txtpreciomayoreo.Text) <= Convert.ToDouble(txtPrecioCompra.Text) &&
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

        private void panelInformacionAdicionalATRAS_Paint(object sender, PaintEventArgs e)
        {
            PanelInformacionAdicional.Dock = DockStyle.Fill;
        }

        private void txtPreciosProveedor_TextChanged(object sender, EventArgs e)
        {
            if(txtPreciosProveedor.Text != "")
            {
                buscarPreciosProveedor();
            }
        }

        private void buscarPreciosProveedor()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("buscarPreciosCompra", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@buscar", txtPreciosProveedor.Text + "");
                da.Fill(dt);
                datalistadoPreciosProveedor.DataSource = dt;
                con.Close();

                datalistadoPreciosProveedor.DataSource = dt;
                datalistadoPreciosProveedor.Columns[0].Visible = false;
                datalistadoPreciosProveedor.Columns[1].Visible = false;
                datalistadoPreciosProveedor.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Bases.Multilinea(ref datalistadoPreciosProveedor);
        }

        private void panelProveedorATRAS_Paint(object sender, PaintEventArgs e)
        {
            txtPreciosProveedor.Text = "";
            PanelUltimosPreciosAgregados.Visible = false;
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("mostrarPreciosCompra", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
                datalistadoPreciosProveedor.DataSource = dt;
                con.Close();

                datalistadoPreciosProveedor.DataSource = dt;
                datalistadoPreciosProveedor.Columns[0].Visible = false;
                datalistadoPreciosProveedor.Columns[1].Visible = false;
                datalistadoPreciosProveedor.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Bases.Multilinea(ref datalistadoPreciosProveedor);
        }

        private void btnAgregarPreciosProveedor_Click(object sender, EventArgs e)
        {
            PanelUltimosPreciosAgregados.Visible = true;
            PanelUltimosPreciosAgregados.BringToFront();
            PanelUltimosPreciosAgregados.Location = new Point(291, 116);
            PanelUltimosPreciosAgregados.Size = new Size(410, 313);
            txtProveedorPreciosArticulo.Text = "";
            txtPreciodeCompraPrecios.Text = "";
        }

        private void btnUltimosPreciosAgregar_Click(object sender, EventArgs e)
        {
           // UltimosPreciosAgregarAgregar.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            PanelUltimosPreciosAgregados.Visible = false;
        }

        private void txtProveedorPreciosArticulo_TextChanged(object sender, EventArgs e)
        {
            if (txtProveedorPreciosArticulo.Text != "")
            {
                panelMostrarProveedor.BringToFront();
                panelMostrarProveedor.Location = new Point(19, 82);
                panelMostrarProveedor.Size = new Size(133,45);
                buscarProveedores();
                panelMostrarProveedor.Visible = true;
            }
            else
            {

                buscarProveedores();
                panelMostrarProveedor.SendToBack();
                panelMostrarProveedor.Visible = false;
            }
        }

        private void buscarProveedores()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("Buscar_proveedores", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letra", txtPreciosProveedor.Text);
                da.Fill(dt);
                con.Close();
                datalistadoProveedorPrecios.DataSource = dt;
                datalistadoProveedorPrecios.Columns[0].Visible = false;
                datalistadoProveedorPrecios.Columns[2].Visible = false;
                datalistadoProveedorPrecios.Columns[3].Visible = false;
                datalistadoProveedorPrecios.Columns[4].Visible = false;
                datalistadoProveedorPrecios.Columns[5].Visible = false;
                datalistadoProveedorPrecios.Columns[6].Visible = false;
                datalistadoProveedorPrecios.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                datalistadoProveedorPrecios.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Bases.Multilinea(ref datalistadoProveedorPrecios);
        }

        private void txtPreciodeCompraPrecios_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txtPreciosProveedor, e);
        }

        int idProveedorPreciosSelect;
        int idProductoSelect;
        private int idAlmacenSelect;
        private int idDescuento;

        private void btnUltimosPreciosCompraAgregar_Click(object sender, EventArgs e)
        {
            
             TextBox[] array = {txtPreciodeCompraPrecios, txtProveedorPreciosArticulo};
            if (Insertar_datos.ValidTextIsNotNullOrEmpty(array))
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                    con.Open();
                    CONEXIONMAESTRA.abrir();
                    SqlCommand cmd = new SqlCommand("insertarPreciosProveedor", CONEXIONMAESTRA.conectar);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idProveedor", idProveedorPreciosSelect);
                    ObteneridproductoUltimo();
                    //idProductoSelect
                    cmd.Parameters.AddWithValue("@idProducto", 1);

                    cmd.Parameters.AddWithValue("@PrecioCompra", Convert.ToDouble(txtPreciodeCompraPrecios.Text));
                    cmd.Parameters.AddWithValue("@FechaCompra", txtFechaUltimosPrecios.Value.Date);
                    cmd.ExecuteNonQuery();
                    CONEXIONMAESTRA.cerrar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                PanelUltimosPreciosAgregados.Visible = false;
                panelMostrarProveedor.Visible = true;
            }
            else
            {

            }
        }

        private void datalistadoProveedorPrecios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idProveedorPreciosSelect = Convert.ToInt32(datalistadoProveedorPrecios.SelectedCells[0].Value);
            txtProveedorPreciosArticulo.Text = datalistadoProveedorPrecios.SelectedCells[1].Value.ToString();
            panelMostrarProveedor.SendToBack();
            panelMostrarProveedor.Visible = false;


            // MessageBox.Show(idProveedorPreciosSelect.ToString());
        }

        private void ObteneridproductoUltimo()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
            SqlCommand com = new SqlCommand("SELECT idProducto FROM Producto WHERE idProducto = (SELECT Max(idProducto) FROM Producto)", con);
            try
            {
                con.Open();
                idProductoSelect = Convert.ToInt32(com.ExecuteScalar());
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void button7_Click_2(object sender, EventArgs e)
        {
            PanelUltimosPreciosAgregados.Visible = false;
        }

        private void txtDescuentosCategoria_DoubleClick(object sender, EventArgs e)
        {
            panelDescuentos.Visible = true;
            panelDescuentos.BringToFront();
            panelDescuentos.Location = new Point(72, 114);
            panelDescuentos.Size = new Size(337, 311);
        }


        private void btnDescuentoAgregar_Click(object sender, EventArgs e)
        {
            TextBox[] array = { txtDescuentoAgregar};
            if (Insertar_datos.ValidTextIsNotNullOrEmpty(array))
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                    con.Open();
                    CONEXIONMAESTRA.abrir();
                    SqlCommand cmd = new SqlCommand("insertarDescuento", CONEXIONMAESTRA.conectar);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Descuento", Convert.ToDouble(txtDescuentoAgregar.Text));
                    cmd.Parameters.AddWithValue("@TipoDescuento", "Descuento de Categoria");
                    cmd.ExecuteNonQuery();
                    CONEXIONMAESTRA.cerrar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                panelDescuentos.Visible = false;
            }
            else
            {

            }
        }

        private void panelCategoriaAgregar_Paint(object sender, PaintEventArgs e)
        {
            //panelMostrarDescuentoCategoria.Visible = false;
            /* panelDescuentos.Visible = false;
             panelImpuestosAgregar.Visible = false;*/


        }

        private void button13_Click(object sender, EventArgs e)
        {
            panelDescuentos.Visible = false;
        }

        private void txtDescuentosCategoria_TextChanged(object sender, EventArgs e)
        {
            if (txtDescuentosCategoria.Text != "")
            {
                panelMostrarDescuentoCategoria.BringToFront();
                panelMostrarDescuentoCategoria.Location = new Point(20, 228);
                panelMostrarDescuentoCategoria.Size = new Size(72, 114);
                buscarDescientosCategoria();
                panelMostrarDescuentoCategoria.Visible = true;
            }
            else
            {
                buscarDescientosCategoria();
                panelMostrarDescuentoCategoria.SendToBack();
                panelMostrarDescuentoCategoria.Visible = false;
            }

            
        }

        private void buscarDescientosCategoria()
        {
            
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("buscarDescuentosCategoria", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@buscar", txtDescuentosCategoria.Text);
                da.Fill(dt);
                datalistadoUnidadesSAT.DataSource = dt;
                con.Close();

                datalistadoMostrarDescuentoCategoria.DataSource = dt;
                datalistadoMostrarDescuentoCategoria.Columns[0].Visible = false;
                datalistadoMostrarDescuentoCategoria.Columns[2].Visible = false;
                datalistadoMostrarDescuentoCategoria.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Bases.Multilinea(ref datalistadoMostrarDescuentoCategoria);
        }

        private void txtImpuestoAgregar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnImpuestoAgregar_Click(object sender, EventArgs e)
        {
            TextBox[] array = { txtNombreImpuestoAgregar, txtImpuestoAgregar };
            if (Insertar_datos.ValidTextIsNotNullOrEmpty(array))
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                    con.Open();
                    CONEXIONMAESTRA.abrir();
                    SqlCommand cmd = new SqlCommand("insertarImpuestosCategoria", CONEXIONMAESTRA.conectar);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@nombre", txtNombreImpuestoAgregar.Text);
                    cmd.Parameters.AddWithValue("@Impuesto", Convert.ToDouble(txtImpuestoAgregar.Text));
                    cmd.Parameters.AddWithValue("@tipo", "Impuesto Categoria");
                    cmd.ExecuteNonQuery();
                    CONEXIONMAESTRA.cerrar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                panelImpuestosAgregar.Visible = false;
            }
            else
            {

            }
        }

        private void txtImpuestosCategoria_DoubleClick(object sender, EventArgs e)
        {
            panelImpuestosAgregar.Visible = true;
            panelImpuestosAgregar.BringToFront();
            panelImpuestosAgregar.Location = new Point(93, 123);
            panelImpuestosAgregar.Size = new Size(337, 311);
        }

        private void txtImpuestoAgregar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txtImpuestoAgregar, e);
        }

        private void txtDescuentoAgregar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txtDescuentoAgregar, e);
        }

        private void txtDescuentosCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txtDescuentosCategoria, e);
        }

        private void txtImpuestosCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txtImpuestosCategoria, e);
        }

        private void txtImpuestosCategoria_TextChanged(object sender, EventArgs e)
        {
            if (txtImpuestosCategoria.Text != "")
            {
                panelImpuestosCategoria.BringToFront();
                panelImpuestosCategoria.Location = new Point(18, 320);
                panelImpuestosCategoria.Size = new Size(228, 52);
                buscarImpuestosCategoria();
                panelImpuestosCategoria.Visible = true;
            }
            else
            {

                buscarDescientosCategoria();
                panelImpuestosCategoria.SendToBack();
                panelImpuestosCategoria.Visible = false;
            }
        }

        private void buscarImpuestosCategoria()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("buscarImpuestosCategoria", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@buscar", txtImpuestosCategoria.Text + "");
                da.Fill(dt);
                datalistadoUnidadesSAT.DataSource = dt;
                con.Close();

                datalistadiImpuestosCategoria.DataSource = dt;
                datalistadiImpuestosCategoria.Columns[0].Visible = false;
                datalistadiImpuestosCategoria.Columns[2].Visible = false;
                datalistadiImpuestosCategoria.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Bases.Multilinea(ref datalistadoMostrarDescuentoCategoria);
        }

        
        private void PanelInformacionBasicaATRAS_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PANELINFOR_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            panelImpuestosAgregar.Visible = false;
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            Presentacion.Almacenes.Almacenes frm = new Presentacion.Almacenes.Almacenes();
            frm.ShowDialog();
        }

        private void txtAlmacen_TextChanged(object sender, EventArgs e)
        {
            if (txtAlmacen.Text != "")
            {
                panelAlmacenBuscar.BringToFront();
                panelAlmacenBuscar.Location = new Point(22, 124);
                panelAlmacenBuscar.Size = new Size(210, 64);
                mostrarAlmacen();
                panelAlmacenBuscar.Visible = true;
            }
            else
            {
                mostarCategoria();
                panelAlmacenBuscar.SendToBack();
                panelAlmacenBuscar.Visible = false;
            }
        }

        private void mostrarAlmacen()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("mostrarAlmacenBuscar", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@buscar", txtUnidadCompra.Text);
                da.Fill(dt);
                con.Close();
                datalistadoAlmacenBuscar.DataSource = dt;
                datalistadoAlmacenBuscar.Columns[0].Visible = false;
                datalistadoAlmacenBuscar.Columns[3].Visible = false;
                datalistadoAlmacenBuscar.Columns[4].Visible = false;
                datalistadoAlmacenBuscar.Columns[5].Visible = false;
                datalistadoAlmacenBuscar.Columns[6].Visible = false;
                datalistadoAlmacenBuscar.Columns[7].Visible = false;
                datalistadoAlmacenBuscar.Columns[1].Visible = false;

                datalistadoAlmacenBuscar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Bases.Multilinea(ref datalistadoAlmacenBuscar);
        }

        private void datalistadoAlmacenBuscar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idAlmacenSelect = Convert.ToInt32(datalistadoAlmacenBuscar.SelectedCells[0].Value);
            txtAlmacen.Text = datalistadoAlmacenBuscar.SelectedCells[2].Value.ToString();
            panelAlmacenBuscar.SendToBack();
            panelAlmacenBuscar.Visible = false;
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            Presentacion.Impuestos.Impuestos frm = new Presentacion.Impuestos.Impuestos();
            frm.ShowDialog();
            chkImpuestos.Checked = false;
        }

        private void panelInformacionBasica_Click(object sender, EventArgs e)
        {
            ObtenerImpuestos();
        }

        private void txtDescuento_DoubleClick(object sender, EventArgs e)
        {

        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            if (txtDescuento.Text != "")
            {
                panelDescuentoBasico.BringToFront();
                panelDescuentoBasico.Location = new Point(485, 311);
                panelDescuentoBasico.Size = new Size(72, 114);
                buscarDescuentos();
                panelDescuentoBasico.Visible = true;
            }
            else
            {
                buscarDescuentos();
                panelDescuentoBasico.SendToBack();
                panelDescuentoBasico.Visible = false;
            }
        }
        private void buscarDescuentos()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("buscarDescuentos", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@buscar", txtDescuento.Text);
                da.Fill(dt);
                datalistadoUnidadesSAT.DataSource = dt;
                con.Close();

                datalistadoDescuentoBasico.DataSource = dt;
                datalistadoDescuentoBasico.Columns[0].Visible = false;
                datalistadoDescuentoBasico.Columns[2].Visible = false;
                datalistadoDescuentoBasico.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Bases.Multilinea(ref datalistadoMostrarDescuentoCategoria);
        }

        private void datalistadoDescuentoBasico_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idDescuento = Convert.ToInt32(datalistadoDescuentoBasico.SelectedCells[0].Value);
            txtDescuento.Text = datalistadoDescuentoBasico.SelectedCells[1].Value.ToString();
            panelDescuentoBasico.Visible = false;

        }
    }
}
 