using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using stock_quote_exchange.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stock_quote_exchange.Jobs
{
    public class StockQuoteJob : BackgroundService
    {
        private ILogger<StockQuoteJob> _logger;
        private readonly PeriodicTimer _timer = new(TimeSpan.FromMinutes(5));
        private IStockMonitorService _stockService;
        private IConfiguration _configuration;

        public StockQuoteJob(IStockMonitorService stockService,
                            IConfiguration configuration,
                            ILogger<StockQuoteJob> logger)
        {
            _logger = logger;
            _stockService = stockService;
            _configuration = configuration;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"Executing StockQuoteJob at {DateTime.Now}");

            var symbol = _configuration.GetSection("symbol").Get<string>();
            var sellThreshold = _configuration.GetSection("sellThreshold").Get<string>();
            var buyThreshold = _configuration.GetSection("buyThreshold").Get<string>();

            await _stockService.MonitorStockAsync(symbol, double.Parse(sellThreshold), double.Parse(buyThreshold));

            while (await _timer.WaitForNextTickAsync(stoppingToken)
                && !stoppingToken.IsCancellationRequested)
            {
                await _stockService.MonitorStockAsync(symbol, double.Parse(sellThreshold), double.Parse(buyThreshold));
            }
        }
    }
}
