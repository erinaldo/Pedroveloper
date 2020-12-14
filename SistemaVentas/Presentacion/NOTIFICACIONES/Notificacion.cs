using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaVentas.Presentacion.NOTIFICACIONES
{
    public partial class Notificacion : Form
    {
        public Notificacion(string message)
        {
            InitializeComponent();
            lblMessage.Text = message;

        }

        public static void confirmarForm(string message)
        {
            Notificacion frm = new Notificacion(message);
            frm.ShowDialog();
        }

        private void closeSuccess_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Notificacion_Load(object sender, EventArgs e)
        {
            bunifuFormFadeTransition1.ShowAsyc(this);

        }
    }
}
