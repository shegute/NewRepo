using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories;
namespace Repositories.EF
{
    public class EntityRepository : IPersonRepository
    {
        public void AddPerson(Repositories.Person newPerson)
        {
            throw new NotImplementedException();
        }

        public void DeletePerson(string lastName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Repositories.Person> GetPeople()
        {
            List<Repositories.Person> personList = new List<Repositories.Person>();
            using (var db = new RepositoriesEntities())
            {
                var query = (from person in db.People
                             select person).ToList();

                foreach (var person in query)
                {
                    personList.Add(
                        new Repositories.Person()
                        {
                            FirstName = person.FirstName,
                            LastName = person.LastName,
                            Gender = (Gender)Enum.Parse(typeof(Gender), person.Gender)
                        });
                }
            }

            return personList;
        }

        public Repositories.Person GetPerson(string lastName)
        {

            throw new NotImplementedException();
        }

        public void UpdatePeople(IEnumerable<Repositories.Person> updatedPeople)
        {
            throw new NotImplementedException();
        }

        public void UpdatePerson(string lastName, Repositories.Person updatedPerson)
        {
            throw new NotImplementedException();
        }
    }
}
