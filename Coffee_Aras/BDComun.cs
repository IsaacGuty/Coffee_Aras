using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Coffee_Aras
{
    public class BDComun
    {
        /// <summary>Obteners the conexion.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection Conn = new SqlConnection("Data source = DESKTOP-KIBLMD6\\SQLEXPRESS; Initial catalog = AracelyCoffee; Integrated security = true");
            Conn.Open();

            return Conn;
        }
    }
}
