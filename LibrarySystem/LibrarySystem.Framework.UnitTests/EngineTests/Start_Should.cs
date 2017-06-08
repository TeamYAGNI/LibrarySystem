using System;
using System.ComponentModel.DataAnnotations;

using LibrarySystem.Framework.Contracts;

using Moq;
using NUnit.Framework;

namespace LibrarySystem.Framework.UnitTests.EngineTests
{
    [TestFixture]
    public class Start_Should
    {
        [Test]
        [Category("Framework.Engine.Start")]
        public void CallCommandReaderReadLineExactlyOnce_WhenTerminateCommandIsProvided()
        {
            // Arrange
            var commandReaderMock = new Mock<ICommandReader>();
            var responseWriterStub = new Mock<IResponseWriter>();
            var commandProccessorStub = new Mock<ICommandProcessor>();

            var engineUnderTest = new Engine(commandReaderMock.Object, responseWriterStub.Object, commandProccessorStub.Object);

            string terminateCommand = "Exit";

            commandReaderMock.Setup(c => c.ReadLine()).Returns(terminateCommand);

            // Act
            engineUnderTest.Start();

            // Assert
            commandReaderMock.Verify(c => c.ReadLine(), Times.Once);
        }

        [Test]
        [Category("Framework.Engine.Start")]
        public void DoesNotCallCommandProcessorProcessCommand_WhenOnlyTerminateCommandIsProvided()
        {
            // Arrange
            var commandReaderStub = new Mock<ICommandReader>();
            var responseWriterStub = new Mock<IResponseWriter>();
            var commandProccessorMock = new Mock<ICommandProcessor>();

            var engineUnderTest = new Engine(commandReaderStub.Object, responseWriterStub.Object, commandProccessorMock.Object);

            string terminateCommand = "Exit";

            commandReaderStub.Setup(c => c.ReadLine()).Returns(terminateCommand);

            // Act
            engineUnderTest.Start();

            // Assert
            commandProccessorMock.Verify(r => r.ProcessCommand(It.IsAny<string>()), Times.Never);
        }

        [Test]
        [Category("Framework.Engine.Start")]
        public void CallCommandReaderReadLineExactlyTwice_WhenTerminateCommandIsProvidedAfterASingleOtherCommand()
        {
            // Arrange
            var commandReaderMock = new Mock<ICommandReader>();
            var responseWriterStub = new Mock<IResponseWriter>();
            var commandProccessorStub = new Mock<ICommandProcessor>();

            var engineUnderTest = new Engine(commandReaderMock.Object, responseWriterStub.Object, commandProccessorStub.Object);

            string singleOtherCommand = "SomeRandomCommand";
            string terminateCommand = "Exit";

            commandReaderMock.SetupSequence(c => c.ReadLine()).Returns(singleOtherCommand).Returns(terminateCommand);

            // Act
            engineUnderTest.Start();

            // Assert
            commandReaderMock.Verify(c => c.ReadLine(), Times.Exactly(2));
        }

        [Test]
        [Category("Framework.Engine.Start")]
        public void CallCommandProcessorProcessCommandExactlyOnceWithExpectedCommand_WhenTerminateCommandIsProvidedAfterTheExpectedCommand()
        {
            // Arrange
            var commandReaderStub = new Mock<ICommandReader>();
            var responseWriterStub = new Mock<IResponseWriter>();
            var commandProccessorMock = new Mock<ICommandProcessor>();

            var engineUnderTest = new Engine(commandReaderStub.Object, responseWriterStub.Object, commandProccessorMock.Object);

            string expectedCommand = "SomeRandomCommand";
            string terminateCommand = "Exit";

            commandReaderStub.SetupSequence(c => c.ReadLine()).Returns(expectedCommand).Returns(terminateCommand);

            // Act
            engineUnderTest.Start();

            // Assert
            commandProccessorMock.Verify(c => c.ProcessCommand(expectedCommand), Times.Once);
        }

        [Test]
        [Category("Framework.Engine.Start")]
        public void CallResponseWriterWriteExactlyOnceWithExpectedResponse_WhenTerminateCommandIsProvidedAfterASingleOtherCommand()
        {
            // Arrange
            var commandReaderStub = new Mock<ICommandReader>();
            var responseWriterMock = new Mock<IResponseWriter>();
            var commandProccessorStub = new Mock<ICommandProcessor>();

            var engineUnderTest = new Engine(commandReaderStub.Object, responseWriterMock.Object, commandProccessorStub.Object);

            string singleOtherCommand = "SomeRandomCommand";
            string terminateCommand = "Exit";

            commandReaderStub.SetupSequence(c => c.ReadLine()).Returns(singleOtherCommand).Returns(terminateCommand);

            string expectedResponse = "SomeRandomResponse";

            commandProccessorStub.Setup(c => c.ProcessCommand(It.IsAny<string>())).Returns(expectedResponse);

            // Act
            engineUnderTest.Start();

            // Assert
            responseWriterMock.Verify(r => r.Write(It.Is<string>(s => s.Contains(expectedResponse))), Times.Once);
        }

        [Test]
        [Category("Framework.Engine.Start")]
        public void CallResponseWriterWriteLineExactlyOnceWithTerminateMessage_WhenOnlyTerminateCommandIsProvided()
        {
            // Arrange
            var commandReaderStub = new Mock<ICommandReader>();
            var responseWriterMock = new Mock<IResponseWriter>();
            var commandProccessorStub = new Mock<ICommandProcessor>();

            var engineUnderTest = new Engine(commandReaderStub.Object, responseWriterMock.Object, commandProccessorStub.Object);

            string terminateCommand = "Exit";

            commandReaderStub.Setup(c => c.ReadLine()).Returns(terminateCommand);

            string terminateMessage = "Program terminated.";

            // Act
            engineUnderTest.Start();

            // Assert
            responseWriterMock.Verify(r => r.WriteLine(terminateMessage), Times.Once);
        }

        [Test]
        [Category("Framework.Engine.Start")]
        public void CallResponseWriterWriteLineExactlyOnceWithTerminateMessage_WhenTerminateCommandIsProvidedAfterASingleOtherCommand()
        {
            // Arrange
            var commandReaderStub = new Mock<ICommandReader>();
            var responseWriterMock = new Mock<IResponseWriter>();
            var commandProccessorStub = new Mock<ICommandProcessor>();

            var engineUnderTest = new Engine(commandReaderStub.Object, responseWriterMock.Object, commandProccessorStub.Object);

            string singleOtherCommand = "SomeRandomCommand";
            string terminateCommand = "Exit";

            commandReaderStub.SetupSequence(c => c.ReadLine()).Returns(singleOtherCommand).Returns(terminateCommand);

            string expectedResponse = "SomeRandomResponse";
            
            commandProccessorStub.Setup(c => c.ProcessCommand(It.IsAny<string>())).Returns(expectedResponse);

            string terminateMessage = "Program terminated.";

            // Act
            engineUnderTest.Start();

            // Assert
            responseWriterMock.Verify(r => r.WriteLine(terminateMessage), Times.Once);
        }

        [Test]
        [Category("Framework.Engine.Start")]
        public void CallResponseWriterWriteExactlyOnceWithExceptionMessage_WhenExceptionOccurred()
        {
            // Arrange
            var commandReaderStub = new Mock<ICommandReader>();
            var responseWriterMock = new Mock<IResponseWriter>();
            var commandProccessorStub = new Mock<ICommandProcessor>();

            var engineUnderTest = new Engine(commandReaderStub.Object, responseWriterMock.Object, commandProccessorStub.Object);

            string singleOtherCommand = "SomeRandomCommand";
            string terminateCommand = "Exit";

            commandReaderStub.SetupSequence(c => c.ReadLine()).Returns(singleOtherCommand).Returns(terminateCommand);

            string exceptionMessage = "ExpectedFailureMessage";

            commandProccessorStub.Setup(c => c.ProcessCommand(It.IsAny<string>())).Throws(new ValidationException(exceptionMessage));

            // Act
            engineUnderTest.Start();

            // Assert
            responseWriterMock.Verify(r => r.Write(It.Is<string>(s => s.Contains(exceptionMessage))), Times.Once);
        }
    }
}
