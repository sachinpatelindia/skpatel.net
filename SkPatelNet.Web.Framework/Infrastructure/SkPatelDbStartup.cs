using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkPatelNet.Core.Infrastructure;

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
            // throw new NotImplementedException();
        }
    }
}
