using Store.Domain;
using System.ComponentModel.DataAnnotations;


namespace Store.Models // ViewModel
{
    public class Category : ICategory
    {
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }
        public string Code { get; set; }

        public Genre FirstGenre { get; set; }
    }
}