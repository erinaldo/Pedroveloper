using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SistemaVentas.CONEXION;
using SistemaVentas.Datos;
using SistemaVentas.Logica;
namespace SistemaVentas.Presentacion.CLIENTES_PROVEEDORES
{
    public partial class ClientesOk : Form
    {
        public ClientesOk()
        {
            InitializeComponent();
        }
        int idCliente;
        string estado;
        int idDireccion;
        int idPersona;
        int idDocumento;
        int idTelefono;
        int idTipoTelefono;
        int correo;
        bool band;
        int idCorreo;
        string numeracion, telefono, nombre;
        //Crud--------
        private void insertar()
        {
            if(idTipoTelefono != 0)
            {
                if(idDireccion != 0)
                {
                    band = insertarCorreo();
                    if (band == true)
                    {
                        CONEXIONMAESTRA.abrir();
                        SqlCommand com = new SqlCommand("ObtenerUltimoCorreo", CONEXIONMAESTRA.conectar);
                        com.CommandType = CommandType.StoredProcedure;
                        correo = Convert.ToInt32(com.ExecuteScalar());
                        CONEXIONMAESTRA.cerrar();
                        insertarDocumento();
                    }
                    else
                    {

                    }
                }
                else
                {
                    MessageBox.Show("Clickea correctamente una dirección", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                MessageBox.Show("Clickea correctamente un Tipo de telefono", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private bool insertarCorreo()
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarCorreo", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@correo", txtCorreo.Text);
                cmd.Parameters.AddWithValue("@TipoCorreo", "Correo Cliente");
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                return false;
            }
        }
        public void insertarCliente()
        {
            idPersona = Obtener_datos.obtenerPersona();
            Lclientes parametros = new Lclientes();
            Insertar_datos funcion = new Insertar_datos();
            parametros.idPersona = idPersona;
            parametros.IdentificadorFiscal = txtIdentificador.Text;
            if (funcion.insertar_clientes(parametros) == true)
            {
                mostrar();
            }

        }
        //InsertarDireccion - Documento - Telefono
        public void insertarPersona()
        {

            idTelefono = Obtener_datos.obtenerTelefono();
            idDocumento = Obtener_datos.obtenerDocumento();

            LPersona parametrosPersona = new LPersona();
            Insertar_datos funcion = new Insertar_datos();

            parametrosPersona.nombre = txtnombre.Text;
            parametrosPersona.apellido = txtApellido.Text;
            parametrosPersona.idCorreo = correo;
            DateTime myDateTime = txtFecha.Value;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd");

            parametrosPersona.fechaNacimiento = txtFecha.Value.Date;
            parametrosPersona.idDireccion = idDireccion;
            parametrosPersona.idDocumento = idDocumento;
            parametrosPersona.idTelefono = idTelefono;

            if (funcion.insertarPersona(parametrosPersona) == true)
            {
                insertarCliente();
            }
        }

        public void insertarTelefono()
        {
            LTelefono parametros = new LTelefono();
            Insertar_datos funcion = new Insertar_datos();

            parametros.Telefono = txtTelefono.Text;
            parametros.TipoTelefono = txtTipoTelefono.Text;

            int idTipoTelefono1 = Obtener_datos.obtenerTipoTelefono();

            if (funcion.insertarTelefono(parametros, idTipoTelefono1) == true)
            {
                insertarPersona();
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

            if (funcion.InsertarDocumento(parametrosDocumentos) == true)
            {
                insertarTipoTelefono();
            }
        }
        public void HideWidthColumns()
        {
            tablaClientes.Columns[0].DisplayIndex = 17;
            tablaClientes.Columns[1].DisplayIndex = 17;
            tablaClientes.Columns[2].Visible = false;
            tablaClientes.Columns[3].Visible = false;
            tablaClientes.Columns[8].Visible = false;
            tablaClientes.Columns[10].Visible = false;
            tablaClientes.Columns[13].Visible = false;
            tablaClientes.Columns[15].Visible = false;
            tablaClientes.Columns[18].Visible = false;
            tablaClientes.Columns[19].Visible = false;
            tablaClientes.Columns[20].Visible = false;
        }

        private void mostrar()
        {
            DataTable dt = new DataTable();
            Obtener_datos.mostrar_clientes (ref dt);
            tablaClientes.DataSource = dt;
            Panelregistro.Visible = false;
            HideWidthColumns();
        }
        int idCliente1;
        int idDireccion1;
        int idPersona1;
        int idDocumento1;
        int idTelefon1o;
        int idTipoTelefono1;
        int idCorreo1;
        private void obtenerDatosID()
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        public void editar()
        {
           /* idPersona1 = Convert.ToInt32(tablaClientes.SelectedCells[3].Value);
            idDireccion1 = Convert.ToInt32(tablaClientes.SelectedCells[8].Value);
            idTelefon1o = Convert.ToInt32(tablaClientes.SelectedCells[13].Value);
            idTipoTelefono1 = Convert.ToInt32(tablaClientes.SelectedCells[15].Value);
            idCorreo1 = Convert.ToInt32(tablaClientes.SelectedCells[20].Value);*/

            if (idTipoTelefono != 0)
            {
                if (idDireccion != 0)
                {
                    bool correo = editarCorreo();
                    if (correo)
                    {
                        editarDocumento();
                    }
                }
                else
                {
                    MessageBox.Show("Clickea correctamente una dirección", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                MessageBox.Show("Clickea correctamente un Tipo de telefono", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private bool editarCorreo()
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("editar_correo", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCorreo", idCorreo);
                cmd.Parameters.AddWithValue("@correo", txtCorreo.Text);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                return false;
            }
        }
        public void editarCliente()
        {
            Lclientes parametros = new Lclientes();
            Editar_datos funcion = new Editar_datos();
            parametros.idcliente = idCliente1;
            parametros.idPersona = idPersona1;
            parametros.IdentificadorFiscal = txtIdentificador.Text;
            if (funcion.editar_clientes(parametros) == true)
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
            parametrosPersona.fechaNacimiento = txtFecha.Value;
            parametrosPersona.idDireccion = idDireccion;
            parametrosPersona.idDocumento = idDocumento;
            parametrosPersona.idTelefono = idTelefono;
            parametrosPersona.idCorreo = idCorreo;

            if (funcion.editarPersona(parametrosPersona) == true)
            {
                editarCliente();
            }
        }

        public void editarTelefono()
        {
            LTelefono parametros = new LTelefono();
            Editar_datos funcion = new Editar_datos();

            parametros.idTelefono = idTelefon1o;
            parametros.Telefono = txtTelefono.Text;
            parametros.TipoTelefono = txtTipoTelefono.Text;
            parametros.idTipoTelefono = idTipoTelefono1;

            if (funcion.editarTelefono(parametros) == true)
            {
                editarPersona();
            }
        }

        public void editarTipoTelefono()
        {
            /*LTelefono parametros = new LTelefono();
            Editar_datos funcion = new Editar_datos();

            parametros.idTelefono = idTelefon1o;
            parametros.Telefono = txtTelefono.Text;
            parametros.TipoTelefono = txtTipoTelefono.Text;

            int idTipoTelefono1 = Obtener_datos.obtenerTipoTelefonoid(txtTipoTelefono.Text);
            parametros.idTipoTelefono = idTipoTelefono1;

            if (funcion.editarTipoTelefono(parametros) == true)
            {*/
                editarTelefono();
           // }
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
                editarTipoTelefono();
            }
        }

        private void eliminar()
        {
            try
            {
                Lclientes  parametros = new Lclientes();
                Eliminar_datos funcion = new Eliminar_datos();
                parametros.idcliente = idCliente;
                if (funcion.eliminar_clientes(parametros) == true)
                {
                    mostrar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }
        private void restaurar()
        {
            Lclientes  parametros = new Lclientes();
            Editar_datos funcion = new Editar_datos();
            parametros.idcliente = idCliente;
            if (funcion.restaurar_clientes (parametros) == true)
            {
                mostrar();
            }

        }
        private void buscar()
        {
            DataTable dt = new DataTable();
            Obtener_datos.buscar_clientes(ref dt, txtbusca.Text);
            tablaClientes.DataSource = dt;
            foreach (DataGridViewRow row in tablaClientes.Rows)
            {
                string estado = Convert.ToString(row.Cells["Estado"].Value);
                if (estado == "ELIMINADO")
                {
                    row.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Strikeout | FontStyle.Bold);
                    row.DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }
        //------------
       
        private void ClientesOk_Load(object sender, EventArgs e)
        {

            bool bandera = Presentacion.CONFIGURACION.PANEL_CONFIGURACIONES.banderaClientes;
            if (bandera)
            {
                //Salir.Visible = true;
            }
            else
            {
                //Salir.Visible = false;
            }
            mostrar();
        }

        private void Nuevo()
        {
            Panelregistro.Visible = true;
            limpiar();
            guardar.Visible = true;
            guardarcambios.Visible = false;
            txtnombre.Focus();
            Panelregistro.Dock = DockStyle.Fill;
        }
        private void limpiar()
        {
            txtnombre.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtIdentificador.Clear();
            txtCorreo.Clear();
            txtTipoTelefono.Clear();
            txtNumeracion.Clear();
            txtApellido.Clear();
            panelDatalistado.Visible = false;
            txtTipoDocumento.SelectedIndex = 0;
        }

     
        private void rellenarCamposVacios()
        {
            if (string.IsNullOrEmpty(txtTelefono.Text)) { txtTelefono.Text = "-"; };
            if (string.IsNullOrEmpty(txtDireccion.Text)) { txtDireccion.Text = "-"; };
            if (string.IsNullOrEmpty(txtIdentificador.Text)) { txtIdentificador.Text = "-"; };

        }

        private void datalistado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }
        private void obtenerId_estado()
        {
            try
            {
                idCliente = Convert.ToInt32(tablaClientes.SelectedCells[2].Value);
                estado = tablaClientes.SelectedCells[17].Value.ToString();

            }
            catch (Exception)
            {

            }
        }

        private void prepararEdicion()
        {
            Panelregistro.Visible = true;
            Panelregistro.Dock = DockStyle.Fill;
            guardar.Visible = false;
            guardarcambios.Visible = true;
        }


        private void txtbusca_TextChanged(object sender, EventArgs e)
        {
            buscar();
        }

        private void datalistado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

 

        private void txtdireccion_TextChanged(object sender, EventArgs e)
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

            Bases.Multilinea(ref datalistadoDireccion);
        }
        private void pintarDatalistadoDireccion()
        {
            Bases.Multilinea(ref datalistadoDireccion);
            datalistadoDireccion.Columns[0].Visible = false;
        }

        private void datalistadoDireccion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idDireccion = Convert.ToInt32(datalistadoDireccion.SelectedCells[0].Value);
            txtDireccion.Text = datalistadoDireccion.SelectedCells[1].Value.ToString();
            panelDataListadoDireccion.Visible = false;
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

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            panelDatalistado.Visible = false;
            btnGuardar_grupo.Visible = false;
            BtnCancelar.Visible = false;
            btnNuevoGrupo.Visible = true;
            txtTipoTelefono.Clear();
            mostrarTipos();
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
                datalistadoTiposTelefono.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
             
            Bases.Multilinea(ref datalistadoTiposTelefono);
        }

        private void btnNuevoGrupo_Click(object sender, EventArgs e)
        {
            txtTipoTelefono.SelectAll();
            txtTipoTelefono.Focus();
            panelDatalistado.Visible = false;
            btnGuardar_grupo.Visible = true;
            BtnCancelar.Visible = true;
            btnNuevoGrupo.Visible = false;
        }

        private void txtTipoTelefono_TextChanged(object sender, EventArgs e)
        {
            mostrarTipos();
            btnGuardar_grupo.Visible = true;
            MenuStrip9.Visible = true;
        }

        private void datalistado_CellBorderStyleChanged(object sender, EventArgs e)
        {

        }

        private void txtNumeracion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {

        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();

        }

        private void guardar_Click(object sender, EventArgs e)
        {

            TextBox[] array = { txtnombre, txtApellido, txtNumeracion, txtTelefono, txtDireccion, txtTipoTelefono, txtCorreo };
            if (Insertar_datos.ValidTextIsNotNullOrEmpty(array))
            {

                if (txtNumeracion.Text.Length == 13)
                {

                    if (txtTelefono.Text.Length == 12)
                    {
                        rellenarCamposVacios();
                        insertar();
                    }
                    else
                    {
                        MessageBox.Show("Telefono no valido, el Telefono debe tener el formato: 809-555-5555, " + " por favor seleccione un telefono valido",
                            "Validación de Telefono", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Cedula no valida, la cedula debe tener el formato: xxx-xxxxxx-x," +
                       " " + " por favor seleccione una cedula valida", "Validación de cedula", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void guardarcambios_Click(object sender, EventArgs e)
        {
            TextBox[] array = { txtnombre, txtApellido, txtNumeracion, txtTelefono, txtDireccion, txtTipoTelefono, txtCorreo };
            if (Insertar_datos.ValidTextIsNotNullOrEmpty(array))
            {

                if (txtNumeracion.Text.Length == 13)
                {

                    if (txtTelefono.Text.Length == 12)
                    {
                        rellenarCamposVacios();
                        editar();
                    }
                    else
                    {
                        MessageBox.Show("Telefono no valido, el Telefono debe tener el formato: 809-555-5555, " + " por favor seleccione un telefono valido",
                            "Validación de Telefono", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Cedula no valida, la cedula debe tener el formato: xxx-xxxxxx-x," +
                       " " + " por favor seleccione una cedula valida", "Validación de cedula", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void volver_Click(object sender, EventArgs e)
        {
            Panelregistro.Visible = false;

        }

        private void tablaClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaClientes.Rows[e.RowIndex].Cells["e"].Selected)
            {
                try
                {
                    idCliente = Convert.ToInt32(tablaClientes.Rows[e.RowIndex].Cells["idclientev"].Value.ToString());
                    idCliente1 = idCliente;
                    idPersona = Convert.ToInt32(tablaClientes.Rows[e.RowIndex].Cells["idPersona"].Value.ToString());
                    idPersona1 = idPersona;
                    txtnombre.Text = tablaClientes.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                    nombre = tablaClientes.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                    txtApellido.Text = tablaClientes.Rows[e.RowIndex].Cells["apellido"].Value.ToString();
                    txtCorreo.Text = tablaClientes.Rows[e.RowIndex].Cells["Correo"].Value.ToString();
                    /* DateTime fecha = Convert.ToDateTime(tablaClientes.Rows[e.RowIndex].Cells["fechaNacimiento"].Value.ToString());
                     MessageBox.Show(fecha.ToString());*/
                    string fecha = (tablaClientes.Rows[e.RowIndex].Cells["fechaNacimiento"].Value.ToString());
                    //txtFecha.Value = Convert.ToDateTime(tablaClientes.SelectedCells[7].Value.ToString());
                    idDireccion = Convert.ToInt32(tablaClientes.Rows[e.RowIndex].Cells["idDireccion"].Value.ToString());
                    idDireccion1= Convert.ToInt32(tablaClientes.Rows[e.RowIndex].Cells["idDireccion"].Value.ToString());
                    txtDireccion.Text = tablaClientes.Rows[e.RowIndex].Cells["Direccion"].Value.ToString();
                    idDocumento = Convert.ToInt32(tablaClientes.Rows[e.RowIndex].Cells["idDocumento"].Value.ToString());
                    idDocumento1 = idDocumento;
                    txtNumeracion.Text = tablaClientes.Rows[e.RowIndex].Cells["Documento"].Value.ToString();
                    numeracion = tablaClientes.Rows[e.RowIndex].Cells["Documento"].Value.ToString();
                    txtTipoDocumento.Text = tablaClientes.Rows[e.RowIndex].Cells["TipoDocumento"].Value.ToString();
                    idTelefono = Convert.ToInt32(tablaClientes.Rows[e.RowIndex].Cells["idTelefono"].Value.ToString());
                    idTelefon1o = idTelefono;
                    txtTelefono.Text = tablaClientes.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
                    telefono = tablaClientes.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
                    idTipoTelefono = Convert.ToInt32(tablaClientes.Rows[e.RowIndex].Cells["idTipoTelefono"].Value.ToString());
                    idTipoTelefono1 = Convert.ToInt32(tablaClientes.Rows[e.RowIndex].Cells["idTipoTelefono"].Value.ToString());
                    string t = tablaClientes.Rows[e.RowIndex].Cells["TipoTelefono"].Value.ToString();
                    txtTipoTelefono.Text = t;
                    txtIdentificador.Text = tablaClientes.Rows[e.RowIndex].Cells["IdentificadorFiscal"].Value.ToString();

                    estado = tablaClientes.Rows[e.RowIndex].Cells["Estado"].Value.ToString();
                    idCorreo = Convert.ToInt32(tablaClientes.Rows[e.RowIndex].Cells["idCorreo"].Value.ToString());
                    if (estado == "ELIMINADO")
                    {
                        DialogResult result = MessageBox.Show("Este Proveedor se Elimino. ¿Desea Volver a Habilitarlo?", "Restaurando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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
                  //  MessageBox.Show(ex.StackTrace);
                }
            }
            if (tablaClientes.Rows[e.RowIndex].Cells["d"].Selected)
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

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void tablaClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void datalistadoTiposTelefono_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.datalistadoTiposTelefono.Columns["EliminarG"].Index)
            {
                lblidtipotelefono.Text = datalistadoTiposTelefono.SelectedCells[2].Value.ToString();
                idTipoTelefono = Convert.ToInt32(datalistadoTiposTelefono.SelectedCells[2].Value.ToString());
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

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            panelDataListadoDireccion.Visible = true;
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (datalistadoDireccion.SelectedRows.Count > 0)
                {

                }
                else
                {
                    DialogResult result = MessageBox.Show("¿Desea agregar una nueva Dirección?", "Dirección", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        Direccion.Direcciones frm = new Direccion.Direcciones();
                        frm.ShowDialog();
                    }

                }
            }
        }
    }
}
