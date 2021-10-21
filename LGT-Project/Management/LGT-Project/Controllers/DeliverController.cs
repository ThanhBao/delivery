using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LGT_Project.Models;

namespace LGT_Project.Controllers
{
    public class DeliverController : Controller
    {

        LogisticsEntities db = new LogisticsEntities();

        // GET: Deliver
        public ActionResult Index()
        {
            return View(db.Drivers.ToList());
        }

        // GET: Deliver/Details/5
        public ActionResult Details(int id)
        {
            Driver driver = db.Drivers.Find(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            return View(driver);
        }

        // GET: Deliver/Create
        public ActionResult Create()
        {
            getData();
            return View();
        }

        protected void getData()
        {
            ViewBag.LICENSE_ID = new SelectList(db.Drivers, "LICENSE_ID", "LICENSE_ID");
            ViewBag.TRANSPORT_ID = new SelectList(db.Drivers, "TRANSPORT_ID", "TRANSPORT_ID");
            ViewBag.ORDER_ID = new SelectList(db.Drivers, "ORDER_ID", "ORDER_ID");
        }

        // POST: Deliver/Create
        [HttpPost]
        public ActionResult Create(Driver driver)
        {

            getData();
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    db.Drivers.Add(driver);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public void bindingDropdownlist()
        {

        }

        // GET: Deliver/Edit/5
        public ActionResult Edit(int id)
        {

            Driver driver = db.Drivers.Single(x => x.Driver_ID == id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            getData();
            return View("Edit", driver);
        }

        // POST: Deliver/Edit/5
        [HttpPost]
        public ActionResult Edit(Driver driver)
        {
            if (ModelState.IsValid)
            {
                db.Entry(driver).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Deliver");
            }
            getData();
            return View(driver);
        }


        // GET: Deliver/Delete/5
        public ActionResult Delete(int id)
        {
            Driver driver = db.Drivers.Find(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            return View(driver);
        }

        //Post Delete Confirmed
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // TODO: Add delete logic here
                Driver driver = db.Drivers.Find(id);
                db.Drivers.Remove(driver);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}