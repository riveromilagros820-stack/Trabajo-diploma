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
            ConfigurarColumnasGrilla();
            HabilitarEdicion(false);
            CargarGrilla();

        }

        private List<Cliente_16MR> clientes = new List<Cliente_16MR>();
        private Cliente_16MR clienteSeleccionado;
        private bool modoNuevo;


        private void frmMaestroClientes_Load(object sender, EventArgs e)
        {

        }
        private void ConfigurarColumnasGrilla()
        {
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DNI", HeaderText = "DNI" });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Apellido", HeaderText = "Apellidos" });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = "Nombres" });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email" });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Telefono", HeaderText = "Celular" });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Direccion", HeaderText = "Dirección" });
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


        //// ---------------- ABM ----------------

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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
           CargarGrilla();
        }

        private void btnAnadir_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            modoNuevo = true;
            HabilitarEdicion(true);
            Informar("Completá los datos del nuevo cliente y presioná Aplicar.");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (clienteSeleccionado == null)
            {
                Informar("Seleccioná un cliente de la grilla.");
                return;
            }

            modoNuevo = false;
            HabilitarEdicion(true);
            Informar("Modificá los datos y presioná Aplicar.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
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

        private void btnAplicar_Click(object sender, EventArgs e)
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            HabilitarEdicion(false);
            LimpiarCampos();
        }

        private void btnSerializar_Click(object sender, EventArgs e)
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

        private void btnBuscarSerializar_Click(object sender, EventArgs e)
        {
            using (var dlg = new SaveFileDialog { Filter = "Archivo XML (*.xml)|*.xml", FileName = "Clientes.xml" })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                    txtRutaSerializar.Text = dlg.FileName;
            }
        }

        private void btnBuscarDesSerializar_Click_1(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog { Filter = "Archivo XML (*.xml)|*.xml" })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                    txtRutaDesSerializar.Text = dlg.FileName;
            }
        }

        private void btnDesSerializar_Click(object sender, EventArgs e)
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            clientes.Clear();
            RefrescarGrillaDesdeLista();
            LimpiarCampos();
            HabilitarEdicion(false);
            Informar("Grilla vaciada.");
        }

        private void DgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvClientes.CurrentRow?.DataBoundItem is Cliente_16MR c)
                    MostrarDatosCliente(c);
            }
            catch (IndexOutOfRangeException)
            {
                
            }
        }
        private void MostrarDatosCliente(Cliente_16MR c)
        {
            clienteSeleccionado = c;
            txtDni.Text = c.DNI;
            txtApellidos.Text = c.Apellido;
            txtNombres.Text = c.Nombre;
            txtEmail.Text = c.Email;
            txtCelular.Text = c.Telefono;
            txtDireccion.Text = c.Direccion;
        }
    }
}

