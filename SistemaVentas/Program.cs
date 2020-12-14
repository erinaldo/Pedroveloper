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

            //Presentacion.LOGIN frm = new Presentacion.LOGIN();

            //Presentacion.LOGIN frm = new Presentacion.LOGIN();
            //Presentacion.ASISTENTE_DE_INSTALACION_servidor.USUARIOS_AUTORIZADOS_AL_SISTEMA frm = new Presentacion.ASISTENTE_DE_INSTALACION_servidor.USUARIOS_AUTORIZADOS_AL_SISTEMA();
            //Presentacion.Vehiculos.Vehiculos frm = new Presentacion.Vehiculos.Vehiculos();
            // Presentacion.Empleados.EmpleadosOK frm = new Presentacion.Empleados.EmpleadosOK();
         Presentacion.VENTAS_MENU_PRINCIPAL.MENUPRINCIPAL frm = new Presentacion.VENTAS_MENU_PRINCIPAL.MENUPRINCIPAL();
             // Presentacion.VENTAS_MENU_PRINCIPAL.VENTAS_MENU_PRINCIPALOK frm = new Presentacion.VENTAS_MENU_PRINCIPAL.VENTAS_MENU_PRINCIPALOK();
              //Presentacion.VENTAS_MENU_PRINCIPAL.MEDIOS_DE_PAGO frm = new Presentacion.VENTAS_MENU_PRINCIPAL.MEDIOS_DE_PAGO();
            // Presentacion.Compras_proveedor.Compras_proveedor frm = new Presentacion.Compras_proveedor.Compras_proveedor();
            //  Presentacion.PRODUCTOS_OK.Productos_ok frm = new Presentacion.PRODUCTOS_OK.Productos_ok();
            // Presentacion.INVENTARIOS_KARDEX.INVENTARIO_MENU frm = new Presentacion.INVENTARIOS_KARDEX.INVENTARIO_MENU();
            //Presentacion.Unidades.Unidades frm = new Presentacion.Unidades.Unidades();

            //Presentacion.CONFIGURACION.PANEL_CONFIGURACIONES frm = new Presentacion.CONFIGURACION.PANEL_CONFIGURACIONES();
            //Presentacion.ASISTENTE_DE_INSTALACION_servidor.USUARIOS_AUTORIZADOS_AL_SISTEMA frm = new Presentacion.ASISTENTE_DE_INSTALACION_servidor.USUARIOS_AUTORIZADOS_AL_SISTEMA();
            // Presentacion.VentasCamiones.VentasCamiones frm = new Presentacion.VentasCamiones.VentasCamiones();
            //Presentacion.Geolocalizacion.Geolocalizacion frm = new Presentacion.Geolocalizacion.Geolocalizacion();
            //Presentacion.ASISTENTE_DE_INSTALACION_servidor.REGISTRO_DE_EMPRESA frm = new Presentacion.ASISTENTE_DE_INSTALACION_servidor.REGISTRO_DE_EMPRESA();
            //Presentacion.FacturasCredito.FacturasCredito frm = new Presentacion.FacturasCredito.FacturasCredito();
            //Presentacion.LoginInicio.Inicio frm = new Presentacion.LoginInicio.Inicio();
            //Presentacion.CONFIGURACION.PANEL_CONFIGURACIONES frm = new Presentacion.CONFIGURACION.PANEL_CONFIGURACIONES();
            //Presentacion.ASISTENTE_DE_INSTALACION_servidor.USUARIOS_AUTORIZADOS_AL_SISTEMA frm = new Presentacion.ASISTENTE_DE_INSTALACION_servidor.USUARIOS_AUTORIZADOS_AL_SISTEMA();
            //Presentacion.CAJA.APERTURA_DE_CAJA frm = new Presentacion.CAJA.APERTURA_DE_CAJA();
            //Presentacion.Admin_nivel_dios.DASHBOARD_PRINCIPAL frm = new Presentacion.Admin_nivel_dios.DASHBOARD_PRINCIPAL();
            // Presentacion.USUARIOS_Y_PERMISOS.usuariosok frm = new Presentacion.USUARIOS_Y_PERMISOS.usuariosok();
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
