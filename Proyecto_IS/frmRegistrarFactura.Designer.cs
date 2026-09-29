namespace Proyecto_IS
{
    partial class frmRegistrarFactura
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
            this.lblDni = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.btnBuscarCarrito = new System.Windows.Forms.Button();
            this.btnFinalizarCarga = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.lblDni.Location = new System.Drawing.Point(33, 37);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(77, 16);
            this.lblDni.TabIndex = 0;
            this.lblDni.Text = "DNI Cliente:";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.lblCliente.Location = new System.Drawing.Point(33, 72);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(10, 16);
            this.lblCliente.TabIndex = 1;
            this.lblCliente.Text = " ";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.lblTotal.Location = new System.Drawing.Point(532, 63);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(75, 16);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "Total: $0.00";
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(166, 37);
            this.txtDni.Name = "txtDni";
            this.txtDni.ShortcutsEnabled = false;
            this.txtDni.Size = new System.Drawing.Size(100, 22);
            this.txtDni.TabIndex = 3;
            // 
            // btnBuscarCarrito
            // 
            this.btnBuscarCarrito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.btnBuscarCarrito.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBuscarCarrito.Location = new System.Drawing.Point(518, 119);
            this.btnBuscarCarrito.Name = "btnBuscarCarrito";
            this.btnBuscarCarrito.Size = new System.Drawing.Size(153, 43);
            this.btnBuscarCarrito.TabIndex = 4;
            this.btnBuscarCarrito.Text = "Buscar Carrito";
            this.btnBuscarCarrito.UseVisualStyleBackColor = false;
            this.btnBuscarCarrito.Click += new System.EventHandler(this.btnBuscarCarrito_Click);
            // 
            // btnFinalizarCarga
            // 
            this.btnFinalizarCarga.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.btnFinalizarCarga.Enabled = false;
            this.btnFinalizarCarga.ForeColor = System.Drawing.SystemColors.Control;
            this.btnFinalizarCarga.Location = new System.Drawing.Point(518, 196);
            this.btnFinalizarCarga.Name = "btnFinalizarCarga";
            this.btnFinalizarCarga.Size = new System.Drawing.Size(153, 43);
            this.btnFinalizarCarga.TabIndex = 5;
            this.btnFinalizarCarga.Text = "Finalizar Carga";
            this.btnFinalizarCarga.UseVisualStyleBackColor = false;
            this.btnFinalizarCarga.Click += new System.EventHandler(this.btnFinalizarCarga_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCancelar.Location = new System.Drawing.Point(518, 265);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(153, 43);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToOrderColumns = true;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Location = new System.Drawing.Point(12, 119);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersWidth = 51;
            this.dgvDetalle.RowTemplate.Height = 24;
            this.dgvDetalle.Size = new System.Drawing.Size(467, 274);
            this.dgvDetalle.TabIndex = 7;
            // 
            // frmRegistrarFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnFinalizarCarga);
            this.Controls.Add(this.btnBuscarCarrito);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblDni);
            this.Name = "frmRegistrarFactura";
            this.Text = "frmRegistrarFactura";
            this.Load += new System.EventHandler(this.frmRegistrarFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Button btnBuscarCarrito;
        private System.Windows.Forms.Button btnFinalizarCarga;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridView dgvDetalle;
    }
}