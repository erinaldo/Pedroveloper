using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SistemaVentas.Datos;
using SistemaVentas.Logica;
namespace SistemaVentas.Presentacion.MediosPagoFacturaCredito
{
    public partial class MediosPagoFacturaCredito : Form
    {
        public MediosPagoFacturaCredito()
        {
            InitializeComponent();
        }
        double saldo;
        int idProveedor;
        int idcaja;
        int idFact;
        string numFact;
        int idusuario;
        //
        double efectivo;
        double tarjeta;
        double vuelto;
        double restante;
        double efectivoCalculado;
        double montoabonado;
        private void MediosCobros_Load(object sender, EventArgs e)
        {
            label2.Visible = false;
            label50.Visible = false;
            txtTransferencia.Visible = false;
            saldo = FacturasCredito.FacturasCredito.saldo;
            lbltotal.Text = saldo.ToString();
            idProveedor = FacturasCredito.FacturasCredito.idProveedor;
            idFact = FacturasCredito.FacturasCredito.idFact;
            numFact = FacturasCredito.FacturasCredito.numFact;
            Obtener_datos.Obtener_id_caja_PorSerial(ref idcaja);
            Obtener_datos.mostrar_inicio_De_sesion(ref idusuario);
        }
        private void calcularRestante()
        {
            try
            {
                efectivo = 0;
                tarjeta = 0;
                if (string.IsNullOrEmpty(txtefectivo2.Text))
                {
                    efectivo = 0;
                }
                else
                {
                    efectivo = Convert.ToDouble(txtefectivo2.Text);

                }
                if (string.IsNullOrEmpty(txttarjeta2.Text))
                {
                    tarjeta = 0;
                }
                else
                {
                    tarjeta = Convert.ToDouble(txttarjeta2.Text);
                }
                //calculo de vuelto
                if (efectivo > saldo)
                {
                    vuelto = efectivo - saldo;
                    efectivoCalculado = (efectivo - vuelto);
                    TXTVUELTO.Text = vuelto.ToString();
                }
                else
                {
                    vuelto = 0;
                    efectivoCalculado = efectivo;
                    TXTVUELTO.Text = vuelto.ToString();

                }

                //calculo del restante
                restante = saldo - efectivoCalculado - tarjeta;
                txtrestante.Text = restante.ToString();
                if (restante < 0)
                {
                    txtrestante.Visible = false;
                    Label8.Visible = false;
                }
                else
                {
                    txtrestante.Visible = true;
                    Label8.Visible = true;
                }

                if (tarjeta == saldo)
                {
                    efectivo = 0;
                    txtefectivo2.Text = efectivo.ToString();
                }
                if (tarjeta > saldo)
                {
                    MessageBox.Show("El pago con tarjeta no puede ser mayor que el saldo");
                    tarjeta = 0;
                    txttarjeta2.Text = tarjeta.ToString();
                }
            }
            catch (Exception)
            {

            }
        }

        private void insertarControlPago()
        {
            Lcontrolpagos parametros = new Lcontrolpagos();
            string codigoTrans;
            if (chkTrans.Checked == true)
            {
                codigoTrans = txtTransferencia.Text;
                parametros.Transferencia = codigoTrans;
            }
            else
            {
                codigoTrans = "-";
                parametros.Transferencia = codigoTrans;

            }

            Insertar_datos funcion = new Insertar_datos();
            parametros.idFact = idFact;
            parametros.numFact = numFact;
            parametros.Monto = efectivoCalculado + tarjeta;
            parametros.Fecha = DateTime.Now;
            parametros.Detalle = "Abono|Pago Factura";
            parametros.idProveedor = idProveedor;
            parametros.IdUsuario = idusuario;
            parametros.IdCaja = idcaja;
            parametros.Comprobante = "-";
            parametros.efectivo = efectivoCalculado;
            parametros.tarjeta = tarjeta;

            if (funcion.insertar_ControlPagoFacturaExterna(parametros) == true)
            {
                Dispose();
            }
        }
        private void disminuirSaldoFactura()
        {
            LSaldo parametros = new LSaldo();
            Lcontrolpagos parametros2 = new Lcontrolpagos();

            Editar_datos funcion = new Editar_datos();
            
            parametros.numFact = FacturasCredito.FacturasCredito.numFact;
            parametros.monto = efectivoCalculado + tarjeta;
            funcion.disminuirSaldoFactura(parametros);
        }

        private void btncobrar_Click_1(object sender, EventArgs e)
        {
            montoabonado = efectivoCalculado + tarjeta;
            if (montoabonado > 0)
            {
                if (chkTrans.Checked == true)
                {
                    if (txtTransferencia.Text != "")
                    {
                        numFact = FacturasCredito.FacturasCredito.numFact;
                        
                        insertarControlPago();
                        disminuirSaldoFactura();
                    }
                    else
                    {
                        MessageBox.Show("Indica el numero de transferencia usado en el campo desginado", "Transferencia bancaria", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    numFact = FacturasCredito.FacturasCredito.numFact;
                    insertarControlPago();
                    disminuirSaldoFactura();
                }
            }
            else
            {
                MessageBox.Show("Especifique un monto a abonar");
            }
        }

        private void txtefectivo2_TextChanged_1(object sender, EventArgs e)
        {
            calcularRestante();

        }

        private void txttarjeta2_TextChanged(object sender, EventArgs e)
        {
            calcularRestante();

        }

        private void chkTrans_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkTrans.Checked == true)
            {
                //panel2.Visible = false;
                txtTransferencia.Visible = true;
                label2.Visible = true;
                label50.Visible = true;
            }
            else
            {
                txtTransferencia.Text = "";
                txtTransferencia.Visible = false;
                label2.Visible = false;
                label50.Visible = false;
            }
        }

        private void txtefectivo2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txtefectivo2, e);

        }

        private void txttarjeta2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txttarjeta2, e);

        }
    }
}
