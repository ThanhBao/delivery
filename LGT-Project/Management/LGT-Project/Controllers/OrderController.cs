using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LGT_Project.Models;

namespace LGT_Project.Controllers
{
    public class OrderController : Controller
    {

        LogisticsEntities db = new LogisticsEntities();
        // GET: Order
        public ActionResult Index()
        {
            return View(db.Orders.OrderByDescending(x => x.OrderID).ToList());
        }
        public ActionResult Details(int id)
        {
            Order ord = db.Orders.Find(id);
            var Ord_details = db.OrderDetails.Where(x => x.OrderID == id).ToList();
            var tuple = new Tuple<Order, IEnumerable<OrderDetail>>(ord, Ord_details);

            double SumAmount = Convert.ToDouble(Ord_details.Sum(x => x.TotalAmount));
            ViewBag.TotalItems = Ord_details.Sum(x => x.Quantity);
            ViewBag.Discount = 0;
            ViewBag.TAmount = SumAmount - 0;
            ViewBag.Amount = SumAmount;
            return View(tuple);
        }

        //Get Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Order order = db.Orders.Single(x => x.OrderID == id);
            if (order == null)
            {
                return HttpNotFound();
            }
            GetViewBagData();
            return View("Edit", order);
        }

        //Post Edit
        [HttpPost]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Order");
            }
            GetViewBagData();
            return View(order);
        }
        public void GetViewBagData()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerID");
            ViewBag.PaymentID = new SelectList(db.Payments, "PaymentID", "PaymentID");
            ViewBag.ShippingID = new SelectList(db.ShippingDetails, "ShippingID", "ShippingID");
        }
    }
}