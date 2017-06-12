using System;

using LibrarySystem.Models.Factory;

using Moq;
using NUnit.Framework;

namespace LibrarySystem.Models.UnitTests.Factory.ModelsFactoryTests
{
    [TestFixture]
    public class CreateLending_Should
    {
        [Test]
        [Category("Models.Factory.ModelFactory.CreateLending")]
        public void ReturnLendingInstance_WhenValidArgumentsPassed()
        {
            // Arrange
            var book = new Mock<Book>().Object;
            var client = new Mock<Client>().Object;
            var borrowDate = new DateTime(2012, 12, 18);
            var returnDate = new DateTime(2012, 12, 27);
            string remarks = "Some kind of remerks";
            
            ModelsFactory factoryUnderTest = new ModelsFactory();

            // Act
            var lending = factoryUnderTest.CreateLending(book, client, borrowDate, returnDate, remarks);

            // Assert
            Assert.That(lending, Is.InstanceOf<Lending>());
        }

        [Test]
        [Category("Models.Factory.ModelFactory.CreateLending")]
        public void SetLendingProperties_WhenValidArgumentsPassed()
        {
            // Arrange
            var book = new Mock<Book>().Object;
            var client = new Mock<Client>().Object;
            var borrowDate = new DateTime(2012, 12, 18);
            var returnDate = new DateTime(2012, 12, 27);
            string remarks = "Some kind of remerks";

            ModelsFactory factoryUnderTest = new ModelsFactory();

            // Act
            var lending = factoryUnderTest.CreateLending(book, client, borrowDate, returnDate, remarks);

            // Assert
            Assert.AreSame(book, lending.Book);
            Assert.AreSame(client, lending.Client);
            Assert.AreSame(remarks, lending.Remarks);

            Assert.AreEqual(borrowDate, lending.BorrоwDate);
            Assert.AreEqual(returnDate, lending.ReturnDate);
        }
    }
}
