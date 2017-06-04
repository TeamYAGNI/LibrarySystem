// <copyright file="Constructor_Should.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds unit tests of Journal entity model constructor.</summary>
 
 using System.Collections.Generic;
 using NUnit.Framework;

namespace LibrarySystem.Models.UnitTests.SubjectTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        [Category("Models.Subject.Constructor")]
        public void InstantiateSubject_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var subject = new Subject();

            //Assert
            Assert.That(subject, Is.InstanceOf<Subject>());
        }

        [Test]
        [Category("Models.Subject.Constructor")]
        public void InstantiateSubjectWithIdProperty_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var subject = new Subject();

            //Assert
            Assert.That(subject, Has.Property("Id"));
        }

        [Test]
        [Category("Models.Subject.Constructor")]
        public void InstantiateSubjectWithNameProperty_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var subject = new Subject();

            //Assert
            Assert.That(subject, Has.Property("Name"));
        }

        [Test]
        [Category("Models.Subject.Constructor")]
        public void InstantiateSubjectWithSuperSubjectIdProperty_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var subject = new Subject();

            //Assert
            Assert.That(subject, Has.Property("SuperSubjectId"));
        }

        [Test]
        [Category("Models.Subject.Constructor")]
        public void InstantiateSubjectWithSuperSubjectProperty_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var subject = new Subject();

            //Assert
            Assert.That(subject, Has.Property("SuperSubject"));
        }

        [Test]
        [Category("Models.Subject.Constructor")]
        public void InstantiateSubjectWithIssueSubSubjectsProperty_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var subject = new Subject();

            //Assert
            Assert.That(subject, Has.Property("SubSubjects"));
        }
        
        [Test]
        [Category("Models.Subject.Constructor")]
        public void InstantiateSubSubjectsCollection_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var subject = new Subject();

            //Assert
            Assert.That(subject.SubSubjects.Count, Is.Zero);
            Assert.That(subject.SubSubjects, Is.TypeOf<HashSet<Subject>>());
        }

        [Test]
        [Category("Models.Subject.Constructor")]
        public void InstantiateSubjectWithIssueJournalsProperty_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var subject = new Subject();

            //Assert
            Assert.That(subject, Has.Property("Journals"));
        }

        [Test]
        [Category("Models.Subject.Constructor")]
        public void InstantiateJournalsCollection_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var subject = new Subject();

            //Assert
            Assert.That(subject.Journals.Count, Is.Zero);
            Assert.That(subject.Journals, Is.TypeOf<HashSet<Journal>>());
        }
    }
}
