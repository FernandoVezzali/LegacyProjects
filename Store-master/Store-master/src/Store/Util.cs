using AutoMapper;
using System.Collections.Generic;
using System.Linq;

using ProductViewModel = Store.Models.Product;      
using ProductDTO = Store.Domain.Product;

using CategoryViewModel = Store.Models.Category;
using CategoryDTO = Store.Domain.Category;

using BrandDTO = Store.Domain.Brand;
using BrandViewModel = Store.Models.Brand;

//todo split into 3 classes or create generic one

namespace Store
{
    public static class Util
    {
        /*public static List<CategoryViewModel> GetCategoriesViewModel(IQueryable<CategoryDTO> all)
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
        }*/

        public static ProductViewModel GetProductViewModel(ProductDTO dto)
        {
            Mapper.CreateMap<ProductDTO, ProductViewModel>();
            Mapper.CreateMap<CategoryViewModel, CategoryDTO>();
            Mapper.AssertConfigurationIsValid();

            var vm = Mapper.Map<ProductDTO, ProductViewModel>(dto);
            return vm;
        }

        /*public static CategoryViewModel GetCategoryViewModel(CategoryDTO dto)
        {
            Mapper.CreateMap<CategoryDTO, CategoryViewModel>();
            Mapper.AssertConfigurationIsValid();

            var vm = Mapper.Map<CategoryDTO, CategoryViewModel>(dto);
            return vm;
        }*/

        public static ProductDTO GetProductDto(ProductViewModel vm)
        {
            Mapper.CreateMap<ProductViewModel, ProductDTO>();
            Mapper.AssertConfigurationIsValid();

            var dto = Mapper.Map<ProductViewModel, ProductDTO>(vm);
            return dto;
        }

        /*public static CategoryDTO GetCategoryDto(CategoryViewModel vm)
        {
            Mapper.CreateMap<CategoryViewModel, CategoryDTO>();
            Mapper.AssertConfigurationIsValid();

            var dto = Mapper.Map<CategoryViewModel, CategoryDTO>(vm);
            return dto;
        }*/

        public static BrandViewModel GetBrandViewModel(Domain.Brand dto)
        {
            Mapper.CreateMap<BrandDTO, BrandViewModel>();
            Mapper.CreateMap<CategoryViewModel, CategoryDTO>();
            Mapper.AssertConfigurationIsValid();

            var vm = Mapper.Map<BrandDTO, BrandViewModel>(dto);
            return vm;
        }

        public static BrandDTO GetBrandDto(BrandViewModel vm)
        {
            Mapper.CreateMap<BrandViewModel, BrandDTO>();
            Mapper.AssertConfigurationIsValid();

            var dto = Mapper.Map<BrandViewModel, BrandDTO>(vm);
            return dto;
        }
    }
}