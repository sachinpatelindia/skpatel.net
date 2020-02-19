using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkPatelNet.Core.Data
{
    public interface IRepository<T> where T:BaseEntity
    {
        void Add(T entity);
        void Edit(T entity);
        void Delete(T entity);
        IQueryable<T> Data { get; set; }
    }
}
