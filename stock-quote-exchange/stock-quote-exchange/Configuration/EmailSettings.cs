using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stock_quote_exchange.Configuration
{
    public sealed class EmailSettings
    {
        public SmtpConfigutation SmtpConfiguration {  get; set; }

        public SenderConfiguration SenderConfiguration { get; set; }

        public ReceiverConfiguration ReceiverConfiguration { get; set; }
    }
}
