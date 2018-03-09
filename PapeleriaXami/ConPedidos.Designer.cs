namespace PapeleriaXami
{
    partial class ConPedidos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConPedidos));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idPedidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoDeBarrasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEmpleadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pedidoRealizadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoDePedidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDePedidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDeEntregaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pedidoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.papeleriaDataSet4 = new PapeleriaXami.papeleriaDataSet4();
            this.button1 = new System.Windows.Forms.Button();
            this.pedidoTableAdapter = new PapeleriaXami.papeleriaDataSet4TableAdapters.pedidoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pedidoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.papeleriaDataSet4)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.BurlyWood;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idPedidoDataGridViewTextBoxColumn,
            this.codigoDeBarrasDataGridViewTextBoxColumn,
            this.idEmpleadoDataGridViewTextBoxColumn,
            this.pedidoRealizadoDataGridViewTextBoxColumn,
            this.costoDePedidoDataGridViewTextBoxColumn,
            this.fechaDePedidoDataGridViewTextBoxColumn,
            this.fechaDeEntregaDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.pedidoBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(748, 268);
            this.dataGridView1.TabIndex = 0;
            // 
            // idPedidoDataGridViewTextBoxColumn
            // 
            this.idPedidoDataGridViewTextBoxColumn.DataPropertyName = "IdPedido";
            this.idPedidoDataGridViewTextBoxColumn.HeaderText = "Id Pedido";
            this.idPedidoDataGridViewTextBoxColumn.Name = "idPedidoDataGridViewTextBoxColumn";
            this.idPedidoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codigoDeBarrasDataGridViewTextBoxColumn
            // 
            this.codigoDeBarrasDataGridViewTextBoxColumn.DataPropertyName = "CodigoDeBarras";
            this.codigoDeBarrasDataGridViewTextBoxColumn.HeaderText = "Codigo De Barras";
            this.codigoDeBarrasDataGridViewTextBoxColumn.Name = "codigoDeBarrasDataGridViewTextBoxColumn";
            this.codigoDeBarrasDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idEmpleadoDataGridViewTextBoxColumn
            // 
            this.idEmpleadoDataGridViewTextBoxColumn.DataPropertyName = "IdEmpleado";
            this.idEmpleadoDataGridViewTextBoxColumn.HeaderText = "Id Empleado";
            this.idEmpleadoDataGridViewTextBoxColumn.Name = "idEmpleadoDataGridViewTextBoxColumn";
            this.idEmpleadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pedidoRealizadoDataGridViewTextBoxColumn
            // 
            this.pedidoRealizadoDataGridViewTextBoxColumn.DataPropertyName = "PedidoRealizado";
            this.pedidoRealizadoDataGridViewTextBoxColumn.HeaderText = "Pedido Realizado";
            this.pedidoRealizadoDataGridViewTextBoxColumn.Name = "pedidoRealizadoDataGridViewTextBoxColumn";
            this.pedidoRealizadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // costoDePedidoDataGridViewTextBoxColumn
            // 
            this.costoDePedidoDataGridViewTextBoxColumn.DataPropertyName = "CostoDePedido";
            this.costoDePedidoDataGridViewTextBoxColumn.HeaderText = "Costo De Pedido";
            this.costoDePedidoDataGridViewTextBoxColumn.Name = "costoDePedidoDataGridViewTextBoxColumn";
            this.costoDePedidoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaDePedidoDataGridViewTextBoxColumn
            // 
            this.fechaDePedidoDataGridViewTextBoxColumn.DataPropertyName = "FechaDePedido";
            this.fechaDePedidoDataGridViewTextBoxColumn.HeaderText = "Fecha De Pedido";
            this.fechaDePedidoDataGridViewTextBoxColumn.Name = "fechaDePedidoDataGridViewTextBoxColumn";
            this.fechaDePedidoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaDeEntregaDataGridViewTextBoxColumn
            // 
            this.fechaDeEntregaDataGridViewTextBoxColumn.DataPropertyName = "FechaDeEntrega";
            this.fechaDeEntregaDataGridViewTextBoxColumn.HeaderText = "Fecha De Entrega";
            this.fechaDeEntregaDataGridViewTextBoxColumn.Name = "fechaDeEntregaDataGridViewTextBoxColumn";
            this.fechaDeEntregaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pedidoBindingSource
            // 
            this.pedidoBindingSource.DataMember = "pedido";
            this.pedidoBindingSource.DataSource = this.papeleriaDataSet4;
            // 
            // papeleriaDataSet4
            // 
            this.papeleriaDataSet4.DataSetName = "papeleriaDataSet4";
            this.papeleriaDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(614, 308);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "&Cerrar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pedidoTableAdapter
            // 
            this.pedidoTableAdapter.ClearBeforeFill = true;
            // 
            // ConPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Peru;
            this.ClientSize = new System.Drawing.Size(749, 362);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConPedidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar Pedidos";
            this.Load += new System.EventHandler(this.ConPedidos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pedidoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.papeleriaDataSet4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private papeleriaDataSet4 papeleriaDataSet4;
        private System.Windows.Forms.BindingSource pedidoBindingSource;
        private papeleriaDataSet4TableAdapters.pedidoTableAdapter pedidoTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPedidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoDeBarrasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEmpleadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pedidoRealizadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoDePedidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDePedidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDeEntregaDataGridViewTextBoxColumn;
    }
}