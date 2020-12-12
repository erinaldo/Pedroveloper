using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing;
using SistemaVentas.Logica;
using SistemaVentas.CONEXION;

namespace SistemaVentas

{
    public partial class usuariosok : Form
    {
        public usuariosok()
        {
            InitializeComponent();
        }
        int idEmpleado;
        int idEmpleado1;
        int idPersona;
        int idPersona1;
        int idCorreo;
        string correo;

        private void Cargar_estado_de_iconos()
        {
            try
            {
                foreach (DataGridViewRow row in tablaUsuarios.Rows)
                {

                    try
                    {

                        string Icono = Convert.ToString(row.Cells["Nombre_de_icono"].Value);

                        if (Icono == "1")
                        {
                            pictureBox3.Visible = false;
                        }
                        else if (Icono == "2")
                        {
                            pictureBox4.Visible = false;
                        }
                        else if (Icono == "3")
                        {
                            pictureBox5.Visible = false;
                        }
                        else if (Icono == "4")
                        {
                            pictureBox6.Visible = false;
                        }
                        else if (Icono == "5")
                        {
                            //    pictureBox7.Visible = false;
                        }
                        else if (Icono == "6")
                        {
                            //       pictureBox8.Visible = false;
                        }
                        else if (Icono == "7")
                        {
                            //        pictureBox9.Visible = false;
                        }
                        else if (Icono == "8")
                        {
                            //       pictureBox10.Visible = false;
                        }
                    }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
                    catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
                    {


                    }


                }
            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            {

            }
        }
        public bool validar_Mail(string sMail)
        {
            return Regex.IsMatch(sMail, @"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$");

        }

        private void mostrar()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                da = new SqlDataAdapter("mostrar_usuario", con);
                da.Fill(dt);
                tablaUsuarios.DataSource = dt;
                con.Close();

                tablaUsuarios.Columns[2].Visible = false;
                tablaUsuarios.Columns[3].Visible = false;
                tablaUsuarios.Columns[4].Visible = false;
                tablaUsuarios.Columns[11].Visible = false;
                tablaUsuarios.Columns[13].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox3.Image;
            lblnumeroIcono.Text = "1";
            LblAnuncioIcono.Visible = false;
            panelICONO.Visible = false;
            panelborder.Visible = false;

        }

        private void LblAnuncioIcono_Click(object sender, EventArgs e)
        {
            Cargar_estado_de_iconos();
            panelICONO.Visible = true;
            panelborder.Visible = false;
            panelborder.Dock = DockStyle.Fill;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox4.Image;
            lblnumeroIcono.Text = "2";
            LblAnuncioIcono.Visible = false;
            panelICONO.Visible = false;
            panelborder.Visible = false;

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox5.Image;
            lblnumeroIcono.Text = "3";
            LblAnuncioIcono.Visible = false;
            panelICONO.Visible = false;
            panelborder.Visible = false;

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox6.Image;
            lblnumeroIcono.Text = "4";
            LblAnuncioIcono.Visible = false;
            panelICONO.Visible = false;
            panelborder.Visible = false;

        }

        public void HideWidthColumns()
        {
            tablaUsuarios.Columns[10].Visible = false;

            tablaUsuarios.Columns[0].DisplayIndex = 14;
            tablaUsuarios.Columns[1].DisplayIndex = 14;

        }
        private void usuariosok_Load(object sender, EventArgs e)
        {

            LRoles cat = new LRoles();
            panelDataListadoEmpleado.Visible = false;
            panelRegistros.Visible = false;
            panelICONO.Visible = false;
            panelborder.Visible = false;

            mostrar();
            HideWidthColumns();

            txtroles.DataSource = cat.CargarCombo();
            txtroles.DisplayMember = "Rol";
            txtroles.ValueMember = "idRol";
        }


        #region Editar usuarios

        #endregion

        private void ICONO_Click(object sender, EventArgs e)
        {
            Cargar_estado_de_iconos();

            panelborder.Visible = true;
            panelborder.Dock = DockStyle.Fill;
            panelICONO.Visible = true;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        private void pictureBox11_Click(object sender, EventArgs e)
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
                LblAnuncioIcono.Visible = false;
                panelICONO.Visible = false;
                panelborder.Visible = false;
            }
        }

        private void buscar_usuario()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("buscar_usuario", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letra", txtbuscar.Text);
                da.Fill(dt);
                tablaUsuarios.DataSource = dt;

                tablaUsuarios.Columns[2].Visible = false;
                tablaUsuarios.Columns[3].Visible = false;
                tablaUsuarios.Columns[4].Visible = false;
                tablaUsuarios.Columns[11].Visible = false;
                tablaUsuarios.Columns[13].Visible = false;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        public void Numeros(System.Windows.Forms.TextBox CajaTexto, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;

            }


        }
        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            buscar_usuario();

        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            Numeros(txtbuscar, e);

        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {
            if (txtEmpleado.Text != "")
            {
                mostrarEmpleado();
            }
            else
            {
                panelDataListadoEmpleado.Visible = false;

            }
        }
        private void mostrarEmpleado()
        {
            panelDataListadoEmpleado.Visible = true;
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("buscarEmpleado2", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letra", txtEmpleado.Text);
                da.Fill(dt);
                datalistadoEmpleado.DataSource = dt;
                con.Close();

                datalistadoEmpleado.DataSource = dt;
                pintardatalistadoEmpleado();
                datalistadoEmpleado.Columns[0].Visible = false;
                datalistadoEmpleado.Columns[1].Visible = false;
                datalistadoEmpleado.Columns[3].Visible = false;
                datalistadoEmpleado.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Bases.Multilinea(ref datalistadoEmpleado);
        }
        private void pintardatalistadoEmpleado()
        {
            Bases.Multilinea(ref datalistadoEmpleado);
        }

        private void datalistadoEmpleado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idEmpleado = Convert.ToInt32(datalistadoEmpleado.SelectedCells[0].Value);
            idEmpleado1 = Convert.ToInt32(datalistadoEmpleado.SelectedCells[0].Value);
            idPersona = Convert.ToInt32(datalistadoEmpleado.SelectedCells[1].Value);
            idPersona1 = Convert.ToInt32(datalistadoEmpleado.SelectedCells[1].Value);
            txtEmpleado.Text = datalistadoEmpleado.SelectedCells[2].Value.ToString();
            panelDataListadoEmpleado.Visible = false;
        }

        private void txtEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (datalistadoEmpleado.SelectedRows.Count > 0)
                {

                }
                else
                {
                    DialogResult result = MessageBox.Show("¿Desea agregar un nuevo Empleado?", "Empleado", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        Presentacion.Empleados.EmpleadosOK frm = new Presentacion.Empleados.EmpleadosOK();
                        frm.ShowDialog();
                    }

                }
            }
        }

        private void txtroles_SelectedIndexChanged(object sender, EventArgs e)
        {
            // MessageBox.Show(txtroles.SelectedValue.ToString());
        }

        private void txtEmpleado_DoubleClick(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea agregar un nuevo Empleado?", "Empleado", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Presentacion.Empleados.EmpleadosOK frm = new Presentacion.Empleados.EmpleadosOK();
                frm.ShowDialog();
            }

        }

        private void Salir_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void Minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;

        }


        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            panelRegistros.Visible = true;

            //panelRegistros.Dock = DockStyle.Fill;

            LblAnuncioIcono.Visible = true;
            txtEmpleado.Text = "";
            txtlogin.Text = "";
            txtPassword.Text = "";
            guardar.Visible = true;
            guardarcambios.Visible = false;
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            int correo = 0;
            bool band = false;
            if (validar_Mail(txtCorreo.Text) == false)
            {
                MessageBox.Show("Dirección de correo electronico no valida, el correo debe tener el formato: nombre@dominio.com, " + " por favor seleccione un correo valido", "Validación de correo electronico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCorreo.Focus();
                txtCorreo.SelectAll();
            }
            else
            {
                band = insertarCorreo();
                if (band == true)
                {
                    CONEXIONMAESTRA.abrir();
                    SqlCommand com = new SqlCommand("ObtenerUltimoCorreo", CONEXIONMAESTRA.conectar);
                    com.CommandType = CommandType.StoredProcedure;
                    correo = Convert.ToInt32(com.ExecuteScalar());
                    CONEXIONMAESTRA.cerrar();
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    ICONO.Image.Save(ms, ICONO.Image.RawFormat);
                    if (ICONO.Image != null)
                    {
                        if (txtEmpleado.Text != "")
                        {
                            if (txtroles.Text != "")
                            {
                                if (LblAnuncioIcono.Visible == false)
                                {
                                    try
                                    {
                                        SqlConnection con = new SqlConnection();
                                        con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                                        con.Open();
                                        SqlCommand cmd = new SqlCommand();
                                        cmd = new SqlCommand("insertar_usuario", con);
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                                        cmd.Parameters.AddWithValue("@Login", txtlogin.Text);
                                        cmd.Parameters.AddWithValue("@Password", Bases.Encriptar(txtPassword.Text));
                                        cmd.Parameters.AddWithValue("@idRol", Convert.ToInt32(txtroles.SelectedValue));
                                        ICONO.Image.Save(ms, ICONO.Image.RawFormat);
                                        cmd.Parameters.AddWithValue("@Icono", ms.GetBuffer());
                                        cmd.Parameters.AddWithValue("@Nombre_de_icono", lblnumeroIcono.Text);
                                        cmd.Parameters.AddWithValue("@idCorreo", correo);
                                        cmd.Parameters.AddWithValue("@Estado", "ACTIVO");
                                        cmd.ExecuteNonQuery();
                                        con.Close();
                                        mostrar();
                                        panelRegistros.Visible = false;
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Elija un Icono", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Elija un Rol", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Asegúrese de haber llenado todos los campos para poder continuar", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Asegúrese de haber seleccionado el icono", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("El correo digitado existe\nDigite un correo diferente.", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private bool insertarCorreo()
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("insertarCorreo", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@correo", txtCorreo);
                cmd.Parameters.AddWithValue("@TipoCorreo", "Correo Usuario");
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                return false;
            }
        }

        private bool editarCorreo()
        {
            MessageBox.Show("id" + idCorreo.ToString());
            MessageBox.Show(correo.ToString());
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("editar_correo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCorreo",idCorreo);
                cmd.Parameters.AddWithValue("@correo",correo);
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                return false;
            }
        }
        private void guardarcambios_Click(object sender, EventArgs e)
        {
            bool band = false;
            if (validar_Mail(txtCorreo.Text) == false)
            {
                MessageBox.Show("Dirección de correo electronico no valida, el correo debe tener el formato: nombre@dominio.com, " + " por favor seleccione un correo valido", "Validación de correo electronico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCorreo.Focus();
                txtCorreo.SelectAll();
            }
            else
            {
                band = editarCorreo();
                if (band == true)
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    ICONO.Image.Save(ms, ICONO.Image.RawFormat);
                    if (ICONO.Image != null)
                    {
                        if (txtEmpleado.Text != "")
                        {
                            if (txtroles.Text != "")
                            {
                                if (LblAnuncioIcono.Visible == false)
                                {
                                    try
                                    {
                                        SqlConnection con = new SqlConnection();
                                        con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                                        con.Open();
                                        SqlCommand cmd = new SqlCommand();
                                        cmd = new SqlCommand("editar_usuario", con);
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        cmd.Parameters.AddWithValue("@idUsuario", lblId_usuario.Text);
                                        cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                                        cmd.Parameters.AddWithValue("@Login", txtlogin.Text);
                                        cmd.Parameters.AddWithValue("@Password", Bases.Encriptar(txtPassword.Text));
                                        cmd.Parameters.AddWithValue("@idRol", Convert.ToInt32(txtroles.SelectedValue));
                                        ICONO.Image.Save(ms, ICONO.Image.RawFormat);
                                        cmd.Parameters.AddWithValue("@Icono", ms.GetBuffer());
                                        cmd.Parameters.AddWithValue("@Nombre_de_icono", lblnumeroIcono.Text);
                                        cmd.ExecuteNonQuery();
                                        con.Close();
                                        mostrar();
                                        panelRegistros.Visible = false;
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Elija un Icono", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Elija un Rol", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Asegúrese de haber llenado todos los campos para poder continuar", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Asegúrese de haber seleccionado el icono", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("El correo digitado existe\nDigite un correo diferente.", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void volver_Click(object sender, EventArgs e)
        {
            panelRegistros.Visible = false;

        }
        private void tablaUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaUsuarios.Rows[e.RowIndex].Cells["Editar"].Selected)
            {
                
                MessageBox.Show(tablaUsuarios.Rows[e.RowIndex].Cells["idUsuario"].Value.ToString());
                  lblId_usuario.Text = tablaUsuarios.Rows[e.RowIndex].Cells["idUsuario"].Value.ToString();
                idEmpleado = Convert.ToInt32(tablaUsuarios.Rows[e.RowIndex].Cells["idEmpleado"].Value);
                idEmpleado1 = Convert.ToInt32(tablaUsuarios.Rows[e.RowIndex].Cells["idEmpleado"].Value);
                txtEmpleado.Text = tablaUsuarios.Rows[e.RowIndex].Cells["Nombre"].Value.ToString() ;
                txtlogin.Text = tablaUsuarios.Rows[e.RowIndex].Cells["Login"].Value.ToString();
                txtPassword.Text = tablaUsuarios.Rows[e.RowIndex].Cells["Password"].Value.ToString();
                ICONO.BackgroundImage = null;
                txtroles.Text = tablaUsuarios.Rows[e.RowIndex].Cells["Rol"].Value.ToString();
                lblnumeroIcono.Text = tablaUsuarios.Rows[e.RowIndex].Cells["NombreIcono"].Value.ToString();
                txtCorreo.Text = tablaUsuarios.Rows[e.RowIndex].Cells["Correo"].Value.ToString();
                idCorreo = Convert.ToInt32(tablaUsuarios.Rows[e.RowIndex].Cells["idCorreo"].Value);
                correo = tablaUsuarios.Rows[e.RowIndex].Cells["Correo"].Value.ToString(); 
                byte[] b = (Byte[])tablaUsuarios.Rows[e.RowIndex].Cells["Icono"].Value;
                MemoryStream ms = new MemoryStream(b);
                ICONO.Image = Image.FromStream(ms);
                LblAnuncioIcono.Visible = false;
                panelRegistros.Visible = true;
                panelRegistros.Dock = DockStyle.Fill;
                guardar.Visible = false;
                guardarcambios.Visible = true;
            }
            if (e.ColumnIndex == this.tablaUsuarios.Columns["Eli"].Index)
            {
                DialogResult result;
                result = MessageBox.Show("¿Realmente desea eliminar este Usuario?", "Eliminando registros", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    try
                    {
                        int onekey = Convert.ToInt32(tablaUsuarios.Rows[e.RowIndex].Cells["idUsuario"].Value);
                        string usuario = tablaUsuarios.Rows[e.RowIndex].Cells["Login"].Value.ToString();
                        SqlCommand cmd;
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                        con.Open();

                        cmd = new SqlCommand("eliminar_usuario", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idusuario", onekey);
                        cmd.Parameters.AddWithValue("@login", usuario);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                mostrar();
            }
        }
    }
}
