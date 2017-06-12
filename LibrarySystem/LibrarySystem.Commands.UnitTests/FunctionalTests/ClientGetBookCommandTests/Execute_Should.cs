using System.Collections.Generic;
using LibrarySystem.Commands.Functional;
using LibrarySystem.Models.Factory;
using LibrarySystem.Repositories.Contracts;
using Moq;
using NUnit.Framework;
using LibrarySystem.Models;
using LibrarySystem.Framework.Providers;
using System;
using LibrarySystem.Repositories.Data.Contracts;

namespace LibrarySystem.Commands.UnitTests.FunctionalTests.ClientGetBookCommandTests
{
    [TestFixture]
    public class Execute_Should
    {
        [Test]
        [Category("Commands.Functional.ClientGetBook.Execute")]
        public void CallGetClientByPinOnClientRepository_WhenValidArgumentsArePassed()
        {
            //Arrange
            var modelsFactoryStub = new Mock<IModelsFactory>();
            var clientRepositoryMock = new Mock<IClientRepository>();
            var bookRepositoryStub = new Mock<IBookRepository>();
            var lendingRepositoryStub = new Mock<ILendingRepository>();
            var clientGetBookCommand = new ClientGetBookCommand(modelsFactoryStub.Object, clientRepositoryMock.Object, bookRepositoryStub.Object, lendingRepositoryStub.Object);

            var parameters = new List<string>() { "1", "2" };
            //Act
            clientGetBookCommand.Execute(parameters);

            //Assert
            clientRepositoryMock.Verify(c => c.GetClientByPin(parameters[0]), Times.Once);
        }

        [Test]
        [Category("Commands.Functional.ClientGetBook.Execute")]
        public void CallGetBookByISBNOnBookRepository_WhenValidArgumentsArePassed()
        {
            //Arrange
            var modelsFactoryStub = new Mock<IModelsFactory>();
            var clientRepositoryStub = new Mock<IClientRepository>();
            var bookRepositoryMock = new Mock<IBookRepository>();
            var lendingRepositoryStub = new Mock<ILendingRepository>();
            var clientGetBookCommand = new ClientGetBookCommand(modelsFactoryStub.Object, clientRepositoryStub.Object, bookRepositoryMock.Object, lendingRepositoryStub.Object);

            var parameters = new List<string>() { "1", "2"};
            //Act
            clientGetBookCommand.Execute(parameters);

            //Assert
            bookRepositoryMock.Verify(c => c.GetBookByISBN(parameters[1]), Times.Once);
        }

        [Test]
        [Category("Commands.Functional.ClientGetBook.Execute")]
        public void ReturnsExactMessage_WhenReturnedClientIsNull()
        {
            //Arrange
            var modelsFactoryStub = new Mock<IModelsFactory>();
            var clientRepositoryStub = new Mock<IClientRepository>();
            var bookRepositoryStub = new Mock<IBookRepository>();
            var lendingRepositoryStub = new Mock<ILendingRepository>();
            var clientGetBookCommand = new ClientGetBookCommand(modelsFactoryStub.Object, clientRepositoryStub.Object, bookRepositoryStub.Object, lendingRepositoryStub.Object);
            var parameters = new List<string>() { "1", "2" };

            var expected = $"Client with PIN {parameters[0]} not found";
            //Act

            var result = clientGetBookCommand.Execute(parameters);

            //Assert
            StringAssert.Contains(expected, result);
        }

        [Test]
        [Category("Commands.Functional.ClientGetBook.Execute")]
        public void ReturnsExactMessage_WhenReturnedBookIsNull()
        {
            //Arrange
            var modelsFactoryStub = new Mock<IModelsFactory>();
            var clientRepositoryStub = new Mock<IClientRepository>();
            clientRepositoryStub.Setup(c => c.GetClientByPin(It.IsAny<string>())).Returns(new Client() { PIN = "1" });
            var bookRepositoryStub = new Mock<IBookRepository>();
            var lendingRepositoryStub = new Mock<ILendingRepository>();
            var clientGetBookCommand = new ClientGetBookCommand(modelsFactoryStub.Object, clientRepositoryStub.Object, bookRepositoryStub.Object, lendingRepositoryStub.Object);
            var parameters = new List<string>() { "1", "2" };

            var expected = $"Book with ISBN {parameters[1]} not found";
            //Act

            var result = clientGetBookCommand.Execute(parameters);

            //Assert
            StringAssert.Contains(expected, result);
        }

        [Test]
        [Category("Commands.Functional.ClientGetBook.Execute")]
        public void ReturnsExactMessage_WhenReturnedBookIsNotAvailable()
        {
            //Arrange
            var modelsFactoryStub = new Mock<IModelsFactory>();

            var clientRepositoryStub = new Mock<IClientRepository>();
            clientRepositoryStub.Setup(c => c.GetClientByPin(It.IsAny<string>())).Returns(new Client() { PIN = "1" });

            var bookRepositoryStub = new Mock<IBookRepository>();
            bookRepositoryStub.Setup(b => b.GetBookByISBN(It.IsAny<string>())).Returns(new Book() { ISBN = "2", Available = 0, Title = "test" });

            var lendingRepositoryStub = new Mock<ILendingRepository>();

            var clientGetBookCommand = new ClientGetBookCommand(modelsFactoryStub.Object, clientRepositoryStub.Object, bookRepositoryStub.Object, lendingRepositoryStub.Object);

            var parameters = new List<string>() { "1", "2" };
            var expected = $"Book test is not available right now";
            //Act

            var result = clientGetBookCommand.Execute(parameters);

            //Assert
            StringAssert.Contains(expected, result);
        }

        [Test]
        [Category("Commands.Functional.ClientGetBook.Execute")]
        public void CallCreateLendingOnModelsFactory_WhenValidArgumentsArePassed()
        {
            //Arrange
            var modelsFactoryMock = new Mock<IModelsFactory>();

            var clientRepositoryStub = new Mock<IClientRepository>();
            var client = new Client() { PIN = "1" };
            clientRepositoryStub.Setup(c => c.GetClientByPin(It.IsAny<string>())).Returns(client);

            var bookRepositoryStub = new Mock<IBookRepository>();
            var book = new Book() { ISBN = "2", Available = 10, Title = "test" };
            bookRepositoryStub.Setup(b => b.GetBookByISBN(It.IsAny<string>())).Returns(book);

            var lendingRepositoryStub = new Mock<ILendingRepository>();

            var clientGetBookCommand = new ClientGetBookCommand(modelsFactoryMock.Object, clientRepositoryStub.Object, bookRepositoryStub.Object, lendingRepositoryStub.Object);

            var timeProviderStub = new Mock<DefaultTimeProvider>();
            timeProviderStub.Setup(t => t.Today).Returns(DateTime.MinValue);
            TimeProvider.Current = timeProviderStub.Object;

            var parameters = new List<string>() { "1", "2" };
            //Act

            var result = clientGetBookCommand.Execute(parameters);

            //Assert
            modelsFactoryMock.Verify(f => f.CreateLending(book, client, TimeProvider.Current.Today, null, null), Times.Once);

            TimeProvider.ResetToDefault();
        }

        [Test]
        [Category("Commands.Functional.ClientGetBook.Execute")]
        public void CallAddOnLendingRepository_WhenValidArgumentsArePassed()
        {
            //Arrange
            var modelsFactoryStub = new Mock<IModelsFactory>();

            var clientRepositoryStub = new Mock<IClientRepository>();
            var client = new Client() { PIN = "1" };
            clientRepositoryStub.Setup(c => c.GetClientByPin(It.IsAny<string>())).Returns(client);

            var bookRepositoryStub = new Mock<IBookRepository>();
            var book = new Book() { ISBN = "2", Available = 10, Title = "test" };
            bookRepositoryStub.Setup(b => b.GetBookByISBN(It.IsAny<string>())).Returns(book);

            var lendingRepositoryMock = new Mock<ILendingRepository>();

            var clientGetBookCommand = new ClientGetBookCommand(modelsFactoryStub.Object, clientRepositoryStub.Object, bookRepositoryStub.Object, lendingRepositoryMock.Object);

            var timeProviderStub = new Mock<DefaultTimeProvider>();
            timeProviderStub.Setup(t => t.Today).Returns(DateTime.MinValue);
            TimeProvider.Current = timeProviderStub.Object;

            var parameters = new List<string>() { "1", "2" };
            //Act

            var lending = new Lending()
            {
                Book = book,
                Client = client,
                BorrоwDate = TimeProvider.Current.Today,
                ReturnDate = null,
                Remarks = null
            };
            modelsFactoryStub.Setup(f => f.CreateLending(It.IsAny<Book>(), It.IsAny<Client>(), It.IsAny<DateTime>(), null, null)).Returns(lending);

            var result = clientGetBookCommand.Execute(parameters);
            //Assert
            lendingRepositoryMock.Verify(l => l.Add(lending), Times.Once);

            TimeProvider.ResetToDefault();
        }

        [Test]
        [Category("Commands.Functional.ClientGetBook.Execute")]
        public void ReturnExactMessageForCommandCompletion_WhenValidArgumentsArePassed()
        {
            //Arrange
            var modelsFactoryStub = new Mock<IModelsFactory>();

            var clientRepositoryStub = new Mock<IClientRepository>();
            var client = new Client() { PIN = "1", FirstName = "Test", LastName = "Tester" };
            clientRepositoryStub.Setup(c => c.GetClientByPin(It.IsAny<string>())).Returns(client);

            var bookRepositoryStub = new Mock<IBookRepository>();
            var book = new Book() { ISBN = "2", Available = 10, Title = "test" };
            bookRepositoryStub.Setup(b => b.GetBookByISBN(It.IsAny<string>())).Returns(book);

            var lendingRepositoryStub = new Mock<ILendingRepository>();

            var clientGetBookCommand = new ClientGetBookCommand(modelsFactoryStub.Object, clientRepositoryStub.Object, bookRepositoryStub.Object, lendingRepositoryStub.Object);

            var timeProviderStub = new Mock<DefaultTimeProvider>();
            timeProviderStub.Setup(t => t.Today).Returns(DateTime.MinValue);
            TimeProvider.Current = timeProviderStub.Object;

            var parameters = new List<string>() { "1", "2"};
            //Act

            var lending = new Lending()
            {
                Book = book,
                Client = client,
                BorrоwDate = TimeProvider.Current.Today,
                ReturnDate = null,
                Remarks = null
            };
            modelsFactoryStub.Setup(f => f.CreateLending(It.IsAny<Book>(), It.IsAny<Client>(), It.IsAny<DateTime>(), null, null)).Returns(lending);

            var result = clientGetBookCommand.Execute(parameters);
            var expected = $"{client.FullName} got {book.Title}{Environment.NewLine}Should return it by {TimeProvider.Current.Today.AddMonths(1).Date:D}";
            //Assert

            StringAssert.Contains(expected, result);

            TimeProvider.ResetToDefault();
        }
    }
}
