using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Conexion
    {
        public static string GetConnectionString()
        {
            string conexion = ConfigurationManager.ConnectionStrings["SqlClient"].ConnectionString.ToString();
            return conexion;
        }
    }
}
