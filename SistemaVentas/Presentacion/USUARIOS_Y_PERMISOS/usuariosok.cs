using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing;
using SistemaVentas.Logica;


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
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Cargar_estado_de_iconos()
        {
            try
            {
                foreach (DataGridViewRow row in datalistado.Rows)
                {

                    try
                    {

                        string Icono = Convert.ToString(row.Cells["Nombre_de_icono"].Value);

                        if (Icono == "1" )
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
                        else if (Icono =="5")
                        {
                            pictureBox7.Visible = false;
                        }
                        else if (Icono == "6")
                        {
                            pictureBox8.Visible = false;
                        }
                        else if (Icono == "7")
                        {
                            pictureBox9.Visible = false;
                        }
                        else if (Icono == "8")
                        {
                            pictureBox10.Visible = false;
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
        private void btnGuardar_Click(object sender, EventArgs e)
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
                                cmd = new SqlCommand("insertar_usuario", con);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                                cmd.Parameters.AddWithValue("@Login", txtlogin.Text);
                                cmd.Parameters.AddWithValue("@Password", Bases.Encriptar(txtPassword.Text));
                                cmd.Parameters.AddWithValue("@idRol", Convert.ToInt32(txtroles.SelectedValue));
                                ICONO.Image.Save(ms, ICONO.Image.RawFormat);
                                cmd.Parameters.AddWithValue("@Icono", ms.GetBuffer());
                                cmd.Parameters.AddWithValue("@Nombre_de_icono", lblnumeroIcono.Text);
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
        private void mostrarRoles()
        {


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
            datalistado.DataSource = dt;
            con.Close();

                datalistado.Columns[1].Visible = false;
                datalistado.Columns[2].Visible = false;
                datalistado.Columns[3].Visible = false;
                datalistado.Columns[9].Visible = false;
                datalistado.Columns[10].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            Bases.Multilinea(ref datalistado  );

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox3.Image;
            lblnumeroIcono.Text = "1";
            LblAnuncioIcono.Visible = false;
            panelICONO.Visible = false;

        }

        private void LblAnuncioIcono_Click(object sender, EventArgs e)
        {
            Cargar_estado_de_iconos();
            panelICONO.Visible = true;
            panelICONO.Dock = DockStyle.Fill;


        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox4.Image;
            lblnumeroIcono.Text = "2";
            LblAnuncioIcono.Visible = false;
            panelICONO.Visible = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox5.Image;
            lblnumeroIcono.Text = "3";
            LblAnuncioIcono.Visible = false;
            panelICONO.Visible = false;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox6.Image;
            lblnumeroIcono.Text = "4";
            LblAnuncioIcono.Visible = false;
            panelICONO.Visible = false;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox7.Image;
            lblnumeroIcono.Text = "5";
            LblAnuncioIcono.Visible = false;
            panelICONO.Visible = false;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox8.Image;
            lblnumeroIcono.Text = "6";
            LblAnuncioIcono.Visible = false;
            panelICONO.Visible = false;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox9.Image;
            lblnumeroIcono.Text = "7";
            LblAnuncioIcono.Visible = false;
            panelICONO.Visible = false;
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox10.Image;
            lblnumeroIcono.Text = "8";
            LblAnuncioIcono.Visible = false;
            panelICONO.Visible = false;
        }

        private void usuariosok_Load(object sender, EventArgs e)
        {
            LRoles cat = new LRoles();
            panelDataListadoEmpleado.Visible = false;
            panelRegistros.Visible = false;
            panelICONO.Visible = false;
            mostrar();

            txtroles.DataSource = cat.CargarCombo();
            txtroles.DisplayMember = "Rol";
            txtroles.ValueMember = "idRol";
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            panelRegistros.Visible = true;
            panelRegistros.Dock = DockStyle.Fill;
            panelNuevo.Visible = false;
            LblAnuncioIcono.Visible = true;
            txtEmpleado.Text = "";
            txtlogin.Text = "";
            txtPassword.Text = "";
            btnGuardar.Visible = true;
            btnGuardarCambios.Visible = false;
        }

        private void datalistado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void datalistado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lblId_usuario.Text = datalistado.SelectedCells[1].Value.ToString();
            idEmpleado1 = Convert.ToInt32(datalistado.SelectedCells[2].Value);
            txtEmpleado.Text = datalistado.SelectedCells[4].Value.ToString();
            txtlogin.Text = datalistado.SelectedCells[6].Value.ToString();
            txtPassword .Text = datalistado.SelectedCells[7].Value.ToString();
            ICONO.BackgroundImage = null;
            txtroles.Text = datalistado.SelectedCells[8].Value.ToString();
            lblnumeroIcono.Text = datalistado.SelectedCells[9].Value.ToString();
            byte[] b = (Byte[])datalistado.SelectedCells[10].Value;
            MemoryStream ms = new MemoryStream(b);
            ICONO.Image = Image.FromStream(ms);
            LblAnuncioIcono.Visible = false;
            panelRegistros.Visible = true;
            panelRegistros.Dock = DockStyle.Fill;
            panelNuevo.Visible = false;
            btnGuardar.Visible = false;
            btnGuardarCambios.Visible = true;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            panelRegistros.Visible = false;
            panelNuevo.Visible = true;
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (txtEmpleado.Text != "")
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
                    cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado1);
                    cmd.Parameters.AddWithValue("@Login", txtlogin.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@idRol", Convert.ToInt32(txtroles.SelectedValue));
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
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
        }

        private void ICONO_Click(object sender, EventArgs e)
        {
            Cargar_estado_de_iconos();
            panelICONO.Visible = true;
            panelICONO.Dock = DockStyle.Fill;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void datalistado_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == this.datalistado.Columns["Eli"].Index)
            {
                DialogResult result;
                result = MessageBox.Show("¿Realmente desea eliminar este Usuario?", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                  
                    try
                    {
                        foreach (DataGridViewRow row in datalistado.SelectedRows)
                        {

                            int onekey = Convert.ToInt32(row.Cells["idUsuario"].Value);
                            string usuario = Convert.ToString(row.Cells["Login"].Value);

                            try
                            {

                                try
                                {
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
                            catch (Exception ex)
                            {

                                MessageBox.Show(ex.Message);
                            }

                        }
                        mostrar();
                    }

#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
                    catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
                    {

                    }
                }
            }


            

            
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
                datalistado.DataSource = dt;
                con.Close();

                datalistado.Columns[1].Visible = false;
                datalistado.Columns[2].Visible = false;
                datalistado.Columns[3].Visible = false;
                datalistado.Columns[9].Visible = false;
                datalistado.Columns[10].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            Bases.Multilinea(ref datalistado);

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

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

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
    }
}
