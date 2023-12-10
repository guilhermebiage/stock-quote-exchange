using Microsoft.Extensions.Logging;
using stock_quote_exchange.Constants;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stock_quote_exchange.Services
{
    public class StockMonitorService : IStockMonitorService
    {
        private IStockService _stockService;
        private IEmailService _emailService;
        private ILogger<StockMonitorService> _logger;

        public StockMonitorService(IStockService stockService,
                                   IEmailService emailService,
                                   ILogger<StockMonitorService> logger)
        {
            _stockService = stockService;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task MonitorStockAsync(string symbol, double buyThreshold, double sellThreshold)
        {
            _ = symbol ?? throw new ArgumentNullException(nameof(symbol));

            var stockResponse = await _stockService.GetStockAsync(symbol);
            var stock = stockResponse.Stock;

            if (stock is null)
            {
                return;
            }

            if (double.Parse(stock.Price, CultureInfo.InvariantCulture) >= sellThreshold)
            {
                _logger.LogInformation($"Alerting sell operation for {symbol}");
                _ =_emailService.SendEmailAsync(symbol, stock.Price, sellThreshold, ThresholdType.Sell);
            }
            else if (double.Parse(stock.Price, CultureInfo.InvariantCulture) <= buyThreshold)
            {
                _logger.LogInformation($"Alerting buy operation for {symbol}");
                _ = _emailService.SendEmailAsync(symbol, stock.Price, buyThreshold, ThresholdType.Buy);
            }
        }
    }
}
