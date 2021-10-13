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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        ConexionDB conexion = new ConexionDB();
        Usuario user = new Usuario();

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "Ingrese el codigo de usuario");
                textBox1.Focus();
                return;
            }
            if (textBox2.Text == "")
            {
                errorProvider1.SetError(textBox2, "Ingrese la contraseña del usuario");
                textBox2.Focus();
                return;
            }

            user.Codigo = textBox1.Text;
            user.Clave = textBox2.Text;


            bool valido = conexion.ValadirUsuario(user);

            if (valido)
            {
                ProductosForm formulario = new ProductosForm();
                this.Hide();
                formulario.Show();

            }
            else
            {
                MessageBox.Show("Datos de Usuario Incorrectos", "Titulo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
