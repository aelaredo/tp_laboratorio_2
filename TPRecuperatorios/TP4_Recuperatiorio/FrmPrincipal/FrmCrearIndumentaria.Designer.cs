
namespace FrmPrincipal
{
    partial class FrmCrearIndumentaria
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
            this.grpTipoIndu = new System.Windows.Forms.GroupBox();
            this.rdbCamiseta = new System.Windows.Forms.RadioButton();
            this.rdbZapatilla = new System.Windows.Forms.RadioButton();
            this.lblSuela = new System.Windows.Forms.Label();
            this.lblCapellada = new System.Windows.Forms.Label();
            this.lblPorcent = new System.Windows.Forms.Label();
            this.lblModelo = new System.Windows.Forms.Label();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.rdbEstampado = new System.Windows.Forms.RadioButton();
            this.rdbNoEstampada = new System.Windows.Forms.RadioButton();
            this.numPorcent = new System.Windows.Forms.NumericUpDown();
            this.btnNuevaIndumentaria = new System.Windows.Forms.Button();
            this.cmbSuela = new System.Windows.Forms.ComboBox();
            this.cmbCapellada = new System.Windows.Forms.ComboBox();
            this.pbCreacion = new System.Windows.Forms.ProgressBar();
            this.grpTipoIndu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPorcent)).BeginInit();
            this.SuspendLayout();
            // 
            // grpTipoIndu
            // 
            this.grpTipoIndu.Controls.Add(this.rdbCamiseta);
            this.grpTipoIndu.Controls.Add(this.rdbZapatilla);
            this.grpTipoIndu.Location = new System.Drawing.Point(15, 20);
            this.grpTipoIndu.Name = "grpTipoIndu";
            this.grpTipoIndu.Size = new System.Drawing.Size(152, 50);
            this.grpTipoIndu.TabIndex = 0;
            this.grpTipoIndu.TabStop = false;
            // 
            // rdbCamiseta
            // 
            this.rdbCamiseta.AutoSize = true;
            this.rdbCamiseta.Location = new System.Drawing.Point(77, 19);
            this.rdbCamiseta.Name = "rdbCamiseta";
            this.rdbCamiseta.Size = new System.Drawing.Size(68, 17);
            this.rdbCamiseta.TabIndex = 1;
            this.rdbCamiseta.TabStop = true;
            this.rdbCamiseta.Text = "Camiseta";
            this.rdbCamiseta.UseVisualStyleBackColor = true;
            this.rdbCamiseta.CheckedChanged += new System.EventHandler(this.rdbCamiseta_CheckedChanged);
            // 
            // rdbZapatilla
            // 
            this.rdbZapatilla.AutoSize = true;
            this.rdbZapatilla.Location = new System.Drawing.Point(6, 19);
            this.rdbZapatilla.Name = "rdbZapatilla";
            this.rdbZapatilla.Size = new System.Drawing.Size(65, 17);
            this.rdbZapatilla.TabIndex = 0;
            this.rdbZapatilla.TabStop = true;
            this.rdbZapatilla.Text = "Zapatilla";
            this.rdbZapatilla.UseVisualStyleBackColor = true;
            this.rdbZapatilla.CheckedChanged += new System.EventHandler(this.rdbZapatilla_CheckedChanged);
            // 
            // lblSuela
            // 
            this.lblSuela.AutoSize = true;
            this.lblSuela.Location = new System.Drawing.Point(265, 26);
            this.lblSuela.Name = "lblSuela";
            this.lblSuela.Size = new System.Drawing.Size(34, 13);
            this.lblSuela.TabIndex = 1;
            this.lblSuela.Text = "Suela";
            this.lblSuela.Visible = false;
            // 
            // lblCapellada
            // 
            this.lblCapellada.AutoSize = true;
            this.lblCapellada.Location = new System.Drawing.Point(174, 26);
            this.lblCapellada.Name = "lblCapellada";
            this.lblCapellada.Size = new System.Drawing.Size(54, 13);
            this.lblCapellada.TabIndex = 3;
            this.lblCapellada.Text = "Capellada";
            this.lblCapellada.Visible = false;
            // 
            // lblPorcent
            // 
            this.lblPorcent.AutoSize = true;
            this.lblPorcent.Location = new System.Drawing.Point(177, 22);
            this.lblPorcent.Name = "lblPorcent";
            this.lblPorcent.Size = new System.Drawing.Size(57, 13);
            this.lblPorcent.TabIndex = 5;
            this.lblPorcent.Text = "% Algodon";
            this.lblPorcent.Visible = false;
            // 
            // lblModelo
            // 
            this.lblModelo.AutoSize = true;
            this.lblModelo.Location = new System.Drawing.Point(196, 70);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(42, 13);
            this.lblModelo.TabIndex = 7;
            this.lblModelo.Text = "Modelo";
            this.lblModelo.Visible = false;
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(244, 67);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(120, 20);
            this.txtModelo.TabIndex = 10;
            this.txtModelo.Visible = false;
            // 
            // rdbEstampado
            // 
            this.rdbEstampado.AutoSize = true;
            this.rdbEstampado.Location = new System.Drawing.Point(184, 46);
            this.rdbEstampado.Name = "rdbEstampado";
            this.rdbEstampado.Size = new System.Drawing.Size(78, 17);
            this.rdbEstampado.TabIndex = 11;
            this.rdbEstampado.TabStop = true;
            this.rdbEstampado.Text = "Estampada";
            this.rdbEstampado.UseVisualStyleBackColor = true;
            this.rdbEstampado.Visible = false;
            // 
            // rdbNoEstampada
            // 
            this.rdbNoEstampada.AutoSize = true;
            this.rdbNoEstampada.Location = new System.Drawing.Point(268, 47);
            this.rdbNoEstampada.Name = "rdbNoEstampada";
            this.rdbNoEstampada.Size = new System.Drawing.Size(95, 17);
            this.rdbNoEstampada.TabIndex = 12;
            this.rdbNoEstampada.TabStop = true;
            this.rdbNoEstampada.Text = "No Estampada";
            this.rdbNoEstampada.UseVisualStyleBackColor = true;
            this.rdbNoEstampada.Visible = false;
            // 
            // numPorcent
            // 
            this.numPorcent.Location = new System.Drawing.Point(244, 12);
            this.numPorcent.Name = "numPorcent";
            this.numPorcent.Size = new System.Drawing.Size(120, 20);
            this.numPorcent.TabIndex = 13;
            this.numPorcent.Visible = false;
            // 
            // btnNuevaIndumentaria
            // 
            this.btnNuevaIndumentaria.Location = new System.Drawing.Point(391, 33);
            this.btnNuevaIndumentaria.Name = "btnNuevaIndumentaria";
            this.btnNuevaIndumentaria.Size = new System.Drawing.Size(108, 37);
            this.btnNuevaIndumentaria.TabIndex = 14;
            this.btnNuevaIndumentaria.Text = "Generar Nueva Indumentaria";
            this.btnNuevaIndumentaria.UseVisualStyleBackColor = true;
            this.btnNuevaIndumentaria.Click += new System.EventHandler(this.btnNuevaIndumentaria_Click);
            // 
            // cmbSuela
            // 
            this.cmbSuela.FormattingEnabled = true;
            this.cmbSuela.Location = new System.Drawing.Point(268, 42);
            this.cmbSuela.Name = "cmbSuela";
            this.cmbSuela.Size = new System.Drawing.Size(85, 21);
            this.cmbSuela.TabIndex = 15;
            // 
            // cmbCapellada
            // 
            this.cmbCapellada.FormattingEnabled = true;
            this.cmbCapellada.Location = new System.Drawing.Point(177, 42);
            this.cmbCapellada.Name = "cmbCapellada";
            this.cmbCapellada.Size = new System.Drawing.Size(85, 21);
            this.cmbCapellada.TabIndex = 16;
            // 
            // pbCreacion
            // 
            this.pbCreacion.Location = new System.Drawing.Point(15, 92);
            this.pbCreacion.Name = "pbCreacion";
            this.pbCreacion.Size = new System.Drawing.Size(484, 23);
            this.pbCreacion.TabIndex = 18;
            // 
            // FrmCrearIndumentaria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 122);
            this.Controls.Add(this.pbCreacion);
            this.Controls.Add(this.cmbCapellada);
            this.Controls.Add(this.cmbSuela);
            this.Controls.Add(this.btnNuevaIndumentaria);
            this.Controls.Add(this.numPorcent);
            this.Controls.Add(this.rdbNoEstampada);
            this.Controls.Add(this.rdbEstampado);
            this.Controls.Add(this.txtModelo);
            this.Controls.Add(this.lblModelo);
            this.Controls.Add(this.lblPorcent);
            this.Controls.Add(this.lblCapellada);
            this.Controls.Add(this.lblSuela);
            this.Controls.Add(this.grpTipoIndu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmCrearIndumentaria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear Indumentaria Laredo.Agustin.2C";
            this.Load += new System.EventHandler(this.FrmCrearIndumentaria_Load);
            this.grpTipoIndu.ResumeLayout(false);
            this.grpTipoIndu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPorcent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpTipoIndu;
        private System.Windows.Forms.RadioButton rdbCamiseta;
        private System.Windows.Forms.RadioButton rdbZapatilla;
        private System.Windows.Forms.Label lblSuela;
        private System.Windows.Forms.Label lblCapellada;
        private System.Windows.Forms.Label lblPorcent;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.RadioButton rdbEstampado;
        private System.Windows.Forms.RadioButton rdbNoEstampada;
        private System.Windows.Forms.NumericUpDown numPorcent;
        private System.Windows.Forms.Button btnNuevaIndumentaria;
        private System.Windows.Forms.ComboBox cmbSuela;
        private System.Windows.Forms.ComboBox cmbCapellada;
        private System.Windows.Forms.ProgressBar pbCreacion;
    }
}