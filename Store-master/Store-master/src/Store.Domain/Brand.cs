using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain
{
    public class Brand : IBrand
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } // it is virtual for lazy loading (see more here: http://msdn.microsoft.com/en-us/library/dd468057.aspx)
    }
}
