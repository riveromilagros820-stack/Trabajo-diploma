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
        public frmCobrarVenta()
        {
            InitializeComponent();
        }

        private void frmCobrarVenta_Load(object sender, EventArgs e)
        {

        }
        private readonly Factura_16MR factura;

        private Label lblTotal;
        private RadioButton rbEfectivo;
        private RadioButton rbTarjeta;
        private Panel pnlDatosTarjeta;
        private TextBox txtBanco;
        private TextBox txtNumero;
        private TextBox txtVencimiento;
        private TextBox txtCodSeguridad;
        private CheckBox chkSimularRechazo;
        private Button btnConfirmarPago;
        private Button btnCancelar;

        public frmCobrarVenta(Factura_16MR facturaPendiente)
        {
            factura = facturaPendiente;
            ConstruirFormulario();
        }

        private void ConstruirFormulario()
        {
            this.Text = "Cobrar Venta";
            this.Size = new Size(420, 420);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ShowInTaskbar = false;
            this.Font = new Font("Segoe UI", 9.5f);

            lblTotal = new Label
            {
                Text = $"Total a pagar: {factura.Total:C}",
                Left = 20,
                Top = 20,
                Width = 350,
                Font = new Font("Segoe UI", 13f, FontStyle.Bold)
            };
            this.Controls.Add(lblTotal);

            rbEfectivo = new RadioButton { Text = "Efectivo", Left = 20, Top = 70, Width = 100, Checked = true };
            rbEfectivo.CheckedChanged += MedioDePago_CheckedChanged;
            this.Controls.Add(rbEfectivo);

            rbTarjeta = new RadioButton { Text = "Tarjeta", Left = 130, Top = 70, Width = 100 };
            this.Controls.Add(rbTarjeta);

            pnlDatosTarjeta = new Panel { Left = 20, Top = 105, Width = 350, Height = 150, Visible = false };
            this.Controls.Add(pnlDatosTarjeta);

            int y = 0;
            txtBanco = AgregarCampoTarjeta("Banco:", ref y);
            txtNumero = AgregarCampoTarjeta("Número:", ref y);
            txtVencimiento = AgregarCampoTarjeta("Vencimiento:", ref y);
            txtCodSeguridad = AgregarCampoTarjeta("Cód. Seguridad:", ref y);

            // Solo para poder mostrar el escenario alternativo sin un Banco
            // real conectado todavia. Sacar cuando haya integracion real.
            chkSimularRechazo = new CheckBox
            {
                Text = "Simular rechazo del Banco (pruebas)",
                Left = 20,
                Top = 270,
                Width = 320
            };
            this.Controls.Add(chkSimularRechazo);

            btnConfirmarPago = new Button
            {
                Text = "Confirmar Pago",
                Left = 100,
                Top = 320,
                Width = 130,
                Height = 34,
                BackColor = Color.FromArgb(123, 97, 255),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnConfirmarPago.Click += BtnConfirmarPago_Click;
            this.Controls.Add(btnConfirmarPago);

            btnCancelar = new Button { Text = "Cancelar", Left = 240, Top = 320, Width = 100, Height = 34 };
            btnCancelar.Click += BtnCancelar_Click;
            this.Controls.Add(btnCancelar);
        }

        private TextBox AgregarCampoTarjeta(string etiqueta, ref int y)
        {
            var lbl = new Label { Text = etiqueta, Left = 0, Top = y, Width = 110 };
            pnlDatosTarjeta.Controls.Add(lbl);

            var txt = new TextBox { Left = 120, Top = y - 3, Width = 200 };
            pnlDatosTarjeta.Controls.Add(txt);

            y += 35;
            return txt;
        }

        private void MedioDePago_CheckedChanged(object sender, EventArgs e)
        {
            pnlDatosTarjeta.Visible = rbTarjeta.Checked;
        }

        private void BtnConfirmarPago_Click(object sender, EventArgs e)
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

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            // El cajero decide no cobrar (no es un rechazo del Banco):
            // la factura queda Pendiente tal cual, se puede reintentar despues.
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}


