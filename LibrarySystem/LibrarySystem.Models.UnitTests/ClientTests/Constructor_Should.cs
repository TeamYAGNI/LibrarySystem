// <copyright file="Constructor_Should.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds unit tests of Journal entity model constructor.</summary>
 
 using System.Collections.Generic;
 using NUnit.Framework;

namespace LibrarySystem.Models.UnitTests.ClientTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        [Category("Models.Client.Constructor")]
        public void InstantiateClient_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var client = new Client();

            //Assert
            Assert.That(client, Is.InstanceOf<Client>());
        }

        [Test]
        [Category("Models.Client.Constructor")]
        public void InstantiateClientWithIdProperty_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var client = new Client();

            //Assert
            Assert.That(client, Has.Property("Id"));
        }

        [Test]
        [Category("Models.Client.Constructor")]
        public void InstantiateClientWithNameProperty_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var client = new Client();

            //Assert
            Assert.That(client, Has.Property("Name"));
        }

        [Test]
        [Category("Models.Client.Constructor")]
        public void InstantiateClientWithPINProperty_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var client = new Client();

            //Assert
            Assert.That(client, Has.Property("PIN"));
        }

        [Test]
        [Category("Models.Client.Constructor")]
        public void InstantiateClientWithPhoneProperty_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var client = new Client();

            //Assert
            Assert.That(client, Has.Property("Phone"));
        }

        [Test]
        [Category("Models.Client.Constructor")]
        public void InstantiateClientWithEmailProperty_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var client = new Client();

            //Assert
            Assert.That(client, Has.Property("Email"));
        }

        [Test]
        [Category("Models.Client.Constructor")]
        public void InstantiateClientWithAddressIdProperty_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var client = new Client();

            //Assert
            Assert.That(client, Has.Property("AddressId"));
        }

        [Test]
        [Category("Models.Client.Constructor")]
        public void InstantiateClientWithAddressProperty_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var client = new Client();

            //Assert
            Assert.That(client, Has.Property("Address"));
        }

        [Test]
        [Category("Models.Client.Constructor")]
        public void InstantiateClientWithLendingsProperty_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var client = new Client();

            //Assert
            Assert.That(client, Has.Property("Lendings"));
        }

        [Test]
        [Category("Models.Client.Constructor")]
        public void InstantiateLendingsCollection_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var client = new Client();

            //Assert
            Assert.That(client.Lendings.Count, Is.Zero);
            Assert.That(client.Lendings, Is.TypeOf<HashSet<Lending>>());
        }

    }
}
