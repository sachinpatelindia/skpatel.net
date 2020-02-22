using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using SkPatelNet.Core.Infrastructure;
using SkPatelNet.Web.Framework.Infrastructure.Extensions;

namespace SkPatelNet.Web
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public readonly IWebHostEnvironment _webHostingEnvironment;
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _configuration = configuration;
            _webHostingEnvironment = webHostEnvironment;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureApplicationServices(_configuration, _webHostingEnvironment.ContentRootPath);

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.ConfigureRequestPipeline();
        }
    }
}
