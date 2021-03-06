using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SistemaVentas.CONEXION;
using SistemaVentas.Datos;
using SistemaVentas.Logica;
namespace SistemaVentas.Presentacion.HistorialCompras
{
    public partial class HistorialComprasForm : Form
    {
        public HistorialComprasForm()
        {
            InitializeComponent();
        }
        int idfactura;
        double Total;
        int idDetallefactura;
        double Cantidad;
        string ControlStock;
        int idproducto;
        double TotalNuevo;
        double PrecioUnitario;
        string TotalenterosString;
        string TotalEnLetras;
        private void txtbusca_TextChanged(object sender, EventArgs e)
        {
            if(txtbusca.Text.Length > 0)
            {
                BuscarCompra();
            }
        }
        private void BuscarCompra()
        {
            DataTable dt = new DataTable();
            Obtener_datos.BuscarCompra(ref dt, txtbusca.Text);
            datalistadoVentas.DataSource = dt;
            /*datalistadoVentas.Columns[1].Visible = false;
            datalistadoVentas.Columns[4].Visible = false;
            datalistadoVentas.Columns[5].Visible = false;
            datalistadoVentas.Columns[6].Visible = false;
            datalistadoVentas.Columns[8].Visible = false;
            datalistadoVentas.Columns[9].Visible = false;
            datalistadoVentas.Columns[10].Visible = false;*/

            Bases.Multilinea(ref datalistadoVentas);
        }

        private void HistorialVentasForm_Load(object sender, EventArgs e)
        {
            panelBienvenida.Dock = DockStyle.Fill;

        }

        private void datalistadoVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            obtenerdatos();
        }
        private void obtenerdatos()
        {
            if (datalistadoVentas.RowCount >0)
            {
                idfactura = Convert.ToInt32 ( datalistadoVentas.SelectedCells[0].Value);
                lblcomprobante.Text = datalistadoVentas.SelectedCells[2].Value.ToString();
                lbltotal.Text = datalistadoVentas.SelectedCells[3].Value.ToString();
                Total =Convert.ToDouble ( datalistadoVentas.SelectedCells[3].Value);
                lblcajero.Text = datalistadoVentas.SelectedCells[4].Value.ToString();
                lblpagocon.Text = datalistadoVentas.SelectedCells[5].Value.ToString();
                lblcliente.Text = datalistadoVentas.SelectedCells[9].Value.ToString();
                LBLTipodePagoOK.Text = datalistadoVentas.SelectedCells[6].Value.ToString();
                lblvuelto.Text = datalistadoVentas.SelectedCells[7].Value.ToString();
                PanelTICKET.Visible = true;
                panelDetalle.Visible = true;
                Pcancelado.Visible = false;
                panelBienvenida.Visible = false;
                Panelcantidad.Visible = false;
                panelReporte.Visible = false;
                panelDetalle.Dock = DockStyle.Fill;
                MostrarDetalleVenta();
            }
        }
        private void MostrarDetalleVenta()
        {
            DataTable dt = new DataTable();
            Obtener_datos.MostrarDetalleCompra(ref dt, idfactura);
            datalistadoDetalleVenta.DataSource = dt;
            datalistadoDetalleVenta.Columns[6].Visible = false;
            datalistadoDetalleVenta.Columns[7].Visible = false;
            datalistadoDetalleVenta.Columns[8].Visible = false;
            datalistadoDetalleVenta.Columns[9].Visible = false;
            datalistadoDetalleVenta.Columns[10].Visible = false;
            datalistadoDetalleVenta.Columns[11].Visible = false;
            datalistadoDetalleVenta.Columns[12].Visible = false;
            datalistadoDetalleVenta.Columns[13].Visible = false;
            datalistadoDetalleVenta.Columns[14].Visible = false;
            datalistadoDetalleVenta.Columns[15].Visible = false;
            datalistadoDetalleVenta.Columns[16].Visible = false;
            datalistadoDetalleVenta.Columns[17].Visible = false;

            Bases.Multilinea(ref datalistadoDetalleVenta);

        }

        private void datalistadoDetalleVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == datalistadoDetalleVenta.Columns["Devolver"].Index )
            {
                ObtenerDatosDetalle();
            }

        }
        private void ObtenerDatosDetalle()
        {
            lblCantActual.Text = datalistadoDetalleVenta.SelectedCells[3].Value.ToString();
            Cantidad = Convert.ToDouble(datalistadoDetalleVenta.SelectedCells[3].Value);
            PrecioUnitario =Convert.ToDouble ( datalistadoDetalleVenta.SelectedCells[4].Value);
            idproducto = Convert.ToInt32 ( datalistadoDetalleVenta.SelectedCells[6].Value);
            idDetallefactura =Convert.ToInt32 ( datalistadoDetalleVenta.SelectedCells[7].Value);
            ControlStock = datalistadoDetalleVenta.SelectedCells[14].Value.ToString();
            txtcantidad.Clear();
            txtcantidad.Focus();
            Panelcantidad.Location = new Point(lblcomprobante.Location.X, lblcomprobante.Location.Y);
            Panelcantidad.Size = new Size(466, 474);
            Panelcantidad.Visible = true;
            Panelcantidad.BringToFront();


        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Panelcantidad.Visible = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Detallefacturadevolucion();
        }
        private void Detallefacturadevolucion()
        {
            if (!string.IsNullOrEmpty (txtcantidad.Text ))
            {
                double CantidadDevolucion;
                CantidadDevolucion =Convert.ToDouble (txtcantidad.Text);
                if (CantidadDevolucion >0)
                {
                    if (CantidadDevolucion <=Cantidad)
                    {
                      Ldetallefactura parametros = new Ldetallefactura();
                      Editar_datos funcion = new Editar_datos();
                      parametros.iddetalle_factura = idDetallefactura;
                      parametros.cantidad = Convert.ToDouble (CantidadDevolucion);
                      parametros.Cantidad_mostrada  = Convert.ToDouble(CantidadDevolucion);
                       if (funcion.DetalleCompraDevolucion(parametros)==true)
                           {
                            if (ControlStock=="SI")
                            {
                                disminuirSTOCK();
                                disminuirSTOCKDETALLE();
                                insertar_KARDEX_SALIDA();
                                lbltotal.Text = TotalNuevo.ToString();
                                Editarfactura();
                                Panelcantidad.Visible = false;
                                ValidarPaneles();
                                BuscarCompra();
                            }
                            else
                            {
                                lbltotal.Text = TotalNuevo.ToString();
                                Editarfactura();
                                Panelcantidad.Visible = false;
                                ValidarPaneles();
                                BuscarCompra();
                            }
                           }
                    }
                    else
                    {
                        MessageBox.Show("Estas Exediendo la cantidad a devolver", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {
                    MessageBox.Show("La cantidad a devolver debe ser mayor a 0", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            else
            {
                MessageBox.Show("Ingrese una cantidad a devolver", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


        }
        private void ValidarPaneles()
        {
            if (TotalNuevo ==0)
            {
                PanelTICKET.Visible = false;
                Pcancelado.Visible = true;
                Pcancelado.Dock = DockStyle.Fill;
                panelDetalle.Visible = false;
                panelBienvenida.Visible = false;
            }
        }
        private void Editarfactura()
        {
            Lventas parametros = new Lventas();
            Editar_datos funcion = new Editar_datos();
            parametros.idfactura = idfactura;
            parametros.Monto_total =TotalNuevo;
            funcion.EditarCompra(parametros);
        }
        private void insertar_KARDEX_SALIDA()
        {
            LKardex parametros = new LKardex();
            Insertar_datos funcion = new Insertar_datos();
            parametros.Fecha = DateTime.Now;
            parametros.Motivo = "Devolución por salida de COMPRA #" + lblcomprobante.Text;
            parametros.Cantidad =Convert.ToDouble ( txtcantidad.Text);
            parametros.Id_producto = idproducto;
            funcion.insertar_KARDEX_SALIDA(parametros);
        }
        private void insertar_KARDEX_ENTRADA()
        {
            LKardex parametros = new LKardex();
            Insertar_datos funcion = new Insertar_datos();
            parametros.Fecha = DateTime.Now;
            parametros.Motivo = "Devolución por entrada de COMPRA #" + lblcomprobante.Text;
            parametros.Cantidad = Convert.ToDouble(txtcantidad.Text);
            parametros.Id_producto = idproducto;
            funcion.insertar_KARDEX_SALIDA(parametros);
        }
        private void disminuirSTOCK()
        {
            Lproductos parametros = new Lproductos();
            Editar_datos funcion = new Editar_datos();
           /* parametros.Id_Producto1 = idproducto;
            parametros.Stock = txtcantidad.Text;*/
            funcion.disminuir_stock(parametros);
        }
        private void disminuirSTOCKDETALLE()
        {
            Ldetallefactura parametros = new Ldetallefactura();
            Editar_datos funcion = new Editar_datos();
            parametros.Id_producto = idproducto;
            parametros.cantidad =Convert.ToDouble (  txtcantidad.Text);
            funcion.DISMINUIRSTOCKDETALLE(parametros);
        }

        private void txtcantidad_TextChanged(object sender, EventArgs e)
        {
            CalcularNuevoTotal();
        }
        private void CalcularNuevoTotal()
        {
            try
            {
                double CantidadTexto;
                CantidadTexto =Convert.ToDouble ( txtcantidad.Text);
                TotalNuevo = Total - (CantidadTexto * PrecioUnitario);

            }
            catch (Exception)
            {
                
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estas seguro de Eliminar esta Compra?", "Eliminando Registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK )
            {
                foreach (DataGridViewRow row in datalistadoDetalleVenta.Rows )
                {
                        idproducto=Convert.ToInt32 ( row.Cells["Id_producto"].Value);
                        txtcantidad.Text = row.Cells["Cantidad"].Value.ToString();
                        disminuirSTOCK();
                        disminuirSTOCKDETALLE();
                        insertar_KARDEX_SALIDA();
                }
                        TotalNuevo = 0;
                        Eliminarfacturas();
                        ValidarPaneles();
                        BuscarCompra();
            }
        }
        private void Eliminarfacturas()
        {
            Lventas parametros = new Lventas();
            Eliminar_datos funcion = new Eliminar_datos();
            parametros.idfactura = idfactura;
            funcion.EliminarCompras(parametros);
        }

        private void btnReimprimir_Click(object sender, EventArgs e)
        {
            convertirTotalEnLetras();
            ReimprimirTicket();
        }
        private void convertirTotalEnLetras()
        {
            try
            {
                TotalNuevo = Convert.ToDouble ( lbltotal.Text); 
                int numero =Convert.ToInt32 ( Math.Floor(TotalNuevo));
                TotalenterosString = total_en_letras.Num2Text(numero);
                string[] a = lbltotal.Text.Split('.');
                string TotalDecimales;
                TotalDecimales = a[1];
                TotalEnLetras = TotalenterosString + " CON " + TotalDecimales + "/100";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        private void ReimprimirTicket()
        {
            DataTable dt = new DataTable();
            Obtener_datos.mostrar_ticket_impreso(ref dt, idfactura, TotalEnLetras);
            REPORTES.Impresion_de_comprobantes.Ticket_report rpt = new REPORTES.Impresion_de_comprobantes.Ticket_report();
            rpt = new REPORTES.Impresion_de_comprobantes.Ticket_report();
            rpt.table1.DataSource = dt;
            rpt.DataSource = dt;
#pragma warning disable CS0618 // 'ReportViewerBase.Report' está obsoleto: 'Telerik.ReportViewer.WinForms.ReportViewer.Report is now obsolete. Please use the Telerik.ReportViewer.WinForms.ReportViewer.ReportSource property instead. For more information, please visit: http://www.telerik.com/support/kb/reporting/general/q2-2012-api-changes-reportsources.aspx#winformsviewer.'
            reportViewer1.Report = rpt;
#pragma warning restore CS0618 // 'ReportViewerBase.Report' está obsoleto: 'Telerik.ReportViewer.WinForms.ReportViewer.Report is now obsolete. Please use the Telerik.ReportViewer.WinForms.ReportViewer.ReportSource property instead. For more information, please visit: http://www.telerik.com/support/kb/reporting/general/q2-2012-api-changes-reportsources.aspx#winformsviewer.'
            reportViewer1.RefreshReport();
            panelReporte.Visible = true;
            panelReporte.Location = new Point(PanelTICKET.Location.X, PanelTICKET.Location.Y);
            panelReporte.Size = new Size(PanelTICKET.Width, PanelTICKET.Height);
            panelReporte.BringToFront();

        }

        private void btnHoy_Click(object sender, EventArgs e)
        {
            FiltrarFechas();
            fi.Value = DateTime.Now;
            ff.Value = DateTime.Now;
            buscarComprasPorFechas();

        }
        private void FiltrarFechas()
        {
            panelDetalle.Visible = false;
            panelBienvenida.Visible = true;
            panelBienvenida.Dock = DockStyle.Fill;
            Pcancelado.Visible = false;
        }
        public void buscarComprasPorFechas()
        {
            DataTable dt = new DataTable();
            Obtener_datos.buscarComprasPorFechas(ref dt, fi.Value, ff.Value);
            datalistadoVentas.DataSource = dt;
            datalistadoVentas.Columns[1].Visible = false;
            datalistadoVentas.Columns[4].Visible = false;
            datalistadoVentas.Columns[5].Visible = false;
            datalistadoVentas.Columns[6].Visible = false;
            datalistadoVentas.Columns[8].Visible = false;
            datalistadoVentas.Columns[9].Visible = false;

            Bases.Multilinea(ref datalistadoVentas);
        }

        private void fi_ValueChanged(object sender, EventArgs e)
        {
            FiltrarFechas();
            buscarComprasPorFechas();
        }

        private void ff_ValueChanged(object sender, EventArgs e)
        {
            FiltrarFechas();
            buscarComprasPorFechas();
        }

        private void txtcantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txtcantidad, e);

        }

        private void datalistadoVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
