using System.Collections.Generic;

using LibrarySystem.Models.Enumerations;
using LibrarySystem.Models.Factory;

using Moq;
using NUnit.Framework;

namespace LibrarySystem.Models.UnitTests.Factory.ModelsFactoryTests
{
    [TestFixture]
    public class CreateEmployee_Should
    {
        [Test]
        [Category("Models.Factory.ModelFactory.CreateEmployee")]
        public void ReturnEmployeeInstance_WhenValidArgumentsPassed()
        {
            // Arrange
            string firstName = "Sofia";
            string lastName = "Ivanova";
            GenderType genderType = GenderType.Female;
            JobTitle jobTitle = JobTitle.Archivist;
            Address address = new Mock<Address>().Object;
            Employee manager = new Mock<Employee>().Object;

            ModelsFactory factoryUnderTest = new ModelsFactory();

            // Act
            var employee = factoryUnderTest.CreateEmployee(firstName, lastName, genderType, jobTitle, address, manager);

            // Assert
            Assert.That(employee, Is.InstanceOf<Employee>());
        }

        [Test]
        [Category("Models.Factory.ModelFactory.CreateEmployee")]
        public void SetEmployeeProperties_WhenValidArgumentsPassed()
        {
            // Arrange
            string firstName = "Sofia";
            string lastName = "Ivanova";
            GenderType genderType = GenderType.Female;
            JobTitle jobTitle = JobTitle.Archivist;
            Address address = new Mock<Address>().Object;
            Employee manager = new Mock<Employee>().Object;

            ModelsFactory factoryUnderTest = new ModelsFactory();

            // Act
            var employee = factoryUnderTest.CreateEmployee(firstName, lastName, genderType, jobTitle, address, manager);

            // Assert
            Assert.AreSame(firstName, employee.FirstName);
            Assert.AreSame(lastName, employee.LastName);
            Assert.AreSame(address, employee.Address);
            Assert.AreSame(manager, employee.ReportsTo);

            Assert.AreEqual(genderType, employee.GenderType);
            Assert.AreEqual(jobTitle, employee.JobTitle);
        }
    }
}
