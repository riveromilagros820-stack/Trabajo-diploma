using Servicios_65RD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Factura_16MR
    {
        public int Id { get; set; }
        public int CarritoId { get; set; }
        public Usuario_65RD Cajero { get; set; } // reusa la clase ya existente
        public string NroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public decimal Total { get; set; }
        public string MedioDePago { get; set; }
        public string Estado { get; set; } = "Pendiente";
        public List<LineaFactura_16MR> Lineas { get; set; } = new List<LineaFactura_16MR>();
    }
}
