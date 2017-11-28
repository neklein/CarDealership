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
    public class SalesAPIController : ApiController
    {
        [Route("api/Sales/Index")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Index(decimal? MinPrice, decimal? MaxPrice, int? MinYear, int? MaxYear, string SearchTerm)
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

                var result = repo.Search(param).Where(p => p.IsSold == false);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
