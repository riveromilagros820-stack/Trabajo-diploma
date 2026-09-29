using Servicios_65RD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Carrito_16MR
    {
        public int Id { get; set; }
        public Cliente_16MR Cliente { get; set; }
        public Usuario_65RD Vendedor { get; set; } // reusa la clase ya existente
        public DateTime Fecha { get; set; }
        public string Estado { get; set; } // Abierto / Facturado
        public List<LineaCarrito_16MR> Lineas { get; set; } = new List<LineaCarrito_16MR>();
    }
}
