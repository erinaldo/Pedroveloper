namespace SistemaVentas.Presentacion.Geolocalizacion
{
    partial class Geolocalizacion
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
            this.Mapa = new GMap.NET.WindowsForms.GMapControl();
            this.txtLatitud = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.txtLongitud = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Label8 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.panelDataListadoLocalizacion = new System.Windows.Forms.Panel();
            this.datalistadoLocalizacion = new System.Windows.Forms.DataGridView();
            this.btnPoligono = new System.Windows.Forms.Button();
            this.btnRuta = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panelDataListadoLocalizacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datalistadoLocalizacion)).BeginInit();
            this.SuspendLayout();
            // 
            // Mapa
            // 
            this.Mapa.Bearing = 0F;
            this.Mapa.CanDragMap = true;
            this.Mapa.EmptyTileColor = System.Drawing.Color.Navy;
            this.Mapa.GrayScaleMode = false;
            this.Mapa.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.Mapa.LevelsKeepInMemmory = 5;
            this.Mapa.Location = new System.Drawing.Point(12, 12);
            this.Mapa.MarkersEnabled = true;
            this.Mapa.MaxZoom = 2;
            this.Mapa.MinZoom = 2;
            this.Mapa.MouseWheelZoomEnabled = true;
            this.Mapa.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.Mapa.Name = "Mapa";
            this.Mapa.NegativeMode = false;
            this.Mapa.PolygonsEnabled = true;
            this.Mapa.RetryLoadTile = 0;
            this.Mapa.RoutesEnabled = true;
            this.Mapa.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.Mapa.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.Mapa.ShowTileGridLines = false;
            this.Mapa.Size = new System.Drawing.Size(540, 426);
            this.Mapa.TabIndex = 0;
            this.Mapa.Zoom = 0D;
            this.Mapa.Load += new System.EventHandler(this.Mapa_Load);
            this.Mapa.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Mapa_MouseDoubleClick);
            // 
            // txtLatitud
            // 
            this.txtLatitud.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLatitud.Location = new System.Drawing.Point(562, 124);
            this.txtLatitud.Multiline = true;
            this.txtLatitud.Name = "txtLatitud";
            this.txtLatitud.Size = new System.Drawing.Size(417, 19);
            this.txtLatitud.TabIndex = 673;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Gray;
            this.panel8.Location = new System.Drawing.Point(562, 145);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(417, 1);
            this.panel8.TabIndex = 672;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(558, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 20);
            this.label10.TabIndex = 671;
            this.label10.Text = "Latitud";
            // 
            // txtLongitud
            // 
            this.txtLongitud.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLongitud.Location = new System.Drawing.Point(562, 193);
            this.txtLongitud.Multiline = true;
            this.txtLongitud.Name = "txtLongitud";
            this.txtLongitud.Size = new System.Drawing.Size(417, 19);
            this.txtLongitud.TabIndex = 676;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Location = new System.Drawing.Point(562, 214);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(417, 1);
            this.panel1.TabIndex = 675;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(558, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 674;
            this.label1.Text = "Longitud";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescripcion.Location = new System.Drawing.Point(562, 48);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(417, 19);
            this.txtDescripcion.TabIndex = 679;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Location = new System.Drawing.Point(562, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(417, 1);
            this.panel2.TabIndex = 678;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.BackColor = System.Drawing.Color.Transparent;
            this.Label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.Location = new System.Drawing.Point(558, 25);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(92, 20);
            this.Label8.TabIndex = 677;
            this.Label8.Text = "Descripción";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregar.BackgroundImage = global::SistemaVentas.Properties.Resources.negro;
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(562, 232);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(101, 42);
            this.btnAgregar.TabIndex = 680;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Transparent;
            this.btnEliminar.BackgroundImage = global::SistemaVentas.Properties.Resources.negro;
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(669, 232);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(101, 42);
            this.btnEliminar.TabIndex = 681;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // panelDataListadoLocalizacion
            // 
            this.panelDataListadoLocalizacion.Controls.Add(this.datalistadoLocalizacion);
            this.panelDataListadoLocalizacion.Location = new System.Drawing.Point(562, 295);
            this.panelDataListadoLocalizacion.Name = "panelDataListadoLocalizacion";
            this.panelDataListadoLocalizacion.Size = new System.Drawing.Size(311, 143);
            this.panelDataListadoLocalizacion.TabIndex = 682;
            // 
            // datalistadoLocalizacion
            // 
            this.datalistadoLocalizacion.AllowUserToAddRows = false;
            this.datalistadoLocalizacion.AllowUserToDeleteRows = false;
            this.datalistadoLocalizacion.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.datalistadoLocalizacion.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.datalistadoLocalizacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datalistadoLocalizacion.BackgroundColor = System.Drawing.Color.White;
            this.datalistadoLocalizacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.datalistadoLocalizacion.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.datalistadoLocalizacion.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.datalistadoLocalizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datalistadoLocalizacion.ColumnHeadersVisible = false;
            this.datalistadoLocalizacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datalistadoLocalizacion.EnableHeadersVisualStyles = false;
            this.datalistadoLocalizacion.Location = new System.Drawing.Point(0, 0);
            this.datalistadoLocalizacion.Name = "datalistadoLocalizacion";
            this.datalistadoLocalizacion.ReadOnly = true;
            this.datalistadoLocalizacion.RowHeadersVisible = false;
            this.datalistadoLocalizacion.RowHeadersWidth = 9;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            this.datalistadoLocalizacion.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.datalistadoLocalizacion.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.datalistadoLocalizacion.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.datalistadoLocalizacion.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            this.datalistadoLocalizacion.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.datalistadoLocalizacion.RowTemplate.Height = 40;
            this.datalistadoLocalizacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datalistadoLocalizacion.Size = new System.Drawing.Size(311, 143);
            this.datalistadoLocalizacion.TabIndex = 644;
            this.datalistadoLocalizacion.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.datalistadoLocalizacion_CellMouseClick);
            // 
            // btnPoligono
            // 
            this.btnPoligono.BackColor = System.Drawing.Color.Transparent;
            this.btnPoligono.BackgroundImage = global::SistemaVentas.Properties.Resources.negro;
            this.btnPoligono.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPoligono.FlatAppearance.BorderSize = 0;
            this.btnPoligono.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPoligono.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPoligono.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPoligono.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPoligono.ForeColor = System.Drawing.Color.White;
            this.btnPoligono.Location = new System.Drawing.Point(776, 232);
            this.btnPoligono.Name = "btnPoligono";
            this.btnPoligono.Size = new System.Drawing.Size(101, 42);
            this.btnPoligono.TabIndex = 683;
            this.btnPoligono.Text = "Polígono";
            this.btnPoligono.UseVisualStyleBackColor = false;
            this.btnPoligono.Click += new System.EventHandler(this.btnPoligono_Click);
            // 
            // btnRuta
            // 
            this.btnRuta.BackColor = System.Drawing.Color.Transparent;
            this.btnRuta.BackgroundImage = global::SistemaVentas.Properties.Resources.negro;
            this.btnRuta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRuta.FlatAppearance.BorderSize = 0;
            this.btnRuta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRuta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRuta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRuta.ForeColor = System.Drawing.Color.White;
            this.btnRuta.Location = new System.Drawing.Point(883, 232);
            this.btnRuta.Name = "btnRuta";
            this.btnRuta.Size = new System.Drawing.Size(101, 42);
            this.btnRuta.TabIndex = 684;
            this.btnRuta.Text = "Ruta";
            this.btnRuta.UseVisualStyleBackColor = false;
            this.btnRuta.Click += new System.EventHandler(this.btnRuta_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::SistemaVentas.Properties.Resources.negro;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(883, 295);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 65);
            this.button1.TabIndex = 685;
            this.button1.Text = "Como llegar?";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = global::SistemaVentas.Properties.Resources.negro;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(883, 373);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 65);
            this.button2.TabIndex = 686;
            this.button2.Text = "Como llegar?";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Geolocalizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(992, 464);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnRuta);
            this.Controls.Add(this.btnPoligono);
            this.Controls.Add(this.panelDataListadoLocalizacion);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.txtLongitud);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLatitud);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Mapa);
            this.Name = "Geolocalizacion";
            this.Text = "Geolocalizacion";
            this.Load += new System.EventHandler(this.Geolocalizacion_Load);
            this.panelDataListadoLocalizacion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datalistadoLocalizacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl Mapa;
        private System.Windows.Forms.TextBox txtLatitud;
        private System.Windows.Forms.Panel panel8;
        internal System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtLongitud;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Button btnAgregar;
        internal System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Panel panelDataListadoLocalizacion;
        internal System.Windows.Forms.DataGridView datalistadoLocalizacion;
        internal System.Windows.Forms.Button btnPoligono;
        internal System.Windows.Forms.Button btnRuta;
        internal System.Windows.Forms.Button button1;
        internal System.Windows.Forms.Button button2;
    }
}