using Alturos.Yolo;
using OpenCvSharp;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DockCheckWindows.UserControls
{
    public partial class UC_Cameras : UserControl
    {
        public UC_Cameras()
        {
            InitializeComponent();
          //Task.Run(() => DetectMovement());
        }

        private bool isDisposed = false;
        private Point lastCenter = new Point(0, 0);
        private bool isLastCenterSet = false;

        private void DetectMovement()
        {
            var yoloConfig = new YoloConfiguration(configFile: "C:\\Users\\lucas\\DockCheckWindows\\DockCheckWindows\\yolov3-tiny.cfg",
                                                     weightsFile: "C:\\Users\\lucas\\DockCheckWindows\\DockCheckWindows\\yolov3-tiny.weights",
                                                     namesFile: "C:\\Users\\lucas\\DockCheckWindows\\DockCheckWindows\\coco.names");

            var yoloWrapper = new YoloWrapper(configurationFilename: "C:\\Users\\lucas\\DockCheckWindows\\DockCheckWindows\\yolov3-tiny.cfg", weightsFilename: "C:\\Users\\lucas\\DockCheckWindows\\DockCheckWindows\\yolov3-tiny.weights", namesFilename: "C:\\Users\\lucas\\DockCheckWindows\\DockCheckWindows\\coco.names");

            string cameraUrl = "rtsp://admin:admin12345678@192.168.1.108:554/cam/realmonitor?channel=1&subtype=0";

            using (var capture = new VideoCapture(0))
            {
                if (!capture.IsOpened())
                {
                    Console.WriteLine("Error opening the camera.");
                    return;
                }

                while (!isDisposed)
                {
                    using (var frame = new Mat())
                    {
                        capture.Read(frame);
                        if (frame.Empty())
                            break;
                        // Save frame to temporary jpg file
                        var tempPath = Path.GetTempFileName() + ".jpg";
                        frame.SaveImage(tempPath);

                        // Perform detection
                        var items = yoloWrapper.Detect(tempPath);
                        File.Delete(tempPath);

                        foreach (var item in items)
                        {
                            if (item.Type == "person")
                            {
                                var currentCenter = new Point(item.X + item.Width / 2, item.Y + item.Height / 2);

                                if (isLastCenterSet)
                                {
                                    string direction = currentCenter.Y > lastCenter.Y ? "Saindo" : "Entrando";
                                    Cv2.PutText(frame, direction, new Point(10, 110), HersheyFonts.HersheySimplex, 1, Scalar.Yellow, 2);
                                }

                                lastCenter = currentCenter;
                                isLastCenterSet = true;
                            }
                        }

                        Invoke((MethodInvoker)delegate
                        {
                            pictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(frame);
                        });
                    }

                    if (Cv2.WaitKey(1) == 27) // Esc key
                        break;
                }

                Cv2.DestroyAllWindows();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                isDisposed = true;
            }
            base.Dispose(disposing);
        }
    }
}
