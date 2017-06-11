// <copyright file="Constructor_Should.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds unit tests of User entity model constructor.</summary>

using System.Collections.Generic;

using LibrarySystem.Models.Users;

using NUnit.Framework;

namespace LibrarySystem.Models.UnitTests.Users.UserTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        [Category("Models.Users.User.Constructor")]
        public void InstantiateUser_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var user = new User();

            // Assert
            Assert.That(user, Is.InstanceOf<User>());
        }

        [Test]
        [Category("Models.Users.User.Constructor")]
        public void InstantiateUserWithIdProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var user = new User();

            // Assert
            Assert.That(user, Has.Property("Id"));
        }

        [Test]
        [Category("Models.Users.User.Constructor")]
        public void InstantiateUserWithUsernameProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var user = new User();

            // Assert
            Assert.That(user, Has.Property("Username"));
        }

        [Test]
        [Category("Models.Users.User.Constructor")]
        public void InstantiateUserWithPassHashProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var user = new User();

            // Assert
            Assert.That(user, Has.Property("PassHash"));
        }

        [Test]
        [Category("Models.Users.User.Constructor")]
        public void InstantiateUserWithAuthKeyProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var user = new User();

            // Assert
            Assert.That(user, Has.Property("AuthKey"));
        }

        [Test]
        [Category("Models.Users.User.Constructor")]
        public void InstantiateUserWithTypeProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var user = new User();

            // Assert
            Assert.That(user, Has.Property("Type"));
        }

        [Test]
        [Category("Models.Users.User.Constructor")]
        public void InstantiateUserWithGroupsProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var user = new User();

            // Assert
            Assert.That(user, Has.Property("Groups"));
        }

        [Test]
        [Category("Models.Users.User.Constructor")]
        public void InstantiateGroupsCollection_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var user = new User();

            // Assert
            Assert.That(user.Groups.Count, Is.Zero);
            Assert.That(user.Groups, Is.TypeOf<HashSet<Group>>());
        }
    }
}
