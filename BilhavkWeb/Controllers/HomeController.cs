using BilhavkWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BilhavkWeb.Controllers
{
    public class HomeController : Controller
    {
        private DataContext context = new DataContext();

        public ActionResult Index()
        {
            ViewBag.loggedin = TempData["loggedin"];
            return View(context.Categories.ToList());
        }

        public ActionResult Iletisim()
        {
            return View();
        }

        public ActionResult Profil()
        {
            return View(context.Users.ToList());
        }

        public ActionResult UpdateUser( User user )
        {
            var updUser = context.Users.FirstOrDefault(x=>x.Id==user.Id);
            updUser.CategoryId = user.CategoryId;
            context.SaveChanges();
            return RedirectToAction("Profil","Home",context.Users.ToList());
        }

        public ActionResult DeleteUser(User user)
        {
            var dltUser = context.Users.FirstOrDefault(x => x.Id == user.Id);
            context.Users.Remove(dltUser);
            context.SaveChanges();
            return RedirectToAction("Profil", "Home", context.Users.ToList());
        }
    }
}