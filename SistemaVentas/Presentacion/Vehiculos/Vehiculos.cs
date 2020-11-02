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

namespace SistemaVentas.Presentacion.Vehiculos
{
    public partial class Vehiculos : Form
    {
        public Vehiculos()
        {
            InitializeComponent();
        }
        int idVehiculo;
        int idTipoVehiculo;
        int idTipoVehiculoEditar;
        string estado;

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Nuevo();
            panelRegistros.Visible = true;
        }

        private void EmpleadosOK_Load(object sender, EventArgs e)
        {
            btnNuevoGrupo.Visible = true;
            BtnCancelar.Visible = false;
            btnGuardar_grupo.Visible = false;
            linealbl.Visible = false;
            lblcapacidad.Visible = false;
            txtCarga.Visible = false;
            PanelTipoVehiculo.Visible = false;
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
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            if(ICONO.Image != null)
            {
                if (txtPlaca.Text != "" && txtPlaca.Text.Length == 7)
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
                            MessageBox.Show("Elija un Color correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Elija una Transmision correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {
                    MessageBox.Show("Digite una placa correctamente de 7 digitos " + "con el formato:\nTipo: S-U-J-L XXXXXXX" , "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                MessageBox.Show("Seleccione una foto del vehiculo", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void insertar()
        {
            if(idTipoVehiculo != 0)
            {
                LVehiculos parametros = new LVehiculos();
                Insertar_datos funcion = new Insertar_datos();
                parametros.idTipoVehiculo = idTipoVehiculo;
                parametros.NPlaca = txtPlaca.Text;
                parametros.Transmision = txtTransmision.Text;
                parametros.Color = txtColor.Text;
                parametros.Marca = txtMarca.Text;
                parametros.Modelo = txtModelo.Text;
                parametros.Ano = Convert.ToInt32(txtAno.Value);
                parametros.Carga = txtCarga.Text;
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                ICONO.Image.Save(ms, ICONO.Image.RawFormat);

                parametros.icono = ms.GetBuffer();


                if (funcion.InsertarVehiculos(parametros) == true)
                {
                    mostrar();
                }
            }
            else
            {
                MessageBox.Show("Clickea correctamente dentro de un Tipo de Vehiculo", "Registro de Vehiculos", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            datalistado.Columns[3].Visible = false;
            datalistado.Columns[12].Visible = false;

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
        
        public void editarVehiculos()
        {
            if (idTipoVehiculo != 0)
            {
                LVehiculos parametros = new LVehiculos();
                Editar_datos funcion = new Editar_datos();
                parametros.idVehiculo = idVehiculo;
                parametros.idTipoVehiculo = idTipoVehiculo;
                parametros.NPlaca = txtPlaca.Text;
                parametros.Transmision = txtTransmision.Text;
                parametros.Color = txtColor.Text;
                parametros.Marca = txtMarca.Text;
                parametros.Modelo = txtModelo.Text;
                parametros.Ano = Convert.ToInt32(txtAno.Value);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                ICONO.Image.Save(ms, ICONO.Image.RawFormat);
                parametros.icono = ms.GetBuffer();
                if (funcion.editarVehiculos(parametros) == true)
                {
                    mostrar();
                }
            }
            else
            {
                MessageBox.Show("Clickea correctamente dentro de un tipo de vehiculo", "Registro de Vehiculos", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            if (ICONO.Image != null)
            {
                if (txtPlaca.Text != "" && txtPlaca.Text.Length == 7)
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
                                    editarVehiculos();
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
                            MessageBox.Show("Elija un Color correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Elija una Transmision correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {
                    MessageBox.Show("Digite una placa correctamente de 7 digitos " + "con el formato:\nTipo: S-U-J-L XXXXXXX", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                MessageBox.Show("Seleccione una foto del vehiculo", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                estado = datalistado.SelectedCells[13].Value.ToString();

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
                idTipoVehiculo = Convert.ToInt32(datalistado.SelectedCells[3].Value);
                txtTipoVehiculo.Text = datalistado.SelectedCells[4].Value.ToString();
                txtPlaca.Text = datalistado.SelectedCells[5].Value.ToString();
                txtTransmision.Text = datalistado.SelectedCells[6].Value.ToString();
                txtColor.Text = datalistado.SelectedCells[7].Value.ToString();
                txtMarca.Text = datalistado.SelectedCells[8].Value.ToString();
                txtModelo.Text = datalistado.SelectedCells[9].Value.ToString();
                txtAno.Text = datalistado.SelectedCells[10].Value.ToString();
                txtCarga.Text = datalistado.SelectedCells[11].Value.ToString();
                ICONO.BackgroundImage = null;
                byte[] b = (Byte[])datalistado.SelectedCells[12].Value;
                MemoryStream ms = new MemoryStream(b);
                ICONO.Image = Image.FromStream(ms);
                LblAnuncioIcono.Visible = false;

                estado = datalistado.SelectedCells[13].Value.ToString();
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

        private void buscarTipoVehiculo()
        {
            DataTable dt = new DataTable();
            Obtener_datos.buscarTipoTelefono(ref dt,txtTipoVehiculo.Text);
            datalistadoTipoVehiculo.DataSource = dt;
            Bases.Multilinea1( ref datalistadoTipoVehiculo);
            datalistadoTipoVehiculo.Columns[1].Visible = false;
            datalistadoTipoVehiculo.Columns[2].Visible = false;

        }

        private void txtTipoVehiculo_TextChanged(object sender, EventArgs e)
        {
            if(txtTipoVehiculo.Text != "")
            {
                linealbl.Visible = true;
                lblcapacidad.Visible = true;
                txtCarga.Visible = true;
                PanelTipoVehiculo.Visible = true;
                MenuStrip9.Visible = true;
                datalistadoTipoVehiculo.Visible = true;
                buscarTipoVehiculo();
                btnGuardar_grupo.Visible = true;
            }
            else
            {
                linealbl.Visible = false;
                               PanelTipoVehiculo.Visible = true;
                lblcapacidad.Visible = false;
                txtCarga.Visible = false;
                MenuStrip9.Visible = false;
                datalistadoTipoVehiculo.Visible = false;
                btnGuardar_grupo.Visible = false;

            }
        }

        private void btnGuardar_grupo_Click(object sender, EventArgs e)
        {
            if(txtTipoVehiculo.Text != "")
            {
                if (txtCarga.Text != "")
                {
                    try
                    {
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd = new SqlCommand("insertarTipoVehiculo", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TipoVehiculo", txtTipoVehiculo.Text);
                        cmd.Parameters.AddWithValue("@capacidad", txtCarga.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        buscarTipoVehiculo();

                        idTipoVehiculo = Convert.ToInt32(datalistadoTipoVehiculo.SelectedCells[2].Value);
                        txtTipoVehiculo.Text = datalistadoTipoVehiculo.SelectedCells[3].Value.ToString();
                        txtCarga.Text = datalistadoTipoVehiculo.SelectedCells[4].Value.ToString();
                        PanelTipoVehiculo.Visible = true;
                        btnGuardar_grupo.Visible = false;
                        BtnCancelar.Visible = false;
                        btnNuevoGrupo.Visible = true;
                        txtCarga.Visible = true;
                        lblcapacidad.Visible = true;
                        linealbl.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }
                else
                {
                    MessageBox.Show("Digite la carga del Vehiculo correctamente", "Tipos de Vehiculos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Digite el Tipo de Vehiculo correctamente", "Tipos de Vehiculos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            PanelTipoVehiculo.Visible = false;
            btnGuardar_grupo.Visible = false;
            BtnCancelar.Visible = false;
            btnNuevoGrupo.Visible = true;
            txtTipoVehiculo.Clear();
            txtCarga.Clear();
            txtCarga.Clear();
            buscarTipoVehiculo();
            txtCarga.Visible = false;
            lblcapacidad.Visible = false;
            linealbl.Visible = false;
        }

        private void datalistadoTipoVehiculo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void datalistadoTipoVehiculo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idTipoVehiculoEditar = Convert.ToInt32(datalistadoTipoVehiculo.SelectedCells[2].Value.ToString());
            if (e.ColumnIndex == this.datalistadoTipoVehiculo.Columns["EliminarG"].Index)
            {
                lblidtipovehiculo.Text = datalistadoTipoVehiculo.SelectedCells[2].Value.ToString();
                idTipoVehiculo = Convert.ToInt32(datalistadoTipoVehiculo.SelectedCells[2].Value.ToString());
                idTipoVehiculoEditar = Convert.ToInt32(datalistadoTipoVehiculo.SelectedCells[2].Value.ToString());
                DialogResult result;
                result = MessageBox.Show("¿Realmente desea eliminar este Tipo de Vehiculo?", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    SqlCommand cmd;
                    try
                    {
                        foreach (DataGridViewRow row in datalistadoTipoVehiculo.SelectedRows)
                        {

                            int onekey = Convert.ToInt32(lblidtipovehiculo.Text);

                            try
                            {
                                try
                                {
                                    SqlConnection con = new SqlConnection();
                                    con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                                    con.Open();
                                    cmd = new SqlCommand("eliminartipovehiculo", con);
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@id", onekey);
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
                                catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
                                {
                                }
                            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
                            catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
                            {
                            }
                        }
                        txtTipoVehiculo.Text = "DIGITA EL TIPO DE VEHICULO";
                        txtTipoVehiculo.SelectAll();
                        txtTipoVehiculo.Focus();
                        buscarTipoVehiculo();
                        lblidtipovehiculo.Text = datalistadoTipoVehiculo.SelectedCells[2].Value.ToString();
                        idTipoVehiculo = Convert.ToInt32(datalistadoTipoVehiculo.SelectedCells[2].Value.ToString());
                    }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
                    catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
                    {
                    }
                }
            }

            if (e.ColumnIndex == this.datalistadoTipoVehiculo.Columns["EditarG"].Index)

            {
                lblidtipovehiculo.Text = datalistadoTipoVehiculo.SelectedCells[2].Value.ToString();
                idTipoVehiculo = Convert.ToInt32(datalistadoTipoVehiculo.SelectedCells[2].Value.ToString());
                idTipoVehiculoEditar = Convert.ToInt32(datalistadoTipoVehiculo.SelectedCells[2].Value.ToString());
                txtTipoVehiculo.Text = datalistadoTipoVehiculo.SelectedCells[3].Value.ToString();
                PanelTipoVehiculo.Visible = false;
                btnGuardar_grupo.Visible = false;
                BtnCancelar.Visible = true;
                btnNuevoGrupo.Visible = false;
            }
            if (e.ColumnIndex == this.datalistadoTipoVehiculo.Columns["descripcion"].Index)
            {
                lblidtipovehiculo.Text = datalistadoTipoVehiculo.SelectedCells[2].Value.ToString();
                idTipoVehiculo = Convert.ToInt32(datalistadoTipoVehiculo.SelectedCells[2].Value.ToString());
                txtTipoVehiculo.Text = datalistadoTipoVehiculo.SelectedCells[3].Value.ToString();
                txtCarga.Text = datalistadoTipoVehiculo.SelectedCells[4].Value.ToString();
                PanelTipoVehiculo.Visible = false;
                btnGuardar_grupo.Visible = false;
                BtnCancelar.Visible = false;
                btnNuevoGrupo.Visible = true;
            }
        }

        private void btnNuevoGrupo_Click(object sender, EventArgs e)
        {
            txtTipoVehiculo.SelectAll();
            txtTipoVehiculo.Focus();
            PanelTipoVehiculo.Visible = false;
            btnGuardar_grupo.Visible = true;
            BtnCancelar.Visible = true;
            btnNuevoGrupo.Visible = false;
            txtCarga.Visible = true;
            lblcapacidad.Visible = true;
            linealbl.Visible = true;
        }

        private void txtPlaca_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
