using System.Collections.Generic;

using LibrarySystem.Models.Enumerations;
using LibrarySystem.Models.Factory;
using LibrarySystem.Models.Users;

using Moq;
using NUnit.Framework;

namespace LibrarySystem.Models.UnitTests.Factory.ModelsFactoryTests
{
    [TestFixture]
    public class CreateGroup_Should
    {
        [Test]
        [Category("Models.Factory.ModelFactory.CreateGroup")]
        public void ReturnGroupInstance_WhenValidArgumentsPassed()
        {
            // Arrange
            string name = "Sofia";
            var users = new HashSet<User>
            {
                new Mock<User>().Object
            };

            ModelsFactory factoryUnderTest = new ModelsFactory();

            // Act
            var group = factoryUnderTest.CreateGroup(name, users);

            // Assert
            Assert.That(group, Is.InstanceOf<Group>());
        }

        [Test]
        [Category("Models.Factory.ModelFactory.CreateGroup")]
        public void SetGroupProperties_WhenValidArgumentsPassed()
        {
            // Arrange
            string name = "Sofia";
            var users = new HashSet<User>
            {
                new Mock<User>().Object
            };

            ModelsFactory factoryUnderTest = new ModelsFactory();

            // Act
            var group = factoryUnderTest.CreateGroup(name, users);

            // Assert
            Assert.AreSame(name, group.Name);
            Assert.AreSame(users, group.Users);
        }
    }
}
