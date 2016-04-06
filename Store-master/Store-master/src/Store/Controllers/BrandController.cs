using System.Collections.Generic;
using System.Web.Mvc;
using Store.Domain;
using Store.Data;
using Store.Map;

namespace Store.Controllers
{
    //[Authorize]
    public class BrandsController : Controller
    {
        private readonly IRepository<Category> categoryRepository;
        private readonly IRepository<Brand> repo;

        public BrandsController(IRepository<Category> categoryRepository, IRepository<Brand> brandRepository)
        {
            this.categoryRepository = categoryRepository;
            this.repo = brandRepository;
        }

        public ViewResult Index()
        {
            var list = new List<Store.Models.Brand>();
            var brands = repo.AllIncluding(brand => brand.Category);

            foreach (var dto in brands)
            {
                var a = repo.Find(dto.BrandId);
                var vm = Util.GetBrandViewModel(repo.Find(dto.BrandId));
                list.Add(vm);
            };

            return View(list);
        }

        public ViewResult Details(int id)
        {
            var vm = Util.GetBrandViewModel(repo.Find(id));
            return View(vm);
        }

        public ActionResult Create()
        {
            var list = new CategoryMapper().ViewModel(categoryRepository.All);
            ViewBag.PossibleCategories = list;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.Brand vm)
        {
            if (ModelState.IsValid)
            {
                var dto = InsertOrUpdate(vm);
                return RedirectToAction("Index", vm);
            }
            else
            {
                var list = new CategoryMapper().ViewModel(categoryRepository.All);
                ViewBag.PossibleCategories = list;
                return View("Create");
            }
        }

        public ActionResult Edit(int id)
        {
            var list = new CategoryMapper().ViewModel(categoryRepository.All);
            ViewBag.PossibleCategories = list;

            var vm = Util.GetBrandViewModel(repo.Find(id));
            return View(vm);
        }

        [HttpPost]
        public ActionResult Edit(Store.Models.Brand vm)
        {
            if (ModelState.IsValid)
            {
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
            var vm = Util.GetBrandViewModel(repo.Find(id));
            return View(vm);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.Delete(id);
            repo.Save();

            return RedirectToAction("Index");
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

        private Brand InsertOrUpdate(Models.Brand vm)
        {
            var dto = Util.GetBrandDto(vm);
            repo.InsertOrUpdate(dto);
            repo.Save();
            return dto;
        }
    }
}
