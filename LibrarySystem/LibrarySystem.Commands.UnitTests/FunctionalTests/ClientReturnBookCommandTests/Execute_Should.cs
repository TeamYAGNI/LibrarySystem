using System;
using System.Collections.Generic;

using LibrarySystem.Commands.Functional;
using LibrarySystem.Framework.Providers;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Contracts.Data;
using LibrarySystem.Repositories.Contracts.Data.UnitOfWork;
using Moq;
using NUnit.Framework;

namespace LibrarySystem.Commands.UnitTests.FunctionalTests.ClientReturnBookCommandTests
{
    [TestFixture]
    public class Execute_Should
    {
        [Test]
        [Category("Commands.Functional.ClientReturnBook.Execute")]
        public void CallGetLendingsByClientPINOnLendingRepository_WhenValidArgumentsArePassed()
        {
            //Arrange
            var lendingRepositoryMock = new Mock<ILendingRepository>();
            var unitOfWorkStub = new Mock<ILibraryUnitOfWork>();

            var command = new ClientReturnBookCommand(unitOfWorkStub.Object, lendingRepositoryMock.Object);

            var parameters = new List<string>() { "1", "2", "remarks" };
            //Act
            command.Execute(parameters);
            //Assert
            lendingRepositoryMock.Verify(l => l.GetLendingsByClientPIN(parameters[0]));
        }

        [Test]
        [Category("Commands.Functional.ClientReturnBook.Execute")]
        public void ReturnExactMessage_WhenLendingIsNull()
        {
            //Arrange
            var lendingRepositoryStub = new Mock<ILendingRepository>();
            var unitOfWorkStub = new Mock<ILibraryUnitOfWork>();

            var command = new ClientReturnBookCommand(unitOfWorkStub.Object, lendingRepositoryStub.Object);

            var parameters = new List<string>() { "1", "2", "remarks" };
            var expected = $"Book with ISBN {parameters[1]} was not found in Client's collection.";
            //Act
            var result = command.Execute(parameters);
            //Assert
            StringAssert.Contains(expected, result);
        }

        [Test]
        [Category("Commands.Functional.ClientReturnBook.Execute")]
        public void IncrementAvailableQuantityOnBookFromLending_WhenValidArgumentsArePassed()
        {
            //Arrange
            var lendingRepositoryStub = new Mock<ILendingRepository>();
            var book = new Book() { Available = 0, Quantity = 10, ISBN = "2" };
            var lending = new Lending() { Book = book };
            var lendingList = new List<Lending>() { lending };
            lendingRepositoryStub.Setup(l => l.GetLendingsByClientPIN(It.IsAny<string>())).Returns(lendingList);
            var unitOfWorkStub = new Mock<ILibraryUnitOfWork>();

            var command = new ClientReturnBookCommand(unitOfWorkStub.Object, lendingRepositoryStub.Object);

            var parameters = new List<string>() { "1", "2", "remarks" };
            var expectedAvailableQuantity = book.Available + 1;
            //Act
            var result = command.Execute(parameters);
            //Assert
            Assert.That(book.Available, Is.EqualTo(expectedAvailableQuantity));
        }

        [Test]
        [Category("Commands.Functional.ClientReturnBook.Execute")]
        public void SetLendingRemarks_WhenValidArgumentsArePassed()
        {
            //Arrange
            var timeProviderStub = new Mock<DefaultTimeProvider>();
            timeProviderStub.SetupSequence(t => t.Today).Returns(DateTime.MinValue).Returns(DateTime.MinValue.AddMonths(1));
            TimeProvider.Current = timeProviderStub.Object;
            var lendingRepositoryStub = new Mock<ILendingRepository>();
            var book = new Book() { Available = 0, Quantity = 10, ISBN = "2" };
            var lending = new Lending()
            {
                Book = book,
                BorrоwDate = TimeProvider.Current.Today,
                ReturnDate = null,
                Remarks = null
            };
            var lendingList = new List<Lending>() { lending };
            lendingRepositoryStub.Setup(l => l.GetLendingsByClientPIN(It.IsAny<string>())).Returns(lendingList);

            var unitOfWorkStub = new Mock<ILibraryUnitOfWork>();
            var command = new ClientReturnBookCommand(unitOfWorkStub.Object, lendingRepositoryStub.Object);

            var parameters = new List<string>() { "1", "2", "remarks" };
            var expected = $"{parameters[2]}";

            //Act
            command.Execute(parameters);

            //Assert
            StringAssert.Contains(expected, lending.Remarks);

            TimeProvider.ResetToDefault();
        }

        [Test]
        [Category("Commands.Functional.ClientReturnBook.Execute")]
        public void SetLendingRemarksWithDelay_WhenValidArgumentsArePassed()
        {
            //Arrange
            var timeProviderStub = new Mock<DefaultTimeProvider>();
            timeProviderStub.SetupSequence(t => t.Today).Returns(DateTime.MinValue).Returns(DateTime.MinValue.AddDays(30));
            TimeProvider.Current = timeProviderStub.Object;
            var lendingRepositoryStub = new Mock<ILendingRepository>();
            var book = new Book() { Available = 0, Quantity = 10, ISBN = "2" };
            var lending = new Lending()
            {
                Book = book,
                BorrоwDate = TimeProvider.Current.Today,
                ReturnDate = null,
                Remarks = null
            };
            var lendingList = new List<Lending>() { lending };
            lendingRepositoryStub.Setup(l => l.GetLendingsByClientPIN(It.IsAny<string>())).Returns(lendingList);

            var unitOfWorkStub = new Mock<ILibraryUnitOfWork>();
            var command = new ClientReturnBookCommand(unitOfWorkStub.Object, lendingRepositoryStub.Object);

            var parameters = new List<string>() { "1", "2", "remarks" };
            var expected = $"Delayed by 1 days.{Environment.NewLine}{parameters[2]}";

            //Act
            command.Execute(parameters);

            //Assert
            StringAssert.Contains(expected, lending.Remarks);

            TimeProvider.ResetToDefault();
        }

        [Test]
        [Category("Commands.Functional.ClientReturnBook.Execute")]
        public void SetLendingReturnDate_WhenValidArgumentsArePassed()
        {
            //Arrange
            var timeProviderStub = new Mock<DefaultTimeProvider>();
            timeProviderStub.SetupSequence(t => t.Today).Returns(DateTime.MinValue).Returns(DateTime.MinValue.AddDays(30));
            TimeProvider.Current = timeProviderStub.Object;
            var lendingRepositoryStub = new Mock<ILendingRepository>();
            var book = new Book() { Available = 0, Quantity = 10, ISBN = "2" };
            var lending = new Lending()
            {
                Book = book,
                BorrоwDate = TimeProvider.Current.Today,
                ReturnDate = null,
                Remarks = null
            };
            var lendingList = new List<Lending>() { lending };
            lendingRepositoryStub.Setup(l => l.GetLendingsByClientPIN(It.IsAny<string>())).Returns(lendingList);

            var unitOfWorkStub = new Mock<ILibraryUnitOfWork>();
            var command = new ClientReturnBookCommand(unitOfWorkStub.Object, lendingRepositoryStub.Object);

            var parameters = new List<string>() { "1", "2", "remarks" };
            var expected = $"Delayed by 1 days.{Environment.NewLine}{parameters[2]}";

            //Act
            command.Execute(parameters);

            //Assert
            Assert.That(lending.ReturnDate, Is.Not.Null);

            TimeProvider.ResetToDefault();
        }

        [Test]
        [Category("Commands.Functional.ClientReturnBook.Execute")]
        public void ReturnExactMessageForCommandCompletion_WhenValidArgumentsArePassed()
        {
            //Arrange
            var timeProviderStub = new Mock<DefaultTimeProvider>();
            timeProviderStub.SetupSequence(t => t.Today).Returns(DateTime.MinValue).Returns(DateTime.MinValue.AddDays(30));
            TimeProvider.Current = timeProviderStub.Object;
            var lendingRepositoryStub = new Mock<ILendingRepository>();
            var book = new Book() { Title = "test", Available = 0, Quantity = 10, ISBN = "2" };
            var lending = new Lending()
            {
                Book = book,
                BorrоwDate = TimeProvider.Current.Today,
                ReturnDate = null,
                Remarks = null
            };
            var lendingList = new List<Lending>() { lending };
            lendingRepositoryStub.Setup(l => l.GetLendingsByClientPIN(It.IsAny<string>())).Returns(lendingList);

            var unitOfWorkStub = new Mock<ILibraryUnitOfWork>();
            var command = new ClientReturnBookCommand(unitOfWorkStub.Object, lendingRepositoryStub.Object);

            var parameters = new List<string>() { "1", "2", "remarks" };
            var expected = $"{book.Title} was successfully returned.";

            //Act
            var result = command.Execute(parameters);

            //Assert
            StringAssert.Contains(expected, result);

            TimeProvider.ResetToDefault();
        }
    }
}
