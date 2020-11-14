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

namespace SistemaVentas.Presentacion.Categoria
{
    public partial class Categoria : Form
    {
        public Categoria()
        {
            InitializeComponent();
        }
        int idUnidad;
        string estado;
        private int idClaveSat;
        private int idDescuento;
        private int idImpuesto;

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Nuevo();
            panelRegistros.Visible = true;
        }

        private void EmpleadosOK_Load(object sender, EventArgs e)
        {
           // txtClaveSat.Enabled = false;
            panelClaveUnidadSat.Visible = false;
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
            TextBox[] array = { txtCategoria, txtDepartamento};
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
            insertarUnidad();
        }

        public void insertarUnidad()
        {
            LCategoria parametros = new LCategoria();
            Insertar_datos insertar = new Insertar_datos();
            

            parametros.Descripcion = txtCategoria.Text;
            parametros.Departamento = txtDepartamento.Text;
            parametros.idDescuento = idDescuento;
            parametros.idImpuesto = idImpuesto;

            if (insertar.insertarUnidad(parametros) == true)
            {
                mostrar();
            }

        }

        
        private void rellenarCamposVacios()
        {
            if (string.IsNullOrEmpty(txtCategoria.Text))
            { txtCategoria.Text = "-"; };
            if (string.IsNullOrEmpty(txtCategoria.Text)) { txtCategoria.Text = "-"; };
            if (string.IsNullOrEmpty(txtDepartamento.Text)) { txtDepartamento.Text = "-"; };
        }

        private void mostrar()
        {
            mostrarCat();   
            panelRegistros.Visible = false;
            pintarDatalistado();
        }
        private void pintarDatalistado()
        {
            Bases.Multilinea(ref datalistado);
            datalistado.Columns[2].Visible = false;
            datalistado.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }
        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtbuscar.Text != "")
            {
                buscar();
            }
            else
            {
                mostrar();
            }
        }

        private void buscar()
        {
            
            mostarCategoriaCompleta(txtbuscar.Text);
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
                datalistado.DataSource = dt;
                con.Close();

                datalistado.DataSource = dt;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Bases.Multilinea(ref datalistado);
        }

        private void mostrarCat()
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
                datalistado.DataSource = dt;
                con.Close();

                datalistado.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Bases.Multilinea(ref datalistado);
        }
        private void obtenerId_estado()
        {
            try
            {
                idUnidad = Convert.ToInt32(datalistado.SelectedCells[2].Value);
            }
            catch (Exception)
            {

            }
        }
        private void obtenerDatos()
        {
            try
            {
                idUnidad = Convert.ToInt32(datalistado.SelectedCells[2].Value);
                txtCategoria.Text = datalistado.SelectedCells[4].Value.ToString();
                txtDepartamento.Focus();
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
            TextBox[] array = { txtCategoria, txtDepartamento };
           
            if (Insertar_datos.ValidTextIsNotNullOrEmpty(array))
            {
                    obtenerId_estado();
                    rellenarCamposVacios();
                    editar();
            }
            else
            {
                MessageBox.Show("Favor llenar los campos correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

     
        public void editar()
        {
            editarUnidad();
        }
        public void editarUnidad()
        {
            LUnidadProductos parametros = new LUnidadProductos();
            Editar_datos insertar = new Editar_datos();


            parametros.descripcion = txtCategoria.Text;
            parametros.idClaveSat = idClaveSat;

            if (insertar.editarUnidad(parametros) == true)
            {
                mostrar();
            }
        }

        private void eliminar()
        {
            LUnidadProductos parametros = new LUnidadProductos();
            parametros.idUnidad = idUnidad;
            Eliminar_datos.eliminarUnidad(idUnidad);
            mostrar();
        }

        private void Nuevo()
        {
            panelRegistros.Visible = true;
            limpiar();
            btnGuardar.Visible = true;
            btnGuardarCambios.Visible = false;
            txtCategoria.Focus();
            panelRegistros.Dock = DockStyle.Fill;
        }
        
        private void limpiar()
        {
            txtCategoria.Clear();
            txtDepartamento.Clear();
            txtbuscar.Clear();
            txtUnidadBuscar.Clear();
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


        private void dlg_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
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
                idUnidad = Convert.ToInt32(datalistado.SelectedCells[2].Value);
                DialogResult result = MessageBox.Show("¿Realmente desea eliminar este Registro?", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    eliminar();
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

        private void txtClaveSat_DoubleClick(object sender, EventArgs e)
        {
            panelClaveUnidadSat.Visible = true;
            //panelUnidad.Visible = true;
            panelClaveUnidadSat.Location = new Point(121, 131);
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

        private void cerrarPANELCLAVESAT_Click(object sender, EventArgs e)
        {
            panelClaveUnidadSat.Visible = false;
        }

        private void datalistadoUnidadesSAT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            panelClaveUnidadSat.Visible = false;
            idClaveSat = Convert.ToInt32(datalistadoUnidadesSAT.SelectedCells[0].Value.ToString());
            txtDepartamento.Text = datalistadoUnidadesSAT.SelectedCells[2].Value.ToString();
            txtCategoria.Focus();
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
    }

}
