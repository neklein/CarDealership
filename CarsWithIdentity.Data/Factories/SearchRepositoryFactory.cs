using CarsWithIdentity.Data.ADORepositories;
using CarsWithIdentity.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsWithIdentity.Data.Factories
{
    public class SearchRepositoryFactory
    {
        public static ISearchResultsRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "PROD":
                    return new SearchResultsRepositoryADO();
                default:
                    throw new Exception("Could not find a valid repository type.");
            }

        }
    }
}
