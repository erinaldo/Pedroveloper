namespace SistemaVentas.Presentacion.CopiasBd
{
    partial class GeneradorAutomatico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneradorAutomatico));
            this.Label1 = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.lbltiempo = new System.Windows.Forms.Label();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStripButton22 = new System.Windows.Forms.ToolStripButton();
            this.Pcargando = new System.Windows.Forms.PictureBox();
            this.timerContador = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.volver = new Guna.UI.WinForms.GunaAdvenceButton();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.Panel1.SuspendLayout();
            this.ToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pcargando)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.Label1.Location = new System.Drawing.Point(18, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(193, 24);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Copia de seguridad";
            // 
            // Panel1
            // 
            this.Panel1.BackgroundImage = global::SistemaVentas.Properties.Resources.this_BackgroundImage;
            this.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel1.Controls.Add(this.txtRuta);
            this.Panel1.Controls.Add(this.pictureBox8);
            this.Panel1.Controls.Add(this.volver);
            this.Panel1.Controls.Add(this.lbltiempo);
            this.Panel1.Controls.Add(this.Label4);
            this.Panel1.Controls.Add(this.Label2);
            this.Panel1.Controls.Add(this.ToolStrip1);
            this.Panel1.Location = new System.Drawing.Point(22, 36);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(491, 304);
            this.Panel1.TabIndex = 615;
            // 
            // lbltiempo
            // 
            this.lbltiempo.AutoSize = true;
            this.lbltiempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.lbltiempo.Location = new System.Drawing.Point(191, 62);
            this.lbltiempo.Name = "lbltiempo";
            this.lbltiempo.Size = new System.Drawing.Size(107, 76);
            this.lbltiempo.TabIndex = 599;
            this.lbltiempo.Text = "10";
            // 
            // txtRuta
            // 
            this.txtRuta.BackColor = System.Drawing.Color.White;
            this.txtRuta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRuta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtRuta.Enabled = false;
            this.txtRuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtRuta.Location = new System.Drawing.Point(62, 228);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Size = new System.Drawing.Size(397, 19);
            this.txtRuta.TabIndex = 1;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.BackColor = System.Drawing.Color.White;
            this.Label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.Label4.Location = new System.Drawing.Point(50, 14);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(388, 48);
            this.Label4.TabIndex = 0;
            this.Label4.Text = "SE GENERARA COPIA DE SEGURIDAD \r\nPROGRAMADA EN:";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.White;
            this.Label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Label2.Location = new System.Drawing.Point(58, 198);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(218, 20);
            this.Label2.TabIndex = 0;
            this.Label2.Text = "Ruta de Copias de Seguridad";
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.AutoSize = false;
            this.ToolStrip1.BackColor = System.Drawing.Color.White;
            this.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripButton22});
            this.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.ToolStrip1.Location = new System.Drawing.Point(20, 186);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ToolStrip1.Size = new System.Drawing.Size(56, 52);
            this.ToolStrip1.TabIndex = 595;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // ToolStripButton22
            // 
            this.ToolStripButton22.BackColor = System.Drawing.Color.White;
            this.ToolStripButton22.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.ToolStripButton22.ForeColor = System.Drawing.Color.Black;
            this.ToolStripButton22.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton22.Image")));
            this.ToolStripButton22.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolStripButton22.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton22.Name = "ToolStripButton22";
            this.ToolStripButton22.Size = new System.Drawing.Size(37, 49);
            this.ToolStripButton22.Text = "+";
            this.ToolStripButton22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolStripButton22.ToolTipText = "Buscar Ruta";
            // 
            // Pcargando
            // 
            this.Pcargando.Image = ((System.Drawing.Image)(resources.GetObject("Pcargando.Image")));
            this.Pcargando.Location = new System.Drawing.Point(22, 340);
            this.Pcargando.Name = "Pcargando";
            this.Pcargando.Size = new System.Drawing.Size(491, 146);
            this.Pcargando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Pcargando.TabIndex = 616;
            this.Pcargando.TabStop = false;
            this.Pcargando.Visible = false;
            // 
            // timerContador
            // 
            this.timerContador.Interval = 1000;
            this.timerContador.Tick += new System.EventHandler(this.timerContador_Tick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::SistemaVentas.Properties.Resources.this_BackgroundImage;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.Label1);
            this.panel2.Controls.Add(this.Pcargando);
            this.panel2.Controls.Add(this.Panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(542, 562);
            this.panel2.TabIndex = 617;
            // 
            // volver
            // 
            this.volver.AnimationHoverSpeed = 0.07F;
            this.volver.AnimationSpeed = 0.03F;
            this.volver.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.volver.BorderColor = System.Drawing.Color.Black;
            this.volver.CheckedBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(25)))), ((int)(((byte)(46)))));
            this.volver.CheckedBorderColor = System.Drawing.Color.Black;
            this.volver.CheckedForeColor = System.Drawing.Color.White;
            this.volver.CheckedImage = ((System.Drawing.Image)(resources.GetObject("volver.CheckedImage")));
            this.volver.CheckedLineColor = System.Drawing.Color.DimGray;
            this.volver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.volver.DialogResult = System.Windows.Forms.DialogResult.None;
            this.volver.FocusedColor = System.Drawing.Color.Empty;
            this.volver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.volver.ForeColor = System.Drawing.Color.White;
            this.volver.Image = ((System.Drawing.Image)(resources.GetObject("volver.Image")));
            this.volver.ImageSize = new System.Drawing.Size(20, 20);
            this.volver.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.volver.Location = new System.Drawing.Point(20, 140);
            this.volver.Name = "volver";
            this.volver.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(25)))), ((int)(((byte)(46)))));
            this.volver.OnHoverBorderColor = System.Drawing.Color.Black;
            this.volver.OnHoverForeColor = System.Drawing.Color.White;
            this.volver.OnHoverImage = null;
            this.volver.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.volver.OnPressedColor = System.Drawing.Color.Black;
            this.volver.Size = new System.Drawing.Size(447, 42);
            this.volver.TabIndex = 665;
            this.volver.Text = "Cancelar";
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(54, 221);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(413, 34);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 686;
            this.pictureBox8.TabStop = false;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 7;
            this.bunifuElipse2.TargetControl = this;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 7;
            this.bunifuElipse1.TargetControl = this.volver;
            // 
            // GeneradorAutomatico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(542, 562);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GeneradorAutomatico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GeneradorAutomatico_FormClosing);
            this.Load += new System.EventHandler(this.GeneradorAutomatico_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pcargando)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label lbltiempo;
        internal System.Windows.Forms.TextBox txtRuta;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton ToolStripButton22;
        internal System.Windows.Forms.PictureBox Pcargando;
        private System.Windows.Forms.Timer timerContador;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI.WinForms.GunaAdvenceButton volver;
        private System.Windows.Forms.PictureBox pictureBox8;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
    }
}