namespace SistemaVentas.Presentacion.CAJA
{
    partial class CierreTurno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CierreTurno));
            this.label1 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.lblDeberiaHaber = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txthay = new System.Windows.Forms.TextBox();
            this.lbldiferencia = new System.Windows.Forms.Label();
            this.checkCorreo = new System.Windows.Forms.CheckBox();
            this.txtcorreo = new System.Windows.Forms.TextBox();
            this.lblanuncio = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.htmldeEnvio = new System.Windows.Forms.TextBox();
            this.Panelregistro = new System.Windows.Forms.Panel();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.guardar = new Guna.UI.WinForms.GunaAdvenceButton();
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse3 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Panelregistro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(-31, -32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(394, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cierre de Turno";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.BackColor = System.Drawing.Color.White;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(94, 136);
            this.Label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(199, 20);
            this.Label6.TabIndex = 194;
            this.Label6.Text = "Efectivo esperado en Caja:";
            // 
            // lblDeberiaHaber
            // 
            this.lblDeberiaHaber.AutoSize = true;
            this.lblDeberiaHaber.BackColor = System.Drawing.Color.White;
            this.lblDeberiaHaber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblDeberiaHaber.ForeColor = System.Drawing.Color.Black;
            this.lblDeberiaHaber.Location = new System.Drawing.Point(170, 168);
            this.lblDeberiaHaber.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDeberiaHaber.Name = "lblDeberiaHaber";
            this.lblDeberiaHaber.Size = new System.Drawing.Size(44, 20);
            this.lblDeberiaHaber.TabIndex = 195;
            this.lblDeberiaHaber.Text = "0.00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(66, 201);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 20);
            this.label2.TabIndex = 196;
            this.label2.Text = "¿Cuanto de Efectivo hay en Caja?";
            // 
            // txthay
            // 
            this.txthay.BackColor = System.Drawing.Color.White;
            this.txthay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txthay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txthay.ForeColor = System.Drawing.Color.Black;
            this.txthay.Location = new System.Drawing.Point(94, 249);
            this.txthay.Name = "txthay";
            this.txthay.Size = new System.Drawing.Size(201, 19);
            this.txthay.TabIndex = 197;
            this.txthay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txthay.TextChanged += new System.EventHandler(this.txthay_TextChanged);
            this.txthay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txthay_KeyPress);
            // 
            // lbldiferencia
            // 
            this.lbldiferencia.AutoSize = true;
            this.lbldiferencia.BackColor = System.Drawing.Color.White;
            this.lbldiferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lbldiferencia.ForeColor = System.Drawing.Color.Gray;
            this.lbldiferencia.Location = new System.Drawing.Point(170, 277);
            this.lbldiferencia.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbldiferencia.Name = "lbldiferencia";
            this.lbldiferencia.Size = new System.Drawing.Size(44, 20);
            this.lbldiferencia.TabIndex = 602;
            this.lbldiferencia.Text = "0.00";
            // 
            // checkCorreo
            // 
            this.checkCorreo.AutoSize = true;
            this.checkCorreo.BackColor = System.Drawing.Color.White;
            this.checkCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkCorreo.ForeColor = System.Drawing.Color.Black;
            this.checkCorreo.Location = new System.Drawing.Point(12, 322);
            this.checkCorreo.Name = "checkCorreo";
            this.checkCorreo.Size = new System.Drawing.Size(111, 21);
            this.checkCorreo.TabIndex = 603;
            this.checkCorreo.Text = "Se enviara a:";
            this.checkCorreo.UseVisualStyleBackColor = false;
            this.checkCorreo.CheckedChanged += new System.EventHandler(this.checkCorreo_CheckedChanged);
            this.checkCorreo.Click += new System.EventHandler(this.checkCorreo_Click);
            // 
            // txtcorreo
            // 
            this.txtcorreo.BackColor = System.Drawing.Color.White;
            this.txtcorreo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtcorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtcorreo.ForeColor = System.Drawing.Color.Black;
            this.txtcorreo.Location = new System.Drawing.Point(138, 324);
            this.txtcorreo.Name = "txtcorreo";
            this.txtcorreo.Size = new System.Drawing.Size(201, 19);
            this.txtcorreo.TabIndex = 604;
            // 
            // lblanuncio
            // 
            this.lblanuncio.BackColor = System.Drawing.Color.White;
            this.lblanuncio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblanuncio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(63)))), ((int)(((byte)(67)))));
            this.lblanuncio.Location = new System.Drawing.Point(21, 460);
            this.lblanuncio.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblanuncio.Name = "lblanuncio";
            this.lblanuncio.Size = new System.Drawing.Size(342, 47);
            this.lblanuncio.TabIndex = 607;
            this.lblanuncio.Text = "...";
            this.lblanuncio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblanuncio.Visible = false;
            this.lblanuncio.Click += new System.EventHandler(this.lblanuncio_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(28, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(335, 112);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // htmldeEnvio
            // 
            this.htmldeEnvio.BackColor = System.Drawing.Color.White;
            this.htmldeEnvio.Location = new System.Drawing.Point(119, 12);
            this.htmldeEnvio.Multiline = true;
            this.htmldeEnvio.Name = "htmldeEnvio";
            this.htmldeEnvio.Size = new System.Drawing.Size(217, 93);
            this.htmldeEnvio.TabIndex = 608;
            this.htmldeEnvio.Text = resources.GetString("htmldeEnvio.Text");
            // 
            // Panelregistro
            // 
            this.Panelregistro.BackColor = System.Drawing.Color.White;
            this.Panelregistro.BackgroundImage = global::SistemaVentas.Properties.Resources.this_BackgroundImage;
            this.Panelregistro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panelregistro.Controls.Add(this.guardar);
            this.Panelregistro.Controls.Add(this.lblanuncio);
            this.Panelregistro.Controls.Add(this.label2);
            this.Panelregistro.Controls.Add(this.label1);
            this.Panelregistro.Controls.Add(this.txtcorreo);
            this.Panelregistro.Controls.Add(this.pictureBox1);
            this.Panelregistro.Controls.Add(this.checkCorreo);
            this.Panelregistro.Controls.Add(this.Label6);
            this.Panelregistro.Controls.Add(this.lbldiferencia);
            this.Panelregistro.Controls.Add(this.lblDeberiaHaber);
            this.Panelregistro.Controls.Add(this.txthay);
            this.Panelregistro.Controls.Add(this.htmldeEnvio);
            this.Panelregistro.Controls.Add(this.pictureBox8);
            this.Panelregistro.Controls.Add(this.pictureBox2);
            this.Panelregistro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panelregistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Panelregistro.Location = new System.Drawing.Point(0, 0);
            this.Panelregistro.Name = "Panelregistro";
            this.Panelregistro.Size = new System.Drawing.Size(394, 528);
            this.Panelregistro.TabIndex = 609;
            this.Panelregistro.Visible = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(129, 313);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(225, 34);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 686;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(70, 240);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(245, 34);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 687;
            this.pictureBox2.TabStop = false;
            // 
            // guardar
            // 
            this.guardar.AnimationHoverSpeed = 0.07F;
            this.guardar.AnimationSpeed = 0.03F;
            this.guardar.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.guardar.BorderColor = System.Drawing.Color.Black;
            this.guardar.CheckedBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(25)))), ((int)(((byte)(46)))));
            this.guardar.CheckedBorderColor = System.Drawing.Color.Black;
            this.guardar.CheckedForeColor = System.Drawing.Color.White;
            this.guardar.CheckedImage = ((System.Drawing.Image)(resources.GetObject("guardar.CheckedImage")));
            this.guardar.CheckedLineColor = System.Drawing.Color.DimGray;
            this.guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guardar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.guardar.FocusedColor = System.Drawing.Color.Empty;
            this.guardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.guardar.ForeColor = System.Drawing.Color.White;
            this.guardar.Image = ((System.Drawing.Image)(resources.GetObject("guardar.Image")));
            this.guardar.ImageSize = new System.Drawing.Size(20, 20);
            this.guardar.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.guardar.Location = new System.Drawing.Point(25, 388);
            this.guardar.Name = "guardar";
            this.guardar.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(25)))), ((int)(((byte)(46)))));
            this.guardar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.guardar.OnHoverForeColor = System.Drawing.Color.White;
            this.guardar.OnHoverImage = null;
            this.guardar.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.guardar.OnPressedColor = System.Drawing.Color.Black;
            this.guardar.Size = new System.Drawing.Size(329, 42);
            this.guardar.TabIndex = 688;
            this.guardar.Text = "Cerrar turno";
            this.guardar.Click += new System.EventHandler(this.guardar_Click);
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 7;
            this.bunifuElipse2.TargetControl = this.guardar;
            // 
            // bunifuElipse3
            // 
            this.bunifuElipse3.ElipseRadius = 7;
            this.bunifuElipse3.TargetControl = this;
            // 
            // CierreTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(394, 528);
            this.Controls.Add(this.Panelregistro);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CierreTurno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.CierreTurno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Panelregistro.ResumeLayout(false);
            this.Panelregistro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label lblDeberiaHaber;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txthay;
        internal System.Windows.Forms.Label lbldiferencia;
        private System.Windows.Forms.CheckBox checkCorreo;
        internal System.Windows.Forms.TextBox txtcorreo;
        internal System.Windows.Forms.Label lblanuncio;
        private System.Windows.Forms.TextBox htmldeEnvio;
        private System.Windows.Forms.Panel Panelregistro;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Guna.UI.WinForms.GunaAdvenceButton guardar;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse3;
    }
}