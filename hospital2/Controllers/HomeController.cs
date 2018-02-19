using hospital2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.IO;


namespace hospital2.Controllers
{
    public class HomeController : Controller
    {
        PostContext db = new PostContext();
        SkilContext db1 = new SkilContext();
       
        public ActionResult Index()
          {
            

            ViewBag.db1Service = db1.Services;
            ViewBag.db1 = db1.Skils.Where(item => item.IsMain);
            return View();

        }
      

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            db1.Dispose();
            base.Dispose(disposing);
        }
    }
}