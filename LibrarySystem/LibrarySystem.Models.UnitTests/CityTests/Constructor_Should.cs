// <copyright file="Constructor_Should.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds unit tests of Journal entity model constructor.</summary>
 
 using System.Collections.Generic;
 using NUnit.Framework;

namespace LibrarySystem.Models.UnitTests.AuthorTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        [Category("Models.City.Constructor")]
        public void InstantiateCity_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var city = new City();

            //Assert
            Assert.That(city, Is.InstanceOf<City>());
        }

        [Test]
        [Category("Models.City.Constructor")]
        public void InstantiateCityWithIdProperty_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var city = new City();

            //Assert
            Assert.That(city, Has.Property("Id"));
        }

        [Test]
        [Category("Models.City.Constructor")]
        public void InstantiateCityWithNameProperty_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var city = new City();

            //Assert
            Assert.That(city, Has.Property("Name"));
        }

        [Test]
        [Category("Models.City.Constructor")]
        public void InstantiateCityWithAddressesProperty_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var city = new City();

            //Assert
            Assert.That(city, Has.Property("Addresses"));
        }

        [Test]
        [Category("Models.City.Constructor")]
        public void InstantiateAddressesCollection_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var city = new City();

            //Assert
            Assert.That(city.Addresses.Count, Is.Zero);
            Assert.That(city.Addresses, Is.TypeOf<HashSet<Address>>());
        }
    }
}
