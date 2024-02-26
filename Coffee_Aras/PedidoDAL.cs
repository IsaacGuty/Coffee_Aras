using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Coffee_Aras
{
    /// <summary>
    /// 
    /// </summary>
    class PedidoDAL
    {
        /// <summary>
        /// Agregars the specified p pedido.
        /// </summary>
        /// <param name="pPedido">The p pedido.</param>
        /// <returns></returns>
        public static int Agregar(Pedido pPedido)
        {
            int retorno = 0;
            using (SqlConnection Conn = BDComun.ObtenerConexion())
            {
                SqlCommand Comando = new SqlCommand(string.Format("Insert Into Pedidos (No_Pedido, Nombre, No_Mesa) values ('{0}', '{1}', '{2}')",
                    pPedido.No_Pedido, pPedido.Nombre, pPedido.No_Mesa), Conn);

                retorno = Comando.ExecuteNonQuery();
            }

            return retorno;
        }

        /// <summary>
        /// Buscars the pedido.
        /// </summary>
        /// <param name="pNo_Pedido">The p no pedido.</param>
        /// <returns></returns>
        public static List<Pedido> BuscarPedido(string pNo_Pedido)
        {
            List<Pedido> Lista = new List<Pedido>();
            using (SqlConnection Conn = BDComun.ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand(string.Format(
                    "Select No_Pedido, Nombre, No_Mesa from Pedidos where No_Pedido like '%{0}%'", pNo_Pedido), Conn);

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Pedido pPedido = new Pedido();
                    pPedido.No_Pedido = reader.GetString(0);
                    pPedido.Nombre = reader.GetString(1);
                    pPedido.No_Mesa = reader.GetString(2);

                    Lista.Add(pPedido);

                }
                Conn.Close();
                return Lista;
            }
        }
    }
}
