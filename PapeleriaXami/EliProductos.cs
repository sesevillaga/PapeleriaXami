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
    public partial class EliProductos : Form
    {
        public EliProductos()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            conexion.Open();

            MySqlCommand sql = new MySqlCommand("select * from productos where CodigoDeBarras=@Clave",conexion);
            sql.Parameters.AddWithValue("@Clave",textBox1.Text);

            MySqlDataReader lector = sql.ExecuteReader();

            if (lector.Read())
            {
                char salto = (char)13;

                DialogResult respuesta = MessageBox.Show("Estas seguro que desea eliminar el producto "+
                    salto+"Codigo De Barras "+lector["CodigoDeBarras"].ToString()+
                    salto+"Id Proveedor "+lector["IdProveedores"].ToString()+
                    salto+"Nombre "+lector["Nombre"].ToString()+
                    salto+"Marca "+lector["Marca"].ToString(),"Informacion",MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                lector.Close();

                if (respuesta==DialogResult.Yes)
                {
                    MySqlCommand sql2 = new MySqlCommand("delete from productos where CodigoDeBarras=@Clave",conexion);
                    sql2.Parameters.AddWithValue("@Clave",textBox1.Text);

                    int r = sql2.ExecuteNonQuery();

                    if (r > 0)
                    {
                        textBox1.Clear();
                        textBox1.Focus();
                        MessageBox.Show("El producto ha sido eliminado","Informacion",MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("EL producto no se pudo eliminar", "Informacion", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        textBox1.Focus();
                    }
                        

                }
                else
                    textBox1.Focus();
            }
            else
            {
                lector.Close();
                MessageBox.Show("No se ha encontrado el producto","Informacion",MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                textBox1.Focus();
            }


            conexion.Close();
        }
        public bool checarCambios()
        {
            if (textBox1.Text != "")
            {
                return true;

            }
            return false;
        }

        private void EliProductos_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarCambios();
        }
    }
}
