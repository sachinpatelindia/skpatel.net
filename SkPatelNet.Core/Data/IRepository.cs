using System.Linq;

namespace SkPatelNet.Core.Data
{
    public partial interface IRepository<TEntity> where TEntity:BaseEntity
    {
        void Add(TEntity entity);
        void Edit(TEntity entity);
        void Delete(TEntity entity);
        IQueryable<TEntity> Data { get; }
    }
}
