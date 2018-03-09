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
    public partial class ModProveedores : Form
    {
        public ModProveedores()
        {
            InitializeComponent();

        }

        private String IdProveedor;
        private String Nombre;
        private String Telefono;
        private String Direccion;
        private String Email;
        private String RFC;



        public bool checarCambios() {

            if (textBox1.Text != IdProveedor || textBox2.Text != Nombre ||
                textBox3.Text != Telefono || textBox4.Text != Direccion || textBox5.Text != Email 
                || textBox6.Text != RFC)
            {


                return true;
            }

            return false;
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

        private void button1_Click(object sender, EventArgs e) { 
            
            MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            conexion.Open();

            MySqlCommand sql = new MySqlCommand("select * from proveedores where IdProveedores=@clave",conexion);
            sql.Parameters.AddWithValue("@clave", textBox1.Text);
            MySqlDataReader lector = sql.ExecuteReader();
            if (lector.Read())
            {


                textBox2.Text = lector["Nombre"].ToString();
                textBox3.Text = lector["Telefono"].ToString();
                textBox4.Text = lector["Direccion"].ToString();
                textBox5.Text = lector["email"].ToString();
                textBox6.Text = lector["RFC"].ToString();
                groupBox1.Enabled = true;
                groupBox1.Text = "Datos Editables ,IdProveedores" + textBox1.Text;
                textBox2.Focus();

                IdProveedor = textBox1.Text;
                Nombre = textBox2.Text;
                Telefono = textBox3.Text;
                Direccion = textBox4.Text;
                Email = textBox5.Text;
                RFC = textBox6.Text;
                button2.Enabled = false;
            }
            else {
                MessageBox.Show("El proveedor no se encontro", "Informacion", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                groupBox1.Enabled = false;
                groupBox1.Text = "Datos editables";
                textBox1.Focus();

            }
            lector.Close();

            conexion.Close();
        


        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            conexion.Open();
            if (email_bien_escrito(textBox5.Text) == true)
            {

                MySqlCommand sql = new MySqlCommand(" update proveedores set Nombre=@nombre,Telefono=@telefono,"
              +"  Direccion=@direccion,Email=@email, RFC=@rfc where IdProveedores=@proveedor", conexion);
            sql.Parameters.AddWithValue("nombre", textBox2.Text);
            sql.Parameters.AddWithValue("telefono", textBox3.Text);
            sql.Parameters.AddWithValue("direccion", textBox4.Text);
            sql.Parameters.AddWithValue("email", textBox5.Text);
            sql.Parameters.AddWithValue("rfc", textBox6.Text);
            sql.Parameters.AddWithValue("proveedor",this.IdProveedor);

            int Resultado = sql.ExecuteNonQuery();

            if (Resultado > 0)
            {

                MessageBox.Show("El proveedor  ha sido modificado","Informacion",MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox1.Focus();

                button2.Enabled = false;
                groupBox1.Enabled = false;
                groupBox1.Text = "Datos editables";

            }
                else
                {
                    MessageBox.Show("No se puede modificar el proveedor","Informacion",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    textBox1.Focus();
                }
                

            }
            else
            {
                MessageBox.Show("El email es incorecto, verifiquelo", "Informacion", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                textBox5.Focus();
            }

            conexion.Close();
        



           

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = checarCambios();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = checarCambios();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = checarCambios();
        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {
            button2.Enabled=checarCambios();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = checarCambios();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = checarCambios();
        }

        private void ModProveedores_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
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
                if (textBox4.Text.Length > 50 && e.KeyChar == (char)50)
                textBox5.Focus();

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (textBox5.Text.Length == 0 && e.KeyChar == ' ')
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
                button2.Focus();
            }
            else if ((e.KeyChar >= 'a' && e.KeyChar <= 'z'))
            {
                MessageBox.Show("Se requieren mayusculas para este campo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.KeyChar = (char)0;
            }
            else if (!(e.KeyChar >= 'A' && e.KeyChar <= 'Z') && !(e.KeyChar >= '0' && e.KeyChar <= '9')
                && e.KeyChar != (char)8)

                e.KeyChar = (char)0;

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
            else if (!(e.KeyChar >= 'A' && e.KeyChar <= 'Z') && !(e.KeyChar >= 'a' &&
                e.KeyChar <= 'z') && !(e.KeyChar >= '0' && e.KeyChar <= '9')
                && e.KeyChar != (char)8)

                e.KeyChar = (char)0;

        }
        public bool checarCambios2()
        {
            if (textBox1.Text != "")
            {
                return true;

            }
            return false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = checarCambios2();
        }
    }
    }

