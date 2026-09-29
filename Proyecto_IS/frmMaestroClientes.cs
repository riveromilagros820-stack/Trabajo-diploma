using BE;
using BLL;
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
    public partial class frmMaestroClientes : Form
    {
        public frmMaestroClientes()
        {
            InitializeComponent();
            ConstruirFormulario();
            CargarGrilla();
        }

        // Lo que se ve en la grilla es lo que se serializa (tal cual pide la spec:
        // "la información que se va a Serializar es la que se encuentra
        // visualizada en la matriz de datos de la pantalla").
        private List<Cliente_16MR> clientes = new List<Cliente_16MR>();
        private Cliente_16MR clienteSeleccionado;
        private bool modoNuevo;

        private DataGridView dgvClientes;
        private Button btnActualizar, btnAnadir, btnModificar, btnEliminar;

        private TextBox txtDni, txtApellidos, txtNombres, txtEmail, txtCelular, txtDireccion;
        private TextBox txtMensaje;
        private Button btnAplicar, btnCancelar, btnSalir;

        private TextBox txtRutaSerializar, txtRutaDesSerializar;
        private Button btnBuscarSerializar, btnSerializar;
        private Button btnBuscarDesSerializar, btnDesSerializar;
        private Button btnLimpiar;

        private void ConstruirFormulario()
        {
            this.Text = "Maestro de Clientes";
            this.ClientSize = new Size(900, 640);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 9.5f);

            var lblTitulo = new Label
            {
                Text = "Maestro de Clientes",
                Left = 20,
                Top = 15,
                Width = 400,
                Font = new Font("Segoe UI", 14f, FontStyle.Bold)
            };
            this.Controls.Add(lblTitulo);

            // ---------- Grilla + botones ABM (arriba) ----------
            dgvClientes = new DataGridView
            {
                Left = 20,
                Top = 55,
                Width = 660,
                Height = 160,
                ReadOnly = true,
                AllowUserToAddRows = false,
                MultiSelect = false,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoGenerateColumns = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DNI", HeaderText = "DNI" });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Apellido", HeaderText = "Apellidos" });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = "Nombres" });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email" });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Telefono", HeaderText = "Celular" });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Direccion", HeaderText = "Dirección" });
            this.Controls.Add(dgvClientes);

            btnActualizar = CrearBotonAbm("Actualizar", 55);
            btnAnadir = CrearBotonAbm("Añadir", 95);
            btnModificar = CrearBotonAbm("Modificar", 135);
            btnEliminar = CrearBotonAbm("Eliminar", 175);

            btnActualizar.Click += (s, e) => CargarGrilla();
            btnAnadir.Click += BtnAnadir_Click;
            btnModificar.Click += BtnModificar_Click;
            btnEliminar.Click += BtnEliminar_Click;

            // ---------- Panel de edición ----------
            int y = 235;
            txtDni = AgregarCampo("DNI:", ref y);
            txtApellidos = AgregarCampo("Apellidos:", ref y);
            txtNombres = AgregarCampo("Nombres:", ref y);
            txtEmail = AgregarCampo("Email:", ref y);
            txtCelular = AgregarCampo("Celular:", ref y);
            txtDireccion = AgregarCampo("Dirección:", ref y);
                

            var lblMensaje = new Label { Text = "Mensaje:", Left = 380, Top = 235, Width = 100 };
            this.Controls.Add(lblMensaje);
            txtMensaje = new TextBox
            {
                Left = 380,
                Top = 258,
                Width = 300,
                Height = 130,
                Multiline = true,
                ReadOnly = true,
                BackColor = Color.WhiteSmoke
            };
            this.Controls.Add(txtMensaje);

            btnAplicar = new Button { Text = "Aplicar", Left = 700, Top = 235, Width = 170, Height = 30 };
            btnCancelar = new Button { Text = "Cancelar", Left = 700, Top = 271, Width = 170, Height = 30 };
            btnSalir = new Button { Text = "Salir", Left = 700, Top = 307, Width = 170, Height = 30 };
            btnAplicar.Click += BtnAplicar_Click;
            btnCancelar.Click += (s, e) => { HabilitarEdicion(false); LimpiarCampos(); };
            btnSalir.Click += (s, e) => this.Close();
            this.Controls.Add(btnAplicar);
            this.Controls.Add(btnCancelar);
            this.Controls.Add(btnSalir);
            HabilitarEdicion(false);

            // ---------- Serializar / Des-serializar ----------
            var lblSep = new Label
            {
                Text = "Serialización",
                Left = 20,
                Top = 420,
                Width = 300,
                Font = new Font("Segoe UI", 11f, FontStyle.Bold)
            };
            this.Controls.Add(lblSep);

            txtRutaSerializar = new TextBox { Left = 20, Top = 455, Width = 400 };
            this.Controls.Add(txtRutaSerializar);
            btnBuscarSerializar = new Button { Text = "📁", Left = 425, Top = 453, Width = 35, Height = 26 };
            btnBuscarSerializar.Click += BtnBuscarSerializar_Click;
            this.Controls.Add(btnBuscarSerializar);
            btnSerializar = new Button
            {
                Text = "SERIALIZAR",
                Left = 470,
                Top = 453,
                Width = 130,
                Height = 28,
                BackColor = Color.Orange
            };
            btnSerializar.Click += BtnSerializar_Click;
            this.Controls.Add(btnSerializar);

            txtRutaDesSerializar = new TextBox { Left = 20, Top = 495, Width = 400 };
            this.Controls.Add(txtRutaDesSerializar);
            btnBuscarDesSerializar = new Button { Text = "📁", Left = 425, Top = 493, Width = 35, Height = 26 };
            btnBuscarDesSerializar.Click += BtnBuscarDesSerializar_Click;
            this.Controls.Add(btnBuscarDesSerializar);
            btnDesSerializar = new Button
            {
                Text = "DES-SERIALIZAR",
                Left = 470,
                Top = 493,
                Width = 130,
                Height = 28,
                BackColor = Color.Orange
            };
            btnDesSerializar.Click += BtnDesSerializar_Click;
            this.Controls.Add(btnDesSerializar);

            btnLimpiar = new Button { Text = "LIMPIAR", Left = 620, Top = 453, Width = 100, Height = 68 };
            btnLimpiar.Click += (s, e) => { clientes.Clear(); RefrescarGrillaDesdeLista(); Informar("Grilla vaciada."); };
            this.Controls.Add(btnLimpiar);
        }

        private Button CrearBotonAbm(string texto, int top)
        {
            var btn = new Button { Text = texto, Left = 700, Top = top, Width = 170, Height = 32 };
            this.Controls.Add(btn);
            return btn;
        }

        private TextBox AgregarCampo(string etiqueta, ref int y)
        {
            var lbl = new Label { Text = etiqueta, Left = 20, Top = y, Width = 100 };
            this.Controls.Add(lbl);

            var txt = new TextBox { Left = 130, Top = y - 3, Width = 230 };
            this.Controls.Add(txt);

            y += 30;
            return txt;
        }

        private void HabilitarEdicion(bool habilitar)
        {
            txtDni.ReadOnly = !habilitar || !modoNuevo; // el DNI no se edita al modificar
            txtApellidos.Enabled = habilitar;
            txtNombres.Enabled = habilitar;
            txtEmail.Enabled = habilitar;
            txtCelular.Enabled = habilitar;
            txtDireccion.Enabled = habilitar;
            btnAplicar.Enabled = habilitar; 
        }

        private void LimpiarCampos()
        {
            txtDni.Text = txtApellidos.Text = txtNombres.Text = txtEmail.Text = txtCelular.Text = txtDireccion.Text = "";
            clienteSeleccionado = null;
        }

        private void Informar(string mensaje) => txtMensaje.Text = mensaje;

        // ---------------- ABM ----------------

        private void CargarGrilla()
        {
            clientes = new ClienteBLL_16MR().ObtenerTodos();
            RefrescarGrillaDesdeLista();
        }

        private void RefrescarGrillaDesdeLista()
        {
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = clientes;
        }

        private void BtnAnadir_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            modoNuevo = true;
            HabilitarEdicion(true);
            Informar("Completá los datos del nuevo cliente y presioná Aplicar.");
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                Informar("Seleccioná un cliente de la grilla.");
                return;
            }

            clienteSeleccionado = (Cliente_16MR)dgvClientes.CurrentRow.DataBoundItem;
            txtDni.Text = clienteSeleccionado.DNI;
            txtApellidos.Text = clienteSeleccionado.Apellido;
            txtNombres.Text = clienteSeleccionado.Nombre;
            txtEmail.Text = clienteSeleccionado.Email;
            txtCelular.Text = clienteSeleccionado.Telefono;
            txtDireccion.Text = clienteSeleccionado.Direccion;

            modoNuevo = false;
            HabilitarEdicion(true);
            Informar("Modificá los datos y presioná Aplicar.");
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                Informar("Seleccioná un cliente de la grilla.");
                return;
            }

            var cliente = (Cliente_16MR)dgvClientes.CurrentRow.DataBoundItem;
            var confirmar = MessageBox.Show($"¿Eliminar al cliente {cliente.Apellido}, {cliente.Nombre}?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmar != DialogResult.Yes) return;

            new ClienteBLL_16MR().Desactivar(cliente.Id, cliente.DNI);
            Informar("Cliente eliminado.");
            CargarGrilla();
        }

        private void BtnAplicar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDni.Text) ||
                string.IsNullOrWhiteSpace(txtApellidos.Text) ||
                string.IsNullOrWhiteSpace(txtNombres.Text))
            {
                Informar("DNI, Apellidos y Nombres son obligatorios.");
                return;
            }

            var clienteBLL = new ClienteBLL_16MR();

            if (modoNuevo)
            {
                if (clienteBLL.ObtenerPorDNI(txtDni.Text) != null)
                {
                    Informar("Ya existe un cliente con ese DNI.");
                    return;
                }

                clienteBLL.Guardar(new Cliente_16MR
                {
                    DNI = txtDni.Text,
                    Apellido = txtApellidos.Text,
                    Nombre = txtNombres.Text,
                    Email = txtEmail.Text,
                    Telefono = txtCelular.Text,
                    Direccion = txtDireccion.Text
                });
                Informar("Cliente creado correctamente.");
            }
            else
            {
                clienteSeleccionado.Apellido = txtApellidos.Text;
                clienteSeleccionado.Nombre = txtNombres.Text;
                clienteSeleccionado.Email = txtEmail.Text;
                clienteSeleccionado.Telefono = txtCelular.Text;
                clienteSeleccionado.Direccion = txtDireccion.Text;

                clienteBLL.Actualizar(clienteSeleccionado);
                Informar("Cliente modificado correctamente.");
            }

            HabilitarEdicion(false);
            LimpiarCampos();
            CargarGrilla();
        }

        // ---------------- Serialización ----------------

        private void BtnBuscarSerializar_Click(object sender, EventArgs e)
        {
            using (var dlg = new SaveFileDialog { Filter = "Archivo XML (*.xml)|*.xml", FileName = "Clientes.xml" })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                    txtRutaSerializar.Text = dlg.FileName;
            }
        }

        private void BtnSerializar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRutaSerializar.Text))
            {
                Informar("Seleccioná primero la ubicación donde guardar el archivo.");
                return;
            }

            try
            {
                new SerializarClienteBLL_16MR().Serializar(clientes, txtRutaSerializar.Text);
                Informar("Clientes serializados correctamente en:\r\n" + txtRutaSerializar.Text);
            }
            catch (Exception ex)
            {
                Informar("Error al serializar: " + ex.Message);
            }
        }

        private void BtnBuscarDesSerializar_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog { Filter = "Archivo XML (*.xml)|*.xml" })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                    txtRutaDesSerializar.Text = dlg.FileName;
            }
        }

        private void BtnDesSerializar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRutaDesSerializar.Text))
            {
                Informar("Seleccioná primero el archivo XML a des-serializar.");
                return;
            }

            try
            {
                clientes = new DesSerializarClienteBLL_16MR().DesSerializar(txtRutaDesSerializar.Text);
                RefrescarGrillaDesdeLista();
                Informar("Clientes des-serializados correctamente: " + clientes.Count + " registros.");
            }
            catch (Exception ex)
            {
                Informar("Error al des-serializar: " + ex.Message);
            }
        }
    }
}

