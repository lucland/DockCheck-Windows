using OpenCvSharp;
using OpenCvSharp.Dnn;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DockCheckWindows.UserControls
{
    public partial class UC_Cameras : UserControl
    {
        public UC_Cameras()
        {
            InitializeComponent();
            Task.Run(() => DetectMovement()); // Run on a separate thread
        }

        private Rect entradaCerca;
        private Rect saidaCerca;

        private void UpdateRectangles()
        {
            int x1 = (int)numericUpDown1.Value;
            int x2 = (int)numericUpDown2.Value;
            entradaCerca = new Rect(100, x1, 1000, 10);
            saidaCerca = new Rect(100, x2, 1000, 10);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            UpdateRectangles();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            UpdateRectangles();
        }

        private void DetectMovement()
        {
            UpdateRectangles();
            const int initializationFrames = 10;
            int currentFrame = 0;

            string cameraUrl = "rtsp://admin:admin12345678@192.168.200.100:554/cam/realmonitor?channel=2&subtype=0";
            //string cameraUrl = "C:\\Users\\lucas\\DockCheckWindows\\DockCheckWindows\\videoTeste.mp4";


            using (VideoCapture capture = new VideoCapture(cameraUrl))
            {
                if (!capture.IsOpened())
                {
                    Console.WriteLine("Erro ao abrir a câmera.");
                    return;
                }

                bool objetoNaEntrada = false;
                bool objetoNaSaida = false;

                int esquerdaParaDireita = 0;
                int direitaParaEsquerda = 0;

                var subtractor = BackgroundSubtractorMOG2.Create();

                while (true)
                {
                    Mat frame = new Mat();
                    Mat fgMask = new Mat();
                    Mat binFrame = new Mat();

                    try
                    {
                        capture.Read(frame);
                        if (frame.Empty())
                            break;

                        //pictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(frame);

                        subtractor.Apply(frame, fgMask);
                        Cv2.Threshold(fgMask, binFrame, 30, 255, ThresholdTypes.Binary);
                        Cv2.MorphologyEx(binFrame, binFrame, MorphTypes.Open, Cv2.GetStructuringElement(MorphShapes.Rect, new Size(10, 10)));

                        if (currentFrame < initializationFrames)
                        {
                            Console.WriteLine(currentFrame);
                            currentFrame++;
                            continue;
                        }

                        bool isDetectedInEntrada = Cv2.CountNonZero(binFrame.SubMat(entradaCerca)) > 0;
                        bool isDetectedInSaida = Cv2.CountNonZero(binFrame.SubMat(saidaCerca)) > 0;


                        if (isDetectedInEntrada)
                        {
                            objetoNaEntrada = true;
                        }

                        if (!isDetectedInEntrada && objetoNaEntrada && isDetectedInSaida)
                        {
                            esquerdaParaDireita++;
                            Console.WriteLine("Movimento da esquerda para direita detectado. Total: " + esquerdaParaDireita);
                            objetoNaEntrada = false;
                        }

                        if (isDetectedInSaida)
                        {
                            objetoNaSaida = true;
                        }

                        if (!isDetectedInSaida && objetoNaSaida && isDetectedInEntrada)
                        {
                            direitaParaEsquerda++;
                            Console.WriteLine("Movimento da direita para esquerda detectado. Total: " + direitaParaEsquerda);
                            objetoNaSaida = false;
                        }

                        Cv2.ImShow("Objeto em Movimento", binFrame);

                       // pictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(frame);

                        Cv2.Rectangle(frame, entradaCerca, Scalar.Green, 2);
                        Cv2.Rectangle(frame, saidaCerca, Scalar.Red, 2);
                        Cv2.PutText(frame, $"Esquerda para Direita: {esquerdaParaDireita}", new Point(10, 30), HersheyFonts.HersheySimplex, 1, Scalar.Blue, 2);
                        Cv2.PutText(frame, $"Direita para Esquerda: {direitaParaEsquerda}", new Point(10, 70), HersheyFonts.HersheySimplex, 1, Scalar.Magenta, 2);

                        // Convert the frame with drawings to Bitmap and set to pictureBox1
                        Invoke((MethodInvoker)delegate
                        {
                            pictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(frame);
                        });
                       //Cv2.ImShow("Detector de Movimento", frame);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        break;
                    }
                    finally
                    {
                        frame.Release();
                        fgMask.Release();
                        binFrame.Release();

                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                    }

                    if (Cv2.WaitKey(1) == 27) // Esc key
                        break;
                }
                Cv2.DestroyAllWindows();
            }
        }
    }
}