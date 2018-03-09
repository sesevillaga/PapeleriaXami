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
    public partial class ConsultasCompras : Form
    {
        public ConsultasCompras()
        {
            InitializeComponent();
        }

        private void ConsultasCompras_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'compras._compras' Puede moverla o quitarla según sea necesario.
            this.comprasTableAdapter.Fill(this.compras._compras);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
