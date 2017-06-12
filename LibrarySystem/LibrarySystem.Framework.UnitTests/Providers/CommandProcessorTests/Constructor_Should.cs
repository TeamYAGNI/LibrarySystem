using System;

using LibrarySystem.Commands.Contracts;
using LibrarySystem.Framework.Providers;

using Moq;
using NUnit.Framework;

namespace LibrarySystem.Framework.UnitTests.Providers.CommandProcessorTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        [Category("Framework.Providers.CommandProcessor.Constructor")]
        public void ThrowArgumentNullException_WhenNullPassedAsCommandsFactory()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => new CommandProcessor(null));
        }

        [Test]
        [Category("Framework.Providers.CommandProcessor.Constructor")]
        public void NotThrow_WhenValidCommandsFactoryPassed()
        {
            // Arrange
            var commandsFactoryStub = new Mock<ICommandsFactory>();

            // Act
            // Assert
            Assert.DoesNotThrow(() => new CommandProcessor(commandsFactoryStub.Object));
        }
    }
}
