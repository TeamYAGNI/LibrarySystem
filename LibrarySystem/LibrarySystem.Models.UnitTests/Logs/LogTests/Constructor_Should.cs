// <copyright file="Constructor_Should.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds unit tests of LogType entity model constructor.</summary>

using System.Collections.Generic;
using LibrarySystem.Models.Logs;
using NUnit.Framework;

namespace LibrarySystem.Models.UnitTests.Logs.LogTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        [Category("Models.Logs.LogType.Constructor")]
        public void InstantiateLogType_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var logType = new LogType();

            // Assert
            Assert.That(logType, Is.InstanceOf<LogType>());
        }

        [Test]
        [Category("Models.Logs.LogType.Constructor")]
        public void InstantiateLogTypeWithIdProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var logType = new LogType();

            // Assert
            Assert.That(logType, Has.Property("Id"));
        }

        [Test]
        [Category("Models.Logs.LogType.Constructor")]
        public void InstantiateLogTypeWithNameProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var logType = new LogType();

            // Assert
            Assert.That(logType, Has.Property("Name"));
        }

        [Test]
        [Category("Models.Logs.LogType.Constructor")]
        public void InstantiateLogTypeWithLogsProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var logType = new LogType();

            // Assert
            Assert.That(logType, Has.Property("Logs"));
        }

        [Test]
        [Category("Models.Logs.LogType.Constructor")]
        public void InstantiateLogsCollection_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var logType = new LogType();

            // Assert
            Assert.That(logType.Logs.Count, Is.Zero);
            Assert.That(logType.Logs, Is.TypeOf<HashSet<Log>>());
        }
    }
}
