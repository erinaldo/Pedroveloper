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

namespace SistemaVentas.Presentacion.FacturasCredito
{ 
    public partial class FacturasCredito : Form
    {
        public FacturasCredito()
        {
            InitializeComponent();
        
        }
        public static  int idProveedor;
        public static  int idFact;
        public static  string numFact;
        public static    double saldo;
        private int idProveedor_;
        public string numFactMov;
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
            datalistadoProveedores.Columns[8].Visible = false;
            datalistadoProveedores.Columns[7].Visible = false;
            datalistadoProveedores.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            datalistadoProveedores.Columns[2].Width = datalistadoProveedores.Width;
            datalistadoProveedores.BringToFront();
            datalistadoProveedores.Visible = true;
            datalistadoProveedores.Location = new Point(panelRegistros.Location.X, panelRegistros.Location.Y);
            datalistadoProveedores.Size= new Size (538, 220);
            panelRegistros.Visible = false;
        }

        private void datalistadoClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idProveedor = (int)datalistadoProveedores.SelectedCells[1].Value;
            txtproveedorc.Text = datalistadoProveedores.SelectedCells[2].Value.ToString(); 
            datalistadoProveedores.Visible = false;
            panelRegistros.Visible = true;
            mostrarEstadosCuentaCliente();
        }
     
            
        private void mostrarEstadosCuentaCliente()
        {
            DataTable dt = new DataTable();
            Obtener_datos.mostrarEstadosFacturas(ref dt, idProveedor);
            datalistadoHistorial.DataSource = dt;
            datalistadoHistorial.Columns[1].Visible = false;
            datalistadoHistorial.Columns[9].Visible = false;
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
            panelFacturas.Visible = false;
            panelProveedor.Visible = false;
            txtTipo.SelectedIndex = 0;
            panelRegistro.Visible = false;
            txtproveedorc.Focus();
            centrarPanel();
        }
        private void centrarPanel()
        {
            PanelContenedor.Location = new Point((Width - PanelContenedor.Width) / 2, (Height - PanelContenedor.Height) / 2);
        }
        private void btnMovimientos_Click(object sender, EventArgs e)
        {
            //BuscarfactsProveedores
            panelFacturas.Visible = true;
            panelH.Visible = false;
            panelM.Visible = true;

            panelHistorial.Visible = false;
            panelMovimientos.Visible = true;

            panelMovimientos.Dock = DockStyle.Fill;
            panelHistorial.Dock = DockStyle.None;

            txttotal_saldo.Text = "0";
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlDataAdapter da = new SqlDataAdapter("BuscarfactsProveedores", CONEXIONMAESTRA.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idProveedor", Convert.ToInt32(idProveedor));
                DataTable dt = new DataTable();
                da.Fill(dt);
                CONEXIONMAESTRA.cerrar();
                
                txtFactura.DisplayMember = "NumFactura";
                txtFactura.ValueMember = "idFactura";
               
                txtFactura.DataSource = dt;
            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.Message);
            }
            if (datalistadoMovimientos.Rows.Count > 0)
                datalistadoMovimientos.Visible = false;
            //datalistadoMovimientos.Rows.Clear();
            //datalistadoMovimientos.Refresh();
        }
       
        private void mostrarControlCobros()
        {

            DataTable dt = new DataTable();
            Obtener_datos.mostrarControlPagosFacturas(ref dt, numFactMov);
            datalistadoMovimientos.DataSource = dt;
            Bases estilo = new Bases();
            estilo.MultilineaCobros(ref datalistadoMovimientos);
            datalistadoMovimientos.Columns[2].Visible = false;
            datalistadoMovimientos.Columns[6].Visible = false;
            datalistadoMovimientos.Columns[7].Visible = false;
            datalistadoMovimientos.Columns[8].Visible = false;
            //Datagridview.Columns.Clear()
            //datalistadoMovimientos.Columns[12].Visible = false;

        }

        private void btnhistorial_Click(object sender, EventArgs e)
        {
            mostrarEstadosCuentaCliente();
            panelFacturas.Visible = false;

            if (datalistadoMovimientos.Rows.Count > 0)
                datalistadoMovimientos.Visible = false;
            //datalistadoMovimientos.Columns.Clear();
            //datalistadoMovimientos.Refresh();

            txtFactura.Text = "";
        }

        private void btnabonar_Click(object sender, EventArgs e)
        {
            if (saldo > 0)
            {
                txttotal_saldo.Text = "0";
                MediosPagoFacturaCredito.MediosPagoFacturaCredito frm = new MediosPagoFacturaCredito.MediosPagoFacturaCredito();
                frm.FormClosing += Frm_FormClosing;
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("El saldo actual es 0");
            }

        }

        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            buscar();
            mostrarControlCobros();
        }

        private void txtclientesolicitante_Click(object sender, EventArgs e)
        {
            txtproveedorc.SelectAll();
        }

        int idControlPago;
        

        private void datalistadoMovimientos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToInt32(datalistadoMovimientos.SelectedCells[1].Value) > 0)
            {
                Lcontrolpagos parametros = new Lcontrolpagos();
                idControlPago = Convert.ToInt32(datalistadoMovimientos.SelectedCells[1].Value);
                if (e.ColumnIndex == datalistadoMovimientos.Columns["Eli"].Index)
                {
                    DialogResult result = MessageBox.Show("¿Realmente desea eliminar esta Abono?", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        aumentarSaldo();
                    }
                }
            }
        }

        private void aumentarSaldo()
        {
            LSaldo lsaldo = new LSaldo();
            double monto;
            monto = Convert.ToDouble(datalistadoMovimientos.SelectedCells[4].Value);
            Editar_datos funcion = new Editar_datos();
            lsaldo.numFact = numFact;
            lsaldo.monto = monto;
            if (funcion.aumentarSaldoFactura(lsaldo) == true)
            {
                eliminarControlCobros();
            }
        }
        private void eliminarControlCobros()
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("Eliminarfactexterna", CONEXIONMAESTRA.conectar);
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

        private void GuardarFactura_Click(object sender, EventArgs e)
        {
            TextBox[] array = { txtTotal, txtNumPed, txtNumFact};
            if (Insertar_datos.ValidTextIsNotNullOrEmpty(array))
            {
                insertarFactura();
                txtproveedorc.SelectAll();
                txtproveedorc.Focus();
            }
        }

        private void insertarFactura()
        {
            if (idProveedor_ != 0)
            {

                try
                {
                    CONEXIONMAESTRA.abrir();
                    SqlCommand cmd = new SqlCommand("RegistrarFactura", CONEXIONMAESTRA.conectar);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NumFact", txtNumFact.Text);
                    cmd.Parameters.AddWithValue("@NumPed", txtNumPed.Text);
                    cmd.Parameters.AddWithValue("@Total", Convert.ToDouble(txtTotal.Text));
                    cmd.Parameters.AddWithValue("@FechaV", Convert.ToDateTime(txtFechaVencimiento.Value.ToShortDateString()));
                    cmd.Parameters.AddWithValue("@FechaP", Convert.ToDateTime(txtFechaPedido.Value.ToShortDateString()));
                    cmd.Parameters.AddWithValue("@Tipo", txtTipo.Text);
                    cmd.Parameters.AddWithValue("@Saldo", Convert.ToDouble(txtTotal.Text));
                    cmd.Parameters.AddWithValue("@idProveedor", Convert.ToInt32(idProveedor_));
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
                panelRegistro.Visible = false;
                limpiarPanelRegistro();

            }
            else
            {
                MessageBox.Show("Seleccione correctamente el Proveedor", "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            panelRegistro.Visible = true;
        }

        private void txtProveedor_TextChanged(object sender, EventArgs e)
        {
            if (txtProveedor.Text != "")
            {
                //panelProveedor.BringToFront();
                //panelProveedor.Location = new Point(674, 201);
                //panelProveedor.Size = new Size(174, 72);
                buscarProveedor();
                panelProveedor.Visible = true;
            }
            else
            {
                //panelProveedor.SendToBack();
                panelProveedor.Visible = false;
            }
        }
        public void buscarProveedor()
        {

            try
            {
                DataTable dt = new DataTable();
                Obtener_datos.Buscar_proveedores_(ref dt, txtProveedor.Text);
                datalistadoProveedor.DataSource = dt;
                datalistadoProveedor.Columns[0].Visible = false;
                datalistadoProveedor.Columns[2].Visible = false;
                datalistadoProveedor.Columns[3].Visible = false;
                datalistadoProveedor.Columns[4].Visible = false;
                datalistadoProveedor.Columns[5].Visible = false;
                datalistadoProveedor.Columns[6].Visible = false;
                datalistadoProveedor.Columns[7].Visible = false;
                //datalistadoProveedor.Columns[2].Width = datalistadoProveedor.Width;
                datalistadoProveedor.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Bases.Multilinea(ref datalistadoProveedor);
        }

        private void datalistadoProveedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idProveedor_ = Convert.ToInt32(datalistadoProveedor.SelectedCells[0].Value);
            txtProveedor.Text = datalistadoProveedor.SelectedCells[1].Value.ToString();
            panelProveedor.Visible = false;
        }

        private void Volver_Click(object sender, EventArgs e)
        {
            panelRegistro.Visible = false;
            limpiarPanelRegistro();
        }

        private void limpiarPanelRegistro()
        {
            txtNumFact.Clear();
            txtNumPed.Clear();
            txtTotal.Clear();
            txtFechaPedido.Value = DateTime.Now;
            txtFechaVencimiento.Value = DateTime.Now;
            txtTipo.SelectedIndex = 0;
        }

        private void datalistadoHistorial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idFact = Convert.ToInt32(datalistadoHistorial.SelectedCells[1].Value.ToString());
            numFact = datalistadoHistorial.SelectedCells[2].Value.ToString();
            txttotal_saldo.Text = datalistadoHistorial.SelectedCells[8].Value.ToString();
            saldo = Convert.ToDouble(txttotal_saldo.Text);
        }   

        private void datalistadoHistorial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void txtFactura_SelectedIndexChanged(object sender, EventArgs e)
        {
           // numFact = Convert.ToInt32(txtFactura.DisplayMember.ToString());
            //MessageBox.Show(txtFactura.Text);
        }

        private void btnMov_Click(object sender, EventArgs e)
        {

            datalistadoMovimientos.Visible = true;
            numFactMov = txtFactura.Text;
            mostrarControlCobros();
            panelFacturas.Visible = false;
                                    //            MessageBox.Show(txtFactura.Text. DisplayMember.ToString());
                                   //            MessageBox.Show(txtFactura.ValueMember.ToString());
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            panelFacturas.Visible = false;
            txtproveedorc.SelectAll();
            txtproveedorc.Focus();
            txttotal_saldo.Text = "0";
        }

        private void txtProveedor_DoubleClick(object sender, EventArgs e)
        {

            Presentacion.CLIENTES_PROVEEDORES.Proveedores frm = new CLIENTES_PROVEEDORES.Proveedores();
            frm.ShowDialog();
        }

        private void txtFechaPedido_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
