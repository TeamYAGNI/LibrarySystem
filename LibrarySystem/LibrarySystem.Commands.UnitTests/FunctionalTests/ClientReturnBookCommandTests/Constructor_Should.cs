using LibrarySystem.Commands.Functional;
using LibrarySystem.Repositories.Contracts.Data;
using LibrarySystem.Repositories.Contracts.Data.UnitOfWork;
using Moq;
using NUnit.Framework;

namespace LibrarySystem.Commands.UnitTests.FunctionalTests.ClientReturnBookCommandTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        [Category("Commands.Functional.ClientReturnBook.Constructor")]
        public void CreateInstanceOfClientReturnBookCommandClass_WhenValidArgumentsArePassed()
        {
            //Arrange
            var lendingRepositoryStub = new Mock<ILendingRepository>();
            var unitOfWorkStub = new Mock<ILibraryUnitOfWork>();

            var command = new ClientReturnBookCommand(unitOfWorkStub.Object, lendingRepositoryStub.Object);
            //Act
            //Assert
            Assert.That(command, Is.InstanceOf<ClientReturnBookCommand>());
        }

    }
}
