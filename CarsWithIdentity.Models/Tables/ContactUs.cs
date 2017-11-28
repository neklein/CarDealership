using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsWithIdentity.Models.Tables
{
    public class ContactUs
    {
        public int ContactUsId { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ContactMessage { get; set; }
        public int CarId { get; set; }
        public string VIN { get; set; }
    }
}
