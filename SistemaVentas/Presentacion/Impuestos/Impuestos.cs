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

namespace SistemaVentas.Presentacion.Impuestos
{
    public partial class Impuestos : Form
    {
        public Impuestos()
        {
            InitializeComponent();
        }
        int idImpuesto;
        string estado;
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

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panelRegistros.Visible = false;
            
        }

     

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            TextBox[] array = { txtnombre, txtImpuesto};
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
            LImpuesto parametros = new LImpuesto();
            Insertar_datos funcion = new Insertar_datos();

            parametros.nombre = txtnombre.Text;
            parametros.impuesto = Convert.ToDouble(txtImpuesto.Text);
            parametros.Tipo = txtTipo.Text;

            if (funcion.insertarImpuesto(parametros) == true)
            {
                mostrar();
            }

        }

        
        private void rellenarCamposVacios()
        {
            if (string.IsNullOrEmpty(txtnombre.Text))
            { txtnombre.Text = "-"; };
            if (string.IsNullOrEmpty(txtnombre.Text)) { txtnombre.Text = "-"; };
            if (string.IsNullOrEmpty(txtTipo.Text)) { txtTipo.Text = "-"; };
            if (string.IsNullOrEmpty(txtImpuesto.Text)) { txtImpuesto.Text = "-"; };
        }

        private void mostrar()
        {
            DataTable dt = new DataTable();
            Obtener_datos.mostrarImpuestos(ref dt);
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
            if (e.ColumnIndex == datalistado.Columns["Editar"].Index)
            {
                obtenerDatos();
            }
            if (e.ColumnIndex == datalistado.Columns["Eliminar"].Index)
            {
                obtenerId_estado();
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
                idImpuesto1 = idImpuesto;
                txtnombre.Text = datalistado.SelectedCells[3].Value.ToString();
                txtImpuesto.Text = datalistado.SelectedCells[4].Value.ToString();
               
                estado = datalistado.SelectedCells[5].Value.ToString();
                if (estado == "ELIMINADO")
                {
                    DialogResult result = MessageBox.Show("Este Impuesto se Elimino. ¿Desea Volver a Habilitarlo?", "Restaurando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        prepararEdicion();
                    }
                }
                else
                {
                    prepararEdicion();
                }
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
            TextBox[] array = { txtnombre, txtImpuesto };
            if (Insertar_datos.ValidTextIsNotNullOrEmpty(array))
            {
                obtenerId_estado();
                rellenarCamposVacios();
                editar();
            }
            else
            {
                MessageBox.Show("Seleccione una del Empleado", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        int idImpuesto1;
        private void obtenerDatosID()
        {
            try
            {
                idImpuesto1 = Convert.ToInt32(datalistado.SelectedCells[2].Value);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        public void editar()
        {
            obtenerDatosID();
            editarImpuesto();
        }
        public void editarImpuesto()
        {
            LImpuesto parametrosEmpleado = new LImpuesto();
            Editar_datos funcion = new Editar_datos();

            if (funcion.editarImpuestos(parametrosEmpleado) == true)
            {
                mostrar();
            }
        }

        private void eliminar()
        {
            LImpuesto parametros = new LImpuesto();
            parametros.idImpuesto = idImpuesto;
            Eliminar_datos.eliminarEmpleado(idImpuesto);
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
            txtnombre.Focus();
            panelRegistros.Dock = DockStyle.Fill;
        }
        
        private void limpiar()
        {
            txtnombre.Clear();
            txtImpuesto.Clear();
            txtbuscar.Clear();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
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

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
     
        private void tiempoBuscador_Tick(object sender, EventArgs e)
        {
        }

      
      
    }

}
