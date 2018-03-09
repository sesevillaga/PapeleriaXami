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
    public partial class EliProveedores : Form
    {
        public EliProveedores()
        {
            InitializeComponent();
        }

        public bool checarcambio()
        {
            if (textBox1.Text=="")
            {
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            conexion.Open();
            MySqlCommand sql = new MySqlCommand("select * from proveedores where IdProveedores=@clave",conexion);
            sql.Parameters.AddWithValue("@clave",textBox1.Text);

            MySqlDataReader lector = sql.ExecuteReader();

            if (lector.Read())
            {
                char salto = (char)10;

                DialogResult respuesta = MessageBox.Show("Esta seguro que deseas eliminar al Proveedor"
                    +salto+"Nombre"+lector["Nombre"].ToString()+
                    salto+"Telefono"+lector["Telefono"].ToString()+
                    salto+"Direccion"+lector["Direccion"].ToString()+
                    salto+"Email"+lector["Email"].ToString()+
                    salto+"RFC"+lector["RFC"].ToString(),"Informacion", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                lector.Close();

                if (respuesta == DialogResult.Yes)
                {
                    MySqlCommand sql2 = new MySqlCommand("delete from proveedores where IdProveedores=@clave", conexion);
                    sql2.Parameters.AddWithValue("@clave",textBox1.Text);

                    int r = sql2.ExecuteNonQuery();

                    if (r > 0)
                    {
                        textBox1.Clear();
                        textBox1.Focus();
                        MessageBox.Show("El Proveedor ha sido Eliminado", "Informacion", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else {
                        MessageBox.Show("No se pudo Eliminar el Proveedor", "Informacion",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox1.Focus();
                    }

                }
                else
                textBox1.Focus();

            }
            else
            {
                lector.Close();
                MessageBox.Show("No se ha podido en contrar el Proveedor","Informacion",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                textBox1.Focus();
            }
            
            conexion.Close();
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
                button1.Focus();
            else if (!(e.KeyChar >= '0' && e.KeyChar <= '9') && e.KeyChar != (char)8 &&
                !(e.KeyChar >= 'a' && e.KeyChar <= 'z') && !(e.KeyChar >= 'A' && e.KeyChar <= 'Z'))
            {
                e.KeyChar = (char)0;
            }
        }

        private void EliProveedores_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarcambio();
        }
    }
}
