using Lab2_DBFirst_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2_DBFirst_.Controllers
{
    public class ProductsController : Controller
    {
        

        public ActionResult Index()
        {
            DBFirstEntities db = new DBFirstEntities();
            var data = from p in db.Products
                       select p;
            //var data = db.Students.ToList();
            return View(data.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(Product p)
        {
            DBFirstEntities db = new DBFirstEntities();
            db.Products.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int Id)
        {
            DBFirstEntities db = new DBFirstEntities();
            var product = (from p in db.Products
                           where p.Id == Id
                           select p).First();
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product pr)
        {
            using ( DBFirstEntities db = new DBFirstEntities())
            {
                Product entity = (from p in db.Products
                                  where p.Id == pr.Id
                                  select p).FirstOrDefault();
                /*entity.Name = s.Name;
                entity.Dob = s.Dob;
                entity.Gender = s.Gender;
                entity.Cgpa = s.Cgpa;*/

                db.Entry(entity).CurrentValues.SetValues(pr);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

        }
        public ActionResult Details(int Id)
        {
            DBFirstEntities db = new DBFirstEntities();
            var product = (from p in db.Products
                           where p.Id == Id
                           select p).First();
            return View(product);
        }
        public ActionResult Delete(int Id)
        {
            using (DBFirstEntities db = new DBFirstEntities())
            {
                Product pr = (from p in db.Products
                             where p.Id == Id
                             select p).FirstOrDefault();
                return View(pr);
            }
        }
        [HttpPost]
        public ActionResult Delete(Product pr)
        {
            using (DBFirstEntities db = new DBFirstEntities())
            {
                Product entity = (from p in db.Products
                                  where p.Id == pr.Id
                                  select p).FirstOrDefault();
                db.Products.Remove(entity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}