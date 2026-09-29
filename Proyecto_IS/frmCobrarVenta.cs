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
    public partial class frmCobrarVenta : Form
    {
      
        private readonly Factura_16MR factura;
        private void frmCobrarVenta_Load(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        public frmCobrarVenta(Factura_16MR facturaPendiente)
        {
            factura = facturaPendiente;
            InitializeComponent();
            lblTotal.Text = $"Total a pagar: {factura.Total:C}";
        }

      

        private void MedioDePago_CheckedChanged(object sender, EventArgs e)
        {
            pnlDatosTarjeta.Visible = rbTarjeta.Checked;
        }

        private void btnConfirmarPago_Click(object sender, EventArgs e)
        {
            if (rbTarjeta.Checked &&
                (string.IsNullOrWhiteSpace(txtBanco.Text) ||
                 string.IsNullOrWhiteSpace(txtNumero.Text) ||
                 string.IsNullOrWhiteSpace(txtVencimiento.Text) ||
                 string.IsNullOrWhiteSpace(txtCodSeguridad.Text)))
            {
                MessageBox.Show("Completá todos los datos de la tarjeta.");
                return;
            }

            string medioDePago = rbEfectivo.Checked ? "Efectivo" : "Tarjeta";

            // TODO: reemplazar por la conexion real con el sistema del Banco.
            bool pagoAceptado = rbEfectivo.Checked || !chkSimularRechazo.Checked;

            if (pagoAceptado)
            {
                new FacturaBLL_16MR().ConfirmarPago(factura, medioDePago);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                new FacturaBLL_16MR().RechazarPago(factura.Id);
                MessageBox.Show("El Banco rechazó la operación. Se cancela el cobro.");
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void pnlDatosTarjeta_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}


