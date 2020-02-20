using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkPatelNet.Core.Infrastructure
{
    public class SkPatelStartup : ISkPatelStartup
    {
        public int Order { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Configure(IApplicationBuilder applicationBuilder)
        {
            throw new NotImplementedException();
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            throw new NotImplementedException();
        }
    }
}
