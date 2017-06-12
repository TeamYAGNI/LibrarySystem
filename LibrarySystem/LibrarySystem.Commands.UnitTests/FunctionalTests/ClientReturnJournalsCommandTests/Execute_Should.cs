using System;
using System.Collections.Generic;

using LibrarySystem.Commands.Functional;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Contracts.Data;
using LibrarySystem.Repositories.Contracts.Data.UnitOfWork;
using Moq;
using NUnit.Framework;

namespace LibrarySystem.Commands.UnitTests.FunctionalTests.ClientReturnJournalsCommandTests
{
    [TestFixture]
    public class Execute_Should
    {
        [Test]
        [Category("Commands.Functional.ClientReturnJournals.Constructor")]
        public void CallGetAllClientJournalsOnJournalRepository_WhenValidArgumentsArePassed()
        {
            //Arrange
            var journalRepositoryMock = new Mock<IJournalRepository>();
            var unitOfWorkStub = new Mock<ILibraryUnitOfWork>();

            var command = new ClientReturnJournalsCommand(unitOfWorkStub.Object, journalRepositoryMock.Object);
            var parameters = new List<string>() { "1" };
            //Act
            command.Execute(parameters);
            //Assert
            journalRepositoryMock.Verify(j => j.GetAllClientJournals(parameters[0]));
        }

        [Test]
        [Category("Commands.Functional.ClientReturnJournals.Constructor")]
        public void ReturnExactMessage_WhenJournalsCollectionIsEmpty()
        {
            //Arrange
            var journalRepositoryStub = new Mock<IJournalRepository>();
            var unitOfWorkStub = new Mock<ILibraryUnitOfWork>();

            var command = new ClientReturnJournalsCommand(unitOfWorkStub.Object, journalRepositoryStub.Object);
            var parameters = new List<string>() { "1" };
            var expected = $"Client with PIN {parameters[0]} has no Journals";
            //Act
            var result = command.Execute(parameters);
            //Assert
            StringAssert.Contains(expected, result);
        }

        [Test]
        [Category("Commands.Functional.ClientReturnJournals.Constructor")]
        public void ReturnExactMessage_WhenJournalsCollectionIsNotEmpty()
        {
            //Arrange
            var journalRepositoryStub = new Mock<IJournalRepository>();
            var client = new Client() { PIN = "1", FirstName = "Test", LastName = "Tester" };
            var journal = new Journal() { Title = "TestTitle" };
            journal.Client = client;
            var journalsList = new List<Journal>() { journal };
            journalRepositoryStub.Setup(j => j.GetAllClientJournals(It.IsAny<string>())).Returns(journalsList);
            var unitOfWorkStub = new Mock<ILibraryUnitOfWork>();

            var command = new ClientReturnJournalsCommand(unitOfWorkStub.Object ,journalRepositoryStub.Object);
            var parameters = new List<string>() { "1" };
            var expected = $"Client {client.FullName} returned:{Environment.NewLine}- {journal.Title}{Environment.NewLine}";
            //Act
            var result = command.Execute(parameters);
            //Assert
            StringAssert.Contains(expected, result);
        }

        [Test]
        [Category("Commands.Functional.ClientReturnJournals.Constructor")]
        public void ClearClientJournalsOnCommandCompletion_WhenJournalsCollectionIsNotEmpty()
        {
            //Arrange
            var journalRepositoryStub = new Mock<IJournalRepository>();
            var client = new Client() { PIN = "1", FirstName = "Test", LastName = "Tester" };
            var journal = new Journal() { Title = "TestTitle" };
            journal.Client = client;
            var journalsList = new List<Journal>() { journal };
            client.Journals = journalsList;
            journalRepositoryStub.Setup(j => j.GetAllClientJournals(It.IsAny<string>())).Returns(journalsList);
            var unitOfWorkStub = new Mock<ILibraryUnitOfWork>();

            var command = new ClientReturnJournalsCommand(unitOfWorkStub.Object, journalRepositoryStub.Object);
            var parameters = new List<string>() { "1" };
            //Act
            command.Execute(parameters);
            //Assert
            Assert.That(client.Journals, Is.Empty);
        }
    }
}
