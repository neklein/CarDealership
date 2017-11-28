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
    public class TransmissionRepositoryADO: ITransmissionRepository
    {
        public List<Transmission> GetAll()
        {
            List<Transmission> transmissions = new List<Transmission>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TransmissionsSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Transmission currentRow = new Transmission();
                        currentRow.TransmissionId = (int)dr["TransmissionId"];
                        currentRow.TransmissionName = dr["Transmission"].ToString();

                        transmissions.Add(currentRow);
                    }
                }
            }
            return transmissions;

        }

    }
}
