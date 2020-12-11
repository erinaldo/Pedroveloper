namespace SistemaVentas.Presentacion.Direccion
{
    partial class Direcciones
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panelNuevo = new System.Windows.Forms.Panel();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dlg = new System.Windows.Forms.OpenFileDialog();
            this.datalistado = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtProvincia = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSector = new System.Windows.Forms.TextBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRegion = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.lblidtipotelefono = new System.Windows.Forms.Label();
            this.lblId_empleado = new System.Windows.Forms.Label();
            this.lblnumeroIcono = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtMunicipio = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.panelRegistros = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.txtbuscar = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.btnGuardarCambios = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Eliminar = new System.Windows.Forms.DataGridViewImageColumn();
            this.EditarG = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1.SuspendLayout();
            this.panelNuevo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datalistado)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panelRegistros.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(939, 47);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Dock = System.Windows.Forms.DockStyle.Right;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(887, 0);
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
            this.label1.Text = "DIRECCIÓN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panelNuevo
            // 
            this.panelNuevo.BackColor = System.Drawing.Color.White;
            this.panelNuevo.Controls.Add(this.PictureBox2);
            this.panelNuevo.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelNuevo.Location = new System.Drawing.Point(757, 94);
            this.panelNuevo.Name = "panelNuevo";
            this.panelNuevo.Size = new System.Drawing.Size(182, 387);
            this.panelNuevo.TabIndex = 7;
            this.panelNuevo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelNuevo_Paint);
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
            this.datalistado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datalistado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EditarG});
            this.datalistado.EnableHeadersVisualStyles = false;
            this.datalistado.Location = new System.Drawing.Point(0, 94);
            this.datalistado.Name = "datalistado";
            this.datalistado.ReadOnly = true;
            this.datalistado.RowHeadersVisible = false;
            this.datalistado.RowHeadersWidth = 9;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            this.datalistado.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.datalistado.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.datalistado.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.datalistado.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            this.datalistado.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.datalistado.RowTemplate.Height = 40;
            this.datalistado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datalistado.Size = new System.Drawing.Size(751, 387);
            this.datalistado.TabIndex = 366;
            this.datalistado.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datalistado_CellClick);
            this.datalistado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datalistado_CellContentClick);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Controls.Add(this.txtProvincia);
            this.panel5.Controls.Add(this.panel3);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.button3);
            this.panel5.Controls.Add(this.txtSector);
            this.panel5.Controls.Add(this.panel11);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Controls.Add(this.txtRegion);
            this.panel5.Controls.Add(this.panel4);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.txtCalle);
            this.panel5.Controls.Add(this.btnGuardarCambios);
            this.panel5.Controls.Add(this.btnGuardar);
            this.panel5.Controls.Add(this.panel10);
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.txtMunicipio);
            this.panel5.Controls.Add(this.txtDescripcion);
            this.panel5.Controls.Add(this.Label5);
            this.panel5.Controls.Add(this.Label6);
            this.panel5.Controls.Add(this.Label8);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(719, 337);
            this.panel5.TabIndex = 605;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // txtProvincia
            // 
            this.txtProvincia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProvincia.Location = new System.Drawing.Point(190, 105);
            this.txtProvincia.Name = "txtProvincia";
            this.txtProvincia.Size = new System.Drawing.Size(237, 19);
            this.txtProvincia.TabIndex = 634;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gray;
            this.panel3.Location = new System.Drawing.Point(190, 126);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(237, 1);
            this.panel3.TabIndex = 633;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(88, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 632;
            this.label2.Text = "Provincia:";
            // 
            // txtSector
            // 
            this.txtSector.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSector.Location = new System.Drawing.Point(188, 172);
            this.txtSector.Name = "txtSector";
            this.txtSector.Size = new System.Drawing.Size(237, 19);
            this.txtSector.TabIndex = 631;
            this.txtSector.TextChanged += new System.EventHandler(this.txtTelefono_TextChanged);
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Gray;
            this.panel11.Location = new System.Drawing.Point(188, 193);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(237, 1);
            this.panel11.TabIndex = 630;
            this.panel11.Paint += new System.Windows.Forms.PaintEventHandler(this.panel11_Paint);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(105, 172);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 20);
            this.label11.TabIndex = 629;
            this.label11.Text = "Sector:";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // txtRegion
            // 
            this.txtRegion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRegion.Location = new System.Drawing.Point(189, 76);
            this.txtRegion.Name = "txtRegion";
            this.txtRegion.Size = new System.Drawing.Size(237, 19);
            this.txtRegion.TabIndex = 628;
            this.txtRegion.TextChanged += new System.EventHandler(this.txtApellido_TextChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gray;
            this.panel4.Location = new System.Drawing.Point(189, 97);
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
            this.label3.Location = new System.Drawing.Point(105, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 626;
            this.label3.Text = "Region:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtCalle
            // 
            this.txtCalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCalle.Location = new System.Drawing.Point(188, 211);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(237, 19);
            this.txtCalle.TabIndex = 625;
            this.txtCalle.TextChanged += new System.EventHandler(this.txtCorreo_TextChanged);
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.lblidtipotelefono);
            this.panel10.Controls.Add(this.lblId_empleado);
            this.panel10.Controls.Add(this.lblnumeroIcono);
            this.panel10.Location = new System.Drawing.Point(25, 37);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(10, 10);
            this.panel10.TabIndex = 615;
            this.panel10.Paint += new System.Windows.Forms.PaintEventHandler(this.panel10_Paint);
            // 
            // lblidtipotelefono
            // 
            this.lblidtipotelefono.AutoSize = true;
            this.lblidtipotelefono.Location = new System.Drawing.Point(26, 20);
            this.lblidtipotelefono.Name = "lblidtipotelefono";
            this.lblidtipotelefono.Size = new System.Drawing.Size(120, 20);
            this.lblidtipotelefono.TabIndex = 614;
            this.lblidtipotelefono.Text = "lblidtipotelefono";
            // 
            // lblId_empleado
            // 
            this.lblId_empleado.AutoSize = true;
            this.lblId_empleado.Location = new System.Drawing.Point(19, 49);
            this.lblId_empleado.Name = "lblId_empleado";
            this.lblId_empleado.Size = new System.Drawing.Size(51, 20);
            this.lblId_empleado.TabIndex = 613;
            this.lblId_empleado.Text = "label2";
            this.lblId_empleado.Click += new System.EventHandler(this.lblId_empleado_Click);
            // 
            // lblnumeroIcono
            // 
            this.lblnumeroIcono.AutoSize = true;
            this.lblnumeroIcono.Location = new System.Drawing.Point(35, 29);
            this.lblnumeroIcono.Name = "lblnumeroIcono";
            this.lblnumeroIcono.Size = new System.Drawing.Size(51, 20);
            this.lblnumeroIcono.TabIndex = 612;
            this.lblnumeroIcono.Text = "label2";
            this.lblnumeroIcono.Click += new System.EventHandler(this.lblnumeroIcono_Click);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Gray;
            this.panel8.Location = new System.Drawing.Point(188, 232);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(237, 1);
            this.panel8.TabIndex = 606;
            this.panel8.Paint += new System.Windows.Forms.PaintEventHandler(this.panel8_Paint);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Gray;
            this.panel7.Location = new System.Drawing.Point(189, 157);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(237, 1);
            this.panel7.TabIndex = 606;
            this.panel7.Paint += new System.Windows.Forms.PaintEventHandler(this.panel7_Paint);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Gray;
            this.panel6.Location = new System.Drawing.Point(189, 56);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(237, 1);
            this.panel6.TabIndex = 606;
            this.panel6.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // txtMunicipio
            // 
            this.txtMunicipio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMunicipio.Location = new System.Drawing.Point(189, 132);
            this.txtMunicipio.Name = "txtMunicipio";
            this.txtMunicipio.Size = new System.Drawing.Size(237, 19);
            this.txtMunicipio.TabIndex = 605;
            this.txtMunicipio.TextChanged += new System.EventHandler(this.txtCedula_TextChanged);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescripcion.Location = new System.Drawing.Point(189, 31);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(237, 19);
            this.txtDescripcion.TabIndex = 605;
            this.txtDescripcion.TextChanged += new System.EventHandler(this.txtnombre_TextChanged);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.BackColor = System.Drawing.Color.Transparent;
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(90, 138);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(79, 20);
            this.Label5.TabIndex = 602;
            this.Label5.Text = "Municipio:";
            this.Label5.Click += new System.EventHandler(this.Label5_Click);
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.BackColor = System.Drawing.Color.White;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(116, 210);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(48, 20);
            this.Label6.TabIndex = 604;
            this.Label6.Text = "Calle:";
            this.Label6.Click += new System.EventHandler(this.Label6_Click);
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.BackColor = System.Drawing.Color.Transparent;
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.Location = new System.Drawing.Point(75, 37);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(96, 20);
            this.Label8.TabIndex = 600;
            this.Label8.Text = "Descripcion:";
            this.Label8.Click += new System.EventHandler(this.Label8_Click);
            // 
            // panelRegistros
            // 
            this.panelRegistros.BackColor = System.Drawing.Color.White;
            this.panelRegistros.Controls.Add(this.panel5);
            this.panelRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelRegistros.Location = new System.Drawing.Point(0, 94);
            this.panelRegistros.Name = "panelRegistros";
            this.panelRegistros.Size = new System.Drawing.Size(719, 337);
            this.panelRegistros.TabIndex = 6;
            this.panelRegistros.Paint += new System.Windows.Forms.PaintEventHandler(this.panelRegistros_Paint);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
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
            // txtbuscar
            // 
            this.txtbuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbuscar.Location = new System.Drawing.Point(55, 10);
            this.txtbuscar.Name = "txtbuscar";
            this.txtbuscar.Size = new System.Drawing.Size(310, 26);
            this.txtbuscar.TabIndex = 0;
            this.txtbuscar.TextChanged += new System.EventHandler(this.txtbuscar_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtbuscar);
            this.panel2.Controls.Add(this.menuStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(939, 47);
            this.panel2.TabIndex = 4;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
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
            this.button3.Location = new System.Drawing.Point(519, 272);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(186, 43);
            this.button3.TabIndex = 620;
            this.button3.Text = "Volver";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
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
            this.btnGuardarCambios.Location = new System.Drawing.Point(240, 272);
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
            this.btnGuardar.Location = new System.Drawing.Point(25, 272);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(157, 43);
            this.btnGuardar.TabIndex = 618;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // PictureBox2
            // 
            this.PictureBox2.BackColor = System.Drawing.SystemColors.Control;
            this.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBox2.Image = global::SistemaVentas.Properties.Resources.addthis;
            this.PictureBox2.Location = new System.Drawing.Point(27, 107);
            this.PictureBox2.Name = "PictureBox2";
            this.PictureBox2.Size = new System.Drawing.Size(128, 135);
            this.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox2.TabIndex = 361;
            this.PictureBox2.TabStop = false;
            this.PictureBox2.Click += new System.EventHandler(this.PictureBox2_Click_1);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripMenuItem1.Image = global::SistemaVentas.Properties.Resources.lapiz1;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(28, 22);
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "";
            this.Eliminar.Image = global::SistemaVentas.Properties.Resources.advertencia;
            this.Eliminar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            this.Eliminar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // EditarG
            // 
            this.EditarG.HeaderText = "Editar";
            this.EditarG.Image = global::SistemaVentas.Properties.Resources.lapiz;
            this.EditarG.Name = "EditarG";
            this.EditarG.ReadOnly = true;
            // 
            // Direcciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 481);
            this.Controls.Add(this.panelRegistros);
            this.Controls.Add(this.datalistado);
            this.Controls.Add(this.panelNuevo);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Direcciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EmpleadosOK";
            this.Load += new System.EventHandler(this.EmpleadosOK_Load);
            this.panel1.ResumeLayout(false);
            this.panelNuevo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datalistado)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panelRegistros.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelNuevo;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.OpenFileDialog dlg;
        internal System.Windows.Forms.DataGridView datalistado;
        internal System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtSector;
        private System.Windows.Forms.Panel panel11;
        internal System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRegion;
        private System.Windows.Forms.Panel panel4;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCalle;
        internal System.Windows.Forms.Button btnGuardarCambios;
        internal System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label lblidtipotelefono;
        private System.Windows.Forms.Label lblId_empleado;
        private System.Windows.Forms.Label lblnumeroIcono;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txtMunicipio;
        private System.Windows.Forms.TextBox txtDescripcion;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label8;
        private System.Windows.Forms.Panel panelRegistros;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.TextBox txtbuscar;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.PictureBox PictureBox2;
        private System.Windows.Forms.TextBox txtProvincia;
        private System.Windows.Forms.Panel panel3;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewImageColumn Eliminar;
        private System.Windows.Forms.DataGridViewImageColumn EditarG;
    }
}