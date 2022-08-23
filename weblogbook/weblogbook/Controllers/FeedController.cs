using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace weblogbook.Controllers
{
    public class FeedController : Controller
    {
        Models.WeblogDBEntities1 db = new Models.WeblogDBEntities1();
        public ActionResult Feed()
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/Door/Index");
            }
            return View();
        }
        // GET: Feed
        [HttpPost]
        public ActionResult Feed([Bind(Include = "email, pass")] Models.User loginuser)
        {
            ViewBag.val = "";
            ViewBag.info = "";
            Models.User userAuth = null;// = new List<Models.User>();
            
            
            if (ModelState.IsValid)
            {
                userAuth = db.Users.Where(person => person.email == loginuser.email.ToLower()).FirstOrDefault();
                
            }

            if (userAuth != null)
            {
                if (userAuth.pass == loginuser.pass)
                {

                    Session["user"] = userAuth.username;
                    ViewBag.info = "login success!";
                    return View();
                }
                else
                {
                    TempData["val"] = "unchecked";
                    TempData["info"] = "wrong pass :(";
                    return RedirectToAction("Index", "Door");
                }

            }
            TempData["val"] = "checked";
            TempData["info"] = "I don't know you :( sign up please";

            return RedirectToAction("Index", "Door");
        }



        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetAllowResponseInBrowserHistory(false);
            return RedirectToAction("Index", "Door");
        }

    }




}