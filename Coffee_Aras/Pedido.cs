using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_Aras
{
    public class Pedido
    {
        /// <summary>
        /// Gets or sets the no pedido.
        /// </summary>
        /// <value>
        /// The no pedido.
        /// </value>
        public string No_Pedido { get; set; }
        /// <summary>
        /// Gets or sets the nombre.
        /// </summary>
        /// <value>
        /// The nombre.
        /// </value>
        public string Nombre { get; set; }
        /// <summary>
        /// Gets or sets the no mesa.
        /// </summary>
        /// <value>
        /// The no mesa.
        /// </value>
        public string No_Mesa { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pedido"/> class.
        /// </summary>
        public Pedido () { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pedido"/> class.
        /// </summary>
        /// <param name="pNo_Pedido">The p no pedido.</param>
        /// <param name="pNombre">The p nombre.</param>
        /// <param name="pNo_Mesa">The p no mesa.</param>
        public Pedido(string pNo_Pedido, string pNombre, string pNo_Mesa)
        {
            this.No_Pedido = pNo_Pedido;
            this.Nombre = pNo_Pedido;
            this.No_Mesa = pNo_Mesa;
        }
    }
}
