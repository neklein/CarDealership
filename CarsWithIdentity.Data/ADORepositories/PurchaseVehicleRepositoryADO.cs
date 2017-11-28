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
    public class PurchaseVehicleRepositoryADO : IPurchaseVehicleRepository
    {
        public List<PurchaseVehicle> GetAll()
        {
            List<PurchaseVehicle> list = new List<PurchaseVehicle>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("PurchaseVehicleSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        PurchaseVehicle currentRow = new PurchaseVehicle();

                        currentRow.PurchaseVehicleId = (int)dr["PurchaseId"];
                        currentRow.CarId = (int)dr["CarId"];
                        currentRow.UserId = dr["UserId"].ToString();
                        currentRow.SpecialId = (int)dr["SpecialId"];
                        currentRow.PurchaseTypeId = (int)dr["PurchaseTypeId"];
                        currentRow.StateId = dr["StateId"].ToString();
                        currentRow.CustomerName = dr["CustomerName"].ToString();
                        currentRow.Phone = dr["Phone"].ToString();
                        currentRow.Email = dr["Email"].ToString();
                        currentRow.Street1 = dr["Street1"].ToString();

                        if (dr["Street2"] != DBNull.Value)
                            currentRow.Street2 = dr["Street2"].ToString();

                        currentRow.City = dr["City"].ToString();
                        currentRow.ZipCode = (int)dr["Zipcode"];
                        currentRow.PurchasePrice = (decimal)dr["PurchasePrice"];
                        currentRow.PurchaseDate = DateTime.Parse(dr["PurchaseDate"].ToString());

                        list.Add(currentRow);
                    }
                }
            }


            return list;
        }

        public PurchaseVehicle GetByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public void Insert(PurchaseVehicle purchase)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("PurchaseVehicleInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@PurchaseId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@CarId", purchase.CarId);
                cmd.Parameters.AddWithValue("@UserId", purchase.UserId);
                cmd.Parameters.AddWithValue("@SpecialId", purchase.SpecialId);
                cmd.Parameters.AddWithValue("@PurchaseTypeId", purchase.PurchaseTypeId);
                cmd.Parameters.AddWithValue("@StateId", purchase.StateId);
                cmd.Parameters.AddWithValue("@CustomerName", purchase.CustomerName);
                cmd.Parameters.AddWithValue("@Phone", purchase.Phone);
                cmd.Parameters.AddWithValue("@Email", purchase.Email);
                cmd.Parameters.AddWithValue("@Street1", purchase.Street1);
                cmd.Parameters.AddWithValue("@Street2", purchase.Street2);
                cmd.Parameters.AddWithValue("@City", purchase.City);
                cmd.Parameters.AddWithValue("@Zipcode", purchase.ZipCode);
                cmd.Parameters.AddWithValue("@PurchasePrice", purchase.PurchasePrice);
                cmd.Parameters.AddWithValue("@PurchaseDate", purchase.PurchaseDate);

                cn.Open();
                cmd.ExecuteNonQuery();

                purchase.PurchaseVehicleId = (int)param.Value;

            }
        }
    }
}
