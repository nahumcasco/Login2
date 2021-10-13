using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;

namespace Login2
{
    public partial class ProductosForm : Form
    {
        public ProductosForm()
        {
            InitializeComponent();
        }
        ConexionDB conexion = new ConexionDB();
        Producto producto = new Producto();

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (DescripcionTextBox.Text == "")
            {
                return;
            }
            if (string.IsNullOrEmpty(PrecioTextBox.Text))
            {
                return;
            }
            if (ExistenciaTextBox.Text == string.Empty)
            {
                return;
            }

            producto.Descripcion = DescripcionTextBox.Text;
            producto.Precio = Convert.ToDecimal(PrecioTextBox.Text);
            producto.Existencia = Convert.ToInt32(ExistenciaTextBox.Text);

            bool inserto = conexion.InsertarProducto(producto);

            if (inserto)
            {
                MessageBox.Show("Producto registrado correctamente");
                producto = null;
                DescripcionTextBox.Clear();
                PrecioTextBox.Text = "";
                ExistenciaTextBox.Text = string.Empty;
                DescripcionTextBox.Focus();
            }
            else
            {
                MessageBox.Show("Error al registrar el producto");
            }

        }
    }
}
