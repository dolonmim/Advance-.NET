using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHungerAssignment.EF;
using ZeroHungerAssignment.EF.Models;

namespace ZeroHungerAssignment.Controllers
{
    
        public class RestaurentController : Controller
        {
            // GET: Restaurent

            //public ActionResult Index()
            //{
            //    return View();
            //}
            public ActionResult Index(int id = 1) //id means page number
            {

                AssignmentContext db = new AssignmentContext();
                int itemperpage = 10;
                var total = db.Foods.Count();
                int pages = (int)Math.Ceiling(total / (double)itemperpage);
                ViewBag.pages = pages;

                var foods = db.Foods.OrderBy(p => p.Id).Skip((id - 1) * itemperpage).Take(itemperpage).ToList();

                return View(foods);
            }
            public ActionResult GiveReq(int id)
            {
                AssignmentContext db = new AssignmentContext();
                var food = db.Foods.Find(id);

                List<Food> ResReq = null;
                if (Session["CollectReq"] == null)
                {
                    ResReq = new List<Food>();
                }
                else
                {
                    ResReq = (List<Food>)Session["CollectReq"];
                }

                ResReq.Add(new Food()
                {
                    Id = food.Id,
                    Name = food.Name,
                    Quantity = food.Quantity,
                });
                db.SaveChanges();
                Session["CollectReq"] = ResReq;
                TempData["msg"] = "Food Added to Request!";
                TempData["color"] = "alert-success";

                return RedirectToAction("Index");
            }

            public ActionResult FoodCart()
            {
                if (Session["CollectReq"] != null)
                    return View((List<Food>)Session["CollectReq"]);
                TempData["Msg"] = "Food Cart Empty";
                TempData["Color"] = "alert-info";
                return RedirectToAction("Index");
            }

            public ActionResult Sent()
            {
                AssignmentContext db = new AssignmentContext();
                CollectRequest collect = new CollectRequest();
                collect.ReqDate = DateTime.Now;
                collect.ExpDate = DateTime.Now.AddDays(1);
                collect.Status = "Pending";
                db.CollectRequests.Add(collect);
                db.SaveChanges();
                var foods = (List<Food>)Session["CollectReq"];

                foreach (var item in foods)
                {
                    FoodRequest od = new FoodRequest();
                    od.Food_Id = collect.Id;
                    od.Req_Id = item.Id;
                    db.FoodRequests.Add(od);
                }
                db.SaveChanges();
                Session["CollectReq"] = null;
                TempData["Msg"] = "Order Placed Successfully";
                TempData["Color"] = "alert-success";
                return RedirectToAction("Index");

            }
        }
}