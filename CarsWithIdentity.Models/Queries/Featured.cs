using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsWithIdentity.Models.Queries
{
    public class Featured
    {
        public int CarId { get; set; }
        public int MakeModelId { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public string PicturePNG { get; set; }
        public decimal SalePrice { get; set; }
        public int CarYear { get; set; }
    }
}
