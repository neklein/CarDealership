using CarsWithIdentity.Data.Interfaces;
using CarsWithIdentity.Models.Queries;
using CarsWithIdentity.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsWithIdentity.Data.ADORepositories
{
    public class CarsRepositoryADO : ICarsRepository
    {
        public void Delete(int carId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarsDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@CarId", carId);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Car> GetAll()
        {
            List<Car> cars = new List<Car>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarsSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Car car = new Car();

                        car.CarId = (int)dr["CarId"];
                        car.MakeModelId = (int)dr["MakeModelId"];
                        car.CarTypeId = (int)dr["CarTypeId"];
                        car.BodyStyleId = (int)dr["BodyStyleId"];
                        car.TransmissionId = (int)dr["TransmissionId"];
                        car.CarColorId = (int)dr["CarColorId"];
                        car.CarYear = (int)dr["CarYear"];
                        car.VIN = (int)dr["VIN"];
                        car.MSRP = (decimal)dr["MSRP"];
                        car.SalePrice = (decimal)dr["SalePrice"];
                        car.CarDescription = dr["CarDescription"].ToString();
                        car.Mileage = (int)dr["Mileage"];
                        car.InteriorColorId = (int)dr["InteriorColorId"];

                        if (dr["PicturePNG"] != DBNull.Value)
                            car.PicturePNG = dr["PicturePNG"].ToString();

                        cars.Add(car);
                    }
                }
            }


            return cars;

        }

        public CarDetails GetById(int carId)
        {
            CarDetails car = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarsSelect", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CarId", carId);

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        car = new CarDetails();
                        car.CarId = carId;
                        car.CarYear = (int)dr["CarYear"];
                        car.MakeModelId = (int)dr["MakeModelId"];
                        car.MakeName = dr["Make"].ToString();
                        car.ModelName = dr["Model"].ToString();
                        car.CarTypeId = (int)dr["CarTypeId"];
                        car.CarTypeName = dr["CarType"].ToString();
                        car.BodyStyleId = (int)dr["BodyStyleId"];
                        car.BodyStyleName = dr["BodyStyle"].ToString();
                        car.TransmissionId = (int)dr["TransmissionId"];
                        car.TransmissionName = dr["Transmission"].ToString();
                        car.CarColorId = (int)dr["CarColorId"];
                        car.CarColorName = dr["CarColor"].ToString();
                        car.VIN = (int)dr["VIN"];
                        car.MSRP = (decimal)dr["MSRP"];
                        car.SalePrice = (decimal)dr["SalePrice"];
                        car.CarDescription = dr["CarDescription"].ToString();
                        car.Mileage = (int)dr["Mileage"];
                        car.InteriorColorId = (int)dr["InteriorColorId"];
                        car.InteriorColorName = dr["InteriorColor"].ToString();
                        car.IsSold = (bool)dr["IsSold"];

                        if (dr["PicturePNG"] != DBNull.Value)
                            car.PicturePNG = dr["PicturePNG"].ToString();
                    }
                }
            }


            return car;
        }

        public IEnumerable<Featured> GetFeatured()
        {
            List<Featured> cars = new List<Featured>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("Featured", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        Featured car = new Featured();
                        car.CarId = (int)dr["CarId"];
                        car.MakeModelId = (int)dr["MakeModelId"];
                        car.MakeName = dr["Make"].ToString();
                        car.ModelName = dr["Model"].ToString();
                        car.SalePrice = (decimal)dr["SalePrice"];
                        car.CarYear = (int)dr["CarYear"];

                        if (dr["PicturePNG"] != DBNull.Value)
                            car.PicturePNG = dr["PicturePNG"].ToString();

                        cars.Add(car);
                    }
                }
            }
            return cars;
        }

        public void Insert(Car car)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarsInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@CarId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@MakeModelId", car.MakeModelId);
                cmd.Parameters.AddWithValue("@CarTypeId", car.CarTypeId);
                cmd.Parameters.AddWithValue("@BodyStyleId", car.BodyStyleId);
                cmd.Parameters.AddWithValue("@TransmissionId", car.TransmissionId);
                cmd.Parameters.AddWithValue("@CarColorId", car.CarColorId);
                cmd.Parameters.AddWithValue("@CarYear", car.CarYear);
                cmd.Parameters.AddWithValue("@VIN", car.VIN);
                cmd.Parameters.AddWithValue("@MSRP", car.MSRP);
                cmd.Parameters.AddWithValue("@SalePrice", car.SalePrice);
                cmd.Parameters.AddWithValue("@CarDescription", car.CarDescription);
                cmd.Parameters.AddWithValue("@Mileage", car.Mileage);
                cmd.Parameters.AddWithValue("@InteriorColorId", car.InteriorColorId);
                cmd.Parameters.AddWithValue("@PicturePNG", car.PicturePNG);
                cmd.Parameters.AddWithValue("@IsFeatured", car.IsFeatured);

                cn.Open();
                cmd.ExecuteNonQuery();

                car.CarId = (int)param.Value;
            }

        }
        public void Update(Car car)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarsUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@CarId", car.CarId);
                cmd.Parameters.AddWithValue("@MakeModelId", car.MakeModelId);
                cmd.Parameters.AddWithValue("@CarTypeId", car.CarTypeId);
                cmd.Parameters.AddWithValue("@BodyStyleId", car.BodyStyleId);
                cmd.Parameters.AddWithValue("@TransmissionId", car.TransmissionId);
                cmd.Parameters.AddWithValue("@CarColorId", car.CarColorId);
                cmd.Parameters.AddWithValue("@CarYear", car.CarYear);
                cmd.Parameters.AddWithValue("@VIN", car.VIN);
                cmd.Parameters.AddWithValue("@MSRP", car.MSRP);
                cmd.Parameters.AddWithValue("@SalePrice", car.SalePrice);
                cmd.Parameters.AddWithValue("@CarDescription", car.CarDescription);
                cmd.Parameters.AddWithValue("@Mileage", car.Mileage);
                cmd.Parameters.AddWithValue("@InteriorColorId", car.InteriorColorId);
                cmd.Parameters.AddWithValue("@PicturePNG", car.PicturePNG);
                cmd.Parameters.AddWithValue("@IsFeatured", car.IsFeatured);

                cn.Open();
                cmd.ExecuteNonQuery();
            }

        }

    }
}
