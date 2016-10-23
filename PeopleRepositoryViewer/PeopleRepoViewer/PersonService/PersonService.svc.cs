using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PersonService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PersonService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PersonService.svc or PersonService.svc.cs at the Solution Explorer and start debugging.
    public class PersonService : IPersonService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public IEnumerable<Person> GetPeople()
        {
            var people = new List<Person>
            {new Person ("Nate","Le",Gender.Male ),
            new Person ("Shi", "Meles",Gender.Male),
            new Person("Serki","Alem",Gender.Female)
            };
            return people;
        }

        public Person GetPerson(string lastName)
        {
            return null;
        }
        public void AddPerson(Person newPerson)
        {
        }
        public void UpdatePerson(string lastName, Person updatedPerson)
        { }
        public void DeletePerson(string lastName)
        { }
        public void UpdatePeople(List<Person> updatedPeople)
        { }
    }
}
