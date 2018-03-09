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
    public partial class BusVentas : Form
    {
        List<String> nombresVentas;
        public BusVentas()
        {
            InitializeComponent();
        }
        public bool checarCambios()
        {
            if (textBox8.Text != "")
            {
                return true;

            }
            return false;
        }

        private void BusVentas_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            conexion.Open();
            MySqlCommand sql = new MySqlCommand("select * from ventas where IdVentas=@IdVentas",conexion);
            sql.Parameters.AddWithValue("IdVentas",textBox8.Text);


            MySqlDataReader lector = sql.ExecuteReader();
            if (lector.Read())
            {
                groupBox1.Text = "Datos de la Venta " + textBox1.Text;
                groupBox1.Enabled = true;
                textBox2.Text = lector["IdEmpleado"].ToString();
                textBox3.Text = lector["IdCliente"].ToString();
                textBox4.Text = lector["CodigoDeBarras"].ToString();
                textBox5.Text = lector["CantidadDeProducto"].ToString();
                textBox6.Text = lector["Folio"].ToString();
                textBox7.Text = "$ " + lector["Costo"].ToString();
                textBox1.Text = lector["fecha"].ToString();
                textBox8.Focus();
            }
            else {

                MessageBox.Show("No se pudo encontrar la venta", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox1.Clear();
                textBox8.Focus();
            }

            lector.Close();



            conexion.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarCambios();
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (textBox8.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
            if (textBox8.Text.Length > 0 && e.KeyChar == (char)13)
            {
                button1.Focus();
            }
            else if (!(e.KeyChar >= 'A' && e.KeyChar <= 'Z') && !(e.KeyChar >= 'a' && e.KeyChar <= 'z') && !(e.KeyChar >= '0' && e.KeyChar <= '9')
                && e.KeyChar != (char)8)

                e.KeyChar = (char)0;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarCambios();
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
