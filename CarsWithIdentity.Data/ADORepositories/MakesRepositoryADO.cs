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
    public class MakesRepositoryADO:IMakesRepository
    {
        public List<Make> GetAll()
        {
            List<Make> makes = new List<Make>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakesSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Make currentRow = new Make();
                        currentRow.MakeId = (int)dr["MakeId"];
                        currentRow.UserId = dr["UserId"].ToString();
                        currentRow.MakeName = dr["Make"].ToString();
                        currentRow.DateAdded = DateTime.Parse(dr["DateAdded"].ToString());

                        makes.Add(currentRow);
                    }
                }
            }
            return makes;

        }

        public IEnumerable<GetMake> GetMakes()
        {
            List<GetMake> makes = new List<GetMake>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetMakes", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        GetMake make = new GetMake();
                        make.MakeId = (int)dr["MakeId"];
                        make.MakeName = dr["Make"].ToString();
                        make.DateAdded = DateTime.Parse(dr["DateAdded"].ToString());
                        make.UserId = dr["UserId"].ToString();
                        make.UserName = dr["UserName"].ToString();

                        makes.Add(make);
                    }
                }

            }

            return makes;
        }

        public void InsertMake(Make make)
        {
            throw new NotImplementedException();
        }
    }
}
