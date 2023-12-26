using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Windows.Forms;
using Image = System.Drawing.Image;

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
            labelIdentificacao.Text = identificacao;
            labelEmpresa.Text = empresa;
            labelCheckIn.Text = "De: " + checkin;
            labelCheckOut.Text = "Até: " + checkout;
            labelEmbarcacao.Text = "Embarcação: " + embarcacao;

            PrintSticker();
        }

        public void PrintSticker()
        {
            try
            {       
                    int width = panelFundo.Size.Width;
                    int height = panelFundo.Size.Height;
                    Bitmap bm = new Bitmap(width, height);
                    panelFundo.DrawToBitmap(bm, new System.Drawing.Rectangle(0, 0, width, height));
                    bm.Save(@"C:\compartilhamento\data_picture\qr\Qrcode10.png", ImageFormat.Png);


                    PrintDocument pd = new PrintDocument();
                    System.Drawing.Printing.PaperSize pkSize;
                    pkSize = pd.PrinterSettings.PaperSizes[57];
                    //   pd.DefaultPageSettings.PrinterResolution = new PrinterResolution() { Kind = PrinterResolutionKind.Medium };

                    pd.DefaultPageSettings.Landscape = true;
                    pd.PrintPage += (sender, args) =>
                    {
                        Image i = bm;
                        System.Drawing.Rectangle m = args.PageBounds;
                        args.Graphics.DrawImage(i, 20, 5, 296, 216);
                    };

                    //  bm.Save(@"C:\data_picture\qr\Qrcode10.png", ImageFormat.Png);
                    pd.Print();
                    pd.Print();
                    this.Hide();
            }
            catch
            {
                MessageBox.Show("A IMPRESSORA BROTHER QL810 ou QL800 NÃO ESTÁ DEFINIDA COMO IMPRESSORA PADRÃO, FAVOR DEFINIR NO PAINEL DE CONTROLE DO WINDOWS NA OPÇÃO (Dispositivos e Impressoras)!");
               // this.Hide();
               // panelFundo.Hide();

            }
        }
    }
}
