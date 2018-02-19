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
    public class NewsController : Controller
    {
        PostContext db = new PostContext();

        
        public ActionResult Index(int page = 1)
        {
            const int pageSize = 12; // количество объектов на страницу
            var posts = db.Posts.ToList().OrderByDescending(m => m.Id);
            IEnumerable<Post> postsPerPages = posts.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = posts.Count() };
            NewsIndexView ivm = new NewsIndexView { PageInfo = pageInfo, Posts = postsPerPages };
            return View(ivm);
        }
        public ActionResult PostView(int id)
        {

            return View(db.Posts.Find(id));
        }
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
           
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Create(Post post, HttpPostedFileBase upload)
        {
            if (string.IsNullOrEmpty(post.Name))
            {
                ModelState.AddModelError("Name", "Введіть ім'я");
            }
            else if(post.Name.Length > 15)
            {
                ModelState.AddModelError("Name", "Назва не повинна бути більшою ніж 15 символів");
            }
            if (string.IsNullOrEmpty(post.SmalText))
            {
                ModelState.AddModelError("SmalText", "Введіть короткий опис");
            }
            else if(post.SmalText.Length > 75)
            {
                ModelState.AddModelError("SmalText", "Назва повинна бути меншою ніж 75 символів");
            }
            if (string.IsNullOrEmpty(post.Text))
            {
                ModelState.AddModelError("Text", "Введіть опис");
            }        
            if (ModelState.IsValid && upload != null)
            {
                string fileName = Path.GetFileName(upload.FileName);
                upload.SaveAs(Server.MapPath("~/Content/news/ " + fileName));
                post.Image = fileName;
                db.Entry(post).State = EntityState.Added;
                db.SaveChanges();
                return RedirectToAction("Index");
            }        
            return View();

        }
        [Authorize(Roles ="admin")]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Post post = db.Posts.Find(id);

            if (id != null)
            {
                return View(post);
            }
            return HttpNotFound();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult EditPost(Post post, HttpPostedFileBase upload)
        {
            if (string.IsNullOrEmpty(post.Name))
            {
                ModelState.AddModelError("Name", "Введіть ім'я");
            }
            else if (post.Name.Length > 15)
            {
                ModelState.AddModelError("Name", "Назва не повинна бути більшою ніж 15 символів");
            }
            if (string.IsNullOrEmpty(post.SmalText))
            {
                ModelState.AddModelError("SmalText", "Введіть короткий опис");
            }
            else if (post.SmalText.Length > 75)
            {
                ModelState.AddModelError("SmalText", "Назва повинна бути меншою ніж 75 символів");
            }
            if (string.IsNullOrEmpty(post.Text))
            {
                ModelState.AddModelError("Text", "Введіть опис");
            }


            if (ModelState.IsValid && upload != null)
            {
                string nameFile = Path.GetFileName(upload.FileName);
                upload.SaveAs(Server.MapPath("~/Content/news/ " + nameFile));
                post.Image = nameFile;
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            
            Post p = db.Posts.Find(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            return View(p);
        }
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteView(int id)
        {
            Post p = db.Posts.Find(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            db.Posts.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();           
            base.Dispose(disposing);
        }
    }
}