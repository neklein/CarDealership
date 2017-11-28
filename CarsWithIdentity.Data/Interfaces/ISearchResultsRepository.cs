using CarsWithIdentity.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsWithIdentity.Data.Interfaces
{
    public interface ISearchResultsRepository
    {
        IEnumerable<SearchResult> Search(CarSearchParameters parameters);
    }
}
