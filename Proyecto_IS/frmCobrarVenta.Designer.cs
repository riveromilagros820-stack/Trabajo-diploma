namespace Proyecto_IS
{
    partial class frmCobrarVenta
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
            this.lblTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rbEfectivo = new System.Windows.Forms.RadioButton();
            this.rbTarjeta = new System.Windows.Forms.RadioButton();
            this.txtBanco = new System.Windows.Forms.TextBox();
            this.txtCodSeguridad = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtVencimiento = new System.Windows.Forms.TextBox();
            this.chkSimularRechazo = new System.Windows.Forms.CheckBox();
            this.btnConfirmarPago = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlDatosTarjeta = new System.Windows.Forms.Panel();
            this.pnlDatosTarjeta.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(76, 47);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(52, 16);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "lblTotal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(21, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Banco";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Número:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Vencimiento";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Cód. Seguridad:";
            // 
            // rbEfectivo
            // 
            this.rbEfectivo.AutoSize = true;
            this.rbEfectivo.Checked = true;
            this.rbEfectivo.Location = new System.Drawing.Point(64, 89);
            this.rbEfectivo.Name = "rbEfectivo";
            this.rbEfectivo.Size = new System.Drawing.Size(76, 20);
            this.rbEfectivo.TabIndex = 5;
            this.rbEfectivo.TabStop = true;
            this.rbEfectivo.Text = "Efectivo";
            this.rbEfectivo.UseVisualStyleBackColor = true;
            this.rbEfectivo.CheckedChanged += new System.EventHandler(this.MedioDePago_CheckedChanged);
            // 
            // rbTarjeta
            // 
            this.rbTarjeta.AutoSize = true;
            this.rbTarjeta.Location = new System.Drawing.Point(172, 89);
            this.rbTarjeta.Name = "rbTarjeta";
            this.rbTarjeta.Size = new System.Drawing.Size(71, 20);
            this.rbTarjeta.TabIndex = 6;
            this.rbTarjeta.Text = "Tarjeta";
            this.rbTarjeta.UseVisualStyleBackColor = true;
            // 
            // txtBanco
            // 
            this.txtBanco.Location = new System.Drawing.Point(132, 22);
            this.txtBanco.Name = "txtBanco";
            this.txtBanco.Size = new System.Drawing.Size(175, 22);
            this.txtBanco.TabIndex = 7;
            // 
            // txtCodSeguridad
            // 
            this.txtCodSeguridad.Location = new System.Drawing.Point(131, 167);
            this.txtCodSeguridad.Name = "txtCodSeguridad";
            this.txtCodSeguridad.Size = new System.Drawing.Size(176, 22);
            this.txtCodSeguridad.TabIndex = 8;
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(131, 70);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(176, 22);
            this.txtNumero.TabIndex = 9;
            // 
            // txtVencimiento
            // 
            this.txtVencimiento.Location = new System.Drawing.Point(131, 119);
            this.txtVencimiento.Name = "txtVencimiento";
            this.txtVencimiento.Size = new System.Drawing.Size(176, 22);
            this.txtVencimiento.TabIndex = 10;
            // 
            // chkSimularRechazo
            // 
            this.chkSimularRechazo.AutoSize = true;
            this.chkSimularRechazo.Location = new System.Drawing.Point(24, 225);
            this.chkSimularRechazo.Name = "chkSimularRechazo";
            this.chkSimularRechazo.Size = new System.Drawing.Size(189, 20);
            this.chkSimularRechazo.TabIndex = 11;
            this.chkSimularRechazo.Text = "Simular rechazo del Banco";
            this.chkSimularRechazo.UseVisualStyleBackColor = true;
            // 
            // btnConfirmarPago
            // 
            this.btnConfirmarPago.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.btnConfirmarPago.ForeColor = System.Drawing.SystemColors.Control;
            this.btnConfirmarPago.Location = new System.Drawing.Point(62, 270);
            this.btnConfirmarPago.Name = "btnConfirmarPago";
            this.btnConfirmarPago.Size = new System.Drawing.Size(153, 43);
            this.btnConfirmarPago.TabIndex = 12;
            this.btnConfirmarPago.Text = "Confirmar Pago";
            this.btnConfirmarPago.UseVisualStyleBackColor = false;
            this.btnConfirmarPago.Click += new System.EventHandler(this.btnConfirmarPago_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCancelar.Location = new System.Drawing.Point(62, 319);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(153, 43);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // pnlDatosTarjeta
            // 
            this.pnlDatosTarjeta.Controls.Add(this.label2);
            this.pnlDatosTarjeta.Controls.Add(this.btnConfirmarPago);
            this.pnlDatosTarjeta.Controls.Add(this.btnCancelar);
            this.pnlDatosTarjeta.Controls.Add(this.txtBanco);
            this.pnlDatosTarjeta.Controls.Add(this.label3);
            this.pnlDatosTarjeta.Controls.Add(this.chkSimularRechazo);
            this.pnlDatosTarjeta.Controls.Add(this.txtNumero);
            this.pnlDatosTarjeta.Controls.Add(this.txtCodSeguridad);
            this.pnlDatosTarjeta.Controls.Add(this.txtVencimiento);
            this.pnlDatosTarjeta.Controls.Add(this.label4);
            this.pnlDatosTarjeta.Controls.Add(this.label5);
            this.pnlDatosTarjeta.Location = new System.Drawing.Point(40, 147);
            this.pnlDatosTarjeta.Name = "pnlDatosTarjeta";
            this.pnlDatosTarjeta.Size = new System.Drawing.Size(341, 381);
            this.pnlDatosTarjeta.TabIndex = 14;
            this.pnlDatosTarjeta.Visible = false;
            this.pnlDatosTarjeta.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDatosTarjeta_Paint);
            // 
            // frmCobrarVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 557);
            this.Controls.Add(this.pnlDatosTarjeta);
            this.Controls.Add(this.rbTarjeta);
            this.Controls.Add(this.rbEfectivo);
            this.Controls.Add(this.lblTotal);
            this.Name = "frmCobrarVenta";
            this.Text = "frmCobrarVenta";
            this.Load += new System.EventHandler(this.frmCobrarVenta_Load);
            this.pnlDatosTarjeta.ResumeLayout(false);
            this.pnlDatosTarjeta.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbEfectivo;
        private System.Windows.Forms.RadioButton rbTarjeta;
        private System.Windows.Forms.TextBox txtBanco;
        private System.Windows.Forms.TextBox txtCodSeguridad;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtVencimiento;
        private System.Windows.Forms.CheckBox chkSimularRechazo;
        private System.Windows.Forms.Button btnConfirmarPago;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel pnlDatosTarjeta;
    }
}