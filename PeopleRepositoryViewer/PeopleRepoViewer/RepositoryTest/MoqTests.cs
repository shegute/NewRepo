using System;
using Repositories;
using Repositories.Injector;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;

namespace RepositoryTest
{
    [TestClass]
    public class MoqTests
    {
        [TestInitialize]
        public void Setup()
        {

        }


        [TestMethod]
        public void Test_MockRepository()
        {
            //Arrange
            var people = new List<Person>()
            {
                new Person("Adey","Abeba",Gender.Female),
                new Person("Mestawet","Hailu",Gender.Female)
            };

            var mockRepository = new Mock<IPersonRepository>();
            mockRepository.Setup(r => r.GetPeople()).Returns(people);

            //Act
            var actual = mockRepository.Object.GetPeople();

            //Assert
            Assert.AreEqual(people, actual);
        }

        [TestMethod]
        public void Test_DIMockRepository()
        {
            //Arrange
            var people = new List<Person>()
            {
                new Person("Adey","Abeba",Gender.Female),
                new Person("Mestawet","Hailu",Gender.Female)
            };
            var mockRepository = new Mock<IPersonRepository>();
            mockRepository.Setup(r => r.GetPeople()).Returns(people);
            SimpleContainer.MapInstance<IPersonRepository>(mockRepository.Object);
            IPersonRepository containerRepo = SimpleContainer.Get<IPersonRepository>();

            //Act
            var actual = containerRepo.GetPeople();

            //Assert
            Assert.AreEqual(people, actual);
        }

        [TestMethod]
        public void Test_DIMockRepository_Add()
        {
            //Arrange
            var people = new List<Person>()
            {
                new Person("Adey","Abeba",Gender.Female),
                new Person("Mestawet","Hailu",Gender.Female)
            };
            var newPerson = new Person("Netsi", "Hailu", Gender.Female);

            var mockRepository = new Mock<IPersonRepository>();
            mockRepository.Setup(r => r.GetPeople()).Returns(people);

            Action<Person> callback = (Person p) => { people.Add(p); };
            mockRepository.Setup(r => r.AddPerson(newPerson)).Callback(callback);
            SimpleContainer.MapInstance<IPersonRepository>(mockRepository.Object);

            //Act
            mockRepository.Object.AddPerson(newPerson);
            var actual = mockRepository.Object.GetPeople();

            //Assert
            Assert.AreEqual(people, actual);
        }
    }
}
