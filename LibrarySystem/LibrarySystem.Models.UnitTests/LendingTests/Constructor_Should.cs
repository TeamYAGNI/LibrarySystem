﻿// <copyright file="Constructor_Should.cs" company="YAGNI">
 // All rights reserved.
 // </copyright>
 // <summary>Holds unit tests of Journal entity model constructor.</summary>

using NUnit.Framework;

namespace LibrarySystem.Models.UnitTests.LendingTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        [Category("Models.Lending.Constructor")]
        public void InstantiateLending_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var lending = new Lending();

            // Assert
            Assert.That(lending, Is.InstanceOf<Lending>());
        }

        [Test]
        [Category("Models.Lending.Constructor")]
        public void InstantiateLendingWithIdProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var lending = new Lending();

            // Assert
            Assert.That(lending, Has.Property("Id"));
        }

        [Test]
        [Category("Models.Lending.Constructor")]
        public void InstantiateLendingWithBookIdProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var lending = new Lending();

            // Assert
            Assert.That(lending, Has.Property("BookId"));
        }

        [Test]
        [Category("Models.Lending.Constructor")]
        public void InstantiateLendingWithBookProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var lending = new Lending();

            // Assert
            Assert.That(lending, Has.Property("Book"));
        }

        [Test]
        [Category("Models.Lending.Constructor")]
        public void InstantiateLendingWithClientIdProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var lending = new Lending();

            // Assert
            Assert.That(lending, Has.Property("ClientId"));
        }

        [Test]
        [Category("Models.Lending.Constructor")]
        public void InstantiateLendingWithClientProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var lending = new Lending();

            // Assert
            Assert.That(lending, Has.Property("Client"));
        }

        [Test]
        [Category("Models.Lending.Constructor")]
        public void InstantiateLendingWithBorrоwDateProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var lending = new Lending();

            // Assert
            Assert.That(lending, Has.Property("BorrоwDate"));
        }

        [Test]
        [Category("Models.Lending.Constructor")]
        public void InstantiateLendingWithReturnDateProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var lending = new Lending();

            // Assert
            Assert.That(lending, Has.Property("ReturnDate"));
        }

        [Test]
        [Category("Models.Lending.Constructor")]
        public void InstantiateLendingWithRemarksProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var lending = new Lending();

            // Assert
            Assert.That(lending, Has.Property("Remarks"));
        }
    }
}
