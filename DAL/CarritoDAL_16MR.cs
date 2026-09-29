using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class CarritoDAL_16MR
    {
        private string connectionString = @"Data Source=.;Initial Catalog=proyecto_ingenieria;Integrated Security=True";

        public int InsertCarrito(Carrito_16MR carrito)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlTransaction tran = con.BeginTransaction())
                {
                    int idCarrito;
                    string qCabecera = @"INSERT INTO Carrito (ClienteId, VendedorId, Fecha, Estado)
                                          VALUES (@clienteId, @vendedorId, GETDATE(), 'Abierto');
                                          SELECT SCOPE_IDENTITY()";
                    using (SqlCommand cmd = new SqlCommand(qCabecera, con, tran))
                    {
                        cmd.Parameters.AddWithValue("@clienteId", carrito.Cliente.Id);
                        cmd.Parameters.AddWithValue("@vendedorId", carrito.Vendedor.Id);
                        idCarrito = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    string qDetalle = @"INSERT INTO LineaCarrito (CarritoId, ProductoId, Cantidad)
                                         VALUES (@carritoId, @productoId, @cantidad)";
                    foreach (var linea in carrito.Lineas)
                    {
                        using (SqlCommand cmd = new SqlCommand(qDetalle, con, tran))
                        {
                            cmd.Parameters.AddWithValue("@carritoId", idCarrito);
                            cmd.Parameters.AddWithValue("@productoId", linea.Producto.Id);
                            cmd.Parameters.AddWithValue("@cantidad", linea.Cantidad);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    tran.Commit();
                    return idCarrito;
                }
            }
        }

        public Carrito_16MR ObtenerAbiertoPorDNI(string dni)
        {
            Carrito_16MR carrito = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string q = @"SELECT ca.Id AS CarritoId, ca.Fecha, cl.Id, cl.DNI, cl.Apellido, cl.Nombre
                             FROM Carrito ca
                             INNER JOIN Cliente cl ON cl.Id = ca.ClienteId
                             WHERE cl.DNI = @dni AND ca.Estado = 'Abierto'";
                using (SqlCommand cmd = new SqlCommand(q, con))
                {
                    cmd.Parameters.AddWithValue("@dni", dni);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            carrito = new Carrito_16MR
                            {
                                Id = Convert.ToInt32(reader["CarritoId"]),
                                Fecha = Convert.ToDateTime(reader["Fecha"]),
                                Cliente = new Cliente_16MR
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    DNI = reader["DNI"].ToString(),
                                    Apellido = reader["Apellido"].ToString(),
                                    Nombre = reader["Nombre"].ToString()
                                }
                            };
                        }
                    }
                }
            }

            if (carrito == null) return null;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string qDetalle = @"SELECT cd.Cantidad, p.Id, p.Nombre, p.Precio
                                    FROM LineaCarrito cd
                                    INNER JOIN Producto p ON p.Id = cd.ProductoId
                                    WHERE cd.CarritoId = @carritoId";
                using (SqlCommand cmd = new SqlCommand(qDetalle, con))
                {
                    cmd.Parameters.AddWithValue("@carritoId", carrito.Id);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            carrito.Lineas.Add(new LineaCarrito_16MR
                            {
                                Cantidad = Convert.ToInt32(reader["Cantidad"]),
                                Producto = new Producto_16MR
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Nombre = reader["Nombre"].ToString(),
                                    Precio = Convert.ToDecimal(reader["Precio"])
                                }
                            });
                        }
                    }
                }
            }

            return carrito;
        }

        public void MarcarFacturado(int idCarrito)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE Carrito SET Estado = 'Facturado' WHERE Id = @id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", idCarrito);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
