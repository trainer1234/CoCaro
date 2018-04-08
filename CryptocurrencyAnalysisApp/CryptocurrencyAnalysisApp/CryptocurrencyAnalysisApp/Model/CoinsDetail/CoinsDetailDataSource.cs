using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyAnalysisApp.Model.CoinsDetail
{
    class CoinsDetailDataSource : ICoinsDetailDataSource
    {
        private CoinsDetailLocalDataSource localDataSource;

        private CoinsDetailRemoteDataSource remoteDataSource;

        public CoinsDetailDataSource()
        {
            localDataSource = new CoinsDetailLocalDataSource();
            remoteDataSource = new CoinsDetailRemoteDataSource();
        }
        public List<Coin> LoadCoinsDetail()
        {
            return remoteDataSource.LoadCoinsDetail();
        }
    }
}
