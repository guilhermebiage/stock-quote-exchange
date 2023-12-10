using Microsoft.Extensions.Logging;
using stock_quote_exchange.Dto;
using stock_quote_exchange.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stock_quote_exchange.Services
{
    public class StockService : IStockService
    {
        private IStockGateway _gateway;
        //private ILogger _logger;

        public StockService(IStockGateway gateway) 
        {
            _gateway = gateway;
            //_logger = logger;
        }
        public async Task<StockResponse> GetStockAsync(string symbol)
        {
            _ = symbol ?? throw new ArgumentNullException(nameof(symbol));

            return await _gateway.GetStockInformationAsync(symbol);
        }
    }
}
