using BilhavkWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilhavkWeb.Controllers
{
    public class ParticipantController : Controller
    {
        DataContext context = new DataContext();
        // GET: Participant
        public ActionResult Index()
        {
            return View(context.Days.ToList());
        }

        public ActionResult Add( Day day )
        {
            if (context.Days.FirstOrDefault(x => x.Id == day.Id).Date.CompareTo(DateTime.Now) < 0)
                return RedirectToAction("Index", "Participant", context.Days.ToList());
            Participant participant = new Participant()
            {
                DayId = day.Id,
                UserId = context.Users.FirstOrDefault(x => x.Name == HttpContext.User.Identity.Name).Id
            };
            context.Participants.Add(participant);
            context.SaveChanges();
            return RedirectToAction("Index", "Participant", context.Days.ToList());
        }

        public ActionResult Delete( Day day )
        {
            if( context.Days.FirstOrDefault(x=> x.Id == day.Id ).Date.CompareTo(DateTime.Now) < 0 )
                return RedirectToAction("Index", "Participant", context.Days.ToList());
            context.Participants.Remove(context.Participants.FirstOrDefault(x=>x.DayId==day.Id && x.User.Name==HttpContext.User.Identity.Name));
            context.SaveChanges();
            return RedirectToAction("Index", "Participant", context.Days.ToList());
        }

        public ActionResult DeleteAll()
        {
            context.Participants.RemoveRange(context.Participants.ToList());
            context.SaveChanges();
            return RedirectToAction("Profil", "Home", context.Users.ToList());
        }
    }
}