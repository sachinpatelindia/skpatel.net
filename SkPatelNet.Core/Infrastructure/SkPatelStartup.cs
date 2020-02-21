using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SkPatelNet.Core.Infrastructure
{
    public class SkPatelStartup : ISkPatelStartup
    {
        public int Order => 1000;

        public void Configure(IApplicationBuilder applicationBuilder)
        {
           // throw new NotImplementedException();
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
           /// throw new NotImplementedException();
        }
    }
}
