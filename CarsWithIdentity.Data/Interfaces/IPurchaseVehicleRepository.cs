using CarsWithIdentity.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsWithIdentity.Data.Interfaces
{
    public interface IPurchaseVehicleRepository
    {
        PurchaseVehicle GetByUserId(string userId);
        List<PurchaseVehicle> GetAll();
        void Insert(PurchaseVehicle purchase);
    }
}
