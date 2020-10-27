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

namespace SistemaVentas.Presentacion.Direccion
{
    public partial class Direcciones : Form
    {
        public Direcciones()
        {
            InitializeComponent();
        }
        int idDireccion;
        string estado;
        int idRegion, idMunicipio, idSector, idProvincia, idCalle;

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

        private void LblAnuncioIcono_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
                if(txtDescripcion.Text != "")
                {
                    if(txtCalle.Text != "")
                    {
                        if(txtMunicipio.Text != "")
                        {
                            if(txtRegion.Text != "")
                            {
                                if (txtSector.Text != "")
                                {
                                        rellenarCamposVacios();
                                        insertar();
                                }
                                else
                                {

                                    MessageBox.Show("Escribe un Sector correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                }
                            }
                            else
                            {
                                MessageBox.Show("Escribe una Region correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }
                        else
                        {
                            MessageBox.Show("Escribe un Municipio de banco correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Escribe una Calle correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {
                    MessageBox.Show("Escribe una descripcion correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

        }
        private void insertar()
        {
            LDireccion direccion = new LDireccion();
            Insertar_datos funcion = new Insertar_datos();

            direccion.desDireccion = txtDescripcion.Text;
            direccion.Provincia = txtProvincia.Text;
            direccion.Region = txtRegion.Text;
            direccion.Municipio = txtMunicipio.Text;
            direccion.Sector = txtSector.Text;
            direccion.Calle = txtCalle.Text;

            if (funcion.insertarCalle(direccion) == true && funcion.insertarProvincia(direccion) == true && funcion.insertarSector(direccion) == true && funcion.insertarMunicipio(direccion) == true
                && funcion.insertarRegion(direccion) == true)
            {
                obtenerParametros();
                if (funcion.insertarDireccion(direccion, idRegion, idMunicipio, idSector, idCalle, idProvincia) == true)
                {
                    mostrar();
                }
            }

        }

        public void obtenerParametros()
        {
            idRegion = Obtener_datos.ObtenerRegion(); 
            idMunicipio = Obtener_datos.ObtenerMunicipio(); 
            idSector = Obtener_datos.ObtenerSector(); 
            idProvincia = Obtener_datos.ObtenerProvincia(); 
            idCalle = Obtener_datos.ObtenerCalle();
        }

        private void rellenarCamposVacios()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            { txtDescripcion.Text = "-"; };
            if (string.IsNullOrEmpty(txtCalle.Text)) { txtCalle.Text = "-"; };
            if (string.IsNullOrEmpty(txtSector.Text)) { txtSector.Text = "-"; };
            if (string.IsNullOrEmpty(txtMunicipio.Text)) { txtMunicipio.Text = "-"; };
            if (string.IsNullOrEmpty(txtRegion.Text)) { txtRegion.Text = "-"; };
        }

        private void mostrar()
        {
            DataTable dt = new DataTable();
            Obtener_datos.ObtenerDireccion(ref dt);
            datalistado.DataSource = dt;
            panelRegistros.Visible = false;
            pintarDatalistado();
        }
        private void pintarDatalistado()
        {
            Bases.Multilinea(ref datalistado);
            datalistado.Columns[1].Visible = false;
            datalistado.Columns[3].Visible = false;
            datalistado.Columns[5].Visible = false;
            datalistado.Columns[7].Visible = false;
            datalistado.Columns[9].Visible = false;
            datalistado.Columns[11].Visible = false;
        }

        private void datalistado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == datalistado.Columns["EditarG"].Index)
            {
                obtenerDatos();
            }
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            buscar();
        }

        private void buscar()
        {
            DataTable dt = new DataTable();
            Obtener_datos.buscar_empleados(ref dt, txtbuscar.Text);
            datalistado.DataSource = dt;
            pintarDatalistado();
        }
        
        private void obtenerDatos()
        {
            try
            {
                idDireccion = Convert.ToInt32(datalistado.SelectedCells[1].Value);
                txtDescripcion.Text = datalistado.SelectedCells[2].Value.ToString();
                txtRegion.Text = datalistado.SelectedCells[4].Value.ToString();
                txtMunicipio.Text = datalistado.SelectedCells[6].Value.ToString();
                txtSector.Text = datalistado.SelectedCells[8].Value.ToString();
                txtProvincia.Text = datalistado.SelectedCells[10].Value.ToString();
                txtCalle.Text = datalistado.SelectedCells[12].Value.ToString();

                prepararEdicion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
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
            if (txtDescripcion.Text != "")
            {
                if (txtCalle.Text != "")
                {
                    if (txtMunicipio.Text != "")
                    {
                        if (txtRegion.Text != "")
                        {
                            if (txtSector.Text != "")
                            {
                                rellenarCamposVacios();
                                editar();
                            }
                            else
                            {

                                MessageBox.Show("Escribe un Sector correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }
                        else
                        {
                            MessageBox.Show("Escribe una Region correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Escribe un Municipio de banco correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {
                    MessageBox.Show("Escribe una Calle correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                MessageBox.Show("Escribe una descripcion correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }
        int idDireccion1;
        int idRegion1;
        int idMunicipio1;
        int idSector1;
        int idProvincia1;
        int idCalle1;
        private void obtenerDatosID()
        {
            try
            {
                idDireccion1 = Convert.ToInt32(datalistado.SelectedCells[1].Value);
                idRegion1 = Convert.ToInt32(datalistado.SelectedCells[3].Value);
                idMunicipio1 = Convert.ToInt32(datalistado.SelectedCells[5].Value);
                idSector1 = Convert.ToInt32(datalistado.SelectedCells[7].Value);
                idProvincia1= Convert.ToInt32(datalistado.SelectedCells[9].Value);
                idCalle1 = Convert.ToInt32(datalistado.SelectedCells[11].Value);
                prepararEdicion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public void editar()
        {
            obtenerDatosID();
            LDireccion direccion = new LDireccion();
            Editar_datos funcion = new Editar_datos();
            direccion.desDireccion = txtDescripcion.Text;
            direccion.Provincia = txtProvincia.Text;
            direccion.Region = txtRegion.Text;
            direccion.Municipio = txtMunicipio.Text;
            direccion.Sector = txtSector.Text;
            direccion.Calle = txtCalle.Text;

            if (funcion.editarCalle(direccion,idCalle1) == true && funcion.editarProvincia(direccion,idProvincia1) == true && funcion.editarSector(direccion,idSector1) == true && funcion.editarMunicipio(direccion,idMunicipio1) == true
                && funcion.editarRegion(direccion,idRegion1) == true)
            {
                obtenerParametros();
                if (funcion.editarDireccion(direccion, idDireccion1) == true)
                {
                    mostrar();
                }
            }

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
            //txtnombre.Focus();
            panelRegistros.Dock = DockStyle.Fill;

        }
        
        private void limpiar()
        {
            txtbuscar.Clear();
            txtSector.Clear();
            txtRegion.Clear();
            txtMunicipio.Clear();
            txtCalle.Clear();
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

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFecha_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtBanco_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblId_empleado_Click(object sender, EventArgs e)
        {

        }

        private void lblnumeroIcono_Click(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void ICONO_Click(object sender, EventArgs e)
        {

        }

        private void txtDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtCuentaBanco_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void panelNuevo_Paint(object sender, PaintEventArgs e)
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

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txtAno_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox2_Click_1(object sender, EventArgs e)
        {
            Nuevo();
            panelRegistros.Visible = true;
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }



    }

    }
