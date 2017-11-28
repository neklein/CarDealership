using CarsWithIdentity.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarsWithIdentity.Models
{
    public class PurchaseVM
    {
        public CarDetails GetCarDetails { get; set; }
        public int PurchaseVehicleId { get; set; }
        public int CarId { get; set; }
        public string UserId { get; set; }
        public int SpecialId { get; set; }
        public int PurchaseTypeId { get; set; }
        public string StateId { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
        public decimal PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; }

        public IEnumerable<SelectListItem> PurchaseTypes { get; set; }
        public IEnumerable<SelectListItem> States { get; set; }

    }
}