using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Repositories;

namespace Repositories.CSV
{
    public class CSVRepository : IPersonRepository
    {
         public static string filepath
            = ConfigurationManager.AppSettings["CSVFilepath"];
        //= @"C:\Users\Nate\Documents\Visual Studio 2015\Projects\PeopleRepoViewer\Repositories.CSV\PeopleCSVFile.txt";

        public CSVRepository()
        {
        }

        public void AddPerson(Person newPerson)
        {
            throw new NotImplementedException();
        }

        public void DeletePerson(string lastName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetPeople()
        {
            List<Person> people = new List<Person>();
            var reader = new StreamReader(File.OpenRead(filepath));
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                Gender g;
                g = (Gender)Enum.Parse(typeof(Gender), values[2].Trim());
                Enum.TryParse<Gender>(values[2].Trim(), out g);
                people.Add(new Person(values[0], values[1], g));
            }
            return people;
        }

        public Person GetPerson(string lastName)
        {
            throw new NotImplementedException();
        }

        public void UpdatePeople(IEnumerable<Person> updatedPeople)
        {
            throw new NotImplementedException();
        }

        public void UpdatePerson(string lastName, Person updatedPerson)
        {
            throw new NotImplementedException();
        }
    }
}
