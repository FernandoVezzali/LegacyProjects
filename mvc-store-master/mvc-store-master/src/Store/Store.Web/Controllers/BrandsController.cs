using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.Domain.Entities;
using Store.Repo;
using Store.Web.Map;

namespace Store.Web.Controllers
{
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
            List<Models.ViewModels.Brand> list = new List<Store.Web.Models.ViewModels.Brand>();
            IQueryable<Domain.Entities.Brand> brands = repo.AllIncluding(brand => brand.Category);

            foreach (Brand dto in brands)
            {
                Store.Web.Models.ViewModels.Brand vm = Util.GetBrandViewModel(dto);
                list.Add(vm);
            };

            return View(list);
        }

        public ViewResult Details(int id)
        {
            Store.Web.Models.ViewModels.Brand vm = Util.GetBrandViewModel(repo.Find(id));
            return View(vm);
        }

        public ActionResult Create()
        {
            List<Models.ViewModels.Category> list = new CategoryMapper().ViewModel(categoryRepository.All);
            ViewBag.PossibleCategories = list;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.ViewModels.Brand vm)
        {
            if (ModelState.IsValid)
            {
                Brand dto = InsertOrUpdate(vm);
                return RedirectToAction("Index", vm);
            }
            else
            {
                List<Models.ViewModels.Category> list = new CategoryMapper().ViewModel(categoryRepository.All);
                ViewBag.PossibleCategories = list;
                return View("Create");
            }
        }

        public ActionResult Edit(int id)
        {
            List<Models.ViewModels.Category> list = new CategoryMapper().ViewModel(categoryRepository.All);
            ViewBag.PossibleCategories = list;

            Store.Web.Models.ViewModels.Brand vm = Util.GetBrandViewModel(repo.Find(id));
            return View(vm);
        }

        [HttpPost]
        public ActionResult Edit(Store.Web.Models.ViewModels.Brand vm)
        {
            if (ModelState.IsValid)
            {
                Brand dto = InsertOrUpdate(vm);
                return RedirectToAction("Index", vm);
            }
            else
            {
                List<Models.ViewModels.Category> list = new CategoryMapper().ViewModel(categoryRepository.All);
                ViewBag.PossibleCategories = list;
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            Store.Web.Models.ViewModels.Brand vm = Util.GetBrandViewModel(repo.Find(id));
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

        private Brand InsertOrUpdate(Models.ViewModels.Brand vm)
        {
            Brand dto = Util.GetBrandDto(vm);
            repo.InsertOrUpdate(dto);
            repo.Save();
            return dto;
        }
    }
}