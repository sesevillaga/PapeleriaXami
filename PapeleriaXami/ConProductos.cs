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
    public partial class ConProductos : Form
    {
        public ConProductos()
        {
            InitializeComponent();
        }

        private void ConProductos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'papeleriaDataSet3.productos' Puede moverla o quitarla según sea necesario.
            this.productosTableAdapter.Fill(this.papeleriaDataSet3.productos);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
