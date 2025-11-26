namespace ado.net_3_repaso
{
    partial class Form1
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
            dgvSocios = new DataGridView();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtDni = new TextBox();
            dtpFechaNacimiento = new DateTimePicker();
            txtNumeroSocio = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            chkCuotaAlDia = new CheckBox();
            groupBox1 = new GroupBox();
            btnBuscarPorDni = new Button();
            btnCantidadSociosConCuotaAlDia = new Button();
            btnListar = new Button();
            btnBuscarSocioMayorA = new Button();
            txtEdadMin = new TextBox();
            btnEliminar = new Button();
            btnModificar = new Button();
            btnAgregar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSocios).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvSocios
            // 
            dgvSocios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSocios.Location = new Point(316, 12);
            dgvSocios.Name = "dgvSocios";
            dgvSocios.Size = new Size(743, 471);
            dgvSocios.TabIndex = 0;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(65, 12);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 1;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(65, 58);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(100, 23);
            txtApellido.TabIndex = 2;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(65, 99);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(100, 23);
            txtDni.TabIndex = 3;
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Location = new Point(74, 145);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(236, 23);
            dtpFechaNacimiento.TabIndex = 4;
            // 
            // txtNumeroSocio
            // 
            txtNumeroSocio.Location = new Point(73, 191);
            txtNumeroSocio.Name = "txtNumeroSocio";
            txtNumeroSocio.Size = new Size(100, 23);
            txtNumeroSocio.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 20);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 6;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 66);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 7;
            label2.Text = "Apellido";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 107);
            label3.Name = "label3";
            label3.Size = new Size(25, 15);
            label3.TabIndex = 8;
            label3.Text = "Dni";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 153);
            label4.Name = "label4";
            label4.Size = new Size(62, 15);
            label4.TabIndex = 9;
            label4.Text = "Fecha Nac";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(8, 199);
            label5.Name = "label5";
            label5.Size = new Size(59, 15);
            label5.TabIndex = 10;
            label5.Text = "Nro Socio";
            // 
            // chkCuotaAlDia
            // 
            chkCuotaAlDia.AutoSize = true;
            chkCuotaAlDia.Location = new Point(12, 240);
            chkCuotaAlDia.Name = "chkCuotaAlDia";
            chkCuotaAlDia.Size = new Size(89, 19);
            chkCuotaAlDia.TabIndex = 11;
            chkCuotaAlDia.Text = "Cuota al dia";
            chkCuotaAlDia.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Gray;
            groupBox1.Controls.Add(btnBuscarPorDni);
            groupBox1.Controls.Add(btnCantidadSociosConCuotaAlDia);
            groupBox1.Controls.Add(btnListar);
            groupBox1.Controls.Add(btnBuscarSocioMayorA);
            groupBox1.Controls.Add(txtEdadMin);
            groupBox1.Controls.Add(btnEliminar);
            groupBox1.Controls.Add(btnModificar);
            groupBox1.Controls.Add(btnAgregar);
            groupBox1.ForeColor = SystemColors.ControlText;
            groupBox1.Location = new Point(8, 265);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(302, 218);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Funciones";
            // 
            // btnBuscarPorDni
            // 
            btnBuscarPorDni.Location = new Point(187, 74);
            btnBuscarPorDni.Name = "btnBuscarPorDni";
            btnBuscarPorDni.Size = new Size(100, 23);
            btnBuscarPorDni.TabIndex = 17;
            btnBuscarPorDni.Text = "Buscar por DNI";
            btnBuscarPorDni.UseVisualStyleBackColor = true;
            btnBuscarPorDni.Click += btnBuscarPorDni_Click;
            // 
            // btnCantidadSociosConCuotaAlDia
            // 
            btnCantidadSociosConCuotaAlDia.Location = new Point(14, 117);
            btnCantidadSociosConCuotaAlDia.Name = "btnCantidadSociosConCuotaAlDia";
            btnCantidadSociosConCuotaAlDia.Size = new Size(273, 35);
            btnCantidadSociosConCuotaAlDia.TabIndex = 16;
            btnCantidadSociosConCuotaAlDia.Text = "Cantidad socios con cuota al dia";
            btnCantidadSociosConCuotaAlDia.UseVisualStyleBackColor = true;
            btnCantidadSociosConCuotaAlDia.Click += btnCantidadSociosConCuotaAlDia_Click;
            // 
            // btnListar
            // 
            btnListar.Location = new Point(14, 74);
            btnListar.Name = "btnListar";
            btnListar.Size = new Size(75, 23);
            btnListar.TabIndex = 15;
            btnListar.Text = "Listar todos";
            btnListar.UseVisualStyleBackColor = true;
            btnListar.Click += btnListar_Click;
            // 
            // btnBuscarSocioMayorA
            // 
            btnBuscarSocioMayorA.Location = new Point(14, 167);
            btnBuscarSocioMayorA.Name = "btnBuscarSocioMayorA";
            btnBuscarSocioMayorA.Size = new Size(153, 23);
            btnBuscarSocioMayorA.TabIndex = 14;
            btnBuscarSocioMayorA.Text = "Buscar socio mayor A";
            btnBuscarSocioMayorA.UseVisualStyleBackColor = true;
            btnBuscarSocioMayorA.Click += btnBuscarSocioMayorA_Click;
            // 
            // txtEdadMin
            // 
            txtEdadMin.Location = new Point(187, 167);
            txtEdadMin.Name = "txtEdadMin";
            txtEdadMin.Size = new Size(100, 23);
            txtEdadMin.TabIndex = 13;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(212, 31);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(114, 31);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 1;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(14, 31);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 0;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1071, 495);
            Controls.Add(groupBox1);
            Controls.Add(chkCuotaAlDia);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtNumeroSocio);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(txtDni);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(dgvSocios);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSocios).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvSocios;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtDni;
        private DateTimePicker dtpFechaNacimiento;
        private TextBox txtNumeroSocio;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private CheckBox chkCuotaAlDia;
        private GroupBox groupBox1;
        private Button btnBuscarSocioMayorA;
        private TextBox txtEdadMin;
        private Button btnEliminar;
        private Button btnModificar;
        private Button btnAgregar;
        private Button btnBuscarPorDni;
        private Button btnCantidadSociosConCuotaAlDia;
        private Button btnListar;
    }
}
