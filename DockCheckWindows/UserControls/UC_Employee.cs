using DockCheckWindows.Repositories;
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
        readonly string role;

        //Employee Repository
        private readonly EmployeeRepository _employeeRepository;

        private SerialPort _serialPort;

        public UC_Employee()
        {
            InitializeComponent();
        }

        public UC_Employee(string name, string identificacao, string empresa, string checkin, string checkout, string embarcacao, EmployeeRepository employeeRepository, string role)
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
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            //check if textBoxRFID is empty
            if (string.IsNullOrEmpty(textBoxRFID.Text))
            {
                MessageBox.Show("Por favor, insira um Beacon válido.");
            }
            else
            {
                //TODO: get vessel name from user authorization
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

        private async void leriTagButton_Click(object sender, EventArgs e)
        {
                try
                {

                    if (_serialPort == null)
                    {
                        _serialPort = new SerialPort("COM5", 115200)
                        {
                            ReadTimeout = 5000,
                            WriteTimeout = 500
                        };
                    }

                    if (!_serialPort.IsOpen)
                    {
                        _serialPort.Open();
                    }
                    _serialPort.WriteLine("L2");
                    await Task.Delay(1000);

                    _serialPort.WriteLine("L1"); // Command to read RFID tag

                    await Task.Delay(1000); // Wait for response

                    while (_serialPort.IsOpen && _serialPort.BytesToRead > 0)
                    {
                        string rfid = _serialPort.ReadLine();
                        textBoxRFID.Text = rfid;
                        _serialPort.WriteLine("L2");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
                finally
                {
                    if (_serialPort.IsOpen)
                    {
                        _serialPort.Close();
                    }
                    //   await _serialDataProcessor.ResumeProcessingAsync();
                }
            
        }

        private void guna2ButtonCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
