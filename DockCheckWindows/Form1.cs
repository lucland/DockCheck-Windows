﻿using DockCheckWindows.Models;
using DockCheckWindows.Repositories;
using DockCheckWindows.Services;
using DockCheckWindows.UserControls;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
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

        private UC_Dados uc_Dados;

        private SerialPort serialPort;

        private AuthenticationRepository _authenticationRepository = new AuthenticationRepository(
                                   apiService: new ApiService()
                                                      );


        private UserRepository userRepository = new UserRepository(apiService: new ApiService());

        private VesselRepository vesselRepository = new VesselRepository(apiService: new ApiService());

        private AuthorizationRepository authorizationRepository = new AuthorizationRepository(apiService: new ApiService());

        public Form1()
        {
            CultureInfo newCulture = new CultureInfo("en");
            Thread.CurrentThread.CurrentCulture = newCulture;
            Thread.CurrentThread.CurrentUICulture = newCulture;
            String language = "en-US";
            Thread.CurrentThread.CurrentCulture = new CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

            InitializeComponent();

            Login loginForm = new Login(
                authenticationRepository: _authenticationRepository
                );
            loginForm.ShowDialog();

            if (loginForm.IsAuthenticated)
            {
                BackgroundTaskManager backgroundTaskManager = new BackgroundTaskManager(userRepository: userRepository);
                backgroundTaskManager.StartBackgroundTask();

                UC_Home home = new UC_Home();

                uc_Cadastrar = new UC_Cadastrar(
                    userRepository: new UserRepository(apiService: new ApiService()),
                    authorizationRepository: new AuthorizationRepository(apiService: new ApiService()),
                    ucDados: new UC_Dados(uc_Cadastrar, userRepository: new UserRepository(apiService: new ApiService())));

                uc_Dados = new UC_Dados(uc_Cadastrar, userRepository: new UserRepository(apiService: new ApiService()));

                loggedUserName(Properties.Settings.Default.UserId);

                addUserControl(home);
            }
            else
            {
                Application.Exit();
            }
            cadastroButton.Text = Properties.Resources.Cadastrar;
        }

        //retieve user object from user_id with UserRepository
        private async void loggedUserName(String userId)
        {
            var user = await userRepository.GetUserByIdAsync(userId);
            Console.WriteLine("User: " + user.ToJson());

            labelUser.Text = user.Name;
            Properties.Settings.Default.Name = user.Name;
            Properties.Settings.Default.Save();
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
            UC_Cadastrar cadastrar = new UC_Cadastrar(
                userRepository: new UserRepository(apiService: new ApiService()),
                authorizationRepository: new AuthorizationRepository(apiService: new ApiService()),
                ucDados: new UC_Dados(uc_Cadastrar, userRepository: new UserRepository(apiService: new ApiService()))
                );
            cadastrar.SwitchToDados += () =>
            {
                addUserControl(uc_Dados);
            };
            addUserControl(cadastrar);
        }

        private void dashboardButton_Click(object sender, EventArgs e)
        {
            UC_Dashboard dashboard = new UC_Dashboard();
            addUserControl(dashboard);
        }

        private void bancoButton_Click(object sender, EventArgs e)
        {
            UC_Dados dados = new UC_Dados(uc_Cadastrar, userRepository: new UserRepository(apiService: new ApiService()));  // Pass the instance field
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

        private async void fecharButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Token = "";
            Properties.Settings.Default.Save();

            Console.WriteLine(Properties.Settings.Default.Token);
            Console.WriteLine(Properties.Settings.Default.UserId);

            await _authenticationRepository.LogoutAsync(Properties.Settings.Default.UserId);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            //retrieve authorization from settings
            string authorization = Properties.Settings.Default.Authorization;
            //split the authorizations by comma
            var authorizationIds = authorization.Split(',');

            List<string> vesselNames = new List<string>();
            List<string> vesselIds = new List<string>();

            foreach (var authId in authorizationIds)
            {
                var authorizationComplete = await authorizationRepository.GetAuthorizationByIdAsync(authId);

                if (authorizationComplete != null)
                {
                    string vesselId = authorizationComplete.VesselId;
                    var vessel = await vesselRepository.GetVesselByIdAsync(vesselId);
                    if (vessel != null)
                    {
                        //save the Vessel Name, Vessel IDs into our settings
                        vesselNames.Add(vessel.Name);
                        vesselIds.Add(vessel.Id);
                    }

                    Properties.Settings.Default.Vessel = string.Join(",", vesselNames);
                    Properties.Settings.Default.VesselId = string.Join(",", vesselIds);
                    Properties.Settings.Default.Save();

                }
                
            }
        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelUser_Click(object sender, EventArgs e)
        {

        }

        async private void vesselLabel_Click(object sender, EventArgs e)
        {
            //retrieve authorization from settings
            string authorization = Properties.Settings.Default.Authorization;
            //retieve vessel object from authorization with VesselRepository
            VesselRepository vesselRepository = new VesselRepository(apiService: new ApiService());
            AuthorizationRepository authorizationRepository = new AuthorizationRepository(apiService: new ApiService());
            Authorization authorization1 = await authorizationRepository.GetAuthorizationByIdAsync(authorization);
            Vessel vessel = await vesselRepository.GetVesselByIdAsync(authorization1.VesselId);
     
            if (vessel != null)
            {
                //save vessel name in settings and write in label
                Properties.Settings.Default.Vessel = vessel.Name;
                Properties.Settings.Default.Save();

                //save vessel id in settings and write in label
                Properties.Settings.Default.VesselId = vessel.Id;
                Properties.Settings.Default.Save();

                vesselLabel.Text = vessel.Name;
            }
            Console.WriteLine("Vessel: " + vessel.ToJson());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
