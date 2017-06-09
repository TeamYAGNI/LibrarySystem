using System.Collections.Generic;

using LibrarySystem.Models.Factory;

using Moq;
using NUnit.Framework;

namespace LibrarySystem.Models.UnitTests.Factory.ModelsFactoryTests
{
    [TestFixture]
    public class CreateJournal_Should
    {
        [Test]
        [Category("Models.Factory.ModelFactory.CreateJournal")]
        public void ReturnJournalInstance_WhenValidArgumentsPassed()
        {
            // Arrange
            string title = "JournalSuperName";
            float? impactFactor = 4.8f;
            string issn = "9853-2341";
            int issueNumber = 42;
            int yearOfPublishing = 1963;
            var publisher = new Mock<Publisher>().Object;
            int quantity = 14;
            int available = 9;
            var subjects = new HashSet<Subject>
            {
                new Mock<Subject>().Object
            };

            ModelsFactory factoryUnderTest = new ModelsFactory();

            // Act
            var journal = factoryUnderTest.CreateJournal(title, impactFactor, issn, issueNumber, yearOfPublishing, publisher, quantity, available, subjects);

            // Assert
            Assert.That(journal, Is.InstanceOf<Journal>());
        }

        [Test]
        [Category("Models.Factory.ModelFactory.CreateJournal")]
        public void SetJournalProperties_WhenValidArgumentsPassed()
        {
            // Arrange
            string title = "JournalSuperName";
            float? impactFactor = 4.8f;
            string issn = "9853-2341";
            int issueNumber = 42;
            int yearOfPublishing = 1963;
            var publisher = new Mock<Publisher>().Object;
            int quantity = 14;
            int available = 9;
            var subjects = new HashSet<Subject>
            {
                new Mock<Subject>().Object
            };

            ModelsFactory factoryUnderTest = new ModelsFactory();

            // Act
            var journal = factoryUnderTest.CreateJournal(title, impactFactor, issn, issueNumber, yearOfPublishing, publisher, quantity, available, subjects);

            // Assert
            Assert.AreSame(title, journal.Title);
            Assert.AreSame(issn, journal.ISSN);
            Assert.AreSame(publisher, journal.Publisher);
            Assert.AreSame(subjects, journal.Subjects);

            Assert.AreEqual(impactFactor, journal.ImpactFactor);
            Assert.AreEqual(issueNumber, journal.IssueNumber);
            Assert.AreEqual(yearOfPublishing, journal.YearOfPublishing);
            Assert.AreEqual(quantity, journal.Quantity);
            Assert.AreEqual(available, journal.Available);
        }
    }
}
