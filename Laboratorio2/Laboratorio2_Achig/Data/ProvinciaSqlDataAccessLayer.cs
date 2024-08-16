using System;
using System.Collections.Generic;
using Npgsql;

namespace Laboratorio2.Data
{
    public class ProvinciaSqlDataAccessLayer
    {
        // Cadena de conexión a la base de datos PostgreSQL
        string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=1234;Database=dbproductos";

        // Método para obtener todas las provincias
        public IEnumerable<ProvinciaSql> GetAllProvincias()
        {
            List<ProvinciaSql> lst = new List<ProvinciaSql>();
            // Crear el comando con una consulta SQL directa
            string query = "SELECT * FROM Provincia";

            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    try
                    {
                        con.Open();
                        using (NpgsqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                ProvinciaSql provincia = new ProvinciaSql
                                {
                                    Id = rdr["id"] != DBNull.Value ? Convert.ToInt32(rdr["id"]) : 0,
                                    Nombre = rdr["nombre"] != DBNull.Value ? rdr["nombre"].ToString() : string.Empty,
                                    Codigo = rdr["codigo"] != DBNull.Value ? rdr["codigo"].ToString() : string.Empty
                                };

                                lst.Add(provincia);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Maneja el error aquí
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
            return lst;
        }
    }

    // Clase para representar la tabla Provincia
    public class ProvinciaSql
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
    }
}
