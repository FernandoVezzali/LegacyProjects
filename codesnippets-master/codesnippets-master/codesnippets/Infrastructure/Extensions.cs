using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using codesnippets.Models;

namespace codesnippets.Infrastructure
{
    public static class Extensions
    {
        public static IEnumerable<SelectListItem> ToSelectListItems(this IEnumerable<Language> items, int selectedId = -1)
        {
            IEnumerable<SelectListItem> selectListItems = items.OrderBy(i => i.Name)
                  .Select(l => new SelectListItem
                  {
                      Selected = (l.Id == selectedId),
                      Text = l.Name,
                      Value = l.Id.ToString()
                  });

            return DefaultItem.Concat(selectListItems);
        }

        public static IEnumerable<SelectListItem> ToSelectListItems(this IEnumerable<LanguageVersion> items, int selectedId = -1)
        {
            IEnumerable<SelectListItem> selectListItems = items.OrderBy(i => i.Version)
                  .Select(l => new SelectListItem
                  {
                      Selected = (l.Id == selectedId),
                      Text = l.Version,
                      Value = l.Id.ToString()
                  });

            return DefaultItem.Concat(selectListItems);
        }

        public static IEnumerable<SelectListItem> DefaultItem
        {
            get
            {
                return Enumerable.Repeat(new SelectListItem
                {
                    Value = "-1",
                    Text = "Select an item"
                }, count: 1);
            }
        }
    }

}
