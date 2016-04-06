using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Controllers
{
    public class CustomController : Controller
    {
        //
        // GET: /Custom/
        public ActionResult Index()
        {
            return View();
        }
        /*
        public ActionResult CustomAction()
        {
            //Gather up all the custom specific data
            List<Store.Models.Category> lst = new List<Models.Category>();
            lst.Add(new Store.Models.Category()
            {
                CategoryId = 1,
                Code = "a",
                FirstGenre = Domain.Genre.Action,
                Name = "a"
            });

            return View("_CustomParialView", lst);
        }*/
        
        public ActionResult CustomAction(int id)
        {
            //Gather up all the custom specific data
            List<Store.Models.Category> lst = new List<Models.Category>();
            lst.Add(new Store.Models.Category() { CategoryId = 1, Code = "a", 
                FirstGenre = Domain.Genre.Action, Name = "a" });

            return View("_CustomPartialView", lst);
        }
         
    }
}