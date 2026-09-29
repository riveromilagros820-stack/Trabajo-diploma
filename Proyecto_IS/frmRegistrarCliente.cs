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
    public partial class frmRegistrarCliente : Form
    {
        public frmRegistrarCliente()
        {
            InitializeComponent();
        }

        private void frmRegistrarCliente_Load(object sender, EventArgs e)
        {

        }

        public Cliente_16MR ClienteRegistrado { get; private set; }

        private TextBox txtDni;
        private TextBox txtApellido;
        private TextBox txtNombre;
        private TextBox txtDireccion;
        private TextBox txtEmail;
        private TextBox txtTelefono;
        private Button btnGuardar;
        private Button btnCancelar;

        public frmRegistrarCliente(string dniPrecargado)
        {
            ConstruirFormulario();
            txtDni.Text = dniPrecargado;
            txtDni.ReadOnly = true; // ya vino de la búsqueda de frmCargarCarrito
        }

        private void ConstruirFormulario()
        {
            this.Text = "Registrar Cliente";
            this.Size = new Size(420, 340);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ShowInTaskbar = false;
            this.Font = new Font("Segoe UI", 9.5f);

            int y = 20;
            txtDni = AgregarCampo("DNI/CUIT:", ref y);
            txtApellido = AgregarCampo("Apellido:", ref y);
            txtNombre = AgregarCampo("Nombre:", ref y);
            txtDireccion = AgregarCampo("Dirección:", ref y);
            txtEmail = AgregarCampo("Email:", ref y);
            txtTelefono = AgregarCampo("Teléfono:", ref y);

            btnGuardar = new Button { Text = "Guardar", Left = 110, Top = y + 15, Width = 100, Height = 32 };
            btnGuardar.Click += BtnGuardar_Click;
            this.Controls.Add(btnGuardar);

            btnCancelar = new Button { Text = "Cancelar", Left = 220, Top = y + 15, Width = 100, Height = 32 };
            btnCancelar.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            this.Controls.Add(btnCancelar);
        }

        private TextBox AgregarCampo(string etiqueta, ref int y)
        {
            var lbl = new Label { Text = etiqueta, Left = 20, Top = y, Width = 100 };
            this.Controls.Add(lbl);

            var txt = new TextBox { Left = 130, Top = y - 3, Width = 250 };
            this.Controls.Add(txt);

            y += 35;
            return txt;
        }

        // Escenario alternativo 5.1 del CUN-03
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDni.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("DNI/CUIT, Apellido y Nombre son obligatorios.");
                return;
            }

            var clienteBLL = new ClienteBLL_16MR();

            if (clienteBLL.ObtenerPorDNI(txtDni.Text) != null)
            {
                MessageBox.Show("Ese DNI/CUIT ya está registrado.");
                return;
            }

            var nuevoCliente = new Cliente_16MR
            {
                DNI = txtDni.Text,
                Apellido = txtApellido.Text,
                Nombre = txtNombre.Text,
                Direccion = txtDireccion.Text,
                Email = txtEmail.Text,
                Telefono = txtTelefono.Text
            };

            int id = clienteBLL.Guardar(nuevoCliente);
            nuevoCliente.Id = id;

            ClienteRegistrado = nuevoCliente;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

