﻿using System.Linq;
using Moq;
using SuperBug.Politrange.Data.Contexts;
using SuperBug.Politrange.Data.Repositories;
using SuperBug.Politrange.Models;
using SuperBug.Politrange.Services.Keywords;
using SuperBug.Politrange.Services.Persons;
using SuperBug.Politrange.Services.States;
using Xunit;
using Xunit.Abstractions;

namespace SuperBug.Politrange.Service.UnitTest
{
    public class PersonServiceTest
    {
        private ITestOutputHelper output;
        private IPersonService personService;
        private Mock<IKeywordRepository> keywordRepositoryMock;

        public PersonServiceTest(ITestOutputHelper output)
        {
            this.output = output;
            IPolitrangeContext context = new PolitrangeContext();
            IPersonRepository personRepository = new PersonRepository(context);
            keywordRepositoryMock = new Mock<IKeywordRepository>();
            personService = new PersonService(personRepository,keywordRepositoryMock.Object);
        }

        [Fact]
        public void ShouldBeReturnListPersons()
        {
            //arrange
            

            //act
            var result = personService.GetAll();

            //assert
            Assert.True(result.Any());

            foreach (Person person in result)
            {
                output.WriteLine(person.Name);
            }
            
        }

        [Fact]
        public void ShouldBeReturnSinglePerson()
        {
            //arrange
            int id = 1;

            //act
            var result = personService.GetById(id);

            //assert
            Assert.Equal(result.PersonId, id);         
        }

        [Fact]
        public void ShouldBeAddedPerson()
        {
            //arrange
            var person = new Person(){Name = "Меркель"};

            //act
            var result = personService.Add(person);

            //assert
            Assert.Equal(result.Name, person.Name);

            output.WriteLine(result.PersonId.ToString());
            
        }

        [Fact]
        public void ShouldBeRenamePersonName()
        {
            //arrange
            var repository = new PersonRepository(new PolitrangeContext());
            int id = 1;
            var person = new Person(){Name = "Вилка"};

            //act
            var result = repository.UpdateNew(id, person);

            //assert
            Assert.True(result);
        }

        [Fact]
        public void ShouldBeDeletedPersonById()
        {
            //arrange
            int id = 1;

            //act
            var result = personService.Remove(id);

            //assert
            Assert.True(result);
            
        }
    }
}