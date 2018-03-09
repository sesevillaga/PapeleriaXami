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
    public partial class ConVentas : Form
    {
        public ConVentas()
        {
            InitializeComponent();
        }

        private void ConVentas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'papeleriaDataSet5.ventas' Puede moverla o quitarla según sea necesario.
            this.ventasTableAdapter.Fill(this.papeleriaDataSet5.ventas);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
