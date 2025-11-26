using Entidades;

namespace Gestion_de_Biblioteca
{
    public partial class Form1 : Form
    {
        private readonly Controladora.Controladora controladora = Controladora.Controladora.Instancia;

        public Form1()
        {
            InitializeComponent();

            this.Shown += (_, __) => ReloadAll();

            dgvSocios.AutoGenerateColumns = true;
            dgvLibros.AutoGenerateColumns = true;
            dgvPrestamos.AutoGenerateColumns = true;
            dgvDevoluciones.AutoGenerateColumns = true;

        }

        private void ReloadAll()
        {
            RellenarSocios();
            RellenarLibros();
            RellenarPrestamos();       // usa Includes (ver 3)
            RellenarCombosPrestamo();  // socios + libros disponibles
            RellenarCombosDevolucion();// préstamos activos (sin BuscarPorId)
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregarSocio_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtDni.Text, out var dni))
            {
                MessageBox.Show("DNI invalido (8 dígitos).");
                return;
            }

            var socio = new Socio
            {
                Dni = dni,
                NombreCompleto = txtNombreCompleto.Text?.Trim(),
                Email = txtEmail.Text?.Trim(),
                Telefono = txtTelefono.Text?.Trim()
            };

            // Guarda en BD y valida con las regex (DNI/Email/Teléfono)
            MessageBox.Show(controladora.AgregarSocio(socio));

            // limpia y refresca “profe style”
            txtDni.Clear(); txtNombreCompleto.Clear(); txtEmail.Clear(); txtTelefono.Clear();
            RellenarSocios();
            RellenarCombosPrestamo();
            RellenarCombosDevolucion();
        }

        private void RellenarSocios()
        {
            var socios = controladora.repoSocios.Listar().ToList();
            dgvSocios.DataSource = null;
            dgvSocios.DataSource = socios;
        }

        private void btnAgregarLibro_Click(object sender, EventArgs e)
        {
            var libro = new Libro
            {
                Isbn = txtIsbn.Text?.Trim(),     // valida ISBN en controladora
                Titulo = txtTitulo.Text?.Trim(),
                Autor = txtAutor.Text?.Trim(),
                Estado = true
            };

            MessageBox.Show(controladora.AgregarLibro(libro));

            txtIsbn.Clear(); txtTitulo.Clear(); txtAutor.Clear();
            RellenarLibros();
            RellenarCombosPrestamo();
        }

        private void RellenarLibros()
        {
            var libros = controladora.repoLibros.Listar().ToList();
            dgvLibros.DataSource = null;
            dgvLibros.DataSource = libros;
        }

        private void btnRealizarPrestamo_Click(object sender, EventArgs e)
        {
            if (cmbSocios.SelectedItem is not Socio socioSel) { MessageBox.Show("Seleccioná un socio."); return; }
            if (cmbLibros.SelectedItem is not Libro libroSel) { MessageBox.Show("Seleccioná un libro."); return; }

            MessageBox.Show(controladora.AsignarPrestamo(socioSel, libroSel));
            ReloadAll();
        }

        private void RellenarPrestamos()
        {
            var prestamos = controladora.repoPrestamos.Listar().ToList(); // ya trae Libro/Socio

            var vista = prestamos.Select(p => new
            {
                p.PrestamoId,
                Libro = p.libro?.Titulo,
                Socio = p.socio?.NombreCompleto,
                Prestado = p.FechaPrestamo.ToString("dd/MM/yyyy"),
                Devolucion = p.FechaDevolucion.HasValue
                                ? p.FechaDevolucion.Value.ToString("dd/MM/yyyy")
                                : "Pendiente"
            }).ToList();

            dgvPrestamos.AutoGenerateColumns = true;
            dgvPrestamos.DataSource = null;
            dgvPrestamos.DataSource = vista;
            dgvPrestamos.Refresh();
        }

        private void RellenarCombosPrestamo()
        {
            // Socios: muestra nombre, guarda id, pero usamos SelectedItem como Socio para simplificar
            var socios = controladora.repoSocios.Listar().ToList();
            cmbSocios.DataSource = null;
            cmbSocios.DataSource = socios;           // objetos
            cmbSocios.DisplayMember = "NombreCompleto";
            cmbSocios.ValueMember = "SocioId";     // opcional

            var disponibles = controladora.repoLibros.Listar().Where(l => l.Estado).ToList();
            cmbLibros.DataSource = null;
            cmbLibros.DataSource = disponibles;      // objetos
            cmbLibros.DisplayMember = "Titulo";
            cmbLibros.ValueMember = "LibroId";
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            if (cmbPrestamos.SelectedItem is not Prestamo pSel)
            {
                MessageBox.Show("Seleccioná un préstamo activo.");
                return;
            }

            MessageBox.Show(controladora.RegistrarDevolucion(pSel));
            ReloadAll();
        }

        private void RellenarCombosDevolucion()
        {
            // 1) Traer TODOS (con Libro/Socio incluidos por el repo)
            var todos = controladora.repoPrestamos.Listar().ToList();

            DateTime sentinel = new DateTime(1901, 1, 1);
            var activos = todos
                .Where(p => p.FechaDevolucion == null
                         || (p.FechaDevolucion.HasValue && p.FechaDevolucion.Value <= sentinel))
                .ToList();

            // 5) Combo: bindear objetos Prestamo
            cmbPrestamos.DataSource = null;
            cmbPrestamos.FormattingEnabled = true;              
            cmbPrestamos.DisplayMember = "";                    
            cmbPrestamos.ValueMember = "";                    
            cmbPrestamos.DataSource = activos;               

            // evitar doble suscripción
            cmbPrestamos.Format -= cmbPrestamos_Format;
            cmbPrestamos.Format += cmbPrestamos_Format;

            if (cmbPrestamos.Items.Count > 0 && string.IsNullOrWhiteSpace(cmbPrestamos.Text))
            {
                cmbPrestamos.DisplayMember = "PrestamoId";      
                cmbPrestamos.ValueMember = "PrestamoId";
                cmbPrestamos.SelectedIndex = 0;
            }

            // 7) Grilla a la derecha (que se vea algo YA)
            dgvDevoluciones.AutoGenerateColumns = true;
            dgvDevoluciones.DataSource = null;
            dgvDevoluciones.DataSource = activos.Select(p => new
            {
                p.PrestamoId,
                Libro = p.libro?.Titulo,
                Socio = p.socio?.NombreCompleto,
                Prestado = p.FechaPrestamo.ToString("dd/MM/yyyy")
            }).ToList();
            dgvDevoluciones.Refresh();
        }

        private void cmbPrestamos_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is Prestamo p)
                e.Value = $"#{p.PrestamoId} - {p.libro?.Titulo} ({p.socio?.NombreCompleto})";
        }
    }
}
