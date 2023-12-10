using stock_quote_exchange.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stock_quote_exchange.Services
{
    public interface IStockService
    {
        public Task<StockResponse> GetStockAsync(string Code);
    }
}
