using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stock_quote_exchange.Dto
{
    public sealed class StockResponse
    {
        [JsonProperty("Global Quote")]
        public StockDto Stock { get; set; }
    }
}
