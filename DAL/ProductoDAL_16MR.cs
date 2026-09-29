using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class ProductoDAL_16MR
    {
        private string connectionString = @"Data Source=.;Initial Catalog=proyecto_ingenieria;Integrated Security=True";

        // Solo productos activos. El filtro busca por nombre (vacío = todos).
        public List<Producto_16MR> ObtenerProductosActivos(string filtro)
        {
            var lista = new List<Producto_16MR>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Producto WHERE Activo = 1 AND Nombre LIKE @filtro";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            lista.Add(Mapear(reader));
                    }
                }
            }
            return lista;
        }

        public Producto_16MR ObtenerPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Producto WHERE Id = @id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        return reader.Read() ? Mapear(reader) : null;
                    }
                }
            }
        }

        public bool DescontarExistencia(int idProducto, int cantidad)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE Producto SET Existencia = Existencia - @cantidad " +
                               "WHERE Id = @id AND Existencia >= @cantidad";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@id", idProducto);
                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        private Producto_16MR Mapear(SqlDataReader reader)
        {
            return new Producto_16MR
            {
                Id = Convert.ToInt32(reader["Id"]),
                Codigo = reader["Codigo"].ToString(),
                Nombre = reader["Nombre"].ToString(),
                Tipo = reader["Tipo"].ToString(),
                Marca = reader["Marca"].ToString(),
                Modelo = reader["Modelo"].ToString(),
                Color = reader["Color"].ToString(),
                Precio = Convert.ToDecimal(reader["Precio"]),
                Existencia = Convert.ToInt32(reader["Existencia"]),
                Activo = Convert.ToBoolean(reader["Activo"])
            };
        }
    }
}
