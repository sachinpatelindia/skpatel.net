using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkPatelNet.Core.Domain.Customers;

namespace SkPatelNet.Data.Mapping.Customers
{
    public partial class CustomerMap:SkPatelNetEntityTypeConfiguration<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(nameof(Customer));
            builder.HasKey(c=>c.Id);

            builder.Property(c=>c.UserName).HasMaxLength(1000);
            builder.Property(c => c.Email).HasMaxLength(1000);
            builder.Property(c => c.SystemName).HasMaxLength(400);
            builder.Property(c => c.EmailToRevalidated).HasMaxLength(1000);
            base.Configure(builder);
        }
    }
}
