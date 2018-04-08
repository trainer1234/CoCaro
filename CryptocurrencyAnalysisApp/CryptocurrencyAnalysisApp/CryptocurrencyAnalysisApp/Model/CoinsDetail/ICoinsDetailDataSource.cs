using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyAnalysisApp.Model.CoinsDetail
{
    interface ICoinsDetailDataSource
    {
        List<Coin> LoadCoinsDetail();
    }
}
