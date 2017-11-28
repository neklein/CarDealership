using CarsWithIdentity.Data.Factories;
using CarsWithIdentity.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarsWithIdentity.Controllers
{
    public class InventoryAPIController : ApiController
    {
        [Route("api/Inventory/SearchNew")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchNew(decimal? MinPrice, decimal? MaxPrice, int? MinYear, int? MaxYear, string SearchTerm)
        {
            var repo = SearchRepositoryFactory.GetRepository();

            try
            {
                var param = new CarSearchParameters();

                param.MinPrice = MinPrice;
                param.MaxPrice = MaxPrice;
                param.MinYear = MinYear;
                param.MaxYear = MaxYear;
                param.SearchTerm = SearchTerm;

                var result = repo.Search(param).Where(c => c.CarTypeName == "New");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/Inventory/SearchUsed")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchUsed(decimal? MinPrice, decimal? MaxPrice, int? MinYear, int? MaxYear, string SearchTerm)
        {
            var repo = SearchRepositoryFactory.GetRepository();

            try
            {
                var param = new CarSearchParameters();

                param.MinPrice = MinPrice;
                param.MaxPrice = MaxPrice;
                param.MinYear = MinYear;
                param.MaxYear = MaxYear;
                param.SearchTerm = SearchTerm;

                var result = repo.Search(param).Where(c => c.CarTypeName == "Used");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
