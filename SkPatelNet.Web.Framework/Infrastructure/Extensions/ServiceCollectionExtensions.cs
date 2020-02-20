using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkPatelNet.Core.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;

namespace SkPatelNet.Web.Framework.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceProvider ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration, string webroot="")
        {
            services.AddHttpContextAccessor();
            CommonHelper.DefaultFileProvider = new PhysicalFileProvider(webroot);
            var engine = EngineContext.Create();
            var serviceProvider = engine.ConfigureService(services,configuration);

            return serviceProvider;
        }

        public static void AddHttpContextAccessor(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
