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
    public partial class ConProveedores : Form
    {
        public ConProveedores()
        {
            InitializeComponent();
        }

        private void ConProveedores_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'papeleriaDataSet2.proveedores' Puede moverla o quitarla según sea necesario.
            this.proveedoresTableAdapter.Fill(this.papeleriaDataSet2.proveedores);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
