using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hospital2.Models;
using System.IO;

namespace hospital2.Controllers
{
    public class DepartamentsController : Controller
    {
        SkilContext db1 = new SkilContext();
       
        public ActionResult Index()
        {
            ViewBag.db1 = db1.Skils.ToList();
            return View();

        }
        [HttpGet]
        public ActionResult DepartamentsEdit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Skil skil = db1.Skils.Find(id);
            if (id != null)
            {
                return View(skil);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult DepartamentsEdit(Skil image, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid && upload != null)
            {
                string nameFile = Path.GetFileName(upload.FileName);
                upload.SaveAs(Server.MapPath("~/Content/img/ " + nameFile));
                image.Image = nameFile;
                db1.Entry(image).State = EntityState.Modified;
                db1.SaveChanges();
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            return HttpNotFound();
        }
        //Image    
        public ActionResult DepartamentsCreate()
        {
            return View();
        }


        [HttpPost]
        public ActionResult DepartamentsCreate(Skil img, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid && uploadImage != null)
            {
                string fileName = Path.GetFileName(uploadImage.FileName);
                uploadImage.SaveAs(Server.MapPath("~/Content/img/ " + fileName));
                img.Image = fileName;
                db1.Entry(img).State = EntityState.Added;
                db1.SaveChanges();
            }
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        public ActionResult DepartamentsRemove(int id)
        {
            Skil s = db1.Skils.Find(id);
            if (s == null)
            {
                return HttpNotFound();
            }
            return View(s);
        }
        [HttpPost, ActionName("DepartamentsRemove")]
        public ActionResult DepartamentsRemoveView(int id)
        {
            Skil s = db1.Skils.Find(id);
            if (s == null)
            {
                return HttpNotFound();
            }
            db1.Skils.Remove(s);
            db1.SaveChanges();
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }
        protected override void Dispose(bool disposing)
        {
          
            db1.Dispose();
            base.Dispose(disposing);
        }

    }
}