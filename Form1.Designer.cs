namespace OLYMPUS10
{
    partial class FrmClientes
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnListaClientes = new Button();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnEliminarCliente = new Button();
            btnGuardar = new Button();
            txtGmail = new TextBox();
            txtTelefono = new TextBox();
            txtDireccion = new TextBox();
            txtApellido = new TextBox();
            txtNombre = new TextBox();
            dgvClientes = new DataGridView();
            cbPlan = new ComboBox();
            txtPrecio = new TextBox();
            label8 = new Label();
            dtpFechaAlta = new DateTimePicker();
            label9 = new Label();
            dgvPagos = new DataGridView();
            btnRegistrarPago = new Button();
            btnVerPagos = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPagos).BeginInit();
            SuspendLayout();
            // 
            // btnListaClientes
            // 
            btnListaClientes.Location = new Point(246, 136);
            btnListaClientes.Name = "btnListaClientes";
            btnListaClientes.Size = new Size(112, 40);
            btnListaClientes.TabIndex = 37;
            btnListaClientes.Text = "Ver Lista de Clientes";
            btnListaClientes.UseVisualStyleBackColor = true;
            btnListaClientes.Click += btnListaClientes_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(35, 107);
            label6.Name = "label6";
            label6.Size = new Size(30, 15);
            label6.TabIndex = 35;
            label6.Text = "Plan";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(202, 50);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 34;
            label5.Text = "Gmail";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(188, 21);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 33;
            label4.Text = "Telefono";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 78);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 32;
            label3.Text = "Direccion";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 49);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 31;
            label2.Text = "Apellido";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 20);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 30;
            label1.Text = "Nombre";
            // 
            // btnEliminarCliente
            // 
            btnEliminarCliente.ImageAlign = ContentAlignment.MiddleLeft;
            btnEliminarCliente.Location = new Point(1033, 98);
            btnEliminarCliente.Name = "btnEliminarCliente";
            btnEliminarCliente.Size = new Size(112, 25);
            btnEliminarCliente.TabIndex = 29;
            btnEliminarCliente.Text = "Eliminar Cliente";
            btnEliminarCliente.UseVisualStyleBackColor = true;
            btnEliminarCliente.Click += btnEliminarCliente_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(246, 107);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(112, 23);
            btnGuardar.TabIndex = 27;
            btnGuardar.Text = "Agregar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtGmail
            // 
            txtGmail.Location = new Point(246, 42);
            txtGmail.Name = "txtGmail";
            txtGmail.RightToLeft = RightToLeft.No;
            txtGmail.Size = new Size(112, 23);
            txtGmail.TabIndex = 26;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(246, 13);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.RightToLeft = RightToLeft.No;
            txtTelefono.Size = new Size(112, 23);
            txtTelefono.TabIndex = 25;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(71, 70);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.RightToLeft = RightToLeft.No;
            txtDireccion.Size = new Size(112, 23);
            txtDireccion.TabIndex = 24;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(71, 41);
            txtApellido.Name = "txtApellido";
            txtApellido.RightToLeft = RightToLeft.No;
            txtApellido.Size = new Size(112, 23);
            txtApellido.TabIndex = 23;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(71, 12);
            txtNombre.Name = "txtNombre";
            txtNombre.RightToLeft = RightToLeft.No;
            txtNombre.Size = new Size(112, 23);
            txtNombre.TabIndex = 22;
            // 
            // dgvClientes
            // 
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(12, 182);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.RightToLeft = RightToLeft.No;
            dgvClientes.Size = new Size(851, 498);
            dgvClientes.TabIndex = 21;
            // 
            // cbPlan
            // 
            cbPlan.AutoCompleteCustomSource.AddRange(new string[] { "Pase Libre", "8 dias p/mes", "12 dias p/mes", "Trimestral" });
            cbPlan.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbPlan.FormattingEnabled = true;
            cbPlan.Items.AddRange(new object[] { "Pase Libre", "8 dias p/mes", "12 dias p/mes", "Trimestral" });
            cbPlan.Location = new Point(71, 99);
            cbPlan.Name = "cbPlan";
            cbPlan.RightToLeft = RightToLeft.No;
            cbPlan.Size = new Size(112, 23);
            cbPlan.TabIndex = 19;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(246, 71);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.RightToLeft = RightToLeft.No;
            txtPrecio.Size = new Size(112, 23);
            txtPrecio.TabIndex = 38;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(200, 79);
            label8.Name = "label8";
            label8.Size = new Size(40, 15);
            label8.TabIndex = 39;
            label8.Text = "Precio";
            // 
            // dtpFechaAlta
            // 
            dtpFechaAlta.Location = new Point(8, 153);
            dtpFechaAlta.Name = "dtpFechaAlta";
            dtpFechaAlta.Size = new Size(175, 23);
            dtpFechaAlta.TabIndex = 40;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(59, 135);
            label9.Name = "label9";
            label9.Size = new Size(79, 15);
            label9.TabIndex = 41;
            label9.Text = "Fecha De Alta";
            // 
            // dgvPagos
            // 
            dgvPagos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPagos.Location = new Point(364, 12);
            dgvPagos.Name = "dgvPagos";
            dgvPagos.RightToLeft = RightToLeft.No;
            dgvPagos.Size = new Size(663, 164);
            dgvPagos.TabIndex = 42;
            // 
            // btnRegistrarPago
            // 
            btnRegistrarPago.Location = new Point(1033, 40);
            btnRegistrarPago.Name = "btnRegistrarPago";
            btnRegistrarPago.Size = new Size(112, 23);
            btnRegistrarPago.TabIndex = 43;
            btnRegistrarPago.Text = "Registrar Pago";
            btnRegistrarPago.UseVisualStyleBackColor = true;
            btnRegistrarPago.Click += btnRegistrarPago_Click;
            // 
            // btnVerPagos
            // 
            btnVerPagos.Location = new Point(1033, 69);
            btnVerPagos.Name = "btnVerPagos";
            btnVerPagos.Size = new Size(112, 23);
            btnVerPagos.TabIndex = 44;
            btnVerPagos.Text = "Ver Pagos";
            btnVerPagos.UseVisualStyleBackColor = true;
            btnVerPagos.Click += btnVerPagos_Click;
            // 
            // FrmClientes
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1154, 692);
            Controls.Add(btnVerPagos);
            Controls.Add(btnRegistrarPago);
            Controls.Add(dgvPagos);
            Controls.Add(label9);
            Controls.Add(dtpFechaAlta);
            Controls.Add(label8);
            Controls.Add(txtPrecio);
            Controls.Add(btnListaClientes);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnEliminarCliente);
            Controls.Add(btnGuardar);
            Controls.Add(txtGmail);
            Controls.Add(txtTelefono);
            Controls.Add(txtDireccion);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(dgvClientes);
            Controls.Add(cbPlan);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "FrmClientes";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterParent;
            Text = "OlympusGym";
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPagos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnListaClientes;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnEliminarCliente;
        private Button btnGuardar;
        private TextBox txtGmail;
        private TextBox txtTelefono;
        private TextBox txtDireccion;
        private TextBox txtApellido;
        private TextBox txtNombre;
        private DataGridView dgvClientes;
        private ComboBox cbPlan;
        private TextBox txtPrecio;
        private Label label8;
        private DateTimePicker dtpFechaAlta;
        private Label label9;
        private DataGridView dgvPagos;
        private Button btnRegistrarPago;
        private Button btnVerPagos;
    }
}
