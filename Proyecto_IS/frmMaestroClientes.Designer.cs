namespace Proyecto_IS
{
    partial class frmMaestroClientes
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
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnAnadir = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCelular = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtRutaSerializar = new System.Windows.Forms.TextBox();
            this.btnBuscarSerializar = new System.Windows.Forms.Button();
            this.btnSerializar = new System.Windows.Forms.Button();
            this.txtRutaDesSerializar = new System.Windows.Forms.TextBox();
            this.btnDesSerializar = new System.Windows.Forms.Button();
            this.btnBuscarDesSerializar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvClientes
            // 
            this.dgvClientes.AllowUserToAddRows = false;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Location = new System.Drawing.Point(26, 25);
            this.dgvClientes.MultiSelect = false;
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.ReadOnly = true;
            this.dgvClientes.RowHeadersVisible = false;
            this.dgvClientes.RowHeadersWidth = 51;
            this.dgvClientes.RowTemplate.Height = 24;
            this.dgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientes.Size = new System.Drawing.Size(500, 267);
            this.dgvClientes.TabIndex = 0;
            this.dgvClientes.SelectionChanged += new System.EventHandler(this.DgvClientes_SelectionChanged);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.btnActualizar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnActualizar.Location = new System.Drawing.Point(957, 49);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(153, 43);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnAnadir
            // 
            this.btnAnadir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.btnAnadir.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAnadir.Location = new System.Drawing.Point(957, 119);
            this.btnAnadir.Name = "btnAnadir";
            this.btnAnadir.Size = new System.Drawing.Size(153, 43);
            this.btnAnadir.TabIndex = 2;
            this.btnAnadir.Text = "Añadir";
            this.btnAnadir.UseVisualStyleBackColor = false;
            this.btnAnadir.Click += new System.EventHandler(this.btnAnadir_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.btnModificar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnModificar.Location = new System.Drawing.Point(957, 178);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(153, 43);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEliminar.Location = new System.Drawing.Point(957, 249);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(153, 43);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.label1.Location = new System.Drawing.Point(648, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "DNI:";
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(745, 84);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(131, 22);
            this.txtDni.TabIndex = 6;
            // 
            // txtApellidos
            // 
            this.txtApellidos.Location = new System.Drawing.Point(745, 125);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(131, 22);
            this.txtApellidos.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.label2.Location = new System.Drawing.Point(648, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Apellidos:";
            // 
            // txtNombres
            // 
            this.txtNombres.Location = new System.Drawing.Point(745, 165);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(131, 22);
            this.txtNombres.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.label3.Location = new System.Drawing.Point(648, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Nombre:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(745, 215);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(131, 22);
            this.txtEmail.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.label4.Location = new System.Drawing.Point(648, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Email:";
            // 
            // txtCelular
            // 
            this.txtCelular.Location = new System.Drawing.Point(745, 249);
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(131, 22);
            this.txtCelular.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.label5.Location = new System.Drawing.Point(648, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Celular:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(745, 291);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(131, 22);
            this.txtDireccion.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.label6.Location = new System.Drawing.Point(648, 298);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Dirección:";
            // 
            // txtMensaje
            // 
            this.txtMensaje.Location = new System.Drawing.Point(745, 336);
            this.txtMensaje.Multiline = true;
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.ReadOnly = true;
            this.txtMensaje.Size = new System.Drawing.Size(131, 22);
            this.txtMensaje.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.label7.Location = new System.Drawing.Point(648, 343);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "Mensaje:";
            // 
            // btnAplicar
            // 
            this.btnAplicar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.btnAplicar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAplicar.Location = new System.Drawing.Point(957, 316);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(153, 43);
            this.btnAplicar.TabIndex = 19;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = false;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCancelar.Location = new System.Drawing.Point(957, 458);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(153, 43);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtRutaSerializar
            // 
            this.txtRutaSerializar.Location = new System.Drawing.Point(26, 312);
            this.txtRutaSerializar.Name = "txtRutaSerializar";
            this.txtRutaSerializar.Size = new System.Drawing.Size(341, 22);
            this.txtRutaSerializar.TabIndex = 22;
            // 
            // btnBuscarSerializar
            // 
            this.btnBuscarSerializar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.btnBuscarSerializar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBuscarSerializar.Location = new System.Drawing.Point(26, 350);
            this.btnBuscarSerializar.Name = "btnBuscarSerializar";
            this.btnBuscarSerializar.Size = new System.Drawing.Size(153, 43);
            this.btnBuscarSerializar.TabIndex = 23;
            this.btnBuscarSerializar.Text = "📁";
            this.btnBuscarSerializar.UseVisualStyleBackColor = false;
            this.btnBuscarSerializar.Click += new System.EventHandler(this.btnBuscarSerializar_Click);
            // 
            // btnSerializar
            // 
            this.btnSerializar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.btnSerializar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSerializar.Location = new System.Drawing.Point(206, 350);
            this.btnSerializar.Name = "btnSerializar";
            this.btnSerializar.Size = new System.Drawing.Size(153, 43);
            this.btnSerializar.TabIndex = 24;
            this.btnSerializar.Text = "SERIALIZAR";
            this.btnSerializar.UseVisualStyleBackColor = false;
            this.btnSerializar.Click += new System.EventHandler(this.btnSerializar_Click);
            // 
            // txtRutaDesSerializar
            // 
            this.txtRutaDesSerializar.Location = new System.Drawing.Point(26, 414);
            this.txtRutaDesSerializar.Name = "txtRutaDesSerializar";
            this.txtRutaDesSerializar.Size = new System.Drawing.Size(341, 22);
            this.txtRutaDesSerializar.TabIndex = 25;
            // 
            // btnDesSerializar
            // 
            this.btnDesSerializar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.btnDesSerializar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnDesSerializar.Location = new System.Drawing.Point(206, 458);
            this.btnDesSerializar.Name = "btnDesSerializar";
            this.btnDesSerializar.Size = new System.Drawing.Size(153, 43);
            this.btnDesSerializar.TabIndex = 27;
            this.btnDesSerializar.Text = "DES-SERIALIZAR";
            this.btnDesSerializar.UseVisualStyleBackColor = false;
            this.btnDesSerializar.Click += new System.EventHandler(this.btnDesSerializar_Click);
            // 
            // btnBuscarDesSerializar
            // 
            this.btnBuscarDesSerializar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.btnBuscarDesSerializar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBuscarDesSerializar.Location = new System.Drawing.Point(26, 458);
            this.btnBuscarDesSerializar.Name = "btnBuscarDesSerializar";
            this.btnBuscarDesSerializar.Size = new System.Drawing.Size(153, 43);
            this.btnBuscarDesSerializar.TabIndex = 26;
            this.btnBuscarDesSerializar.Text = "📁";
            this.btnBuscarDesSerializar.UseVisualStyleBackColor = false;
            this.btnBuscarDesSerializar.Click += new System.EventHandler(this.btnBuscarDesSerializar_Click_1);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(110)))), ((int)(((byte)(117)))));
            this.btnLimpiar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnLimpiar.Location = new System.Drawing.Point(745, 458);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(153, 43);
            this.btnLimpiar.TabIndex = 28;
            this.btnLimpiar.Text = "LIMPIAR";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // frmMaestroClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 513);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnDesSerializar);
            this.Controls.Add(this.btnBuscarDesSerializar);
            this.Controls.Add(this.txtRutaDesSerializar);
            this.Controls.Add(this.btnSerializar);
            this.Controls.Add(this.btnBuscarSerializar);
            this.Controls.Add(this.txtRutaSerializar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.txtMensaje);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCelular);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNombres);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtApellidos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAnadir);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.dgvClientes);
            this.Name = "frmMaestroClientes";
            this.Text = "frmMaestroClientes";
            this.Load += new System.EventHandler(this.frmMaestroClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnAnadir;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCelular;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMensaje;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtRutaSerializar;
        private System.Windows.Forms.Button btnBuscarSerializar;
        private System.Windows.Forms.Button btnSerializar;
        private System.Windows.Forms.TextBox txtRutaDesSerializar;
        private System.Windows.Forms.Button btnDesSerializar;
        private System.Windows.Forms.Button btnBuscarDesSerializar;
        private System.Windows.Forms.Button btnLimpiar;
    }
}