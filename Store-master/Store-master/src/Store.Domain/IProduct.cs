namespace Store.Domain
{
    public interface IProduct
    {
        int ProductId { get; set; }
        string Name { get; set; }
        int CategoryId { get; set; }
        Category Category { get; set; }
    }
}
