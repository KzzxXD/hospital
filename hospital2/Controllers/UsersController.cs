using hospital2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hospital2.Controllers
{
    public class UsersController : Controller
    {
        
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(int id)
        {
            IList<string> roles = new List<string> { "Роль не опреділена" };
            ApplicationUserManager UserManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationUser user = UserManager.FindByEmail(User.Identity.Name);
            if(user != null)
            {
                roles = UserManager.GetRoles(user.Id);
            }   
            return View(roles);
        }
    }
}