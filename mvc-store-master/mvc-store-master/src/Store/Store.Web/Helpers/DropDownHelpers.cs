using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.Domain.Entities;
using Store.Repo;

namespace Store.Web.Helpers
{
    public static class DropDownHelpers
    {
        public static IEnumerable<SelectListItem> GetItems(
            this Category category, int? selectedValue)
        {
            IRepository<Category> repo = new Store.Repo.Repositories.CategoryRepository();
            List<string> names = repo.All.Select(x => x.Name).ToList();
            List<int> values = repo.All.Select(x => x.CategoryId).ToList();

            var items = names.Zip(values, (name, value) =>
                    new SelectListItem
                    {
                        Text = name,
                        Value = value.ToString(),
                        Selected = value == selectedValue
                    }
                );

            return items;
        }
    }
}