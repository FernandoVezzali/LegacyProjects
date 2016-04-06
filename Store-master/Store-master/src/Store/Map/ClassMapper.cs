using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Map
{
    public interface ClassMapper<V, D> where V : class
    {
        List<V> ViewModel(IQueryable<D> all);
        V ViewModel(D dto);
        D Dto(V vm);
    }
}