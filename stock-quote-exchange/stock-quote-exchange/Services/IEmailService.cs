using stock_quote_exchange.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stock_quote_exchange.Services
{
    public interface IEmailService
    {
        public Task SendEmailAsync(string symbol, string price, double threshold, ThresholdType thresholdType);
    }
}
