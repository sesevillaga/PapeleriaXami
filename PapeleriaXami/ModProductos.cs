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
    public partial class ModProductos : Form
    {
        public ModProductos()
        {
            InitializeComponent();
        }


        List<String> nombres;

        private String CodigoDeBarras;
        private String IdProveedores;
        private String Nombre;
        private String Marca;
        private String Cantidad;
        private String PrecioDeCompra;
        private String PrecioDeVenta;

        public bool checarCambios()
        {
            if (textBox1.Text!=CodigoDeBarras ||
                comboBox1.Text!=IdProveedores ||
                textBox2.Text!=Nombre ||
                textBox3.Text!=Marca ||
                textBox4.Text!=Cantidad ||
                textBox5.Text!=PrecioDeCompra ||
                textBox6.Text!=PrecioDeVenta
                )
            {
                return true;
            }

            return false;
        }
        public bool checarCambios2()
        {
            if (textBox1.Text != "")
            {
                return true;

            }
            return false;
        }

        private void ModProductos_Load(object sender, EventArgs e)
        {
            MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            conexion.Open();

            MySqlCommand sql = new MySqlCommand("select * from proveedores", conexion);

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

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            conexion.Open();

            MySqlCommand sql = new MySqlCommand("select * from productos where CodigoDeBarras=@Clave", conexion);
            sql.Parameters.AddWithValue("@Clave", textBox1.Text);

            MySqlDataReader lector = sql.ExecuteReader();

            if (lector.Read())
            {
                comboBox1.Text = lector["IdProveedores"].ToString();
                textBox2.Text = lector["Nombre"].ToString();
                textBox3.Text = lector["Marca"].ToString();
                textBox4.Text = lector["Cantidad"].ToString();
                textBox5.Text = lector["PrecioDeCompra"].ToString();
                textBox6.Text = lector["PrecioDeVenta"].ToString();

                groupBox1.Enabled = true;
                groupBox1.Text = "Datos Editables, Codigo De Barras " + textBox1.Text;
                comboBox1.Focus();

                CodigoDeBarras = textBox1.Text;
                IdProveedores = comboBox1.Text;
                Nombre = textBox2.Text;
                Marca = textBox3.Text;
                Cantidad = textBox4.Text;
                PrecioDeCompra = textBox5.Text;
                PrecioDeVenta = textBox6.Text;

                button2.Enabled = false;

            }
            else
            {
                MessageBox.Show("No se pudo encontrar el producto", "Informacion", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox1.Focus();
                groupBox1.Enabled = false;
                groupBox1.Text = "Datos Editables";
            }
               

            lector.Close();

            conexion.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            conexion.Open();

            MySqlCommand sql = new MySqlCommand("update  productos set IdProveedores=@IdProveedores,Nombre=@Nombre,"+
                "Marca=@Marca,Cantidad=@Cantidad,PrecioDeCompra=@PrecioDeCompra,PrecioDeVenta=@PrecioDeVenta"+
                " where CodigoDeBarras=@CodigoDeBarras",conexion);

            sql.Parameters.AddWithValue("IdProveedores",comboBox1.Text);
            sql.Parameters.AddWithValue("Nombre",textBox2.Text);
            sql.Parameters.AddWithValue("Marca",textBox3.Text);
            sql.Parameters.AddWithValue("Cantidad",textBox4.Text);
            sql.Parameters.AddWithValue("PrecioDeCompra",textBox5.Text);
            sql.Parameters.AddWithValue("PrecioDeVenta",textBox6.Text);
            sql.Parameters.AddWithValue("CodigoDeBarras",this.CodigoDeBarras);

            int Resultado = sql.ExecuteNonQuery();

            if (Resultado > 0)
            {
                MessageBox.Show("El Producto ha sido Modificado","Informacion",MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                comboBox1.SelectedIndex = 0;
                textBox1.Text =
                    textBox2.Text =
                    textBox3.Text =
                    textBox4.Text =
                    textBox5.Text =
                    textBox6.Text = "";
                

                button2.Enabled = false;
                groupBox1.Enabled = false;
                groupBox1.Text = "Datos Editables";
                textBox1.Focus();

            }
            else {
                MessageBox.Show("No se ha Podido Modificar el Producto", "Informacion", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                textBox2.Focus();

            }
               


            conexion.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = checarCambios();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = checarCambios();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = checarCambios();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = checarCambios();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = checarCambios();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Enabled = checarCambios();
            label8.Text = nombres.ElementAt(comboBox1.SelectedIndex);
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
            else if (!(e.KeyChar >= 'a' && e.KeyChar <= 'z')&& !(e.KeyChar >= 'A' && e.KeyChar <= 'Z') && e.KeyChar != (char)8)
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
            else if (!(e.KeyChar >= 'a' && e.KeyChar <= 'z') && !(e.KeyChar >= 'A' && e.KeyChar <= 'Z') && e.KeyChar != (char)8)
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
                button2.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarCambios2();
        }
    }
}
