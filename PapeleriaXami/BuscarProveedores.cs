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
    public partial class BuscarProveedores : Form
    {
        public BuscarProveedores()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            conexion.Open();

            MySqlCommand sql = new MySqlCommand("select * from proveedores where IdProveedores=@clave", conexion);
            sql.Parameters.AddWithValue("@clave",textBox1.Text);

            MySqlDataReader lector = sql.ExecuteReader();

            if (lector.Read())
            {
                textBox2.Text = lector["Nombre"].ToString();
                textBox3.Text = lector["Telefono"].ToString();
                textBox4.Text = lector["Direccion"].ToString();
                textBox5.Text = lector["Email"].ToString();
                textBox6.Text = lector["RFC"].ToString();
                textBox1.Focus();

            }
            else
            {
                MessageBox.Show("El proveedor que busca no existe", "Informacion", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
                button1.Focus();
            else if (!(e.KeyChar >= '0' && e.KeyChar <= '9')  && e.KeyChar != (char)8)
            {
                e.KeyChar = (char)0;
            }
        }
        public bool checarCambios2()
        {
            if (textBox1.Text != "")
            {
                return true;

            }
            return false;
        }

        private void BuscarProveedores_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled=checarCambios2();
        }
    }
}
