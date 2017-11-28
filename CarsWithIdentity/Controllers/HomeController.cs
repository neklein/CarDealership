using CarsWithIdentity.Data.Factories;
using CarsWithIdentity.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarsWithIdentity.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            var model = CarFactoryRepository.GetRepository().GetFeatured();

            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Specials()
        {
            var model = SpecialRepositoryFactory.GetRepository().GetAll();
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult ContactUs(string VIN, int carId)
        {
            var model = new ContactUs();
            model.VIN = VIN;
            model.CarId = carId;

            return View(model);
        }

        [HttpPost]
        public ActionResult ContactUs(ContactUs contact)
        {
            if (ModelState.IsValid)
            {
                ContactUsFactory.GetRepository().AddContact(contact);
            }
            else
            {
                var model = new ContactUs();
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
