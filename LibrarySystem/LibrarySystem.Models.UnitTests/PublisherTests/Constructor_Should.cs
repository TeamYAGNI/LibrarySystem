// <copyright file="Constructor_Should.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds unit tests of Publisher entity model constructor.</summary>

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace LibrarySystem.Models.UnitTests.AuthorTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        [Category("Models.Publisher.Constructor")]
        public void InstantiatePublisher_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var publisher = new Publisher();

            //Assert
            Assert.That(publisher, Is.InstanceOf<Publisher>());
        }

        [Test]
        [Category("Models.Publisher.Constructor")]
        public void InstantiatePublisherWithIdProperty_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var publisher = new Publisher();

            //Assert
            Assert.That(publisher, Has.Property("Id"));
        }

        [Test]
        [Category("Models.Publisher.Constructor")]
        public void InstantiatePublisherWithNameProperty_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var publisher = new Publisher();

            //Assert
            Assert.That(publisher, Has.Property("Name"));
        }

        [Test]
        [Category("Models.Publisher.Constructor")]
        public void InstantiatePublisherWithBooksProperty_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var publisher = new Publisher();

            //Assert
            Assert.That(publisher, Has.Property("Books"));
        }

        [Test]
        [Category("Models.Publisher.Constructor")]
        public void InstantiatePublisherWithJournalsProperty_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var publisher = new Publisher();

            //Assert
            Assert.That(publisher, Has.Property("Journals"));
        }

        [Test]
        [Category("Models.Publisher.Constructor")]
        public void InstantiatePublisherBookCollection_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var publisher = new Publisher();

            //Assert
            Assert.That(publisher.Books.Count, Is.Zero);
            Assert.That(publisher.Books, Is.TypeOf<HashSet<Book>>());
        }

        [Test]
        [Category("Models.Publisher.Constructor")]
        public void InstantiatePublisherJournalCollection_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var publisher = new Publisher();

            //Assert
            Assert.That(publisher.Journals.Count, Is.Zero);
            Assert.That(publisher.Journals, Is.TypeOf<HashSet<Journal>>());
        }

    }
}
