using Microsoft.EntityFrameworkCore;
using SkPatelNet.Core;

namespace SkPatelNet.Data
{
    public interface ISkPatelNetDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        int SaveChanges();
        void Detach<TEntity>(TEntity entity) where TEntity : BaseEntity;
    }
}
