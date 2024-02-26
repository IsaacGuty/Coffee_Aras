using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Coffee_Aras
{
    public partial class Pedidos : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Pedidos"/> class.
        /// </summary>
        public Pedidos()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public struct PedidoO
        {
            /// <summary>
            /// The number cliente
            /// </summary>
            public string Num_Cliente;
            /// <summary>
            /// The nombre
            /// </summary>
            public string Nombre;
            /// <summary>
            /// The number mesa
            /// </summary>
            public string Num_Mesa;
            /// <summary>
            /// The subtotal
            /// </summary>
            public int Subtotal;
            /// <summary>
            /// The total
            /// </summary>
            public float Total;
            /// <summary>
            /// The impuesto
            /// </summary>
            public float Impuesto;
        }

        /// <summary>
        /// The sub
        /// </summary>
        private int sub;

        /// <summary>
        /// The connection
        /// </summary>
        SqlConnection Conn = new SqlConnection("Data source = DESKTOP-KIBLMD6\\SQLEXPRESS; Initial catalog = AracelyCoffee; Integrated security = true");

        /// <summary>
        /// Handles the Click event of the btnGuardar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(txtNo_Pedido.Text == "")
            {
                MessageBox.Show("Ingrese un numero de pedido", "Advertencia");
            }
            else
            {
                if(txtNombre.Text == "")
                {
                    MessageBox.Show("Ingrese un nombre", "Advertencia");
                }
                else
                {
                    if(txtNo_Mesa.Text == "")
                    {
                        MessageBox.Show("Ingrese el número de mesa", "Advertencia");
                    }
                    else
                    {
                        Pedido Pedido = new Pedido();
                        Pedido.No_Pedido = txtNo_Pedido.Text;
                        Pedido.Nombre = txtNombre.Text;
                        Pedido.No_Mesa = txtNo_Mesa.Text;

                        int resultado = PedidoDAL.Agregar(Pedido);

                        if (resultado > 0)
                        {
                            MessageBox.Show("Datos guardados correctamente", "Datos guardados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            limpiar();
                        }
                        else
                        {
                            MessageBox.Show("No se guardaron correctamente los datos", "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
            
        }

        /// <summary>
        /// Handles the Click event of the btnBuscar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = PedidoDAL.BuscarPedido(txtBuscar.Text);
        }

        /// <summary>
        /// Handles the CellContentClick event of the dataGridView1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNo_Pedido.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtNo_Mesa.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        /// <summary>
        /// Handles the Load event of the Pedidos control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Pedidos_Load(object sender, EventArgs e)
        {
            this.pedidosTableAdapter.Fill(this.aracelyCoffeeDataSet1.Pedidos);
        }

        /// <summary>
        /// Limpiars this instance.
        /// </summary>
        void limpiar()
        {
            txtNo_Pedido.Clear();
            txtNombre.Clear();
            txtNo_Mesa.Clear();
        }

        /// <summary>
        /// Handles the Click event of the btnEliminar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Conn.Open();

            string No_Pedido = txtNo_Pedido.Text;
            string Nombre = txtNombre.Text;
            string No_Mesa = txtNo_Mesa.Text;
            string consulta = ("delete from Pedidos where No_Pedido = " +No_Pedido);
            SqlCommand comando = new SqlCommand(consulta, Conn);
            comando.ExecuteNonQuery();
            MessageBox.Show("El pedido ha sido eliminado.");

            Conn.Close();
            
        }

        /// <summary>
        /// Handles the Click event of the btnModificar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            Conn.Open();

            string No_Pedido = txtNo_Pedido.Text;
            string Nombre = txtNombre.Text;
            string No_Mesa = txtNo_Mesa.Text;
            string cadena = ("update Pedidos set Nombre = '" + Nombre + "', no_mesa = '" + No_Mesa + "' where No_Pedido = " + No_Pedido);
            SqlCommand comando = new SqlCommand(cadena, Conn);
            int resultado;
            resultado = comando.ExecuteNonQuery();
            if(resultado == 1)
            {
                MessageBox.Show("Se modificaron correctamente los datos.");
            }
            else
            {
                MessageBox.Show("No se pudo modificar.");
            }

            Conn.Close();
        }

        /// <summary>
        /// Actualizars the totales.
        /// </summary>
        void actualizar_totales()
        {
            PedidoO Pedido = new PedidoO();

            Pedido.Subtotal = sub;

            lblSubtotal.Text = Convert.ToString(Pedido.Subtotal);
            lblImpuesto.Text = Convert.ToString(Pedido.Subtotal * .15F);
            lblTotal.Text = Convert.ToString(Pedido.Subtotal + float.Parse(lblImpuesto.Text));
        }

        /// <summary>
        /// Handles the CheckedChanged event of the chkLatte control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void chkLatte_CheckedChanged(object sender, EventArgs e)
        {
            PedidoO Pedido = new PedidoO();
            if(chkLatte.Checked)
            {
                lstPedido.Items.Add(chkLatte.Text);
                sub += 52;
            }
            else
            {
                lstPedido.Items.Remove(chkLatte.Text);
                sub -= 52;
            }
            actualizar_totales();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the chkIcedLatte control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void chkIcedLatte_CheckedChanged(object sender, EventArgs e)
        {
            PedidoO Pedido = new PedidoO();
            if(chkIcedLatte.Checked)
            {
                lstPedido.Items.Add(chkIcedLatte.Text);
                sub += 67;
            }
            else
            {
                lstPedido.Items.Remove(chkIcedLatte.Text);
            }
            actualizar_totales();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the chkFrozen control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void chkFrozen_CheckedChanged(object sender, EventArgs e)
        {
            PedidoO Pedido = new PedidoO();
            if(chkFrozen.Checked)
            {
                lstPedido.Items.Add(chkFrozen.Text);
                sub += 75;
            }
            else
            {
                lstPedido.Items.Remove(chkFrozen.Text);
                sub -= 75;
            }
            actualizar_totales();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the chkIcedCoffee control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void chkIcedCoffee_CheckedChanged(object sender, EventArgs e)
        {
            PedidoO Pedido = new PedidoO();
            if(chkIcedCoffee.Checked)
            {
                lstPedido.Items.Add(chkIcedCoffee.Text);
                sub += 57;
            }
            else
            {
                lstPedido.Items.Remove(chkIcedCoffee.Text);
                sub -= 57;
            }
            actualizar_totales();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the chkIcedAras control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void chkIcedAras_CheckedChanged(object sender, EventArgs e)
        {
            PedidoO Pedido = new PedidoO();
            if(chkIcedAras.Checked)
            {
                lstPedido.Items.Add(chkIcedAras.Text);
                sub += 80;
            }
            else
            {
                lstPedido.Items.Remove(chkIcedAras.Text);
                sub -= 80;
            }
            actualizar_totales();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the chkCroissant control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void chkCroissant_CheckedChanged(object sender, EventArgs e)
        {
            PedidoO Pedido = new PedidoO();
            if(chkCroissant.Checked)
            {
                lstPedido.Items.Add(chkCroissant.Text);
                sub += 60;
            }
            else
            {
                lstPedido.Items.Remove(chkCroissant.Text);
                sub -= 60;
            }
            actualizar_totales();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the chkCheesecake control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void chkCheesecake_CheckedChanged(object sender, EventArgs e)
        {
            PedidoO Pedido = new PedidoO();
            if(chkCheesecake.Checked)
            {
                lstPedido.Items.Add(chkCheesecake.Text);
                sub += 80;
            }
            else
            {
                lstPedido.Items.Remove(chkCheesecake.Text);
                sub -= 80;
            }
            actualizar_totales();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the chkPied control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void chkPied_CheckedChanged(object sender, EventArgs e)
        {
            PedidoO Pedido = new PedidoO();
            if(chkPied.Checked)
            {
                lstPedido.Items.Add(chkPied.Text);
                sub += 95;
            }
            else
            {
                lstPedido.Items.Remove(chkPied.Text);
                sub -= 95;
            }
            actualizar_totales();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the chkBagel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void chkBagel_CheckedChanged(object sender, EventArgs e)
        {
            PedidoO Pedido = new PedidoO();
            if(chkBagel.Checked)
            {
                lstPedido.Items.Add(chkBagel.Text);
                sub += 85;
            }
            else
            {
                lstPedido.Items.Remove(chkBagel.Text);
                sub -= 85;
            }
            actualizar_totales();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the chkBrownie control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void chkBrownie_CheckedChanged(object sender, EventArgs e)
        {
            PedidoO Pedido = new PedidoO();
            if(chkBrownie.Checked)
            {
                lstPedido.Items.Add(chkBrownie.Text);
                sub += 22;
            }
            else
            {
                lstPedido.Items.Remove(chkBrownie.Text);
                sub -= 22;
            }
            actualizar_totales();
        }

        /// <summary>
        /// Handles the Click event of the btnSalir control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Reporte Rep = new Reporte();
            Rep.Show();
        }

        /// <summary>
        /// Handles the Click event of the btnImprimir control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if((chkLatte.Checked || chkIcedLatte.Checked || chkFrozen.Checked || chkIcedCoffee.Checked || chkIcedAras.Checked) == false)
            {
                MessageBox.Show("Seleccione una bebida como mínimo", "Advertencia");
            }
            else
            {
                if((chkCroissant.Checked || chkCheesecake.Checked || chkPied.Checked ||chkBagel.Checked || chkBrownie.Checked) == false)
                {
                    MessageBox.Show("Seleccione una opción de repostería como mínimo", "Advertencia");
                }
                else
                {
                    Factura Fac = new Factura(txtNo_Pedido.Text, txtNombre.Text,
                txtNo_Mesa.Text, int.Parse(lblSubtotal.Text),
                float.Parse(lblTotal.Text), float.Parse(lblImpuesto.Text));

                    Factura Factura = new Factura();
                    Factura.Imprimir();
                }
            }
            
        }

        /// <summary>
        /// Handles the Click event of the btnLimpiar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNo_Pedido.Clear();
            txtNombre.Clear();
            txtNo_Mesa.Clear();
            txtBuscar.Clear();
        }

        /// <summary>
        /// Handles the 1 event of the Pedidos_Load control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Pedidos_Load_1(object sender, EventArgs e)
        {

        }

        
    }
}
