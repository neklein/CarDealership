using CarsWithIdentity.Data.ADORepositories;
using CarsWithIdentity.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsWithIdentity.Data.Factories
{
    public class ContactUsFactory
    {
        public static IContactUsRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "PROD":
                    return new ContactUsRepositoryADO();
                default:
                    throw new Exception("Could not find a valid repository type.");
            }
        }
    }
}
