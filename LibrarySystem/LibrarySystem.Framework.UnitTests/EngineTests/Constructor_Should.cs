using System;

using LibrarySystem.Framework.Contracts;

using Moq;
using NUnit.Framework;

namespace LibrarySystem.Framework.UnitTests.EngineTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        [Category("Framework.Engine.Constructor")]
        public void ThrowArgumentNullException_WhenNullPassedAsCommandReader()
        {
            // Arrange
            var responseWriterStub = new Mock<IResponseWriter>();
            var commandProccessorStub = new Mock<ICommandProcessor>();
            var loggerStub = new Mock<ILogger>();

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => new Engine(null, responseWriterStub.Object, commandProccessorStub.Object, loggerStub.Object));
        }

        [Test]
        [Category("Framework.Engine.Constructor")]
        public void ThrowArgumentNullException_WhenNullPassedAsResponseWriter()
        {
            // Arrange
            var commandReaderStub = new Mock<ICommandReader>();
            var commandProccessorStub = new Mock<ICommandProcessor>();
            var loggerStub = new Mock<ILogger>();

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => new Engine(commandReaderStub.Object, null, commandProccessorStub.Object, loggerStub.Object));
        }

        [Test]
        [Category("Framework.Engine.Constructor")]
        public void ThrowArgumentNullException_WhenNullPassedAsCommandProcessor()
        {
            // Arrange
            var commandReaderStub = new Mock<ICommandReader>();
            var responseWriterStub = new Mock<IResponseWriter>();
            var loggerStub = new Mock<ILogger>();

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => new Engine(commandReaderStub.Object, responseWriterStub.Object, null, loggerStub.Object));
        }

        [Test]
        [Category("Framework.Engine.Constructor")]
        public void NotThrow_WhenPassedValidArguments()
        {
            // Arrange
            var commandReaderStub = new Mock<ICommandReader>();
            var responseWriterStub = new Mock<IResponseWriter>();
            var commandProccessorStub = new Mock<ICommandProcessor>();
            var loggerStub = new Mock<ILogger>();

            // Act
            // Assert
            Assert.DoesNotThrow(() => new Engine(commandReaderStub.Object, responseWriterStub.Object, commandProccessorStub.Object, loggerStub.Object));
        }
    }
}
