using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LGT_Project.Models;

namespace LGT_Project.Controllers
{
    public class ProfileController : Controller
    {

        LogisticsEntities db = new LogisticsEntities();
        // GET: Profile
        public ActionResult Index()
        {
            return View(db.admin_Employee.Find(TemData.EmpID));
        }

        public ActionResult Edit(int id)
        {
            admin_Employee emp = db.admin_Employee.Find(id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }

        [HttpPost]
        public ActionResult Edit(admin_Employee emp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}