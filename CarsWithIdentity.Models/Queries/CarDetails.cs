using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsWithIdentity.Models.Queries
{
    public class CarDetails
    {
        public int CarId { get; set; }
        public int MakeModelId { get; set; }
        public int CarYear { get; set; }
        public int Mileage { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public string PicturePNG { get; set; }
        public decimal SalePrice { get; set; }
        public int BodyStyleId { get; set; }
        public string BodyStyleName { get; set; }
        public int TransmissionId { get; set; }
        public string TransmissionName { get; set; }
        public int CarTypeId { get; set; }
        public string CarTypeName { get; set; }
        public int CarColorId { get; set; }
        public string CarColorName { get; set; }
        public int InteriorColorId { get; set; }
        public string InteriorColorName { get; set; }
        public int VIN { get; set; }
        public decimal MSRP { get; set; }
        public string CarDescription { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsSold { get; set; }
    }
}
