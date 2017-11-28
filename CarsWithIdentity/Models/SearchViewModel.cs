using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarsWithIdentity.Models
{
    public class SearchViewModel
    {
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public int? MinYear { get; set; }
        public int? MaxYear { get; set; }
        public string SearchTerm { get; set; }
    }
}