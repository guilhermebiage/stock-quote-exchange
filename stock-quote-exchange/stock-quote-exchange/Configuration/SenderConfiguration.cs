﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stock_quote_exchange.Configuration
{
    public sealed class SenderConfiguration
    {
        public string SenderEmail {  get; set; }

        public string SenderName {  get; set; }

        public string SenderPassword { get; set; }
    }
}
