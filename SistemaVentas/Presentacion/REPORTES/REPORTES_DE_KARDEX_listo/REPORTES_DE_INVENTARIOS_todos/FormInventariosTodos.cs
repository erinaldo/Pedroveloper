using System;

using System.Data;

using System.Windows.Forms;
using System.Data.SqlClient;
namespace SistemaVentas.Presentacion.REPORTES.REPORTES_DE_KARDEX_listo.REPORTES_DE_INVENTARIOS_todos
{
    public partial class FormInventariosTodos : Form
    {
        public FormInventariosTodos()
        {
            InitializeComponent();
        }
        ReportInventarios_Todos rptFREPORT2=new ReportInventarios_Todos();
        private void mostrar()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("imprimir_inventarios_todos", con);
                da.Fill(dt);
                con.Close();
                rptFREPORT2 = new ReportInventarios_Todos();
                rptFREPORT2.DataSource = dt;
                rptFREPORT2.table1.DataSource = dt;
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
        private void FormInventariosTodos_Load(object sender, EventArgs e)
        {
            mostrar();
        }
    }
}
