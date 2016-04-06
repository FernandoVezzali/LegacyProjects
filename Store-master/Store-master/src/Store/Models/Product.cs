using Store.Domain;
using System.ComponentModel.DataAnnotations;


namespace Store.Models
{
    public class Product : IProduct
    {
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public virtual Domain.Category Category { get; set; }
    }
}