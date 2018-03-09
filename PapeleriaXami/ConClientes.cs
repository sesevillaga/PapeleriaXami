using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PapeleriaXami
{
    public partial class ConClientes : Form
    {
        public ConClientes()
        {
            InitializeComponent();
        }

        private void ConClientes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'cliente._cliente' Puede moverla o quitarla según sea necesario.
            this.clienteTableAdapter.Fill(this.cliente._cliente);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
      
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            
        }

        private void Cerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
