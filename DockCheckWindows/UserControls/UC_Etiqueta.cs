using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO.Ports;
using System.Windows.Forms;

namespace DockCheckWindows.UserControls
{
    public partial class UC_Etiqueta : UserControl
    {
        readonly string name;
        readonly string identificacao;
        readonly string empresa;
        readonly string checkin;
        readonly string checkout;
        readonly string embarcacao;

        public UC_Etiqueta(string name, string identificacao, string empresa, string checkin, string checkout, string embarcacao)
        {
            InitializeComponent();
            this.name = name;
            this.identificacao = identificacao;
            this.empresa = empresa;
            this.checkin = checkin;
            this.checkout = checkout;
            this.embarcacao = embarcacao;
        }

        private void UC_Etiqueta_Load(object sender, EventArgs e)
        {
            labelNome.Text = name;
            labelIdentificacao.Text = "33";
            labelEmpresa.Text = empresa;
            labelCheckIn.Text = "De: " + checkin;
            labelCheckOut.Text = "Até: " + checkout;
            labelEmbarcacao.Text = embarcacao;

            PrintSticker();
        }

        public void PrintSticker()
        {
            try
            {
                Bitmap bm = GenerateBitmapFromPanel();

                // Convert bitmap to a format suitable for the printer
                byte[] printerCommands = ConvertImageToPrinterCommands(bm);

                // Send data to printer
                SendDataToPrinter("COM11", printerCommands);

                this.Hide();
                panelFundo.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Printing failed: {ex.Message}");
            }
        }

        private byte[] ConvertImageToPrinterCommands(Bitmap bitmap)
        {
            // Convert your bitmap to a byte array or a string of commands 
            // that your printer understands. This highly depends on your printer's command set.
            // You might need a third-party library or a custom implementation for this.
            // This is a placeholder for the conversion logic.
            return new byte[0]; // Replace this with actual conversion logic
        }

        private void SendDataToPrinter(string portName, byte[] data)
        {
            using (SerialPort printerPort = new SerialPort(portName))
            {
                printerPort.BaudRate = 9600; // Set appropriate baud rate
                printerPort.Parity = Parity.None;
                printerPort.StopBits = StopBits.One;
                printerPort.DataBits = 8;
                printerPort.Handshake = Handshake.None;

                printerPort.Open();
                printerPort.Write(data, 0, data.Length);
                printerPort.Close();
            }
        }

        private Bitmap GenerateBitmapFromPanel()
        {
            int width = panelFundo.Size.Width;
            int height = panelFundo.Size.Height;
            Bitmap bm = new Bitmap(width, height);
            panelFundo.DrawToBitmap(bm, new Rectangle(0, 0, width, height));
            bm.Save(@"C:\compartilhamento\data_picture\qr\Qrcode10.png", System.Drawing.Imaging.ImageFormat.Png);
            return bm;
        }

        private PrintDocument CreatePrintDocument(Bitmap bm)
        {
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.Landscape = true;
            pd.PrintPage += (sender, args) =>
            {
                Image i = bm;
                Rectangle m = args.PageBounds;
                args.Graphics.DrawImage(i, 20, 5, 296, 216);
            };
            return pd;
        }

        private void excludeImageButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void labelIdentificacao_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
