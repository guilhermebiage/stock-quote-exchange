using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using stock_quote_exchange.Builder;
using stock_quote_exchange.Configuration;
using stock_quote_exchange.Extensions;

namespace stock_quote_exchange
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    _ = args ?? throw new ArgumentNullException(nameof(args));
                    var arguments = CommandConfigurationBuilder.Build(args);

                    IConfiguration configuration = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .AddCommandLine(arguments)
                        .Build();

                    services.AddSingleton<IConfiguration>(configuration);
                    services.AddConfiguration(configuration);
                    services.AddLogging();
                    services.AddGateways(configuration.GetSection("GatewaysUrl").Get<GatewayUrlSettings>());
                    services.AddServices();                    
                });
        }
    }
}