namespace codesnippets.Models
{
    public class LanguageVersion
    {
        public int Id { get; set; }
        public string Version { get; set; }

        public virtual Language Language { get; set; }
    }
}
