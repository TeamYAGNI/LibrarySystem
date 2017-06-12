using System.Collections.Generic;

using LibrarySystem.Models.Factory;

using Moq;
using NUnit.Framework;

namespace LibrarySystem.Models.UnitTests.Factory.ModelsFactoryTests
{
    [TestFixture]
    public class CreateCity_Should
    {
        [Test]
        [Category("Models.Factory.ModelFactory.CreateCity")]
        public void ReturnCityInstance_WhenValidArgumentsPassed()
        {
            // Arrange
            string name = "Sofia";
            var addresses = new HashSet<Address>
            {
                new Mock<Address>().Object
            };

            ModelsFactory factoryUnderTest = new ModelsFactory();

            // Act
            var city = factoryUnderTest.CreateCity(name, addresses);

            // Assert
            Assert.That(city, Is.InstanceOf<City>());
        }

        [Test]
        [Category("Models.Factory.ModelFactory.CreateCity")]
        public void SetCityProperties_WhenValidArgumentsPassed()
        {
            // Arrange
            string name = "Sofia";
            var addresses = new HashSet<Address>
            {
                new Mock<Address>().Object
            };

            ModelsFactory factoryUnderTest = new ModelsFactory();

            // Act
            var city = factoryUnderTest.CreateCity(name, addresses);

            // Assert
            Assert.AreSame(name, city.Name);
            Assert.AreSame(addresses, city.Addresses);
        }
    }
}
