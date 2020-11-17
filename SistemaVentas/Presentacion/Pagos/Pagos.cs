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

namespace SistemaVentas.Presentacion.Pagos
{ 
    public partial class Pagos : Form
    {
        public Pagos()
        {
            InitializeComponent();
        }
        public static  int idProveedor;
        public static    double saldo;
        private void Label21_Click(object sender, EventArgs e)
        {

        }

        private void txtclientesolicitante_TextChanged(object sender, EventArgs e)
        {
            buscar();
        }
        private void buscar()
        {
            DataTable dt = new DataTable();
            Obtener_datos.Buscar_proveedores_(ref dt, txtproveedorc.Text);
            datalistadoProveedores.DataSource = dt;
            datalistadoProveedores.Columns[0].Visible = false;

            datalistadoProveedores.Columns[1].Visible = false;
            datalistadoProveedores.Columns[3].Visible = false;
            datalistadoProveedores.Columns[4].Visible = false;
            datalistadoProveedores.Columns[5].Visible = false;
            datalistadoProveedores.Columns[6].Visible = false;
            datalistadoProveedores.Columns[7].Visible = false;
            datalistadoProveedores.Columns[2].Width = datalistadoProveedores.Width;
            datalistadoProveedores.BringToFront();
            datalistadoProveedores.Visible = true;
            datalistadoProveedores.Location = new Point(panelRegistros.Location.X, panelRegistros.Location.Y);
            datalistadoProveedores.Size= new Size (538, 220);
            panelRegistros.Visible = false;
        }

        private void datalistadoClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            idProveedor =(int)datalistadoProveedores.SelectedCells[1].Value;
            txtproveedorc.Text = datalistadoProveedores.SelectedCells[2].Value.ToString();
            obtenerSaldo();
            datalistadoProveedores.Visible = false;
            panelRegistros.Visible = true;
            mostrarEstadosCuentaCliente();

        }
        private void obtenerSaldo()
        {
            txttotal_saldo.Text= datalistadoProveedores.SelectedCells[7].Value.ToString();
            saldo = Convert.ToDouble ( datalistadoProveedores.SelectedCells[7].Value);
        }
            
        private void mostrarEstadosCuentaCliente()
        {
            DataTable dt = new DataTable();
            Obtener_datos.mostrarEstadosCuentaProveedor(ref dt, idProveedor);
            datalistadoHistorial.DataSource = dt;
            Bases estilo = new Bases();
            estilo.MultilineaCobros (ref datalistadoHistorial); 
            panelH.Visible = true;
            panelM.Visible = false;
            panelHistorial.Visible = true;
            panelHistorial.Dock = DockStyle.Fill;
            panelMovimientos.Visible = false;
            panelMovimientos.Dock = DockStyle.None;
        }

        private void CobrosForm_Load(object sender, EventArgs e)
        {
            txtproveedorc.Focus();
            centrarPanel();
        }
        private void centrarPanel()
        {
            PanelContenedor.Location = new Point((Width - PanelContenedor.Width) / 2, (Height - PanelContenedor.Height) / 2);
        }
        private void btnMovimientos_Click(object sender, EventArgs e)
        {
            mostrarControlCobros();
        }
        private void mostrarControlCobros()
        {
            DataTable dt = new DataTable();
            Obtener_datos.mostrarControlPago(ref dt);
            datalistadoMovimientos.DataSource = dt;
            Bases estilo = new Bases();
            estilo.MultilineaCobros(ref datalistadoMovimientos);
            datalistadoMovimientos.Columns[1].Visible = false;
            datalistadoMovimientos.Columns[5].Visible = false;
            datalistadoMovimientos.Columns[6].Visible = false;
            datalistadoMovimientos.Columns[7].Visible = false;

            panelH.Visible = false;
            panelM.Visible = true;
            panelHistorial.Visible = false;
            panelMovimientos.Visible = true;
            panelMovimientos.Dock = DockStyle.Fill;
            panelHistorial.Dock = DockStyle.None;
        }

        private void btnhistorial_Click(object sender, EventArgs e)
        {
            mostrarEstadosCuentaCliente();
        }

        private void btnabonar_Click(object sender, EventArgs e)
        {
            if (saldo >0 )
            {
            MediosPagos.MediosPagos frm = new MediosPagos.MediosPagos();
            frm.FormClosing += Frm_FormClosing;
            frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("El saldo del cliente actual es 0");
            }
           
        }

        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            buscar();
            obtenerSaldo();
            mostrarControlCobros();
        }

        private void txtclientesolicitante_Click(object sender, EventArgs e)
        {
            txtproveedorc.SelectAll();
        }

        int idControlPago;
        private void datalistadoMovimientos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Lcontrolpagos parametros = new Lcontrolpagos();
            idControlPago = Convert.ToInt32(datalistadoMovimientos.SelectedCells[1].Value);
            if (e.ColumnIndex == datalistadoMovimientos.Columns ["Eli"].Index )
            {
                DialogResult result= MessageBox.Show("¿Realmente desea eliminar esta Abono?", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
               if (result == DialogResult.OK )
                {
                    aumentarSaldo();
                }
            }
        }
        private void aumentarSaldo()
        {
            double monto;
            monto = Convert.ToDouble(datalistadoMovimientos.SelectedCells[2].Value);
            Lproveedores parametros = new Lproveedores();
            Editar_datos funcion = new Editar_datos();
            parametros.IdProveedor = idProveedor;
            if (funcion.aumentarSaldoProveedor(parametros, monto) == true)
            {
                eliminarControlCobros();
            }

        }
        private void eliminarControlCobros()
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("Eliminarcontrolpago", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcontrol", idControlPago);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
            buscar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void datalistadoProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
