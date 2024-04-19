using DockCheckWindows.Models;
using DockCheckWindows.Repositories;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DockCheckWindows.UserControls
{
    public partial class UC_Blueprint : UserControl
    {
        private readonly SensorRepository _sensorRepository;
        private bool _isLoading = true;
        private Image _topViewImage;
        private Image _sideViewImage;
        private List<Sensor> _topViewSensors = new List<Sensor>();
        private List<Sensor> _sideViewSensors = new List<Sensor>();
        private int _selectedSensorIndex = -1;
        private bool _isMovingSensor = false;

        public UC_Blueprint(SensorRepository sensorRepository)
        {
            InitializeComponent();
            _sensorRepository = sensorRepository;
        }

        private async void UC_Blueprint_Load(object sender, EventArgs e)
        {
            // Show loading state
            ShowLoadingState();

            // Fetch sensor data asynchronously
            try
            {
                _topViewSensors = await _sensorRepository.GetAllSensorsAsync();

                _topViewSensors = _topViewSensors.OrderBy(sensor => sensor.Code).ToList();

                List<Sensor> _sideViewSensors = _topViewSensors.Where(sensor => sensor.InVessel == true).ToList();

                _sideViewSensors.RemoveAll(sensor => sensor.AreaId == "Acesso Interno");



                // Load images from resources
                _topViewImage = Properties.Resources.top_view_vessel;
                _sideViewImage = Properties.Resources.side_view_vessel;

                // Set images and sensors on the custom user control
                SetImagesAndSensors(_topViewImage, _sideViewImage, _topViewSensors, _sideViewSensors);
            }
            catch (Exception ex)
            {
                // Handle error
                MessageBox.Show("Failed to load sensor data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Hide loading state
                HideLoadingState();
            }
        }
            
        private void ShowLoadingState()
        {
            // Show loading state here, e.g., display a loading animation or message
            // For simplicity, let's disable the user control during loading
            guna2WinProgressIndicator1.Visible = true;
            guna2WinProgressIndicator1.Enabled = true;
            Enabled = false;
        }

        private void HideLoadingState()
        {
            // Hide loading state here
            // Re-enable the user control
            guna2WinProgressIndicator1.Enabled = false;
            guna2WinProgressIndicator1.Visible = false;
            Enabled = true;
        }

        public void SetImagesAndSensors(Image topViewImage, Image sideViewImage, List<Sensor> topViewSensors, List<Sensor> sideViewSensors)
        {
            _topViewImage = topViewImage;
            _sideViewImage = sideViewImage;
            _topViewSensors = topViewSensors;
            _sideViewSensors = sideViewSensors;
            Invalidate(); // Trigger redraw
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw top view image
            if (_topViewImage != null)
            {
                e.Graphics.DrawImage(_topViewImage, 24, 16);
            }

            // Draw side view image
            if (_sideViewImage != null)
            {
                e.Graphics.DrawImage(_sideViewImage, 24, _topViewImage.Height);
            }

            // Draw top view sensors
            foreach (Sensor sensor in _topViewSensors)
            {
                DrawSensor(e.Graphics, sensor, 20, 20);
            }

            // Draw side view sensors
            foreach (Sensor sensor in _sideViewSensors)
            {
                DrawSensor2(e.Graphics, sensor, 20, _topViewImage.Height);
            }
        }

        private void DrawSensor(Graphics g, Sensor sensor, int offsetX, int offsetY)
        {
            Font _font = new Font("Arial", 24);
            _font = new Font(_font, FontStyle.Bold);

            Font _font2 = new Font("Arial", 14);
            _font2 = new Font(_font2, FontStyle.Bold);

            int radius = 20; // Adjust as needed
            Rectangle circleRect = new Rectangle(sensor.LocationX - radius + offsetX, sensor.LocationY - radius + offsetY, radius * 2, radius * 2);
            g.FillEllipse(Brushes.IndianRed, circleRect);
            g.DrawString(sensor.BeaconsFound.Count.ToString() , _font2, Brushes.White, circleRect.X + 12, circleRect.Y + 12) ;
            g.DrawString(sensor.AreaId, _font, Brushes.DarkRed, circleRect.X, circleRect.Y + radius * 2);
        }

        private void DrawSensor2(Graphics g, Sensor sensor, int offsetX, int offsetY)
        {
            Font _font = new Font("Arial", 24);
            _font = new Font(_font, FontStyle.Bold);

            Font _font2 = new Font("Arial", 14);
            _font2 = new Font(_font2, FontStyle.Bold);

            int radius = 20; // Adjust as needed
            Rectangle circleRect = new Rectangle(sensor.LocationX - radius + offsetX, sensor.Code - radius + offsetY, radius * 2, radius * 2);
            g.FillEllipse(Brushes.IndianRed, circleRect);
            g.DrawString(sensor.BeaconsFound.Count.ToString(), _font2, Brushes.White, circleRect.X + 12, circleRect.Y + 12);
            g.DrawString(sensor.AreaId, _font, Brushes.DarkRed, circleRect.X, circleRect.Y + radius * 2);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            // Check if the click is within any sensor circle
            for (int i = 0; i < _topViewSensors.Count; i++)
            {
                int radius = 20; // Adjust as needed
                int distanceSquared = (e.X - _topViewSensors[i].LocationX) * (e.X - _topViewSensors[i].LocationX) + (e.Y - _topViewSensors[i].LocationY) * (e.Y - _topViewSensors[i].LocationY);
                if (distanceSquared <= radius * radius)
                {
                    _selectedSensorIndex = i;
                    _isMovingSensor = true;
                    break;
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (_selectedSensorIndex != -1 && _isMovingSensor)
            {
                Sensor movedSensor = _topViewSensors[_selectedSensorIndex];
                movedSensor.LocationX = e.X;
                movedSensor.LocationY = e.Y;

                // Check if the moved sensor is also in the side view sensor list
                if (_sideViewSensors.Any(s => s.Id == movedSensor.Id))
                {
                    UpdateSideViewSensor(movedSensor);
                }

                Invalidate(); // Redraw to show sensor movement
            }
        }

        private void UpdateSideViewSensor(Sensor topViewSensor)
        {
            // Assuming side view sensors are a subset of top view sensors
            Sensor sideViewSensor = _sideViewSensors.FirstOrDefault(s => s.Id == topViewSensor.Id);
            if (sideViewSensor != null)
            {
                // Side view sensor found, update its position
                sideViewSensor.LocationX = topViewSensor.LocationX; // Example, modify as needed for actual alignment logic
                Invalidate(); // Optional: Only if you need immediate visual feedback in UI
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            // Reset selected sensor and movement flag
            _selectedSensorIndex = -1;
            _isMovingSensor = false;
        }
    }
}