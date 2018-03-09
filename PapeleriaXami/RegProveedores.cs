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
    public partial class RegProveedores : Form
    {
        public RegProveedores()
        {
            InitializeComponent();
        }

        public bool checarCambios()
        {
            if (textBox1.Text==""||textBox2.Text==""||textBox3.Text==""||textBox4.Text==""||textBox5.Text==""
                ||textBox6.Text=="")
            {
                return false;
            }
            return true;
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


        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            conexion.Open();

            MySqlCommand sql = new MySqlCommand("select * from proveedores where IdProveedores=@clave",conexion);
            sql.Parameters.AddWithValue("@clave", textBox1.Text);

            MySqlDataReader lector = sql.ExecuteReader();

            if (lector.Read())
            {
                MessageBox.Show("El Proveedor que registro ya existe,"
                    +" modifiquelo y vuelva ha intentarlo");
                textBox1.Focus();
                lector.Close();
                }
            else
            {
                lector.Close();
                if (email_bien_escrito(textBox5.Text)==true)
                {

                MySqlCommand comando = new MySqlCommand("insert into proveedores values (@IdProveedores,@Nombre,@Telefono,"
                    +"@Direccion,@Email,@RFC)",conexion);

                comando.Parameters.AddWithValue("@IdProveedores", textBox1.Text);
                comando.Parameters.AddWithValue("@Nombre",textBox2.Text);
                comando.Parameters.AddWithValue("@Telefono",textBox3.Text);
                comando.Parameters.AddWithValue("@Direccion",textBox4.Text);
                comando.Parameters.AddWithValue("@Email",textBox5.Text);
                comando.Parameters.AddWithValue("@RFC",textBox6.Text);

                int Resultado = comando.ExecuteNonQuery();
                if (Resultado>0)
                    { 
                    MessageBox.Show("Se registro el proveedor correctamente",
                       "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        textBox1.Text =
                        textBox2.Text =
                        textBox3.Text =
                        textBox4.Text = 
                        textBox5.Text =
                        textBox6.Text = "";
                        textBox1.Focus();

                    }
                    else
                    {
                        MessageBox.Show("No se ha Podido Guardar Correctamente","Informacion",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        textBox1.Focus();
                    }
                
                    

                }
                else
                {
                    MessageBox.Show("El email es incorecto, verifiquelo", "Informacion", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    textBox5.Focus();
                }
            }

            conexion.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
             if (textBox1.Text.Length > 0 && e.KeyChar == (char)13)
            {
                textBox2.Focus();
            }
            else if (!(e.KeyChar >= 'A' && e.KeyChar <= 'Z') && !(e.KeyChar >= 'a' &&
                e.KeyChar <= 'z') && !(e.KeyChar >= '0' && e.KeyChar <= '9')
                && e.KeyChar != (char)8)

                e.KeyChar = (char)0;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarCambios();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox2.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
             if (textBox2.Text.Length > 0 && e.KeyChar == (char)13)
            {
                textBox3.Focus();
            }
            else if (!(e.KeyChar >= 'A' && e.KeyChar <= 'Z') && !(e.KeyChar >= 'a' &&
                e.KeyChar <= 'z') && e.KeyChar != (char)8 && e.KeyChar != (char)32)

                e.KeyChar = (char)0;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarCambios();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox3.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
                      if (textBox3.Text.Length > 0 && e.KeyChar == (char)13)
                textBox4.Focus();
            else if (!(e.KeyChar >= '0' && e.KeyChar <= '9') && e.KeyChar != (char)8)
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
            {
                textBox5.Focus();
            }
            else if (!(e.KeyChar >= 'A' && e.KeyChar <= 'Z') && !(e.KeyChar >= 'a' &&
                e.KeyChar <= 'z') && !(e.KeyChar >= '0' && e.KeyChar <= '9')
                && e.KeyChar != (char)8 && e.KeyChar!=(char)32)

                e.KeyChar = (char)0;

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox4.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
                if (textBox5.Text.Length > 0 && e.KeyChar == (char)13)
                textBox6.Focus();
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox6.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
             if (textBox6.Text.Length > 0 && e.KeyChar == (char)13)
            {
                button1.Focus();
            }
            else if ((e.KeyChar >= 'a' && e.KeyChar <= 'z'))
            {
                MessageBox.Show("Se requieren mayusculas para este campo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.KeyChar = (char)0;
            }
            else if(!(e.KeyChar >= 'A' && e.KeyChar <= 'Z') && !(e.KeyChar >= '0' && e.KeyChar <= '9')
                && e.KeyChar != (char)8)

                e.KeyChar = (char)0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegProveedores_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarCambios();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarCambios();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarCambios();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarCambios();
        }
    }
}
