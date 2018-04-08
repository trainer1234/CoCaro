using CryptocurrencyAnalysisApp.Model.CoinsDetail;
using CryptocurrencyAnalysisApp.Presenter;
using CryptocurrencyAnalysisApp.View.CoinsDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptocurrencyAnalysisApp
{
    static class Program
    {
        public static CoinsDetailDataSource coinsDetailDataSource;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            coinsDetailDataSource = new CoinsDetailDataSource();
                        
            Application.Run(new MainForm());
        }
    }
}
