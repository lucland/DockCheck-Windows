using System;
using System.Windows.Forms;

namespace DockCheckWindows
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            /*FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("path/to/serviceAccountKey.json"),
            });*/
        }
    }
}
