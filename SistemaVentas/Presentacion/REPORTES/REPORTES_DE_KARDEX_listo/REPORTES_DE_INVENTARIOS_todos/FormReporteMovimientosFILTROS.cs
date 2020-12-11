using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace SistemaVentas.Presentacion.REPORTES.REPORTES_DE_KARDEX_listo.REPORTES_DE_INVENTARIOS_todos
{
    public partial class FormReporteMovimientosFILTROS : Form
    {
        public FormReporteMovimientosFILTROS()
        {
            InitializeComponent();
        }
        Reporte_Movimientos_con_filtros rptFREPORT2 = new Reporte_Movimientos_con_filtros();
        private void mostrar()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("buscar_MOVIMIENTOS_DE_KARDEX_filtros", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@fecha", Presentacion.INVENTARIOS_KARDEX.INVENTARIO_MENU.fecha );
                da.SelectCommand.Parameters.AddWithValue("@tipo", Presentacion.INVENTARIOS_KARDEX.INVENTARIO_MENU.Tipo_de_movimiento );
                da.SelectCommand.Parameters.AddWithValue("@Id_usuario", Presentacion.INVENTARIOS_KARDEX.INVENTARIO_MENU.id_usuario );

                da.Fill(dt);
                con.Close();
                rptFREPORT2 = new Reporte_Movimientos_con_filtros();
                rptFREPORT2.DataSource = dt;
                rptFREPORT2.Table1.DataSource = dt;
#pragma warning disable CS0618 // 'ReportViewerBase.Report' está obsoleto: 'Telerik.ReportViewer.WinForms.ReportViewer.Report is now obsolete. Please use the Telerik.ReportViewer.WinForms.ReportViewer.ReportSource property instead. For more information, please visit: http://www.telerik.com/support/kb/reporting/general/q2-2012-api-changes-reportsources.aspx#winformsviewer.'
                reportViewer1.Report = rptFREPORT2;
#pragma warning restore CS0618 // 'ReportViewerBase.Report' está obsoleto: 'Telerik.ReportViewer.WinForms.ReportViewer.Report is now obsolete. Please use the Telerik.ReportViewer.WinForms.ReportViewer.ReportSource property instead. For more information, please visit: http://www.telerik.com/support/kb/reporting/general/q2-2012-api-changes-reportsources.aspx#winformsviewer.'

                reportViewer1.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }
        private void FormReporteMovimientosFILTROS_Load(object sender, EventArgs e)
        {
            mostrar();
        }
    }
}
