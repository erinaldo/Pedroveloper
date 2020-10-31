using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Management;
using SistemaVentas.Logica;
using SistemaVentas.Datos;

namespace SistemaVentas.Presentacion.ASISTENTE_DE_INSTALACION_servidor
{
    public partial class USUARIOS_AUTORIZADOS_AL_SISTEMA : Form
    {
        public USUARIOS_AUTORIZADOS_AL_SISTEMA()
        {
            InitializeComponent();
        }
        int idEmpleado;
        string lblIDSERIAL;
        private void USUARIOS_AUTORIZADOS_AL_SISTEMA_Load(object sender, EventArgs e)
        {
            Panel2.Location = new Point((Width - Panel2.Width) / 2, (Height - Panel2.Height) / 2);
            panelDataListadoEmpleados.Visible = false;

            Bases.Obtener_serialPC(ref lblIDSERIAL);
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text != "" && TXTCONTRASEÑA.Text != "" && TXTUSUARIO.Text != "")
              {
                if (TXTCONTRASEÑA.Text == txtconfirmarcontraseña.Text)
                    {
                    string contraseña_encryptada;
                    contraseña_encryptada = Bases.Encriptar(this.TXTCONTRASEÑA.Text.Trim());
                    try
                    {
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd = new SqlCommand("insertar_usuario", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                        cmd.Parameters.AddWithValue("@Login", TXTUSUARIO.Text);
                        cmd.Parameters.AddWithValue("@Password", contraseña_encryptada);
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        PictureBox2.Image.Save(ms, PictureBox2.Image.RawFormat);
                        cmd.Parameters.AddWithValue("@Icono", ms.GetBuffer());
                        cmd.Parameters.AddWithValue("@Rol", "Administrador (Control total)");
                        cmd.Parameters.AddWithValue("@Nombre_de_icono", "Pedroveloper");
                        cmd.Parameters.AddWithValue("@Estado", "ACTIVO");
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Insertar_licencia_de_prueba_30_dias();
                        insertar_cliente_standar();
                        insertar_grupo_por_defecto();
                        insertar_inicio_De_sesion();
                        MessageBox.Show("!LISTO! RECUERDA que para Iniciar Sesión tu Usuario es: " + TXTUSUARIO.Text + " y tu Contraseña es: " + TXTCONTRASEÑA.Text, "Registro Exitoso", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                        Dispose();
                        Presentacion.LOGIN frm = new Presentacion.LOGIN();
                        frm.ShowDialog();
                    }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
                    catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
                    {
                        //MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Las contraseñas no Coinciden", "Contraseñas Incompatibles", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                }
            }
            else
            {
                MessageBox.Show("Falta ingresar Datos", "Datos incompletos", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            }
        }
        private void Insertar_licencia_de_prueba_30_dias()
        {
            DateTime today = DateTime.Now;
            DateTime fechaFinal = today.AddDays(30);
            txtfechaFinalOK.Text = Convert.ToString(fechaFinal);
            string SERIALpC;
            SERIALpC = lblIDSERIAL;
            string FECHA_FINAL;
            FECHA_FINAL = Bases.Encriptar(this.txtfechaFinalOK.Text.Trim());
            string estado;
            estado = Bases.Encriptar("?ACTIVO?");
            string fecha_activacion;
            fecha_activacion = Bases.Encriptar(this.txtfechaInicio.Text.Trim());


            try
            {


                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("Insertar_marcan", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@s", SERIALpC);
                cmd.Parameters.AddWithValue("@f", FECHA_FINAL);
                cmd.Parameters.AddWithValue("@e", estado);
                cmd.Parameters.AddWithValue("@fa", fecha_activacion);
                cmd.ExecuteNonQuery();
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void insertar_cliente_standar()
        {
            try
            {


                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("insertar_clientes", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPersona", 1);
                cmd.Parameters.AddWithValue("@IdentificadorFiscal", "-");
                cmd.Parameters.AddWithValue("@Estado ", 0);
                cmd.Parameters.AddWithValue("@Saldo", 0);

                cmd.ExecuteNonQuery();
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void insertar_grupo_por_defecto()
        {
            try
            {


                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("insertar_Grupo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Grupo", "General");
                cmd.Parameters.AddWithValue("@Por_defecto", "Si");
               
                cmd.ExecuteNonQuery();
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void insertar_inicio_De_sesion()
        {
            try
            {

                string serialPC;
                serialPC = lblIDSERIAL;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("insertar_inicio_De_sesion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_serial_Pc", serialPC);

                cmd.ExecuteNonQuery();
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {
            buscar();
            if (txtnombre.TextLength > 0)
            {
                panelDataListadoEmpleados.Visible = true;
            }
            else
            {
                panelDataListadoEmpleados.Visible = false;
            }
        }

        private void buscar()
        {
            DataTable dt = new DataTable();
            Obtener_datos.buscar_empleados(ref dt, txtnombre.Text);
            datalistadoEmpleado.DataSource = dt;
            if(datalistadoEmpleado.Rows.Count > 0)
            {
                pintarDatalistado();
            }
            else
            {

            }
        }

        private void pintarDatalistado()
        {

            Bases.Multilinea(ref datalistadoEmpleado);
            datalistadoEmpleado.Columns[0].Visible = false;
            datalistadoEmpleado.Columns[1].Visible = false;
            datalistadoEmpleado.Columns[2].Visible = false;
            datalistadoEmpleado.Columns[7].Visible = false;
            datalistadoEmpleado.Columns[9].Visible = false;
            datalistadoEmpleado.Columns[12].Visible = false;

            datalistadoEmpleado.Columns[14].Visible = false;
            datalistadoEmpleado.Columns[18].Visible = false;
            datalistadoEmpleado.Columns[23].Visible = false;
        }
        private void datalistadoEmpleado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idEmpleado = Convert.ToInt32(datalistadoEmpleado.SelectedCells[0].Value);
            txtnombre.Text = datalistadoEmpleado.SelectedCells[3].Value.ToString();
            panelDataListadoEmpleados.Visible = false;
        }
    }
}
