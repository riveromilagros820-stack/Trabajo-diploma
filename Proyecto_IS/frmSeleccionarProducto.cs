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
    public partial class frmSeleccionarProducto : Form
    {
        public List<LineaCarrito_16MR> LineasSeleccionadas { get; } = new List<LineaCarrito_16MR>();

        // Fila de la grilla: el producto + cuánto queda realmente disponible.
        private class ItemCatalogo
        {
            public Producto_16MR Producto { get; set; }
            public string Codigo => Producto.Codigo;
            public string Nombre => Producto.Nombre;
            public string Marca => Producto.Marca;
            public decimal Precio => Producto.Precio;
            public int Disponible { get; set; }
        }

        private readonly List<LineaCarrito_16MR> _lineasEnCarrito;
        private List<Producto_16MR> _catalogo = new List<Producto_16MR>();

        public frmSeleccionarProducto(List<LineaCarrito_16MR> lineasEnCarrito)
        {
            _lineasEnCarrito = lineasEnCarrito ?? new List<LineaCarrito_16MR>();
            InitializeComponent();
            ConfigurarColumnasGrilla();
            _catalogo = new ProductoBLL_16MR().BuscarProductos("");
            Refrescar();
        }

        private void ConfigurarColumnasGrilla()
        {
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Codigo", HeaderText = "Código", FillWeight = 20 });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = "Nombre", FillWeight = 45 });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Marca", HeaderText = "Marca", FillWeight = 20 });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Precio",
                HeaderText = "Precio",
                FillWeight = 22,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Disponible", HeaderText = "Disponible", FillWeight = 18 });
        }

        private void TxtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Buscar();
            }
        }

        private void Buscar()
        {
            _catalogo = new ProductoBLL_16MR().BuscarProductos(txtBuscar.Text);
            Refrescar();
        }
        private void DgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            MostrarDetalle(ItemSeleccionado());
        }

        private void DgvProductos_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                MostrarDetalle(dgvProductos.Rows[e.RowIndex].DataBoundItem as ItemCatalogo);
        }

        private void DgvProductos_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            MostrarDetalle(ItemSeleccionado());
        }
        // Lo que ya está reservado de un producto: en el carrito + en esta selección.
        private int Reservado(int idProducto)
        {
            return _lineasEnCarrito.Where(l => l.Producto.Id == idProducto).Sum(l => l.Cantidad)
                 + LineasSeleccionadas.Where(l => l.Producto.Id == idProducto).Sum(l => l.Cantidad);
        }

        // Arma la grilla: solo aparecen los productos con al menos 1 unidad disponible.
        private void Refrescar()
        {
            int? idSeleccionado = ItemSeleccionado()?.Producto.Id;

            var items = _catalogo
                .Select(p => new ItemCatalogo { Producto = p, Disponible = p.Existencia - Reservado(p.Id) })
                .Where(i => i.Disponible >= 1)
                .ToList();

            dgvProductos.DataSource = items;

            // Tras agregar, dejar seleccionado el mismo producto (si sigue disponible)
            if (idSeleccionado.HasValue)
            {
                foreach (DataGridViewRow fila in dgvProductos.Rows)
                {
                    if (((ItemCatalogo)fila.DataBoundItem).Producto.Id == idSeleccionado.Value)
                    {
                        dgvProductos.CurrentCell = fila.Cells[0];
                        break;
                    }
                }
            }

            MostrarDetalle(ItemSeleccionado());
        }

        private ItemCatalogo ItemSeleccionado()
        {
            return dgvProductos.CurrentRow?.DataBoundItem as ItemCatalogo;
        }

        private void MostrarDetalle(ItemCatalogo item)
        {
            if (item == null)
            {
                lblCantidad.Text = "Pasá el mouse sobre un producto" + Environment.NewLine + "para ver sus características.";
                return;
            }

            var p = item.Producto;
            lblDetalle.Text = string.Join(Environment.NewLine + Environment.NewLine, new[]
            {
                "Código: " + p.Codigo,
                "Nombre: " + p.Nombre,
                "Tipo: " + p.Tipo,
                "Marca: " + p.Marca,
                "Modelo: " + p.Modelo,
                "Color: " + p.Color,
                "Precio: " + p.Precio.ToString("C2"),
                "Disponible: " + item.Disponible
            });
        }


        private void frmSeleccionarProducto_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var item = ItemSeleccionado();
            if (item == null)
            {
                MessageBox.Show("Seleccioná un producto de la grilla.");
                return;
            }

            int cantidad = (int)nudCantidad.Value;
            var productoBLL = new ProductoBLL_16MR();

            // Escenario alternativo 7.1: se valida contra el stock actual de la base,
            // contando lo que ya está en el carrito y en esta selección.
            if (!productoBLL.ValidarStock(item.Producto.Id, Reservado(item.Producto.Id) + cantidad))
            {
                MessageBox.Show("No hay stock suficiente para esa cantidad. Ingresá un valor válido.");
                _catalogo = productoBLL.BuscarProductos(txtBuscar.Text); // refresca el stock mostrado
                Refrescar();
                return;
            }

            var existente = LineasSeleccionadas.FirstOrDefault(l => l.Producto.Id == item.Producto.Id);
            if (existente != null)
                existente.Cantidad += cantidad;
            else
                LineasSeleccionadas.Add(new LineaCarrito_16MR { Producto = item.Producto, Cantidad = cantidad });

            lstAgregados.Items.Clear();
            foreach (var l in LineasSeleccionadas)
                lstAgregados.Items.Add(l.Cantidad + " x " + l.Producto.Nombre);

            nudCantidad.Value = 1;
            Refrescar();
        }

        private void btnListo_Click(object sender, EventArgs e)
        {
            this.DialogResult = LineasSeleccionadas.Count > 0 ? DialogResult.OK : DialogResult.Cancel;
            this.Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void grpDetalle_Enter(object sender, EventArgs e)
        {
                
        }
    }
}



