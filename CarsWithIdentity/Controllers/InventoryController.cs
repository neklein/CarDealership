using CarsWithIdentity.Data.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarsWithIdentity.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        public ActionResult New()
        {
            return View();
        }

        public ActionResult Used()
        {
            return View();
        }

        public ActionResult GetDetails(int id)
        {
            var repo = CarFactoryRepository.GetRepository();
            var model = repo.GetById(id);

            return View(model);
        }
    }
}