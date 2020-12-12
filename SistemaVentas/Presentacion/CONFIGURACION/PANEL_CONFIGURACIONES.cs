using SistemaVentas.Datos;
using SistemaVentas.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaVentas.Presentacion.CONFIGURACION
{
    public partial class PANEL_CONFIGURACIONES : Form
    {
        public PANEL_CONFIGURACIONES()
        {
            InitializeComponent();
        }

        int idRol;
        string Rol;
        string Operacion;
        string modulo;
        string Acceso;

        private void Button6_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in datalistado.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario == idusuarioBuscar)
                {
                    if (modulo == "Productos")
                    {
                        if (Operacion == "ACCESO")
                        {
                            PRODUCTOS_OK.Productos_ok frm = new PRODUCTOS_OK.Productos_ok();
                            frm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Acceso restringido\nComunicate con tu administrador", "Panel de Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

            }
            
        }

       

    

     
        private void Logo_empresa_Click(object sender, EventArgs e)
        {
            Configurar_empresa();

        }

        private void Configurar_empresa()
        {
            foreach (DataGridViewRow row in datalistado.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario == idusuarioBuscar)
                {
                    if (modulo == "Empresa")
                    {
                        if (Operacion == "ACCESO")
                        {
                            ASISTENTE_DE_INSTALACION_servidor.REGISTRO_DE_EMPRESA frm = new ASISTENTE_DE_INSTALACION_servidor.REGISTRO_DE_EMPRESA();
                            frm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Acceso restringido\nComunicate con tu administrador", "Panel de Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

            }
            
        }
        private void Label47_Click(object sender, EventArgs e)
        {
            Configurar_empresa();
        }

        public static int idusuario;
        public bool AccesoUsuarios;
        private void PANEL_CONFIGURACIONES_Load(object sender, EventArgs e)
        {
 
            Obtener_datos.mostrar_inicio_De_sesion(ref idusuario);
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("obtenerAccesoUsuarios", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idUsuario", idusuario);
                da.Fill(dt);
                datalistado.DataSource = dt;
                con.Close();
                datalistado.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Bases.Multilinea(ref datalistado);

        }

       

        private void Button1_Click(object sender, EventArgs e)
        {
            Usuarios();
        }
        private void Usuarios()
        {
            foreach (DataGridViewRow row in datalistado.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario == idusuarioBuscar)
                {
                    if(modulo == "Usuarios")
                    {
                        if(Operacion == "ACCESO")
                        {
                            usuariosok frm = new usuariosok();
                            frm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Acceso restringido\nComunicate con tu administrador", "Panel de Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

            }
        }

        private void Label26_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in datalistado.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario == idusuarioBuscar)
                {
                    if (modulo == "Usuarios")
                    {
                        if (Operacion == "ACCESO")
                        {
                            Usuarios();
                        }
                        else
                        {
                            MessageBox.Show("Acceso restringido\nComunicate con tu administrador", "Panel de Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            mostrar_cajas();
        }
        private void mostrar_cajas()
        {
            foreach (DataGridViewRow row in datalistado.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario == idusuarioBuscar)
                {
                    if (modulo == "Cajas")
                    {
                        if (Operacion == "ACCESO")
                        {
                            CAJA.Cajas_form frm = new CAJA.Cajas_form();
                            frm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Acceso restringido\nComunicate con tu administrador", "Panel de Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

            }

        }

        private void Label27_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in datalistado.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario == idusuarioBuscar)
                {
                    if (modulo == "Cajas")
                    {
                        if (Operacion == "ACCESO")
                        {
                            Dispose();
                            CAJA.Cajas_form frm = new CAJA.Cajas_form();
                            frm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Acceso restringido\nComunicate con tu administrador", "Panel de Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in datalistado.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario == idusuarioBuscar)
                {
                    if (modulo == "Clientes")
                    {
                        if (Operacion == "ACCESO")
                        {
                            CLIENTES_PROVEEDORES.ClientesOk frm = new CLIENTES_PROVEEDORES.ClientesOk();
                            frm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Acceso restringido\nComunicate con tu administrador", "Panel de Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

            }

            
        
        }

        private void btnproveedores_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in datalistado.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario == idusuarioBuscar)
                {
                    if (modulo == "Proveedores")
                    {
                        if (Operacion == "ACCESO")
                        {
                            CLIENTES_PROVEEDORES.Proveedores frm = new CLIENTES_PROVEEDORES.Proveedores();
                            frm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Acceso restringido\nComunicate con tu administrador", "Panel de Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

            }
        }

        private void btncorreo_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in datalistado.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario == idusuarioBuscar)
                {
                    if (modulo == "Notificaciones")
                    {
                        if (Operacion == "ACCESO")
                        {
                            Presentacion.CorreoBase.ConfigurarCorreo frm = new Presentacion.CorreoBase.ConfigurarCorreo();
                            frm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Acceso restringido\nComunicate con tu administrador", "Panel de Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

            }
           
        }

        private void btnimpresoras_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in datalistado.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario == idusuarioBuscar)
                {
                    if (modulo == "Impresoras")
                    {
                        if (Operacion == "ACCESO")
                        {
                            Impresoras.Admin_impresoras frm = new Impresoras.Admin_impresoras();
                            frm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Acceso restringido\nComunicate con tu administrador", "Panel de Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

            }

            
        }

        private void btndiseñador_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in datalistado.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario == idusuarioBuscar)
                {
                    if (modulo == "Comprobantes")
                    {
                        if (Operacion == "ACCESO")
                        {
                            DISEÑADOR_DE_COMPROBANTES.Ticket frm = new DISEÑADOR_DE_COMPROBANTES.Ticket();
                            frm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Acceso restringido\nComunicate con tu administrador", "Panel de Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

            }
           
        }

        private void ToolStripButton22_Click(object sender, EventArgs e)
        {
            
           
        }

        private void btnRespaldos_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in datalistado.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario == idusuarioBuscar)
                {
                    if (modulo == "BackUp")
                    {
                        if (Operacion == "ACCESO")
                        {
                            CopiasBd.CrearCopiaBd frm = new CopiasBd.CrearCopiaBd();
                            frm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Acceso restringido\nComunicate con tu administrador", "Panel de Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

            }
           
        }

        private void PANEL_CONFIGURACIONES_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (DataGridViewRow row in datalistado.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario == idusuarioBuscar)
                {
                    if (modulo == "Dashboard")
                    {
                        if (Operacion == "ACCESO")
                        {
                            Dispose();
                            Admin_nivel_dios.DASHBOARD_PRINCIPAL frm = new Admin_nivel_dios.DASHBOARD_PRINCIPAL();
                            frm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Acceso restringido\nComunicate con tu administrador", "Panel de Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

            }
            
        }

        private void btnBalanza_Click(object sender, EventArgs e)
        {

            BalanzaElectronica.BalanzaForm frm = new BalanzaElectronica.BalanzaForm();
            frm.ShowDialog();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in datalistado.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario == idusuarioBuscar)
                {
                    if (modulo == "Serializacion")
                    {
                        if (Operacion == "ACCESO")
                        {
                            SERIALIZACION_DE_COMPROBANTES.SERIALIZACION frm = new SERIALIZACION_DE_COMPROBANTES.SERIALIZACION();
                            frm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Acceso restringido\nComunicate con tu administrador", "Panel de Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in datalistado.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario == idusuarioBuscar)
                {
                    if (modulo == "Empleados")
                    {
                        if (Operacion == "ACCESO")
                        {
                            Empleados.EmpleadosOK frm = new Empleados.EmpleadosOK();
                            frm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Acceso restringido\nComunicate con tu administrador", "Panel de Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in datalistado.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario == idusuarioBuscar)
                {
                    if (modulo == "Vehiculos")
                    {
                        if (Operacion == "ACCESO")
                        {
                            Vehiculos.Vehiculos frm = new Vehiculos.Vehiculos();
                            frm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Acceso restringido\nComunicate con tu administrador", "Panel de Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

            }
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in datalistado.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario == idusuarioBuscar)
                {
                    if (modulo == "Impuestos")
                    {
                        if (Operacion == "ACCESO")
                        {
                            Impuestos.Impuestos frm = new Impuestos.Impuestos();
                            frm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Acceso restringido\nComunicate con tu administrador", "Panel de Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

            }
            
        }

        private void label12_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in datalistado.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario == idusuarioBuscar)
                {
                    if (modulo == "Impuestos")
                    {
                        if (Operacion == "ACCESO")
                        {
                            Impuestos.Impuestos frm = new Impuestos.Impuestos();
                            frm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Acceso restringido\nComunicate con tu administrador", "Panel de Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }

             
        }

        private void button7_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in datalistado.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario == idusuarioBuscar)
                {
                    if (modulo == "Almacen")
                    {
                        if (Operacion == "ACCESO")
                        {
                            Almacenes.Almacenes frm = new Almacenes.Almacenes();
                            frm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Acceso restringido\nComunicate con tu administrador", "Panel de Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }

                
        }

        private void label13_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in datalistado.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario == idusuarioBuscar)
                {
                    if (modulo == "Almacen")
                    {
                        if (Operacion == "ACCESO")
                        {
                            Almacenes.Almacenes frm = new Almacenes.Almacenes();
                            frm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Acceso restringido\nComunicate con tu administrador", "Panel de Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
          
        }

        private void button9_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in datalistado.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario == idusuarioBuscar)
                {
                    if (modulo == "Unidades")
                    {
                        if (Operacion == "ACCESO")
                        {
                            Unidades.Unidades frm = new Unidades.Unidades();
                            frm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Acceso restringido\nComunicate con tu administrador", "Panel de Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Unidades.Unidades frm = new Unidades.Unidades();
            frm.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in datalistado.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario == idusuarioBuscar)
                {
                    if (modulo == "Descuentos")
                    {
                        if (Operacion == "ACCESO")
                        {
                            Descuento.Descuento frm = new Descuento.Descuento();
                            frm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Acceso restringido\nComunicate con tu administrador", "Panel de Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
           
        }

        private void button11_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in datalistado.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario == idusuarioBuscar)
                {
                    if (modulo == "Categorias")
                    {
                        if (Operacion == "ACCESO")
                        {
                            Categoria.Categoria frm = new Categoria.Categoria();
                            frm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Acceso restringido\nComunicate con tu administrador", "Panel de Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            
        }

        private void Label8_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in datalistado.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario == idusuarioBuscar)
                {
                    if (modulo == "Proveedores")
                    {
                        if (Operacion == "ACCESO")
                        {
                            CLIENTES_PROVEEDORES.Proveedores frm = new CLIENTES_PROVEEDORES.Proveedores();
                            frm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Acceso restringido\nComunicate con tu administrador", "Panel de Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

            }
        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in datalistado.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario == idusuarioBuscar)
                {
                    if (modulo == "Roles")
                    {
                        if (Operacion == "ACCESO")
                        {
                            Roles.Roles frm = new Roles.Roles();
                            frm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Acceso restringido\nComunicate con tu administrador", "Panel de Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            FacturasCredito.FacturasCredito frm = new FacturasCredito.FacturasCredito();
            frm.ShowDialog();
        }

        private void label19_Click(object sender, EventArgs e)
        {
            FacturasCredito.FacturasCredito frm = new FacturasCredito.FacturasCredito();
            frm.ShowDialog();
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in datalistado.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario == idusuarioBuscar)
                {
                    if (modulo == "Dashboard")
                    {
                        if (Operacion == "ACCESO")
                        {
                            Dispose();
                            Admin_nivel_dios.DASHBOARD_PRINCIPAL frm = new Admin_nivel_dios.DASHBOARD_PRINCIPAL();
                            frm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Acceso restringido\nComunicate con tu administrador", "Panel de Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

            }
        }

        private void Minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;

        }
    }
}
