using CryptocurrencyAnalysisApp.Model.CoinsDetail;
using CryptocurrencyAnalysisApp.View.CoinsDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyAnalysisApp.Presenter
{
    class CoinsDetailPresenter: ICoinsDetailPresenter
    {        
        ICoinsDetailView view;
        ICoinsDetailDataSource dataSource;
        public CoinsDetailPresenter(ICoinsDetailView view, ICoinsDetailDataSource dataSource)
        {
            this.view = view;
            view.Presenter = this;
            this.dataSource = dataSource;
        }

        public void LoadCoinsDetail()
        {
            view.ShowCoinList(this.dataSource.LoadCoinsDetail());
        }
    }
}
