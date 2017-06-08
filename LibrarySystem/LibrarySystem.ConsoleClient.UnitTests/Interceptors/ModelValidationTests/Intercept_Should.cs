using System;

using LibrarySystem.ConsoleClient.Interceptors;
using LibrarySystem.Framework.Contracts;

using Moq;
using Ninject.Extensions.Interception;
using NUnit.Framework;

namespace LibrarySystem.ConsoleClient.UnitTests.Interceptors.ModelValidationTests
{
    [TestFixture]
    public class Intercept_Should
    {
        [Test]
        [Category("ConsoleClient.Interceptors.ModelValidation.Intercept")]
        public void CallInvocationProceedExactlyOnce_WhenValidInvocationPassed()
        {
            // Arrange
            var validatorStub = new Mock<IValidator>();
            var modelValidationUnderTest = new ModelValidation(validatorStub.Object);

            var invocationMock = new Mock<IInvocation>();

            // Act
            modelValidationUnderTest.Intercept(invocationMock.Object);

            // Assert
            invocationMock.Verify(i => i.Proceed(), Times.Once);
        }

        [Test]
        [Category("ConsoleClient.Interceptors.ModelValidation.Intercept")]
        public void CallValidatorValidateExactlyOnceWithReturnValueOfInvocation_WhenValidArgumentsPassed()
        {
            // Arrange
            var validatorMock = new Mock<IValidator>();
            var modelValidationUnderTest = new ModelValidation(validatorMock.Object);

            string returnValue = "GenericReturnValue";

            var invocationStub = new Mock<IInvocation>();
            invocationStub.SetupGet(i => i.ReturnValue).Returns(returnValue);

            // Act
            modelValidationUnderTest.Intercept(invocationStub.Object);

            // Assert
            validatorMock.Verify(v => v.Validate<object>(returnValue, It.IsAny<Action<string>>()), Times.Once);
        }
    }
}
