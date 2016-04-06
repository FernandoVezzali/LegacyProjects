namespace Store.Domain
{
    public class Category : ICategory
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Genre FirstGenre { get; set; }
    }
}
