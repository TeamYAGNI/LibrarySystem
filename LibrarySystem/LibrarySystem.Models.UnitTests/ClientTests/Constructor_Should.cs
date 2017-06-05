// <copyright file="Constructor_Should.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds unit tests of Journal entity model constructor.</summary>
 
 using System.Collections.Generic;
 using LibrarySystem.Models.Enumerations;
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
            // Arrange
            // Act
            var client = new Client();

            // Assert
            Assert.That(client, Is.InstanceOf<Client>());
        }

        [Test]
        [Category("Models.Client.Constructor")]
        public void InstantiateClientWithIdProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var client = new Client();

            // Assert
            Assert.That(client, Has.Property("Id"));
        }

        [Test]
        [Category("Models.Client.Constructor")]
        public void InstantiateClientWithFirstNameProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var client = new Client();

            // Assert
            Assert.That(client, Has.Property("FirstName"));
        }

        [Test]
        [Category("Models.Client.Constructor")]
        public void InstantiateClientWithLastNameProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var client = new Client();

            // Assert
            Assert.That(client, Has.Property("LastName"));
        }

        [Test]
        [Category("Models.Client.Constructor")]
        public void InstantiateClientWithFullNameProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var client = new Client();

            // Assert
            Assert.That(client, Has.Property("FullName"));
        }

        [Test]
        [Category("Models.Client.Constructor")]
        public void ReturnStringJoiningFirstAndLastName_WhenInvoked()
        {
            // Arrange
            string firstName = "John";
            string lastName = "Doe";

            string expectedFullName = "John Doe";

            var client = new Client();
            client.FirstName = firstName;
            client.LastName = lastName;

            // Act
            // Assert
            Assert.AreEqual(expectedFullName, client.FullName);
        }

        [Test]
        [Category("Models.Client.Constructor")]
        public void InstantiateClientWithGenderTypeProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var client = new Client();

            // Assert
            Assert.That(client, Has.Property("GenderType"));
            Assert.That(client.GenderType, Is.EqualTo(GenderType.NotSpecified));
        }

        [Test]
        [Category("Models.Client.Constructor")]
        public void InstantiateClientWithPINProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var client = new Client();

            // Assert
            Assert.That(client, Has.Property("PIN"));
        }

        [Test]
        [Category("Models.Client.Constructor")]
        public void InstantiateClientWithPhoneProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var client = new Client();

            // Assert
            Assert.That(client, Has.Property("Phone"));
        }

        [Test]
        [Category("Models.Client.Constructor")]
        public void InstantiateClientWithEmailProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var client = new Client();

            // Assert
            Assert.That(client, Has.Property("Email"));
        }

        [Test]
        [Category("Models.Client.Constructor")]
        public void InstantiateClientWithAddressIdProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var client = new Client();

            // Assert
            Assert.That(client, Has.Property("AddressId"));
        }

        [Test]
        [Category("Models.Client.Constructor")]
        public void InstantiateClientWithAddressProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var client = new Client();

            // Assert
            Assert.That(client, Has.Property("Address"));
        }

        [Test]
        [Category("Models.Client.Constructor")]
        public void InstantiateClientWithLendingsProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var client = new Client();

            // Assert
            Assert.That(client, Has.Property("Lendings"));
        }

        [Test]
        [Category("Models.Client.Constructor")]
        public void InstantiateLendingsCollection_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var client = new Client();

            // Assert
            Assert.That(client.Lendings.Count, Is.Zero);
            Assert.That(client.Lendings, Is.TypeOf<HashSet<Lending>>());
        }
    }
}
