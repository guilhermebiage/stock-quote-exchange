using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stock_quote_exchange.Dto
{
    public sealed class StockDto
    {
        [JsonProperty("01. symbol")]
        public string Symbol { get; set; }

        [JsonProperty("05. price")]
        public string Price { get; set; }
    }
}
