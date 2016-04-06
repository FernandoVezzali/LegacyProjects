using System.Collections.Generic;
using System.Web.Mvc;
using Store.Domain;
using Store.Data;
using System.Diagnostics;
using Store.Map;

namespace Store.Controllers
{
    //[Authorize]
    public class ProductsController : Controller
    {
        private readonly IRepository<Category> categoryRepository;
        private readonly IRepository<Product> repo;

        public ProductsController(IRepository<Category> categoryRepository, IRepository<Product> productRepository)
        {
            this.categoryRepository = categoryRepository;
            this.repo = productRepository;
        }

        public ViewResult Index()
        {
            var list = new List<Store.Models.Product>();
            var products = repo.AllIncluding(product => product.Category);

            foreach (var dto in products)
            {
                var vm = Util.GetProductViewModel(repo.Find(dto.ProductId));
                list.Add(vm);
            };

            return View(list);
        }

        public ViewResult Details(int id)
        {
            var vm = Util.GetProductViewModel(repo.Find(id));
            return View(vm);
        }

        public ViewResult Dashboard(int id)
        {
            var vm = Util.GetProductViewModel(repo.Find(id));
            return View(vm);
        }

        public ActionResult Create()
        {
            var list = new CategoryMapper().ViewModel(categoryRepository.All);
            ViewBag.PossibleCategories = list;

            Models.Product product = new Models.Product()
            {
                Category = new Category(),
                CategoryId = 0,
                Name = ""
            };

            return View(product);
        }

        [HttpPost]
        public ActionResult Create(Models.Product vm)
        {
            if (vm.Category != null)
            {
                vm.CategoryId = vm.Category.CategoryId;
            }
            else
            {
                vm.Category = new Category() { CategoryId = vm.CategoryId };
            }

            if (ModelState.IsValid)
            {
                var dto = InsertOrUpdate(vm);
                return RedirectToAction("Index",vm);
            }
            else
            {

                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        Debug.WriteLine(error.ErrorMessage);
                        if (modelState.Value != null)
                        { 
                            Debug.WriteLine(modelState.Value.AttemptedValue); 
                        }
                    }
                    if (modelState.Errors.Count > 0)
                    {
                        foreach (var item in modelState.Errors)
                        {
                            Debug.WriteLine(item.ErrorMessage);
                        }

                        
                    }
                }

                var list = new CategoryMapper().ViewModel(categoryRepository.All);
                ViewBag.PossibleCategories = list;

                Models.Product product = new Models.Product()
                {
                    Category = new Category(),
                    CategoryId = 0,
                    Name = ""
                };

                return View("Create", product);
            }
        }

        public ActionResult Edit(int id)
        {
            var list = new CategoryMapper().ViewModel(categoryRepository.All);
            ViewBag.PossibleCategories = list;

            var vm = Util.GetProductViewModel(repo.Find(id));
            return View(vm);
        }

        [HttpPost]
        public ActionResult Edit(Store.Models.Product vm)
        {
            if (ModelState.IsValid)
            {
                //todo
                vm.CategoryId = vm.Category.CategoryId;

                var dto = InsertOrUpdate(vm);
                return RedirectToAction("Index", vm);
            }
            else
            {
                var list = new CategoryMapper().ViewModel(categoryRepository.All);
                ViewBag.PossibleCategories = list;
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var vm = Util.GetProductViewModel(repo.Find(id));
            return View(vm);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.Delete(id);
            repo.Save();

            return RedirectToAction("Index");
        }

        private Product InsertOrUpdate(Models.Product vm)
        {
            var dto = Util.GetProductDto(vm);
            repo.InsertOrUpdate(dto);
            repo.Save();
            return dto;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                categoryRepository.Dispose();
                repo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

