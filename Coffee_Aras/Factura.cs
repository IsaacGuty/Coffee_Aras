using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;                       

namespace Coffee_Aras
{
    class Factura : PedidoO
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Factura"/> class.
        /// </summary>
        public Factura()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Factura"/> class.
        /// </summary>
        /// <param name="No_Pedido">The no pedido.</param>
        /// <param name="Nombre">The nombre.</param>
        /// <param name="No_Mesa">The no mesa.</param>
        public Factura(string No_Pedido, string Nombre, string No_Mesa )
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Factura"/> class.
        /// </summary>
        /// <param name="pNo_Pedido">The p no pedido.</param>
        /// <param name="pNombre">The p nombre.</param>
        /// <param name="pNo_Mesa">The p no mesa.</param>
        /// <param name="subt_">The subt.</param>
        /// <param name="total_">The total.</param>
        /// <param name="imp_">The imp.</param>
        public Factura(string pNo_Pedido, string pNombre, string pNo_Mesa, int subt_, float total_, float imp_) : base(pNo_Pedido, pNombre, pNo_Mesa, subt_, total_, imp_)
        {
        }

        /// <summary>
        /// Imprimirs this instance.
        /// </summary>
        public new void Imprimir()
        {
                MessageBox.Show("Numero de Pedido: " + No_Pedido + "\n" +
                "Nombre: " + Nombre + " \n" +
                "Numero de Mesa: " + No_Mesa + "\n" +
                "Total a pagar: " + Total + "\n", "Datos Registrados");
        }
    }
}
