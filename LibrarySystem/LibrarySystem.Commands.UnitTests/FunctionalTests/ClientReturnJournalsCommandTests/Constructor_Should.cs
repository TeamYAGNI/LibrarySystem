using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Commands.Functional;
using LibrarySystem.Repositories.Contracts;
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
