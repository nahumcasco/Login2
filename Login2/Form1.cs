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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ConexionDB conexion = new ConexionDB();
        Usuario user = new Usuario();

        private void button1_Click(object sender, EventArgs e)
        {
            user.Codigo = textBox1.Text;
            user.Clave = textBox2.Text;


            bool valido = conexion.ValadirUsuario(user);

            if (valido)
            {
                MessageBox.Show("Usuario correcto");
            }
            else
            {
                MessageBox.Show("Datos de Usuario Incorrectos");
            }

        }
    }
}
