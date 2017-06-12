using LibrarySystem.Commands.Functional;
using LibrarySystem.Repositories.Contracts.Data;

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
            var command = new ClientReturnJournalsCommand(journalRepositoryStub.Object);
            //Act
            //Assert
            Assert.That(command, Is.InstanceOf<ClientReturnJournalsCommand>());
        }
    }
}
