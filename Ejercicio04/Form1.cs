using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio04
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
            dsCrudTableAdapters.ProductosTableAdapter ta =
                new dsCrudTableAdapters.ProductosTableAdapter();
            dsCrud.ProductosDataTable dt = ta.GetData();
            dataGridView1.DataSource = dt;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmProductos frm = new FrmProductos();
            frm.ShowDialog();
            Actualizar();
        }

        private int? ObtenerId()
        {
            try
            {
                return int.Parse(
                dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString()
                );
            }
            catch
            {
                return null;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int? Id = ObtenerId();
            if (Id != null)
            {
                FrmProductos frm = new FrmProductos(Id);
                frm.ShowDialog();
                Actualizar();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int? Id = ObtenerId();
            if (Id != null)
            {
                dsCrudTableAdapters.ProductosTableAdapter ta =
                    new dsCrudTableAdapters.ProductosTableAdapter();
                ta.Remove((int)Id);
                Actualizar();

            }
        }
    }
}
