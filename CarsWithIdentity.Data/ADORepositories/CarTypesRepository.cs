using CarsWithIdentity.Data.Interfaces;
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
    public class CarTypesRepository: ICarTypesRepository
    {
        public List<CarType> GetAll()
        {
            List<CarType> carTypes = new List<CarType>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarTypesSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CarType currentRow = new CarType();
                        currentRow.CarTypeId = (int)dr["CarTypeId"];
                        currentRow.CarTypeName = dr["CarType"].ToString();

                        carTypes.Add(currentRow);
                    }
                }
            }

            return carTypes;
        }
    }
}
