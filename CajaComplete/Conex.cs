using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaComplete
{
    public static class Conex
    {
        // Cadena de conexión a la base de datos
        private static readonly string connectionString = @"Server=localhost\SQLEXPRESS01;Database=VetsCaja;Trusted_Connection=True;";

        // Método para obtener una conexión
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
