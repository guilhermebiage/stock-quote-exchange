using Microsoft.Extensions.Hosting;
using stock_quote_exchange.Extensions;

namespace stock_quote_exchange
{
    class Program
    {
        static async void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddServices();
                });
        }
    }
}