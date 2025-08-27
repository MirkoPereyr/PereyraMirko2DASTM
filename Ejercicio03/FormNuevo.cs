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
    public partial class FormNuevo : Form
    {
        private int? Id;
        public FormNuevo(int? Id=null)
        {
            InitializeComponent();
            this.Id = Id;
            if (this.Id != null)
                CargarDatos();

        }

        private void CargarDatos()
        {
            ProductosDB oProductosDB = new ProductosDB();
            Producto oProducto = oProductosDB.Obtener((int)Id);
            txtNombre.Text = oProducto.Nombre;
            txtPrecio.Text = oProducto.Precio.ToString();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ProductosDB oProductosDB = new ProductosDB();
            try
            {
                if(Id == null)
                    oProductosDB.Agregar(txtNombre.Text, decimal.Parse(txtPrecio.Text));
                else
                    oProductosDB.Modificar(txtNombre.Text, decimal.Parse(txtPrecio.Text), (int)Id);

                this.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar producto: " + ex.Message);
            }
        }


    }
}
