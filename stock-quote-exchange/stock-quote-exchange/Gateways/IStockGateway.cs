using Refit;
using stock_quote_exchange.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stock_quote_exchange.Gateways
{
    public interface IStockGateway
    {
        [Get("/api/stock(code)")]
        StockDto GetStockInformation(string code);
    }
}
