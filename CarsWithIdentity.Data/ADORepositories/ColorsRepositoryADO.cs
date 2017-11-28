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
    public class ColorsRepositoryADO : IColorsRepository
    {
        public List<CarColor> GetAllCarColors()
        {
            List<CarColor> colors = new List<CarColor>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarColorsSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CarColor currentRow = new CarColor();
                        currentRow.CarColorId = (int)dr["CarColorId"];
                        currentRow.CarColorName = dr["CarColor"].ToString();

                        colors.Add(currentRow);
                    }
                }
            }
            return colors;

        }

        public List<InteriorColor> GetAllInteriorColors()
        {
            List<InteriorColor> colors = new List<InteriorColor>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InteriorColorsSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        InteriorColor currentRow = new InteriorColor();
                        currentRow.InteriorColorId = (int)dr["InteriorColorId"];
                        currentRow.InteriorColorName = dr["InteriorColor"].ToString();

                        colors.Add(currentRow);
                    }
                }
            }

            return colors;
        }
    }
}
