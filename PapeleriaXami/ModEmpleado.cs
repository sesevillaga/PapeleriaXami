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
    public partial class ModEmpleado : Form
    {
        public ModEmpleado()
        {
            InitializeComponent();
        }

        private String IdEmpleado;
        private String Nombre;
        private String ApellidoP;
        private String ApellidoM;
        private String Telefono;
        private String Direccion;
        private String Curp;
        private String Email;
        private String NSS;
        private String TipoDeSangre;

        public bool ChecarCambios()
        {
            if (textBox1.Text != IdEmpleado || textBox2.Text != Nombre || textBox3.Text != ApellidoP || textBox4.Text != ApellidoM ||
                textBox5.Text != Telefono || textBox6.Text != Direccion || textBox7.Text != Curp || textBox8.Text != Email ||
                textBox9.Text != NSS || textBox10.Text != TipoDeSangre)
            {
                return true;
            }
            return false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            conexion.Open();
            MySqlCommand sql = new MySqlCommand("Select * from empleado where IdEmpleado=@clave", conexion);
            sql.Parameters.AddWithValue("@clave", textBox1.Text);

            MySqlDataReader lector = sql.ExecuteReader();

            if (lector.Read())
            {
                textBox2.Text = lector["Nombre"].ToString();
                textBox3.Text = lector["ApellidoP"].ToString();
                textBox4.Text = lector["ApellidoM"].ToString();
                textBox5.Text = lector["Telefono"].ToString();
                textBox6.Text = lector["Direccion"].ToString();
                textBox7.Text = lector["Curp"].ToString();
                textBox8.Text = lector["Email"].ToString();
                textBox9.Text = lector["NSS"].ToString();
                textBox10.Text = lector["TipoDeSangre"].ToString();

                groupBox1.Enabled = true;
                groupBox1.Text = "Datos Editables, IdEmpleado" + textBox1.Text;
                button3.Enabled = false;
                textBox2.Focus();

                IdEmpleado = textBox1.Text;
                Nombre = textBox2.Text;
                ApellidoP = textBox3.Text;
                ApellidoM = textBox4.Text;
                Telefono = textBox5.Text;
                Direccion = textBox6.Text;
                Curp = textBox7.Text;
                Email = textBox8.Text;
                NSS = textBox9.Text;
                TipoDeSangre = textBox10.Text;


            }
            else
            {
                MessageBox.Show("No se ha podido encontrar el empleado para modificar", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                groupBox1.Enabled = false;
                groupBox1.Text = "Datos Editables";
                textBox1.Focus();
            }

            lector.Close();
            conexion.Close();
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
            else if (!(e.KeyChar >= 'A' && e.KeyChar <= 'Z') && !(e.KeyChar >= 'a' && e.KeyChar <= 'z') && !(e.KeyChar == ' ')
           && e.KeyChar != (char)8)
            {
                e.KeyChar = (char)0;

            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            button3.Enabled = ChecarCambios();
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
                textBox5.Focus();
            else if (!(e.KeyChar >= 'A' && e.KeyChar <= 'Z') && !(e.KeyChar >= 'a' && e.KeyChar <= 'z') && !(e.KeyChar == ' ')
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
                if (textBox5.Text.Length > 0 && e.KeyChar == (char)13)
                textBox6.Focus();
            else if (!(e.KeyChar >= '0' && e.KeyChar <= '9')
          && e.KeyChar != (char)8)
            {
                e.KeyChar = (char)0;
            }
        }
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (textBox6.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
                 if (textBox6.Text.Length > 50 && e.KeyChar == (char)50)
                textBox7.Focus();
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
                textBox9.Focus();
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox9.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
                if (textBox9.Text.Length > 0 && e.KeyChar == (char)13)
                textBox10.Focus();
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

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox10.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
                if (textBox10.Text.Length > 0 && e.KeyChar == (char)13)
                button3.Focus();
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
        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            conexion.Open();
            if (email_bien_escrito(textBox8.Text)==true)
            {
                MySqlCommand sql = new MySqlCommand("update empleado set Nombre=@nombre,ApellidoP=@apellidop,ApellidoM=@apellidom,"
                + "Telefono=@telefono,Direccion=@direccion,Curp=@curp,Email=@email,NSS=@nss,TipoDeSangre=@tipodesangre", conexion);

                sql.Parameters.AddWithValue("nombre", textBox2.Text);
                sql.Parameters.AddWithValue("apellidop", textBox3.Text);
                sql.Parameters.AddWithValue("apellidom", textBox4.Text);
                sql.Parameters.AddWithValue("telefono", textBox5.Text);
                sql.Parameters.AddWithValue("direccion", textBox6.Text);
                sql.Parameters.AddWithValue("curp", textBox7.Text);
                sql.Parameters.AddWithValue("email", textBox8.Text);
                sql.Parameters.AddWithValue("nss", textBox9.Text);
                sql.Parameters.AddWithValue("tipodesangre", textBox10.Text);

                int Resultado = sql.ExecuteNonQuery();

                if (Resultado > 0)
                {
                    MessageBox.Show("El Empleado ha sido modificado", "Informacion", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    textBox9.Clear();
                    groupBox1.Enabled = false;
                    textBox1.Focus();

                    button3.Enabled = false;
                    groupBox1.Enabled = false;
                    groupBox1.Text = "Datos Editables";

                }
                else
                {
                    MessageBox.Show("No se ha podido modificar", "Informacion", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
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

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            button3.Enabled = ChecarCambios();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            button3.Enabled = ChecarCambios();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void ModEmpleado_Load(object sender, EventArgs e)
        {

        }
        public bool checarCambios2()
        {
            if (textBox1.Text != "")
            {
                return true;

            }
            return false;
        }

        private void textBox10_TextChanged_1(object sender, EventArgs e)
        {
            button3.Enabled = ChecarCambios();
        }

        private void textBox10_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (textBox10.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
               if (textBox10.Text.Length > 0 && e.KeyChar == (char)13)
                button3.Focus();
            else if (!(e.KeyChar == 'A') && !(e.KeyChar == 'B') && !(e.KeyChar == 'O')  && !(e.KeyChar == 'a')   && !(e.KeyChar == 'b') && !(e.KeyChar == 'o') && !(e.KeyChar == '-') && !(e.KeyChar == '+')
           && (e.KeyChar != (char)8))
            {
                e.KeyChar = (char)0;

            }
        }

        private void button3_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarCambios2();
        }
    }
}
