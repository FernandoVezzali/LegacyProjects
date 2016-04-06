using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CategoryViewModel = Store.Web.Models.ViewModels.Category;        // ViewModel
using CategoryDTO = Store.Domain.Entities.Category;
using Store.Web.Map;

namespace Store.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly Store.Repo.IRepository<Category> repo;
        public CategoriesController(Store.Repo.IRepository<Category> repo)
        {
            this.repo = repo;
        }

        public ViewResult Index()
        {
            var list = new CategoryMapper().ViewModel(repo.All);
            return View(list);
        }

        public ViewResult Details(int id)
        {
            var dto = repo.Find(id);
            CategoryViewModel vm = new CategoryMapper().ViewModel(dto);

            return View(vm);
        }

        public ActionResult Create()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Create(CategoryViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var dto = InsertOrUpdate(vm);
                return RedirectToAction("Index", vm);
            }
            else
            {
                return View("Create");
            }
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Edit(int id)
        {
            var vm = new CategoryMapper().ViewModel(repo.Find(id));
            return View(vm);
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Edit(CategoryViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var dto = InsertOrUpdate(vm);
                return RedirectToAction("Index", vm);
            }
            else
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var vm = new CategoryMapper().ViewModel(repo.Find(id));
            return View(vm);
        }

        [System.Web.Mvc.HttpPost, System.Web.Mvc.ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.Delete(id);
            repo.Save();

            return RedirectToAction("Index");
        }

        private Category InsertOrUpdate(Models.ViewModels.Category vm)
        {
            var dto = new CategoryMapper().Dto(vm);
            repo.InsertOrUpdate(dto);
            repo.Save();
            return dto;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}