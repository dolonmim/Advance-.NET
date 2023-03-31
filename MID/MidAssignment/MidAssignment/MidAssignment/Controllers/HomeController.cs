using MidAssignment.EF;
using MidAssignment.Auth;
using MidAssignment.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MidAssignment.Controllers
{
    
    public class HomeController : Controller
    {

        [HttpGet]
        public ActionResult AddRequest()
        {


            return View();
        }
        [HttpPost]
        public ActionResult AddRequest(Food model)
        {
            var db = new ZHUDb();
            db.Foods.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");


        }

        [HttpGet]
        public ActionResult Delete(int id)
        {


            var db = new ZHUDb();
            var pt = (from s in db.Foods
                      where s.Id == id
                      select s).SingleOrDefault();
            db.Foods.Remove(pt);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Index(int id = 1)
        {
            var db = new ZHUDb();
            int itemperpage = 20;
            var foods = db.Foods.OrderBy(e => e.Id).Skip((id - 1) * itemperpage).Take(itemperpage).ToList();

            var pagescount = Math.Ceiling(db.Foods.Count() / (decimal)itemperpage);
            ViewBag.Pages = pagescount;
            return View(foods);
        }

        public ActionResult AddCart(int id)
        {
            ZHUDb db = new ZHUDb();
            List<Food> cart = null;
            if (Session["cart"] == null)
            {
                cart = new List<Food>();
            }
            else
            {
                cart = (List<Food>)Session["cart"];
            }

            var food = db.Foods.Find(id);
            cart.Add(new Food()
            {
                Id = food.Id,
                Name = food.Name,
                Location = food.Location,
                
            });

            Session["cart"] = cart;

            TempData["Msg"] = "Successfully Added";
            return RedirectToAction("Index");
        }

        public ActionResult Cart()
        {

            var cart = (List<Food>)Session["cart"];
            if (cart != null)
            {
                return View(cart);
            }
            TempData["Msg"] = "Cart Empty";
            return RedirectToAction("Index");


        }

        public ActionResult Place()
        {
           
            var cart = (List<Food>)Session["cart"];
            Request request = new Request();

            request.RequestDate= DateTime.Now;
            request.Status = "Request Pending";

          
            ZHUDb db = new ZHUDb();
            db.Requests.Add(request);
            db.SaveChanges();
            foreach (var p in cart)
            {
                var rd = new RequestDetail();

                rd.FId= p.Id;
                rd.ReqId = request.Id;
                
                db.RequestDetails.Add(rd);
            }
           
            db.SaveChanges();
            Session["cart"] = null;
            TempData["Msg"] = "Request Placed Successfully";
            return RedirectToAction("Index");

        }


        
        public ActionResult AllRequest()
        {
            var db = new ZHUDb();
            return View(db.Requests.ToList());
        }
        
        public ActionResult Details(int id)
        {
            var db = new ZHUDb();
            var request = db.Requests.Find(id);
            return View(request);
        }


        public ActionResult Process(int id)
        {
            ZHUDb ctx = new ZHUDb();
            var request = ctx.Requests.Find(id);
            foreach (var od in request.RequestDetails)
            {
                var p = ctx.Foods.Find(od.FId);
               
            }
            request.Status = "Accepted";
            ctx.SaveChanges();
            TempData["Msg"] = "Request Placed Successfully";
            return RedirectToAction("AllRequest");

        }


        public ActionResult Cancel(int id)
        {
            ZHUDb db = new ZHUDb();
            var request = db.Requests.Find(id);
            request.Status = "Cancelled";
            db.SaveChanges();
            TempData["Msg"] = "Request Cancelled";
            return RedirectToAction("AllRequest");
        }



















        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}