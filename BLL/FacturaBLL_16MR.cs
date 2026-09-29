using Servicios_65RD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;

namespace BLL
{
    public class FacturaBLL_16MR
    {
        private FacturaDAL_16MR dal = new FacturaDAL_16MR();

        // CU4 "Generar factura": crea la factura en estado Pendiente.
        public int GuardarFacturaPendiente(Factura_16MR factura) => dal.InsertFactura(factura);

        // CU5 "Cobrar venta", camino aceptado: recien aca se descuenta stock,
        // se marca el carrito facturado y se deja registro en Bitacora/DV.
        public void ConfirmarPago(Factura_16MR factura, string medioDePago)
        {
            dal.ActualizarEstado(factura.Id, "Pagada", medioDePago);

            var productoBLL = new ProductoBLL_16MR();
            foreach (var linea in factura.Lineas)
                productoBLL.DescontarExistencia(linea.Producto.Id, linea.Cantidad);

            new CarritoBLL_16MR().MarcarFacturado(factura.CarritoId);

            int idUsuarioActual = SessionManager_65RD.Instancia.UsuarioLogueado.Id;
            new BitacoraBLL_65RD().RegistrarEvento(idUsuarioActual, "Ventas", "Pago confirmado", 1,
                $"Factura {factura.NroFactura} pagada por {medioDePago}, total {factura.Total:C}");
            new DigitoVerificadorBLL_65RD().ActualizarDVFactura();
        }

        // CU5 "Cobrar venta", camino rechazado: la factura queda como registro,
        // sin tocar stock ni el carrito (asi se puede reintentar el cobro despues).
        public void RechazarPago(int idFactura)
        {
            dal.ActualizarEstado(idFactura, "Rechazada", null);

            int idUsuarioActual = SessionManager_65RD.Instancia.UsuarioLogueado.Id;
            new BitacoraBLL_65RD().RegistrarEvento(idUsuarioActual, "Ventas", "Pago rechazado", 2,
                $"Factura {idFactura}: el Banco rechazó el pago");
        }
    }
}


