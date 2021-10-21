using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LGT_Project.Models;

namespace LGT_Project.Controllers
{
    public class Driver_RegisterController : Controller
    {
        LogisticsEntities db = new LogisticsEntities();

        // GET: Driver_Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Driver driver)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Drivers.Add(driver);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Driver_Login");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Đăng ký không thành công !");

                }
            }
            return View("Index");
        }
    }
}