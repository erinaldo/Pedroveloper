
namespace SistemaVentas.Presentacion.LoginInicio
{
    partial class Inicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.label20 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progressbar = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.CurvaPanelInfoDetallada = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label20.Location = new System.Drawing.Point(275, 295);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(258, 20);
            this.label20.TabIndex = 635;
            this.label20.Text = "© 2020-2021 Pedro Solutions S.A";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label1.Location = new System.Drawing.Point(2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 636;
            this.label1.Text = "Cargando...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label2.Location = new System.Drawing.Point(721, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 637;
            this.label2.Text = "Pedro v8.0.80";
            // 
            // progressbar
            // 
            this.progressbar.animated = false;
            this.progressbar.animationIterval = 5;
            this.progressbar.animationSpeed = 500;
            this.progressbar.BackColor = System.Drawing.Color.Transparent;
            this.progressbar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("progressbar.BackgroundImage")));
            this.progressbar.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.progressbar.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.progressbar.LabelVisible = true;
            this.progressbar.LineProgressThickness = 8;
            this.progressbar.LineThickness = 5;
            this.progressbar.Location = new System.Drawing.Point(290, 58);
            this.progressbar.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.progressbar.MaxValue = 100;
            this.progressbar.Name = "progressbar";
            this.progressbar.ProgressBackColor = System.Drawing.SystemColors.Control;
            this.progressbar.ProgressColor = System.Drawing.Color.White;
            this.progressbar.Size = new System.Drawing.Size(228, 228);
            this.progressbar.TabIndex = 638;
            this.progressbar.Value = 0;
            // 
            // CurvaPanelInfoDetallada
            // 
            this.CurvaPanelInfoDetallada.ElipseRadius = 20;
            this.CurvaPanelInfoDetallada.TargetControl = this;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.progressbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuCircleProgressbar progressbar;
        private Bunifu.Framework.UI.BunifuElipse CurvaPanelInfoDetallada;
        private System.Windows.Forms.Timer timer1;
    }
}