using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SkPatelNet.Core.Infrastructure
{
    public interface ISkPatelStartup
    {
        void ConfigureServices(IServiceCollection services, IConfiguration configuration);
        void Configure(IApplicationBuilder applicationBuilder);
        int Order { get; }
    }
}