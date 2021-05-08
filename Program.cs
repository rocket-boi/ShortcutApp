using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Shortcut_App
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        private static Mutex mutex = null;

        [STAThread]

        static void Main(string[] args)
        {

            const string appName = "ShortCutApp Instance";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool createdNew;

            mutex = new Mutex(true, appName, out createdNew);

            if (!createdNew)
            {
                MessageBox.Show("There is already one instance of Shortcut App open.");
                return;
            }
            Application.Run(new MainPage());
        }
    }

    public static class Global
    {
        public static string BaseDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MANASLU Apps");
    }
    
    public class ShortCut
    {
        public string Name;
        public string Command;
        public Keys Key;
        public Keys Augument;

        public ShortCut()
        {

        }

        public ShortCut(string command, Keys key, Keys augument)
        {
            Command = command;
            Key = key;
            Augument = augument;
        }
    }
}
