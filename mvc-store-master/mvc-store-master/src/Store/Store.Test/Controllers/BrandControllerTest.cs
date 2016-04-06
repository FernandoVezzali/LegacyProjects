using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using NUnit.Framework;
//using Store.Controllers;
//using Store.Data;
using Store.Domain;
using Store.Domain.Entities;
using Store.Repo;
using Store.Web.Controllers;
using Telerik.JustMock;
//using System.Web.Mvc;

namespace Store.Test.Controllers
{
    [TestFixture]
    public class BrandControllerTest
    {
        [Test]
        public void IndexShouldReturnThreeProducts()
        {
            // Arrange
            var repo = Mock.Create<IRepository<Brand>>();

            Mock.Arrange(() => repo.AllIncluding(x => x.Category == new Category()))
                .IgnoreArguments()
                .Returns((new List<Brand>
                    {
                        new Brand(){CategoryId = 1,Name = "Name",BrandId = 1, Category = new Category()},
                        new Brand(){CategoryId = 1,Name = "Name",BrandId = 1, Category = new Category()},
                        new Brand(){CategoryId = 1,Name = "Name",BrandId = 1, Category = new Category()}
                    })
                .AsQueryable());

            // Act
            var result = new BrandsController(Mock.Create<IRepository<Category>>(), repo).Index();

            // Assert
            Assert.AreEqual(3, ((IEnumerable<Store.Web.Models.ViewModels.Brand>)result.Model).Count());
        }

        [Test]
        public void DetailsShouldReturnMicrosoft()
        {
            // Arrange
            var repo = Mock.Create<IRepository<Brand>>();

            Mock.Arrange(() => repo.Find(1))
                .IgnoreArguments()
                .Returns(new Brand() { BrandId = 1, Name = "Microsoft" });

            // Act
            var result = new BrandsController(Mock.Create<IRepository<Category>>(), repo).Details(1);

            // Assert
            Assert.AreEqual("Microsoft", ((Store.Web.Models.ViewModels.Brand)result.Model).Name);
        }

        [Test]
        public void EditShouldReturnMicrosoft()
        {
            // Arrange
            var repo = Mock.Create<IRepository<Brand>>();

            Mock.Arrange(() => repo.Find(1))
                .IgnoreArguments()
                .Returns(new Brand() { BrandId = 1, Name = "Microsoft" });

            // Act
            ViewResult result = new BrandsController(Mock.Create<IRepository<Category>>(), repo).Edit(1) as ViewResult;

            // Assert
            Assert.AreEqual("Microsoft", ((Store.Web.Models.ViewModels.Brand)result.Model).Name);
        }

        [Test]
        public void DeleteConfirmedShouldRedirectToIndex()
        {
            // Arrange
            var repo = Mock.Create<IRepository<Brand>>();

            // Act
            var result = new BrandsController(Mock.Create<IRepository<Category>>(), repo).DeleteConfirmed(1);

            // Assert
            Assert.AreEqual(true, ((System.Web.Mvc.RedirectToRouteResult)(result)).RouteValues.ContainsValue("Index"));
        }

        [Test]
        public void InvalidModelStateShouldReturnCreateView()
        {
            // Arrange
            var repo = Mock.Create<IRepository<Brand>>();
            var controller = new BrandsController(Mock.Create<IRepository<Category>>(), repo);
            controller.ModelState.AddModelError("key", "model is invalid");

            // Act
            ViewResult result = controller.Create(new Store.Web.Models.ViewModels.Brand()) as ViewResult;

            // Assert
            Assert.AreEqual("Create", result.ViewName);
        }

        [Test]
        public void CreateShouldRedirectToIndex()
        {
            // Arrange
            var repo = Mock.Create<IRepository<Brand>>();
            var controller = new BrandsController(Mock.Create<IRepository<Category>>(), repo);

            // Act
            ActionResult result = controller.Create(new Store.Web.Models.ViewModels.Brand());

            // Assert
            Assert.AreEqual(true, ((System.Web.Mvc.RedirectToRouteResult)(result)).RouteValues.ContainsValue("Index"));
        }
    }
}
