using Microsoft.AspNetCore.Mvc;

using Moq;

using System;
using System.Collections.Generic;

using TaskTele.Controllers;
using TaskTele.Data.Interfaces;
using TaskTele.Data.Models;

using Xunit;

namespace TaskTele.Tests.Controller
{
    public class PersonsControllerTests
    {

        private readonly Mock<IPerson> _mockRepo;
        private readonly PersonsController _controller;


        public PersonsControllerTests () {
            _mockRepo = new Mock<IPerson>();
            _controller = new PersonsController(_mockRepo.Object);
        }



        [Fact]
        public void NotNullTest () {


            //Arrange
            string sex = "";
            string x = "";
            string y = "";

            var mock = new Mock<IPerson>();
 


            mock.Setup(repo => repo.Persons).Returns(GetTestUsers());

            var controller = new PersonsController(mock.Object);
           


            // Act
            var result = controller.List(sex, x, y);
            

            // Assert
            Assert.NotNull(result);

        }

        [Fact]
        public void EqualsTest () {


        }

        private List<Person> GetTestUsers () {
            var users = new List<Person>
            {
               new Person { name = "Stan Smith", age = 25, sex = true },   //male = true, female false
                    new Person { name = "Jack Anderson", age = 26, sex = true },
                    new Person { name = "Olga Popova", age = 60, sex = false },
                    new Person { name = "Erzhena Koroleva", age = 27, sex = false },
                    new Person { name = "German Titov", age = 10, sex = true }, // first
                    new Person { name = "Dmitry Vegas", age = 90, sex = true }, // last 
                    new Person { name = "Solomon Shlemovich", age = 45, sex = true },
                    new Person { name = "Alex Whitedrinker", age = 22, sex = false },
                    new Person { name = "Anna Titova", age = 37, sex = false },
                    new Person { name = "Elmo Kennedy", age = 29, sex = true },
                    new Person { name = "Sascha Braemer", age = 31, sex = true },
                    new Person { name = "Pishkun Vladislav", age = 41, sex = true },
                    new Person { name = "Jessica Braemer", age = 20, sex = false }
            };
            return users;


        }
    }
}
