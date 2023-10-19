using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DockCheckWindows
{
    public partial class WebcamForm : Form
    {
        public Bitmap CapturedImage { get; private set; }
        private VideoCaptureDevice videoSource;

        public WebcamForm()
        {
            InitializeComponent();
            FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
            videoSource.Start();
        }

        private void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBoxWebcam.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void buttonCapture_Click(object sender, EventArgs e)
        {
            if (pictureBoxWebcam.Image != null)
            {
                CapturedImage = (Bitmap)pictureBoxWebcam.Image.Clone();
                videoSource.SignalToStop();
                videoSource.WaitForStop();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            videoSource.SignalToStop();
            videoSource.WaitForStop();
            this.Close();
        }
    }
}
