using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NUnit.Framework;
using Store.Controllers;
using Store.Domain;
using Telerik.JustMock;
using Store.Data;
using Telerik.JustMock.Helpers;

namespace Store.Tests
{
    [TestFixture]
    public class ProductControllerTest
    {
        [Test]
        public void IndexShouldReturnThreeProducts()
        {
            // Arrange
            var repo = Mock.Create<IRepository<Product>>();

            Mock.Arrange(() => repo.AllIncluding(x => x.Category == new Category()))
                .IgnoreArguments()
                .Returns((new List<Product>
                    {
                        new Product(){CategoryId = 1,Name = "Name",ProductId = 1, Category = new Category()},
                        new Product(){CategoryId = 1,Name = "Name",ProductId = 1, Category = new Category()},
                        new Product(){CategoryId = 1,Name = "Name",ProductId = 1, Category = new Category()}
                    })
                .AsQueryable());

            // Act
            var result = new ProductsController(Mock.Create<IRepository<Category>>(), repo).Index();

            // Assert
            Assert.AreEqual(3, ((IEnumerable<Store.Models.Product>)result.Model).Count());
        }

        [Test]
        public void DetailsShouldReturnProfessional_ASP_NET_MVC()
        {
            // Arrange
            var repo = Mock.Create<IRepository<Product>>();

            Mock.Arrange(() => repo.Find(1))
                .IgnoreArguments()
                .Returns(new Product() { ProductId = 1, Name = "Professional ASP NET MVC" });

            // Act
            var result = new ProductsController(Mock.Create<IRepository<Category>>(), repo).Details(1);

            // Assert
            Assert.AreEqual("Professional ASP NET MVC", ((Store.Models.Product)result.Model).Name);
        }

        [Test]
        public void EditShouldReturnProfessional_ASP_NET_MVC()
        {
            // Arrange
            var repo = Mock.Create<IRepository<Product>>();

            Mock.Arrange(() => repo.Find(1))
                .IgnoreArguments()
                .Returns(new Product() { ProductId = 1, Name = "Professional ASP NET MVC" });

            // Act
            ViewResult result = new ProductsController(Mock.Create<IRepository<Category>>(), repo).Edit(1) as ViewResult;
            
            // Assert
            Assert.AreEqual("Professional ASP NET MVC", ((Store.Models.Product)result.Model).Name);
        }

        [Test]
        public void DeleteConfirmedShouldRedirectToIndex()
        {
            // Arrange
            var repo = Mock.Create<IRepository<Product>>();

            // Arrange
            var result = new ProductsController(Mock.Create<IRepository<Category>>(), repo).DeleteConfirmed(1);

            // Arrange
            Assert.AreEqual(true, ((System.Web.Mvc.RedirectToRouteResult)(result)).RouteValues.ContainsValue("Index"));
        }

        [Test]
        public void InvalidModelStateShouldReturnCreateView()
        {
            // Arrange
            var repo = Mock.Create<IRepository<Product>>();
            var categoryRepository = Mock.Create<IRepository<Category>>();
            var controller = new ProductsController(categoryRepository, repo);
            controller.ModelState.AddModelError("key", "model is invalid");

            // Arrange
            ViewResult result = controller.Create(new Store.Models.Product()) as ViewResult;

            //Assert
            Assert.AreEqual("Create", result.ViewName);
        }

        [Test]
        public void CreateShouldRedirectToIndex()
        {
            // Arrange
            var repo = Mock.Create<IRepository<Product>>();
            var categoryRepository = Mock.Create<IRepository<Category>>();
            var controller = new ProductsController(categoryRepository, repo);

            // Act
            ActionResult result = controller.Create(new Store.Models.Product());

            // Assert
            Assert.AreEqual(true, ((System.Web.Mvc.RedirectToRouteResult)(result)).RouteValues.ContainsValue("Index"));
        }
    }
}
