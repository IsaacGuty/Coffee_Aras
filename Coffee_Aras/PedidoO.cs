using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_Aras
{
    class PedidoO
    {
        /// <summary>
        /// The no pedido
        /// </summary>
        protected static string No_Pedido;
        /// <summary>
        /// The nombre
        /// </summary>
        protected static string Nombre;
        /// <summary>
        /// The no mesa
        /// </summary>
        protected static string No_Mesa;
        /// <summary>
        /// The subtotal
        /// </summary>
        protected static int Subtotal = 0;
        /// <summary>
        /// The total
        /// </summary>
        protected static float Total = 0;
        /// <summary>
        /// The impuesto
        /// </summary>
        protected static float Impuesto = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="PedidoO"/> class.
        /// </summary>
        public PedidoO()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PedidoO"/> class.
        /// </summary>
        /// <param name="pNo_Pedido">The p no pedido.</param>
        /// <param name="pNombre">The p nombre.</param>
        /// <param name="pNo_Mesa">The p no mesa.</param>
        /// <param name="subt_">The subt.</param>
        /// <param name="total_">The total.</param>
        /// <param name="imp_">The imp.</param>
        public PedidoO (string pNo_Pedido, string pNombre,  string pNo_Mesa, int subt_, float total_, float imp_)
        {
            No_Pedido = pNo_Pedido;
            Nombre = pNombre;
            No_Mesa = pNo_Mesa;
            Subtotal = subt_;
            Total = total_;
            Impuesto = imp_;
        }

        /// <summary>
        /// Imprimirs this instance.
        /// </summary>
        public virtual void Imprimir()
        {

        }
    }
}
