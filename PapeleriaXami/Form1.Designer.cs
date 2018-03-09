namespace PapeleriaXami
{
    partial class VentanaPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.busquedaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empleadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regristrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.generalToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.busquedaToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.generalToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.busquedaToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.generalToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.busquedaToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarToolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.generalToolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.busquedaToolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Peru;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem,
            this.empleadoToolStripMenuItem,
            this.productosToolStripMenuItem,
            this.proveedoresToolStripMenuItem,
            this.ventasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(643, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buscarToolStripMenuItem,
            this.consultarToolStripMenuItem,
            this.modificarToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.clientesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("clientesToolStripMenuItem.Image")));
            this.clientesToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Bisque;
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.clientesToolStripMenuItem.Text = "&Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // buscarToolStripMenuItem
            // 
            this.buscarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("buscarToolStripMenuItem.Image")));
            this.buscarToolStripMenuItem.Name = "buscarToolStripMenuItem";
            this.buscarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.buscarToolStripMenuItem.Text = "&Registrar...";
            this.buscarToolStripMenuItem.Click += new System.EventHandler(this.buscarToolStripMenuItem_Click);
            // 
            // consultarToolStripMenuItem
            // 
            this.consultarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generalToolStripMenuItem,
            this.busquedaToolStripMenuItem});
            this.consultarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("consultarToolStripMenuItem.Image")));
            this.consultarToolStripMenuItem.Name = "consultarToolStripMenuItem";
            this.consultarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.consultarToolStripMenuItem.Text = "&Consultar";
            // 
            // generalToolStripMenuItem
            // 
            this.generalToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("generalToolStripMenuItem.Image")));
            this.generalToolStripMenuItem.Name = "generalToolStripMenuItem";
            this.generalToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.generalToolStripMenuItem.Text = "&General";
            this.generalToolStripMenuItem.Click += new System.EventHandler(this.generalToolStripMenuItem_Click);
            // 
            // busquedaToolStripMenuItem
            // 
            this.busquedaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("busquedaToolStripMenuItem.Image")));
            this.busquedaToolStripMenuItem.Name = "busquedaToolStripMenuItem";
            this.busquedaToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.busquedaToolStripMenuItem.Text = "&Busqueda...";
            this.busquedaToolStripMenuItem.Click += new System.EventHandler(this.busquedaToolStripMenuItem_Click);
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("modificarToolStripMenuItem.Image")));
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.modificarToolStripMenuItem.Text = "&Modificar...";
            this.modificarToolStripMenuItem.Click += new System.EventHandler(this.modificarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eliminarToolStripMenuItem.Image")));
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.eliminarToolStripMenuItem.Text = "&Eliminar...";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // empleadoToolStripMenuItem
            // 
            this.empleadoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.regristrarToolStripMenuItem,
            this.consultarToolStripMenuItem2,
            this.modificarToolStripMenuItem2,
            this.eliminarToolStripMenuItem2});
            this.empleadoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("empleadoToolStripMenuItem.Image")));
            this.empleadoToolStripMenuItem.Name = "empleadoToolStripMenuItem";
            this.empleadoToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.empleadoToolStripMenuItem.Text = "&Empleado";
            // 
            // regristrarToolStripMenuItem
            // 
            this.regristrarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("regristrarToolStripMenuItem.Image")));
            this.regristrarToolStripMenuItem.Name = "regristrarToolStripMenuItem";
            this.regristrarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.regristrarToolStripMenuItem.Text = "&Registrar...";
            this.regristrarToolStripMenuItem.Click += new System.EventHandler(this.regristrarToolStripMenuItem_Click);
            // 
            // consultarToolStripMenuItem2
            // 
            this.consultarToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generalToolStripMenuItem2,
            this.busquedaToolStripMenuItem2});
            this.consultarToolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("consultarToolStripMenuItem2.Image")));
            this.consultarToolStripMenuItem2.Name = "consultarToolStripMenuItem2";
            this.consultarToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.consultarToolStripMenuItem2.Text = "&Consultar";
            // 
            // generalToolStripMenuItem2
            // 
            this.generalToolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("generalToolStripMenuItem2.Image")));
            this.generalToolStripMenuItem2.Name = "generalToolStripMenuItem2";
            this.generalToolStripMenuItem2.Size = new System.Drawing.Size(137, 22);
            this.generalToolStripMenuItem2.Text = "&General";
            this.generalToolStripMenuItem2.Click += new System.EventHandler(this.generalToolStripMenuItem2_Click);
            // 
            // busquedaToolStripMenuItem2
            // 
            this.busquedaToolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("busquedaToolStripMenuItem2.Image")));
            this.busquedaToolStripMenuItem2.Name = "busquedaToolStripMenuItem2";
            this.busquedaToolStripMenuItem2.Size = new System.Drawing.Size(137, 22);
            this.busquedaToolStripMenuItem2.Text = "&Busqueda...";
            this.busquedaToolStripMenuItem2.Click += new System.EventHandler(this.busquedaToolStripMenuItem2_Click);
            // 
            // modificarToolStripMenuItem2
            // 
            this.modificarToolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("modificarToolStripMenuItem2.Image")));
            this.modificarToolStripMenuItem2.Name = "modificarToolStripMenuItem2";
            this.modificarToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.modificarToolStripMenuItem2.Text = "&Modificar...";
            this.modificarToolStripMenuItem2.Click += new System.EventHandler(this.modificarToolStripMenuItem2_Click);
            // 
            // eliminarToolStripMenuItem2
            // 
            this.eliminarToolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("eliminarToolStripMenuItem2.Image")));
            this.eliminarToolStripMenuItem2.Name = "eliminarToolStripMenuItem2";
            this.eliminarToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.eliminarToolStripMenuItem2.Text = "&Eliminar...";
            this.eliminarToolStripMenuItem2.Click += new System.EventHandler(this.eliminarToolStripMenuItem2_Click);
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarToolStripMenuItem2,
            this.consultarToolStripMenuItem4,
            this.modificarToolStripMenuItem4,
            this.eliminarToolStripMenuItem4});
            this.productosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("productosToolStripMenuItem.Image")));
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.productosToolStripMenuItem.Text = "P&roductos";
            this.productosToolStripMenuItem.Click += new System.EventHandler(this.productosToolStripMenuItem_Click);
            // 
            // registrarToolStripMenuItem2
            // 
            this.registrarToolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("registrarToolStripMenuItem2.Image")));
            this.registrarToolStripMenuItem2.Name = "registrarToolStripMenuItem2";
            this.registrarToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.registrarToolStripMenuItem2.Text = "&Registrar...";
            this.registrarToolStripMenuItem2.Click += new System.EventHandler(this.registrarToolStripMenuItem2_Click);
            // 
            // consultarToolStripMenuItem4
            // 
            this.consultarToolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generalToolStripMenuItem4,
            this.busquedaToolStripMenuItem4});
            this.consultarToolStripMenuItem4.Image = ((System.Drawing.Image)(resources.GetObject("consultarToolStripMenuItem4.Image")));
            this.consultarToolStripMenuItem4.Name = "consultarToolStripMenuItem4";
            this.consultarToolStripMenuItem4.Size = new System.Drawing.Size(152, 22);
            this.consultarToolStripMenuItem4.Text = "&Consultar";
            // 
            // generalToolStripMenuItem4
            // 
            this.generalToolStripMenuItem4.Image = ((System.Drawing.Image)(resources.GetObject("generalToolStripMenuItem4.Image")));
            this.generalToolStripMenuItem4.Name = "generalToolStripMenuItem4";
            this.generalToolStripMenuItem4.Size = new System.Drawing.Size(137, 22);
            this.generalToolStripMenuItem4.Text = "&General";
            this.generalToolStripMenuItem4.Click += new System.EventHandler(this.generalToolStripMenuItem4_Click);
            // 
            // busquedaToolStripMenuItem4
            // 
            this.busquedaToolStripMenuItem4.Image = ((System.Drawing.Image)(resources.GetObject("busquedaToolStripMenuItem4.Image")));
            this.busquedaToolStripMenuItem4.Name = "busquedaToolStripMenuItem4";
            this.busquedaToolStripMenuItem4.Size = new System.Drawing.Size(137, 22);
            this.busquedaToolStripMenuItem4.Text = "&Busqueda...";
            this.busquedaToolStripMenuItem4.Click += new System.EventHandler(this.busquedaToolStripMenuItem4_Click);
            // 
            // modificarToolStripMenuItem4
            // 
            this.modificarToolStripMenuItem4.Image = ((System.Drawing.Image)(resources.GetObject("modificarToolStripMenuItem4.Image")));
            this.modificarToolStripMenuItem4.Name = "modificarToolStripMenuItem4";
            this.modificarToolStripMenuItem4.Size = new System.Drawing.Size(152, 22);
            this.modificarToolStripMenuItem4.Text = "&Modificar...";
            this.modificarToolStripMenuItem4.Click += new System.EventHandler(this.modificarToolStripMenuItem4_Click);
            // 
            // eliminarToolStripMenuItem4
            // 
            this.eliminarToolStripMenuItem4.Image = ((System.Drawing.Image)(resources.GetObject("eliminarToolStripMenuItem4.Image")));
            this.eliminarToolStripMenuItem4.Name = "eliminarToolStripMenuItem4";
            this.eliminarToolStripMenuItem4.Size = new System.Drawing.Size(152, 22);
            this.eliminarToolStripMenuItem4.Text = "&Eliminar...";
            this.eliminarToolStripMenuItem4.Click += new System.EventHandler(this.eliminarToolStripMenuItem4_Click);
            // 
            // proveedoresToolStripMenuItem
            // 
            this.proveedoresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarToolStripMenuItem3,
            this.consultarToolStripMenuItem5,
            this.modificarToolStripMenuItem5,
            this.eliminarToolStripMenuItem5});
            this.proveedoresToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("proveedoresToolStripMenuItem.Image")));
            this.proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            this.proveedoresToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.proveedoresToolStripMenuItem.Text = "Provee&dores";
            this.proveedoresToolStripMenuItem.Click += new System.EventHandler(this.proveedoresToolStripMenuItem_Click);
            // 
            // registrarToolStripMenuItem3
            // 
            this.registrarToolStripMenuItem3.Image = ((System.Drawing.Image)(resources.GetObject("registrarToolStripMenuItem3.Image")));
            this.registrarToolStripMenuItem3.Name = "registrarToolStripMenuItem3";
            this.registrarToolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
            this.registrarToolStripMenuItem3.Text = "&Registrar...";
            this.registrarToolStripMenuItem3.Click += new System.EventHandler(this.registrarToolStripMenuItem3_Click);
            // 
            // consultarToolStripMenuItem5
            // 
            this.consultarToolStripMenuItem5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generalToolStripMenuItem5,
            this.busquedaToolStripMenuItem5});
            this.consultarToolStripMenuItem5.Image = ((System.Drawing.Image)(resources.GetObject("consultarToolStripMenuItem5.Image")));
            this.consultarToolStripMenuItem5.Name = "consultarToolStripMenuItem5";
            this.consultarToolStripMenuItem5.Size = new System.Drawing.Size(152, 22);
            this.consultarToolStripMenuItem5.Text = "&Consultar";
            // 
            // generalToolStripMenuItem5
            // 
            this.generalToolStripMenuItem5.Image = ((System.Drawing.Image)(resources.GetObject("generalToolStripMenuItem5.Image")));
            this.generalToolStripMenuItem5.Name = "generalToolStripMenuItem5";
            this.generalToolStripMenuItem5.Size = new System.Drawing.Size(137, 22);
            this.generalToolStripMenuItem5.Text = "&General";
            this.generalToolStripMenuItem5.Click += new System.EventHandler(this.generalToolStripMenuItem5_Click);
            // 
            // busquedaToolStripMenuItem5
            // 
            this.busquedaToolStripMenuItem5.Image = ((System.Drawing.Image)(resources.GetObject("busquedaToolStripMenuItem5.Image")));
            this.busquedaToolStripMenuItem5.Name = "busquedaToolStripMenuItem5";
            this.busquedaToolStripMenuItem5.Size = new System.Drawing.Size(137, 22);
            this.busquedaToolStripMenuItem5.Text = "&Busqueda...";
            this.busquedaToolStripMenuItem5.Click += new System.EventHandler(this.busquedaToolStripMenuItem5_Click);
            // 
            // modificarToolStripMenuItem5
            // 
            this.modificarToolStripMenuItem5.Image = ((System.Drawing.Image)(resources.GetObject("modificarToolStripMenuItem5.Image")));
            this.modificarToolStripMenuItem5.Name = "modificarToolStripMenuItem5";
            this.modificarToolStripMenuItem5.Size = new System.Drawing.Size(152, 22);
            this.modificarToolStripMenuItem5.Text = "&Modificar...";
            this.modificarToolStripMenuItem5.Click += new System.EventHandler(this.modificarToolStripMenuItem5_Click);
            // 
            // eliminarToolStripMenuItem5
            // 
            this.eliminarToolStripMenuItem5.Image = ((System.Drawing.Image)(resources.GetObject("eliminarToolStripMenuItem5.Image")));
            this.eliminarToolStripMenuItem5.Name = "eliminarToolStripMenuItem5";
            this.eliminarToolStripMenuItem5.Size = new System.Drawing.Size(152, 22);
            this.eliminarToolStripMenuItem5.Text = "&Eliminar...";
            this.eliminarToolStripMenuItem5.Click += new System.EventHandler(this.eliminarToolStripMenuItem5_Click);
            // 
            // ventasToolStripMenuItem
            // 
            this.ventasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarToolStripMenuItem4,
            this.consultarToolStripMenuItem6,
            this.modificarToolStripMenuItem6,
            this.eliminarToolStripMenuItem6});
            this.ventasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ventasToolStripMenuItem.Image")));
            this.ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            this.ventasToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.ventasToolStripMenuItem.Text = "&Ventas";
            // 
            // registrarToolStripMenuItem4
            // 
            this.registrarToolStripMenuItem4.Image = ((System.Drawing.Image)(resources.GetObject("registrarToolStripMenuItem4.Image")));
            this.registrarToolStripMenuItem4.Name = "registrarToolStripMenuItem4";
            this.registrarToolStripMenuItem4.Size = new System.Drawing.Size(152, 22);
            this.registrarToolStripMenuItem4.Text = "&Registrar...";
            this.registrarToolStripMenuItem4.Click += new System.EventHandler(this.registrarToolStripMenuItem4_Click);
            // 
            // consultarToolStripMenuItem6
            // 
            this.consultarToolStripMenuItem6.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generalToolStripMenuItem6,
            this.busquedaToolStripMenuItem6});
            this.consultarToolStripMenuItem6.Image = ((System.Drawing.Image)(resources.GetObject("consultarToolStripMenuItem6.Image")));
            this.consultarToolStripMenuItem6.Name = "consultarToolStripMenuItem6";
            this.consultarToolStripMenuItem6.Size = new System.Drawing.Size(152, 22);
            this.consultarToolStripMenuItem6.Text = "&Consultar";
            // 
            // generalToolStripMenuItem6
            // 
            this.generalToolStripMenuItem6.Image = ((System.Drawing.Image)(resources.GetObject("generalToolStripMenuItem6.Image")));
            this.generalToolStripMenuItem6.Name = "generalToolStripMenuItem6";
            this.generalToolStripMenuItem6.Size = new System.Drawing.Size(137, 22);
            this.generalToolStripMenuItem6.Text = "&General";
            this.generalToolStripMenuItem6.Click += new System.EventHandler(this.generalToolStripMenuItem6_Click);
            // 
            // busquedaToolStripMenuItem6
            // 
            this.busquedaToolStripMenuItem6.Image = ((System.Drawing.Image)(resources.GetObject("busquedaToolStripMenuItem6.Image")));
            this.busquedaToolStripMenuItem6.Name = "busquedaToolStripMenuItem6";
            this.busquedaToolStripMenuItem6.Size = new System.Drawing.Size(137, 22);
            this.busquedaToolStripMenuItem6.Text = "&Busqueda...";
            this.busquedaToolStripMenuItem6.Click += new System.EventHandler(this.busquedaToolStripMenuItem6_Click);
            // 
            // modificarToolStripMenuItem6
            // 
            this.modificarToolStripMenuItem6.Image = ((System.Drawing.Image)(resources.GetObject("modificarToolStripMenuItem6.Image")));
            this.modificarToolStripMenuItem6.Name = "modificarToolStripMenuItem6";
            this.modificarToolStripMenuItem6.Size = new System.Drawing.Size(152, 22);
            this.modificarToolStripMenuItem6.Text = "&Modificar...";
            this.modificarToolStripMenuItem6.Click += new System.EventHandler(this.modificarToolStripMenuItem6_Click);
            // 
            // eliminarToolStripMenuItem6
            // 
            this.eliminarToolStripMenuItem6.Image = ((System.Drawing.Image)(resources.GetObject("eliminarToolStripMenuItem6.Image")));
            this.eliminarToolStripMenuItem6.Name = "eliminarToolStripMenuItem6";
            this.eliminarToolStripMenuItem6.Size = new System.Drawing.Size(152, 22);
            this.eliminarToolStripMenuItem6.Text = "&Eliminar...";
            this.eliminarToolStripMenuItem6.Click += new System.EventHandler(this.eliminarToolStripMenuItem6_Click);
            // 
            // VentanaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(643, 413);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "VentanaPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Papeleria Xamy";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.VentanaPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem busquedaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem empleadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regristrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem generalToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem busquedaToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem consultarToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem generalToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem busquedaToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem proveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem consultarToolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem generalToolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem busquedaToolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem consultarToolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem generalToolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem busquedaToolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem6;
    }
}

