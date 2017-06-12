using System;

using LibrarySystem.Models.Factory;
using LibrarySystem.Models.Logs;

using Moq;
using NUnit.Framework;

namespace LibrarySystem.Models.UnitTests.Factory.ModelsFactoryTests
{
    [TestFixture]
    public class CreateLog_Should
    {
        [Test]
        [Category("Models.Factory.ModelFactory.CreateLog")]
        public void ReturnLogInstance_WhenValidArgumentsPassed()
        {
            // Arrange
            string message = "Sofia";
            var dateTime = new DateTime(2012, 12, 18);
            var logType = new Mock<LogType>().Object;
            
            ModelsFactory factoryUnderTest = new ModelsFactory();

            // Act
            var log = factoryUnderTest.CreateLog(message, dateTime, logType);

            // Assert
            Assert.That(log, Is.InstanceOf<Log>());
        }

        [Test]
        [Category("Models.Factory.ModelFactory.CreateLog")]
        public void SetLogProperties_WhenValidArgumentsPassed()
        {
            // Arrange
            string message = "Sofia";
            var dateTime = new DateTime(2012, 12, 18);
            var logType = new Mock<LogType>().Object;

            ModelsFactory factoryUnderTest = new ModelsFactory();

            // Act
            var log = factoryUnderTest.CreateLog(message, dateTime, logType);

            // Assert
            Assert.AreSame(message, log.Message);
            Assert.AreSame(logType, log.LogType);

            Assert.AreEqual(dateTime, log.DateTime);
        }
    }
}
