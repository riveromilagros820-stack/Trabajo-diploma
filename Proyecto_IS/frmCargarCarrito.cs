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
         }

        private Cliente_16MR clienteActual;
        private List<LineaCarrito_16MR> lineas = new List<LineaCarrito_16MR>();

        private void btnBuscarCliente_Click(object sender, EventArgs e)
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

        private void btnRegistrarCliente_Click(object sender, EventArgs e)
        {
            using (var frm = new frmRegistrarCliente(txtDni.Text))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    MostrarCliente(frm.ClienteRegistrado);

                }
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
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

        private void btnFinalizarCarga_Click(object sender, EventArgs e)
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

