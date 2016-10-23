using Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using Repositories.Injector; 

namespace PeopleConsoleViewer.DI
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int random = DateTime.Now.Second % 2;
                IPersonRepository iPersonRepo =
                    random > 0 ? GetRepoFromConfig() :
                    //GetRepoFromConfig<IPersonRepository>();
                  SimpleContainer.Get<IPersonRepository>();

                var people = iPersonRepo.GetPeople();
                foreach (var p in people)
                {
                    Console.Write("{0} {1}, {2}", p.FirstName, p.LastName, p.Gender);
                    Console.WriteLine();
                }
                Console.WriteLine("Brought to you by **********{0}", iPersonRepo.GetType().ToString());
            }
        }

        public static IPersonRepository GetRepoFromConfig()
        {
            string type = ConfigurationManager.AppSettings["RepositoryType"];
            Type repoType = Type.GetType(type);
            object repoInstance = Activator.CreateInstance(repoType);
            IPersonRepository repo = repoInstance as IPersonRepository;
            return repo;
        }

    }
}
