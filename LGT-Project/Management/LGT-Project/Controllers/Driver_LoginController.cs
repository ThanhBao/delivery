using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LGT_Project.Models;

namespace LGT_Project.Controllers
{
    public class Driver_LoginController : Controller
    {

        LogisticsEntities db = new LogisticsEntities();
        // GET: Driver_Login
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(admin_Login login)
        {
            if (ModelState.IsValid)
            {
                var model = (from m in db.admin_Login
                             where m.UserName == login.UserName && m.Password == login.Password
                             select m).Any();
                if (model)
                {
                    var loginInfo = db.admin_Login.Where(x => x.UserName == login.UserName && x.Password == login.Password).FirstOrDefault();
                    if (loginInfo.RoleType == 1)
                    {
                        Session["username"] = loginInfo.UserName;
                        TemData.EmpID = loginInfo.EmpID;
                        return RedirectToAction("Index", "Driver");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng nhập không đúng!");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng!");
                }
            }
            return View("Index");
        }
    }
}