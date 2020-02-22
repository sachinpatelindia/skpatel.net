using Microsoft.AspNetCore.Builder;
using SkPatelNet.Core.Infrastructure;

namespace SkPatelNet.Web.Framework.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void ConfigureRequestPipeline(this IApplicationBuilder applicationBuilder)
        {
            EngineContext.Current.ConfigureRequestPipleline(applicationBuilder);
        }

        public static void UseSkPatelEndpoints(this IApplicationBuilder application)
        {
            application.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
