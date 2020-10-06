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

namespace SistemaVentas.Presentacion.Empleados
{
    public partial class EmpleadosOK : Form
    {
        public EmpleadosOK()
        {
            InitializeComponent();
        }
        int idEmpleado;
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
            if(Datos.Obtener_datos.validar_Mail(txtCorreo.Text) == false)
            {
                MessageBox.Show("Dirección de correo electronico no valida, el correo debe tener el formato: nombre@dominio.com, " + " por favor seleccione un correo valido", "Validación de correo electronico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCorreo.Focus();
                txtCorreo.SelectAll();
            }
            else
            {
                if(txtnombre.Text != "")
                {
                    if(txtCedula.Text != "")
                    {
                        if(txtCuentaBanco.Text != "")
                        {
                            if(txtDepartamento.Text != "")
                            {
                                if(txtBanco.Text != "")
                                {
                                    rellenarCamposVacios();
                                    insertar();
                                }
                                else
                                {
                                    MessageBox.Show("Elija un banco correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                }
                            }
                            else
                            {
                                MessageBox.Show("Elija un departamento correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }
                        else
                        {
                            MessageBox.Show("Elija una cuenta de banco correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Elija una cedula correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {
                    MessageBox.Show("Elija un nombre correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }

        }
        private void insertar()
        {
            LEmpleados parametros = new LEmpleados();
            Insertar_datos funcion = new Insertar_datos();
            parametros.nombre = txtnombre.Text;
            parametros.cedula = txtCedula.Text;
            parametros.correoElectronico = txtCorreo.Text;
            parametros.cuentaBanco = txtCuentaBanco.Text;
            parametros.fechaNacimiento = txtFecha.Value;
            parametros.departamento = txtDepartamento.Text;
            parametros.banco = txtBanco.Text;
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            ICONO.Image.Save(ms, ICONO.Image.RawFormat);

            parametros.icono = ms.GetBuffer();
            

            if (funcion.insertarEmpleado(parametros) == true)
            {
                mostrar();
            }

        }

        private void rellenarCamposVacios()
        {
            if (string.IsNullOrEmpty(txtnombre.Text))
            { txtnombre.Text = "-"; };
            if (string.IsNullOrEmpty(txtCuentaBanco.Text)) { txtCuentaBanco.Text = "-"; };
            if (string.IsNullOrEmpty(txtCedula.Text)) { txtCedula.Text = "-"; };
            if (string.IsNullOrEmpty(txtCorreo.Text)) { txtCorreo.Text = "-"; };
            //if (string.IsNullOrEmpty(txtDepartamento.Text)) { txtDepartamento.Text = "-"; };
            //if (string.IsNullOrEmpty(txtFecha.Text)) { txtFecha.Text = "-"; };
            if (string.IsNullOrEmpty(txtBanco.Text)) { txtBanco.Text = "-"; };
        }

        private void mostrar()
        {
            DataTable dt = new DataTable();
            Obtener_datos.mostrar_Empleados(ref dt);
            datalistado.DataSource = dt;
            panelRegistros.Visible = false;
            pintarDatalistado();
        }
        private void pintarDatalistado()
        {
            Bases.Multilinea(ref datalistado);
            datalistado.Columns[2].Visible = false;
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
            Obtener_datos.buscar_empleados(ref dt, txtbuscar.Text);
            datalistado.DataSource = dt;
            pintarDatalistado();
        }
        private void obtenerId_estado()
        {
            try
            {
                idEmpleado = Convert.ToInt32(datalistado.SelectedCells[2].Value);
                estado = datalistado.SelectedCells[11].Value.ToString();

            }
            catch (Exception)
            {

            }
        }
        private void obtenerDatos()
        {
            try
            {
                idEmpleado = Convert.ToInt32(datalistado.SelectedCells[2].Value);
                txtnombre.Text = datalistado.SelectedCells[3].Value.ToString();
                txtCedula.Text = datalistado.SelectedCells[4].Value.ToString();
                txtCorreo.Text = datalistado.SelectedCells[5].Value.ToString();
                txtCuentaBanco.Text = datalistado.SelectedCells[6].Value.ToString();
                txtFecha.Value = Convert.ToDateTime(datalistado.SelectedCells[7].Value);
                txtDepartamento.Text = datalistado.SelectedCells[8].Value.ToString();
                txtBanco.Text = datalistado.SelectedCells[9].Value.ToString();
                ICONO.BackgroundImage = null;
                byte[] b = (Byte[])datalistado.SelectedCells[10].Value;
                MemoryStream ms = new MemoryStream(b);
                ICONO.Image = Image.FromStream(ms);
                LblAnuncioIcono.Visible = false;
                estado = datalistado.SelectedCells[11].Value.ToString();
                if (estado == "ELIMINADO")
                {
                    DialogResult result = MessageBox.Show("Este Empleado se Elimino. ¿Desea Volver a Habilitarlo?", "Restaurando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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
            LEmpleados parametros = new LEmpleados();
            Editar_datos funcion = new Editar_datos();
            parametros.idEmpleado = idEmpleado;
            if(funcion.restaurar_empleados(parametros) == true)
            {
                mostrar();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Datos.Obtener_datos.validar_Mail(txtCorreo.Text) == false)
            {
                MessageBox.Show("Dirección de correo electronico no valida, el correo debe tener el formato: nombre@dominio.com, " + " por favor seleccione un correo valido", "Validación de correo electronico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCorreo.Focus();
                txtCorreo.SelectAll();
            }
            else
            {
                if (txtnombre.Text != "")
                {
                    if (txtCedula.Text != "")
                    {
                        if (txtCuentaBanco.Text != "")
                        {
                            if (txtDepartamento.Text != "")
                            {
                                if (txtBanco.Text != "")
                                {
                                    obtenerId_estado();
                                    rellenarCamposVacios();
                                    editar();
                                }
                                else
                                {
                                    MessageBox.Show("Elija un banco correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                }
                            }
                            else
                            {
                                MessageBox.Show("Elija un departamento correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }
                        else
                        {
                            MessageBox.Show("Elija una cuenta de banco correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Elija una cedula correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {
                    MessageBox.Show("Elija un nombre correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }

        }

        public void editar()
        {
            LEmpleados parametros = new LEmpleados();
            Editar_datos Editar = new Editar_datos();
            parametros.idEmpleado = idEmpleado;
            parametros.nombre = txtnombre.Text;
            parametros.cedula = txtCedula.Text;
            parametros.correoElectronico = txtCorreo.Text;
            parametros.cuentaBanco = txtCuentaBanco.Text;
            parametros.fechaNacimiento = txtFecha.Value;
            parametros.departamento = txtDepartamento.Text;
            parametros.banco = txtBanco.Text;
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            ICONO.Image.Save(ms, ICONO.Image.RawFormat);

            parametros.icono = ms.GetBuffer();
            if (Editar.EditarEmpleado(parametros) == true)
            {
                mostrar();
            }
        }
        
        private void eliminar()
        {
            LEmpleados parametros = new LEmpleados();
            Editar_datos funcion = new Editar_datos();
            parametros.idEmpleado = idEmpleado;
            if(funcion.eliminar_empleados(parametros) == true)
            {
                mostrar();
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
            txtnombre.Focus();
            panelRegistros.Dock = DockStyle.Fill;

        }
        
        private void limpiar()
        {
            txtnombre.Clear();
            txtCedula.Clear();
            txtCorreo.Clear();
            txtCuentaBanco.Clear();
            txtDepartamento.Text = "";
            txtBanco.Text = "";
        }
        
    }
}
