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
    public partial class eliVentas : Form
    {
        List<String> nombresVentas;
        public eliVentas()
        {
            InitializeComponent();
        }

        private void eliVentas_Load(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Text = "El Id de Venta a eliminar " + textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            conexion.Open();
            MySqlCommand sql = new MySqlCommand("select * from ventas where IdVentas=@IdVentas",conexion);
            sql.Parameters.AddWithValue("IdVentas", textBox1.Text);
            MySqlDataReader lector = sql.ExecuteReader();

            if (lector.Read())
            {
                char salto = (char)13;
                DialogResult respuesta = MessageBox.Show("Estas seguro de eliminar la venta "+salto+"Id de Venta "+lector["IdVentas"].ToString() + salto + "Id de Empleado " + lector["IdEmpleado"].ToString() + salto + "Id de Cliente " + lector["IdCliente"].ToString() + salto + "Codigo de Barras " + lector["CodigoDeBarras"].ToString() + salto + "Cantidad " + lector["CantidadDeProducto"].ToString(), "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                lector.Close();

                if (respuesta == DialogResult.Yes)
                {
                    MySqlCommand sql2 = new MySqlCommand("delete from ventas where IdVentas=@IdVentas", conexion);
                    sql2.Parameters.AddWithValue("IdVentas", textBox1.Text);

                    int r = sql2.ExecuteNonQuery();

                    if (r > 0)
                    {
                        label2.Text = "";
                        textBox1.Clear();
                        textBox1.Focus();
                        MessageBox.Show("La venta a sido eliminada", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("La venta no se pudo eliminar", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox1.Focus();
                    }
                       

                }
            }
            else
            {
                lector.Close();
                MessageBox.Show("No se ha encontrado la venta", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }





            conexion.Close();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
