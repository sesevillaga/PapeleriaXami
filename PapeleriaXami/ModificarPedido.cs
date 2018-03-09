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
    public partial class ModificarPedido : Form
    {
        List<String> nombreProducto;
        List<String> nombreEmpleado;

        private String IdPedido;
        private String CodigoDeBarras;
        private String IdEmpleado;
        private String PedidoRealizado;
        private String CostoDePedido;
        private String FechaDePedido;
        private String FechaDeEntrega;


        public bool checarCambios() {

            if(textBox1.Text != IdPedido || comboBox1.Text != CodigoDeBarras ||comboBox2.Text != IdEmpleado || comboBox3.Text != PedidoRealizado || textBox3.Text != CostoDePedido
                || dateTimePicker1.Text != FechaDePedido || dateTimePicker2.Text != FechaDeEntrega ) {
                return true;
            }
            return false;
        }

        public ModificarPedido()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            conexion.Open();
            MySqlCommand sql = new MySqlCommand("select * from pedido where IdPedido=@IdPedido", conexion);
            sql.Parameters.AddWithValue("IdPedido",textBox1.Text);
            MySqlDataReader lector = sql.ExecuteReader();

            if (lector.Read())
            {
                comboBox1.Text = lector["CodigoDeBarras"].ToString();
                comboBox2.Text = lector["IdEmpleado"].ToString();
                comboBox3.Text = lector["PedidoRealizado"].ToString();
                textBox3.Text = lector["CostoDePedido"].ToString();
                dateTimePicker1.Text = lector["FechaDePedido"].ToString();
                dateTimePicker2.Text = lector["FechaDeEntrega"].ToString();
                groupBox1.Enabled = true;
                groupBox1.Text = "Datos del Pedido, IdPedido" + textBox1.Text;
                comboBox1.Focus();


                IdPedido = textBox1.Text;
                CodigoDeBarras = comboBox1.Text;
                IdEmpleado = comboBox2.Text;
                PedidoRealizado = comboBox3.Text;
                CostoDePedido = textBox3.Text;
                FechaDePedido = dateTimePicker1.Text;
                FechaDeEntrega = dateTimePicker2.Text;
                button2.Enabled = false;
            }
            else
            {
                MessageBox.Show("No se puedo encontrar su pedido", "informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Clear();
                groupBox1.Enabled = false;
                textBox1.Focus();
            }
                
            lector.Close();
            conexion.Close();
             

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Enabled = checarCambios();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            conexion.Open();

            MySqlCommand sql = new MySqlCommand("update pedido set CodigoDeBarras=@CodigoDeBarras," +
                "IdEmpleado=@IdEmpleado," +
                "PedidoRealizado=@PedidoRealizado,CostoDePedido=@CostoDePedido,FechaDePedido=@FechaDePedido," +
                "FechaDeEntrega=@FechaDeEntrega where IdPedido=@IdPedido", conexion);
            sql.Parameters.AddWithValue("CodigoDeBarras", comboBox1.Text);
            sql.Parameters.AddWithValue("IdEmpleado", comboBox2.Text);
            sql.Parameters.AddWithValue("PedidoRealizado", comboBox3.Text);
            sql.Parameters.AddWithValue("CantidadDeProducto", textBox3.Text);
            sql.Parameters.AddWithValue("CostoDePedido", textBox3.Text);
            sql.Parameters.AddWithValue("FechaDePedido", dateTimePicker1.Value);
            sql.Parameters.AddWithValue("FechaDeEntrega", dateTimePicker2.Value);
            sql.Parameters.AddWithValue("IdPedido", this.IdPedido);

            int Resultado = sql.ExecuteNonQuery();
            if (Resultado > 0)
            {

                MessageBox.Show("El pedido ha sido modificado", "informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Clear();
                textBox1.Clear();
                comboBox1.SelectedIndex= 0;
                comboBox2.SelectedIndex = 0; 
                comboBox3.SelectedIndex = 0;
                button2.Enabled = false;
                groupBox1.Enabled = false;
                groupBox1.Text = "Datos del Pedido";
                textBox1.Focus();


            }
            else
            {
                MessageBox.Show("No se ha podido modificar el pedido", "informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
                
            conexion.Close();

        }

        private void ModificarPedido_Load(object sender, EventArgs e)
        {
            MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            conexion.Open();
            MySqlCommand empleado = new MySqlCommand("select * from productos", conexion);
            MySqlDataReader lector1 = empleado.ExecuteReader();
            comboBox1.Items.Clear();
            nombreProducto = new List<String>();
            while (lector1.Read())
            {
                comboBox1.Items.Add(lector1["CodigoDeBarras"].ToString());
                nombreProducto.Add(lector1["Nombre"].ToString());

            }
            comboBox1.SelectedIndex = 0;
            lector1.Close();

            MySqlCommand Empleado = new MySqlCommand("select * from Empleado", conexion);
            MySqlDataReader lector3 = Empleado.ExecuteReader();
            comboBox2.Items.Clear();
            nombreEmpleado = new List<String>();
            while (lector3.Read())
            {
                comboBox2.Items.Add(lector3["IdEmpleado"].ToString());
                nombreEmpleado.Add(lector3["Nombre"].ToString() + " " + lector3["ApellidoP"].ToString());
            }
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            lector3.Close();

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label8.Text = nombreProducto.ElementAt(comboBox1.SelectedIndex);
            button2.Enabled=checarCambios();

             
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label9.Text = nombreEmpleado.ElementAt(comboBox2.SelectedIndex);
            button2.Enabled = checarCambios();

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = checarCambios();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            button2.Enabled = checarCambios();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            button2.Enabled = checarCambios();
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
            if (comboBox2.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
               if (comboBox2.Text.Length > 0 && e.KeyChar == (char)13)
                textBox3.Focus();
        }

        private void dateTimePicker2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dateTimePicker2.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
            if (dateTimePicker2.Text.Length > 0 && e.KeyChar == (char)13)
                dateTimePicker1.Focus();
        }

        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dateTimePicker1.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
            if (dateTimePicker1.Text.Length > 0 && e.KeyChar == (char)13)
                dateTimePicker1.Focus();
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
            button1.Enabled = checarCambios2();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
