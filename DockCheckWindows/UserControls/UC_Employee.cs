﻿using DockCheckWindows.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace DockCheckWindows.UserControls
{
    public partial class UC_Employee : UserControl
    {
        readonly string name;
        readonly string empresa;
        readonly string identificacao;
        readonly string checkin;
        readonly string checkout;
        readonly string embarcacao;
        readonly string id;
        readonly string role;

        //Employee Repository
        private readonly EmployeeRepository _employeeRepository;

        private SerialPort _serialPort;

        public UC_Employee()
        {
            InitializeComponent();
        }

        public UC_Employee(string name, string identificacao, string empresa, string checkin, string checkout, string embarcacao, EmployeeRepository employeeRepository, string role, string id)
        {
            InitializeComponent();
            this.name = name;
            this.identificacao = identificacao;
            this.empresa = empresa;
            this.checkin = checkin;
            this.checkout = checkout;
            this.embarcacao = embarcacao;
            this.role = role;
            _employeeRepository = employeeRepository;
            this.id = id;
        }

        private async void printButton_Click(object sender, EventArgs e)
        {
            // Check if textBoxRFID is empty
            if (string.IsNullOrEmpty(textBoxRFID.Text))
            {
                MessageBox.Show("Por favor, insira um Beacon válido.");
            }
            else
            {
                // Remove any space or additional line \n \r if there is any from the textBoxRFID
                textBoxRFID.Text = textBoxRFID.Text.Trim();

                await _employeeRepository.UpdateAreaAsync(id, textBoxRFID.Text);

                // Continue with the rest of your logic only if there is no error
                if (!textBoxRFID.Text.StartsWith("Error:"))
                {
                    // TODO: Get vessel name from user authorization
                    string vesselName = "Skandi Salvador";
                    var ucEtiqueta = new UC_Etiqueta(
                        role: role,
                        name: name,
                        identificacao: identificacao,
                        embarcacao: vesselName,
                        empresa: empresa,
                        checkin: DateTime.Now.ToString("dd/MM/yyyy"),
                        checkout: "-"
                    );
                    ucEtiqueta.Location = new Point(0, 0);
                    ucEtiqueta.Size = new Size(353, 288);
                    Controls.Add(ucEtiqueta);
                    ucEtiqueta.BringToFront();
                    ucEtiqueta.Show();
                }
            }
        }

        private async void lerTagButton_Click(object sender, EventArgs e)
        {
            await _employeeRepository.UpdateAreaAsync(id, textBoxRFID.Text.Trim());
            if (!textBoxRFID.Text.StartsWith("Error:"))
            {
                this.Hide();
            }
        }


        private async void leriTagButton_Click(object sender, EventArgs e)
        {
            try
            {
                //open serial port COM3 with 115200 band
                SerialPort serialPort = new SerialPort("COM6", 115200);
                //send command "L1" to the serial port and read the response
                if (!serialPort.IsOpen)
                {
                    serialPort.Open();
                }
                serialPort.WriteLine("L2");
                serialPort.WriteLine("L1");
                serialPort.WriteLine("L1");
                string rfid = serialPort.ReadLine();
                textBoxRFID.Text = rfid;
                if (serialPort.IsOpen)
                {
                    serialPort.WriteLine("L2");
                    serialPort.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void guna2ButtonCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void UC_Employee_Load(object sender, EventArgs e)
        {

        }
    }
}
