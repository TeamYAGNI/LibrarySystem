using System;

using LibrarySystem.ConsoleClient.Interceptors;
using LibrarySystem.Framework.Contracts;

using Moq;
using NUnit.Framework;

namespace LibrarySystem.ConsoleClient.UnitTests.Interceptors.ModelValidationTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        [Category("ConsoleClient.Interceptors.ModelValidation.Constructor")]
        public void ThrowArgumentNullException_WhenNullPassedAsValidator()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => new ModelValidation(null));
        }

        [Test]
        [Category("ConsoleClient.Interceptors.ModelValidation.Constructor")]
        public void NotThrow_WhenValidatorPassed()
        {
            // Arrange
            var validatorStub = new Mock<IValidator>();

            // Act
            // Assert
            Assert.DoesNotThrow(() => new ModelValidation(validatorStub.Object));
        }
    }
}
