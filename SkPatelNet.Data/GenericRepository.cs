using Microsoft.EntityFrameworkCore;
using SkPatelNet.Core;
using SkPatelNet.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkPatelNet.Data
{
    public partial class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ISkPatelNetDbContext _dbContext;
        private DbSet<TEntity> _entities;
        public GenericRepository(ISkPatelNetDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public IQueryable<TEntity> Data => this.Entities;

        public virtual DbSet<TEntity> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _dbContext.Set<TEntity>();
                return _entities;
            }
        }

        public virtual void Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            try
            {
                this.Entities.Add(entity);
                _dbContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
