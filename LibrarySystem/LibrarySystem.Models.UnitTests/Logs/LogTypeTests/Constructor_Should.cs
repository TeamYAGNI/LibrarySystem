// <copyright file="Constructor_Should.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds unit tests of Log entity model constructor.</summary>

using LibrarySystem.Models.Logs;
using NUnit.Framework;

namespace LibrarySystem.Models.UnitTests.Logs.LogTypeTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        [Category("Models.Logs.Log.Constructor")]
        public void InstantiateLog_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var log = new Log();

            // Assert
            Assert.That(log, Is.InstanceOf<Log>());
        }

        [Test]
        [Category("Models.Logs.Log.Constructor")]
        public void InstantiateLogWithIdProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var log = new Log();

            // Assert
            Assert.That(log, Has.Property("Id"));
        }

        [Test]
        [Category("Models.Logs.Log.Constructor")]
        public void InstantiateLogWithMessageProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var log = new Log();

            // Assert
            Assert.That(log, Has.Property("Message"));
        }

        [Test]
        [Category("Models.Logs.Log.Constructor")]
        public void InstantiateLogWithDateTimeProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var log = new Log();

            // Assert
            Assert.That(log, Has.Property("DateTime"));
        }

        [Test]
        [Category("Models.Logs.Log.Constructor")]
        public void InstantiateLogWithLogTypeIdProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var log = new Log();

            // Assert
            Assert.That(log, Has.Property("LogTypeId"));
        }

        [Test]
        [Category("Models.Logs.Log.Constructor")]
        public void InstantiateLogWithLogTypeProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var log = new Log();

            // Assert
            Assert.That(log, Has.Property("LogType"));
        }
    }
}
