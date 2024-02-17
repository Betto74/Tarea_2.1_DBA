using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Datos
{
    public class Conexion
    {

        public static MySqlConnection conexion;
        public static bool Conectar()
        {


            try
            {
                if (conexion != null && conexion.State == System.Data.ConnectionState.Open) return true;

                conexion = new MySqlConnection();
                conexion.ConnectionString = "server=manolo.mysql.database.azure.com;uid=ADMIN;pwd=qwert1234@;database=MAFIA_BILLS";
                conexion.Open();

                return true;
            }
            catch (MySqlException ex)
            {

                return false;
            }
            catch (Exception ex)
            {

                return false;
            }

        }

        public static void Desconectar()
        {
            if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();

        }
    }
}
