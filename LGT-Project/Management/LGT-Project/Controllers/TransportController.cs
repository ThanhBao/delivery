using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LGT_Project.Models;


namespace LGT_Project.Controllers
{
    public class TransportController : Controller
    {
        // GET: Transport
        LogisticsEntities db = new LogisticsEntities();
        // GET: Transport
        public ActionResult Index()
        {
            return View(db.Transports.ToList());
        }

        // GET: Transport/Details/5
        public ActionResult Details(int id)
        {
            Transport transport = db.Transports.Find(id);
            if (transport == null)
            {
                return HttpNotFound();
            }
            return View(transport);
        }

        // GET: Transport/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transport/Create
        [HttpPost]
        public ActionResult Create(Transport transport)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    db.Transports.Add(transport);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Transport/Edit/5
        public ActionResult Edit(int id)
        {
            Transport transport = db.Transports.Single(x => x.Transport_ID == id);
            if (transport == null)
            {
                return HttpNotFound();
            }
            return View("Edit", transport);
        }

        // POST: Transport/Edit/5
        [HttpPost]
        public ActionResult Edit(Transport transport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Transport");
            }
            return View(transport);
        }

        // GET: Transport/Delete/5
        public ActionResult Delete(int id)
        {
            Transport transport = db.Transports.Find(id);
            if (transport == null)
            {
                return HttpNotFound();
            }
            return View(transport);
        }


        //Post Delete Confirmed
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // TODO: Add delete logic here
                Transport transport = db.Transports.Find(id);
                db.Transports.Remove(transport);
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