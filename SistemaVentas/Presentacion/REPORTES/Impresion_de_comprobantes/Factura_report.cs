namespace SistemaVentas.Presentacion.REPORTES.Impresion_de_comprobantes
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for Ticket_report.
    /// </summary>
    public partial class Factura_report : Telerik.Reporting.Report
    {
        public Factura_report()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
    }
}