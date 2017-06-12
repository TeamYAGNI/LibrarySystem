﻿using LibrarySystem.Commands.Functional;
using LibrarySystem.Models.Factory;
using LibrarySystem.Repositories.Contracts.Data;

using Moq;
using NUnit.Framework;

namespace LibrarySystem.Commands.UnitTests.FunctionalTests.ClientExitLibraryCommandTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        [Category("Commands.Functional.ClientGetBook.Constructor")]
        public void CreateInstanceOfClientGetBookCommandClass_WhenValidArgumentsArePassed()
        {
            //Arrange
            var modelsFactoryStub = new Mock<IModelsFactory>();
            var clientRepositoryStub = new Mock<IClientRepository>();
            var bookRepositoryMock = new Mock<IBookRepository>();
            var lendingRepositoryStub = new Mock<ILendingRepository>();
            var clientGetBookCommand = new ClientGetBookCommand(modelsFactoryStub.Object, clientRepositoryStub.Object, bookRepositoryMock.Object, lendingRepositoryStub.Object);
            //Act
            //Assert
            Assert.That(clientGetBookCommand, Is.InstanceOf<ClientGetBookCommand>());
        }
    }
}
