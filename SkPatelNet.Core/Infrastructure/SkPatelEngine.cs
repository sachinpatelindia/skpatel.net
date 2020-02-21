using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SkPatelNet.Core.Infrastructure
{
    public class SkPatelEngine : IEngine
    {
        private  IServiceProvider _serviceProvider { get; set; }

        public void ConfigureRequestPipleline(IApplicationBuilder builder)
        {
            var typeFinder = Resolve<ITypeFinder>();
            var startupConfigurations = typeFinder.FindClassesOfType<ISkPatelStartup>();
            var instances = startupConfigurations
                .Select(startup => (ISkPatelStartup)Activator.CreateInstance(startup))
                .OrderBy(startup => startup.Order);

            foreach (var instance in instances)
                instance.Configure(builder);
        }

        protected IServiceProvider GetServiceProvider()
        {
            var accessor = ServiceProvider.GetService<IHttpContextAccessor>();
            var context = accessor.HttpContext;
            return context?.RequestServices ?? ServiceProvider;
        }

        public IServiceProvider ConfigureService(IServiceCollection services, IConfiguration configuration)
        {
            var typeFinder = new WebAppTypeFinder();
            var startupConfigurations = typeFinder.FindClassesOfType<ISkPatelStartup>();
            var instances = startupConfigurations.Select(startup => (ISkPatelStartup)Activator.CreateInstance(startup))
                .OrderBy(startup => startup.Order);
            foreach (var instance in instances)
                instance.ConfigureServices(services, configuration);

            RegisterDependencies(services,typeFinder);
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            return _serviceProvider;
        }

        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            var assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a=>a.FullName==args.Name);
            if (assembly != null)
                return assembly;
            var typeFinder = Resolve<ITypeFinder>();
            assembly = typeFinder.GetAssemblies().FirstOrDefault(a=>a.FullName==args.Name);
            return assembly;
        }

        public T Resolve<T>() where T : class
        {
            return (T)Resolve(typeof(T));
        }

        public object Resolve(Type type)
        {
            return GetServiceProvider().GetService(type);
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            return (IEnumerable<T>)GetServiceProvider().GetService(typeof(T));
        }

        //public object ResolveUnregistered(Type t)
        //{
        //    throw new NotImplementedException();
        //}

        protected virtual IServiceProvider RegisterDependencies(IServiceCollection services,ITypeFinder typeFinder)
        {
            services.AddSingleton<IEngine, SkPatelEngine>();
            services.AddSingleton<ITypeFinder, AppDomainTypeFinder>();
            _serviceProvider = services.BuildServiceProvider();

            return _serviceProvider;
        }
        public virtual IServiceProvider ServiceProvider => _serviceProvider;
    }
}
