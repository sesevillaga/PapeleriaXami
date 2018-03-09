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
    public partial class RegistrarCompras : Form
    {
        public RegistrarCompras()
        {
            InitializeComponent();
        }
        List<String> nombres;
        List<String> nombres2;

        public bool checarCambios()
        {
            if (textBox1.Text != "" && textBox4.Text != "" && textBox5.Text != "" )
            {
                return true;

            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection Conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            Conexion.Open();
            MySqlCommand Validar = new MySqlCommand("select * from compras where IdCompras=@Clave ", Conexion);
            Validar.Parameters.AddWithValue("@clave",textBox1.Text);

            MySqlDataReader lector = Validar.ExecuteReader();

            if (lector.Read())
            {
                MessageBox.Show("El IdCompras de compras ya existe vuelva  a intentarlo");
                lector.Close();
            }
            else
            {
                lector.Close();
                MySqlCommand Comando = new MySqlCommand("insert into compras values(@IdCompras,@IdEmpleado,@CodigoDeBarras,@CantidadDeProductos,@Costo,@Fecha)" , Conexion);
                Comando.Parameters.AddWithValue("@IdCompras", textBox1.Text);
                Comando.Parameters.AddWithValue("@IdEmpleado",comboBox1.Text);
                Comando.Parameters.AddWithValue("@CodigoDeBarras", comboBox2.Text);
                Comando.Parameters.AddWithValue("@CantidadDeProductos",textBox4.Text);
                Comando.Parameters.AddWithValue("@Costo", textBox5.Text);
                Comando.Parameters.AddWithValue("@Fecha",dateTimePicker1.Value);

                int Resultado = Comando.ExecuteNonQuery();
                if (Resultado > 0)
                {
                    MessageBox.Show("Se aguardado Exitosamente", "Informacion",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Text =
                        textBox4.Text =
                        textBox5.Text = "";
                    comboBox1.SelectedIndex = 0;
                    comboBox2.SelectedIndex = 0;
                    textBox1.Focus();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar la compra", "Informacion",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Text =
                        textBox4.Text =
                        textBox5.Text = "";
                    comboBox1.SelectedIndex =0;
                    comboBox2.SelectedIndex = 0;
                    
                    textBox1.Focus();
                }
                    
            }

            Conexion.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarCambios();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (textBox4.Text.Length == 0 && e.KeyChar == ' ')

                e.KeyChar = (char)0;


            else if (textBox4.Text.Length > 0 && e.KeyChar == (char)13)
            
                textBox5.Focus();
            
            else if (!(e.KeyChar >= '0' && e.KeyChar <= '9')
             && e.KeyChar != (char)8)
            
                e.KeyChar = (char)0;



            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
            if (textBox1.Text.Length > 0 && e.KeyChar == (char)13)
            {
                comboBox1.Focus();
            }
            else if (!(e.KeyChar >= 'A' && e.KeyChar <= 'Z') && !(e.KeyChar >= 'a' && e.KeyChar <= 'z') && !(e.KeyChar >= '0' && e.KeyChar <= '9')
                && e.KeyChar != (char)8)

                e.KeyChar = (char)0;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void RegistrarCompras_Load(object sender, EventArgs e)
        {
            MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            conexion.Open();

            MySqlCommand empleado = new MySqlCommand("select * from empleado ", conexion);
            MySqlDataReader lector = empleado.ExecuteReader();

            comboBox1.Items.Clear();
            nombres = new List<string>();

            while (lector.Read())
            {
                comboBox1.Items.Add(lector["IdEmpleado"].ToString());
                nombres.Add(lector["Nombre"].ToString());
            }
            comboBox1.SelectedItem = -1;
            lector.Close();

            MySqlCommand codigoBarras = new MySqlCommand("select * from Productos",conexion);
            MySqlDataReader lector2 = codigoBarras.ExecuteReader();

            comboBox2.Items.Clear();
            nombres2 = new List<string>();

            while (lector2.Read())
            {
                comboBox2.Items.Add(lector2["CodigoDeBarras"].ToString());
                nombres2.Add(lector2["Nombre"].ToString());
            }
            comboBox2.SelectedIndex = -1;
            lector2.Close();


            conexion.Close();

            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label7.Text = nombres.ElementAt(comboBox1.SelectedIndex);

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label8.Text = nombres2.ElementAt(comboBox2.SelectedIndex);
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
                button1.Focus();





        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
           if (comboBox1.Text.Length > 0 && e.KeyChar == (char)13)
            {
                comboBox2.Focus();
            }
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox2.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
           if (comboBox2.Text.Length > 0 && e.KeyChar == (char)13)
            {
                textBox4.Focus();
            }
        }

        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dateTimePicker1.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
          if (dateTimePicker1.Text.Length > 0 && e.KeyChar == (char)13)
            {
                button1.Focus();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarCambios();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarCambios();
        }
    }
}
