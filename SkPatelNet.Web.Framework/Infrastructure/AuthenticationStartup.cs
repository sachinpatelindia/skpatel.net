using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkPatelNet.Core.Infrastructure;
using SkPatelNet.Web.Framework.Infrastructure.Extensions;

namespace SkPatelNet.Web.Framework.Infrastructure
{
    public class AuthenticationStartup : ISkPatelStartup
    {
        public int Order => 200;

        public void Configure(IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseAuthentication();
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSkPatelAuthentication();
        }
    }
}
