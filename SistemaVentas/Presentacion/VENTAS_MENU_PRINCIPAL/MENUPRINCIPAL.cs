using SistemaVentas.Datos;
using SistemaVentas.Presentacion.Admin_nivel_dios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaVentas.Presentacion.VENTAS_MENU_PRINCIPAL
{
    public partial class MENUPRINCIPAL : Form
    {
        public MENUPRINCIPAL()
        {
            InitializeComponent();
        }

        public static int idusuario_que_inicio_sesion;

        private void MENUPRINCIPAL_Load(object sender, EventArgs e)
        {
            Obtener_datos.mostrar_inicio_De_sesion(ref idusuario_que_inicio_sesion);
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("obtenerAccesoUsuarios", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idUsuario", idusuario_que_inicio_sesion);
                da.Fill(dt);
                datalistadousuario.DataSource = dt;
                con.Close();
                datalistadousuario.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            ventas();
           
        }
      
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            selectedBotons((Bunifu.Framework.UI.BunifuFlatButton)sender);
            arrowGuide((Bunifu.Framework.UI.BunifuFlatButton)sender);

            int idRol;
            string Rol;
            string modulo;
            string Operacion;

            foreach (DataGridViewRow row in datalistadousuario.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario_que_inicio_sesion == idusuarioBuscar)
                {
                    if (modulo == "Configuracion")
                    {
                        if (Operacion == "ACCESO")
                        {
                            Dispose();
                            DASHBOARD_PRINCIPAL frm = new DASHBOARD_PRINCIPAL();
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

        private void btnProducts_Click(object sender, EventArgs e)
        {
            selectedBotons((Bunifu.Framework.UI.BunifuFlatButton)sender);
            arrowGuide((Bunifu.Framework.UI.BunifuFlatButton)sender);
            showFormInWrapper(new Presentacion.PRODUCTOS_OK.Productos_ok());

            //showFormInWrapper(new productsView());
        }

        private Form FormActive = null;

        private void showFormInWrapper(Form FormSon)
        {
            if (FormActive != null)
                FormActive.Close();
            FormActive = FormSon;
            FormSon.TopLevel = false;
            FormSon.Dock = DockStyle.Fill;
            wrapper.Controls.Add(FormSon);
            wrapper.Tag = FormSon;
            FormSon.BringToFront();
            FormSon.Show();
        }
        private void btnSales_Click(object sender, EventArgs e)
        {
            selectedBotons((Bunifu.Framework.UI.BunifuFlatButton)sender);
            arrowGuide((Bunifu.Framework.UI.BunifuFlatButton)sender);
            ventas();
        }
        private void ventas( )
        {
            int idRol;
            string Rol;
            string modulo;
            string Operacion;

            foreach (DataGridViewRow row in datalistadousuario.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario_que_inicio_sesion == idusuarioBuscar)
                {
                    if (modulo == "Ventas")
                    {
                        if (Operacion == "ACCESO")
                        {
                            showFormInWrapper(new Presentacion.VENTAS_MENU_PRINCIPAL.VENTAS_MENU_PRINCIPALOK());
                        }
                        else
                        {
                            MessageBox.Show("Acceso restringido\nComunicate con tu administrador", "Panel de Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

            }
        }
        public void arrowGuide(Bunifu.Framework.UI.BunifuFlatButton sender)
        {
            arrow.Top = sender.Top;
        }
        public void selectedBotons(Bunifu.Framework.UI.BunifuFlatButton sender)
        {
            btnDashboard.Textcolor = Color.WhiteSmoke;
            btnProducts.Textcolor = Color.WhiteSmoke;
            btnSales.Textcolor = Color.WhiteSmoke;
            btnBuy.Textcolor = Color.WhiteSmoke;
            btnWork.Textcolor = Color.WhiteSmoke;
            btnClients.Textcolor = Color.WhiteSmoke;
            btnProvs.Textcolor = Color.WhiteSmoke;
            btnMoney.Textcolor = Color.WhiteSmoke;

            sender.selected = true;

            if (sender.selected)
            {
                sender.Textcolor = Color.FromArgb(98, 195, 140);
            }
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            selectedBotons((Bunifu.Framework.UI.BunifuFlatButton)sender);
            arrowGuide((Bunifu.Framework.UI.BunifuFlatButton)sender);

            int idRol;
            string Rol;
            string modulo;
            string Operacion;

            foreach (DataGridViewRow row in datalistadousuario.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario_que_inicio_sesion == idusuarioBuscar)
                {
                    if (modulo == "Compras")
                    {
                        if (Operacion == "ACCESO")
                        {
                            showFormInWrapper(new Compras_proveedor.Compras_proveedor());
                        }
                        else
                        {
                            MessageBox.Show("Acceso restringido\nComunicate con tu administrador", "Panel de Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

            }

        }

        private void btnWork_Click(object sender, EventArgs e)
        {
            selectedBotons((Bunifu.Framework.UI.BunifuFlatButton)sender);
            arrowGuide((Bunifu.Framework.UI.BunifuFlatButton)sender);
            int idRol;
            string Rol;
            string modulo;
            string Operacion;

            foreach (DataGridViewRow row in datalistadousuario.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario_que_inicio_sesion == idusuarioBuscar)
                {
                    if (modulo == "Empleados")
                    {
                        if (Operacion == "ACCESO")
                        {
                            showFormInWrapper(new Presentacion.Empleados.EmpleadosOK());
                        }
                        else
                        {
                            MessageBox.Show("Acceso restringido\nComunicate con tu administrador", "Panel de Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

            }
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            selectedBotons((Bunifu.Framework.UI.BunifuFlatButton)sender);
            arrowGuide((Bunifu.Framework.UI.BunifuFlatButton)sender);
            int idRol;
            string Rol;
            string modulo;
            string Operacion;

            foreach (DataGridViewRow row in datalistadousuario.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario_que_inicio_sesion == idusuarioBuscar)
                {
                    if (modulo == "Clientes")
                    {
                        if (Operacion == "ACCESO")
                        {
                            showFormInWrapper(new Presentacion.CLIENTES_PROVEEDORES.ClientesOk());
                        }
                        else
                        {
                            MessageBox.Show("Acceso restringido\nComunicate con tu administrador", "Panel de Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

            }
        }

        private void btnProvs_Click(object sender, EventArgs e)
        {
            selectedBotons((Bunifu.Framework.UI.BunifuFlatButton)sender);
            arrowGuide((Bunifu.Framework.UI.BunifuFlatButton)sender);
            int idRol;
            string Rol;
            string modulo;
            string Operacion;

            foreach (DataGridViewRow row in datalistadousuario.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario_que_inicio_sesion == idusuarioBuscar)
                {
                    if (modulo == "Cotizacion")
                    {
                        if (Operacion == "ACCESO")
                        {
                            showFormInWrapper(new Presentacion.Cotizacion.Cotizaciones());
                        }
                        else
                        {
                            MessageBox.Show("Acceso restringido\nComunicate con tu administrador", "Panel de Configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

            }
        }

        private void btnMoney_Click(object sender, EventArgs e)
        {

            int idRol;
            string Rol;
            string modulo;
            string Operacion;

            foreach (DataGridViewRow row in datalistadousuario.Rows)
            {

                int idusuarioBuscar = Convert.ToInt32(row.Cells["idUsuario"].Value);
                idRol = Convert.ToInt32(row.Cells["idRol"].Value);
                Rol = Convert.ToString(row.Cells["Rol"].Value);
                modulo = Convert.ToString(row.Cells["Modulo"].Value);
                Operacion = Convert.ToString(row.Cells["Operacion"].Value);
                if (idusuario_que_inicio_sesion == idusuarioBuscar)
                {
                    if (modulo == "Cerrar turno")
                    {
                        if (Operacion == "ACCESO")
                        {
                            Dispose();
                            CAJA.CIERRE_DE_CAJA frm = new CAJA.CIERRE_DE_CAJA();
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

        private void Restaurar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            Restaurar.Visible = false;
            Maximizar.Visible = true;
        }

        private void Maximizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            Maximizar.Visible = false;
            Restaurar.Visible = true;
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MENUPRINCIPAL_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlgRes = MessageBox.Show("¿Realmente desea Cerrar el Sistema?", "Cerrando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlgRes == DialogResult.Yes)
            {
                Dispose();
                CopiasBd.GeneradorAutomatico frm = new CopiasBd.GeneradorAutomatico();
                frm.ShowDialog();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
