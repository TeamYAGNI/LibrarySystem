using System;
using System.Collections.Generic;

using LibrarySystem.Commands.Functional;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Contracts.Data;

using Moq;
using NUnit.Framework;

namespace LibrarySystem.Commands.UnitTests.FunctionalTests.ClientGetJournalCommandTests
{
    [TestFixture]
    public class Execute_Should
    {
        [Test]
        [Category("Commands.Functional.ClientGetJournal.Execute")]
        public void CallGetClientByPINOnClientRepository_WhenValidArgumentsArePassed()
        {
            //Arrange
            var clientsRepositoryMock = new Mock<IClientRepository>();
            var journalsRepositoryStub = new Mock<IJournalRepository>();

            var command = new ClientGetJournalCommand(clientsRepositoryMock.Object, journalsRepositoryStub.Object);
            var parameters = new List<string>() { "1", "2" };
            //Act
            command.Execute(parameters);

            //Assert
            clientsRepositoryMock.Verify(c => c.GetClientByPin(parameters[0]));
        }

        [Test]
        [Category("Commands.Functional.ClientGetJournal.Execute")]
        public void CallFindJournalByISSNOnJournalsRepository_WhenValidArgumentsArePassed()
        {
            //Arrange
            var clientsRepositoryStub = new Mock<IClientRepository>();
            var journalsRepositoryMock = new Mock<IJournalRepository>();

            var command = new ClientGetJournalCommand(clientsRepositoryStub.Object, journalsRepositoryMock.Object);
            var parameters = new List<string>() { "1", "2" };
            //Act
            command.Execute(parameters);

            //Assert
            journalsRepositoryMock.Verify(c => c.FindJournalByISSN(parameters[1]));
        }

        [Test]
        [Category("Commands.Functional.ClientGetJournal.Execute")]
        public void ReturnsExactMessage_WhenReturnedClientIsNull()
        {
            //Arrange
            var clientsRepositoryStub = new Mock<IClientRepository>();
            var journalsRepositoryStub = new Mock<IJournalRepository>();

            var command = new ClientGetJournalCommand(clientsRepositoryStub.Object, journalsRepositoryStub.Object);
            var parameters = new List<string>() { "1", "2" };
            var expected = $"Client with PIN {parameters[0]} not found";
            //Act

            var result = command.Execute(parameters);

            //Assert
            StringAssert.Contains(expected, result);
        }

        [Test]
        [Category("Commands.Functional.ClientGetJournal.Execute")]
        public void ReturnsExactMessage_WhenReturnedJournalIsNull()
        {
            //Arrange
            var clientsRepositoryStub = new Mock<IClientRepository>();
            var client = new Client() { PIN = "1", FirstName = "Test", LastName = "Tester" };
            clientsRepositoryStub.Setup(c => c.GetClientByPin(It.IsAny<string>())).Returns(client);

            var journalsRepositoryStub = new Mock<IJournalRepository>();

            var command = new ClientGetJournalCommand(clientsRepositoryStub.Object, journalsRepositoryStub.Object);
            var parameters = new List<string>() { "1", "2" };
            var expected = $"Journal with ISSN {parameters[1]} not found";
            //Act

            var result = command.Execute(parameters);

            //Assert
            StringAssert.Contains(expected, result);
        }

        [Test]
        [Category("Commands.Functional.ClientGetJournal.Execute")]
        public void ReturnsExactMessage_WhenReturnedBookIsNotAvailable()
        {
            //Arrange
            var clientsRepositoryStub = new Mock<IClientRepository>();
            var client = new Client() { PIN = "1", FirstName = "Test", LastName = "Tester" };
            clientsRepositoryStub.Setup(c => c.GetClientByPin(It.IsAny<string>())).Returns(client);

            var journalsRepositoryStub = new Mock<IJournalRepository>();
            var journal = new Journal() { Available = 0, Title = "test" };
            journalsRepositoryStub.Setup(j => j.FindJournalByISSN(It.IsAny<string>())).Returns(journal);

            var command = new ClientGetJournalCommand(clientsRepositoryStub.Object, journalsRepositoryStub.Object);
            var parameters = new List<string>() { "1", "2" };
            var expected = $"Journal test is not available right now";
            //Act

            var result = command.Execute(parameters);

            //Assert
            StringAssert.Contains(expected, result);
        }

        [Test]
        [Category("Commands.Functional.ClientGetJournal.Execute")]
        public void AddsJournalOnClient_WhenValidArgumentsArePassed()
        {
            //Arrange
            var clientsRepositoryStub = new Mock<IClientRepository>();
            var client = new Client() { PIN = "1", FirstName = "Test", LastName = "Tester" };
            clientsRepositoryStub.Setup(c => c.GetClientByPin(It.IsAny<string>())).Returns(client);

            var journalsRepositoryStub = new Mock<IJournalRepository>();
            var journal = new Journal() { Available = 1, Title = "test" };
            journalsRepositoryStub.Setup(j => j.FindJournalByISSN(It.IsAny<string>())).Returns(journal);

            var command = new ClientGetJournalCommand(clientsRepositoryStub.Object, journalsRepositoryStub.Object);
            var parameters = new List<string>() { "1", "2" };
            var expected = $"Journal test is not available right now";
            //Act

            var result = command.Execute(parameters);

            //Assert
            Assert.That(client.Journals, Is.Not.Empty);
            Assert.That(client.Journals, Contains.Item(journal));
        }

        [Test]
        [Category("Commands.Functional.ClientGetJournal.Execute")]
        public void ReturnExactMessageForCommandCompletion_WhenValidArgumentsArePassed()
        {
            //Arrange
            var clientsRepositoryStub = new Mock<IClientRepository>();
            var client = new Client() { PIN = "1", FirstName = "Test", LastName = "Tester" };
            clientsRepositoryStub.Setup(c => c.GetClientByPin(It.IsAny<string>())).Returns(client);

            var journalsRepositoryStub = new Mock<IJournalRepository>();
            var journal = new Journal() { Available = 1, Title = "test" };
            journalsRepositoryStub.Setup(j => j.FindJournalByISSN(It.IsAny<string>())).Returns(journal);

            var command = new ClientGetJournalCommand(clientsRepositoryStub.Object, journalsRepositoryStub.Object);
            var parameters = new List<string>() { "1", "2" };
            var expected = $"{client.FullName} got {journal.Title}{Environment.NewLine}This item can not be lended";
            //Act

            var result = command.Execute(parameters);

            //Assert
            StringAssert.Contains(expected, result);
        }

    }
}
