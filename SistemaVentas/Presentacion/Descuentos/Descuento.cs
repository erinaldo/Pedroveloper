﻿using SistemaVentas.Datos;
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

namespace SistemaVentas.Presentacion.Descuento
{
    public partial class Descuento : Form
    {
        public Descuento()
        {
            InitializeComponent();
        }
        int idDescuento;
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
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panelRegistros.Visible = false;
            
        }

     

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            TextBox[] array = { txtnombre, txtDescuento};
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
          insertarDescuento();
        }

        public void insertarDescuento()
        {
            LDescuento parametros = new LDescuento();
            Insertar_datos funcion = new Insertar_datos();

            parametros.nombre = txtnombre.Text;
            parametros.descuento = txtDescuento.Text;
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
            if (string.IsNullOrEmpty(txtDescuento.Text)) { txtDescuento.Text = "-"; };
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

        /*if (e.ColumnIndex == datalistado.Columns["EditarImpuestoG"].Index)
            {
                obtenerDatos();
            }
            if (e.ColumnIndex == datalistado.Columns["EliminarImpuesto"].Index)
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
            }*/
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
                idDescuento = Convert.ToInt32(datalistado.SelectedCells[2].Value);
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
                idDescuento = Convert.ToInt32(datalistado.SelectedCells[2].Value);
                txtnombre.Text = datalistado.SelectedCells[3].Value.ToString();
                txtDescuento.Text = datalistado.SelectedCells[4].Value.ToString();
                txtTipo.Text= datalistado.SelectedCells[5].Value.ToString();
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
            TextBox[] array = { txtnombre, txtDescuento };
           
            if (Insertar_datos.ValidTextIsNotNullOrEmpty(array))
            {
                if (txtTipo.Text != "")
                {
                    obtenerId_estado();
                    rellenarCamposVacios();
                    editar();
                }
                else
                {
                    MessageBox.Show("Seleccione un Tipo de Impuesto", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
              
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
            LDescuento parametros = new LDescuento();
            Editar_datos funcion = new Editar_datos();

            double porciento = calcularPorciento();
            parametros.idDescuento = idDescuento;
            parametros.nombre = txtnombre.Text;
            parametros.impuesto = porciento;
            parametros.Tipo = txtTipo.Text;

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
            Eliminar_datos.eliminarDescuento(idDescuento);
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
            txtDescuento.Clear();
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
            porciento = Convert.ToDouble(txtDescuento.Text);
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

                idDescuento =  Convert.ToInt32(datalistado.SelectedCells[2].Value);
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
    }

}
