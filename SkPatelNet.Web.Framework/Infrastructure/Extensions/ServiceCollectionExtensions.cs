using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using SkPatelNet.Core.Data;
using SkPatelNet.Core.Infrastructure;
using SkPatelNet.Data;
using SkPatelNet.Services.Customers;
using SkPatelNet.Web.Framework.UI;
using System;

namespace SkPatelNet.Web.Framework.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceProvider ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration, string webroot = "")
        {
            services.AddHttpContextAccessor();
            CommonHelper.DefaultFileProvider = new PhysicalFileProvider(webroot);
            var engine = EngineContext.Create();
            var serviceProvider = engine.ConfigureService(services, configuration);

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

        public static void AddRegisterDependency(this IServiceCollection services)
        {
            services.AddScoped<ISkPatelNetDbContext, SkPatelNetDbContext>();
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IPageHeadBuilder, PageHeadBuilder>();

        }

        public static void AddSkPatelNetDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<SkPatelNetDbContext>(options =>
            {
                options.UseSqlServerWithLazyLoading(services, configuration);
            });
        }
    }
}
