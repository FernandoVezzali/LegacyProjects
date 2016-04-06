using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;

namespace Store.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
		    var container = new UnityContainer();
            container.RegisterType<Store.Repo.IRepository<Store.Domain.Entities.Product>, Store.Repo.Repositories.ProductRepository>();
            container.RegisterType<Store.Repo.IRepository<Store.Domain.Entities.Category>, Store.Repo.Repositories.CategoryRepository>();
            container.RegisterType<Store.Repo.IRepository<Store.Domain.Entities.Brand>, Store.Repo.Repositories.BrandRepository>();
            //container.RegisterType<Store.Repo.IRepository<Store.Domain.User>, Data.UserRepository>();
            //container.RegisterType<Store.Repo.IRepository<Store.Domain.Entities.Brand>, Data.BrandRepository>();

            //RegisterTypes(container);
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}