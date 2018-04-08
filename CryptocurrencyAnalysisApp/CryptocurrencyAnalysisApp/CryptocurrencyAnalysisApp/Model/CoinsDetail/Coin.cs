using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyAnalysisApp.Model
{
    class Coin
    {
        [JsonProperty]
        public int Id { get; set; }
        [JsonProperty]
        public string Url { get; set; }
        [JsonProperty]
        public string ImageUrl { get; set; }
        [JsonProperty]
        public string Name { get; set; }
        [JsonProperty]
        public string CoinName { get; set; }
        [JsonProperty]
        public string FullName { get; set; }
        [JsonProperty]
        public string Algorithm { get; set; }
        [JsonProperty]
        public string ProofType { get; set; }
        [JsonProperty]
        public int SortOrder { get; set; }       
    }
}
