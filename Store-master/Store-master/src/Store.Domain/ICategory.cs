namespace Store.Domain
{
    public interface ICategory
    {
        int CategoryId { get; set; }
        string Name { get; set; }
        string Code { get; set; }
    }
}
