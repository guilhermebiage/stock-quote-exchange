using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace stock_quote_exchange
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //appconfiguration
        }
    }
}
