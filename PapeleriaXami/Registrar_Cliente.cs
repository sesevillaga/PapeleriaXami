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
    public partial class Registrar_Cliente : Form
    {
        public Registrar_Cliente()
        {
            InitializeComponent();
        }
        public bool checarCambios()
        {
            if (textBox1.Text !=""&& textBox2.Text != ""&& textBox3.Text != "" && textBox4.Text !=""
                && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" )
            {
                return true;

            }
            return false;
        }
        private void Guardar_Click(object sender, EventArgs e)
        {

            MySqlConnection Conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            Conexion.Open();
            MySqlCommand Valida = new MySqlCommand("select * from cliente where IdCliente=@clave ", Conexion);
            Valida.Parameters.AddWithValue("@clave",textBox1.Text);
            MySqlDataReader lector = Valida.ExecuteReader();
            if (lector.Read())
            {
                MessageBox.Show("El IdCliente que escribio ya existe vuelva a intentarlo");
                lector.Close();
            }
            else
            {
                lector.Close();
                if (email_bien_escrito(textBox7.Text) == true)
                {
                    if (rfc_bien_escrito(textBox6.Text) == true)
                    {

                    
                    MySqlCommand Comando = new MySqlCommand("insert into cliente values (@IdCliente,@Nombre,@ApellidoP,@ApellidoM,"
                    + "@Direccion,@Fecha,@RFC,@Email)", Conexion);
                    Comando.Parameters.AddWithValue("@Idcliente", textBox1.Text);
                    Comando.Parameters.AddWithValue("@Nombre", textBox2.Text);
                    Comando.Parameters.AddWithValue("@ApellidoP", textBox3.Text);
                    Comando.Parameters.AddWithValue("@ApellidoM", textBox4.Text);
                    Comando.Parameters.AddWithValue("@Direccion", textBox5.Text);
                    Comando.Parameters.AddWithValue("@Fecha", dateTimePicker1.Value);
                    Comando.Parameters.AddWithValue("@RFC", textBox6.Text);
                    Comando.Parameters.AddWithValue("@Email", textBox7.Text);

                    int Resultado = Comando.ExecuteNonQuery();

                    if (Resultado > 0)
                    {
                        MessageBox.Show("Se a guardado correctamente", "Informacion",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                        textBox7.Clear();
                        textBox1.Focus();

                    }
                    else
                    {
                        MessageBox.Show("No se ha podido guardar el cliente", "Informacion",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox1.Focus();
                    }
                }
                else
                {
                        MessageBox.Show("Esta mal escrito el RFC", "Advertencia",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                           textBox6.Focus();

                    }
                        
                }
                else
                {
                    MessageBox.Show("Esta mal escrito el email", "Advertencia",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox7.Focus();
                }
                

                

            }

            Conexion.Close();
        }

        private void Cerrar_Click(object sender, EventArgs e)
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
            else if (!(e.KeyChar >= '0' && e.KeyChar <= '9')
                && e.KeyChar != (char)8)

                e.KeyChar = (char)0;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (textBox2.Text.Length==0 && e.KeyChar ==' ')
                e.KeyChar=(char)0;
            else
            if(textBox2.Text.Length>0 && e.KeyChar==(char)13)
            
                textBox3.Focus();
            
            else if(!(e.KeyChar >= 'A' && e.KeyChar <= 'Z')&&!(e.KeyChar>= 'a' && e.KeyChar<='z') &&  !(e.KeyChar == ' ')
                && e.KeyChar != (char)8)
            
                e.KeyChar = (char)0;
            
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox3.Text.Length==0 && e.KeyChar == ' ')
                e.KeyChar=(char)0;
            else
            if(textBox3.Text.Length>0 && e.KeyChar==(char)13)
            {
                textBox4.Focus();
            }
           else if (!(e.KeyChar >= 'A' && e.KeyChar <= 'Z')&&!(e.KeyChar >= 'a' && e.KeyChar <= 'z') && !(e.KeyChar == ' ')
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
            if (textBox4.Text.Length>0 && e.KeyChar==(char)13)
            {
                textBox5.Focus();
            }
           else if (!(e.KeyChar >= 'A' && e.KeyChar <= 'Z')&&!(e.KeyChar >= 'a' && e.KeyChar <= 'z') && !(e.KeyChar == ' ')
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
            if(textBox5.Text.Length>0 && e.KeyChar == (char)13)
            {
                textBox6.Focus();
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox6.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
            if(textBox6.Text.Length>0 && e.KeyChar == (char)13)
            {
                textBox7.Focus();
            }
            else if((e.KeyChar >= 'a' && e.KeyChar <= 'z')){
                MessageBox.Show("Se requieren mayusculas para este campo","Informacion",MessageBoxButtons.OK,MessageBoxIcon.Information);
                e.KeyChar = (char)0;
            }
            else if (!(e.KeyChar >= 'A' && e.KeyChar <= 'Z')&& !(e.KeyChar >= '0' && e.KeyChar <= '9')
               && e.KeyChar != (char)8)
            {
                e.KeyChar = (char)0;
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
        private Boolean rfc_bien_escrito(String rfc)
        {
            String expresion;
            expresion = "^([A-Z,Ñ\x26]{3,4}([0-9]{2})(0[1-9]|1[0-2])(0[1-9]|1[0-9]|2[0-9]|3[0-1]))([A-Z|\\d]{3})$";
            if (Regex.IsMatch(rfc, expresion))
            {
                if (Regex.Replace(rfc, expresion, String.Empty).Length == 0)
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


        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox7.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else if (textBox7.Text.Length > 0 && e.KeyChar == (char)13)
            {
                Guardar.Focus();
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Cerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Registrar_Cliente_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dateTimePicker1.Text.Length == 0 && e.KeyChar == ' ')
                e.KeyChar = (char)0;
            else
          if (dateTimePicker1.Text.Length > 0 && e.KeyChar == (char)13)
            {
                textBox6.Focus();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            Guardar.Enabled = checarCambios();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Guardar.Enabled = checarCambios();
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            Guardar.Enabled = checarCambios();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Guardar.Enabled = checarCambios();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Guardar.Enabled = checarCambios();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            Guardar.Enabled = checarCambios();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            Guardar.Enabled = checarCambios();
        }

        private void dateTimePicker1_TabIndexChanged(object sender, EventArgs e)
        {
            Guardar.Enabled = checarCambios();
        }
    }
}
