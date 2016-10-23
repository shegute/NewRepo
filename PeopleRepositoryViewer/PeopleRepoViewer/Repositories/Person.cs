using System.Runtime.Serialization;

namespace Repositories
{

    [DataContract]
    public class Person
    {
        public Person(string f, string l, Gender g)
        {
            FirstName = f; LastName = l; Gender = g;
        }

        public Person()
        {
        }

        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public Gender Gender { get; set; }
    }

    public enum Gender
    { Male, Female }
}