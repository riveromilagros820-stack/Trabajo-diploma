using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class ClienteDAL_16MR
    {
        private string connectionString = @"Data Source=.;Initial Catalog=proyecto_ingenieria;Integrated Security=True";

        public Cliente_16MR ObtenerPorDNI(string dni)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Cliente WHERE DNI = @dni";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@dni", dni);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        return reader.Read() ? Mapear(reader) : null;
                    }
                }
            }
        }

        // Para la grilla del Maestro de Clientes. Solo activos.
        public List<Cliente_16MR> ObtenerTodos()
        {
            var lista = new List<Cliente_16MR>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Cliente WHERE Activo = 1 ORDER BY Apellido, Nombre";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
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

        public int Guardar(Cliente_16MR c)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Cliente (DNI, Apellido, Nombre, Direccion, Email, Telefono, Activo)
                                  VALUES (@dni, @apellido, @nombre, @direccion, @email, @telefono, 1);
                                  SELECT SCOPE_IDENTITY()";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@dni", c.DNI);
                    cmd.Parameters.AddWithValue("@apellido", c.Apellido);
                    cmd.Parameters.AddWithValue("@nombre", c.Nombre);
                    cmd.Parameters.AddWithValue("@direccion", (object)c.Direccion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@email", (object)c.Email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@telefono", (object)c.Telefono ?? DBNull.Value);
                    con.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public bool Actualizar(Cliente_16MR c)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Cliente SET Apellido = @apellido, Nombre = @nombre,
                                  Direccion = @direccion, Email = @email, Telefono = @telefono
                                  WHERE Id = @id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@apellido", c.Apellido);
                    cmd.Parameters.AddWithValue("@nombre", c.Nombre);
                    cmd.Parameters.AddWithValue("@direccion", (object)c.Direccion ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@email", (object)c.Email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@telefono", (object)c.Telefono ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@id", c.Id);
                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Baja logica: no se puede borrar de verdad, Cliente tiene Carritos/Facturas asociados por FK.
        public bool Desactivar(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE Cliente SET Activo = 0 WHERE Id = @id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        private Cliente_16MR Mapear(SqlDataReader reader)
        {
            return new Cliente_16MR
            {
                Id = Convert.ToInt32(reader["Id"]),
                DNI = reader["DNI"].ToString(),
                Apellido = reader["Apellido"].ToString(),
                Nombre = reader["Nombre"].ToString(),
                Direccion = reader["Direccion"].ToString(),
                Email = reader["Email"].ToString(),
                Telefono = reader["Telefono"].ToString(),
                Activo = Convert.ToBoolean(reader["Activo"])
            };
        }
    }
}
