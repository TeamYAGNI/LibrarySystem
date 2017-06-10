// <copyright file="Constructor_Should.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds unit tests of Group entity model constructor.</summary>

using System.Collections.Generic;

using LibrarySystem.Models.Users;

using NUnit.Framework;

namespace LibrarySystem.Models.UnitTests.Users.GroupTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        [Category("Models.Users.Group.Constructor")]
        public void InstantiateGroup_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var group = new Group();

            // Assert
            Assert.That(group, Is.InstanceOf<Group>());
        }

        [Test]
        [Category("Models.Users.Group.Constructor")]
        public void InstantiateGroupWithIdProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var group = new Group();

            // Assert
            Assert.That(group, Has.Property("Id"));
        }

        [Test]
        [Category("Models.Users.Group.Constructor")]
        public void InstantiateGroupWithNameProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var group = new Group();

            // Assert
            Assert.That(group, Has.Property("Name"));
        }

        [Test]
        [Category("Models.Users.Group.Constructor")]
        public void InstantiateGroupWithUsersProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var group = new Group();

            // Assert
            Assert.That(group, Has.Property("Users"));
        }

        [Test]
        [Category("Models.Users.Group.Constructor")]
        public void InstantiateUsersCollection_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var group = new Group();

            // Assert
            Assert.That(group.Users.Count, Is.Zero);
            Assert.That(group.Users, Is.TypeOf<HashSet<User>>());
        }
    }
}
