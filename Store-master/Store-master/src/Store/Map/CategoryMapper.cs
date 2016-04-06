﻿using System.Collections.Generic;
using System.Linq;
using CategoryViewModel = Store.Models.Category;
using CategoryDTO = Store.Domain.Category;
using AutoMapper;

namespace Store.Map
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