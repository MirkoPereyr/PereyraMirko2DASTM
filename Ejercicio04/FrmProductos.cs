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
    public partial class FrmProductos : Form
    {
        private int? Id;

        public FrmProductos(int? Id=null)
        {
            InitializeComponent();
            this.Id = Id;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            dsCrudTableAdapters.ProductosTableAdapter ta =
                new dsCrudTableAdapters.ProductosTableAdapter();
            if (Id == null)
            {
                ta.Add(txtNombre.Text.Trim(), decimal.Parse(txtPrecio.Text.Trim()));
            }
            else
            {
                ta.Edit(txtNombre.Text.Trim(), decimal.Parse(txtPrecio.Text.Trim()), (int)Id);
            }
            this.Close();

        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            if (Id != null)
            {
                dsCrudTableAdapters.ProductosTableAdapter ta =
                    new dsCrudTableAdapters.ProductosTableAdapter();
                dsCrud.ProductosDataTable dt = ta.GetDataById((int)Id);
                dsCrud.ProductosRow row = (dsCrud.ProductosRow)dt.Rows[0];
                txtNombre.Text = row.nombre;
                txtPrecio.Text = row.precio.ToString();

            }
        }
    }
}
