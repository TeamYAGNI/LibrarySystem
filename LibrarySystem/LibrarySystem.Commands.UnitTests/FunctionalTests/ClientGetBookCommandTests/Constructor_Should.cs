using LibrarySystem.Commands.Functional;
using LibrarySystem.Repositories.Contracts.Data;

using Moq;
using NUnit.Framework;

namespace LibrarySystem.Commands.UnitTests.FunctionalTests.ClientGetBookCommandTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        [Category("Commands.Functional.ClientExitLibrary.Constructor")]
        public void CreateInstanceOfClientExitLibraryCommandClass_WhenValidArgumentsArePassed()
        {
            //Arrange
            var clientRepositoryStub = new Mock<IClientRepository>();
            var clientExitLibraryCommand = new ClientExitLibraryCommand(clientRepositoryStub.Object);
            //Act
            //Assert
            Assert.That(clientExitLibraryCommand, Is.InstanceOf<ClientExitLibraryCommand>());
        }
    }
}
