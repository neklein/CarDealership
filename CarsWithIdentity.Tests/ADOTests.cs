using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CarsWithIdentity.Data.ADORepositories;
using CarsWithIdentity.Models.Tables;
using CarsWithIdentity.Models.Queries;

namespace CarsWithIdentity.Tests
{
    [TestFixture]
    public class ADOTests
    {
        [SetUp]
        public void Init()
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "DealershipDbReset";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        [Test]
        public void CanLoadStates()
        {
            var repo = new StatesRepositoryADO();

            var states = repo.GetAll();

            Assert.AreEqual(3, states.Count());

            Assert.AreEqual("IN", states[0].StateId);
            Assert.AreEqual("Indiana", states[0].StateName);
        }

        [Test]
        public void CanLoadBodyStyles()
        {
            var repo = new BodyStylesRepositoryADO();

            var bodyStyles = repo.GetAll();

            Assert.AreEqual(4, bodyStyles.Count());

            Assert.AreEqual(1, bodyStyles[0].BodyStyleId);
            Assert.AreEqual("Car", bodyStyles[0].BodyStyleName);
        }

        [Test]
        public void CanLoadCarTypes()
        {
            var repo = new CarTypesRepository();

            var carTypes = repo.GetAll();

            Assert.AreEqual(2, carTypes.Count());

            Assert.AreEqual(1, carTypes[0].CarTypeId);
            Assert.AreEqual("New", carTypes[0].CarTypeName);
        }

        [Test]
        public void CanLoadCarColors()
        {
            var repo = new ColorsRepositoryADO();

            var colors = repo.GetAllCarColors();

            Assert.AreEqual(5, colors.Count());

            Assert.AreEqual(1, colors[0].CarColorId);
            Assert.AreEqual("Red", colors[0].CarColorName);
        }

        [Test]
        public void CanLoadInteriorColors()
        {
            var repo = new ColorsRepositoryADO();

            var colors = repo.GetAllInteriorColors();

            Assert.AreEqual(5, colors.Count());

            Assert.AreEqual(1, colors[0].InteriorColorId);
            Assert.AreEqual("Red", colors[0].InteriorColorName);
        }


        [Test]
        public void CanLoadContacts()
        {
            var repo = new ContactUsRepositoryADO();

            var contacts = repo.GetAll();

            Assert.AreEqual(3, contacts.Count());

            Assert.AreEqual(1, contacts[0].ContactUsId);
            Assert.AreEqual("Person1", contacts[0].ContactName);
            Assert.AreEqual("1@1.com", contacts[0].Email);
            Assert.AreEqual("111-111-1111", contacts[0].Phone);
            Assert.AreEqual("Message1", contacts[0].ContactMessage);
        }

        [Test]
        public void CanLoadMakes()
        {
            var repo = new MakesRepositoryADO();

            var makes = repo.GetAll();

            Assert.AreEqual(3, makes.Count());

            Assert.AreEqual(1, makes[0].MakeId);
            Assert.AreEqual("00000000-0000-0000-000000000000", makes[0].UserId);
            Assert.AreEqual("Make1", makes[0].MakeName);
            Assert.AreEqual("1/1/2011", makes[0].DateAdded.ToShortDateString());
        }

        [Test]
        public void CanLoadModels()
        {
            var repo = new ModelsRepositoryADO();

            var models = repo.GetAll();

            Assert.AreEqual(3, models.Count());

            Assert.AreEqual(1, models[0].ModelId);
            Assert.AreEqual("00000000-0000-0000-000000000000", models[0].UserId);
            Assert.AreEqual("Model1", models[0].ModelName);
            Assert.AreEqual("1/1/2011", models[0].DateAdded.ToShortDateString());
        }

        [Test]
        public void CanLoadTransmissions()
        {
            var repo = new TransmissionRepositoryADO();

            var transmissions = repo.GetAll();

            Assert.AreEqual(2, transmissions.Count());

            Assert.AreEqual(1, transmissions[0].TransmissionId);
            Assert.AreEqual("Automatic", transmissions[0].TransmissionName);
        }

        [Test]
        public void CanLoadCar()
        {
            var repo = new CarsRepositoryADO();
            var car = repo.GetById(1);

            Assert.IsNotNull(car);
            Assert.AreEqual(1, car.CarId);
            Assert.AreEqual(1, car.MakeModelId);
            Assert.AreEqual(1, car.CarTypeId);
            Assert.AreEqual(1, car.BodyStyleId);
            Assert.AreEqual(1, car.TransmissionId);
            Assert.AreEqual(1, car.CarColorId);
            Assert.AreEqual(2017, car.CarYear);
            Assert.AreEqual(111, car.VIN);
            Assert.AreEqual(10000M, car.MSRP);
            Assert.AreEqual(12000M, car.SalePrice);
            Assert.AreEqual("Brilliant", car.CarDescription);
            Assert.AreEqual(777, car.Mileage);
            Assert.AreEqual(1, car.InteriorColorId);
            Assert.AreEqual("Placeholder.PNG", car.PicturePNG);

        }

        [Test]
        public void NotFoundCarReturnsNull()
        {
            var repo = new CarsRepositoryADO();
            var car = repo.GetById(5000);

            Assert.IsNull(car);
        }

        [Test]
        public void CanAddCar()
        {
            Car carToAdd = new Car();
            var repo = new CarsRepositoryADO();

            carToAdd.MakeModelId = 2;
            carToAdd.CarTypeId = 2;
            carToAdd.BodyStyleId = 2;
            carToAdd.TransmissionId = 2;
            carToAdd.CarColorId = 2;
            carToAdd.CarYear = 1999;
            carToAdd.VIN = 222;
            carToAdd.MSRP = 17000M;
            carToAdd.SalePrice = 16500M;
            carToAdd.CarDescription = "Description2";
            carToAdd.Mileage = 47000;
            carToAdd.InteriorColorId = 2;
            carToAdd.PicturePNG = "Placeholder.png2";
            carToAdd.IsFeatured = true;

            repo.Insert(carToAdd);

            Assert.AreEqual(3, carToAdd.CarId);
        }

        [Test]
        public void CanUpdateCar()
        {
            Car carToAdd = new Car();
            var repo = new CarsRepositoryADO();

            carToAdd.MakeModelId = 2;
            carToAdd.CarTypeId = 2;
            carToAdd.BodyStyleId = 2;
            carToAdd.TransmissionId = 2;
            carToAdd.CarColorId = 2;
            carToAdd.CarYear = 1999;
            carToAdd.VIN = 222;
            carToAdd.MSRP = 17000M;
            carToAdd.SalePrice = 16500M;
            carToAdd.CarDescription = "Description2";
            carToAdd.Mileage = 47000;
            carToAdd.InteriorColorId = 2;
            carToAdd.PicturePNG = "Placeholder.png2";
            carToAdd.IsFeatured = true;

            repo.Insert(carToAdd);

            carToAdd.MakeModelId = 3;
            carToAdd.CarTypeId = 1;
            carToAdd.BodyStyleId = 1;
            carToAdd.TransmissionId = 1;
            carToAdd.CarColorId = 4;
            carToAdd.CarYear = 1998;
            carToAdd.VIN = 212;
            carToAdd.MSRP = 21000M;
            carToAdd.SalePrice = 2000M;
            carToAdd.CarDescription = "Look at these updates!";
            carToAdd.Mileage = 175000;
            carToAdd.InteriorColorId = 4;
            carToAdd.PicturePNG = "Placeholder.png2";
            carToAdd.IsFeatured = false;

            repo.Update(carToAdd);

            var updatedCar = repo.GetById(3);
            Assert.AreEqual(3, updatedCar.MakeModelId);
            Assert.AreEqual(1, updatedCar.CarTypeId);
            Assert.AreEqual(1, updatedCar.BodyStyleId);
            Assert.AreEqual(1, updatedCar.TransmissionId);
            Assert.AreEqual(4, updatedCar.CarColorId);
            Assert.AreEqual(1998, updatedCar.CarYear);
            Assert.AreEqual(212, updatedCar.VIN);
            Assert.AreEqual(21000M, updatedCar.MSRP);
            Assert.AreEqual(2000M, updatedCar.SalePrice);
            Assert.AreEqual("Look at these updates!", updatedCar.CarDescription);
            Assert.AreEqual(175000, updatedCar.Mileage);
            Assert.AreEqual(4, updatedCar.InteriorColorId);
            Assert.AreEqual("Placeholder.png2", updatedCar.PicturePNG);
            Assert.AreEqual(false, updatedCar.IsFeatured);

        }

        [Test]
        public void CanDeleteCar()
        {
            Car carToAdd = new Car();
            var repo = new CarsRepositoryADO();

            carToAdd.MakeModelId = 2;
            carToAdd.CarTypeId = 2;
            carToAdd.BodyStyleId = 2;
            carToAdd.TransmissionId = 2;
            carToAdd.CarColorId = 2;
            carToAdd.CarYear = 1999;
            carToAdd.VIN = 222;
            carToAdd.MSRP = 17000M;
            carToAdd.SalePrice = 16500M;
            carToAdd.CarDescription = "Description2";
            carToAdd.Mileage = 47000;
            carToAdd.InteriorColorId = 2;
            carToAdd.PicturePNG = "Placeholder.png2";
            carToAdd.IsFeatured = true;

            repo.Insert(carToAdd);

            var loaded = repo.GetById(2);
            Assert.IsNotNull(loaded);

            repo.Delete(2);
            loaded = repo.GetById(2);

            Assert.IsNull(loaded);
        }

        [Test]
        public void CanLoadSpecials()
        {
            var repo = new SpecialsRepositoryADO();

            var specials = repo.GetAll();

            Assert.AreEqual(3, specials.Count());

            Assert.AreEqual(1, specials[0].SpecialId);
            Assert.AreEqual("Special1", specials[0].SpecialName);
        }

        [Test]
        public void CanLoadPurchaseTypes()
        {
            var repo = new PurchaseTypeRepositoryADO();

            var purchaseTypes = repo.GetAll();

            Assert.AreEqual(3, purchaseTypes.Count());

            Assert.AreEqual(1, purchaseTypes[0].PurchaseTypeId);
            Assert.AreEqual("Bank Finance", purchaseTypes[0].PurchaseTypeName);
        }

        [Test]
        public void CanLoadPurchaseVehicles()
        {
            var repo = new PurchaseVehicleRepositoryADO();

            var purchaseVehicle = repo.GetAll();

            Assert.AreEqual(1, purchaseVehicle.Count());

            Assert.AreEqual(1, purchaseVehicle[0].PurchaseVehicleId);
            Assert.AreEqual(1, purchaseVehicle[0].CarId);
            Assert.AreEqual("00000000-0000-0000-000000000000", purchaseVehicle[0].UserId);
            Assert.AreEqual(1, purchaseVehicle[0].SpecialId);
            Assert.AreEqual(1, purchaseVehicle[0].PurchaseTypeId);
            Assert.AreEqual("OH", purchaseVehicle[0].StateId);
            Assert.AreEqual("Nate", purchaseVehicle[0].CustomerName);
            Assert.AreEqual("111-111-1111", purchaseVehicle[0].Phone);
            Assert.AreEqual("test@test.com", purchaseVehicle[0].Email);
            Assert.AreEqual("1 One Street", purchaseVehicle[0].Street1);
            Assert.AreEqual(null, purchaseVehicle[0].Street2);
            Assert.AreEqual("Louisville", purchaseVehicle[0].City);
            Assert.AreEqual(40210, purchaseVehicle[0].ZipCode);
            Assert.AreEqual(10000M, purchaseVehicle[0].PurchasePrice);
            Assert.AreEqual("1/1/2011", purchaseVehicle[0].PurchaseDate.ToShortDateString());
        }

        [Test]
        public void CanAddPurchaseVehicle()
        {
            PurchaseVehicle purchaseToAdd = new PurchaseVehicle();
            var repo = new PurchaseVehicleRepositoryADO();

            purchaseToAdd.CarId = 1;
            purchaseToAdd.UserId = "00000000-0000-0000-000000000000";
            purchaseToAdd.SpecialId = 2;
            purchaseToAdd.PurchaseTypeId = 2;
            purchaseToAdd.StateId = "IN";
            purchaseToAdd.CustomerName = "Kevin";
            purchaseToAdd.Phone = "111-111-1111";
            purchaseToAdd.Email = "test2@test2.com";
            purchaseToAdd.Street1 = "2 Two St";
            purchaseToAdd.Street2 = "Apt 2";
            purchaseToAdd.City = "New York";
            purchaseToAdd.ZipCode = 11211;
            purchaseToAdd.PurchasePrice = 10000M;
            purchaseToAdd.PurchaseDate = DateTime.Parse("2/2/22");

            repo.Insert(purchaseToAdd);

            Assert.AreEqual(2, purchaseToAdd.PurchaseVehicleId);
        }

        [Test]
        public void CanLoadFeatured()
        {
            var repo = new CarsRepositoryADO();
            List<Featured> featured = repo.GetFeatured().ToList();

            Assert.AreEqual(1, featured.Count());

            Assert.AreEqual(2, featured[0].CarId);
            Assert.AreEqual(2, featured[0].MakeModelId);
            Assert.AreEqual("Make2", featured[0].MakeName);
            Assert.AreEqual("Model2", featured[0].ModelName);
            Assert.AreEqual("Placeholder2.PNG", featured[0].PicturePNG);
            Assert.AreEqual(3000M, featured[0].SalePrice);
        }

        [Test]
        public void CanGetMakes()
        {
            var repo = new MakesRepositoryADO();
            List<GetMake> makes = repo.GetMakes().ToList();

            Assert.AreEqual(3, makes.Count());

            Assert.AreEqual(1, makes[0].MakeId);
            Assert.AreEqual("Make1", makes[0].MakeName);
            Assert.AreEqual("1/1/2011", makes[0].DateAdded.ToShortDateString());
            Assert.AreEqual("00000000-0000-0000-000000000000", makes[0].UserId);
            Assert.AreEqual("test1", makes[0].UserName);
        }

        [Test]
        public void CanGetModels()
        {
            var repo = new ModelsRepositoryADO();
            List<GetModel> models = repo.GetModels().ToList();

            Assert.AreEqual(3, models.Count());

            Assert.AreEqual(1, models[0].ModelId);
            Assert.AreEqual("Model1", models[0].ModelName);
            Assert.AreEqual("1/1/2011", models[0].DateAdded.ToShortDateString());
            Assert.AreEqual("00000000-0000-0000-000000000000", models[0].UserId);
            Assert.AreEqual("test1", models[0].UserName);
        }

        [Test]
        public void CanLoadSearchNoMinMax()
        {
            var repo = new SearchResultsRepositoryADO();
            CarSearchParameters param = new CarSearchParameters();

            List<SearchResult> searches = repo.Search(param).ToList();

            Assert.AreEqual(20, searches.Count());
        }

        [Test]
        public void CanLoadMinNoMaxPrice()
        {
            var repo = new SearchResultsRepositoryADO();
            CarSearchParameters param = new CarSearchParameters();
            param.MinPrice = 10000M;

            param.SearchTerm = "s";
            List<SearchResult> searches = repo.Search(param).ToList();
            Assert.AreEqual("Chrysler", searches[0].MakeName);
            Assert.AreEqual(12, searches.Count());
        }

        [Test]
        public void CanLoadMaxNoMinPrice()
        {
            var repo = new SearchResultsRepositoryADO();
            CarSearchParameters param = new CarSearchParameters();
            param.MaxPrice = 10000M;

            List<SearchResult> searches = repo.Search(param).ToList();

            Assert.AreEqual(1, searches.Count());
            Assert.AreEqual("Model2", searches[0].ModelName);
        }

        [Test]
        public void CanLoadMinNoMaxYear()
        {
            var repo = new SearchResultsRepositoryADO();
            CarSearchParameters param = new CarSearchParameters();
            param.MinYear = 2018;

            List<SearchResult> searches = repo.Search(param).ToList();

            Assert.AreEqual(2, searches.Count());
        }

        [Test]
        public void CanLoadMaxNoMinYear()
        {
            var repo = new SearchResultsRepositoryADO();
            CarSearchParameters param = new CarSearchParameters();
            param.MaxYear = 2018;

            List<SearchResult> searches = repo.Search(param).ToList();

            Assert.AreEqual(20, searches.Count());
        }

        [Test]
        public void CanLoadMaxYear()
        {
            var repo = new SearchResultsRepositoryADO();
            CarSearchParameters param = new CarSearchParameters();
            param.MaxYear = 2015;

            List<SearchResult> searches = repo.Search(param).ToList();

            Assert.AreEqual(3, searches.Count());
        }
    }
}
