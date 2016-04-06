using Store.Domain.Entities;
using System;


namespace Store.Domain.Interfaces
{
    public interface IBrand
    {
        int BrandId { get; set; }
        string Name { get; set; }
        int CategoryId { get; set; }
        Category Category { get; set; }
    }
}
