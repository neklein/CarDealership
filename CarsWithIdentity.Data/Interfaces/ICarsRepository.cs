using CarsWithIdentity.Models.Queries;
using CarsWithIdentity.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsWithIdentity.Data.Interfaces
{
    public interface ICarsRepository
    {
        List<Car> GetAll();
        CarDetails GetById(int carId);
        void Insert(Car car);
        void Update(Car car);
        void Delete(int carId);
        IEnumerable<Featured> GetFeatured();
    }
}
