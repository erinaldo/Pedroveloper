namespace SistemaVentas.Presentacion.Impuestos
{
    partial class Impuestos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Impuestos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtbuscar = new System.Windows.Forms.TextBox();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panelRegistros = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTipo = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.txtImpuesto = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGuardarCambios = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dlg = new System.Windows.Forms.OpenFileDialog();
            this.Eliminar = new System.Windows.Forms.DataGridViewImageColumn();
            this.Editar = new System.Windows.Forms.DataGridViewImageColumn();
            this.tiempoBuscador = new System.Windows.Forms.Timer(this.components);
            this.datalistado = new System.Windows.Forms.DataGridView();
            this.EliminarG = new System.Windows.Forms.DataGridViewImageColumn();
            this.EditarG = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panelRegistros.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datalistado)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(63)))), ((int)(((byte)(67)))));
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(903, 47);
            this.panel1.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Dock = System.Windows.Forms.DockStyle.Right;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(851, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(52, 47);
            this.button2.TabIndex = 1;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Impuestos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.txtbuscar);
            this.panel2.Controls.Add(this.PictureBox2);
            this.panel2.Controls.Add(this.menuStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(903, 47);
            this.panel2.TabIndex = 4;
            // 
            // txtbuscar
            // 
            this.txtbuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbuscar.Location = new System.Drawing.Point(55, 10);
            this.txtbuscar.Name = "txtbuscar";
            this.txtbuscar.Size = new System.Drawing.Size(310, 26);
            this.txtbuscar.TabIndex = 0;
            this.txtbuscar.TextChanged += new System.EventHandler(this.txtbuscar_TextChanged);
            // 
            // PictureBox2
            // 
            this.PictureBox2.BackColor = System.Drawing.Color.White;
            this.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBox2.Image = global::SistemaVentas.Properties.Resources._1486485587_add_create_new_maths_math_signs_plus_81172;
            this.PictureBox2.Location = new System.Drawing.Point(378, 0);
            this.PictureBox2.Name = "PictureBox2";
            this.PictureBox2.Size = new System.Drawing.Size(47, 47);
            this.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox2.TabIndex = 360;
            this.PictureBox2.TabStop = false;
            this.PictureBox2.Click += new System.EventHandler(this.PictureBox2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menuStrip1.BackgroundImage")));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(9, 10);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(43, 26);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.BackgroundImage")));
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(28, 22);
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // panelRegistros
            // 
            this.panelRegistros.BackColor = System.Drawing.Color.White;
            this.panelRegistros.Controls.Add(this.panel5);
            this.panelRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelRegistros.Location = new System.Drawing.Point(132, 196);
            this.panelRegistros.Name = "panelRegistros";
            this.panelRegistros.Size = new System.Drawing.Size(652, 315);
            this.panelRegistros.TabIndex = 6;
            this.panelRegistros.Paint += new System.Windows.Forms.PaintEventHandler(this.panelRegistros_Paint);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Controls.Add(this.label19);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.txtTipo);
            this.panel5.Controls.Add(this.button3);
            this.panel5.Controls.Add(this.txtImpuesto);
            this.panel5.Controls.Add(this.panel4);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.btnGuardarCambios);
            this.panel5.Controls.Add(this.btnGuardar);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.txtnombre);
            this.panel5.Controls.Add(this.Label8);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(652, 315);
            this.panel5.TabIndex = 605;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.White;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Gray;
            this.label19.Location = new System.Drawing.Point(52, 163);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(252, 15);
            this.label19.TabIndex = 658;
            this.label19.Text = "Ejemplo: 18 | Sera dividido automáticamente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(388, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 20);
            this.label2.TabIndex = 657;
            this.label2.Text = "Tipos de Impuestos";
            // 
            // txtTipo
            // 
            this.txtTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtTipo.FormattingEnabled = true;
            this.txtTipo.Items.AddRange(new object[] {


            "IVA",

            "Impuesto Categoria",
            "Impuesto Productos"});
            this.txtTipo.Location = new System.Drawing.Point(392, 57);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new System.Drawing.Size(237, 28);
            this.txtTipo.TabIndex = 656;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImage = global::SistemaVentas.Properties.Resources.negro;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(443, 224);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(186, 43);
            this.button3.TabIndex = 620;
            this.button3.Text = "Volver";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtImpuesto
            // 
            this.txtImpuesto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtImpuesto.Location = new System.Drawing.Point(55, 138);
            this.txtImpuesto.Name = "txtImpuesto";
            this.txtImpuesto.Size = new System.Drawing.Size(237, 19);
            this.txtImpuesto.TabIndex = 628;
            this.txtImpuesto.TextChanged += new System.EventHandler(this.txtApellido_TextChanged);
            this.txtImpuesto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImpuesto_KeyPress);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gray;
            this.panel4.Location = new System.Drawing.Point(55, 159);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(237, 1);
            this.panel4.TabIndex = 627;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(51, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 626;
            this.label3.Text = "Impuesto";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnGuardarCambios
            // 
            this.btnGuardarCambios.BackColor = System.Drawing.Color.Transparent;
            this.btnGuardarCambios.BackgroundImage = global::SistemaVentas.Properties.Resources.Rojo;
            this.btnGuardarCambios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuardarCambios.FlatAppearance.BorderSize = 0;
            this.btnGuardarCambios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnGuardarCambios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnGuardarCambios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarCambios.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarCambios.ForeColor = System.Drawing.Color.White;
            this.btnGuardarCambios.Location = new System.Drawing.Point(227, 224);
            this.btnGuardarCambios.Name = "btnGuardarCambios";
            this.btnGuardarCambios.Size = new System.Drawing.Size(185, 43);
            this.btnGuardarCambios.TabIndex = 619;
            this.btnGuardarCambios.Text = "Guardar Cambios";
            this.btnGuardarCambios.UseVisualStyleBackColor = false;
            this.btnGuardarCambios.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Transparent;
            this.btnGuardar.BackgroundImage = global::SistemaVentas.Properties.Resources.Rojo;
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(55, 224);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(157, 43);
            this.btnGuardar.TabIndex = 618;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Gray;
            this.panel6.Location = new System.Drawing.Point(55, 84);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(233, 1);
            this.panel6.TabIndex = 606;
            this.panel6.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // txtnombre
            // 
            this.txtnombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtnombre.Location = new System.Drawing.Point(55, 59);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(233, 19);
            this.txtnombre.TabIndex = 605;
            this.txtnombre.TextChanged += new System.EventHandler(this.txtnombre_TextChanged);
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.BackColor = System.Drawing.Color.Transparent;
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.Location = new System.Drawing.Point(51, 36);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(65, 20);
            this.Label8.TabIndex = 600;
            this.Label8.Text = "Nombre";
            this.Label8.Click += new System.EventHandler(this.Label8_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            // 
            // dlg
            // 
            this.dlg.FileName = "openFileDialog1";
            this.dlg.FileOk += new System.ComponentModel.CancelEventHandler(this.dlg_FileOk);
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "";
            this.Eliminar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            this.Eliminar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Editar
            // 
            this.Editar.HeaderText = "";
            this.Editar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Editar.Name = "Editar";
            this.Editar.ReadOnly = true;
            // 
            // tiempoBuscador
            // 
            this.tiempoBuscador.Enabled = true;
            this.tiempoBuscador.Interval = 15;
            this.tiempoBuscador.Tick += new System.EventHandler(this.tiempoBuscador_Tick);
            // 
            // datalistado
            // 
            this.datalistado.AllowUserToAddRows = false;
            this.datalistado.AllowUserToDeleteRows = false;
            this.datalistado.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.datalistado.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.datalistado.BackgroundColor = System.Drawing.Color.White;
            this.datalistado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.datalistado.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.datalistado.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datalistado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.datalistado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datalistado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EliminarG,
            this.EditarG});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datalistado.DefaultCellStyle = dataGridViewCellStyle3;
            this.datalistado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datalistado.EnableHeadersVisualStyles = false;
            this.datalistado.Location = new System.Drawing.Point(0, 94);
            this.datalistado.Name = "datalistado";
            this.datalistado.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datalistado.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.datalistado.RowHeadersVisible = false;
            this.datalistado.RowHeadersWidth = 9;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Gainsboro;
            this.datalistado.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.datalistado.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.datalistado.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.datalistado.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            this.datalistado.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.datalistado.RowTemplate.Height = 40;
            this.datalistado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datalistado.Size = new System.Drawing.Size(903, 561);
            this.datalistado.TabIndex = 367;
            this.datalistado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datalistado_CellContentClick_1);
            // 
            // EliminarG
            // 
            this.EliminarG.HeaderText = "";
            this.EliminarG.Image = global::SistemaVentas.Properties.Resources.advertencia;
            this.EliminarG.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.EliminarG.Name = "EliminarG";
            this.EliminarG.ReadOnly = true;
            this.EliminarG.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // EditarG
            // 
            this.EditarG.HeaderText = "";
            this.EditarG.Image = global::SistemaVentas.Properties.Resources.lapiz;
            this.EditarG.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.EditarG.Name = "EditarG";
            this.EditarG.ReadOnly = true;
            // 
            // Impuestos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 655);
            this.Controls.Add(this.panelRegistros);
            this.Controls.Add(this.datalistado);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Impuestos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EmpleadosOK";
            this.Load += new System.EventHandler(this.EmpleadosOK_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelRegistros.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datalistado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtbuscar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Panel panelRegistros;
        internal System.Windows.Forms.PictureBox PictureBox2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.OpenFileDialog dlg;
        internal System.Windows.Forms.DataGridViewImageColumn Eliminar;
        internal System.Windows.Forms.DataGridViewImageColumn Editar;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtImpuesto;
        private System.Windows.Forms.Panel panel4;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Button button3;
        internal System.Windows.Forms.Button btnGuardarCambios;
        internal System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txtnombre;
        internal System.Windows.Forms.Label Label8;
        private System.Windows.Forms.Timer tiempoBuscador;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox txtTipo;
        internal System.Windows.Forms.DataGridView datalistado;
        private System.Windows.Forms.DataGridViewImageColumn EliminarG;
        private System.Windows.Forms.DataGridViewImageColumn EditarG;
        internal System.Windows.Forms.Label label19;
    }
}