using DockCheckWindows.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DockCheckWindows
{
    public partial class Form1 : Form
    {
        private UC_Cadastrar uc_Cadastrar;

        private SerialPort serialPort;

        public Form1()
        {
            CultureInfo newCulture = new CultureInfo("en");
            Thread.CurrentThread.CurrentCulture = newCulture;
            Thread.CurrentThread.CurrentUICulture = newCulture;
            String language = "en-US";
            Thread.CurrentThread.CurrentCulture = new CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

            InitializeComponent();

            // Show login form
            Login loginForm = new Login();
            loginForm.ShowDialog();

            // Check if authenticated
            if (loginForm.IsAuthenticated)
            {
                UC_Home home = new UC_Home();
                uc_Cadastrar = new UC_Cadastrar();
                addUserControl(home);
            }
            else
            {
                // Close the application if not authenticated
                Application.Exit();
            }
            cadastroButton.Text = Properties.Resources.Cadastrar;
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            foreach (Control control in panelContainer.Controls)
            {
                if (control != uc_Cadastrar)  // Skip disposing of uc_Cadastrar
                {
                    control.Dispose();
                }
            }
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
            UC_Dados dados = new UC_Dados(uc_Cadastrar);  // Pass the instance field
            dados.SwitchToCadastro += () =>
            {
                addUserControl(uc_Cadastrar);
            };
            addUserControl(dados);
        }

        private void cameraButton_Click(object sender, EventArgs e)
        {
            UC_Cameras cameras = new UC_Cameras();
            addUserControl(cameras);
        }

        private void fecharButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Token = "";
            Properties.Settings.Default.Save();

            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            //open LoginForm
            Login login = new Login();
            login.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            
    
        }

       
    }
}
