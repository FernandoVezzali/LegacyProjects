using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using codesnippets.Models;

namespace codesnippets.Repositories
{
    public interface ILanguageRepository : IRepository<Language, int>, IDisposable
    {
        IEnumerable<Language> FindAll();
        IEnumerable<Language> Find(string text);
    }

    public class LanguageRepository : ILanguageRepository
    {
        private ApplicationDbContext db;

        public LanguageRepository()
        {
            db = new ApplicationDbContext();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public Language Get(int id)
        {
            var result = db.Language.FirstOrDefault(x => x.Id == id);
            return result;
        }

        public void Save(Language entity)
        {
            db.Language.Add(entity);
        }

        public void Delete(Language entity)
        {
            db.Language.Remove(entity);
        }

        public IEnumerable<Language> FindAll()
        {
            var result = db.Language.ToList();
            return result;
        }

        public IEnumerable<Language> Find(string text)
        {
            var result = db.Language.ToList().Where(x=>x.Name.ToUpper().Equals(text.ToUpper()));
            return result;
        }
    }
}
