using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkPatelNet.Core.Infrastructure;

namespace SkPatelNet.Web.Framework.Infrastructure
{
    public class SkPatelCommonStartup : ISkPatelStartup
    {
        public int Order => 100;

        public void Configure(IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseStaticFiles();
            applicationBuilder.UseRouting();
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            
        }
    }
}
