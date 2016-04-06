using Store.Domain;
using System;
using System.Linq;
using System.Data.Entity;
using Store.Domain.DataContexts;

namespace Store.Data
{
    public class UserRepository : IRepository<User>
    {
        DomainContext context = new DomainContext();

        public IQueryable<User> All
        {
            get { return context.Users; }
        }

        public IQueryable<User> AllIncluding(params System.Linq.Expressions.Expression<Func<User, object>>[] includeProperties)
        {
            IQueryable<User> query = context.Users;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public User Find(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertOrUpdate(User category)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /*public System.Threading.Tasks.Task Save()
        {
            throw new NotImplementedException();
        }*/

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
