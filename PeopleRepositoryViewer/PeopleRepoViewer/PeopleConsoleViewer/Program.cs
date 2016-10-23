using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Service;
using Repositories.CSV;
using Repositories;

namespace PeopleConsoleViewer
{
    class Program
    {
        static void Main(string[] args)
        {

            //IPersonRepository iPersonRepo = new ServiceRepository();
            //IPersonRepository iPersonRepo = new CSVRepository();
            int random = DateTime.Now.Second;
            RepositoryType repoType =
                 random >= 39 ? RepositoryType.Service:
                 random >= 19 ?  RepositoryType.CSV :
                 RepositoryType.EF;
            IPersonRepository iPersonRepo = RepositoryFactory.GetRepository(repoType);

            var people = iPersonRepo.GetPeople();
            foreach (var p in people)
            {
                Console.Write("{0} {1}, {2}", p.FirstName, p.LastName, p.Gender);
                Console.WriteLine();
            }
            Console.WriteLine(random);
            Console.WriteLine("Brought to you by **********{0}", iPersonRepo.GetType().ToString());
        }
    }
}
