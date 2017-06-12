using LibrarySystem.Commands.Functional;
using LibrarySystem.Repositories.Contracts.Data;
using LibrarySystem.Repositories.Contracts.Data.UnitOfWork;
using Moq;
using NUnit.Framework;

namespace LibrarySystem.Commands.UnitTests.FunctionalTests.ClientReturnJournalsCommandTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        [Category("Commands.Functional.ClientReturnJournals.Constructor")]
        public void CreateInstanceOfClientReturnJournalsCommandClass_WhenValidArgumentsArePassed()
        {
            //Arrange
            var journalRepositoryStub = new Mock<IJournalRepository>();
            var unitOfWorkStub = new Mock<ILibraryUnitOfWork>();

            var command = new ClientReturnJournalsCommand(unitOfWorkStub.Object, journalRepositoryStub.Object);
            //Act
            //Assert
            Assert.That(command, Is.InstanceOf<ClientReturnJournalsCommand>());
        }
    }
}
