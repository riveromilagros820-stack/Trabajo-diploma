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

        private TextBox txtBuscar;
        private Button btnBuscar;
        private DataGridView dgvProductos;
        private GroupBox grpDetalle;
        private Label lblDetalle;
        private Label lblCantidad;
        private NumericUpDown nudCantidad;
        private Button btnAgregar;
        private ListBox lstAgregados;
        private Button btnListo;
        private Button btnCancelar;

        public frmSeleccionarProducto(List<LineaCarrito_16MR> lineasEnCarrito)
        {
            _lineasEnCarrito = lineasEnCarrito ?? new List<LineaCarrito_16MR>();
            ConstruirFormulario();
            _catalogo = new ProductoBLL_16MR().BuscarProductos("");
            Refrescar();
        }

        private void ConstruirFormulario()
        {
            this.Text = "Seleccionar Productos";
            this.ClientSize = new Size(860, 560);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ShowInTaskbar = false;
            this.Font = new Font("Segoe UI", 9.5f);

            txtBuscar = new TextBox { Left = 20, Top = 20, Width = 300 };
            txtBuscar.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; Buscar(); }
            };
            this.Controls.Add(txtBuscar);

            btnBuscar = new Button { Text = "Buscar", Left = 330, Top = 18, Width = 90, Height = 28 };
            btnBuscar.Click += (s, e) => Buscar();
            this.Controls.Add(btnBuscar);

            dgvProductos = new DataGridView
            {
                Left = 20,
                Top = 60,
                Width = 540,
                Height = 250,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                MultiSelect = false,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoGenerateColumns = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
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

            // Panel de características: al seleccionar o al pasar el mouse por una fila
            dgvProductos.SelectionChanged += (s, e) => MostrarDetalle(ItemSeleccionado());
            dgvProductos.CellMouseEnter += (s, e) =>
            {
                if (e.RowIndex >= 0)
                    MostrarDetalle(dgvProductos.Rows[e.RowIndex].DataBoundItem as ItemCatalogo);
            };
            dgvProductos.CellMouseLeave += (s, e) => MostrarDetalle(ItemSeleccionado());
            this.Controls.Add(dgvProductos);

            grpDetalle = new GroupBox { Text = "Características", Left = 580, Top = 60, Width = 260, Height = 250 };
            lblDetalle = new Label { Left = 12, Top = 25, Width = 236, Height = 215, AutoSize = false };
            grpDetalle.Controls.Add(lblDetalle);
            this.Controls.Add(grpDetalle);

            lblCantidad = new Label { Text = "Cantidad:", Left = 20, Top = 327, Width = 70 };
            this.Controls.Add(lblCantidad);

            nudCantidad = new NumericUpDown { Left = 95, Top = 324, Width = 80, Minimum = 1, Maximum = 9999, Value = 1 };
            this.Controls.Add(nudCantidad);

            btnAgregar = new Button { Text = "Agregar", Left = 190, Top = 321, Width = 100, Height = 30 };
            btnAgregar.Click += BtnAgregar_Click;
            this.Controls.Add(btnAgregar);

            var lblAgregados = new Label { Text = "Agregados en esta selección:", Left = 20, Top = 365, Width = 300 };
            this.Controls.Add(lblAgregados);

            lstAgregados = new ListBox { Left = 20, Top = 390, Width = 540, Height = 110 };
            this.Controls.Add(lstAgregados);

            btnListo = new Button
            {
                Text = "Listo",
                Left = 620,
                Top = 510,
                Width = 110,
                Height = 34,
                BackColor = Color.FromArgb(123, 97, 255),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnListo.Click += (s, e) =>
            {
                this.DialogResult = LineasSeleccionadas.Count > 0 ? DialogResult.OK : DialogResult.Cancel;
                this.Close();
            };
            this.Controls.Add(btnListo);

            btnCancelar = new Button { Text = "Cancelar", Left = 740, Top = 510, Width = 100, Height = 34 };
            btnCancelar.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            this.Controls.Add(btnCancelar);
        }

        private void Buscar()
        {
            _catalogo = new ProductoBLL_16MR().BuscarProductos(txtBuscar.Text);
            Refrescar();
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
                lblDetalle.Text = "Pasá el mouse sobre un producto" + Environment.NewLine + "para ver sus características.";
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

        private void BtnAgregar_Click(object sender, EventArgs e)
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
    
        private void frmSeleccionarProducto_Load(object sender, EventArgs e)
        {

        }
    }

}

