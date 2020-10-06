using SistemaVentas.Datos;
using SistemaVentas.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaVentas.Presentacion.Vehiculos
{
    public partial class Vehiculos : Form
    {
        public Vehiculos()
        {
            InitializeComponent();
        }
        int idVehiculo;
        string estado;

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Nuevo();
            panelRegistros.Visible = true;
        }

        private void EmpleadosOK_Load(object sender, EventArgs e)
        {
            txtbuscar.Focus();
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
            dlg.InitialDirectory = "";
            dlg.Filter = "Imagenes|*.jpg;*.png";
            dlg.FilterIndex = 2;
            dlg.Title = "";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ICONO.BackgroundImage = null;
                ICONO.Image = new Bitmap(dlg.FileName);
                ICONO.SizeMode = PictureBoxSizeMode.Zoom;
                lblnumeroIcono.Text = Path.GetFileName(dlg.FileName);
                Console.WriteLine(lblnumeroIcono.Text);
                LblAnuncioIcono.Visible = false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtPlaca.Text != "")
            {
                if (txtTransmision.Text != "")
                {
                    if (txtColor.Text != "")
                    {
                        if (txtMarca.Text != "")
                        {
                            if (txtModelo.Text != "")
                            {
                                rellenarCamposVacios();
                                insertar();
                            }
                            else
                            {
                                MessageBox.Show("Elija un Modelo correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }
                        else
                        {
                            MessageBox.Show("Elija una Marca correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Elija un color correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {
                    MessageBox.Show("Elija una Transmision correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                MessageBox.Show("Digite una placa correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }
        private void insertar()
        {
            LVehiculos parametros = new LVehiculos();
            Insertar_datos funcion = new Insertar_datos();
            parametros.NPlaca = txtPlaca.Text;
            parametros.Transmision = txtTransmision.Text;
            parametros.Color = txtColor.Text;
            parametros.Marca = txtMarca.Text;
            parametros.Modelo = txtModelo.Text;
            parametros.Ano = Convert.ToInt32(txtAno.Value);

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            ICONO.Image.Save(ms, ICONO.Image.RawFormat);

            parametros.icono = ms.GetBuffer();


            if (funcion.InsertarVehiculos(parametros) == true)
            {
                mostrar();
            }

        }

        private void rellenarCamposVacios()
        {
            if (string.IsNullOrEmpty(txtPlaca.Text))
            { txtPlaca.Text = "-"; };
            if (string.IsNullOrEmpty(txtMarca.Text)) { txtMarca.Text = "-"; };
            if (string.IsNullOrEmpty(txtModelo.Text)) { txtModelo.Text = "-"; };
            if (string.IsNullOrEmpty(txtPlaca.Text)) { txtPlaca.Text = "-"; };
            if (string.IsNullOrEmpty(txtTransmision.Text)) { txtTransmision.Text = "-"; };
            if (string.IsNullOrEmpty(txtColor.Text)) { txtColor.Text = "-"; };
        }

        private void mostrar()
        {
            DataTable dt = new DataTable();
            Obtener_datos.mostrarVehiculos(ref dt);
            datalistado.DataSource = dt;
            panelRegistros.Visible = false;
            pintarDatalistado();
        }
        private void pintarDatalistado()
        {
            Bases.Multilinea1(ref datalistado);
            datalistado.Columns[2].Visible = false;
            datalistado.Columns[9].Visible = false;
            datalistado.Columns[10].Visible = false;
            foreach (DataGridViewRow row in datalistado.Rows)
            {
                string estado = Convert.ToString(row.Cells["Estado"].Value);
                if (estado == "ELIMINADO")
                {
                    row.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Strikeout | FontStyle.Bold);
                    row.DefaultCellStyle.ForeColor = Color.Red;
                }

            }
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
            buscar();
        }
       
        private void buscar()
        {
            DataTable dt = new DataTable();
            Obtener_datos.BuscarVehiculos(ref dt, txtbuscar.Text);
            datalistado.DataSource = dt;
            pintarDatalistado();
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


        private void restaurar()
        {
            LVehiculos parametros = new LVehiculos();
            Editar_datos funcion = new Editar_datos();
            parametros.idVehiculo = idVehiculo;
            /*
            if (funcion.restaurar_ve(parametros) == true)
            {
                mostrar();
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPlaca.Text != "")
            {
                if (txtTransmision.Text != "")
                {
                    if (txtColor.Text != "")
                    {
                        if (txtMarca.Text != "")
                        {
                            if (txtModelo.Text != "")
                            {
                                obtenerId_estado();
                                rellenarCamposVacios();
                                editar();
                            }
                            else
                            {
                                MessageBox.Show("Elija un Modelo correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }
                        else
                        {
                            MessageBox.Show("Elija una Marca correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Elija un color correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {
                    MessageBox.Show("Elija una Transmision correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                MessageBox.Show("Digite una placa correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        public void editar()
        {
            LVehiculos parametros = new LVehiculos();
            Editar_datos Editar = new Editar_datos();
            parametros.idVehiculo = idVehiculo;
            parametros.NPlaca = txtPlaca.Text;
            parametros.Transmision = txtTransmision.Text;
            parametros.Color = txtColor.Text;
            parametros.Marca = txtMarca.Text;
            parametros.Modelo = txtModelo.Text;
            parametros.Ano = Convert.ToInt32(txtAno.Value);

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            ICONO.Image.Save(ms, ICONO.Image.RawFormat);

            parametros.icono = ms.GetBuffer();
            if (Editar.EditarVehiculo(parametros) == true)
            {
                mostrar();
            }
        }
        
        private void eliminar()
        {
            LVehiculos parametros = new LVehiculos();
            Datos.Editar_datos funcion = new Datos.Editar_datos();
            parametros.idVehiculo = idVehiculo;

            if(funcion.eliminar_vehiculo(parametros) == true)
            {
                mostrar();
            }
        }

        private void obtenerId_estado()
        {
            try
            {
                idVehiculo = Convert.ToInt32(datalistado.SelectedCells[2].Value);
                estado = datalistado.SelectedCells[10].Value.ToString();

            }
            catch (Exception)
            {

            }
        }

        private void datalistado_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Nuevo()
        {
            LblAnuncioIcono.Visible = true;
            panelRegistros.Visible = true;
            limpiar();
            btnGuardar.Visible = true;
            btnGuardarCambios.Visible = false;
            txtPlaca.Focus();
            panelRegistros.Dock = DockStyle.Fill;

        }
        
        private void limpiar()
        {
            txtPlaca.Clear();
            txtMarca.Clear();
            txtTransmision.SelectionStart = 0;
            txtColor.Text = "";
            txtModelo.Clear();
            txtAno.Value = 2020;
        }

        private void datalistado_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == datalistado.Columns["Editar2"].Index)
            {
               limpiar();
               obtenerDatos();
            }
            if (e.ColumnIndex == datalistado.Columns["Eliminar2"].Index)
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void obtenerDatos()
        {
            try
            {
                idVehiculo = Convert.ToInt32(datalistado.SelectedCells[2].Value);
                txtPlaca.Text = datalistado.SelectedCells[3].Value.ToString();
                txtTransmision.Text = datalistado.SelectedCells[4].Value.ToString();
                txtColor.Text = datalistado.SelectedCells[5].Value.ToString();
                txtMarca.Text = datalistado.SelectedCells[6].Value.ToString();
                txtModelo.Text = datalistado.SelectedCells[7].Value.ToString();
                txtAno.Text = datalistado.SelectedCells[8].Value.ToString();
                ICONO.BackgroundImage = null;
                byte[] b = (Byte[])datalistado.SelectedCells[9].Value;
                MemoryStream ms = new MemoryStream(b);
                ICONO.Image = Image.FromStream(ms);
                LblAnuncioIcono.Visible = false;

                estado = datalistado.SelectedCells[10].Value.ToString();
                if (estado == "ELIMINADO")
                {
                    DialogResult result = MessageBox.Show("Este Vehiculo se Elimino. ¿Desea Volver a Habilitarlo?", "Restaurando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        restaurar();
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
                MessageBox.Show(ex.StackTrace);
            }
        }
    }
}
