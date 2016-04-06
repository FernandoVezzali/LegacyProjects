using NUnit.Framework;
using Store.Controllers;
using Store.Data;
using Store.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Telerik.JustMock;
using CategoryViewModel = Store.Models.Category;

namespace Store.Tests
{
    [TestFixture]
    public class CategoryControllerTest
    {
        [Test]
        public void IndexShouldReturnThreeCategories() {
            
            // Arrange
            var repo = Mock.Create<IRepository<Category>>();
            Mock.Arrange(() => repo.All).Returns((new List<Category> { 
                new Category(),
                new Category(),
                new Category()
            }).AsQueryable());

            // Arrange
            var result = new CategoriesController(repo).Index();

            // Arrange
            Assert.AreEqual(3, ((IEnumerable<Store.Models.Category>)result.Model).Count());
        }

        [Test]
        public void DetailsShouldReturnBooks()
        {
            // Arrange
            var repo = Mock.Create<IRepository<Category>>();

            Mock.Arrange(() => repo.Find(1)).
                Returns(new Category(){CategoryId=1,Name="Books"});

            // Arrange
            var result = new CategoriesController(repo).Details(1);

            // Arrange
            Assert.AreEqual("Books", ((Store.Models.Category)result.Model).Name);
        }

        [Test]
        public void CreateShouldRedirectToIndex()
        {
            // Arrange
            var repo = Mock.Create<IRepository<Category>>();
            var controller = new CategoriesController(repo);

            // Act
            ActionResult result = controller.Create(new CategoryViewModel());

            // Assert
            Assert.AreEqual(true, ((System.Web.Mvc.RedirectToRouteResult)(result)).RouteValues.ContainsValue("Index"));
        }

        [Test]
        public void InvalidModelStateShouldReturnCreateView()
        {
            // Arrange
            var repo = Mock.Create<IRepository<Category>>();
            var controller = new CategoriesController(repo);
            controller.ModelState.AddModelError("key", "model is invalid");

            // Arrange
            ViewResult result = controller.Create(new CategoryViewModel()) as ViewResult;

            //Assert
            Assert.AreEqual("Create", result.ViewName);
        }

        [Test]
        public void DeleteConfirmedShouldRedirectToIndex()
        {
            // Arrange
            var repo = Mock.Create<IRepository<Category>>();

            // Arrange
            var result = new CategoriesController(repo).DeleteConfirmed(1);

            // Arrange
            Assert.AreEqual(true, ((System.Web.Mvc.RedirectToRouteResult)(result)).RouteValues.ContainsValue("Index"));
        }

        [Test]
        public void EditShouldReturnBooks()
        {
            // Arrange
            var repo = Mock.Create<IRepository<Category>>();

            Mock.Arrange(() => repo.Find(1)).
                Returns(new Category() { CategoryId = 1, Name = "Books" });

            // Arrange
            var result = new CategoriesController(repo).Edit(1) as ViewResult;

            // Arrange
            Assert.AreEqual("Books", ((Store.Models.Category)result.Model).Name);
        }
    }
}
