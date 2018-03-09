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
    public partial class RegPedido : Form
    {
        List<String> nombreProducto;
        List<String> nombreEmpleado;
        public RegPedido()
        {
            InitializeComponent();
        }
        public bool checarcambios()
        {
            if (textBox1.Text=="" || comboBox1.Text== "" || comboBox2.Text==""||textBox3.Text==""
                || comboBox3.Text=="" || dateTimePicker1.Text=="" || dateTimePicker2.Text=="" )
            {
                return false;
            }
            return true;
        }

        private void RegPedido_Load(object sender, EventArgs e)
        {
            MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            conexion.Open();

            MySqlCommand productos = new MySqlCommand("select * from productos ", conexion);
            MySqlDataReader lector1 = productos.ExecuteReader();
            comboBox1.Items.Clear();
            nombreProducto = new List<String>();
            while (lector1.Read()) {
                comboBox1.Items.Add(lector1["CodigoDeBarras"].ToString());
                nombreProducto.Add(lector1["Nombre"].ToString());
            }
            comboBox1.SelectedIndex = 0;
            lector1.Close();

            MySqlCommand empleado = new MySqlCommand("select * from empleado ", conexion);
            MySqlDataReader lector2 = empleado.ExecuteReader();
            comboBox2.Items.Clear();
            nombreEmpleado = new List<String>();

            while (lector2.Read()) {
                comboBox2.Items.Add(lector2["IdEmpleado"].ToString());
                nombreEmpleado.Add(lector2["Nombre"].ToString()+" "+lector2["ApellidoP"].ToString());
            }
            comboBox2.SelectedIndex=0;
            lector2.Close();
            conexion.Close();

            comboBox3.SelectedIndex = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            conexion.Open();
            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                MessageBox.Show("Selecciona una fecha mayor a la fecha de pedido", "Informacion",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                dateTimePicker2.Focus();
            }
            else
            {
                MySqlCommand sql = new MySqlCommand("select * from pedido where IdPedido=@IdPedido", conexion);
                sql.Parameters.AddWithValue("@IdPedido", textBox1.Text);
                MySqlDataReader lector = sql.ExecuteReader();

                if (lector.Read())
                {
                    MessageBox.Show("El Id del pedido ya existe modifiquelo y vuelva a Intentarlo",
                            "Informacion",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Focus();
                    lector.Close();
                }
                else {

                    lector.Close();
                    MySqlCommand sql2 = new MySqlCommand("insert into pedido values(@IdPedido," +
                        "@CodigoDeBarras,@IdEmpleado,@PedidoRealizado,@CostoDePedido,@FechaDePedido,@FechaDeEntrega)", conexion);
                    sql2.Parameters.AddWithValue("@IdPedido", textBox1.Text);
                    sql2.Parameters.AddWithValue("@CodigoDeBarras", comboBox1.Text);
                    sql2.Parameters.AddWithValue("@IdEmpleado", comboBox2.Text);
                    sql2.Parameters.AddWithValue("@PedidoRealizado", comboBox3.Text);
                    sql2.Parameters.AddWithValue("@CostoDePedido", textBox3.Text);
                    sql2.Parameters.AddWithValue("@FechaDePedido", dateTimePicker1.Value);
                    sql2.Parameters.AddWithValue("@FechaDeEntrega", dateTimePicker2.Value);

                    int r = sql2.ExecuteNonQuery();
                    if (r > 0)
                    {
                        MessageBox.Show("Se ha guardado correctamente",
                            "Informacion",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Clear();
                        textBox3.Clear();
                        textBox1.Focus();
                    }
                    else
                        MessageBox.Show("No se ha podido guardar la venta", "informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                }
            }

            
            conexion.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label8.Text=nombreProducto.ElementAt(comboBox1.SelectedIndex);
            button1.Enabled = checarcambios();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label9.Text = nombreEmpleado.ElementAt(comboBox2.SelectedIndex);
            button1.Enabled = checarcambios();
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

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
               if (textBox1.Text.Length > 0 && e.KeyChar == (char)13)
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
                textBox3.Focus();
        }

        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dateTimePicker1.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
              if (dateTimePicker1.Text.Length > 0 && e.KeyChar == (char)13)
                dateTimePicker2.Focus();

        }

        private void dateTimePicker2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dateTimePicker1.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
           if (dateTimePicker1.Text.Length > 0 && e.KeyChar == (char)13)
                button1.Focus();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox3.Text.Contains('.'))
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
            if (textBox3.Text.Length > 0 && e.KeyChar == (char)13)
                dateTimePicker2.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarcambios();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarcambios();
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarcambios();
        }

        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarcambios();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarcambios();
        }

        private void dateTimePicker1_TabIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarcambios();
        }

        private void dateTimePicker2_TabIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarcambios();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarcambios();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarcambios();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarcambios();
        }
    }
}
