using SistemaVentas.Presentacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
namespace SistemaVentas
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        /// 
        [STAThread]
        static void Main()     
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< HEAD
           Presentacion.LOGIN frm = new Presentacion.LOGIN();
=======
            //Presentacion.LOGIN frm = new Presentacion.LOGIN();
>>>>>>> 070e0db6f7cb668b558c2edfe87731c1cff6d7d7
            //Presentacion.ASISTENTE_DE_INSTALACION_servidor.USUARIOS_AUTORIZADOS_AL_SISTEMA frm = new Presentacion.ASISTENTE_DE_INSTALACION_servidor.USUARIOS_AUTORIZADOS_AL_SISTEMA();
            //Presentacion.Vehiculos.Vehiculos frm = new Presentacion.Vehiculos.Vehiculos();
            // Presentacion.Empleados.EmpleadosOK frm = new Presentacion.Empleados.EmpleadosOK();
            //  Presentacion.VENTAS_MENU_PRINCIPAL.VENTAS_MENU_PRINCIPALOK frm = new Presentacion.VENTAS_MENU_PRINCIPAL.VENTAS_MENU_PRINCIPALOK();
            // Presentacion.Compras_proveedor.Compras_proveedor frm = new Presentacion.Compras_proveedor.Compras_proveedor();
            //  Presentacion.PRODUCTOS_OK.Productos_ok frm = new Presentacion.PRODUCTOS_OK.Productos_ok();
            // Presentacion.INVENTARIOS_KARDEX.INVENTARIO_MENU frm = new Presentacion.INVENTARIOS_KARDEX.INVENTARIO_MENU();
            //Presentacion.Unidades.Unidades frm = new Presentacion.Unidades.Unidades();
<<<<<<< HEAD
            // Presentacion.CONFIGURACION.PANEL_CONFIGURACIONES frm = new Presentacion.CONFIGURACION.PANEL_CONFIGURACIONES();
            //Presentacion.ASISTENTE_DE_INSTALACION_servidor.USUARIOS_AUTORIZADOS_AL_SISTEMA frm = new Presentacion.ASISTENTE_DE_INSTALACION_servidor.USUARIOS_AUTORIZADOS_AL_SISTEMA();
            // Presentacion.VentasCamiones.VentasCamiones frm = new Presentacion.VentasCamiones.VentasCamiones();
            //Presentacion.Geolocalizacion.Geolocalizacion frm = new Presentacion.Geolocalizacion.Geolocalizacion();
            //Presentacion.ASISTENTE_DE_INSTALACION_servidor.REGISTRO_DE_EMPRESA frm = new Presentacion.ASISTENTE_DE_INSTALACION_servidor.REGISTRO_DE_EMPRESA();
            //Presentacion.FacturasCredito.FacturasCredito frm = new Presentacion.FacturasCredito.FacturasCredito();
           //Presentacion.LoginInicio.Inicio frm = new Presentacion.LoginInicio.Inicio();
=======
           // Presentacion.CONFIGURACION.PANEL_CONFIGURACIONES frm = new Presentacion.CONFIGURACION.PANEL_CONFIGURACIONES();
            //Presentacion.ASISTENTE_DE_INSTALACION_servidor.USUARIOS_AUTORIZADOS_AL_SISTEMA frm = new Presentacion.ASISTENTE_DE_INSTALACION_servidor.USUARIOS_AUTORIZADOS_AL_SISTEMA();
            // Presentacion.VentasCamiones.VentasCamiones frm = new Presentacion.VentasCamiones.VentasCamiones();
            //Presentacion.Geolocalizacion.Geolocalizacion frm = new Presentacion.Geolocalizacion.Geolocalizacion();
            Presentacion.FacturasCredito.FacturasCredito frm = new Presentacion.FacturasCredito.FacturasCredito();
>>>>>>> 070e0db6f7cb668b558c2edfe87731c1cff6d7d7
            frm.FormClosed += Frm_FormClosed;
            frm.ShowDialog();  
            Application.Run();
        }
        private static void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }
    }
}
