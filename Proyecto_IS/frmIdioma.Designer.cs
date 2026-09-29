namespace Proyecto_IS
{
    partial class frmIdioma
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
            System.Windows.Forms.Label lblTituloPantalla;
            this.cmbIdiomas = new System.Windows.Forms.ComboBox();
            this.btnGuardarIdioma = new System.Windows.Forms.Button();
            this.lblSeleccionarIdioma = new System.Windows.Forms.Label();
            lblTituloPantalla = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbIdiomas
            // 
            this.cmbIdiomas.FormattingEnabled = true;
            this.cmbIdiomas.Location = new System.Drawing.Point(125, 162);
            this.cmbIdiomas.Name = "cmbIdiomas";
            this.cmbIdiomas.Size = new System.Drawing.Size(142, 24);
            this.cmbIdiomas.TabIndex = 0;
            // 
            // lblTituloPantalla
            // 
            lblTituloPantalla.AutoSize = true;
            lblTituloPantalla.Font = new System.Drawing.Font("Nirmala UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblTituloPantalla.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            lblTituloPantalla.Location = new System.Drawing.Point(60, 53);
            lblTituloPantalla.Name = "lblTituloPantalla";
            lblTituloPantalla.Size = new System.Drawing.Size(316, 46);
            lblTituloPantalla.TabIndex = 41;
            lblTituloPantalla.Text = "CAMBIAR IDIOMA";
            // 
            // btnGuardarIdioma
            // 
            this.btnGuardarIdioma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.btnGuardarIdioma.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarIdioma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarIdioma.ForeColor = System.Drawing.Color.White;
            this.btnGuardarIdioma.Location = new System.Drawing.Point(125, 206);
            this.btnGuardarIdioma.Name = "btnGuardarIdioma";
            this.btnGuardarIdioma.Size = new System.Drawing.Size(142, 30);
            this.btnGuardarIdioma.TabIndex = 54;
            this.btnGuardarIdioma.Text = "GUARDAR";
            this.btnGuardarIdioma.UseVisualStyleBackColor = false;
            this.btnGuardarIdioma.Click += new System.EventHandler(this.btnGuardarIdioma_Click);
            // 
            // lblSeleccionarIdioma
            // 
            this.lblSeleccionarIdioma.AutoSize = true;
            this.lblSeleccionarIdioma.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeleccionarIdioma.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.lblSeleccionarIdioma.Location = new System.Drawing.Point(29, 109);
            this.lblSeleccionarIdioma.Name = "lblSeleccionarIdioma";
            this.lblSeleccionarIdioma.Size = new System.Drawing.Size(151, 32);
            this.lblSeleccionarIdioma.TabIndex = 55;
            this.lblSeleccionarIdioma.Text = " Seleccionar";
            this.lblSeleccionarIdioma.Click += new System.EventHandler(this.lblSeleccionarIdioma_Click);
            // 
            // frmIdioma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 338);
            this.Controls.Add(this.lblSeleccionarIdioma);
            this.Controls.Add(this.btnGuardarIdioma);
            this.Controls.Add(lblTituloPantalla);
            this.Controls.Add(this.cmbIdiomas);
            this.Name = "frmIdioma";
            this.Text = "frmIdioma";
            this.Load += new System.EventHandler(this.frmIdioma_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbIdiomas;
        private System.Windows.Forms.Button btnGuardarIdioma;
        private System.Windows.Forms.Label lblSeleccionarIdioma;
    }
}