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
using System.Text.RegularExpressions;

namespace PapeleriaXami
{
    public partial class ModCliente : Form
    {
        public ModCliente()
        {
            InitializeComponent();
        }
        private String IdCliente;
        private String Nombre;
        private String ApellidoP;
        private String ApellidoM;
        private String Direccion;
        private String Fecha;
        private String RFC;
        private String Email;

        public bool ChecarCambios()
        {
            if (textBox1.Text!=IdCliente || 
                textBox2.Text != Nombre || 
                textBox3.Text != ApellidoP || 
                textBox4.Text != ApellidoM ||
                    textBox5.Text != Direccion || 
                    dateTimePicker1.Text != Fecha || 
                    textBox7.Text != RFC ||
                    textBox8.Text != Email)
            {
                return true;

            }
            return false;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            conexion.Open();
            MySqlCommand sql = new MySqlCommand("select * from cliente where IdCliente=@clave", conexion);
            sql.Parameters.AddWithValue("@clave",textBox1.Text);

            MySqlDataReader lector = sql.ExecuteReader();
            if (lector.Read())
            {
                textBox2.Text = lector["Nombre"].ToString();
                textBox3.Text = lector["ApellidoP"].ToString();
                textBox4.Text = lector["ApellidoM"].ToString();
                textBox5.Text = lector["Direccion"].ToString();
                dateTimePicker1.Text = lector["Fecha"].ToString();
                textBox7.Text = lector["RFC"].ToString();
                textBox8.Text = lector["Email"].ToString();

                groupBox1.Enabled = true;
                groupBox1.Text = "Datos Editables, IdClientes" + textBox1.Text;
                textBox2.Focus();

                IdCliente = textBox1.Text;
                Nombre = textBox2.Text;
                ApellidoP = textBox3.Text;
                ApellidoM = textBox4.Text;
                Direccion = textBox5.Text;
                Fecha = dateTimePicker1.Text;
                RFC = textBox7.Text;
                Email = textBox8.Text;

                button3.Enabled = false;


            }
            else
            {
                MessageBox.Show("No se ha podido encontrar el cliente para modificar", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox7.Clear();
                textBox8.Clear();
                groupBox1.Enabled = false;
                groupBox1.Text = "Datos Editables";
                textBox1.Focus();
            }
                

            lector.Close();

            conexion.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            conexion.Open();
            if (email_bien_escrito(textBox8.Text)==true)
            {
                MySqlCommand sql = new MySqlCommand("update cliente set Nombre=@nombre,ApellidoP=@apellidop,ApellidoM=@apellidom,Direccion=@direccion,"
               + "Fecha=@fecha,RFC=@rfc,Email=@email where IdCliente=@idcliente", conexion);

                sql.Parameters.AddWithValue("nombre", textBox2.Text);
                sql.Parameters.AddWithValue("apellidop", textBox3.Text);
                sql.Parameters.AddWithValue("apellidom", textBox4.Text);
                sql.Parameters.AddWithValue("direccion", textBox5.Text);
                sql.Parameters.AddWithValue("fecha", dateTimePicker1.Value);
                sql.Parameters.AddWithValue("rfc", textBox7.Text);
                sql.Parameters.AddWithValue("email", textBox8.Text);
                sql.Parameters.AddWithValue("idcliente", this.IdCliente);

                int Resultado = sql.ExecuteNonQuery();

                if (Resultado > 0)
                {
                    MessageBox.Show("El cliente a sido modificado", "Informacion",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    textBox1.Focus();

                    button3.Enabled = false;
                    groupBox1.Enabled = false;
                    groupBox1.Text = "Datos Editables";

                }
                else
                {
                    MessageBox.Show("No se ha podido modificar el cliente", "Informacion",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                }
                    
            }
            else
            {
                MessageBox.Show("Esta mal escrito el email", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox8.Focus();
            }



            conexion.Close();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button3.Enabled = ChecarCambios();

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            button3.Enabled = ChecarCambios();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            button3.Enabled = ChecarCambios();

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            button3.Enabled = ChecarCambios();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            button3.Enabled = ChecarCambios();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            button3.Enabled = ChecarCambios();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            button3.Enabled = ChecarCambios();

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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox2.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
                if (textBox2.Text.Length > 0 && e.KeyChar == (char)13)
                textBox3.Focus();
            else if (!(e.KeyChar >= 'a' && e.KeyChar <= 'z')
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
                textBox4.Focus();
            else if (!(e.KeyChar >= 'a' && e.KeyChar <= 'z')&&(e.KeyChar >= 'a' && e.KeyChar <= 'z')
             && e.KeyChar != (char)8)
            {
                e.KeyChar = (char)0;

            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox4.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
                if (textBox4.Text.Length > 0 && e.KeyChar == (char)13)
                dateTimePicker1.Focus();
            else if (!(e.KeyChar >= 'a' && e.KeyChar <= 'z')&&(e.KeyChar >= 'a' && e.KeyChar <= 'z')
             && e.KeyChar != (char)8)
            {
                e.KeyChar = (char)0;
            }
        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox5.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
                if (textBox5.Text.Length > 50 && e.KeyChar == (char)50)
                textBox7.Focus();
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox7.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
            if (textBox7.Text.Length > 0 && e.KeyChar == (char)13)
            {
                textBox8.Focus();
            }
            else if ((e.KeyChar >= 'a' && e.KeyChar <= 'z'))
            {
                MessageBox.Show("Se requieren mayusculas para este campo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.KeyChar = (char)0;
            }
            else if (!(e.KeyChar >= 'A' && e.KeyChar <= 'Z') && !(e.KeyChar >= '0' && e.KeyChar <= '9')
               && e.KeyChar != (char)8)
            {
                e.KeyChar = (char)0;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox8.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
                if (textBox8.Text.Length > 0 && e.KeyChar == (char)13)
                textBox8.Focus();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dateTimePicker1.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
              if (dateTimePicker1.Text.Length > 0 && e.KeyChar == (char)13)
                textBox7.Focus();
        }
        public bool checarCambios2()
        {
            if (textBox1.Text != "")
            {
                return true;

            }
            return false;
        }
        private void ModCliente_Load(object sender, EventArgs e)
        {

        }
        private Boolean email_bien_escrito(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarCambios2();
        }
    }
}
