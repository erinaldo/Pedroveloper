using SistemaVentas.Datos;
using SistemaVentas.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaVentas.Presentacion.Almacenes
{
    public partial class Almacenes : Form
    {
        public Almacenes()
        {
            InitializeComponent();
        }
        int idAlmacen;
        int idLocalizacion;
        
        int idImpuesto;
        string estado;
        private int idDireccionEditar;
        private int idDireccion;

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Nuevo();
            panelRegistros.Visible = true;
        }

        private void EmpleadosOK_Load(object sender, EventArgs e)
        {
            
            panelRegistros.Visible = false;
            mostrar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panelRegistros.Visible = false;
            
        }

     

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            TextBox[] array = { txtDescripcionAlmacen, txtStockMinimo, txtAnaquel, txtDireccion, txtLocalizacion,txtZona};
            if (Insertar_datos.ValidTextIsNotNullOrEmpty(array))
            {
                insertar();
                rellenarCamposVacios();
            }
            else
            {
                MessageBox.Show("Canmpos vacios\n Llene correctamente los campos", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void insertar()
        {
          insertarImpuestos();
        }

        public void insertarImpuestos()
        {
            if(idDireccion != 0)
            {
                Insertar_datos insertar = new Insertar_datos();
                LAlmacen almacen = new LAlmacen();
                almacen.almacen = txtDescripcionAlmacen.Text;
                almacen.localizaicon = txtLocalizacion.Text;
                almacen.Anaquel = txtAnaquel.Text;
                almacen.idDireccion = idDireccion;
                almacen.stockminimo = Convert.ToDouble(txtStockMinimo.Text);
                almacen.Zona = txtZona.Text;

                if (Convert.ToDouble(txtStockMinimo.Text) > 0.00)
                {
                    if (insertar.insertarLozalizacion(almacen) == true)
                    {
                        Obteneridlocalizacion();
                        almacen.idLocalizacion = idLocalizacion;
                        if (insertar.insertarAlmacen(almacen) == true)
                        {
                            mostrar();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Favor escribir un porcentaje de impuesto valido", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Favor seleccionar una dirección", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }
        private void Obteneridlocalizacion()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
            SqlCommand com = new SqlCommand("SELECT idLocalizacion FROM Localizacion WHERE idLocalizacion = (SELECT Max(idLocalizacion) FROM Localizacion)", con);
            try
            {
                con.Open();
                idLocalizacion = Convert.ToInt32(com.ExecuteScalar());
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void rellenarCamposVacios()
        {
            if (string.IsNullOrEmpty(txtDescripcionAlmacen.Text))
            { txtDescripcionAlmacen.Text = "-"; };
            if (string.IsNullOrEmpty(txtDescripcionAlmacen.Text)) { txtDescripcionAlmacen.Text = "-"; };
            if (string.IsNullOrEmpty(txtStockMinimo.Text)) { txtStockMinimo.Text = "-"; };
        }

        private void mostrar()
        {
            DataTable dt = new DataTable();
            Obtener_datos.mostrarAlmacen(ref dt);
            datalistado.DataSource = dt;
            panelRegistros.Visible = false;
            pintarDatalistado();
        }
        private void pintarDatalistado()
        {
            Bases.Multilinea(ref datalistado);
            datalistado.Columns[2].Visible = false;
        }

      
        private void datalistado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }




        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtbuscar.Text != "")
            {
                buscar();
            }
        }

        private void buscar()
        {
            DataTable dt = new DataTable();
            Obtener_datos.buscarImpuestos(ref dt, txtbuscar.Text);
            datalistado.DataSource = dt;
            pintarDatalistado();
        }
        private void obtenerId_estado()
        {
            try
            {
                idImpuesto = Convert.ToInt32(datalistado.SelectedCells[2].Value);
                estado = datalistado.SelectedCells[6].Value.ToString();
            }
            catch (Exception)
            {

            }
        }
        private void obtenerDatos()
        {
            try
            {
                idImpuesto = Convert.ToInt32(datalistado.SelectedCells[2].Value);
                txtDescripcionAlmacen.Text = datalistado.SelectedCells[3].Value.ToString();
                txtStockMinimo.Text = datalistado.SelectedCells[4].Value.ToString();
                estado = datalistado.SelectedCells[6].Value.ToString();
                prepararEdicion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void prepararEdicion()
        {
           
            panelRegistros.Visible = true;
            panelRegistros.Dock = DockStyle.Fill;
            panelRegistros.BringToFront();
            //datalistado.SendToBack();
            btnGuardar.Visible = false;
            btnGuardarCambios.Visible = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            TextBox[] array = { txtDescripcionAlmacen, txtStockMinimo };
           
            if (Insertar_datos.ValidTextIsNotNullOrEmpty(array))
            {
                    obtenerId_estado();
                    rellenarCamposVacios();
                    editar();
                    MessageBox.Show("Seleccione un Tipo de Impuesto", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
              
            }
            else
            {
                MessageBox.Show("Favor llenar los campos correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

     
        public void editar()
        {
            //obtenerDatosID();
            editarImpuesto();
        }
        public void editarImpuesto()
        {
            LImpuesto parametros = new LImpuesto();
            Editar_datos funcion = new Editar_datos();

            double porciento = calcularPorciento();
            parametros.idImpuesto = idImpuesto;
            parametros.nombre = txtDescripcionAlmacen.Text;
            parametros.impuesto = porciento;

            if(porciento > 0.00 && porciento < 20.00)
            {
                if (funcion.editarImpuestos(parametros) == true)
                {
                    mostrar();
                }
            }
            else
            {
                MessageBox.Show("Favor escribir un porcentaje de impuesto valido", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void eliminar()
        {
            LImpuesto parametros = new LImpuesto();
            parametros.idImpuesto = idImpuesto;
            Eliminar_datos.eliminarImpuesto(idImpuesto);
            mostrar();
        }

        private void datalistado_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Nuevo()
        {
            panelRegistros.Visible = true;
            limpiar();
            btnGuardar.Visible = true;
            btnGuardarCambios.Visible = false;
            txtDescripcionAlmacen.Focus();
            panelRegistros.Dock = DockStyle.Fill;
        }
        
        private void limpiar()
        {
            txtDescripcionAlmacen.Clear();
            txtStockMinimo.Clear();
            txtbuscar.Clear();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void panelRegistros_Paint(object sender, PaintEventArgs e)
        {

        }

 

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

   

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {

        }


        private void Label8_Click(object sender, EventArgs e)
        {

        }


        private void dlg_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
           
        }

        private double calcularPorciento()
        {
            double porciento;
            porciento = Convert.ToDouble(txtStockMinimo.Text);
            porciento = porciento / 100;
            return porciento;
        }
        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
     
        private void tiempoBuscador_Tick(object sender, EventArgs e)
        {
        }

        private void datalistado_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == datalistado.Columns["EditarG"].Index)
            {
                obtenerDatos();
            }
            if (e.ColumnIndex == datalistado.Columns["EliminarG"].Index)
            {
                obtenerId_estado();

                idImpuesto =  Convert.ToInt32(datalistado.SelectedCells[2].Value);
                if (estado == "ACTIVO")
                {
                    DialogResult result = MessageBox.Show("¿Realmente desea eliminar este Registro?", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        eliminar();
                    }
                }
            }
        }

        private void txtImpuesto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            if (txtDireccion.Text != "")
            {
                mostrarDireccion();
            }
            else
            {
                panelDataListadoDireccion.Visible = false;

            }
        }

        private void mostrarDireccion()
        {
            panelDataListadoDireccion.Visible = true;
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("buscarDireccion", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letra", txtDireccion.Text);
                da.Fill(dt);
                datalistadoDireccion.DataSource = dt;
                con.Close();

                datalistadoDireccion.DataSource = dt;
                pintarDatalistadoDireccion();
                datalistadoDireccion.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Bases.Multilinea(ref datalistado);
        }

        private void datalistadoDireccion_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            idDireccionEditar = Convert.ToInt32(datalistadoDireccion.SelectedCells[0].Value);
            idDireccion = Convert.ToInt32(datalistadoDireccion.SelectedCells[0].Value);
            txtDireccion.Text = datalistadoDireccion.SelectedCells[1].Value.ToString();
            panelDataListadoDireccion.Visible = false;
        }

        private void pintarDatalistadoDireccion()
        {
            Bases.Multilinea(ref datalistadoDireccion);
            datalistadoDireccion.Columns[0].Visible = false;
        }

        private void txtDireccion_DoubleClick(object sender, EventArgs e)
        {
            Presentacion.Direccion.Direcciones frm = new Presentacion.Direccion.Direcciones();
            frm.ShowDialog();
        }
    }

}
