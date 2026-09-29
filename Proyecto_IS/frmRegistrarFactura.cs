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
    public partial class frmRegistrarFactura : Form
    {
        private Carrito_16MR carritoActual;


        public frmRegistrarFactura()
        {
            InitializeComponent();

        }


        private void frmRegistrarFactura_Load(object sender, EventArgs e)
        {
            
        }

        private void btnBuscarCarrito_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDni.Text))
            {
                MessageBox.Show("Ingresá un DNI/CUIT.");
                return;
            }

            carritoActual = new CarritoBLL_16MR().ObtenerAbiertoPorDNI(txtDni.Text);

            if (carritoActual == null)
            {
                lblCliente.ForeColor = Color.DarkRed;
                lblCliente.Text = "No se encontró ningún carrito abierto para ese DNI/CUIT.";
                dgvDetalle.DataSource = null;
                lblTotal.Text = "Total: $0.00";
                btnFinalizarCarga.Enabled = false;
                return;
            }

            lblCliente.ForeColor = Color.DarkGreen;
            lblCliente.Text = $"Cliente: {carritoActual.Cliente.Apellido}, {carritoActual.Cliente.Nombre}";

            dgvDetalle.DataSource = carritoActual.Lineas.Select(l => new
            {
                Producto = l.Producto.Nombre,
                l.Cantidad,
                PrecioUnitario = l.Producto.Precio,
                Subtotal = l.Cantidad * l.Producto.Precio
            }).ToList();

            decimal total = carritoActual.Lineas.Sum(l => l.Cantidad * l.Producto.Precio);
            lblTotal.Text = $"Total: {total:C}";
            btnFinalizarCarga.Enabled = true;
        }

        private void btnFinalizarCarga_Click(object sender, EventArgs e)
        {
            decimal total = carritoActual.Lineas.Sum(l => l.Cantidad * l.Producto.Precio);

            var factura = new Factura_16MR
            {
                CarritoId = carritoActual.Id,
                Cajero = SessionManager_65RD.Instancia.UsuarioLogueado,
                NroFactura = $"F-{DateTime.Now:yyyyMMddHHmmss}",
                Fecha = DateTime.Now.Date,
                Hora = DateTime.Now.TimeOfDay,
                Total = total,
                Lineas = carritoActual.Lineas.Select(l => new LineaFactura_16MR
                {
                    Producto = l.Producto,
                    Cantidad = l.Cantidad,
                    PrecioUnitario = l.Producto.Precio
                }).ToList()
            };

            factura.Id = new FacturaBLL_16MR().GuardarFacturaPendiente(factura);

            using (var frmCobro = new frmCobrarVenta(factura))
            {
                if (frmCobro.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show($"Venta cobrada. Factura {factura.NroFactura} generada.");
                }
                else
                {
                    MessageBox.Show($"El cobro no se completó. La factura {factura.NroFactura} quedó pendiente.");
                }
            }

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


