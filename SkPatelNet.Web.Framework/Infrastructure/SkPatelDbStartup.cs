using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkPatelNet.Core.Infrastructure;
using SkPatelNet.Web.Framework.Infrastructure.Extensions;

namespace SkPatelNet.Web.Framework.Infrastructure
{
    public class SkPatelDbStartup : ISkPatelStartup
    {
        public int Order => 2000;

        public void Configure(IApplicationBuilder applicationBuilder)
        {
            // throw new NotImplementedException();
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSkPatelNetDbContext(configuration);
            services.AddEntityFrameworkSqlServer();
            services.AddEntityFrameworkProxies();
        }
    }
}
