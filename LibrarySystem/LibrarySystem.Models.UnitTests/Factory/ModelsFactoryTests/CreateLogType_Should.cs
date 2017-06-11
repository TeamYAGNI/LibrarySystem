using System.Collections.Generic;

using LibrarySystem.Models.Enumerations;
using LibrarySystem.Models.Factory;
using LibrarySystem.Models.Logs;

using Moq;
using NUnit.Framework;

namespace LibrarySystem.Models.UnitTests.Factory.ModelsFactoryTests
{
    [TestFixture]
    public class CreateLogType_Should
    {
        [Test]
        [Category("Models.Factory.ModelFactory.CreateLogType")]
        public void ReturnLogTypeInstance_WhenValidArgumentsPassed()
        {
            // Arrange
            string name = "Sofia";
            var logs = new HashSet<Log>
            {
                new Mock<Log>().Object
            };

            ModelsFactory factoryUnderTest = new ModelsFactory();

            // Act
            var logType = factoryUnderTest.CreateLogType(name, logs);

            // Assert
            Assert.That(logType, Is.InstanceOf<LogType>());
        }

        [Test]
        [Category("Models.Factory.ModelFactory.CreateLogType")]
        public void SetLogTypeProperties_WhenValidArgumentsPassed()
        {
            // Arrange
            string name = "Sofia";
            var logs = new HashSet<Log>
            {
                new Mock<Log>().Object
            };

            ModelsFactory factoryUnderTest = new ModelsFactory();

            // Act
            var logType = factoryUnderTest.CreateLogType(name, logs);

            // Assert
            Assert.AreSame(name, logType.Name);
            Assert.AreSame(logs, logType.Logs);
        }
    }
}
