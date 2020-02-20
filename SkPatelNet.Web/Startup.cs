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
        public Startup(IConfiguration configuration,IWebHostEnvironment webHostEnvironment)
        {
            _configuration = configuration;
            _webHostingEnvironment = webHostEnvironment;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddScoped<ISkPatelFileProvider, SkPatelFileProvider>();
            // services.AddScoped<ITypeFinder, AppDomainTypeFinder>();

            // var engineContext = EngineContext.Create();
            //var provider= engineContext.ConfigureService(services,Configuration);
            // services.AddControllersWithViews();
            services.ConfigureApplicationServices(_configuration, _webHostingEnvironment.ContentRootPath);
            
    
        }

 
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}
            //app.UseHttpsRedirection();
            //app.UseStaticFiles();

            //app.UseRouting();

            // app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");
            //});

            app.ConfigureRequestPipeline();
        }
    }
}
