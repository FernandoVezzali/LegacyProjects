using System.ComponentModel.DataAnnotations;

namespace Store.Web.Models.ViewModels
{
    public class Category : Store.Domain.Interfaces.ICategory
    {
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }
        public string Code { get; set; }

        public Store.Domain.Entities.Genre FirstGenre { get; set; }
    }
}