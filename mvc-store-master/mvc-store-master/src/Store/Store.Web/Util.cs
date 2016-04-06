using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

using ProductViewModel = Store.Web.Models.ViewModels.Product;
using ProductDTO = Store.Domain.Entities.Product;

using CategoryViewModel = Store.Web.Models.ViewModels.Category;
using CategoryDTO = Store.Domain.Entities.Category;

using BrandViewModel = Store.Web.Models.ViewModels.Brand;
using BrandDTO = Store.Domain.Entities.Brand;

namespace Store.Web
{
    public static class Util
    {
        public static ProductViewModel GetProductViewModel(ProductDTO dto)
        {
            Mapper.CreateMap<ProductDTO, ProductViewModel>();
            Mapper.CreateMap<CategoryViewModel, CategoryDTO>();
            Mapper.AssertConfigurationIsValid();

            var vm = Mapper.Map<ProductDTO, ProductViewModel>(dto);
            return vm;
        }

        public static ProductDTO GetProductDto(ProductViewModel vm)
        {
            Mapper.CreateMap<ProductViewModel, ProductDTO>();
            Mapper.AssertConfigurationIsValid();

            var dto = Mapper.Map<ProductViewModel, ProductDTO>(vm);
            return dto;
        }

        public static BrandViewModel GetBrandViewModel(Domain.Entities.Brand dto)
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