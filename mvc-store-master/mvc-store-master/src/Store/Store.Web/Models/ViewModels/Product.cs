using System.ComponentModel.DataAnnotations;

namespace Store.Web.Models.ViewModels
{
    public class Product : Store.Domain.Interfaces.IProduct
    {
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Domain.Entities.Category Category { get; set; }
    }
}