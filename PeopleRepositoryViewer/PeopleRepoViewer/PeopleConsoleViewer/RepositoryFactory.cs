using Repositories;
using Repositories.Service;
using Repositories.CSV;
using Repositories.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleConsoleViewer
{
    public static class RepositoryFactory
    {
        public static IPersonRepository GetRepository(RepositoryType repositoryType)
        {
            IPersonRepository personRepo = null;
            switch (repositoryType)
            {
                case RepositoryType.Service:
                    personRepo = new ServiceRepository();
                    break;
                case RepositoryType.CSV:
                    personRepo = new CSVRepository();
                    break;
                case RepositoryType.EF:
                    personRepo = new EntityRepository();
                    break;
                default:
                    throw new ArgumentException("Invalid repository type requested");
            }
            return personRepo;
        }
    }

    public enum RepositoryType
    {
        Service, CSV, EF
    }
}
