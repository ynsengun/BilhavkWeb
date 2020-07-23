using BilhavkWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilhavkWeb.Controllers
{
    public class DayController : Controller
    {
        DataContext context = new DataContext();

        [HttpPost]
        public ActionResult Add( Day day)
        {
            context.Days.Add(day);
            context.SaveChanges();
            return RedirectToAction("Index","Participant", context.Days.ToList());
        }

        public ActionResult Delete( Day day )
        {
            context.Days.Remove(context.Days.FirstOrDefault(x=>x.Id == day.Id));
            context.SaveChanges();
            return RedirectToAction("Index", "Participant", context.Days.ToList());
        }
    }
}