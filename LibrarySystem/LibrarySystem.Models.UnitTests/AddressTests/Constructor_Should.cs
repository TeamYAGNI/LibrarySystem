// <copyright file="Constructor_Should.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds unit tests of Address entity model constructor.</summary>

using System.Collections.Generic;
using NUnit.Framework;

namespace LibrarySystem.Models.UnitTests.AddressTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        [Category("Models.Address.Constructor")]
        public void InstantiateAddress_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var address = new Address();

            // Assert
            Assert.That(address, Is.InstanceOf<Address>());
        }

        [Test]
        [Category("Models.Address.Constructor")]
        public void InstantiateAddressWithIdProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var address = new Address();

            // Assert
            Assert.That(address, Has.Property("Id"));
        }

        [Test]
        [Category("Models.Address.Constructor")]
        public void InstantiateAddressWithStreetProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var address = new Address();

            // Assert
            Assert.That(address, Has.Property("Street"));
        }

        [Test]
        [Category("Models.Address.Constructor")]
        public void InstantiateAddressWithStreetNumberProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var address = new Address();

            // Assert
            Assert.That(address, Has.Property("StreetNumber"));
        }

        [Test]
        [Category("Models.Address.Constructor")]
        public void InstantiateAddressWithCityIdProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var address = new Address();

            // Assert
            Assert.That(address, Has.Property("CityId"));
        }

        [Test]
        [Category("Models.Address.Constructor")]
        public void InstantiateAddressWithCityProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var address = new Address();

            // Assert
            Assert.That(address, Has.Property("City"));
        }

        [Test]
        [Category("Models.Address.Constructor")]
        public void InstantiateAddressWithClientsProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var address = new Address();

            // Assert
            Assert.That(address, Has.Property("Clients"));
        }

        [Test]
        [Category("Models.Address.Constructor")]
        public void InstantiateAddressWithEmployeesProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var address = new Address();

            // Assert
            Assert.That(address, Has.Property("Employees"));
        }

        [Test]
        [Category("Models.Address.Constructor")]
        public void InstantiateClientsCollection_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var address = new Address();

            // Assert
            Assert.That(address.Clients.Count, Is.Zero);
            Assert.That(address.Clients, Is.TypeOf<HashSet<Client>>());
        }

        [Test]
        [Category("Models.Address.Constructor")]
        public void InstantiateEmployeesCollection_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var address = new Address();

            // Assert
            Assert.That(address.Employees.Count, Is.Zero);
            Assert.That(address.Employees, Is.TypeOf<HashSet<Employee>>());
        }
    }
}