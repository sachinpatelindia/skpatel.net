using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SkPatelNet.Data.Mapping
{
    public partial class SkPatelNetQueryTypeConfiguration<TQuery> : IMappingConfiguration, IQueryTypeConfiguration<TQuery> where TQuery : class
    {
        public virtual void ApplyConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(this);
        }

        public virtual void Configure(QueryTypeBuilder<TQuery> builder)
        {
            PostConfigure(builder);
        }

        protected virtual void PostConfigure(QueryTypeBuilder<TQuery> builder)
        {
           
        }
    }
}
