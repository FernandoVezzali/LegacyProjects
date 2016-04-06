using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Store.Domain;
using UserViewModel = Store.Models.User;    // ViewModel
using UserDTO = Store.Domain.User;
using Store.Data;            // DTO

namespace Store.Controllers
{
    public class UsersController : Controller
    {
        private readonly IRepository<User> repo;
        public UsersController(IRepository<User> repo)
        {
            this.repo = repo;
        }

        public ActionResult Index()
        {
            //repo.FindAll();
            //
            //repo.Add(new UserDTO(){Name = "fer"});
            repo.InsertOrUpdate(new UserDTO());

            var list = new List<UserViewModel>();
            Mapper.CreateMap<UserDTO, UserViewModel>();
            Mapper.AssertConfigurationIsValid();

            foreach (UserDTO dto in repo.All)
            {
                UserViewModel vm = Mapper.Map<UserDTO, UserViewModel>(dto);
                list.Add(vm);
            }

            return View(list);
        }
    }
}
