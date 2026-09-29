using System.Windows.Forms;

namespace Proyecto_IS
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblAppNombre;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Label lblRol;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblAppNombre = new System.Windows.Forms.Label();
            this.lblRol = new System.Windows.Forms.Label();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuAdministracion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGestionUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBitacora = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGestionPerfiles = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGestionFamilias = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGestionRespaldo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMaestros = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMaestroProductos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMaestroClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCarrito = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFacturar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCambiarIdioma = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCambiarContrasena = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIniciarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAppNombre
            // 
            this.lblAppNombre.AutoSize = true;
            this.lblAppNombre.Font = new System.Drawing.Font("Segoe UI Black", 16F, System.Drawing.FontStyle.Bold);
            this.lblAppNombre.Location = new System.Drawing.Point(430, 563);
            this.lblAppNombre.Name = "lblAppNombre";
            this.lblAppNombre.Size = new System.Drawing.Size(208, 37);
            this.lblAppNombre.TabIndex = 0;
            this.lblAppNombre.Text = "BIENVENIDO!!";
            // 
            // lblRol
            // 
            this.lblRol.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblRol.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblRol.ForeColor = System.Drawing.Color.DimGray;
            this.lblRol.Location = new System.Drawing.Point(0, 440);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(220, 20);
            this.lblRol.TabIndex = 0;
            this.lblRol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblBienvenida.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBienvenida.Location = new System.Drawing.Point(0, 460);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(220, 30);
            this.lblBienvenida.TabIndex = 0;
            this.lblBienvenida.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAdministracion,
            this.mnuMaestros,
            this.mnuVentas,
            this.mnuUsuario,
            this.reportesToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1104, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuAdministracion
            // 
            this.mnuAdministracion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGestionUsuarios,
            this.mnuBitacora,
            this.mnuGestionPerfiles,
            this.mnuGestionFamilias,
            this.mnuGestionRespaldo});
            this.mnuAdministracion.Name = "mnuAdministracion";
            this.mnuAdministracion.Size = new System.Drawing.Size(118, 24);
            this.mnuAdministracion.Text = "Administrador";
            // 
            // mnuGestionUsuarios
            // 
            this.mnuGestionUsuarios.Name = "mnuGestionUsuarios";
            this.mnuGestionUsuarios.Size = new System.Drawing.Size(224, 26);
            this.mnuGestionUsuarios.Text = "Gestion Usuarios";
            this.mnuGestionUsuarios.Click += new System.EventHandler(this.mnuGestionUsuarios_Click_1);
            // 
            // mnuBitacora
            // 
            this.mnuBitacora.Name = "mnuBitacora";
            this.mnuBitacora.Size = new System.Drawing.Size(224, 26);
            this.mnuBitacora.Text = "Bitacora eventos";
            this.mnuBitacora.Click += new System.EventHandler(this.mnuBitacora_Click_1);
            // 
            // mnuGestionPerfiles
            // 
            this.mnuGestionPerfiles.Name = "mnuGestionPerfiles";
            this.mnuGestionPerfiles.Size = new System.Drawing.Size(224, 26);
            this.mnuGestionPerfiles.Text = "Gestion Perfiles";
            this.mnuGestionPerfiles.Click += new System.EventHandler(this.mnuGestionPerfiles_Click);
            // 
            // mnuGestionFamilias
            // 
            this.mnuGestionFamilias.Name = "mnuGestionFamilias";
            this.mnuGestionFamilias.Size = new System.Drawing.Size(224, 26);
            this.mnuGestionFamilias.Text = "Gestion Familias";
            this.mnuGestionFamilias.Click += new System.EventHandler(this.mnuGestionFamilias_Click);
            // 
            // mnuGestionRespaldo
            // 
            this.mnuGestionRespaldo.Name = "mnuGestionRespaldo";
            this.mnuGestionRespaldo.Size = new System.Drawing.Size(224, 26);
            this.mnuGestionRespaldo.Text = "Gestion Respaldo";
            this.mnuGestionRespaldo.Click += new System.EventHandler(this.mnuGestionRespaldo_Click);
            // 
            // mnuMaestros
            // 
            this.mnuMaestros.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMaestroProductos,
            this.mnuMaestroClientes});
            this.mnuMaestros.Name = "mnuMaestros";
            this.mnuMaestros.Size = new System.Drawing.Size(77, 24);
            this.mnuMaestros.Text = "Maestro";
            // 
            // mnuMaestroProductos
            // 
            this.mnuMaestroProductos.Name = "mnuMaestroProductos";
            this.mnuMaestroProductos.Size = new System.Drawing.Size(158, 26);
            this.mnuMaestroProductos.Text = "Productos";
            this.mnuMaestroProductos.Click += new System.EventHandler(this.mnuMaestroProductos_Click);
            // 
            // mnuMaestroClientes
            // 
            this.mnuMaestroClientes.Name = "mnuMaestroClientes";
            this.mnuMaestroClientes.Size = new System.Drawing.Size(158, 26);
            this.mnuMaestroClientes.Text = "Clientes";
            this.mnuMaestroClientes.Click += new System.EventHandler(this.mnuMaestroClientes_Click);
            // 
            // mnuVentas
            // 
            this.mnuVentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCarrito,
            this.mnuFacturar});
            this.mnuVentas.Name = "mnuVentas";
            this.mnuVentas.Size = new System.Drawing.Size(66, 24);
            this.mnuVentas.Text = "Ventas";
            // 
            // mnuCarrito
            // 
            this.mnuCarrito.Name = "mnuCarrito";
            this.mnuCarrito.Size = new System.Drawing.Size(144, 26);
            this.mnuCarrito.Text = "Carrito";
            this.mnuCarrito.Click += new System.EventHandler(this.mnuCarrito_Click_1);
            // 
            // mnuFacturar
            // 
            this.mnuFacturar.Name = "mnuFacturar";
            this.mnuFacturar.Size = new System.Drawing.Size(144, 26);
            this.mnuFacturar.Text = "Facturar";
            this.mnuFacturar.Click += new System.EventHandler(this.mnuFacturar_Click_1);
            // 
            // mnuUsuario
            // 
            this.mnuUsuario.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCambiarIdioma,
            this.mnuCambiarContrasena,
            this.mnuCerrarSesion,
            this.mnuIniciarSesion});
            this.mnuUsuario.Name = "mnuUsuario";
            this.mnuUsuario.Size = new System.Drawing.Size(73, 24);
            this.mnuUsuario.Text = "Usuario";
            // 
            // mnuCambiarIdioma
            // 
            this.mnuCambiarIdioma.Name = "mnuCambiarIdioma";
            this.mnuCambiarIdioma.Size = new System.Drawing.Size(226, 26);
            this.mnuCambiarIdioma.Text = "Cambiar Idioma";
            this.mnuCambiarIdioma.Click += new System.EventHandler(this.mnuCambiarIdioma_Click);
            // 
            // mnuCambiarContrasena
            // 
            this.mnuCambiarContrasena.Name = "mnuCambiarContrasena";
            this.mnuCambiarContrasena.Size = new System.Drawing.Size(226, 26);
            this.mnuCambiarContrasena.Text = "Cambiar Contraseña";
            this.mnuCambiarContrasena.Click += new System.EventHandler(this.mnuCambiarContrasena_Click_1);
            // 
            // mnuCerrarSesion
            // 
            this.mnuCerrarSesion.Name = "mnuCerrarSesion";
            this.mnuCerrarSesion.Size = new System.Drawing.Size(226, 26);
            this.mnuCerrarSesion.Text = "Cerrar Sesion";
            this.mnuCerrarSesion.Click += new System.EventHandler(this.mnuCerrarSesion_Click_1);
            // 
            // mnuIniciarSesion
            // 
            this.mnuIniciarSesion.Name = "mnuIniciarSesion";
            this.mnuIniciarSesion.Size = new System.Drawing.Size(226, 26);
            this.mnuIniciarSesion.Text = "Iniciar sesion";
            this.mnuIniciarSesion.Click += new System.EventHandler(this.mnuIniciarSesion_Click_1);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // panelHeader
            // 
            this.panelHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelHeader.Controls.Add(this.menuStrip1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1106, 132);
            this.panelHeader.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1106, 644);
            this.Controls.Add(this.lblAppNombre);
            this.Controls.Add(this.panelHeader);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuAdministracion;
        private ToolStripMenuItem mnuGestionUsuarios;
        private ToolStripMenuItem mnuBitacora;
        private ToolStripMenuItem mnuGestionPerfiles;
        private ToolStripMenuItem mnuGestionFamilias;
        private ToolStripMenuItem mnuGestionRespaldo;
        private ToolStripMenuItem mnuMaestros;
        private ToolStripMenuItem mnuMaestroProductos;
        private ToolStripMenuItem mnuMaestroClientes;
        private ToolStripMenuItem mnuVentas;
        private ToolStripMenuItem mnuCarrito;
        private ToolStripMenuItem mnuFacturar;
        private ToolStripMenuItem mnuUsuario;
        private ToolStripMenuItem mnuCambiarIdioma;
        private ToolStripMenuItem mnuCambiarContrasena;
        private ToolStripMenuItem mnuCerrarSesion;
        private ToolStripMenuItem mnuIniciarSesion;
        private ToolStripMenuItem reportesToolStripMenuItem;
        private ToolStripMenuItem ayudaToolStripMenuItem;
        private Panel panelHeader;
    }
}