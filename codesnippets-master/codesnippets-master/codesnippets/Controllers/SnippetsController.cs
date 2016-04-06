using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using codesnippets.Infrastructure;
using codesnippets.Models;
using codesnippets.Repositories;

namespace codesnippets.Controllers
{
    [Authorize]
    public class SnippetsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        readonly LanguageRepository _languageRepository = new LanguageRepository();
        readonly LanguageVersionRepository _languageVersionRepository = new LanguageVersionRepository();

        public ActionResult Index()
        {
            return View(db.Snippets.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Snippet snippet = db.Snippets.Find(id);
            if (snippet == null)
            {
                return HttpNotFound();
            }

            return View(snippet);
        }

        public ActionResult Create()
        {
            Snippet snippet = new Snippet();

            var languages = _languageRepository.FindAll().AsEnumerable().ToSelectListItems();
            snippet.LanguageItems = new SelectList(languages, "Value", "Text");

            var versions = new List<SelectListItem>();
            snippet.LanguageVersionItems = new SelectList(versions, "Value", "Text");

            return View(snippet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Body,SelectedLanguageId,SelectedLanguageVersionId,Released")] Snippet snippet)
        {
            if (ModelState.IsValid)
            {
                db.Snippets.Add(snippet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(snippet);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Snippet snippet = db.Snippets.Find(id);
            if (snippet == null)
            {
                return HttpNotFound();
            }

            var languages = _languageRepository.FindAll().AsEnumerable().ToSelectListItems(snippet.SelectedLanguageId);
            snippet.LanguageItems = new SelectList(languages, "Value", "Text");

            var versions = _languageVersionRepository.FindByLanguageId(snippet.SelectedLanguageId).AsEnumerable().ToSelectListItems(snippet.SelectedLanguageVersionId);
            snippet.LanguageVersionItems = new SelectList(versions, "Value", "Text");

            return View(snippet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Body,SelectedLanguageId,SelectedLanguageVersionId,Released")] Snippet snippet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(snippet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(snippet);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Snippet snippet = db.Snippets.Find(id);
            if (snippet == null)
            {
                return HttpNotFound();
            }
            return View(snippet);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Snippet snippet = db.Snippets.Find(id);
            db.Snippets.Remove(snippet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetVersionByLanguageId(string languageId)
        {
            if (String.IsNullOrEmpty(languageId))
            {
                throw new ArgumentNullException("languageId");
            }

            int id = 0;
            Int32.TryParse(languageId, out id);
            var versions = _languageVersionRepository.FindByLanguageId(id);

            var result = (from s in versions
                          select new
                          {
                              id = s.Id,
                              name = s.Version
                          }).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
