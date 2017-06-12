using System.Collections.Generic;

using LibrarySystem.Models.Factory;

using Moq;
using NUnit.Framework;

namespace LibrarySystem.Models.UnitTests.Factory.ModelsFactoryTests
{
    [TestFixture]
    public class CreateAddress_Should
    {
        [Test]
        [Category("Models.Factory.ModelFactory.CreateAddress")]
        public void ReturnAddressInstance_WhenValidArgumentsPassed()
        {
            // Arrange
            string street = "Alexander Malinov";
            int? streetNumber = 31;
            var city = new Mock<City>();
            var clients = new HashSet<Client> { new Mock<Client>().Object };
            var employees = new HashSet<Employee>
            {
                new Mock<Employee>().Object
            };

            ModelsFactory factoryUnderTest = new ModelsFactory();

            // Act
            var address = factoryUnderTest.CreateAddress(street, streetNumber, city.Object, clients, employees);

            // Assert
            Assert.That(address, Is.InstanceOf<Address>());
        }

        [Test]
        [Category("Models.Factory.ModelFactory.CreateAddress")]
        public void SetAddressProperties_WhenValidArgumentsPassed()
        {
            // Arrange
            string street = "Alexander Malinov";
            int? streetNumber = 31;
            var city = new Mock<City>().Object;
            var clients = new HashSet<Client> { new Mock<Client>().Object };
            var employees = new HashSet<Employee>
            {
                new Mock<Employee>().Object
            };

            ModelsFactory factoryUnderTest = new ModelsFactory();

            // Act
            var address = factoryUnderTest.CreateAddress(street, streetNumber, city, clients, employees);

            // Assert
            Assert.AreSame(street, address.Street);
            Assert.AreSame(city, address.City);
            Assert.AreSame(clients, address.Clients);
            Assert.AreSame(employees, address.Employees);

            Assert.AreEqual(streetNumber, address.StreetNumber);
        }
    }
}
