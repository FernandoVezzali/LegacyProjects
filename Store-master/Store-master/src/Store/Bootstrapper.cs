using System.Web.Mvc;
using Microsoft.Practices.Unity;
//using Unity.Mvc4;
using Unity.Mvc5;

namespace Store
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
        var container = new UnityContainer();
        container.RegisterType<Data.IRepository<Store.Domain.Product>, Data.ProductRepository>();
        container.RegisterType<Data.IRepository<Store.Domain.Category>, Data.CategoryRepository>();
        container.RegisterType<Data.IRepository<Store.Domain.User>, Data.UserRepository>();
        container.RegisterType<Data.IRepository<Store.Domain.Brand>, Data.BrandRepository>();

        RegisterTypes(container);

        return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
    
    }
  }
}