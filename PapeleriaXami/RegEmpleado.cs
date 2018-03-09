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
    public partial class RegEmpleado : Form
    {
        public RegEmpleado()
        {
            InitializeComponent();
        }
        public bool checarCambios()
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != ""
                && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "")
            {
                return true;

            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            conexion.Open();

            MySqlCommand valida = new MySqlCommand("select * from empleado where IdEmpleado=@clave",conexion);
            valida.Parameters.AddWithValue("@clave",textBox1.Text);

            MySqlDataReader lector = valida.ExecuteReader();
            if (lector.Read())
            {
                MessageBox.Show("El Empleado que desea registrar ya existe, vuelva a intentarlo");
                lector.Close();
            }
            else
            {
                lector.Close();
                if (email_bien_escrito(textBox8.Text)==true)
                {
                    MySqlCommand comando = new MySqlCommand("insert into empleado values (@IdEmpleado,@Nombre,"
                    + "@ApellidoP,@ApellidoM,@Telefono,@Direccion,@Curp,@Email,@NSS,@TipoDeSangre)", conexion);
                    comando.Parameters.AddWithValue("@IdEmpleado", textBox1.Text);
                    comando.Parameters.AddWithValue("@Nombre", textBox2.Text);
                    comando.Parameters.AddWithValue("@ApellidoP", textBox3.Text);
                    comando.Parameters.AddWithValue("@ApellidoM", textBox4.Text);
                    comando.Parameters.AddWithValue("@Telefono", textBox5.Text);
                    comando.Parameters.AddWithValue("@Direccion", textBox6.Text);
                    comando.Parameters.AddWithValue("@Curp", textBox7.Text);
                    comando.Parameters.AddWithValue("@Email", textBox8.Text);
                    comando.Parameters.AddWithValue("@NSS", textBox9.Text);
                    comando.Parameters.AddWithValue("@TipoDeSangre", comboBox1.Text);

                    int resultado = comando.ExecuteNonQuery();

                    if (resultado > 0)
                    {
                        MessageBox.Show("Se a guardado correctamente", "Informacion",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Text =
                        textBox2.Text =
                        textBox3.Text =
                        textBox4.Text =
                        textBox5.Text =
                        textBox6.Text =
                        textBox7.Text = textBox8.Text = textBox9.Text = "";
                        textBox1.Focus();
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido guardar el empleado", "Informacion",
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
            {
                textBox2.Focus();
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

            else if (!(e.KeyChar >= 'A' && e.KeyChar <= 'Z') && !(e.KeyChar >= 'a' && e.KeyChar <= 'z') && !(e.KeyChar == ' ')
                && e.KeyChar != (char)8)

                e.KeyChar = (char)0;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox3.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
             if (textBox3.Text.Length > 0 && e.KeyChar == (char)13)

                textBox4.Focus();

            else if (!(e.KeyChar >= 'A' && e.KeyChar <= 'Z') && !(e.KeyChar >= 'a' && e.KeyChar <= 'z') && !(e.KeyChar == ' ')
                && e.KeyChar != (char)8)

                e.KeyChar = (char)0;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox4.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
            if (textBox4.Text.Length > 0 && e.KeyChar == (char)13)

                textBox5.Focus();

            else if (!(e.KeyChar >= 'A' && e.KeyChar <= 'Z') && !(e.KeyChar >= 'a' && e.KeyChar <= 'z') && !(e.KeyChar == ' ')
                && e.KeyChar != (char)8)

                e.KeyChar = (char)0;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox5.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
            if (textBox5.Text.Length > 0 && e.KeyChar == (char)13)

                textBox6.Focus();

            else if (!(e.KeyChar >= '0' && e.KeyChar <= '9') 
                && e.KeyChar != (char)8)

                e.KeyChar = (char)0;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox6.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
            if (textBox6.Text.Length > 0 && e.KeyChar == (char)13)

                textBox7.Focus();

            else if (!(e.KeyChar >= 'A' && e.KeyChar <= 'Z') && !(e.KeyChar >= 'a' && e.KeyChar <= 'z') && !(e.KeyChar == ' ')
                && e.KeyChar != (char)8)

                e.KeyChar = (char)0;
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox7.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
                if (textBox7.Text.Length > 0 && e.KeyChar == (char)13)
                textBox8.Focus();
            else if ((e.KeyChar >= 'a' && e.KeyChar <= 'z'))
            {
                MessageBox.Show("Se requieren mayusculas para este campo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.KeyChar = (char)0;
            }
            else
            if (!(e.KeyChar >= 'A' && e.KeyChar <= 'Z') && !(e.KeyChar >= '0' && e.KeyChar <= '9')
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
                textBox9.Focus();
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox9.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
                if (textBox9.Text.Length > 0 && e.KeyChar == (char)13)
                comboBox1.Focus();
            else if((e.KeyChar >= 'a' && e.KeyChar <= 'z')){
                MessageBox.Show("Se requieren mayusculas para este campo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.KeyChar = (char)0;
            }
            else
            if (!(e.KeyChar >= 'A' && e.KeyChar <= 'Z') && !(e.KeyChar >= '0' && e.KeyChar <= '9')
                && e.KeyChar != (char)8)
            {
                e.KeyChar = (char)0;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarCambios();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
           if (comboBox1.Text.Length > 0 && e.KeyChar == (char)13)
            {
                button1.Focus();
            }

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

        private void RegEmpleado_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarCambios();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
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

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarCambios();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarCambios();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarCambios();
        }
    }
}
