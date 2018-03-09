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
    public partial class BuscarCompras : Form
    {
        public BuscarCompras()
        {
            InitializeComponent();
        }

        private void BuscarCompras_Load(object sender, EventArgs e)
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
        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            conexion.Open();
            MySqlCommand SQL = new MySqlCommand("select * from compras where IdCompras=@Clave",conexion);
            SQL.Parameters.AddWithValue("@Clave",textBox1.Text);
            MySqlDataReader lector = SQL.ExecuteReader();

            if (lector.Read())
            {
                textBox2.Text = lector["IdEmpleado"].ToString();
                textBox3.Text = lector["CodigoDeBarras"].ToString();
                textBox4.Text = lector["CantidadDeProductos"].ToString();
                textBox5.Text = lector["Costo"].ToString();
                textBox6.Text = lector["Fecha"].ToString();
                textBox1.Focus();
            }
            else
            {
                MessageBox.Show("La compra que busca no exite vuelva a intentarlo", "Informacion",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox1.Focus();

            }
                

            lector.Close();
            conexion.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarCambios();
        }
    }
}
