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
namespace SistemaVentas.Presentacion.Compras
{
    public partial class Compras_en_espera : Form
    {
        public Compras_en_espera()
        {

            InitializeComponent();
        }
        int idcaja;
       
       
        int idFactura;
        private void Ventas_en_espera_Load(object sender, EventArgs e)
        {
            mostrar_ventas_en_espera_con_fecha_y_monto();
            Obtener_datos.Obtener_id_caja_PorSerial(ref idcaja);
        }
        private void mostrar_ventas_en_espera_con_fecha_y_monto()
        {
            try
            {
                DataTable dt = new DataTable();
                Obtener_datos.mostrar_compras_en_espera_con_fecha_y_monto(ref dt);
                datalistado_ventas_en_espera.DataSource = dt;
                datalistado_ventas_en_espera.Columns[1].Visible = false;
                datalistado_ventas_en_espera.Columns[4].Visible = false;
                datalistado_ventas_en_espera.Columns[5].Visible = false;
                Bases.Multilinea (ref datalistado_ventas_en_espera);
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
                idFactura = Convert.ToInt32(datalistado_ventas_en_espera.SelectedCells[1].Value);
                MessageBox.Show(idFactura.ToString());
                mostrar_detalle_venta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            

        }
        private void mostrar_detalle_venta()
        {
            DataTable dt = new DataTable();
            Obtener_datos.mostrar_productos_agregados_a_compras_en_espera(ref dt, idFactura);
            datalistadodetalledeventasarestaurar.DataSource = dt;
            datalistadodetalledeventasarestaurar.Columns[6].Visible = false;
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            Eliminar_datos.eliminar_compra(idFactura);
            idFactura = 0;
            mostrar_ventas_en_espera_con_fecha_y_monto();
            mostrar_detalle_venta();
        }

        private void datalistado_ventas_en_espera_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                idFactura = Convert.ToInt32(datalistado_ventas_en_espera.SelectedCells[1].Value);
                mostrar_detalle_venta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }

        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            if (idFactura == 0)
            {
                MessageBox.Show("Seleccione una Compra a Restaurar");
            }
            else
            {
                Compras_proveedor.Compras_proveedor.idVenta = idFactura;
                Compras_proveedor.Compras_proveedor.txtventagenerada = "COMPRA GENERADA";
                Editar_datos.cambio_de_Cajacompra(idcaja, idFactura);
                Dispose();
            }
            
        }

        private void txtbusca_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
