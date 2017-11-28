using CarsWithIdentity.Data.Interfaces;
using CarsWithIdentity.Models.Queries;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsWithIdentity.Data.ADORepositories
{
    public class SearchResultsRepositoryADO:ISearchResultsRepository
    {
        public IEnumerable<SearchResult> Search(CarSearchParameters parameters)
        {
            List<SearchResult> cars = new List<SearchResult>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                string query = "SELECT TOP 20 CarId, ma.Make, mo.Model, ct.CarType, bs.BodyStyle, t.Transmission, " +
                        "cc.CarColor, i.InteriorColor, IsSold, Mileage, CarYear, VIN, MSRP, SalePrice, PicturePNG " +
                        "FROM Cars c" +
                        "	INNER JOIN MakeModel mm ON c.MakeModelId = mm.MakeModelId" +
                        "   INNER JOIN Makes ma ON mm.MakeId = ma.MakeId" +
                        "   INNER JOIN Models mo ON mm.ModelId = mo.ModelId" +
                        "   INNER JOIN BodyStyles bs ON c.BodyStyleId = bs.BodyStyleId" +
                        "   INNER JOIN Transmissions t ON c.TransmissionId = t.TransmissionId" +
                        "   INNER JOIN CarColors cc ON c.CarColorId = cc.CarColorId" +
                        "   INNER JOIN InteriorColors i ON c.InteriorColorId = i.InteriorColorId" +
                        "   INNER JOIN CarTypes ct ON c.CarTypeId = ct.CarTypeId " +
                        "WHERE 1 = 1";


                if (parameters.MinPrice.HasValue)
                {
                    query += " AND SalePrice >= @MinPrice";
                    cmd.Parameters.AddWithValue("@MinPrice", parameters.MinPrice.Value);
                }

                if (parameters.MaxPrice.HasValue)
                {
                    query += " AND SalePrice <= @MaxPrice";
                    cmd.Parameters.AddWithValue("@MaxPrice", parameters.MaxPrice.Value);
                }

                if (parameters.MinYear.HasValue)
                {
                    query += " AND CarYear >= @MinYear";
                    cmd.Parameters.AddWithValue("@MinYear", parameters.MinYear.Value);
                }

                if (parameters.MaxYear.HasValue)
                {
                    query += " AND CarYear <= @MaxYear";
                    cmd.Parameters.AddWithValue("@MaxYear", parameters.MaxYear.Value);
                }

                if (!string.IsNullOrEmpty(parameters.SearchTerm))
                {
                    query += " AND (CarYear LIKE '%' + @String + '%' OR Make LIKE '%' + @String + '%' OR Model LIKE '%' + @String + '%')";
                    cmd.Parameters.AddWithValue("@String", parameters.SearchTerm);
                }

                cmd.CommandText = query;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SearchResult car = new SearchResult();

                        car.CarId = (int)dr["CarId"];
                        car.MakeName = dr["Make"].ToString();
                        car.ModelName = dr["Model"].ToString();
                        car.CarTypeName = dr["CarType"].ToString();
                        car.Mileage = (int)dr["Mileage"];
                        car.IsSold = (bool)dr["IsSold"];
                        car.BodyStyleName = dr["BodyStyle"].ToString();
                        car.TransmissionName = dr["Transmission"].ToString();
                        car.CarColorName = dr["CarColor"].ToString();
                        car.CarYear = (int)dr["CarYear"];
                        car.VIN = (int)dr["VIN"];
                        car.MSRP = (decimal)dr["MSRP"];
                        car.SalePrice = (decimal)dr["SalePrice"];
                        car.InteriorColorName = dr["InteriorColor"].ToString();

                        if (dr["PicturePNG"] != DBNull.Value)
                            car.PicturePNG = dr["PicturePNG"].ToString();

                        cars.Add(car);
                    }
                }
            }

            return cars;
        }
    }
}
