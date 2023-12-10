using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stock_quote_exchange.Services
{
    public interface IStockMonitorService
    {
        public Task MonitorStockAsync(string symbol, double buyThreshold, double sellThreshold);
    }
}
