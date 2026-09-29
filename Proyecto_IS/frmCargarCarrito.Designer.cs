namespace Proyecto_IS
{
    partial class frmCargarCarrito
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
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.btnFinalizarCarga = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.btnRegistrarCliente = new System.Windows.Forms.Button();
            this.dgvCarrito = new System.Windows.Forms.DataGridView();
            this.lblCliente = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.lblDni.Location = new System.Drawing.Point(24, 33);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(77, 16);
            this.lblDni.TabIndex = 0;
            this.lblDni.Text = "DNI Cliente:";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.BackColor = System.Drawing.Color.White;
            this.lblSubtotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.lblSubtotal.Location = new System.Drawing.Point(512, 431);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(93, 16);
            this.lblSubtotal.TabIndex = 1;
            this.lblSubtotal.Text = "Subtotal: $0.00";
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(140, 30);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(100, 22);
            this.txtDni.TabIndex = 2;
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.btnBuscarCliente.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBuscarCliente.Location = new System.Drawing.Point(284, 30);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(153, 43);
            this.btnBuscarCliente.TabIndex = 3;
            this.btnBuscarCliente.Text = "Buscar";
            this.btnBuscarCliente.UseVisualStyleBackColor = false;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // btnFinalizarCarga
            // 
            this.btnFinalizarCarga.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.btnFinalizarCarga.ForeColor = System.Drawing.SystemColors.Control;
            this.btnFinalizarCarga.Location = new System.Drawing.Point(407, 473);
            this.btnFinalizarCarga.Name = "btnFinalizarCarga";
            this.btnFinalizarCarga.Size = new System.Drawing.Size(153, 43);
            this.btnFinalizarCarga.TabIndex = 4;
            this.btnFinalizarCarga.Text = "Finalizar Carga";
            this.btnFinalizarCarga.UseVisualStyleBackColor = false;
            this.btnFinalizarCarga.Click += new System.EventHandler(this.btnFinalizarCarga_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCancelar.Location = new System.Drawing.Point(582, 473);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(153, 43);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.btnAgregarProducto.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAgregarProducto.Location = new System.Drawing.Point(27, 404);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(153, 43);
            this.btnAgregarProducto.TabIndex = 6;
            this.btnAgregarProducto.Text = "Seleccionar Productos";
            this.btnAgregarProducto.UseVisualStyleBackColor = false;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // btnRegistrarCliente
            // 
            this.btnRegistrarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.btnRegistrarCliente.ForeColor = System.Drawing.SystemColors.Control;
            this.btnRegistrarCliente.Location = new System.Drawing.Point(484, 33);
            this.btnRegistrarCliente.Name = "btnRegistrarCliente";
            this.btnRegistrarCliente.Size = new System.Drawing.Size(153, 43);
            this.btnRegistrarCliente.TabIndex = 7;
            this.btnRegistrarCliente.Text = "Registrar Cliente";
            this.btnRegistrarCliente.UseVisualStyleBackColor = false;
            this.btnRegistrarCliente.Visible = false;
            this.btnRegistrarCliente.Click += new System.EventHandler(this.btnRegistrarCliente_Click);
            // 
            // dgvCarrito
            // 
            this.dgvCarrito.AllowUserToAddRows = false;
            this.dgvCarrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarrito.Location = new System.Drawing.Point(17, 162);
            this.dgvCarrito.Name = "dgvCarrito";
            this.dgvCarrito.ReadOnly = true;
            this.dgvCarrito.RowHeadersWidth = 51;
            this.dgvCarrito.RowTemplate.Height = 24;
            this.dgvCarrito.Size = new System.Drawing.Size(485, 221);
            this.dgvCarrito.TabIndex = 8;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.lblCliente.Location = new System.Drawing.Point(27, 96);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(12, 18);
            this.lblCliente.TabIndex = 9;
            this.lblCliente.Text = " ";
            this.lblCliente.Visible = false;
            // 
            // frmCargarCarrito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 539);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.dgvCarrito);
            this.Controls.Add(this.btnRegistrarCliente);
            this.Controls.Add(this.btnAgregarProducto);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnFinalizarCarga);
            this.Controls.Add(this.btnBuscarCliente);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.lblDni);
            this.Name = "frmCargarCarrito";
            this.Text = "frmCargarCarrito";
            this.Load += new System.EventHandler(this.frmCargarCarrito_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.Button btnFinalizarCarga;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.Button btnRegistrarCliente;
        private System.Windows.Forms.DataGridView dgvCarrito;
        private System.Windows.Forms.Label lblCliente;
    }
}