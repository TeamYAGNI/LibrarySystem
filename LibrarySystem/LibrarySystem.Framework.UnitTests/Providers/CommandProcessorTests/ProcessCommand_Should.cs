using System;
using System.Collections.Generic;

using LibrarySystem.Commands.Contracts;
using LibrarySystem.Framework.Providers;

using Moq;
using NUnit.Framework;

namespace LibrarySystem.Framework.UnitTests.Providers.CommandProcessorTests
{
    [TestFixture]
    public class ProcessCommand_Should
    {
        [Test]
        [Category("Framework.Providers.CommandProcessor.ProcessCommand")]
        public void ThrowArgumentNullException_WhenNullPassedAsArgument()
        {
            // Arrange
            var commandsFactoryStub = new Mock<ICommandsFactory>();
            var commandProcessorUnderTest = new CommandProcessor(commandsFactoryStub.Object);

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => commandProcessorUnderTest.ProcessCommand(null));
        }

        [Test]
        [Category("Framework.Providers.CommandProcessor.ProcessCommand")]
        public void CallCommandsFactoryGetCommandExactlyOnesWithCommandName_WhenValidStringPassedAsArgument()
        {
            // Arrange
            var commandStub = new Mock<ICommand>();

            var commandsFactoryMock = new Mock<ICommandsFactory>();
            commandsFactoryMock.Setup(c => c.GetCommand(It.IsAny<string>())).Returns(commandStub.Object);

            var commandProcessorUnderTest = new CommandProcessor(commandsFactoryMock.Object);

            string validCommand = "CommandName Valid Parameters";
            string commandName = "CommandName";

            // Act
            commandProcessorUnderTest.ProcessCommand(validCommand);

            // Assert
            commandsFactoryMock.Verify(c => c.GetCommand(commandName), Times.Once);
        }

        [Test]
        [Category("Framework.Providers.CommandProcessor.ProcessCommand")]
        public void CallCommandExecuteOnesWithCommandParameters_WhenValidStringPassedAsArgument()
        {
            // Arrange
            var commandMock = new Mock<ICommand>();

            var commandsFactoryStub = new Mock<ICommandsFactory>();
            commandsFactoryStub.Setup(c => c.GetCommand(It.IsAny<string>())).Returns(commandMock.Object);

            var commandProcessorUnderTest = new CommandProcessor(commandsFactoryStub.Object);

            string validCommand = "CommandName Valid Parameters";
            var commandParameters = new List<string> { "Valid", "Parameters" };

            // Act
            commandProcessorUnderTest.ProcessCommand(validCommand);

            // Assert
            commandMock.Verify(c => c.Execute(commandParameters), Times.Once);
        }

        [Test]
        [Category("Framework.Providers.CommandProcessor.ProcessCommand")]
        public void ReturnProperResponse_WhenValidStringPassedAsArgument()
        {
            // Arrange
            string properResponse = "Some kind of proper response";

            var commandStub = new Mock<ICommand>();
            commandStub.Setup(c => c.Execute(It.IsAny<IList<string>>())).Returns(properResponse);

            var commandsFactoryStub = new Mock<ICommandsFactory>();
            commandsFactoryStub.Setup(c => c.GetCommand(It.IsAny<string>())).Returns(commandStub.Object);

            var commandProcessorUnderTest = new CommandProcessor(commandsFactoryStub.Object);

            string validCommand = "CommandName Valid Parameters";
            var commandParameters = new List<string> { "Valid", "Parameters" };

            // Act
            string actualResponse = commandProcessorUnderTest.ProcessCommand(validCommand);

            // Assert
            Assert.AreEqual(properResponse, actualResponse);
        }
    }
}
