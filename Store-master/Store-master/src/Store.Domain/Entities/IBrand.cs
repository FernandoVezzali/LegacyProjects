using System;
namespace Store.Domain
{
    public interface IBrand
    {
        int BrandId { get; set; }
        string Name { get; set; }
        int CategoryId { get; set; }
        Category Category { get; set; }
    }
}
