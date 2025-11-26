namespace Gestion_de_Biblioteca
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            btnAgregarSocio = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtTelefono = new TextBox();
            txtEmail = new TextBox();
            txtNombreCompleto = new TextBox();
            txtDni = new TextBox();
            dgvSocios = new DataGridView();
            tabPage2 = new TabPage();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            txtAutor = new TextBox();
            txtTitulo = new TextBox();
            txtIsbn = new TextBox();
            dgvLibros = new DataGridView();
            btnAgregarLibro = new Button();
            tabPage3 = new TabPage();
            btnRealizarPrestamo = new Button();
            dgvPrestamos = new DataGridView();
            label11 = new Label();
            label10 = new Label();
            label8 = new Label();
            cmbLibros = new ComboBox();
            cmbSocios = new ComboBox();
            dtpPrestamo = new DateTimePicker();
            tabPage4 = new TabPage();
            dgvDevoluciones = new DataGridView();
            label12 = new Label();
            btnDevolver = new Button();
            cmbPrestamos = new ComboBox();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSocios).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrestamos).BeginInit();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDevoluciones).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Location = new Point(-1, -1);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(741, 326);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnAgregarSocio);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(txtTelefono);
            tabPage1.Controls.Add(txtEmail);
            tabPage1.Controls.Add(txtNombreCompleto);
            tabPage1.Controls.Add(txtDni);
            tabPage1.Controls.Add(dgvSocios);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(733, 298);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Socios";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnAgregarSocio
            // 
            btnAgregarSocio.Location = new Point(81, 247);
            btnAgregarSocio.Name = "btnAgregarSocio";
            btnAgregarSocio.Size = new Size(75, 23);
            btnAgregarSocio.TabIndex = 9;
            btnAgregarSocio.Text = "Agregar ";
            btnAgregarSocio.UseVisualStyleBackColor = true;
            btnAgregarSocio.Click += btnAgregarSocio_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 183);
            label4.Name = "label4";
            label4.Size = new Size(53, 15);
            label4.TabIndex = 8;
            label4.Text = "Telefono";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 125);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 7;
            label3.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 64);
            label2.Name = "label2";
            label2.Size = new Size(105, 15);
            label2.TabIndex = 6;
            label2.Text = "Nombre y apellido";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 14);
            label1.Name = "label1";
            label1.Size = new Size(27, 15);
            label1.TabIndex = 5;
            label1.Text = "DNI";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(81, 175);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(100, 23);
            txtTelefono.TabIndex = 4;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(81, 117);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(100, 23);
            txtEmail.TabIndex = 3;
            // 
            // txtNombreCompleto
            // 
            txtNombreCompleto.Location = new Point(120, 61);
            txtNombreCompleto.Name = "txtNombreCompleto";
            txtNombreCompleto.Size = new Size(152, 23);
            txtNombreCompleto.TabIndex = 2;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(42, 6);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(120, 23);
            txtDni.TabIndex = 1;
            // 
            // dgvSocios
            // 
            dgvSocios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSocios.Location = new Point(278, 6);
            dgvSocios.Name = "dgvSocios";
            dgvSocios.Size = new Size(449, 282);
            dgvSocios.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(txtAutor);
            tabPage2.Controls.Add(txtTitulo);
            tabPage2.Controls.Add(txtIsbn);
            tabPage2.Controls.Add(dgvLibros);
            tabPage2.Controls.Add(btnAgregarLibro);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(733, 298);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Libros";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(9, 147);
            label7.Name = "label7";
            label7.Size = new Size(37, 15);
            label7.TabIndex = 7;
            label7.Text = "Autor";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(9, 97);
            label6.Name = "label6";
            label6.Size = new Size(38, 15);
            label6.TabIndex = 6;
            label6.Text = "Titulo";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(9, 43);
            label5.Name = "label5";
            label5.Size = new Size(32, 15);
            label5.TabIndex = 5;
            label5.Text = "ISBN";
            // 
            // txtAutor
            // 
            txtAutor.Location = new Point(52, 139);
            txtAutor.Name = "txtAutor";
            txtAutor.Size = new Size(137, 23);
            txtAutor.TabIndex = 4;
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(53, 89);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(136, 23);
            txtTitulo.TabIndex = 3;
            // 
            // txtIsbn
            // 
            txtIsbn.Location = new Point(53, 35);
            txtIsbn.Name = "txtIsbn";
            txtIsbn.Size = new Size(136, 23);
            txtIsbn.TabIndex = 2;
            // 
            // dgvLibros
            // 
            dgvLibros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLibros.Location = new Point(259, 6);
            dgvLibros.Name = "dgvLibros";
            dgvLibros.Size = new Size(468, 282);
            dgvLibros.TabIndex = 1;
            // 
            // btnAgregarLibro
            // 
            btnAgregarLibro.Location = new Point(79, 214);
            btnAgregarLibro.Name = "btnAgregarLibro";
            btnAgregarLibro.Size = new Size(75, 23);
            btnAgregarLibro.TabIndex = 0;
            btnAgregarLibro.Text = "Agregar";
            btnAgregarLibro.UseVisualStyleBackColor = true;
            btnAgregarLibro.Click += btnAgregarLibro_Click;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(btnRealizarPrestamo);
            tabPage3.Controls.Add(dgvPrestamos);
            tabPage3.Controls.Add(label11);
            tabPage3.Controls.Add(label10);
            tabPage3.Controls.Add(label8);
            tabPage3.Controls.Add(cmbLibros);
            tabPage3.Controls.Add(cmbSocios);
            tabPage3.Controls.Add(dtpPrestamo);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(733, 298);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Prestamos";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnRealizarPrestamo
            // 
            btnRealizarPrestamo.Location = new Point(109, 215);
            btnRealizarPrestamo.Name = "btnRealizarPrestamo";
            btnRealizarPrestamo.Size = new Size(111, 30);
            btnRealizarPrestamo.TabIndex = 9;
            btnRealizarPrestamo.Text = "Realizar";
            btnRealizarPrestamo.UseVisualStyleBackColor = true;
            btnRealizarPrestamo.Click += btnRealizarPrestamo_Click;
            // 
            // dgvPrestamos
            // 
            dgvPrestamos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrestamos.Location = new Point(360, 3);
            dgvPrestamos.Name = "dgvPrestamos";
            dgvPrestamos.Size = new Size(368, 289);
            dgvPrestamos.TabIndex = 8;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(11, 105);
            label11.Name = "label11";
            label11.Size = new Size(39, 15);
            label11.TabIndex = 7;
            label11.Text = "Libros";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(9, 62);
            label10.Name = "label10";
            label10.Size = new Size(41, 15);
            label10.TabIndex = 6;
            label10.Text = "Socios";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(9, 31);
            label8.Name = "label8";
            label8.Size = new Size(91, 15);
            label8.TabIndex = 4;
            label8.Text = "Fecha prestamo";
            // 
            // cmbLibros
            // 
            cmbLibros.FormattingEnabled = true;
            cmbLibros.Location = new Point(56, 97);
            cmbLibros.Name = "cmbLibros";
            cmbLibros.Size = new Size(164, 23);
            cmbLibros.TabIndex = 3;
            // 
            // cmbSocios
            // 
            cmbSocios.FormattingEnabled = true;
            cmbSocios.Location = new Point(56, 54);
            cmbSocios.Name = "cmbSocios";
            cmbSocios.Size = new Size(164, 23);
            cmbSocios.TabIndex = 2;
            // 
            // dtpPrestamo
            // 
            dtpPrestamo.Location = new Point(109, 23);
            dtpPrestamo.Name = "dtpPrestamo";
            dtpPrestamo.Size = new Size(233, 23);
            dtpPrestamo.TabIndex = 0;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(dgvDevoluciones);
            tabPage4.Controls.Add(label12);
            tabPage4.Controls.Add(btnDevolver);
            tabPage4.Controls.Add(cmbPrestamos);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(733, 298);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Devoluciones";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgvDevoluciones
            // 
            dgvDevoluciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDevoluciones.Location = new Point(244, 3);
            dgvDevoluciones.Name = "dgvDevoluciones";
            dgvDevoluciones.Size = new Size(484, 289);
            dgvDevoluciones.TabIndex = 3;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(99, 99);
            label12.Name = "label12";
            label12.Size = new Size(62, 15);
            label12.TabIndex = 2;
            label12.Text = "Prestamos";
            // 
            // btnDevolver
            // 
            btnDevolver.Location = new Point(49, 167);
            btnDevolver.Name = "btnDevolver";
            btnDevolver.Size = new Size(162, 49);
            btnDevolver.TabIndex = 1;
            btnDevolver.Text = "Realizar devolucion";
            btnDevolver.UseVisualStyleBackColor = true;
            btnDevolver.Click += btnDevolver_Click;
            // 
            // cmbPrestamos
            // 
            cmbPrestamos.FormattingEnabled = true;
            cmbPrestamos.Location = new Point(9, 129);
            cmbPrestamos.Name = "cmbPrestamos";
            cmbPrestamos.Size = new Size(229, 23);
            cmbPrestamos.TabIndex = 0;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(743, 327);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Biblioteca";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSocios).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrestamos).EndInit();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDevoluciones).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private DataGridView dgvSocios;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private TextBox txtTelefono;
        private TextBox txtEmail;
        private TextBox txtNombreCompleto;
        private TextBox txtDni;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnAgregarSocio;
        private DataGridView dgvLibros;
        private Button btnAgregarLibro;
        private Label label7;
        private Label label6;
        private Label label5;
        private TextBox txtAutor;
        private TextBox txtTitulo;
        private TextBox txtIsbn;
        private Label label11;
        private Label label10;
        private Label label8;
        private ComboBox cmbLibros;
        private ComboBox cmbSocios;
        private DateTimePicker dtpPrestamo;
        private DataGridView dgvPrestamos;
        private Button btnRealizarPrestamo;
        private TabPage tabPage4;
        private Button btnDevolver;
        private ComboBox cmbPrestamos;
        private DataGridView dgvDevoluciones;
        private Label label12;
    }
}
