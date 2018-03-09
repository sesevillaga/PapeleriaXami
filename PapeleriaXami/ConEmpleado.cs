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
    public partial class ConEmpleado : Form
    {
        public ConEmpleado()
        {
            InitializeComponent();
        }

        private void ConEmpleado_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'papeleriaDataSet1.empleado' Puede moverla o quitarla según sea necesario.
            this.empleadoTableAdapter.Fill(this.papeleriaDataSet1.empleado);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
