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
    public partial class ModCompras : Form
    {
        public ModCompras()
        {
            InitializeComponent();
        }
        List<String> nombres;
        List<String> nombres2;

        private String IdCompras;
        private String IdEmpleado;
        private String CodigoDeBarras;
        private String CantidadDeProductos;
        private String Costo;
        private String Fecha;

        public bool Checarcambios()
        {
            if (textBox1.Text!=IdCompras||textBox2.Text!=Costo || textBox4.Text!=CantidadDeProductos
                || comboBox1.Text!=IdEmpleado || comboBox2.Text!=CodigoDeBarras || dateTimePicker1.Text!=Fecha)
            {
                return true;
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            conexion.Open();
            MySqlCommand sql = new MySqlCommand("Select * from compras where IdCompras=@clave",conexion);
            sql.Parameters.AddWithValue("@clave", textBox1.Text);

            MySqlDataReader lector = sql.ExecuteReader();

            if (lector.Read())
            {
                comboBox1.Text = lector["IdEmpleado"].ToString();
                comboBox2.Text = lector["CodigoDeBarras"].ToString();
                textBox4.Text = lector["CantidadDeProductos"].ToString();
                textBox2.Text = lector["Costo"].ToString();
                dateTimePicker1.Text = lector["Fecha"].ToString();

                groupBox1.Enabled = true;
                groupBox1.Text = "Datos Editables, IdCompras" + textBox1.Text;
                dateTimePicker1.Enabled = false;
                comboBox1.Focus();

                IdCompras = textBox1.Text;
                IdEmpleado = comboBox1.Text;
                CodigoDeBarras = comboBox2.Text;
                CantidadDeProductos = textBox4.Text;
                Costo = textBox2.Text;
                Fecha = dateTimePicker1.Text;

                button3.Enabled = false;
            }
            else
            {
                MessageBox.Show("No se pudo en contrar la compra especifica", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                groupBox1.Enabled = false;
                textBox4.Clear();
                textBox2.Clear();
                textBox1.Focus();

            }
                

            lector.Close();
            conexion.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            conexion.Open();
            MySqlCommand sql = new MySqlCommand("update compras set IdEmpleado=@idempleado,"
                + "CodigoDeBarras=@CodiBarras,CantidadDeProductos=@CantiProduct,Costo=@costo,"
                +"Fecha=@fecha where IdCompras=@idcompras ", conexion);

            sql.Parameters.AddWithValue("idempleado",comboBox1.Text );
            sql.Parameters.AddWithValue("CodiBarras", comboBox2.Text);
            sql.Parameters.AddWithValue("CantiProduct", textBox4.Text);
            sql.Parameters.AddWithValue("costo",textBox2.Text);
            sql.Parameters.AddWithValue("fecha", dateTimePicker1.Value);
            sql.Parameters.AddWithValue("idcompras", this.IdCompras);

            int Resultado = sql.ExecuteNonQuery();

            if (Resultado > 0)
            {
                MessageBox.Show("La Compra ha sido modificada", "Informacion", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                textBox1.Text =
                    textBox2.Text =
                    textBox4.Text = " ";

                button3.Enabled = false;
                groupBox1.Enabled = false;
                groupBox1.Text = "Datos Editables";
                textBox1.Focus();


            }
            else
            {
                MessageBox.Show("No se ha podido modificar la Compra", "Informacion", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                textBox1.Focus();
            }
                
            conexion.Close();
        }
        public bool checarCambios2()
        {
            if (textBox1.Text != "")
            {
                return true;

            }
            return false;
        }

        private void ModCompras_Load(object sender, EventArgs e)
        {
            MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            conexion.Open();
           MySqlCommand sql1 = new MySqlCommand("select * from empleado ", conexion);

            MySqlDataReader lector = sql1.ExecuteReader();

            comboBox1.Items.Clear();
            nombres = new List<string>();

            while (lector.Read())
            {
                comboBox1.Items.Add(lector["IdEmpleado"].ToString());
                nombres.Add(lector["nombre"].ToString());
            }
            comboBox1.SelectedIndex = -1;
            lector.Close();

            MySqlCommand sql2 = new MySqlCommand("select * from productos ", conexion);

            MySqlDataReader lector1 = sql2.ExecuteReader();
            comboBox2.Items.Clear();
            nombres2 = new List<string>();

            while (lector1.Read())
            {
                comboBox2.Items.Add(lector1["CodigoDeBarras"].ToString());
                nombres2.Add(lector1["nombre"].ToString());
            }
            comboBox2.SelectedIndex = -1;

            lector1.Close();
            conexion.Close();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {

            button3.Enabled = Checarcambios();
            label7.Text = nombres.ElementAt(comboBox1.SelectedIndex);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            button3.Enabled = Checarcambios();
            label8.Text = nombres2.ElementAt(comboBox2.SelectedIndex);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            button3.Enabled = Checarcambios();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button3.Enabled = Checarcambios();
        }

        private void dateTimePicker1_ImeModeChanged(object sender, EventArgs e)
        {
            button3.Enabled = Checarcambios();

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

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
              if (comboBox2.Text.Length > 0 && e.KeyChar == (char)13)
                comboBox2.Focus();
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox2.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
              if (comboBox2.Text.Length > 0 && e.KeyChar == (char)13)
                textBox4.Focus();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox4.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
              if (textBox4.Text.Length > 0 && e.KeyChar == (char)13)
                textBox2.Focus();
            else if (!(e.KeyChar >= '0' && e.KeyChar <= '9')
            && e.KeyChar != (char)8)
            {
                e.KeyChar = (char)0;

            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox2.Text.Contains('.'))
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
            if (textBox2.Text.Length > 0 && e.KeyChar == (char)13)
                button3.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarCambios2();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
