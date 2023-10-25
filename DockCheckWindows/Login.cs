using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DockCheckWindows
{
    public partial class Login : Form
    {
        public bool IsAuthenticated { get; private set; }


        public Login()
        {
            InitializeComponent();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            // Close the application
            Application.Exit();
           
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            // For now, hardcoding username and password
            if (textBoxUsuario.Text == "admin" && textBoxSenha.Text == "123456789")
            {
                IsAuthenticated = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void textBoxUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelSenha_Click(object sender, EventArgs e)
        {

        }

        private void labelUsuario_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
