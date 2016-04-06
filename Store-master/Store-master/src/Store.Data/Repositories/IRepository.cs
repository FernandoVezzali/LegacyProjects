using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Store.Data
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> All { get; }
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        T Find(int id);
        void InsertOrUpdate(T entity);
        void Delete(int id);
        void Save();
        void Dispose();
    }
}
