using System.Collections.Generic;

using LibrarySystem.Commands.Functional;
using LibrarySystem.Repositories.Contracts.Data;

using Moq;
using NUnit.Framework;

namespace LibrarySystem.Commands.UnitTests.FunctionalTests.ClientExitLibraryCommandTests
{
    [TestFixture]
    public class Execute_Should
    {
        [Test]
        [Category("Commands.Functional.ClientExitLibrary.Execute")]
        public void CallClientHasJournalOnClientRepository_WhenValidArgumentsArePassed()
        {
            //Arrange
            var clientRepositoryMock = new Mock<IClientRepository>();
            var clientExitLibraryCommand = new ClientExitLibraryCommand(clientRepositoryMock.Object);
            var parameters = new List<string>(){"1"};
            //Act
            clientExitLibraryCommand.Execute(parameters);
           //Assert
           clientRepositoryMock.Verify(c => c.ClientHasJournal(parameters[0]), Times.Once);
        }

        [Test]
        [Category("Commands.Functional.ClientExitLibrary.Execute")]
        public void ReturnExactString_WhenClientHasJournals()
        {
            //Arrange
            var clientRepositoryStub = new Mock<IClientRepository>();
            clientRepositoryStub.Setup(c => c.ClientHasJournal(It.IsAny<string>())).Returns(true);
            var clientExitLibraryCommand = new ClientExitLibraryCommand(clientRepositoryStub.Object);
            var parameters = new List<string>() { "1" };
            var expected = $"Client with PIN {parameters[0]} can not leave the library before he returns all journals.";

            //Act
            var result = clientExitLibraryCommand.Execute(parameters);
            //Assert
            StringAssert.Contains(expected, result);
        }

        [Test]
        [Category("Commands.Functional.ClientExitLibrary.Execute")]
        public void ReturnExactString_WhenClientHasNoJournals()
        {
            //Arrange
            var clientRepositoryStub = new Mock<IClientRepository>();
            clientRepositoryStub.Setup(c => c.ClientHasJournal(It.IsAny<string>())).Returns(false);
            var clientExitLibraryCommand = new ClientExitLibraryCommand(clientRepositoryStub.Object);
            var parameters = new List<string>() { "1" };
            var expected = $"Client with PIN {parameters[0]} exit successful.";

            //Act
            var result = clientExitLibraryCommand.Execute(parameters);
            //Assert
            StringAssert.Contains(expected, result);
        }
    }
}
