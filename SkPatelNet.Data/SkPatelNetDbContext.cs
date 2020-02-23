using Microsoft.EntityFrameworkCore;
using SkPatelNet.Core;
using System;

namespace SkPatelNet.Data
{
    public class SkPatelNetDbContext:DbContext,ISkPatelNetDbContext
    {
        public SkPatelNetDbContext(DbContextOptions options):base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual new DbSet<TEntity> Set<TEntity>() where TEntity:BaseEntity
        {
            return base.Set<TEntity>();
        }
        public virtual void Detach<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            var entityEntry = Entry(entity);
            if (entityEntry == null)
                return;
            entityEntry.State = EntityState.Detached;
        }

    }
}
