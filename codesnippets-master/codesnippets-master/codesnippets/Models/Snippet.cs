using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codesnippets.Models
{
    public class Snippet
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is mandatory")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Body is mandatory")]
        public string Body { get; set; }

        [Display(Name = "Select the Language")]
        public int SelectedLanguageId { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> LanguageItems { get; set; }

        [Display(Name = "Select the Language Version")]
        public int SelectedLanguageVersionId { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> LanguageVersionItems { get; set; }

        [DataType(DataType.Date)]
        public DateTime Released { get; set; }
    }
}
