using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stock_quote_exchange.Builder
{
    public class CommandConfigurationBuilder
    {
        public static string[] Build(string[] args)
        {
            _ = args ?? throw new ArgumentNullException(nameof(args));

            return new string[] { $"symbol={args[0]}", $"sellThreshold={args[1]}", $"buyThreshold={args[2]}" };
        }
    }
}
