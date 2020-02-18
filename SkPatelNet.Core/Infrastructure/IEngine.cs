using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkPatelNet.Core.Infrastructure
{
    public interface IEngine
    {
        IServiceProvider ConfigureService(IServiceCollection services, IConfiguration configure);
        void ConfigureRequestPipleline(IApplicationBuilder builder);
        T Resolve<T>() where T : class;
        object Resolve(Type type);
        IEnumerable<T> ResolveAll<T>();
        object ResolveUnregistered(Type t);
    }
}
