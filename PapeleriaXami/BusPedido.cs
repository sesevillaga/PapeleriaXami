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
    public partial class BusPedido : Form
    {
        List<String> nombrePedido;
        public BusPedido()
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

            MySqlCommand sql = new MySqlCommand("select * from pedido where IdPedido=@IdPedido",conexion);
            sql.Parameters.AddWithValue("IdPedido",textBox7.Text);


            MySqlDataReader lector = sql.ExecuteReader();

            if (lector.Read()) {


                groupBox1.Text = "Datos del Pedido " + textBox7.Text ;
                groupBox1.Enabled = true;
                textBox1.Text = lector["CodigoDeBarras"].ToString();
                textBox2.Text = lector["IdEmpleado"].ToString();
                textBox3.Text = lector["PedidoRealizado"].ToString();
                textBox4.Text = "$ " + lector["CostoDePedido"].ToString();
                textBox5.Text = lector["FechaDePedido"].ToString();
                textBox6.Text = lector["FechaDeEntrega"].ToString();
                textBox7.Focus();


            }
            else
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                
             
                MessageBox.Show("El pedido no existe", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox7.Focus();
            }
                
            lector.Close();



            conexion.Close();

        }
        public bool checarCambios()
        {
            if (textBox7.Text != "")
            {
                return true;

            }
            return false;
        }

        private void BusPedido_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
           if (textBox1.Text.Length > 0 && e.KeyChar == (char)13)
            {
                button1.Focus();
            }
           
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox7.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
            if (textBox7.Text.Length > 0 && e.KeyChar == (char)13)
            {
                button1.Focus();
            }
            else if (!(e.KeyChar >= 'A' && e.KeyChar <= 'Z') && !(e.KeyChar >= 'a' && e.KeyChar <= 'z') && !(e.KeyChar >= '0' && e.KeyChar <= '9')
                && e.KeyChar != (char)8)

                e.KeyChar = (char)0;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarCambios();
        }
    }
}
