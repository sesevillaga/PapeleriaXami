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
    public partial class RegProductos : Form
    {
        public RegProductos()
        {
            InitializeComponent();
        }
        public bool checarCambios()
        {
            if (textBox1.Text != "" &&
                comboBox1.Text != "" &&
                textBox2.Text != "" &&
                textBox3.Text != "" &&
                textBox4.Text != "" &&
                textBox5.Text != "" &&
                textBox6.Text != "")
            {
                return true;
            }

            return false;
        }

        List<String> nombres;

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
                MessageBox.Show("EL Codigo De Barras Ya existe, Modifiquelo y vuelva ha intentarlo ");
                lector.Close();
            }
            else
            {
                lector.Close();
                MySqlCommand sql2 = new MySqlCommand("insert into productos values(@CodigoDeBarras,"+
                    "@IdProveedores,@Nombre,@Marca,@Cantidad,@PrecioDeCompra,@PrecioDeVenta)",conexion);
                sql2.Parameters.AddWithValue("@CodigoDeBarras",textBox1.Text);
                sql2.Parameters.AddWithValue("@IdProveedores",comboBox1.Text);
                sql2.Parameters.AddWithValue("@Nombre",textBox2.Text);
                sql2.Parameters.AddWithValue("@Marca",textBox3.Text);
                sql2.Parameters.AddWithValue("@Cantidad",textBox4.Text);
                sql2.Parameters.AddWithValue("@PrecioDeCompra",textBox5.Text);
                sql2.Parameters.AddWithValue("@PrecioDeVenta",textBox6.Text);

                int r = sql2.ExecuteNonQuery();


                if (r > 0)
                {
                    MessageBox.Show("Se ha guardado correctamente",
                        "Informacion",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboBox1.SelectedIndex = 0;
                    textBox1.Text =
                        textBox2.Text =
                        textBox3.Text =
                        textBox4.Text =
                        textBox5.Text =
                        textBox6.Text = "";
                    textBox1.Focus();
                }
                else
                {
                    MessageBox.Show("No se ha podido guardar el producto", "Infomacion", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    textBox1.Focus();
                }
                
                    
                
                    

                

            }

            conexion.Close();
        }

        private void RegProductos_Load(object sender, EventArgs e)
        {

            MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            conexion.Open();

            MySqlCommand sql = new MySqlCommand("select * from proveedores",conexion);

            MySqlDataReader lector = sql.ExecuteReader();

            comboBox1.Items.Clear();
            nombres = new List<string>();

            while (lector.Read())
            {
                comboBox1.Items.Add(lector["IdProveedores"].ToString());
                nombres.Add(lector["Nombre"].ToString());
            }
            comboBox1.SelectedIndex = -1;
            lector.Close();

            conexion.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label8.Text = nombres.ElementAt(comboBox1.SelectedIndex);
            button1.Enabled = checarCambios();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
            if (textBox1.Text.Length > 0 && e.KeyChar == (char)13)
                comboBox1.Focus();
            else if (!(e.KeyChar >= '0' && e.KeyChar <= '9') 
               && e.KeyChar != (char)8)
            {
                e.KeyChar = (char)0;
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
          if (comboBox1.Text.Length > 0 && e.KeyChar == (char)13)
                textBox2.Focus();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox2.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
           if (textBox2.Text.Length > 0 && e.KeyChar == (char)13)
               textBox3.Focus();
            else if (!(e.KeyChar >= 'a' && e.KeyChar <= 'z') && !(e.KeyChar >= 'A' && e.KeyChar <= 'Z')
               && e.KeyChar != (char)8)
            {
                e.KeyChar = (char)0;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox3.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
           if (textBox3.Text.Length > 0 && e.KeyChar == (char)13)
                textBox4.Focus();
            else if ( !(e.KeyChar >= 'a' && e.KeyChar <= 'z') && !(e.KeyChar >= 'A' && e.KeyChar <= 'Z')
               && e.KeyChar != (char)8)
            {
                e.KeyChar = (char)0;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox4.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
                      if (textBox4.Text.Length > 0 && e.KeyChar == (char)13)
                textBox5.Focus();
            else if (!(e.KeyChar >= '0' && e.KeyChar <= '9') && e.KeyChar != (char)8)
            {
                e.KeyChar = (char)0;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (textBox5.Text.Contains('.'))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
            else
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                if (e.KeyChar == '.' || e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
            if (textBox5.Text.Length > 0 && e.KeyChar == (char)13)
                textBox6.Focus();

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {

            
            if (textBox6.Text.Contains('.'))
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                if (e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
            else
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                if (e.KeyChar == '.' || e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
            }
            if (textBox6.Text.Length > 0 && e.KeyChar == (char)13)
                button1.Focus();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarCambios();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarCambios();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarCambios();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarCambios();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarCambios();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarCambios();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
