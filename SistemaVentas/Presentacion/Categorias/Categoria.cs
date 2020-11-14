using SistemaVentas.CONEXION;
using SistemaVentas.Datos;
using SistemaVentas.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaVentas.Presentacion.Categoria
{
    public partial class Categoria : Form
    {
        public Categoria()
        {
            InitializeComponent();
        }
        int idCategoria;
        string estado;
        private int idClaveSat;
        private int idDescuento;
        private int idImpuesto;

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Nuevo();
            panelRegistros.Visible = true;
        }

        private void EmpleadosOK_Load(object sender, EventArgs e)
        {
            panelDescuentoBasico.Visible = false;
            panelImpuestosCategoria.Visible = false;
            panelImpuestosAgregar.Visible = false;
            panelDescuentos.Visible = false;
            // txtClaveSat.Enabled = false;
            panelClaveUnidadSat.Visible = false;
            panelRegistros.Visible = false;
            mostrar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panelRegistros.Visible = false;

        }



        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (idCategoria == 0 || idImpuesto == 0)
            {
                MessageBox.Show("Favor clickea correctamente en los impuestos o descuentos", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                TextBox[] array = { txtCategoria, txtDepartamento };
                if (Insertar_datos.ValidTextIsNotNullOrEmpty(array))
                {
                    insertar();
                    rellenarCamposVacios();
                }
                else
                {
                    MessageBox.Show("Canmpos vacios\n Llene correctamente los campos", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void insertar()
        {
            insertarUnidad();
        }

        public void insertarUnidad()
        {
            LCategoria parametros = new LCategoria();
            Insertar_datos insertar = new Insertar_datos();


            parametros.Descripcion = txtCategoria.Text;
            parametros.Departamento = txtDepartamento.Text;
            parametros.idDescuento = idDescuento;
            parametros.idImpuesto = idImpuesto;

            if (insertar.insertarCategoria(parametros) == true)
            {
                mostrar();
            }

        }


        private void rellenarCamposVacios()
        {
            if (string.IsNullOrEmpty(txtCategoria.Text))
            { txtCategoria.Text = "-"; };
            if (string.IsNullOrEmpty(txtCategoria.Text)) { txtCategoria.Text = "-"; };
            if (string.IsNullOrEmpty(txtDepartamento.Text)) { txtDepartamento.Text = "-"; };
        }

        private void mostrar()
        {
            mostrarCat();
            panelRegistros.Visible = false;
            pintarDatalistado();
        }
        private void pintarDatalistado()
        {
            Bases.Multilinea(ref datalistado);
            datalistado.Columns[2].Visible = false;
            datalistado.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }
        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtbuscar.Text != "")
            {
                buscar();
            }
            else
            {
                mostrar();
            }
        }

        private void buscar()
        {

            mostarCategoriaCompleta(txtbuscar.Text);
        }
        private void mostarCategoriaCompleta(string categoria)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("mostrarCategorias2", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@buscar", categoria);
                da.Fill(dt);
                datalistado.DataSource = dt;
                con.Close();

                datalistado.DataSource = dt;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Bases.Multilinea(ref datalistado);
        }

        private void mostrarCat()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("mostrarCategorias", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
                datalistado.DataSource = dt;
                con.Close();

                datalistado.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Bases.Multilinea(ref datalistado);
        }
        private void obtenerId_estado()
        {
            try
            {
                idCategoria = Convert.ToInt32(datalistado.SelectedCells[2].Value);
            }
            catch (Exception)
            {

            }
        }
        private void obtenerDatos()
        {
            try
            {
                idCategoria = Convert.ToInt32(datalistado.SelectedCells[2].Value);
                txtCategoria.Text = datalistado.SelectedCells[3].Value.ToString();
                txtDepartamento.Text = datalistado.SelectedCells[4].Value.ToString();
                txtidImpuesto.Text = datalistado.SelectedCells[5].Value.ToString();
                txtidDescuento.Text = datalistado.SelectedCells[6].Value.ToString();
                prepararEdicion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void prepararEdicion()
        {

            panelRegistros.Visible = true;
            panelRegistros.Dock = DockStyle.Fill;
            panelRegistros.BringToFront();
            //datalistado.SendToBack();
            btnGuardar.Visible = false;
            btnGuardarCambios.Visible = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            TextBox[] array = { txtCategoria, txtDepartamento };

            if (Insertar_datos.ValidTextIsNotNullOrEmpty(array))
            {
                obtenerId_estado();
                rellenarCamposVacios();
                editar();
            }
            else
            {
                MessageBox.Show("Favor llenar los campos correctamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public void editar()
        {
            editarCategoria();
        }
        public void editarCategoria()
        {
            if (idCategoria == 0 || idImpuesto == 0)
            {
                MessageBox.Show("Favor clickea correctamente en los impuestos o descuentos", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                LCategoria parametros = new LCategoria();
                Editar_datos insertar = new Editar_datos();

                parametros.idCategoria = idCategoria;
                parametros.Descripcion = txtCategoria.Text;
                parametros.idDescuento = idDescuento;
                parametros.idImpuesto = idImpuesto;
                parametros.Departamento = txtDepartamento.Text;

                if (insertar.editarCategoria(parametros) == true)
                {
                    mostrar();
                }
            }

        }

        private void eliminar()
        {
            Eliminar_datos.eliminarCategoria(idCategoria);
            mostrar();
        }

        private void Nuevo()
        {
            panelRegistros.Visible = true;
            limpiar();
            btnGuardar.Visible = true;
            btnGuardarCambios.Visible = false;
            txtCategoria.Focus();
            panelRegistros.Dock = DockStyle.Fill;
        }

        private void limpiar()
        {
            txtCategoria.Clear();
            txtDepartamento.Clear();
            txtbuscar.Clear();
            txtUnidadBuscar.Clear();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void panelRegistros_Paint(object sender, PaintEventArgs e)
        {

        }



        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }



        private void txtnombre_TextChanged(object sender, EventArgs e)
        {

        }


        private void dlg_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }



        private void tiempoBuscador_Tick(object sender, EventArgs e)
        {
        }

        private void datalistado_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == datalistado.Columns["EditarG"].Index)
            {
                obtenerDatos();
            }
            if (e.ColumnIndex == datalistado.Columns["EliminarG"].Index)
            {
                idCategoria = Convert.ToInt32(datalistado.SelectedCells[2].Value);
                DialogResult result = MessageBox.Show("¿Realmente desea eliminar este Registro?", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    eliminar();
                }
            }
        }

        private void txtImpuesto_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtClaveSat_DoubleClick(object sender, EventArgs e)
        {
            panelClaveUnidadSat.Visible = true;
            //panelUnidad.Visible = true;
            panelClaveUnidadSat.Location = new Point(121, 131);
            panelClaveUnidadSat.Size = new Size(670, 362);
            panelClaveUnidadSat.BringToFront();
            mostrarClavesSAT();
        }
        public void mostrarClavesSAT()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("mostrarClavesSat", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@buscar", txtUnidadBuscar.Text + "");
                da.Fill(dt);
                datalistadoUnidadesSAT.DataSource = dt;
                con.Close();

                datalistadoUnidadesSAT.DataSource = dt;
                datalistadoUnidadesSAT.Columns[0].Visible = false;
                datalistadoUnidadesSAT.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Bases.Multilinea(ref datalistadoUnidadesSAT);
        }

        private void cerrarPANELCLAVESAT_Click(object sender, EventArgs e)
        {
            panelClaveUnidadSat.Visible = false;
            panelClaveUnidadSat.BringToFront();

        }

        private void datalistadoUnidadesSAT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            panelClaveUnidadSat.Visible = false;
            idClaveSat = Convert.ToInt32(datalistadoUnidadesSAT.SelectedCells[0].Value.ToString());
            txtDepartamento.Text = datalistadoUnidadesSAT.SelectedCells[2].Value.ToString();
            txtCategoria.Focus();
        }

        private void txtUnidadBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("mostrarClavesSat", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@buscar", txtUnidadBuscar.Text + "");
                da.Fill(dt);
                datalistadoUnidadesSAT.DataSource = dt;
                con.Close();

                datalistadoUnidadesSAT.DataSource = dt;
                datalistadoUnidadesSAT.Columns[0].Visible = false;
                datalistadoUnidadesSAT.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Bases.Multilinea(ref datalistadoUnidadesSAT);
        }

        private void txtidDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txtidDescuento, e);
        }

        private void txtidImpuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txtidImpuesto, e);
        }

        private void txtidDescuento_DoubleClick(object sender, EventArgs e)
        {
            panelDescuentos.Visible = true;
            panelDescuentos.BringToFront();
        }

        private void btnDescuentoAgregar_Click(object sender, EventArgs e)
        {
            TextBox[] array = { txtDescuentoAgregar };
            if (Insertar_datos.ValidTextIsNotNullOrEmpty(array))
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                    con.Open();
                    CONEXIONMAESTRA.abrir();
                    SqlCommand cmd = new SqlCommand("insertarDescuento", CONEXIONMAESTRA.conectar);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Descuento", Convert.ToDouble(txtDescuentoAgregar.Text));
                    cmd.Parameters.AddWithValue("@TipoDescuento", "Descuento Categoria");
                    cmd.ExecuteNonQuery();
                    CONEXIONMAESTRA.cerrar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                panelDescuentos.Visible = false;
            }
            else
            {

            }
        }

        private void txtDescuentoAgregar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Separador_de_Numeros(txtDescuentoAgregar, e);
        }

        private void btnImpuestoAgregar_Click(object sender, EventArgs e)
        {
            TextBox[] array = { txtNombreImpuestoAgregar, txtImpuestoAgregar };
            if (Insertar_datos.ValidTextIsNotNullOrEmpty(array))
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                    con.Open();
                    CONEXIONMAESTRA.abrir();
                    SqlCommand cmd = new SqlCommand("insertarImpuestosCategoria", CONEXIONMAESTRA.conectar);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@nombre", txtNombreImpuestoAgregar.Text);
                    cmd.Parameters.AddWithValue("@Impuesto", Convert.ToDouble(txtImpuestoAgregar.Text) / 100);
                    cmd.Parameters.AddWithValue("@tipo", "Impuesto Categoria");
                    cmd.ExecuteNonQuery();
                    CONEXIONMAESTRA.cerrar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                panelImpuestosAgregar.Visible = false;
            }
            else
            {

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            panelImpuestosAgregar.Visible = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            panelDescuentos.Visible = false;
        }

        private void txtidImpuesto_DoubleClick(object sender, EventArgs e)
        {
            panelImpuestosAgregar.Visible = true;
            panelImpuestosAgregar.BringToFront();
        }

        private void txtidDescuento_TextChanged(object sender, EventArgs e)
        {
            if (txtidDescuento.Text != "")
            {
                panelDescuentoBasico.BringToFront();
                buscarDescientosCategoria();
                panelDescuentoBasico.Visible = true;
            }
            else
            {
                buscarDescientosCategoria();
                panelDescuentoBasico.SendToBack();
                panelDescuentoBasico.Visible = false;
            }

        }

        private void txtidImpuesto_TextChanged(object sender, EventArgs e)
        {
            if (txtidImpuesto.Text != "")
            {
                panelImpuestosCategoria.BringToFront();
                panelImpuestosCategoria.Size = new Size(228, 52);
                buscarImpuestosCategoria();
                panelImpuestosCategoria.Visible = true;
            }
            else
            {

                buscarDescientosCategoria();
                panelImpuestosCategoria.SendToBack();
                panelImpuestosCategoria.Visible = false;
            }
        }

        private void buscarImpuestosCategoria()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("buscarImpuestosCategoria", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@buscar", txtidImpuesto.Text + "");
                da.Fill(dt);
                datalistadoUnidadesSAT.DataSource = dt;
                con.Close();

                datalistadiImpuestosCategoria.DataSource = dt;
                datalistadiImpuestosCategoria.Columns[0].Visible = false;
                datalistadiImpuestosCategoria.Columns[2].Visible = false;
                datalistadiImpuestosCategoria.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Bases.Multilinea(ref datalistadiImpuestosCategoria);

    }

        private void buscarDescientosCategoria()
        {

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("buscarDescuentosCategoria", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@buscar", txtidDescuento.Text);
                da.Fill(dt);
                datalistadoUnidadesSAT.DataSource = dt;
                con.Close();

                datalistadoDescuentoBasico.DataSource = dt;
                datalistadoDescuentoBasico.Columns[0].Visible = false;
                datalistadoDescuentoBasico.Columns[2].Visible = false;
                datalistadoDescuentoBasico.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Bases.Multilinea(ref datalistadoDescuentoBasico); }

        private void datalistadoDescuentoBasico_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idDescuento = Convert.ToInt32(datalistadoDescuentoBasico.SelectedCells[0].Value);
            txtidDescuento.Text = datalistadoDescuentoBasico.SelectedCells[1].Value.ToString();
            panelDescuentoBasico.Visible = false;
        }

        private void datalistadiImpuestosCategoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idImpuesto = Convert.ToInt32(datalistadiImpuestosCategoria.SelectedCells[0].Value);
            txtidImpuesto.Text = datalistadiImpuestosCategoria.SelectedCells[1].Value.ToString();
            panelImpuestosCategoria.Visible = false;
        }
    }
}
