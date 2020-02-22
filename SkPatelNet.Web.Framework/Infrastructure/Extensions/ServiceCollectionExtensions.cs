using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using SkPatelNet.Core.Infrastructure;
using System;

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

        public static void AddSkPatelAuthentication(this IServiceCollection services)
        {
           // services.AddAuthentication();
        }
    }
}
