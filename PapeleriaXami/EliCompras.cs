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
    public partial class EliCompras : Form
    {
        public EliCompras()
        {
            InitializeComponent();
        }
        public bool checarCambios()
        {
            if (textBox1.Text != "")
            {
                return true;

            }
            return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);

            conexion.Open();
            MySqlCommand sql = new MySqlCommand("select * from compras where IdCompras=@clave",conexion);

            sql.Parameters.AddWithValue("@clave",textBox1.Text);

            MySqlDataReader lector = sql.ExecuteReader();
            if (lector.Read())
            {
                char salto = (char)13;
                DialogResult respuesta = MessageBox.Show("Estas seguro que deseas Eliminar la Compra"
                    + salto + "IdCompras" + lector["IdCompras"].ToString() +
                    salto + "IdEmpleado" + lector["IdEmpleado"].ToString() +
                    salto + "Codigo de barrras" + lector["CodigoDeBarras"].ToString() +
                    salto + "Cantidad de Productos" + lector["CantidadDeProductos"].ToString() +
                    salto + "Costo" + lector["Costo"].ToString() +
                    salto + "Fecha" + lector["Fecha"].ToString(), "Informacion ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                lector.Close();

                if (respuesta == DialogResult.Yes)
                {
                    MySqlCommand sql2 = new MySqlCommand("delete from compras where IdCompras=@Clave1", conexion);
                    sql2.Parameters.AddWithValue("@clave1", textBox1.Text);

                    int r = sql2.ExecuteNonQuery();

                    if (r > 0)
                    {
                        textBox1.Clear();
                        textBox1.Focus();
                        button1.Enabled = false;
                        MessageBox.Show("La Compra ha sido Eliminada", "Informacion", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("La Compra no se pudo Eliminar", "Informacion",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox1.Focus();
                    }
                        



                }
            }
            else {
                lector.Close();
                MessageBox.Show("No se ha encontrado la compra", "Informacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            

            }

            conexion.Close();

          

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
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

        private void EliCompras_Load(object sender, EventArgs e)
        {

        }
    }
}
