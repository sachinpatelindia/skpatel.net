using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace SkPatelNet.Core.Infrastructure
{
    public class SkPatelEngine : IEngine
    {
        private  IServiceProvider _serviceProvider { get; set; }

        public void ConfigureRequestPipleline(IApplicationBuilder builder)
        {
            throw new NotImplementedException();
        }

        public IServiceProvider ConfigureService(IServiceCollection services, IConfiguration configuration)
        {
            var typeFinder = new WebAppTypeFinder();
            var startupConfigurations = typeFinder.FindClassesOfType<ISkPatelStartup>();
            var instances = startupConfigurations.Select(startup => (ISkPatelStartup)Activator.CreateInstance(startup))
                .OrderBy(startup => startup.Order);
            foreach (var instance in instances)
                instance.ConfigureServices(services, configuration);
            return _serviceProvider;
        }

        public T Resolve<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public object Resolve(Type type)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            throw new NotImplementedException();
        }

        public object ResolveUnregistered(Type t)
        {
            throw new NotImplementedException();
        }


        public virtual IServiceProvider ServiceProvider => _serviceProvider;
    }
}
