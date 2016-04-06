using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using CategoryViewModel = Store.Web.Models.ViewModels.Category;
using CategoryDTO = Store.Domain.Entities.Category;

using AutoMapper;

namespace Store.Web.Map
{
    public class CategoryMapper : ClassMapper<CategoryViewModel, CategoryDTO>
    {
        public List<CategoryViewModel> ViewModel(IQueryable<CategoryDTO> all)
        {
            Mapper.CreateMap<CategoryDTO, CategoryViewModel>();
            Mapper.AssertConfigurationIsValid();

            var list = new List<CategoryViewModel>();
            foreach (CategoryDTO dto in all)
            {
                var vm = Mapper.Map<CategoryDTO, CategoryViewModel>(dto);
                list.Add(vm);
            }
            return list;
        }

        public CategoryViewModel ViewModel(CategoryDTO dto)
        {
            Mapper.CreateMap<CategoryDTO, CategoryViewModel>();
            Mapper.AssertConfigurationIsValid();

            var vm = Mapper.Map<CategoryDTO, CategoryViewModel>(dto);
            return vm;
        }

        public CategoryDTO Dto(CategoryViewModel vm)
        {
            Mapper.CreateMap<CategoryViewModel, CategoryDTO>();
            Mapper.AssertConfigurationIsValid();

            var dto = Mapper.Map<CategoryViewModel, CategoryDTO>(vm);
            return dto;
        }
    }
}