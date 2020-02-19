using System;
using System.Collections.Generic;
using System.Text;

namespace SkPatelNet.Core.Domain.Customers
{
    public partial class Customer:BaseEntity
    {
        public Guid CustomerGuid { get; set; } = Guid.NewGuid();
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
