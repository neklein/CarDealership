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
    public class ModelsRepositoryADO:IModelsRepository
    {
        public List<Model> GetAll()
        {
            List<Model> models = new List<Model>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelsSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Model currentRow = new Model();
                        currentRow.ModelId = (int)dr["ModelId"];
                        currentRow.UserId = dr["UserId"].ToString();
                        currentRow.ModelName = dr["Model"].ToString();
                        currentRow.DateAdded = DateTime.Parse(dr["DateAdded"].ToString());

                        models.Add(currentRow);
                    }
                }
            }
            return models;
        }

        public IEnumerable<GetModel> GetModels()
        {
            List<GetModel> models = new List<GetModel>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetModels", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        GetModel model = new GetModel();
                        model.ModelId = (int)dr["ModelId"];
                        model.ModelName = dr["Model"].ToString();
                        model.DateAdded = DateTime.Parse(dr["DateAdded"].ToString());
                        model.UserId = dr["UserId"].ToString();
                        model.UserName = dr["UserName"].ToString();

                        models.Add(model);
                    }
                }

            }

            return models;
        }

        public void InsertModel(Model model)
        {
            throw new NotImplementedException();
        }
    }
}
