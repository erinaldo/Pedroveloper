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

namespace SistemaVentas.Presentacion.Empleados
{
    public partial class EmpleadosOK : Form
    {
        public EmpleadosOK()
        {
            InitializeComponent();
        }
        int idTipoTelefonoEditar;
        int idDireccionEditar;
        int idEmpleado;
        string estado;
        int idDireccion;
        int idDocumento;
        int idTelefono;
        int idTipoHorario, idHorario;
        int idTipoTelefono;
        int idPersona;
        private void PictureBox2_Click(object sender, EventArgs e)
        {
            mostrarTipos();
            Nuevo();
            panelRegistros.Visible = true;
        }

        private void EmpleadosOK_Load(object sender, EventArgs e)
        {
            panelDataListadoDireccion.Visible = false;
            panelRegistros.Visible = false;
            mostrar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int num;
            SqlConnection con = new SqlConnection();
            con.Open();
            con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
            SqlCommand com = new SqlCommand("SELECT COUNT(idUsuario) from USUARIO2", con);
            num = Convert.ToInt32(com.ExecuteScalar());
            con.Close();
            try
            {
                if (num == 0)
                {
                    Presentacion.ASISTENTE_DE_INSTALACION_servidor.USUARIOS_AUTORIZADOS_AL_SISTEMA frm = new Presentacion.ASISTENTE_DE_INSTALACION_servidor.USUARIOS_AUTORIZADOS_AL_SISTEMA();
                }
                else
                {
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            
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
            TextBox[] array = { txtnombre, txtApellido, txtNumeracion, txtTelefono,  txtDireccion, txtCuentaBanco,  txtTipoTelefono};
            if (Insertar_datos.ValidTextIsNotNullOrEmpty(array))
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                if (ICONO.Image != null)
                {
                    if (Datos.Obtener_datos.validar_Mail(txtCorreo.Text) == false)
                    {
                        MessageBox.Show("Dirección de correo electronico no valida, el correo debe tener el formato: nombre@dominio.com, " + " por favor seleccione un correo valido", "Validación de correo electronico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtCorreo.Focus();
                        txtCorreo.SelectAll();
                    }
                    else
                    {
                        if (txtNumeracion.Text.Length == 13)
                        {
                            if (txtCuentaBanco.Text.Length == 9)
                            {
                                if (txtDepartamento.Text != "")
                                {
                                    if (txtBanco.Text != "")
                                    {
                                        if (txtTelefono.Text.Length == 12)
                                        {
                                            if (txtTipoDocumento.Text != "" && txtTipoHorario.Text != "")
                                            {

                                                insertar();
                                                rellenarCamposVacios();

                                            }
                                            else
                                            {
                                                MessageBox.Show("Elija un Tipo de Documento correctamente o el Tipo de Horario", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Telefono no valido, el Telefono debe tener el formato: 809-555-5555, " + " por favor seleccione un telefono valido",
                                                "Validación de Telefono", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Elija un tipo de banco correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Elija un departamento correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Cuenta de banco no valida, la cuenta debe tener el formato: XXXXXXXXX 9 CARACTERES," +
                                    " " + " por favor seleccione una cuenta valida", "Validación de cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Cedula no valida, la cedula debe tener el formato: xxx-xxxxxx-x," +
                                " " + " por favor seleccione una cedula valida", "Validación de cedula", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una foto del Empleado", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void insertar()
        {
            if(idTipoTelefono != 0)
            {
                if(idDireccion != 0)
                {
                    insertarTipoHorario();
                }
                else
                {
                    MessageBox.Show("Clickea sobre una Direccion correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Clickea sobre un Tipo de Telefono correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        public void insertarEmpleado()
        {
            idHorario = Obtener_datos.obtenerHorario();
            LEmpleados parametrosEmpleado = new LEmpleados();
            Insertar_datos funcion = new Insertar_datos();
            idPersona = Obtener_datos.obtenerPersona();
            parametrosEmpleado.idPersona = idPersona;
            parametrosEmpleado.idHorario = idHorario;
            parametrosEmpleado.cuentaBanco = txtCuentaBanco.Text;
            parametrosEmpleado.departamento = txtDepartamento.Text;
            parametrosEmpleado.banco = txtBanco.Text;
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            ICONO.Image.Save(ms, ICONO.Image.RawFormat);
            parametrosEmpleado.icono = ms.GetBuffer();

            if (funcion.insertarEmpleado(parametrosEmpleado) == true)
            {
                mostrar();
            }

        }

        public void insertarPersona()
        {
            
            MessageBox.Show("idTelefono"+ idTelefono.ToString());
            idTelefono = Obtener_datos.obtenerTelefono();
            idDocumento = Obtener_datos.obtenerDocumento();

            LPersona parametrosPersona = new LPersona();
            Insertar_datos funcion = new Insertar_datos();

            parametrosPersona.nombre = txtnombre.Text;
            parametrosPersona.apellido = txtApellido.Text;
            parametrosPersona.correo = txtCorreo.Text;
            parametrosPersona.fechaNacimiento = txtFecha.Value;
            parametrosPersona.idDireccion = idDireccion;
            parametrosPersona.idDocumento = idDocumento;
            parametrosPersona.idTelefono = idTelefono;
            
            if (funcion.insertarPersona(parametrosPersona) == true)
            {
                insertarEmpleado();
            }

        }

        public void insertarTelefono()
        {
            LTelefono parametros = new LTelefono();
            Insertar_datos funcion = new Insertar_datos();

            parametros.Telefono = txtTelefono.Text;
            parametros.TipoTelefono = txtTipoTelefono.Text;

            int idTipoTelefono1 = Obtener_datos.obtenerTipoTelefono();

            if(funcion.insertarTelefono(parametros, idTipoTelefono1) == true){
                insertarDocumento();
            }

        }

        public void insertarTipoTelefono()
        {
            LTelefono parametros = new LTelefono();
            Insertar_datos funcion = new Insertar_datos();

            parametros.Telefono = txtTelefono.Text;
            parametros.TipoTelefono = txtTipoTelefono.Text;

            insertarTelefono();

        }

        public void insertarDocumento()
        {
            LDocumentos parametrosDocumentos = new LDocumentos();
            Insertar_datos funcion = new Insertar_datos();

            parametrosDocumentos.tipo = txtTipoDocumento.Text;
            parametrosDocumentos.numeracion = txtNumeracion.Text;

            if (funcion.InsertarDocumento(parametrosDocumentos) == true){
                insertarPersona();
            }

        }

        public void insertarHorario()
        {
            idTipoHorario = Obtener_datos.obtenerTipoHorarip();
            LHorario parametrosHorario = new LHorario();
            Insertar_datos funcion = new Insertar_datos();

            string hEntrada = Convert.ToString(txtEntrada.Value);
            string hSalida = Convert.ToString(txtSalida.Value);
            parametrosHorario.horaEntrada = hEntrada;
            parametrosHorario.horaSalida = hSalida;

            if (funcion.insertarHorario(parametrosHorario, idTipoHorario) == true){
                insertarTipoTelefono();
            }

        }
        public void insertarTipoHorario()
        {
            LHorario parametrosHorario = new LHorario();
           
            parametrosHorario.Descripcion_TipoHorario = txtTipoHorario.Text;

            if(Insertar_datos.insertarTipoHorario(txtTipoHorario.Text) == true){
                insertarHorario();
            }

        }

        
        private void rellenarCamposVacios()
        {
            if (string.IsNullOrEmpty(txtnombre.Text))
            { txtnombre.Text = "-"; };
            if (string.IsNullOrEmpty(txtCuentaBanco.Text)) { txtCuentaBanco.Text = "-"; };
            if (string.IsNullOrEmpty(txtNumeracion.Text)) { txtNumeracion.Text = "-"; };
            if (string.IsNullOrEmpty(txtCorreo.Text)) { txtCorreo.Text = "-"; };
            if (string.IsNullOrEmpty(txtDireccion.Text)) { txtDireccion.Text = "-"; };
            if (string.IsNullOrEmpty(txtApellido.Text)) { txtApellido.Text = "-"; };
            if (string.IsNullOrEmpty(txtBanco.Text)) { txtBanco.Text = "-"; };
            if (string.IsNullOrEmpty(txtTipoDocumento.Text)) { txtTipoDocumento.Text = "-"; };
        }

        private void mostrar()
        {
            DataTable dt = new DataTable();
            Obtener_datos.mostrar_Empleados(ref dt);
            datalistado.DataSource = dt;
            panelRegistros.Visible = false;
            panelDataListadoDireccion.Visible = true;
            datalistado.Columns[2].Visible = false;
            datalistado.Columns[3].Visible = false;
            datalistado.Columns[4].Visible = false;
            datalistado.Columns[9].Visible = false;

            datalistado.Columns[11].Visible = false;
            datalistado.Columns[14].Visible = false;
            datalistado.Columns[16].Visible = false;
            datalistado.Columns[20].Visible = false;
            datalistado.Columns[25].Visible = false;
            pintarDatalistado();
        }
        private void pintarDatalistado()
        {
            Bases.Multilinea(ref datalistado);
            
        }
        private void pintarDatalistadoDireccion()
        {
            Bases.Multilinea(ref datalistadoDireccion);
            datalistadoDireccion.Columns[0].Visible = false;
        }


        private void datalistado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == datalistado.Columns["EditarEmpleado1"].Index)
            {
                obtenerDatos();
            }
            if (e.ColumnIndex == datalistado.Columns["EliminarEmpleado1"].Index)
            {
                obtenerId_estado();
                idEmpleado = Convert.ToInt32(datalistado.SelectedCells[2].Value);
                DialogResult result = MessageBox.Show("¿Realmente desea eliminar este Registro?", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    eliminar();
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
            Obtener_datos.buscar_empleados(ref dt, txtbuscar.Text);
            datalistado.DataSource = dt;
            pintarDatalistado();
        }
        private void obtenerId_estado()
        {
            try
            {
                idEmpleado = Convert.ToInt32(datalistado.SelectedCells[2].Value);
                estado = datalistado.SelectedCells[26].Value.ToString();

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
                idEmpleado1 = idEmpleado;
                idPersona = Convert.ToInt32(datalistado.SelectedCells[3].Value);
                idPersona1 = idPersona;
                idHorario = Convert.ToInt32(datalistado.SelectedCells[4].Value);
                idHorario1 = idHorario;
                txtnombre.Text = datalistado.SelectedCells[5].Value.ToString();
                txtApellido.Text = datalistado.SelectedCells[6].Value.ToString();
                txtCorreo.Text = datalistado.SelectedCells[7].Value.ToString();
                txtFecha.Value = Convert.ToDateTime(datalistado.SelectedCells[8].Value);
                idDireccion = Convert.ToInt32(datalistado.SelectedCells[9].Value);
                idDireccion1 = idDireccion;
                txtDireccion.Text = datalistado.SelectedCells[10].Value.ToString();
                idDocumento = Convert.ToInt32(datalistado.SelectedCells[11].Value);
                idDocumento1 = idDocumento;
                txtNumeracion.Text = datalistado.SelectedCells[12].Value.ToString();
                txtTipoDocumento.Text = datalistado.SelectedCells[13].Value.ToString();
                idTelefono = Convert.ToInt32(datalistado.SelectedCells[14].Value);
                idTelefon1o = idTelefono;
                txtTelefono.Text = datalistado.SelectedCells[15].Value.ToString();
                idTipoTelefono = Convert.ToInt32(datalistado.SelectedCells[16].Value);
                txtTipoTelefono.Text = datalistado.SelectedCells[17].Value.ToString();
                txtEntrada.Maximum = Convert.ToDecimal(datalistado.SelectedCells[18].Value);
                txtSalida.Minimum = Convert.ToDecimal(datalistado.SelectedCells[19].Value);
                idTipoHorario = Convert.ToInt32(datalistado.SelectedCells[20].Value);

                txtTipoHorario.Text = datalistado.SelectedCells[21].Value.ToString();
                txtCuentaBanco.Text = datalistado.SelectedCells[22].Value.ToString();
                txtDepartamento.Text = datalistado.SelectedCells[23].Value.ToString();
                txtBanco.Text = datalistado.SelectedCells[24].Value.ToString();
                ICONO.BackgroundImage = null;
                byte[] b = (Byte[])datalistado.SelectedCells[25].Value;
                MemoryStream ms = new MemoryStream(b);
                ICONO.Image = Image.FromStream(ms);
                LblAnuncioIcono.Visible = false;
                estado = datalistado.SelectedCells[26].Value.ToString();
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
            TextBox[] array = { txtnombre, txtApellido, txtNumeracion, txtTelefono, txtDireccion, txtCuentaBanco, txtTipoTelefono };
            if (Insertar_datos.ValidTextIsNotNullOrEmpty(array))
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                if (ICONO.Image != null)
                {
                    if (Datos.Obtener_datos.validar_Mail(txtCorreo.Text) == false)
                    {
                        MessageBox.Show("Dirección de correo electronico no valida, el correo debe tener el formato: nombre@dominio.com, " + " por favor seleccione un correo valido", "Validación de correo electronico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtCorreo.Focus();
                        txtCorreo.SelectAll();
                    }
                    else
                    {
                        if (txtNumeracion.Text.Length == 13)
                        {
                            if (txtCuentaBanco.Text.Length == 9)
                            {
                                if (txtDepartamento.Text != "")
                                {
                                    if (txtBanco.Text != "")
                                    {
                                        if (txtTelefono.Text.Length == 12)
                                        {
                                            if (txtTipoDocumento.Text != "" && txtTipoHorario.Text != "")
                                            {
                                                obtenerId_estado();
                                                rellenarCamposVacios();
                                                editar();
                                            }
                                            else
                                            {
                                                MessageBox.Show("Elija un Tipo de Documento correctamente o el Tipo de Horario", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Telefono no valido, el Telefono debe tener el formato: 809-555-5555, " + " por favor seleccione un telefono valido",
                                                "Validación de Telefono", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Elija un tipo de banco correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Elija un departamento correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Cuenta de banco no valida, la cuenta debe tener el formato: XXXXXXXXX 9 CARACTERES," +
                                    " " + " por favor seleccione una cuenta valida", "Validación de cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Cedula no valida, la cedula debe tener el formato: xxx-xxxxxx-x," +
                                " " + " por favor seleccione una cedula valida", "Validación de cedula", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una foto del Empleado", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        int idEmpleado1;
        int idDireccion1;
        int idPersona1;
        int idDocumento1;
        int idTelefon1o;
        int idTipoTelefono1;
        int idTipoHorario1;
        int idHorario1;
        private void obtenerDatosID()
        {
            try
            {
                idEmpleado1 = Convert.ToInt32(datalistado.SelectedCells[2].Value);
                idPersona1 = Convert.ToInt32(datalistado.SelectedCells[3].Value);
                idHorario1 = Convert.ToInt32(datalistado.SelectedCells[4].Value);
                //idDireccion1 = Convert.ToInt32(datalistado.SelectedCells[9].Value);

                idDocumento1 = Convert.ToInt32(datalistado.SelectedCells[11].Value);
                idTelefon1o = Convert.ToInt32(datalistado.SelectedCells[14].Value);
                idTipoTelefono1 = Convert.ToInt32(datalistado.SelectedCells[16].Value);
                idTipoHorario1 = Convert.ToInt32(datalistado.SelectedCells[20].Value);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        public void editar()
        {
            obtenerDatosID();
            if (idTipoTelefonoEditar != 0)
            {
                if (idDireccionEditar != 0)
                {
                    editarTipoHorario();
                }
                else
                {
                    MessageBox.Show("Clickea sobre una Direccion correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Clickea sobre un Tipo de Telefono correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }
        public void editarEmpleado()
        {
            LEmpleados parametrosEmpleado = new LEmpleados();
            Editar_datos funcion = new Editar_datos();

            parametrosEmpleado.idPersona = idPersona1;
            parametrosEmpleado.idHorario = idHorario1;
            parametrosEmpleado.cuentaBanco = txtCuentaBanco.Text;
            parametrosEmpleado.departamento = txtDepartamento.Text;
            parametrosEmpleado.banco = txtBanco.Text;
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            ICONO.Image.Save(ms, ICONO.Image.RawFormat);
            parametrosEmpleado.icono = ms.GetBuffer();
            if (funcion.editarEmpleado(parametrosEmpleado) == true)
            {
                mostrar();
            }
        }

        public void editarPersona()
        {
            LPersona parametrosPersona = new LPersona();
            Editar_datos funcion = new Editar_datos();

            parametrosPersona.idPersona = idPersona1;
            parametrosPersona.nombre = txtnombre.Text;
            parametrosPersona.apellido = txtApellido.Text;
            parametrosPersona.correo = txtCorreo.Text;
            parametrosPersona.fechaNacimiento = txtFecha.Value;
            parametrosPersona.idDireccion = idDireccion1;
            parametrosPersona.idDocumento = idDocumento1;
            parametrosPersona.idTelefono = idTelefon1o;
            
            if (funcion.editarPersona(parametrosPersona) == true)
            {
                editarEmpleado();
            }
        }

        public void editarTelefono()
        {
            LTelefono parametros = new LTelefono();
            Editar_datos funcion = new Editar_datos();

            parametros.idTelefono = idTelefon1o;
            parametros.Telefono = txtTelefono.Text;
            parametros.TipoTelefono = txtTipoTelefono.Text;
            parametros.idTipoTelefono = Convert.ToInt32(lblidtipotelefono.Text);

            if (funcion.editarTelefono(parametros) == true)
            {
                editarDocumento();
            }
        }

        public void editarTipoTelefono()
        {
            editarTelefono();
        }

        public void editarDocumento()
        {
            LDocumentos parametrosDocumentos = new LDocumentos();
            Editar_datos funcion = new Editar_datos();

            parametrosDocumentos.idDocumento = idDocumento1;
            parametrosDocumentos.tipo = txtTipoDocumento.Text;
            parametrosDocumentos.numeracion = txtNumeracion.Text;

            if (funcion.editarDocumento(parametrosDocumentos) == true)
            {
                editarPersona();
            }
        }

        public void editarHorario()
        {
            idTipoHorario = Obtener_datos.obtenerTipoHorarip();
            LHorario parametrosHorario = new LHorario();
            Editar_datos funcion = new Editar_datos();

            string hEntrada = Convert.ToString(txtEntrada.Value);
            string hSalida = Convert.ToString(txtSalida.Value);

            parametrosHorario.idHorario = idHorario1;
            parametrosHorario.horaEntrada = hEntrada;
            parametrosHorario.horaSalida = hSalida;
            parametrosHorario.idTipoHorario = idTipoHorario1;
            if (funcion.editarHorario(parametrosHorario) == true)
            {
                editarTipoTelefono();
            }
        }
        public void editarTipoHorario()
        {
            LHorario parametrosHorario = new LHorario();
            Editar_datos funcion = new Editar_datos();

            parametrosHorario.idTipoHorario = idTipoHorario1;
            parametrosHorario.Descripcion_TipoHorario = txtTipoHorario.Text;
            if (funcion.editarTipoHorario(parametrosHorario) == true)
            {
                editarHorario();
            }
        }

        private void eliminar()
        {
            LEmpleados parametros = new LEmpleados();
            parametros.idEmpleado = idEmpleado;
            Eliminar_datos.eliminarEmpleado(idEmpleado);
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
            txtNumeracion.Clear();
            txtCorreo.Clear();
            txtCuentaBanco.Clear();
            txtDepartamento.Text = "";
            txtBanco.Text = "";
            txtApellido.Clear();
            txtbuscar.Clear();
            panelDatalistado.Visible = false;
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

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtgrupo_TextChanged(object sender, EventArgs e)
        {
            mostrarTipos();
            btnGuardar_grupo.Visible = true;
            MenuStrip9.Visible =true;
            //MenuStrip9.BringToFront;
        }

        private void mostrarTipos()
        {
            panelDatalistado.Visible = true;
            BtnCancelar.Visible = false;
            btnGuardar_grupo.Visible = false;
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("mostrar_tipos", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@buscar", txtTipoTelefono.Text);
                da.Fill(dt);
                datalistadoTiposTelefono.DataSource = dt;
                con.Close();

                datalistadoTiposTelefono.DataSource = dt;
                datalistadoTiposTelefono.Columns[2].Visible = false;
                datalistadoTiposTelefono.Columns[3].Width = 500;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Bases.Multilinea(ref datalistado);
        }

        private void btnGuardar_grupo_Click(object sender, EventArgs e)
        {
            
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("insertar_tipotelefono", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", txtTipoTelefono.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                mostrarTipos();

                txtTipoTelefono.Text = datalistadoTiposTelefono.SelectedCells[3].Value.ToString();

                panelDatalistado.Visible = false;
                btnGuardar_grupo.Visible = false;
                //guardarcambiostipo.Visible = false;
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
            
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            
            panelDatalistado.Visible = false;
            btnGuardar_grupo.Visible = false;
            BtnCancelar.Visible = false;
            btnNuevoGrupo.Visible = true;
            txtTipoTelefono.Clear();
            mostrarTipos();
        }

        private void datalistadoTiposTelefono_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idTipoTelefonoEditar = Convert.ToInt32(datalistadoTiposTelefono.SelectedCells[2].Value.ToString());
            if (e.ColumnIndex == this.datalistadoTiposTelefono.Columns["EliminarG"].Index)
            {
                lblidtipotelefono.Text = datalistadoTiposTelefono.SelectedCells[2].Value.ToString();
                idTipoTelefono = Convert.ToInt32(datalistadoTiposTelefono.SelectedCells[2].Value.ToString());
                idTipoTelefonoEditar = Convert.ToInt32(datalistadoTiposTelefono.SelectedCells[2].Value.ToString());
                DialogResult result;
                result = MessageBox.Show("¿Realmente desea eliminar este Tipo de Numero?", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    SqlCommand cmd;
                    try
                    {
                        foreach (DataGridViewRow row in datalistadoTiposTelefono.SelectedRows)
                        {

                            int onekey = Convert.ToInt32(lblidtipotelefono.Text);

                            try
                            {
                                try
                                {
                                    SqlConnection con = new SqlConnection();
                                    con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                                    con.Open();
                                    cmd = new SqlCommand("eliminartipotelefono", con);
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@id", onekey);
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
                                catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
                                {
                                    //MessageBox.Show(ex.Message);
                                }
                            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
                            catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
                            {

                                //MessageBox.Show(ex.Message);
                            }
                        }
                        txtTipoTelefono.Text = "DIGITA EL TIPO DE NUMERO";
                        txtTipoTelefono.SelectAll();
                        txtTipoTelefono.Focus();
                        mostrarTipos();
                        lblidtipotelefono.Text = datalistadoTiposTelefono.SelectedCells[2].Value.ToString();
                        idTipoTelefono = Convert.ToInt32(datalistadoTiposTelefono.SelectedCells[2].Value.ToString());
                    }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
                    catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
                    {
                        //MessageBox.Show(ex.Message);
                    }
                }
            }

            if (e.ColumnIndex == this.datalistadoTiposTelefono.Columns["EditarG"].Index)

            {
                lblidtipotelefono.Text = datalistadoTiposTelefono.SelectedCells[2].Value.ToString();
                idTipoTelefono = Convert.ToInt32(datalistadoTiposTelefono.SelectedCells[2].Value.ToString());
                idTipoTelefonoEditar = Convert.ToInt32(datalistadoTiposTelefono.SelectedCells[2].Value.ToString());
                txtTipoTelefono.Text = datalistadoTiposTelefono.SelectedCells[3].Value.ToString();
                panelDatalistado.Visible = false;
                btnGuardar_grupo.Visible = false;
                BtnCancelar.Visible = true;
                btnNuevoGrupo.Visible = false;
            }
            if (e.ColumnIndex == this.datalistadoTiposTelefono.Columns["tipoTelefono"].Index)
            {
                lblidtipotelefono.Text = datalistadoTiposTelefono.SelectedCells[2].Value.ToString();
                idTipoTelefono = Convert.ToInt32(datalistadoTiposTelefono.SelectedCells[2].Value.ToString());
                txtTipoTelefono.Text = datalistadoTiposTelefono.SelectedCells[3].Value.ToString();
                panelDatalistado.Visible = false;
                btnGuardar_grupo.Visible = false;
                BtnCancelar.Visible = false;
                btnNuevoGrupo.Visible = true;
            }
        }

        private void btnNuevoGrupo_Click_1(object sender, EventArgs e)
        {
           
            txtTipoTelefono.SelectAll();
            txtTipoTelefono.Focus();
            panelDatalistado.Visible = false;
            btnGuardar_grupo.Visible = true;
            BtnCancelar.Visible = true;
            btnNuevoGrupo.Visible = false;
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            if(txtDireccion.Text != "")
            {
                panelDataListadoDireccion.Visible = true;
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

            Bases.Multilinea(ref datalistadoDireccion);
        }

        private void datalistadoDireccion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idDireccionEditar = Convert.ToInt32(datalistadoDireccion.SelectedCells[0].Value);
            idDireccion = Convert.ToInt32(datalistadoDireccion.SelectedCells[0].Value);
            idDireccion1 = Convert.ToInt32(datalistadoDireccion.SelectedCells[0].Value);
            txtDireccion.Text = datalistadoDireccion.SelectedCells[1].Value.ToString();
            panelDataListadoDireccion.Visible = false;
        }

        private void tiempoBuscador_Tick(object sender, EventArgs e)
        {
        }

        private void txtDireccion_Enter(object sender, EventArgs e)
        {
           
        }

        private void txtDireccion_DragEnter(object sender, DragEventArgs e)
        {
            

        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (datalistadoDireccion.SelectedRows.Count > 0)
                {

                }
                else
                {
                    DialogResult result = MessageBox.Show("¿Desea agregar una nueva Dirección?", "DirecciÓN", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        Direccion.Direcciones frm = new Direccion.Direcciones();
                        frm.ShowDialog();
                    }

                }
            }
        }

        private void datalistadoTiposTelefono_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
