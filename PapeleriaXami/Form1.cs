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

namespace PapeleriaXami
{
    public partial class VentanaPrincipal : Form
    {
        public VentanaPrincipal()
        {
            InitializeComponent();
        }

        public bool ClientesVacios()
        {

            MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            conexion.Open();

            MySqlCommand consulta = new MySqlCommand("select * from cliente",conexion);
            bool r=false;
            MySqlDataReader lector = consulta.ExecuteReader();
            if (!lector.Read())
            {
                r = true;
            }
            conexion.Close();
            return r;
        }

        public bool ComprasVacia()
        {
            MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            conexion.Open();

            MySqlCommand consulta = new MySqlCommand("select * from compras",conexion);
            bool r = false;
            MySqlDataReader lector = consulta.ExecuteReader();
            if (!lector.Read())
            {
                r = true;
            }
            conexion.Close();
            return r;
        }

        public bool EmpleadoVacio()
        {
            MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            conexion.Open();

            MySqlCommand consulta = new MySqlCommand("select * from empleado",conexion);
            bool r = false;
            MySqlDataReader lector = consulta.ExecuteReader();
            if (!lector.Read())
            {
                r = true;
            }

            conexion.Close();
            return r;
        }

        public bool proveedoresVacia()
        {
            MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            conexion.Open();

            MySqlCommand consulta = new MySqlCommand("select * from proveedores",conexion);
            bool r = false;
            MySqlDataReader lector = consulta.ExecuteReader();
            if (!lector.Read())
            {
                r=true;
            }
            conexion.Close();
            return r;
        }

        public bool ProductosVacio()
        {
            MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            conexion.Open();
            MySqlCommand consulta = new MySqlCommand("select * from productos",conexion);
            MySqlDataReader lector = consulta.ExecuteReader();
            bool r = false;
            if (!lector.Read())
            {
                r = true;
            }
            conexion.Close();
            return r;
        }

        public bool PedidosVacio()
        {
            MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            conexion.Open();
            MySqlCommand consulta = new MySqlCommand("select * from pedido",conexion);
            MySqlDataReader lector = consulta.ExecuteReader();
            bool r = false;
            if (!lector.Read())
            {
                r = true;
            }

            conexion.Close();
            return r;
        }

        public bool VentasVacia()
        {
            MySqlConnection conexion = new MySqlConnection(Properties.Settings.Default.CadenaPapeleriaXami);
            conexion.Open();
            MySqlCommand consulta = new MySqlCommand("select * from ventas",conexion);
            MySqlDataReader lector = consulta.ExecuteReader();
            bool r = false;

            if (!lector.Read())
            {
                r = true;
            }

            conexion.Close();
            return r;
        }

        private void VentanaPrincipal_Load(object sender, EventArgs e)
        {
 
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            new Registrar_Cliente().Show();
        }

        private void generalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ClientesVacios())
            {
                MessageBox.Show("No hay clientes para consultar","Informacion",MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }else
            new ConClientes().Show();
        }

        private void busquedaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new BuscarCliente().Show();
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ProductosVacio())
            {
                MessageBox.Show("No hay productos registrados para poder registrar una compra,"+
                    " favor de registrar productos","Informacion",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else if (EmpleadoVacio())
            {
                MessageBox.Show("No hay empleados registrados, favor de registrar un empleado","Informacion",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
                new RegistrarCompras().Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void consultarToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void generalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new ConsultasCompras().Show();
        }

        private void busquedaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new BuscarCompras().Show();

        }

        private void regristrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new RegEmpleado().Show();
        }

        private void generalToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (EmpleadoVacio())
            {
                MessageBox.Show("No existe empleados para la consulta","Informacion",MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }else
            new ConEmpleado().Show();
        }

        private void busquedaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (EmpleadoVacio())
            {
                MessageBox.Show("No existe empleados para la busqueda","Informacion",MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }else
            new BusEmpleado().Show();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ClientesVacios())
            {
                MessageBox.Show("No hay clientes para Modificar","Informacion",MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }else
            new ModCliente().Show();

        }

        private void registrarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            new RegProveedores().Show();
        }

        private void generalToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (proveedoresVacia())
            {
                MessageBox.Show("No hay proveedores para consulta","Informacion",MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }else
            new ConProveedores().Show();
        }

        private void busquedaToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (proveedoresVacia())
            {
                MessageBox.Show("No hay proveedores para busqueda", "Informacion", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
                new BuscarProveedores().Show();
        }

        private void modificarToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (proveedoresVacia())
            {
                MessageBox.Show("No hay proveedores para Modificar", "Informacion", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
                new ModProveedores().Show();
        }

        private void registrarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (proveedoresVacia())
            {
                MessageBox.Show("No hay proveedores para poder registrar un producto");
            }else
            new RegProductos().Show();
        }

        private void generalToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (ProductosVacio())
            {
                MessageBox.Show("No hay productos para consultar","Informacion",MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }else
            new ConProductos().Show();
        }

        private void busquedaToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (ProductosVacio())
            {
                MessageBox.Show("No hay productos para buscar","Informacion",MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }else
            new BusProductos().Show();
        }

        private void eliminarToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (ProductosVacio())
            {
                MessageBox.Show("No hay productos para eliminar","Informacion",MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }else
            new EliProductos().Show();
        }

        private void modificarToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (ProductosVacio())
            {
                MessageBox.Show("No hay productos para modificar","Informacion",MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }else
            new ModProductos().Show();
        }

        private void eliminarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (EmpleadoVacio())
            {
                MessageBox.Show("No hay empleados para eliminar","Informacion", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            new Eliminar_Empleado().Show();
        }

        private void modificarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (EmpleadoVacio())
            {
                MessageBox.Show("No hay empleados para modificar","Informacion",MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }else
            new ModEmpleado().Show();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ClientesVacios())
            {
                MessageBox.Show("No hay clientes para eliminar");
            }else
            new Eliminar_Clientes().Show();
        }

        private void registrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ProductosVacio() || EmpleadoVacio())
            {
                if (ProductosVacio())
                {
                    MessageBox.Show("No hay productos para poder registrar un pedido","Informacion",
                        MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else if (EmpleadoVacio())
                {
                    MessageBox.Show("No hay empleados para poder registrar un pedido","Informacion",
                        MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else if (ProductosVacio() && EmpleadoVacio())
                {
                    MessageBox.Show("No hay empleados ni productos para poder registrar un producto",
                        "Informacion",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }else
            new RegPedido().Show();
        }

        private void eliminarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ComprasVacia())
            {
                MessageBox.Show("No hay Compras para poder eliminar","Informacion",MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }else
            new EliCompras().Show();
        }

        private void registrarToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (EmpleadoVacio() || ClientesVacios() || ProductosVacio())
            {
                if (EmpleadoVacio())
                {
                    MessageBox.Show("No hay empleados para registrar una venta","Informacion",MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                 if (ClientesVacios())
                {
                    MessageBox.Show("No hay clientes para registrar una venta", "Informacion", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                 if (ProductosVacio())
                {
                    MessageBox.Show("No hay productos para registrar una venta", "Informacion", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                 if (EmpleadoVacio() && ClientesVacios() && ProductosVacio())
                {
                    MessageBox.Show("No hay productos, clientes y empleados para registrar una venta", "Informacion", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            new RegVentas().Show();
        }

        private void modificarToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (VentasVacia())
            {
                MessageBox.Show("No hay ventas para modificar","Informacion",MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            new ModVentas().Show();
        }

        private void busquedaToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (VentasVacia())
            {
                MessageBox.Show("No hay ventas para poder buscar","Informacion",MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }else
            new BusVentas().Show();
        }

        private void eliminarToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (VentasVacia())
            {
                MessageBox.Show("No hay ventas para poder eliminar","Informacion",MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }else
            new eliVentas().Show();
        }

        private void busquedaToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (PedidosVacio())
            {
                MessageBox.Show("No hay pedidos para poder buscar","Informacion",MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }else
            new BusPedido().Show();
        }

        private void modificarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (PedidosVacio())
            {
                MessageBox.Show("No hay pedidos para poder modificar","Informacion",MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }else
            new ModificarPedido().Show();
        }

        private void eliminarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (PedidosVacio())
            {
                MessageBox.Show("No hay pedidos para poder eliminar","Informacion",MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }else
            new EliminarPedido().Show();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void modificarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ComprasVacia())
            {
                MessageBox.Show("No hay compras para poder modificar","Informacion",MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }else
            new ModCompras().Show();
        }

        private void generalToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (PedidosVacio())
            {
                MessageBox.Show("No hay pedidos para la consulta general","Informacion",MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }else
            new ConPedidos().Show();
        }

        private void eliminarToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (ProductosVacio())
            {
                MessageBox.Show("No hay proveedores para poder eliminar","Informacion",MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }else
            new EliProveedores().Show();
        }

        private void generalToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (VentasVacia())
            {
                MessageBox.Show("No hay ventas para la consulta general","Informacion",MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }else
            new ConVentas().Show();
            
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
