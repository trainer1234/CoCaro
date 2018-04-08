using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using CryptocurrencyAnalysisApp.Presenter;
using CryptocurrencyAnalysisApp.Model;
using System.Net;
using DevExpress.XtraGrid.Views.Grid;

namespace CryptocurrencyAnalysisApp.View.CoinsDetail
{
    internal partial class CoinsDetailView : UserControl, ICoinsDetailView
    {
        public CoinsDetailView()
        {
            InitializeComponent();
            CoinsDetailPresenter coinDetailPresenter = new CoinsDetailPresenter(this, Program.coinsDetailDataSource);            
        }

        public CoinsDetailPresenter Presenter { private get;  set; }

        public void LoadCoinList()
        {            
            Thread thread = new Thread(Presenter.LoadCoinsDetail);
            thread.IsBackground = true;
            thread.Start();
        }

        public void ShowCoinList(List<Coin> coins)
        {            
            MessageBox.Show("OK!");
            try
            {
                this.gridControlCoinDetail.DataSource = coins;
            }            
            catch(Exception ex)
            {

            }
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "Image" && e.IsGetData)
            {
                GridView view = sender as GridView;
                int rowHandle = view.GetRowHandle(e.ListSourceRowIndex);
                var request = WebRequest.Create("https://www.cryptocompare.com" + view.GetRowCellValue(rowHandle, "ImageUrl"));
                var response = request.GetResponse();
                var stream = response.GetResponseStream();
                e.Value = Bitmap.FromStream(stream);
            }
        }      
    }
}
