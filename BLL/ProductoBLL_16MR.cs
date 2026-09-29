using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;


namespace BLL
{
    public   class ProductoBLL_16MR
    {
        private ProductoDAL_16MR dal = new ProductoDAL_16MR();

        public List<Producto_16MR> BuscarProductos(string filtro) => dal.ObtenerProductosActivos(filtro);

        // ¿Alcanza el stock actual (leído de la base) para esa cantidad total?
        public bool ValidarStock(int idProducto, int cantidadTotal)
        {
            var producto = dal.ObtenerPorId(idProducto);
            return producto != null && producto.Activo && producto.Existencia >= cantidadTotal;
        }

        public bool DescontarExistencia(int idProducto, int cantidad) =>
            dal.DescontarExistencia(idProducto, cantidad);
    }
}
