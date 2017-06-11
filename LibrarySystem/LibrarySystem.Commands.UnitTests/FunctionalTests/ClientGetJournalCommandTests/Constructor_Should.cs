using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Commands.Functional;
using LibrarySystem.Repositories.Contracts;
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

            var command = new ClientGetJournalCommand(clientsRepositoryStub.Object, journalsRepositoryStub.Object);
            //Act
            //Assert
            Assert.That(command, Is.InstanceOf<ClientGetJournalCommand>());
        }
    }
}
