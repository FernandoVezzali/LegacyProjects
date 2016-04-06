using System.Collections.Generic;

namespace codesnippets.Models
{
    public class Language
    {
        public Language()
        {
            LanguageVersions = new List<LanguageVersion>();
        }
        public virtual ICollection<LanguageVersion> LanguageVersions { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
