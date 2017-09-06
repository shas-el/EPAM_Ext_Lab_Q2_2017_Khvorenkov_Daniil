namespace TextCatalog.UI.Controllers
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using TextCatalog.DAL;
    using TextCatalog.DAL.Model;
    using TextCatalog.UI.Models;

    public class UserController : Controller
    {
        private TextCatalogDAL repo;

        public UserController()
        {
            repo = new TextCatalogDAL();
        }

        [HttpGet]
        [Authorize(Roles = "user,admin")]
        public ActionResult Index()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<User, UserViewModel>()
                .ForMember("Texts", opt => opt.MapFrom(u => u.Texts())));

            User user = new User()
            {
                UserName = User.Identity.Name
            };


            var userModel = Mapper.Map<User, UserViewModel>(repo.GetUserDetailsName(user));

            return View(userModel);
        }
    }
}