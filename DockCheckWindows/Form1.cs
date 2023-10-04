using DockCheckWindows.UserControls;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            UC_Home home = new UC_Home();
            addUserControl(home);
        }

        private void addUserControl(UserControl userControl) {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            UC_Home home = new UC_Home();
            addUserControl(home);
        }

        private void cadastroButton_Click(object sender, EventArgs e)
        {
            UC_Cadastrar cadastrar = new UC_Cadastrar();
            addUserControl(cadastrar);
        }

        private void dashboardButton_Click(object sender, EventArgs e)
        {
            UC_Dashboard dashboard = new UC_Dashboard();
            addUserControl(dashboard);
        }

        private void bancoButton_Click(object sender, EventArgs e)
        {
            UC_Dados dados = new UC_Dados();
            addUserControl(dados);
        }

        private void cameraButton_Click(object sender, EventArgs e)
        {
            UC_Cameras cameras = new UC_Cameras();
            addUserControl(cameras);
        }

        private void fecharButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
