using Store.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class Brand:IBrand
    {
        //public int BrandId { get; set; }

        //[Required]
        //public string Name { get; set; }
        //public int CategoryId { get; set; }
        //public virtual Domain.Category Category { get; set; }

        public int BrandId { get; set; }
        [Required]
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Domain.Category Category { get; set; }

    }
}