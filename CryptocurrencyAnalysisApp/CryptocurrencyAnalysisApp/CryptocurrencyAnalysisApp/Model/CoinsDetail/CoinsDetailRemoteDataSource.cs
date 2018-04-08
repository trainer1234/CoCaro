using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CryptocurrencyAnalysisApp.Model.CoinsDetail
{
    class CoinsDetailRemoteDataSource: ICoinsDetailDataSource
    {
        public CoinsDetailRemoteDataSource()
        {

        }
        public List<Coin> LoadCoinsDetail()
        {
            WebRequest request = WebRequest.Create("https://www.cryptocompare.com/api/data/coinlist/");
            request.Method = "GET";
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string jsonData = reader.ReadToEnd();

            response.Close();
            reader.Close();

            JObject jObject = JObject.Parse(jsonData);
            Dictionary<string, Coin> data = JsonConvert.DeserializeObject<Dictionary<string, Coin>>(jObject["Data"].ToString());
            List<Coin> coins = new List<Coin>();
            foreach(var keyPair in data)
            {
                Coin coin = keyPair.Value;
                //if(coin.ImageUrl != null)
                //{
                //    var imageRequest = WebRequest.Create("https://www.cryptocompare.com" + coin.ImageUrl);
                //    var imageResponse = imageRequest.GetResponse();
                //    var stream = imageResponse.GetResponseStream();
                //    try
                //    {
                //        coin.Image = Bitmap.FromStream(stream);
                //    }
                //    catch (Exception)
                //    {

                //    }
                    
                //    imageResponse.Close();
                //    stream.Close();
                //}                
                coins.Add(coin);                                
            }
            //coins.Sort();
            return coins;
        }
    }
}
