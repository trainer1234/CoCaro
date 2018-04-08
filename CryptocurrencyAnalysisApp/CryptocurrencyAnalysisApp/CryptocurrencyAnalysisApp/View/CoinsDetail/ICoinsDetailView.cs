using CryptocurrencyAnalysisApp.Model;
using CryptocurrencyAnalysisApp.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyAnalysisApp.View.CoinsDetail
{
    interface ICoinsDetailView
    {
        CoinsDetailPresenter Presenter { set; }
        void ShowCoinList(List<Coin> coins);
    }
}
