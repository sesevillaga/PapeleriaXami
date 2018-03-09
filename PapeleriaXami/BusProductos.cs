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
using MySql.Data.MySqlClient;

namespace PapeleriaXami
{
    public partial class BusProductos : Form
    {
        public BusProductos()
        {
            InitializeComponent();
        }
        public bool checarCambios()
        {
            if (textBox1.Text != "")
            {
                return true;

            }
            return false;
        }
        private void BusProductos_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            conexion.Open();

            MySqlCommand sql = new MySqlCommand("select * from productos where CodigoDeBarras=@Clave",conexion);
            sql.Parameters.AddWithValue("@Clave",textBox1.Text);

            MySqlDataReader lector = sql.ExecuteReader();

            if (lector.Read())
            {

                textBox2.Text = lector["IdProveedores"].ToString();
                textBox3.Text = lector["Nombre"].ToString();
                textBox4.Text = lector["Marca"].ToString();
                textBox5.Text = lector["Cantidad"].ToString();
                textBox6.Text = lector["PrecioDeCompra"].ToString();
                textBox7.Text = lector["PrecioDeVenta"].ToString();
               textBox1.Focus();

            }
            else
            {
                MessageBox.Show("El producto que busca no existe", "Informacion", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox1.Focus();
            }
                

            lector.Close();

            conexion.Close();

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (textBox1.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
                      if (textBox1.Text.Length > 0 && e.KeyChar == (char)13)
                button1.Focus();
            else if (!(e.KeyChar >= '0' && e.KeyChar <= '9') && e.KeyChar != (char)8)
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
