using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace weblogbook.Views.Door
{
    public class DoorController : Controller
    {
        Models.WeblogDBEntities1 db = new Models.WeblogDBEntities1(); 

        // GET: Door
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Models.User newuser)
        {
            if(ModelState.IsValid)
            {
                newuser.totalposts = 0;
                newuser.username = newuser.email.Split('@')[0];
                db.Users.Add(newuser);
                try
                {
                    
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    TempData["val"] = "unchecked";

                    TempData["info"] = "Account Exists, please login";
                    return View("Index");
                }
            }
            else
            {
                TempData["val"] = "unchecked";
                TempData["info"] = "Invalid input";
                return View("Index");
            }
 
            return View("Index");  
        }

        

    }
}