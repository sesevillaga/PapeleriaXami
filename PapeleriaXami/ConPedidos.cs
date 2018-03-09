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
    public partial class ConPedidos : Form
    {
        public ConPedidos()
        {
            InitializeComponent();
        }

        private void ConPedidos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'papeleriaDataSet4.pedido' Puede moverla o quitarla según sea necesario.
            this.pedidoTableAdapter.Fill(this.papeleriaDataSet4.pedido);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
