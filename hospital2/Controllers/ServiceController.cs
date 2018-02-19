using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hospital2.Models;
using System.IO;
using System.Data.Entity;


namespace hospital2.Controllers
{
    public class ServiceController : Controller
    {
        SkilContext db1 = new SkilContext();
        HomeController index = new HomeController();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ServiceCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ServiceCreate(Service service)
        {
            db1.Entry(service).State = EntityState.Added;
            db1.SaveChanges();

            return RedirectToRoute(new { controller = "Home", action = "Index" });

        }
        [HttpGet]
        public ActionResult EditService(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Service servicee = db1.Services.Find(id);
            if(id != null)
            {
                return View(servicee);
            }
            return HttpNotFound();
        }
       

        [HttpPost]
        public ActionResult EditService(Service s)
        {

            db1.Entry(s).State = EntityState.Modified;
            db1.SaveChanges();           
              return RedirectToRoute(new { controller = "Home", action = "Index" });
        }
        public ActionResult DeleteService(int id)
        {
            Service s = db1.Services.Find(id);
            if(s  == null)
            {
                return HttpNotFound();
            }
            return View();
        }
        [HttpPost, ActionName("DeleteService")]
        public ActionResult ServiceDelete(int id)
        {
            Service s = db1.Services.Find(id);
            if(s == null)
            {
                return HttpNotFound();
            }
            db1.Services.Remove(s);
            db1.SaveChanges();
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

    }
}