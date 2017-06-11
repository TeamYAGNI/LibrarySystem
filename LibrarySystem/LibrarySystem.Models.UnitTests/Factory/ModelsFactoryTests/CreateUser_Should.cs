using System.Collections.Generic;

using LibrarySystem.Models.Enumerations;
using LibrarySystem.Models.Factory;
using LibrarySystem.Models.Users;

using Moq;
using NUnit.Framework;

namespace LibrarySystem.Models.UnitTests.Factory.ModelsFactoryTests
{
    [TestFixture]
    public class CreateUser_Should
    {
        [Test]
        [Category("Models.Factory.ModelFactory.CreateUser")]
        public void ReturnUserInstance_WhenValidArgumentsPassed()
        {
            // Arrange
            string username = "Sofia";
            string passHash = "SomeHash";
            string authKey = "SomeAuthKey";
            UserType userType = UserType.Master;
            var groups = new HashSet<Group>
            {
                new Mock<Group>().Object
            };

            ModelsFactory factoryUnderTest = new ModelsFactory();

            // Act
            var user = factoryUnderTest.CreateUser(username, passHash, authKey, userType, groups);

            // Assert
            Assert.That(user, Is.InstanceOf<User>());
        }

        [Test]
        [Category("Models.Factory.ModelFactory.CreateUser")]
        public void SetUserProperties_WhenValidArgumentsPassed()
        {
            // Arrange
            string username = "Sofia";
            string passHash = "SomeHash";
            string authKey = "SomeAuthKey";
            UserType userType = UserType.Master;
            var groups = new HashSet<Group>
            {
                new Mock<Group>().Object
            };

            ModelsFactory factoryUnderTest = new ModelsFactory();

            // Act
            var user = factoryUnderTest.CreateUser(username, passHash, authKey, userType, groups);

            // Assert
            Assert.AreSame(username, user.Username);
            Assert.AreSame(passHash, user.PassHash);
            Assert.AreSame(authKey, user.AuthKey);
            Assert.AreSame(groups, user.Groups);

            Assert.AreEqual(userType, user.Type);
        }
    }
}
