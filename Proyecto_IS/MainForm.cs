using BLL;
using Servicios;
using Servicios_65RD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_IS
{
    public partial class MainForm : Form , IidiomaObserver
    {

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            IdiomaManager.GetInstance().RegisterObserver(this);
            UpdateIdioma(IdiomaManager.GetInstance().IdiomaActual);

        }

        private readonly string _rol;
        private readonly string _nombre;
        private readonly int _usuarioId;

        private static readonly Color ColorHeader = Color.FromArgb(255, 255, 255);
        private static readonly Color ColorMenu = Color.FromArgb(248, 249, 250);
        private static readonly Color ColorFondoContenido = Color.FromArgb(235, 238, 245);
        private static readonly Color ColorAccent = Color.FromArgb(123, 97, 255);
        private static readonly Color ColorHover = Color.FromArgb(220, 215, 255);
        private static readonly Color ColorTextoPrincipal = Color.FromArgb(40, 40, 40);


        public MainForm(int usuarioId, string nombre, string rol)
        {
            _usuarioId = usuarioId;
            _nombre = nombre;
            _rol = rol;

            InitializeComponent();
            ConfigurarVentana();
            ConfigurarMenu();
            ActualizarBienvenida();

            IdiomaManager.GetInstance().RegisterObserver(this);
            UpdateIdioma(IdiomaManager.GetInstance().IdiomaActual);
        }

        
        private void ConfigurarVentana()
        {
            this.Size = new Size(1000, 750);
            this.MinimumSize = new Size(800, 550);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);

            panelHeader.BackColor = ColorHeader;
            // panelMenu ya no se usa para armar botones (eso lo hace ahora
            // el MenuStrip de arriba). Si no lo estás usando para nada más,
            // lo podés sacar del Designer; si lo dejaste, no molesta.

            
        }


        private void ConfigurarMenu()
        {
            bool canGestionUsuarios = SessionManager_65RD.Instancia.TienePermiso("Gestión de Usuarios");
            bool canBitacora = SessionManager_65RD.Instancia.TienePermiso("Ver Bitácora");
            bool canGestionRoles = SessionManager_65RD.Instancia.TienePermiso("Gestión de Perfiles");
            bool canGestionFamilias = SessionManager_65RD.Instancia.TienePermiso("Gestión de Familias");
            bool canRespaldo = SessionManager_65RD.Instancia.TienePermiso("Gestión de Respaldo");

            mnuGestionUsuarios.Visible = canGestionUsuarios;
            mnuBitacora.Visible = canBitacora;
            mnuGestionPerfiles.Visible = canGestionRoles;
            mnuGestionFamilias.Visible = canGestionFamilias;
            mnuGestionRespaldo.Visible = canRespaldo;
            mnuAdministracion.Visible = canGestionUsuarios || canBitacora || canGestionRoles
                                      || canGestionFamilias || canRespaldo;

            bool canProductos = SessionManager_65RD.Instancia.TienePermiso("Gestión de Productos");
            bool canClientes = SessionManager_65RD.Instancia.TienePermiso("Gestión de Clientes");

            mnuMaestroProductos.Visible = canProductos;
            mnuMaestroClientes.Visible = canClientes;
            mnuMaestros.Visible = canProductos || canClientes;

            bool canCarrito = SessionManager_65RD.Instancia.TienePermiso("Carga de Carrito");
            bool canFacturar = SessionManager_65RD.Instancia.TienePermiso("Facturación");

            mnuCarrito.Visible = canCarrito;
            mnuFacturar.Visible = canFacturar;
            mnuVentas.Visible = canCarrito || canFacturar;

            // "Usuario" (idioma, contraseña, sesión) queda siempre visible.
        }

        private void AbrirMaestroProductos(object sender, EventArgs e)
        {
            frmMaestroProductos frm = new frmMaestroProductos();
            frm.ShowDialog();
        }

        private void AbrirMaestroClientes(object sender, EventArgs e)
        {
            frmMaestroClientes frm = new frmMaestroClientes();
            frm.ShowDialog();
        }

        private void AbrirCarrito(object sender, EventArgs e)
        {
            frmCargarCarrito frm = new frmCargarCarrito();
            frm.ShowDialog();
        }

        private void AbrirFacturar(object sender, EventArgs e)
        {
            frmRegistrarFactura frm = new frmRegistrarFactura();
            frm.ShowDialog();
        }

        private void AbrirGestionRespaldo(object sender, EventArgs e)
        {
            frmGestionRespaldo frm = new frmGestionRespaldo();
            frm.ShowDialog();
        }

        private void ReLogin(object sender, EventArgs e)
        {
            if (SessionManager_65RD.Instancia.UsuarioLogueado != null)
            {
                string msgCuerpo = IdiomaManager.GetInstance().GetTexto(this.Name, "msgSesionActivaCuerpo");
                string msgTitulo = IdiomaManager.GetInstance().GetTexto(this.Name, "msgSesionActivaTitulo");

                DialogResult advertencia = MessageBox.Show(msgCuerpo, msgTitulo, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (advertencia == DialogResult.No)
                {
                    return;
                }

                int idUsuarioActual = SessionManager_65RD.Instancia.UsuarioLogueado.Id;
                new BitacoraBLL_65RD().RegistrarEvento(idUsuarioActual, "Usuarios", "Logout", 1, "Cierre de sesión por cambio de usuario (ReLogin)");

                SessionManager_65RD.Instancia.CerrarSesion();
            }

            frmLogin login = new frmLogin();
            login.EsReLogin = true;
            login.Show();
            this.Hide();

            login.FormClosed += (s, args) =>
            {
                if (SessionManager_65RD.Instancia.UsuarioLogueado != null)
                {
                    this.Show();
                }
                else
                {
                    Application.Exit();
                }
            };
        }

        private void ActualizarBienvenida()
        {
            string saludo = IdiomaManager.GetInstance().GetTexto(this.Name, "lblHola");
            lblBienvenido.Text = $"{saludo}, {_nombre}";

            string rolAdmin = IdiomaManager.GetInstance().GetTexto(this.Name, "lblRolAdmin");
            string rolBasico = IdiomaManager.GetInstance().GetTexto(this.Name, "lblRolBasico");

            lblRoll.Text = _rol == "Administrador" ? rolAdmin : rolBasico;
        }

        private void AbrirGestionUsuarios(object sender, EventArgs e)
        {
            frmGestionUsuarios frmGestion = new frmGestionUsuarios();
            frmGestion.ShowDialog();
        }

        private void AbrirBitacora(object sender, EventArgs e)
        {
            frmBitacoraEventos frmBitacora = new frmBitacoraEventos();
            frmBitacora.ShowDialog();
        }

        private void AbrirCambiarIdioma(object sender, EventArgs e)
        {
            frmIdioma frmIdioma = new frmIdioma();
            frmIdioma.ShowDialog();
        
        }

        private void CerrarSesion(object sender, EventArgs e)
        {
            string msgCuerpo = IdiomaManager.GetInstance().GetTexto(this.Name, "msgCerrarSesionCuerpo");
            string msgTitulo = IdiomaManager.GetInstance().GetTexto(this.Name, "msgCerrarSesionTitulo");

            var res = MessageBox.Show(msgCuerpo, msgTitulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                if (SessionManager_65RD.Instancia.UsuarioLogueado != null)
                {
                    int idUsuarioActual = SessionManager_65RD.Instancia.UsuarioLogueado.Id;
                    BitacoraBLL_65RD bitacora = new BitacoraBLL_65RD();
                    bitacora.RegistrarEvento(idUsuarioActual, "Usuarios", "Logout", 1, "El usuario cerró sesión desde el menú principal");
                }

                SessionManager_65RD.Instancia.CerrarSesion();
                IdiomaManager.GetInstance().CambiarIdioma("es");
                this.Hide();
                frmLogin login = new frmLogin();
                login.Show();
            }
        }

        private void MostrarContenido(string titulo, string descripcion)
        {
           
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            IdiomaManager.GetInstance().RemoveObserver(this);
        }

        public void UpdateIdioma(string idioma)
        {
            this.Text = IdiomaManager.GetInstance().GetTexto(this.Name, "lblTituloVentana");


            ActualizarBienvenida();
            ConfigurarMenu();
        }

        private void AbrirGestionRoles(object sender, EventArgs e)
        {
            frmGestionPerfiles frm = new frmGestionPerfiles();
            frm.ShowDialog();
        }

        private void AbrirGestionFamilias(object sender, EventArgs e)
        {
            frmGestionFamilias frm = new frmGestionFamilias();
            frm.ShowDialog();
        }

        private void AbrirCambiarContraseña(object sender, EventArgs e)
        {
            frmCambioContraseña frm = new frmCambioContraseña();
            frm.ShowDialog();
        }

        private void panelContenido_Paint(object sender, PaintEventArgs e)
        {
        }


        private void mnuCarrito_Click_1(object sender, EventArgs e)
        {
            AbrirCarrito(sender, e);
        }

        private void mnuGestionUsuarios_Click_1(object sender, EventArgs e)
        {
            AbrirGestionUsuarios(sender, e);
        }

        private void mnuBitacora_Click_1(object sender, EventArgs e)
        {
            AbrirBitacora(sender, e);
        }

        private void mnuGestionPerfiles_Click(object sender, EventArgs e)
        {
            AbrirGestionRoles(sender, e);
        }

        private void mnuGestionFamilias_Click(object sender, EventArgs e)
        {
            AbrirGestionFamilias(sender, e);
        }

        private void mnuGestionRespaldo_Click(object sender, EventArgs e)
        {
            AbrirGestionRespaldo(sender, e);
        }

        private void mnuMaestroProductos_Click(object sender, EventArgs e)
        {
            AbrirMaestroProductos(sender, e);
        }

        private void mnuMaestroClientes_Click(object sender, EventArgs e)
        {
            AbrirMaestroClientes(sender, e);
        }

        private void mnuFacturar_Click_1(object sender, EventArgs e)
        {
            AbrirFacturar(sender, e);
        }

        private void mnuCambiarIdioma_Click(object sender, EventArgs e)
        {
            AbrirCambiarIdioma(sender, e);
        }

        private void mnuCambiarContrasena_Click_1(object sender, EventArgs e)
        {
            AbrirCambiarContraseña(sender, e);
        }

        private void mnuCerrarSesion_Click_1(object sender, EventArgs e)
        {
            CerrarSesion(sender, e);
        }

        private void mnuIniciarSesion_Click_1(object sender, EventArgs e)
        {
            ReLogin(sender, e);

        }

        private void lblRoll_Click(object sender, EventArgs e)
        {

        }
    }
}



