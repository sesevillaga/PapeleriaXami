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
    public partial class RegVentas : Form
    {
        List<String> nombresEmpleados;
        List<String> nombresClientes;
        List<String> nombresProductos;



        public RegVentas()
        {
            InitializeComponent();
        }
        public bool checarCambios()
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != ""
                && textBox4.Text!="" && comboBox1.Text!="" && comboBox2.Text!="" && 
                comboBox3.Text!="" && dateTimePicker1.Text!="")
            {
                return true;

            }
            return false;
        }

        private void RegVentas_Load(object sender, EventArgs e)
        {
            MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            conexion.Open();

            MySqlCommand empleado = new MySqlCommand("select * from empleado", conexion);
            MySqlDataReader lector1 = empleado.ExecuteReader();
            comboBox1.Items.Clear();
            nombresEmpleados = new List<String>();
            while (lector1.Read())
            {
                comboBox1.Items.Add(lector1["IdEmpleado"].ToString());
                nombresEmpleados.Add(lector1["Nombre"].ToString() + " " + lector1["ApellidoP"].ToString());
                
            }
            comboBox1.SelectedIndex = 0;
            lector1.Close();



            MySqlCommand cliente = new MySqlCommand("select * from cliente", conexion);
            MySqlDataReader lector2 = cliente.ExecuteReader();
            comboBox2.Items.Clear();
            nombresClientes = new List<String>();
            while (lector2.Read())
            {
                comboBox2.Items.Add(lector2["IdCliente"].ToString());
                nombresClientes.Add(lector2["Nombre"].ToString() + " " + lector2["ApellidoP"].ToString());
            }
            comboBox2.SelectedIndex = 0;
            lector2.Close();



            MySqlCommand producto = new MySqlCommand("select * from productos", conexion);
            MySqlDataReader lector3 = producto.ExecuteReader();
            comboBox3.Items.Clear();
            nombresProductos = new List<String>();
            while (lector3.Read())
            {
                comboBox3.Items.Add(lector3["CodigoDeBarras"].ToString());
                nombresProductos.Add(lector3["Nombre"].ToString());

            }
            comboBox3.SelectedIndex = 0;
            lector3.Close();







            conexion.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            conexion.Open();

            MySqlCommand sql = new MySqlCommand("select * from ventas where IdVentas=@IdVentas", conexion);
            sql.Parameters.AddWithValue("@IdVentas", textBox1.Text);

            MySqlDataReader lector = sql.ExecuteReader();
            if (lector.Read())
            {
                MessageBox.Show("EL Codigo De Barras Ya existe, Modifiquelo y vuelva ha intentarlo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lector.Close();
            }
            else
            {
                lector.Close();
                MySqlCommand sql2 = new MySqlCommand("insert into ventas values(@IdVentas,@IdEmpleado,@IdCliente,@CodigoDeBarras,@CantidadDeProducto,@Folio,@Costo,@fecha)", conexion);
                sql2.Parameters.AddWithValue("IdVentas", textBox1.Text);
                sql2.Parameters.AddWithValue("IdEmpleado", comboBox1.Text);
                sql2.Parameters.AddWithValue("IdCliente", comboBox2.Text);
                sql2.Parameters.AddWithValue("CodigoDeBarras", comboBox3.Text);
                sql2.Parameters.AddWithValue("CantidadDeProducto", textBox2.Text);
                sql2.Parameters.AddWithValue("Folio", textBox3.Text);
                sql2.Parameters.AddWithValue("Costo", textBox4.Text);
                sql2.Parameters.AddWithValue("fecha", dateTimePicker1.Value);

                int r = sql2.ExecuteNonQuery();


                if (r > 0)
                {
                    MessageBox.Show("Se ha guardado correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox1.Focus();
                }
                else
                {
                    MessageBox.Show("No se ha podido guardar la venta", "Infomacion", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    textBox1.Focus();

                }
                    
            }

           
            conexion.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label9.Text = nombresEmpleados.ElementAt(comboBox1.SelectedIndex);
            button1.Enabled = checarCambios();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label10.Text = nombresClientes.ElementAt(comboBox2.SelectedIndex);
            button1.Enabled = checarCambios();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            label11.Text = nombresProductos.ElementAt(comboBox3.SelectedIndex);
            button1.Enabled = checarCambios();
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
                comboBox1.Focus();
            }
            else if (!(e.KeyChar >= 'A' && e.KeyChar <= 'Z') && !(e.KeyChar >= 'a' && e.KeyChar <= 'z') && !(e.KeyChar >= '0' && e.KeyChar <= '9')
                && e.KeyChar != (char)8)

                e.KeyChar = (char)0;
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
         if (comboBox1.Text.Length > 0 && e.KeyChar == (char)13)
                comboBox2.Focus();
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox2.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
        if (comboBox2.Text.Length > 0 && e.KeyChar == (char)13)
                comboBox3.Focus();
        }

        private void comboBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox3.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
        if (comboBox3.Text.Length > 0 && e.KeyChar == (char)13)
                textBox2.Focus();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox2.Text.Length == 0 && e.KeyChar == ' ')

                e.KeyChar = (char)0;


            else if (textBox2.Text.Length > 0 && e.KeyChar == (char)13)

                textBox3.Focus();

            else if (!(e.KeyChar >= '0' && e.KeyChar <= '9')
             && e.KeyChar != (char)8)

                e.KeyChar = (char)0;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (textBox4.Text.Contains('.'))
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
            if (textBox4.Text.Length > 0 && e.KeyChar == (char)13)
                button1.Focus();
        }

        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dateTimePicker1.Text.Length > 0 && e.KeyChar == (char)13)
                button1.Focus();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox3.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
         if (textBox3.Text.Length > 0 && e.KeyChar == (char)13)
            {
                textBox4.Focus();
            }
            else if (!(e.KeyChar >= 'A' && e.KeyChar <= 'Z') && !(e.KeyChar >= 'a' && e.KeyChar <= 'z') && !(e.KeyChar >= '0' && e.KeyChar <= '9')
                && e.KeyChar != (char)8)

                e.KeyChar = (char)0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarCambios();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarCambios();
        }
    }
}
