namespace Store.Domain.Interfaces
{
    public interface ICategory
    {
        int CategoryId { get; set; }
        string Name { get; set; }
        string Code { get; set; }
    }
}
