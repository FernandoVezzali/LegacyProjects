using Store.Domain.Interfaces;

namespace Store.Domain.Entities
{
    public class Product : IProduct
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } // it is virtual for lazy loading (see more here: http://msdn.microsoft.com/en-us/library/dd468057.aspx)
    }
}
