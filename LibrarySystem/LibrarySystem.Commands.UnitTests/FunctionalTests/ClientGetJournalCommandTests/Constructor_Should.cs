using LibrarySystem.Commands.Functional;
using LibrarySystem.Repositories.Contracts.Data;
using LibrarySystem.Repositories.Contracts.Data.UnitOfWork;
using Moq;
using NUnit.Framework;

namespace LibrarySystem.Commands.UnitTests.FunctionalTests.ClientGetJournalCommandTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        [Category("Commands.Functional.ClientGetJournal.Constructor")]
        public void CreateInstanceOfClientGetJournalCommandClass_WhenValidArgumentsArePassed()
        {
            //Arrange
            var clientsRepositoryStub = new Mock<IClientRepository>();
            var journalsRepositoryStub = new Mock<IJournalRepository>();
            var unitOfWorkStub = new Mock<ILibraryUnitOfWork>();

            var command = new ClientGetJournalCommand(unitOfWorkStub.Object, clientsRepositoryStub.Object, journalsRepositoryStub.Object);
            //Act
            //Assert
            Assert.That(command, Is.InstanceOf<ClientGetJournalCommand>());
        }
    }
}
