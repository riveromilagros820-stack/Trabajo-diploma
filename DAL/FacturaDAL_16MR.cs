using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class FacturaDAL_16MR
    {
        private string connectionString = @"Data Source=.;Initial Catalog=proyecto_ingenieria;Integrated Security=True";

        // CU4: crea la factura en estado Pendiente, con su detalle. Todavia
        // no se toca el stock ni se marca el carrito (eso es CU5, al confirmar).
        public int InsertFactura(Factura_16MR factura)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlTransaction tran = con.BeginTransaction())
                {
                    int idFactura;
                    string qCabecera = @"INSERT INTO Factura (CarritoId, CajeroId, NroFactura, Fecha, Hora, Total, MedioDePago, Estado)
                                          VALUES (@carritoId, @cajeroId, @nroFactura, @fecha, @hora, @total, NULL, 'Pendiente');
                                          SELECT SCOPE_IDENTITY()";
                    using (SqlCommand cmd = new SqlCommand(qCabecera, con, tran))
                    {
                        cmd.Parameters.AddWithValue("@carritoId", factura.CarritoId);
                        cmd.Parameters.AddWithValue("@cajeroId", factura.Cajero.Id);
                        cmd.Parameters.AddWithValue("@nroFactura", factura.NroFactura);
                        cmd.Parameters.AddWithValue("@fecha", factura.Fecha.Date);
                        cmd.Parameters.AddWithValue("@hora", factura.Hora);
                        cmd.Parameters.AddWithValue("@total", factura.Total);
                        idFactura = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    string qDetalle = @"INSERT INTO LineaFactura (FacturaId, ProductoId, Cantidad, PrecioUnitario)
                                         VALUES (@facturaId, @productoId, @cantidad, @precioUnitario)";
                    foreach (var linea in factura.Lineas)
                    {
                        using (SqlCommand cmd = new SqlCommand(qDetalle, con, tran))
                        {
                            cmd.Parameters.AddWithValue("@facturaId", idFactura);
                            cmd.Parameters.AddWithValue("@productoId", linea.Producto.Id);
                            cmd.Parameters.AddWithValue("@cantidad", linea.Cantidad);
                            cmd.Parameters.AddWithValue("@precioUnitario", linea.PrecioUnitario);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    tran.Commit();
                    return idFactura;
                }
            }
        }

        // CU5: pasa la factura a "Pagada" (con el medio de pago) o a "Rechazada".
        public void ActualizarEstado(int idFactura, string estado, string medioDePago)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE Factura SET Estado = @estado, MedioDePago = @medioDePago WHERE Id = @id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@estado", estado);
                    cmd.Parameters.AddWithValue("@medioDePago", (object)medioDePago ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@id", idFactura);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

