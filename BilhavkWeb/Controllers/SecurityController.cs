using BilhavkWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BilhavkWeb.Controllers
{
    public class SecurityController : Controller
    {
        private DataContext context = new DataContext();
        // GET: Security

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var control = context.Users.FirstOrDefault(x => x.NickName == user.NickName && x.Password == user.Password);
            if (control != null)
            {
                FormsAuthentication.SetAuthCookie(control.Name, false);
                TempData["loggedin"] = true;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.message = "Geçersiz kullanıcı adı veya şifre";
                return View();
            }
        }

        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user, string rePassword)
        {
            if (user.Password != rePassword)
            {
                ViewBag.message = "Parolanız uyuşmamaktadır";
                return View();
            }
            var control = context.Users.FirstOrDefault(x => x.NickName == user.NickName);
            if (control != null)
            {
                ViewBag.message = "Bu kullanıcı adı kullanılmaktadır";
                return View();
            }
            else if (user.Name == null || user.Password == null || user.Surname == null || user.NickName == null)
            {
                ViewBag.message = "Lütfen bütün alanları doldurunuz";
                return View();
            }
            else
            {
                User newUser = new User()
                {
                    NickName = user.NickName,
                    Surname = user.Surname,
                    Name = user.Name,
                    Password = user.Password,
                    Info = "",
                    CategoryId = 1,
                    Penalty = 0,
                    BirthDate = DateTime.Now
                };
                context.Users.Add(newUser);
                context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
        }
    }
}