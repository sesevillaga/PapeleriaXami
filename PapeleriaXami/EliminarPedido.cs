using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PapeleriaXami
{
    public partial class EliminarPedido : Form
    {
        
        public EliminarPedido()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            conexion.Open();
            MySqlCommand sql = new MySqlCommand("select * from pedido where IdPedido=@IdPedido", conexion);
            sql.Parameters.AddWithValue("IdPedido", textBox1.Text);
            MySqlDataReader lector = sql.ExecuteReader();

            if (lector.Read())
            {
                char salto = (char)13;
                DialogResult respuesta = MessageBox.Show("Estas seguro de eliminar el pedido " + salto + "Id de Pedido " + lector["IdPedido"].ToString() + salto + "Codigo de Barras " + lector["CodigoDeBarras"].ToString() + salto + "Id de Empleado" + lector["IdEmpleado"].ToString() + salto + "Pedido Realizado " + lector["PedidoRealizado"].ToString() + salto + "Costo de Pedido" + lector["CostoDePedido"].ToString(), "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                lector.Close();

                if (respuesta == DialogResult.Yes)
                {
                    MySqlCommand sql2 = new MySqlCommand("delete from pedido where IdPedido=@IdPedido", conexion);
                    sql2.Parameters.AddWithValue("IdPedido", textBox1.Text);

                    int r = sql2.ExecuteNonQuery();

                    if (r > 0)
                    {
                        label2.Text = "";
                        textBox1.Clear();
                        textBox1.Focus();
                        MessageBox.Show("El pedido a sido eliminado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("El pedido no se elimino", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox1.Focus();
                    }
                        

                }
            }
            else
            {
                lector.Close();
                MessageBox.Show("No se ha encontrado el pedido", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }





            conexion.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public bool checarCambios()
        {
            if (textBox1.Text != "")
            {
                return true;

            }
            return false;
        }
        private void EliminarPedido_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
                     if (textBox1.Text.Length > 0 && e.KeyChar == (char)13)
                button1.Focus();
            else if (!(e.KeyChar >= 'a' && e.KeyChar <= 'z') && !(e.KeyChar >= 'A' && e.KeyChar <= 'Z') && !(e.KeyChar >= '0' && e.KeyChar <= '9') && e.KeyChar != (char)8)
            {
                e.KeyChar = (char)0;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarCambios();
        }
    }
}
