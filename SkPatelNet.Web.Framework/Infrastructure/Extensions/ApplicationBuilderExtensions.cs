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
    }
}
