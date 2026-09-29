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

        private Label lblDni;
        private TextBox txtDni;
        private Button btnBuscarCarrito;
        private Label lblCliente;
        private DataGridView dgvDetalle;
        private Label lblTotal;
        private Button btnFinalizarCarga;
        private Button btnCancelar;

        public frmRegistrarFactura()
        {
            ConstruirFormulario();
        }

        private void ConstruirFormulario()
        {
            this.Text = "Registrar Factura";
            this.Size = new Size(610, 520);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 9.5f);

            var lblTitulo = new Label
            {
                Text = "Registrar Factura",
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

            btnBuscarCarrito = new Button { Text = "Buscar Carrito", Left = 305, Top = 55, Width = 110, Height = 28 };
            btnBuscarCarrito.Click += BtnBuscarCarrito_Click;
            this.Controls.Add(btnBuscarCarrito);

            lblCliente = new Label { Text = "", Left = 20, Top = 95, Width = 500, Height = 22 };
            this.Controls.Add(lblCliente);

            dgvDetalle = new DataGridView
            {
                Left = 20,
                Top = 130,
                Width = 555,
                Height = 260,
                ReadOnly = true,
                AllowUserToAddRows = false,
                MultiSelect = false
            };
            this.Controls.Add(dgvDetalle);

            lblTotal = new Label
            {
                Text = "Total: $0.00",
                Left = 375,
                Top = 400,
                Width = 200,
                Font = new Font("Segoe UI", 11f, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleRight
            };
            this.Controls.Add(lblTotal);

            btnFinalizarCarga = new Button
            {
                Text = "Finalizar Carga",
                Left = 315,
                Top = 440,
                Width = 130,
                Height = 36,
                BackColor = Color.FromArgb(123, 97, 255),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Enabled = false
            };
            btnFinalizarCarga.Click += BtnFinalizarCarga_Click;
            this.Controls.Add(btnFinalizarCarga);

            btnCancelar = new Button { Text = "Cancelar", Left = 455, Top = 440, Width = 120, Height = 36 };
            btnCancelar.Click += (s, e) => this.Close();
            this.Controls.Add(btnCancelar);
        }

        // Paso 2 del PN1 (busqueda del carrito). Alt: no se encuentra carrito.
        private void BtnBuscarCarrito_Click(object sender, EventArgs e)
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

        // Pasos 3 a 15 del PN1 (registrar factura -> ejecuta CUN-05 -> cobra)
        // CU4 "Generar factura": arma la factura y la guarda como Pendiente,
        // y recien ahi ejecuta CU5 "Cobrar venta". CU5 es quien confirma o
        // rechaza el pago y quien persiste eso (esta pantalla ya no lo hace).
        private void BtnFinalizarCarga_Click(object sender, EventArgs e)
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
    }
}


