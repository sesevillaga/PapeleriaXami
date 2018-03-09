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
    public partial class BuscarCliente : Form
    {
        public BuscarCliente()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
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
            MySqlCommand SQL = new MySqlCommand("Select * from cliente where IdCliente=@Clave", conexion);
            SQL.Parameters.AddWithValue("@Clave", textBox1.Text);

            MySqlDataReader lector = SQL.ExecuteReader();

            if (lector.Read())
            {
                textBox2.Text = lector["Nombre"].ToString();
                textBox3.Text = lector["ApellidoP"].ToString();
                textBox4.Text = lector["ApellidoM"].ToString();
                textBox5.Text = lector["Direccion"].ToString();
                textBox6.Text = lector["RFC"].ToString();
                textBox7.Text = lector["Email"].ToString();
                textBox8.Text = lector["Fecha"].ToString();
                textBox1.Focus();
            }
            else
            {
                MessageBox.Show("No se encuentra el cliente", "Informacion",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
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
            {
                button1.Focus();
            }
            else if (!(e.KeyChar >= 'A' && e.KeyChar <= 'Z') && !(e.KeyChar >= 'a' && e.KeyChar <= 'z') && !(e.KeyChar >= '0' && e.KeyChar <= '9')
                && e.KeyChar != (char)8)

                e.KeyChar = (char)0;
        }
        public bool checarCambios()
        {
            if (textBox1.Text != "")
            {
                return true;

            }
            return false;
        }
        private void BuscarCliente_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarCambios();
        }
    }
}
