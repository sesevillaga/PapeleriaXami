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
    public partial class ModVentas : Form
    {
        List<String> nombresEmpleados;
        List<String> nombresClientes;
        List<String> nombresProductos;
        private String IdVentas;
        private String IdEmpleado;
        private String IdCliente;
        private String CodigoDeBarras;
        private String CantidadDeProducto;
        private String Folio;
        private String Costo;
        private String fecha;


        public bool checarCambios()
        {
            if (textBox1.Text != IdVentas || comboBox1.Text != IdEmpleado || comboBox2.Text != IdCliente || comboBox3.Text!=CodigoDeBarras
                || textBox2.Text!=CantidadDeProducto || textBox3.Text!=Folio || textBox4.Text!=Costo || dateTimePicker1.Text!=fecha)
            {
                return true;

            }
            return false;
        }



        public ModVentas()
        {
            InitializeComponent();
        }
        public bool checarCambios2()
        {
            if (textBox1.Text != "")
            {
                return true;

            }
            return false;
        }

        private void ModVentas_Load(object sender, EventArgs e)
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
                nombresEmpleados.Add(lector1["Nombre"].ToString() + lector1["ApellidoP"].ToString());
                
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
                nombresClientes.Add(lector2["Nombre"].ToString() + lector2["ApellidoP"].ToString());
                
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label9.Text = nombresEmpleados.ElementAt(comboBox1.SelectedIndex);
            button3.Enabled = checarCambios();
            

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            label10.Text = nombresClientes.ElementAt(comboBox2.SelectedIndex);
            button3.Enabled = checarCambios();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            label11.Text = nombresProductos.ElementAt(comboBox3.SelectedIndex);
            button3.Enabled = checarCambios();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            conexion.Open();

            MySqlCommand sql = new MySqlCommand("update ventas set IdEmpleado=@IdEmpleado,"+
                "IdCliente=@IdCliente,CodigoDeBarras=@CodigoDeBarras,"+
                "CantidadDeProducto=@CantidadDeProducto,Folio=@Folio,Costo=@Costo,"+
                "fecha=@fecha where IdVentas=@IdVentas", conexion);
            sql.Parameters.AddWithValue("IdEmpleado", comboBox1.Text);
            sql.Parameters.AddWithValue("IdCliente", comboBox2.Text);
            sql.Parameters.AddWithValue("CodigoDeBarras", comboBox3.Text);
            sql.Parameters.AddWithValue("CantidadDeProducto", textBox2.Text);
            sql.Parameters.AddWithValue("Folio", textBox3.Text);
            sql.Parameters.AddWithValue("Costo", textBox4.Text);
            sql.Parameters.AddWithValue("fecha", dateTimePicker1.Value);
            sql.Parameters.AddWithValue("IdVentas", this.IdVentas);

            int Resultado = sql.ExecuteNonQuery();
            if (Resultado > 0)
            {
                MessageBox.Show("La venta ha sido modificada", "Informacion", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();

                button3.Enabled = false;
                groupBox1.Enabled = false;
                groupBox1.Text = "Datos Editables";
                textBox1.Focus();

            }
            else
            {
                MessageBox.Show("No se ha podido modificar la Venta", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
                

            conexion.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            conexion.Open();

            MySqlCommand sql = new MySqlCommand("select * from ventas where IdVentas=@IdVentas",conexion);
            sql.Parameters.AddWithValue("IdVentas",textBox1.Text);

            MySqlDataReader lector = sql.ExecuteReader();

            if (lector.Read())
            {
                comboBox1.Text = lector["IdEmpleado"].ToString();
                comboBox2.Text = lector["IdCliente"].ToString();
                comboBox3.Text = lector["CodigoDeBarras"].ToString();
                textBox2.Text = lector["CantidadDeProducto"].ToString();
                textBox3.Text = lector["Folio"].ToString();
                textBox4.Text = lector["Costo"].ToString();
                dateTimePicker1.Text = lector["fecha"].ToString();
                groupBox1.Enabled = true;
                groupBox1.Text = "Datos Editables, Id de Venta " + textBox1.Text;
                comboBox1.Focus();

                IdVentas = textBox1.Text;
                IdEmpleado = comboBox1.Text;
                IdCliente = comboBox2.Text;
                CodigoDeBarras = comboBox3.Text;
                CantidadDeProducto = textBox2.Text;
                Folio = textBox3.Text;
                Costo = textBox4.Text;
                fecha = dateTimePicker1.Text;
                button3.Enabled = false;                
            }
            else
            {
                MessageBox.Show("No se pudo encontrar la venta", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
                
            lector.Close();
            conexion.Close();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button3.Enabled = checarCambios();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            button3.Enabled = checarCambios();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            button3.Enabled = checarCambios();
        }

        private void dateTimePicker1_StyleChanged(object sender, EventArgs e)
        {
            //button3.Enabled = checarCambios();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            button3.Enabled = checarCambios();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (comboBox4.Text.Length == 0 && e.KeyChar == ' ')
            //    e.KeyChar = (char)0;
            //if (comboBox4.Text.Length > 0 && e.KeyChar == (char)13)
            //    button1.Focus();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            if (comboBox1.Text.Length > 0 && e.KeyChar == (char)13)
                comboBox2.Focus();
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox2.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            if (comboBox2.Text.Length > 0 && e.KeyChar == (char)13)
                comboBox3.Focus();
        }

        private void comboBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox3.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            if (comboBox3.Text.Length > 0 && e.KeyChar == (char)13)
                textBox2.Focus();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox2.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
            if (textBox2.Text.Length > 0 && e.KeyChar == (char)13)
                textBox3.Focus();
            else if (!(e.KeyChar >= '0' && e.KeyChar <= '9')
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
            {
                textBox4.Focus();
            }
            else if (!(e.KeyChar >= 'A' && e.KeyChar <= 'Z') && !(e.KeyChar >= 'a' && e.KeyChar <= 'z') && !(e.KeyChar >= '0' && e.KeyChar <= '9')
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
                dateTimePicker1.Focus();
        }

        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dateTimePicker1.Text.Length > 0 && e.KeyChar == (char)13)
                button1.Focus();
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

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
