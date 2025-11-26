using System.Data.SqlClient;

namespace ado.net_3_repaso
{
    public partial class Form1 : Form
    {
        RepositorioSocios repo = new RepositorioSocios();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Refrescar();
            dgvSocios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSocios.MultiSelect = false;
            dgvSocios.ReadOnly = true;
            dgvSocios.CellClick += dgvSocios_CellClick;
            LimpiarCampos();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                AgregarSocio();
            }
            catch (DatosInvalidosException ex)
            {
                MessageBox.Show($"Error de datos: {ex.Message}");
            }
            catch (SqlException ex)
            {
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                ModificarSocio();
            }
            catch (DatosInvalidosException ex)
            {
                MessageBox.Show($"Error de datos: {ex.Message}");
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error en la base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                EliminarSocio();
            }
            catch (DatosInvalidosException ex)
            {
                MessageBox.Show($"Error de datos: {ex.Message}");
            }
            catch (SqlException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void btnBuscarSocioMayorA_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtEdadMin.Text, out int edad))
                {
                    MessageBox.Show("Ingrese una edad valida.");
                    return;
                }

                var resultado = repo.ListarSociosMayoresA(edad);

                dgvSocios.AutoGenerateColumns = true;
                dgvSocios.DataSource = null;


                dgvSocios.DataSource = resultado.ToList();

                dgvSocios.ClearSelection();

            }
            catch (DatosInvalidosException ex)
            {
                MessageBox.Show($"Error de datos: {ex.Message}");
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error en la base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}");
            }
        }

        private void btnCantidadSociosConCuotaAlDia_Click(object sender, EventArgs e)
        {
            try
            {
                int cantidad = repo.ContarSociosConCuotaAlDia();
                MessageBox.Show($"Socios con la cuota al dia: {cantidad}");
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error en la base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}");
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            Refrescar();
        }

        private void btnBuscarPorDni_Click(object sender, EventArgs e)
        {
            BuscarPorDni();
        }

        private void Refrescar()
        {
            dgvSocios.DataSource = null;
            dgvSocios.DataSource = repo.ListarSocios();
        }

        private void AgregarSocio()
        {
            if (CamposVacios())
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios");
                return;
            }

            if (dtpFechaNacimiento.Value > DateTime.Now)
            {
                MessageBox.Show("La fecha de nacimiento no puede ser futura");
                return;
            }

            if (!int.TryParse(txtNumeroSocio.Text, out int nroSocio))
            {
                MessageBox.Show("Numero de socio invalido.");
                return;
            }

            var socio = new Socio
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Dni = txtDni.Text,
                FechaNacimiento = dtpFechaNacimiento.Value,
                NumeroSocio = nroSocio,
                CuotaAlDia = chkCuotaAlDia.Checked
            };

            repo.AgregarSocio(socio);
            MessageBox.Show("Socio agregado exitosamente.");
            Refrescar();
            LimpiarCampos();
        }

        private void ModificarSocio()
        {
            if (dgvSocios.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un socio para modificar.");
                return;
            }

            if (CamposVacios())
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios");
                return;
            }

            if (dtpFechaNacimiento.Value > DateTime.Now)
            {
                MessageBox.Show("La fecha de nacimiento no puede ser futura");
                return;
            }

            if (!int.TryParse(txtNumeroSocio.Text, out int nroSocio))
            {
                MessageBox.Show("Numero de socio invalido.");
                return;
            }

            var socio = new Socio 
            {
                Id = Convert.ToInt32(dgvSocios.CurrentRow.Cells["Id"].Value),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Dni = txtDni.Text,
                FechaNacimiento = dtpFechaNacimiento.Value,
                NumeroSocio = nroSocio,
                CuotaAlDia = chkCuotaAlDia.Checked
            };

            repo.ModificarSocio(socio);
            MessageBox.Show("Socio modificado exitosamente.");
            Refrescar();
            LimpiarCampos();
        }

        private void EliminarSocio()
        {
            if (dgvSocios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un socio para eliminar.");
                return;
            }

            if (MessageBox.Show("¿Esta seguro de que desea eliminar este socio?", "Confirmar eliminacion", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            int id = Convert.ToInt32(dgvSocios.SelectedRows[0].Cells["Id"].Value);
            repo.EliminarSocio(id);
            MessageBox.Show("Socio eliminado con exito.");
            Refrescar();
            LimpiarCampos();
        }

        private void BuscarPorDni()
        {
            string dni = txtDni.Text.Trim();

            if (string.IsNullOrEmpty(dni))
            {
                Refrescar();
                return;
            }

            var resultado = repo.BuscarSocioPorDni(dni);
            if (resultado != null)
            {
                dgvSocios.DataSource = null;
                dgvSocios.DataSource = new List<Socio> { resultado };
            }
            else
            {
                dgvSocios.DataSource = null;
                MessageBox.Show("No se encontro socio con ese DNI.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LimpiarCampos() 
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDni.Clear();
            dtpFechaNacimiento.Value = DateTime.Now;
            txtNumeroSocio.Clear();
            chkCuotaAlDia.Checked = false;
        }

        private bool CamposVacios()
        {
            return string.IsNullOrWhiteSpace(txtNombre.Text) ||
                   string.IsNullOrWhiteSpace(txtApellido.Text) ||
                   string.IsNullOrWhiteSpace(txtDni.Text) ||
                   string.IsNullOrWhiteSpace(txtNumeroSocio.Text);
        }

        private void dgvSocios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var fila = dgvSocios.Rows[e.RowIndex];

            txtNombre.Text = fila.Cells["Nombre"]?.Value?.ToString() ?? "";
            txtApellido.Text = fila.Cells["Apellido"]?.Value?.ToString() ?? "";
            txtDni.Text = fila.Cells["Dni"]?.Value?.ToString() ?? "";
            dtpFechaNacimiento.Value = (DateTime)fila.Cells["FechaNacimiento"].Value;
            txtNumeroSocio.Text = fila.Cells["NumeroSocio"]?.Value?.ToString() ?? "";

            var valorCuota = fila.Cells["CuotaAlDia"]?.Value;
            chkCuotaAlDia.Checked = valorCuota is bool b && b;
        }

    }
}
