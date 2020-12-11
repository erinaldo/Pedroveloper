using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaVentas.Presentacion.LoginInicio
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            progressbar.Visible = false;

            timer1.Start();

            progressbar.Visible = true;

        }

        int valor = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            valor += 1;
            progressbar.Value = valor;

            if (progressbar.Value == 100)
            {
                timer1.Stop();
                progressbar.Visible = false;
                Dispose();
                Presentacion.LOGIN frm = new Presentacion.LOGIN();
                frm.ShowDialog();
            }
        }
    }
}
