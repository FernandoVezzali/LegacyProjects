using System.ComponentModel.DataAnnotations;

namespace Store.Domain.Entities
{
    public enum Genre
    {
        [Display(Name = "Non Fiction")]
        NonFiction,
        Romance,
        Action,
        [Display(Name = "Science Fiction")]
        ScienceFiction
    }
}
