using System.Collections.Generic;

using LibrarySystem.Models.Factory;

using Moq;
using NUnit.Framework;

namespace LibrarySystem.Models.UnitTests.Factory.ModelsFactoryTests
{
    [TestFixture]
    public class CreateSubject_Should
    {
        [Test]
        [Category("Models.Factory.ModelFactory.CreateSubject")]
        public void ReturnSubjectInstance_WhenValidArgumentsPassed()
        {
            // Arrange
            string name = "Sofia";
            var parrentSubject = new Mock<Subject>().Object;
            var childSubjects = new HashSet<Subject>
            {
                new Mock<Subject>().Object
            };
            var journals = new HashSet<Journal>
            {
                new Mock<Journal>().Object
            };

            ModelsFactory factoryUnderTest = new ModelsFactory();

            // Act
            var subject = factoryUnderTest.CreateSubject(name, parrentSubject, childSubjects, journals);

            // Assert
            Assert.That(subject, Is.InstanceOf<Subject>());
        }

        [Test]
        [Category("Models.Factory.ModelFactory.CreateJournal")]
        public void SetSubjectProperties_WhenValidArgumentsPassed()
        {
            // Arrange
            string name = "Sofia";
            var parrentSubject = new Mock<Subject>().Object;
            var childSubjects = new HashSet<Subject>
            {
                new Mock<Subject>().Object
            };
            var journals = new HashSet<Journal>
            {
                new Mock<Journal>().Object
            };

            ModelsFactory factoryUnderTest = new ModelsFactory();

            // Act
            var subject = factoryUnderTest.CreateSubject(name, parrentSubject, childSubjects, journals);

            // Assert
            Assert.AreSame(name, subject.Name);
            Assert.AreSame(parrentSubject, subject.SuperSubject);
            Assert.AreSame(childSubjects, subject.SubSubjects);
            Assert.AreSame(journals, subject.Journals);
        }
    }
}
