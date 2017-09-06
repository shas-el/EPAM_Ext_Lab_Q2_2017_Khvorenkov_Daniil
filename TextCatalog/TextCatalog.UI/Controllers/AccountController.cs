using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TextCatalog.DAL;
using TextCatalog.DAL.Model;
using TextCatalog.UI.Models;

namespace TextCatalog.UI.Controllers
{
    public class AccountController : Controller
    {
        private TextCatalogDAL repo = new TextCatalogDAL();

        [HttpGet]
        public ActionResult LogIn()
        {
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult LogIn(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string hashedPassword;
            using (var sha1 = new SHA1CryptoServiceProvider())
            {
                var data = Encoding.UTF8.GetBytes(model.Password);
                var sha1data = sha1.ComputeHash(data);
                hashedPassword = Encoding.UTF8.GetString(sha1data);
            }

            var user = repo.GetUserDetails(new User()
            {
                UserName = model.UserName,
                Password = hashedPassword
            });

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);

                var authTicker = new FormsAuthenticationTicket(1, user.UserName, DateTime.Now,
                    DateTime.Now.AddMinutes(20), false, user.Role().RoleName);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicker);
                var authTicket = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authTicket);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string hashedPassword;
            using (var sha1 = new SHA1CryptoServiceProvider())
            {
                var data = Encoding.UTF8.GetBytes(model.Password);
                var sha1data = sha1.ComputeHash(data);
                hashedPassword = Encoding.UTF8.GetString(sha1data);
            }

            const int userRole = 2;

            User user = new User()
            {
                UserName = model.UserName,
                Password = hashedPassword,
                RoleId = userRole
            };

            repo.CreateUser(user);

            return RedirectToAction("Index", "Home");
        }
    }
}