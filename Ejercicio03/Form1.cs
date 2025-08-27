using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void Actualizar()
        {
            ProductosDB oProductosDB = new ProductosDB();
            dataGridView1.DataSource = oProductosDB.Obtener();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormNuevo frm = new FormNuevo();
            frm.ShowDialog();
            Actualizar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int? Id = ObtenerId();
            try
            {
                if (Id != null)
                {
                    FormNuevo frmModificar = new FormNuevo(Id);
                    frmModificar.ShowDialog();
                    Actualizar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar producto: " + ex.Message);
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int? Id = ObtenerId();
            try
            {
                if (Id != null)
                {
                    ProductosDB oProductosDB = new ProductosDB();
                    oProductosDB.Eliminar((int)Id);
                    Actualizar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar producto: " + ex.Message);
            }
        }

        #region HELPER
        private int ObtenerId()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch 
            {
                return int.Parse(null);
            }
            
        }
        #endregion

    }
}
