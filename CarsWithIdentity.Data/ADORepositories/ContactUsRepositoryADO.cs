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
    public class ContactUsRepositoryADO: IContactUsRepository
    {
        public void AddContact(ContactUs contact)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InsertContact", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@ContactUsId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@ContactName", contact.ContactName);
                cmd.Parameters.AddWithValue("@Email", contact.Email);
                cmd.Parameters.AddWithValue("@Phone", contact.Phone);
                cmd.Parameters.AddWithValue("@ContactMessage", contact.ContactMessage);
                cmd.Parameters.AddWithValue("@CarId", contact.CarId);

                cn.Open();
                cmd.ExecuteNonQuery();

                contact.ContactUsId = (int)param.Value;
            }

        }

        public List<ContactUs> GetAll()
        {
            List<ContactUs> contactUs = new List<ContactUs>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ContactUsSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ContactUs currentRow = new ContactUs();
                        currentRow.ContactUsId = (int)dr["ContactUsId"];
                        currentRow.ContactName = dr["ContactName"].ToString();
                        currentRow.Email = dr["Email"].ToString();
                        currentRow.Phone = dr["Phone"].ToString();
                        currentRow.ContactMessage = dr["ContactMessage"].ToString();
                        currentRow.CarId = (int)dr["CarId"];
                        currentRow.VIN = dr["VIN"].ToString();

                        contactUs.Add(currentRow);
                    }
                }
            }

            return contactUs;
        }
    }
}
