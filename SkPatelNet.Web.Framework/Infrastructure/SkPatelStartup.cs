using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkPatelNet.Core.Infrastructure;
using SkPatelNet.Web.Framework.Infrastructure.Extensions;

namespace SkPatelNet.Web.Framework.Infrastructure
{
    public class SkPatelStartup : ISkPatelStartup
    {
        public int Order => 1000;

        public void Configure(IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseSkPatelEndpoints();
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllersWithViews();
        }
    }
}
