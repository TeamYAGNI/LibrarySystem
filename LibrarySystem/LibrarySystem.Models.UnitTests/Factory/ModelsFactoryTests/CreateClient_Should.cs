using System.Collections.Generic;

using LibrarySystem.Models.Enumerations;
using LibrarySystem.Models.Factory;

using Moq;
using NUnit.Framework;

namespace LibrarySystem.Models.UnitTests.Factory.ModelsFactoryTests
{
    [TestFixture]
    public class CreateClient_Should
    {
        [Test]
        [Category("Models.Factory.ModelFactory.CreateClient")]
        public void ReturnClientInstance_WhenValidArgumentsPassed()
        {
            // Arrange
            string firstName = "Sofia";
            string lastName = "Ivanova";
            GenderType genderType = GenderType.Female;
            string pin = "9912121053";
            string phone = "0888777666";
            string email = "valid@e.mail";
            Address address = new Mock<Address>().Object;
            var lendings = new HashSet<Lending>
            {
                new Mock<Lending>().Object
            };

            ModelsFactory factoryUnderTest = new ModelsFactory();

            // Act
            var client = factoryUnderTest.CreateClient(firstName, lastName, genderType, pin, phone, email, address, lendings);

            // Assert
            Assert.That(client, Is.InstanceOf<Client>());
        }

        [Test]
        [Category("Models.Factory.ModelFactory.CreateClient")]
        public void SetClientProperties_WhenValidArgumentsPassed()
        {
            // Arrange
            string firstName = "Sofia";
            string lastName = "Ivanova";
            GenderType genderType = GenderType.Female;
            string pin = "9912121053";
            string phone = "0888777666";
            string email = "valid@e.mail";
            Address address = new Mock<Address>().Object;
            var lendings = new HashSet<Lending>
            {
                new Mock<Lending>().Object
            };

            ModelsFactory factoryUnderTest = new ModelsFactory();

            // Act
            var client = factoryUnderTest.CreateClient(firstName, lastName, genderType, pin, phone, email, address, lendings);

            // Assert
            Assert.AreSame(firstName, client.FirstName);
            Assert.AreSame(lastName, client.LastName);
            Assert.AreSame(pin, client.PIN);
            Assert.AreSame(phone, client.Phone);
            Assert.AreSame(email, client.Email);
            Assert.AreSame(address, client.Address);
            Assert.AreSame(lendings, client.Lendings);

            Assert.AreEqual(genderType, client.GenderType);
        }
    }
}
