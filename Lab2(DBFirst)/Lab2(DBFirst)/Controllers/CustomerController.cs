using Lab2_DBFirst_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2_DBFirst_.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            DBFirstEntities db = new DBFirstEntities();
            var data = from c in db.Customers
                       select c;
            //var data = db.Students.ToList();
            return View(data.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer c)
        {
            DBFirstEntities db = new DBFirstEntities();
            db.Customers.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int Id)
        {
            DBFirstEntities db = new DBFirstEntities();
            var customer = (from c in db.Customers
                           where c.Id == Id
                           select c).First();
            return View(customer);
        }
        [HttpPost]
        public ActionResult Edit(Customer cus)
        {
            using (DBFirstEntities db = new DBFirstEntities())
            {
                Customer entity = (from c in db.Customers
                                  where c.Id == cus.Id
                                  select c).FirstOrDefault();
                /*entity.Name = s.Name;
                entity.Dob = s.Dob;
                entity.Gender = s.Gender;
                entity.Cgpa = s.Cgpa;*/

                db.Entry(entity).CurrentValues.SetValues(cus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

        }
        public ActionResult Details(int Id)
        {
            DBFirstEntities db = new DBFirstEntities();
            var customer = (from c in db.Products
                           where c.Id == Id
                           select c).First();
            return View(customer);
        }
        public ActionResult Delete(int Id)
        {
            using (DBFirstEntities db = new DBFirstEntities())
            {
                Customer cus = (from c in db.Customers
                              where c.Id == Id
                              select c).FirstOrDefault();
                return View(cus);
            }
        }
        [HttpPost]
        public ActionResult Delete(Customer cus)
        {
            using (DBFirstEntities db = new DBFirstEntities())
            {
                Customer entity = (from c in db.Customers
                                  where c.Id == cus.Id
                                  select c).FirstOrDefault();
                db.Customers.Remove(entity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}