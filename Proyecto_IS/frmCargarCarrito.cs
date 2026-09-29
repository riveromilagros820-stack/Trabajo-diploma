using BE;
using BLL;
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
    public partial class frmCargarCarrito : Form
    {
        public frmCargarCarrito()
        {
            InitializeComponent();
        }

        private void frmCargarCarrito_Load(object sender, EventArgs e)
        {
            ConstruirFormulario();
        }

        private Cliente_16MR clienteActual;
        private List<LineaCarrito_16MR> lineas = new List<LineaCarrito_16MR>();

        private Label lblDni;
        private TextBox txtDni;
        private Button btnBuscarCliente;
        private Label lblCliente;
        private Button btnRegistrarCliente;
        private DataGridView dgvCarrito;
        private Button btnAgregarProducto;
        private Label lblSubtotal;
        private Button btnFinalizarCarga;
        private Button btnCancelar;

       

        private void ConstruirFormulario()
        {
            this.Text = "Cargar Carrito";
            this.Size = new Size(610, 560);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 9.5f);

            var lblTitulo = new Label
            {
                Text = "Cargar Carrito",
                Left = 20,
                Top = 15,
                Width = 300,
                Font = new Font("Segoe UI", 14f, FontStyle.Bold)
            };
            this.Controls.Add(lblTitulo);

            lblDni = new Label { Text = "DNI/CUIT Cliente:", Left = 20, Top = 60, Width = 120 };
            this.Controls.Add(lblDni);

            txtDni = new TextBox { Left = 145, Top = 57, Width = 150 };
            this.Controls.Add(txtDni);

            btnBuscarCliente = new Button { Text = "Buscar", Left = 305, Top = 55, Width = 80, Height = 28 };
            btnBuscarCliente.Click += BtnBuscarCliente_Click;
            this.Controls.Add(btnBuscarCliente);
            txtDni.TextChanged += (s, e) => LimpiarCliente();
            txtDni.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    BtnBuscarCliente_Click(s, e);
                }
            };

            btnRegistrarCliente = new Button
            {
                Text = "Registrar Cliente",
                Left = 400,
                Top = 55,
                Width = 130,
                Height = 28,
                Visible = false
            };
            btnRegistrarCliente.Click += BtnRegistrarCliente_Click;
            this.Controls.Add(btnRegistrarCliente);


            lblCliente = new Label
            {
                Left = 20,
                Top = 92,
                Width = 555,
                Height = 66,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Padding = new Padding(6, 4, 6, 4),
                Visible = false
            };
            this.Controls.Add(lblCliente);

            dgvCarrito = new DataGridView
            {
                Left = 20,
                Top = 165,
                Width = 555,
                Height = 225,
                ReadOnly = true,
                AllowUserToAddRows = false,
                MultiSelect = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            this.Controls.Add(dgvCarrito);

            btnAgregarProducto = new Button
            {
                Text = "Seleccionar Productos",
                Left = 20,
                Top = 400,
                Width = 180,
                Height = 32
            };
            btnAgregarProducto.Click += BtnAgregarProducto_Click;
            this.Controls.Add(btnAgregarProducto);

            lblSubtotal = new Label
            {
                Text = "Subtotal: $0.00",
                Left = 375,
                Top = 405,
                Width = 200,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleRight
            };
            this.Controls.Add(lblSubtotal);

            btnFinalizarCarga = new Button
            {
                Text = "Finalizar Carga",
                Left = 315,
                Top = 470,
                Width = 130,
                Height = 36,
                BackColor = Color.FromArgb(123, 97, 255),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnFinalizarCarga.Click += BtnFinalizarCarga_Click;
            this.Controls.Add(btnFinalizarCarga);

            btnCancelar = new Button { Text = "Cancelar", Left = 455, Top = 470, Width = 120, Height = 36 };
            btnCancelar.Click += (s, e) => this.Close();
            this.Controls.Add(btnCancelar);
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDni.Text))
            {
                MessageBox.Show("Ingresá un DNI/CUIT.");
                return;
            }

            var cliente = new ClienteBLL_16MR().ObtenerPorDNI(txtDni.Text.Trim());

            if (cliente != null)
            {
                MostrarCliente(cliente);
            }
            else
            {
                LimpiarCliente();
                lblCliente.ForeColor = Color.DarkRed;
                lblCliente.Text = "Cliente no registrado. Presioná \"Registrar Cliente\".";
                lblCliente.Visible = true;
                btnRegistrarCliente.Visible = true;
            }
        }

        private void MostrarCliente(Cliente_16MR c)
        {
            clienteActual = c;
            lblCliente.ForeColor = Color.DarkGreen;
            lblCliente.Text =
                c.Apellido + ", " + c.Nombre + "   |   DNI/CUIT: " + c.DNI + Environment.NewLine +
                "Dirección: " + c.Direccion + "   |   Teléfono: " + c.Telefono + Environment.NewLine +
                "Email: " + c.Email;
            lblCliente.Visible = true;
            btnRegistrarCliente.Visible = false;
        }

        private void LimpiarCliente()
        {
            clienteActual = null;
            lblCliente.Visible = false;
            btnRegistrarCliente.Visible = false;
        }

        // CUN-03 (todavia no construido)
        private void BtnRegistrarCliente_Click(object sender, EventArgs e)
        {
            using (var frm = new frmRegistrarCliente(txtDni.Text))
            {
               if (frm.ShowDialog() == DialogResult.OK)
               {
                    MostrarCliente(frm.ClienteRegistrado);

                }
            }
        }

        // CUN-02
        private void BtnAgregarProducto_Click(object sender, EventArgs e)
        {
            using (var frm = new frmSeleccionarProducto(lineas))
            {
                if (frm.ShowDialog() != DialogResult.OK) return;

                foreach (var nueva in frm.LineasSeleccionadas)
                {
                    var existente = lineas.FirstOrDefault(l => l.Producto.Id == nueva.Producto.Id);
                    if (existente != null)
                        existente.Cantidad += nueva.Cantidad;
                    else
                        lineas.Add(nueva);
                }
                ActualizarGrilla();
            }
        }

        private void ActualizarGrilla()
        {
            dgvCarrito.DataSource = null;
            dgvCarrito.DataSource = lineas.Select(l => new
            {
                Producto = l.Producto.Nombre,
                l.Cantidad,
                PrecioUnitario = l.Producto.Precio,
                Subtotal = l.Cantidad * l.Producto.Precio
            }).ToList();

            decimal total = lineas.Sum(l => l.Cantidad * l.Producto.Precio);
            lblSubtotal.Text = $"Subtotal: {total:C}";
        }

        // Pasos 8 y 13 del PN1 (asociar carrito y finalizar)
        private void BtnFinalizarCarga_Click(object sender, EventArgs e)
        {
            if (clienteActual == null)
            {
                MessageBox.Show("Buscá o registrá al cliente antes de finalizar.");
                return;
            }

            if (lineas.Count == 0)
            {
                MessageBox.Show("Agregá al menos un producto al carrito.");
                return;
            }

            var carrito = new Carrito_16MR
            {
                Cliente = clienteActual,
                Vendedor = SessionManager_65RD.Instancia.UsuarioLogueado,
                Lineas = lineas
            };
            new CarritoBLL_16MR().GuardarCarrito(carrito);
            MessageBox.Show("Carrito guardado. Indicale al cliente que se dirija a caja.");
            this.Close();
        }
    }
}

