using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkPatelNet.Web.Infrastructure.Singleton
{
    public class ServiceContext
    {
        IHttpContextAccessor _httpContextAccessor;
        public ServiceContext(IHttpContextAccessor httpContextAccessor)
        {
            this.HttpContextAccessor = httpContextAccessor;
        }
        
        public IHttpContextAccessor HttpContextAccessor { get; set; }
    }
}
