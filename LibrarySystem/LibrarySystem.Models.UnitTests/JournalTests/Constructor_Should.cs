// <copyright file="Constructor_Should.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds unit tests of Journal entity model constructor.</summary>

using System.Collections.Generic;
using NUnit.Framework;

namespace LibrarySystem.Models.UnitTests.JournalTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        [Category("Models.Journal.Constructor")]
        public void InstantiateJournal_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var journal = new Journal();

            // Assert
            Assert.That(journal, Is.InstanceOf<Journal>());
        }

        [Test]
        [Category("Models.Journal.Constructor")]
        public void InstantiateJournalWithIdProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var journal = new Journal();

            // Assert
            Assert.That(journal, Has.Property("Id"));
        }

        [Test]
        [Category("Models.Journal.Constructor")]
        public void InstantiateJournalWithTitleProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var journal = new Journal();

            // Assert
            Assert.That(journal, Has.Property("Title"));
        }

        [Test]
        [Category("Models.Journal.Constructor")]
        public void InstantiateJournalWithImpactFactorProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var journal = new Journal();

            // Assert
            Assert.That(journal, Has.Property("ImpactFactor"));
        }

        [Test]
        [Category("Models.Journal.Constructor")]
        public void InstantiateJournalWithISSNProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var journal = new Journal();

            // Assert
            Assert.That(journal, Has.Property("ISSN"));
        }

        [Test]
        [Category("Models.Journal.Constructor")]
        public void InstantiateJournalWithIssueNumberProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var journal = new Journal();

            // Assert
            Assert.That(journal, Has.Property("IssueNumber"));
        }

        [Test]
        [Category("Models.Journal.Constructor")]
        public void InstantiateJournalWithYearOfPublishingProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var journal = new Journal();

            // Assert
            Assert.That(journal, Has.Property("YearOfPublishing"));
        }

        [Test]
        [Category("Models.Journal.Constructor")]
        public void InstantiateJournalWithPublisherIdProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var journal = new Journal();

            // Assert
            Assert.That(journal, Has.Property("PublisherId"));
        }

        [Test]
        [Category("Models.Journal.Constructor")]
        public void InstantiateJournalWithPublisherProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var journal = new Journal();

            // Assert
            Assert.That(journal, Has.Property("Publisher"));
        }

        [Test]
        [Category("Models.Journal.Constructor")]
        public void InstantiateJournalWithClientIdProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var journal = new Journal();

            // Assert
            Assert.That(journal, Has.Property("ClientId"));
        }

        [Test]
        [Category("Models.Journal.Constructor")]
        public void InstantiateJournalWithClientProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var journal = new Journal();

            // Assert
            Assert.That(journal, Has.Property("Client"));
        }

        [Test]
        [Category("Models.Journal.Constructor")]
        public void InstantiateJournalWithQuantityProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var journal = new Journal();

            // Assert
            Assert.That(journal, Has.Property("Quantity"));
        }

        [Test]
        [Category("Models.Journal.Constructor")]
        public void InstantiateJournalWithAvailableProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var journal = new Journal();

            // Assert
            Assert.That(journal, Has.Property("Available"));
        }

        [Test]
        [Category("Models.Journal.Constructor")]
        public void InstantiateJournalWithSubjectsProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var journal = new Journal();

            // Assert
            Assert.That(journal, Has.Property("Subjects"));
        }

        [Test]
        [Category("Models.Journal.Constructor")]
        public void InstantiateSubjectsCollection_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var journal = new Journal();

            // Assert
            Assert.That(journal.Subjects.Count, Is.Zero);
            Assert.That(journal.Subjects, Is.TypeOf<HashSet<Subject>>());
        }
    }
}