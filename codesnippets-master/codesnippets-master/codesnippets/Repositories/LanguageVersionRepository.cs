using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using codesnippets.Models;

namespace codesnippets.Repositories
{
    public interface ILanguageVersionRepository : IRepository<LanguageVersion, int>, IDisposable
    {
        IEnumerable<LanguageVersion> FindAll();
        IEnumerable<LanguageVersion> Find(string text);
        IEnumerable<LanguageVersion> FindByLanguageId(int languageId);
    }

    public class LanguageVersionRepository: ILanguageVersionRepository
    {
        private ApplicationDbContext db;

        public LanguageVersionRepository()
        {
            db = new ApplicationDbContext();
        }

        public LanguageVersion Get(int id)
        {
            var result = db.LanguageVersion.FirstOrDefault(x => x.Id == id);
            return result;
        }

        public void Save(LanguageVersion entity)
        {
            db.LanguageVersion.Add(entity);
        }

        public void Delete(LanguageVersion entity)
        {
            db.LanguageVersion.Remove(entity);
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<LanguageVersion> FindAll()
        {
            var result = db.LanguageVersion.ToList();
            return result;
        }

        public IEnumerable<LanguageVersion> Find(string text)
        {
            var result = db.LanguageVersion.ToList().Where(x => x.Version.ToUpper().Equals(text.ToUpper()));
            return result;
        }

        public IEnumerable<LanguageVersion> FindByLanguageId(int languageId)
        {
            var result = db.LanguageVersion.ToList().Where(x => x.Language.Id.Equals(languageId));
            return result;
        }
    }
}
