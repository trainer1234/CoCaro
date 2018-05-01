using CoCaro.DAL.Context;
using CoCaro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoTheManager
{
    static class Program
    {
        public static DataSource DataSource;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CaroContext caroContext = new CaroContext();
            DataSource = new DataSource(caroContext);

            Application.Run(new MainForm());
        }
    }
}
