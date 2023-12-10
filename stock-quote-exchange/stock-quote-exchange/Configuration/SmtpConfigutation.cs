using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stock_quote_exchange.Configuration
{
    public sealed class SmtpConfigutation
    {
        public string Server {  get; set; }

        public int Port { get; set; }
    }
}
