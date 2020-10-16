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
using SistemaVentas.CONEXION;

namespace SistemaVentas.Presentacion.VENTAS_MENU_PRINCIPAL
{
    public partial class Cotizaciones_En_Espera : Form
    {
        public Cotizaciones_En_Espera()
        {
            InitializeComponent();
        }
        int idcaja;
        string fecha;

        static int  idcotizacion;
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
                Obtener_datos.mostrar_cotizacion_en_espera_con_fecha_y_monto(ref dt);
                datalistado_ventas_en_espera.DataSource = dt;
                datalistado_ventas_en_espera.Columns[1].Visible = false;
                datalistado_ventas_en_espera.Columns[4].Visible = false;
               // datalistado_ventas_en_espera.Columns[5].Visible = false;
                //lblfechadeventa.Text = datalistado_ventas_en_espera.SelectedCells[5].Value.ToString();
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
           
            idcotizacion = Convert.ToInt32 ( datalistado_ventas_en_espera.SelectedCells[1].Value);
             //   MessageBox.Show(idcotizacion.ToString());
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
            Obtener_datos.mostrar_productos_agregados_a_cotizaciones_en_espera(ref dt, idcotizacion);
            datalistadodetalledeventasarestaurar.DataSource = dt;
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
                try
                {
                    CONEXIONMAESTRA.abrir();
                    SqlCommand cmd = new SqlCommand("eliminar_cotizacion", CONEXIONMAESTRA.conectar);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idcotizacion", idcotizacion);
                    cmd.ExecuteNonQuery();
                    CONEXIONMAESTRA.cerrar();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

            
            idcotizacion = 0;
            mostrar_ventas_en_espera_con_fecha_y_monto();
            mostrar_detalle_venta();
        }

        private void datalistado_ventas_en_espera_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            if (idcotizacion ==0)
            {
                MessageBox.Show("Seleccione una cotizacion a Restaurar");
            }
            else
            {
                /*DataTable dt = new DataTable();
                Obtener_datos.mostrar_productos_agregados_a_cotizaciones_en_espera(ref dt, idcotizacion);
                datalistadocoti.DataSource = dt;*/
                EnviarDatos();
                Dispose();
            }
            
        }

        private void txtbusca_TextChanged(object sender, EventArgs e)
        {

        }

        public void EnviarDatos()
        {
            Logica.LCotizacion parametros = new Logica.LCotizacion();

            parametros.idcotizacion = Convert.ToInt32(datalistadodetalledeventasarestaurar.SelectedCells[7].Value);
            MessageBox.Show(parametros.idcotizacion.ToString());
        }

    }
}
