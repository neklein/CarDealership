using CarsWithIdentity.Models.Queries;
using CarsWithIdentity.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsWithIdentity.Data.Interfaces
{
    public interface IMakesRepository
    {
        List<Make> GetAll();
        void InsertMake(Make make);
        IEnumerable<GetMake> GetMakes();
    }
}
