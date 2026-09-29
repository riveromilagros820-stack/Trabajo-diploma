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
    public class ClienteBLL_16MR
    {
        private ClienteDAL_16MR dal = new ClienteDAL_16MR();

        public Cliente_16MR ObtenerPorDNI(string dni) => dal.ObtenerPorDNI(dni);
        public List<Cliente_16MR> ObtenerTodos() => dal.ObtenerTodos();

        public int Guardar(Cliente_16MR cliente)
        {
            int id = dal.Guardar(cliente);

            int idUsuarioActual = SessionManager_65RD.Instancia.UsuarioLogueado.Id;
            new BitacoraBLL_65RD().RegistrarEvento(idUsuarioActual, "Ventas", "Cliente registrado", 1,
                $"Alta de cliente DNI {cliente.DNI}");

            return id;
        }

        public bool Actualizar(Cliente_16MR cliente)
        {
            bool ok = dal.Actualizar(cliente);
            if (ok)
            {
                int idUsuarioActual = SessionManager_65RD.Instancia.UsuarioLogueado.Id;
                new BitacoraBLL_65RD().RegistrarEvento(idUsuarioActual, "Ventas", "Cliente modificado", 1,
                    $"Cliente {cliente.DNI} modificado");
            }
            return ok;
        }

        public bool Desactivar(int idCliente, string dni)
        {
            bool ok = dal.Desactivar(idCliente);
            if (ok)
            {
                int idUsuarioActual = SessionManager_65RD.Instancia.UsuarioLogueado.Id;
                new BitacoraBLL_65RD().RegistrarEvento(idUsuarioActual, "Ventas", "Cliente eliminado", 2,
                    $"Cliente {dni} dado de baja");
            }
            return ok;
        }
    }
}
