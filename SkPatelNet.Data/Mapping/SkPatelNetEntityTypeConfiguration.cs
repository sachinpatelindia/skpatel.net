using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkPatelNet.Core;

namespace SkPatelNet.Data.Mapping
{
    public partial class SkPatelNetEntityTypeConfiguration<TEntity> : IMappingConfiguration,IEntityTypeConfiguration<TEntity> where TEntity:BaseEntity
    {

        protected virtual void PostConfigure(EntityTypeBuilder<TEntity> builder)
        {

        }

        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            PostConfigure(builder);
        }

        public virtual void ApplyConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(this);
        }
    }
}
