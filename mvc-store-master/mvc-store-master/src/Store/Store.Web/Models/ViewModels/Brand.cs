using System.ComponentModel.DataAnnotations;

namespace Store.Web.Models.ViewModels
{
    public class Brand : Store.Domain.Interfaces.IBrand
    {
        public int BrandId { get; set; }
        [Required]
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Store.Domain.Entities.Category Category { get; set; }
    }
}