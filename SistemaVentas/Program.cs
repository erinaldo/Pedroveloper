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
            Presentacion.LoginInicio.Inicio frm = new Presentacion.LoginInicio.Inicio();
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
