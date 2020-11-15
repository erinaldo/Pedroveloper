using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using SistemaVentas.Datos;
using SistemaVentas.Logica;
namespace SistemaVentas.Presentacion.VENTAS_MENU_PRINCIPAL
{
    public partial class Pedidos_En_Espera : Form
    {
        public Pedidos_En_Espera()
        {
            InitializeComponent();
        }
       
       
        int idPedido;
        int idEmpleado;
        int idVehiculo;

        private void Ventas_en_espera_Load(object sender, EventArgs e)
        {
            MostrarPedido();
        }
        private void MostrarPedido()
        {
            try
            {
                DataTable dt = new DataTable();
                Obtener_datos.mostrarPedido(ref dt);
                datalistadoPedidos.DataSource = dt;
                datalistadoPedidos.Columns[0].Visible = false;
                datalistadoPedidos.Columns[1].Visible = false;
                datalistadoPedidos.Columns[3].Visible = false;
                datalistadoPedidos.Columns[4].Visible = false;
                datalistadoPedidos.Columns[7].Visible = false;
                Bases.Multilinea (ref datalistadoPedidos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);              
            }
        }

        private void datalistado_ventas_en_espera_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
            idPedido =Convert.ToInt32 ( datalistadoPedidos.SelectedCells[0].Value);
            idEmpleado =Convert.ToInt32 ( datalistadoPedidos.SelectedCells[3].Value);
            idVehiculo =Convert.ToInt32 ( datalistadoPedidos.SelectedCells[4].Value);
                

                mostrarPedidoAFinalizar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            

        }
        private void mostrarPedidoAFinalizar()
        {
            DataTable dt = new DataTable();
            Obtener_datos.mostrarPedidoEspecifico(ref dt, idPedido);
            datalistadopedidocompleto.Columns[0].Visible = false;
            /*datalistadopedidocompleto.Columns[1].Visible = false;
            datalistadopedidocompleto.Columns[2].Visible = false;
            datalistadopedidocompleto.Columns[3].Visible = false;
            datalistadopedidocompleto.Columns[4].Visible = false;*/

            datalistadopedidocompleto.DataSource = dt;
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
          /*  Eliminar_datos.eliminar_factura(idfactura);
            idfactura = 0;
            mostrar_ventas_en_espera_con_fecha_y_monto();
            mostrar_detalle_venta();*/
        }

        private void datalistado_ventas_en_espera_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            if (idPedido ==0)
            {
                MessageBox.Show("Seleccione un Pedido a Finalizar");
            }
            else
            {
                Insertar_datos.ProcesarPedido(idPedido);
                MessageBox.Show("Envio Finalizado", "Pedidos",MessageBoxButtons.OK,MessageBoxIcon.Information);
                MostrarPedido();
                ActualizarEstadoEmpleado();
                ActualizarEstadoVehiculo();
                Dispose();
            }
        }

        public void ActualizarEstadoEmpleado()
        {
            Insertar_datos.ActualizarDatosEmpleado(idEmpleado);
        }
        public void ActualizarEstadoVehiculo()
        {
            Insertar_datos.ActualizarDatosVehiculo(idVehiculo);
        }
    }
}
