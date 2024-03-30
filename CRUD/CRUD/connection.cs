using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    class connection
    {
        public static MySqlConnection conexion()
        {
            string server = "localhost";
            string db = "prueba";
            string user = "root";
            string password = "";

            string cadenaConexion = "Database=" + db + "; Data Source=" + server + "; user Id=" + user + "; Password=" + password + ";";

            try
            {
                MySqlConnection connectionDB = new MySqlConnection(cadenaConexion);
                return connectionDB;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("error: " + ex.Message);
                return null;
            }
        }
    }
}
