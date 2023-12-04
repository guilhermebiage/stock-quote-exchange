using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;
using stock_quote_exchange.Configuration;
using stock_quote_exchange.Gateways;
using stock_quote_exchange.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace stock_quote_exchange.Extensions
{
    public static class ServiceConfigurationExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services.AddTransient<IStockService, StockService>();
        }

        public static IServiceCollection AddRefit(this IServiceCollection services, GatewayUrlSettings gatewayUrlSettings)
        {
            //services.AddMemoryCache();

            var settings = new RefitSettings(new NewtonsoftJsonContentSerializer(new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
            }));

            services.AddRefitClient<IStockGateway>(settings)
                .ConfigureHttpClient(c => c.BaseAddress = gatewayUrlSettings.StockApiUrl);

            return services;
        }
    }
}
