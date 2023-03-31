using MidAssignment.EF;
using MidAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MidAssignment.Controllers
{
    public class LogController : Controller
    {
        // GET: Log
        [HttpGet]
        public ActionResult Login()
        {


            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                ZHUDb db = new ZHUDb();
                var user = (from u in db.Users
                            where u.Username.Equals(login.Username)
                            && u.Password.Equals(login.Password)
                            select u).SingleOrDefault();
                if (user != null)
                {
                    Session["user"] = user;
                    var returnUrl = Request["ReturnUrl"];
                    if (returnUrl != null)
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                TempData["Msg"] = "Username Password Invalid";
            }
            return View(login);


        }
    }
}