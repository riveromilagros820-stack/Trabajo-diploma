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
    public class CarritoBLL_16MR
    {
        private CarritoDAL_16MR dal = new CarritoDAL_16MR();

        public Carrito_16MR ObtenerAbiertoPorDNI(string dni) => dal.ObtenerAbiertoPorDNI(dni);

        // CUN-01: DAL -> Bitacora -> Digito Verificador (mismo orden que el DSS)
        public int GuardarCarrito(Carrito_16MR carrito)
        {
            int id = dal.InsertCarrito(carrito);

            int idUsuarioActual = SessionManager_65RD.Instancia.UsuarioLogueado.Id;
            new BitacoraBLL_65RD().RegistrarEvento(idUsuarioActual, "Ventas", "Carrito cargado", 1,
                $"Carrito {id} cargado para cliente {carrito.Cliente.DNI}");
            new DigitoVerificadorBLL_65RD().ActualizarDVCarrito();

            return id;
        }

        public void MarcarFacturado(int idCarrito) => dal.MarcarFacturado(idCarrito);
    }
}



