using CarsWithIdentity.Data.Factories;
using CarsWithIdentity.Models;
using CarsWithIdentity.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarsWithIdentity.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PurchaseVehicle(int id)
        {
            var repo = CarFactoryRepository.GetRepository();
            var details = repo.GetById(id);

            var purchase = new PurchaseVM();

            purchase.GetCarDetails = details;
            return View(purchase);
        }

        [HttpPost]
        public ActionResult PurchaseVehicle(PurchaseVehicle purchase)
        {
            if (ModelState.IsValid)
            {
                PurchaseVehicleFactory.GetRepository().Insert(purchase);
            }
            else
            {
                return View(purchase);
            }
            return RedirectToAction("Index", "Sales");

        }
    }
}