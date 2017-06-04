// <copyright file="Constructor_Should.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds unit tests of Journal entity model constructor.</summary>
 
 using System.Collections.Generic;
 using NUnit.Framework;

namespace LibrarySystem.Models.UnitTests.EmployeeTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        [Category("Models.Employee.Constructor")]
        public void InstantiateEmployee_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var employee = new Employee();

            //Assert
            Assert.That(employee, Is.InstanceOf<Employee>());
        }

        [Test]
        [Category("Models.Employee.Constructor")]
        public void InstantiateEmployeeWithIdProperty_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var employee = new Employee();

            //Assert
            Assert.That(employee, Has.Property("Id"));
        }

        [Test]
        [Category("Models.Employee.Constructor")]
        public void InstantiateEmployeeWithFirstNameProperty_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var employee = new Employee();

            //Assert
            Assert.That(employee, Has.Property("FirstName"));
        }

        [Test]
        [Category("Models.Employee.Constructor")]
        public void InstantiateEmployeeWithLastNameProperty_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var employee = new Employee();

            //Assert
            Assert.That(employee, Has.Property("LastName"));
        }

        [Test]
        [Category("Models.Employee.Constructor")]
        public void InstantiateEmployeeWithFullNameProperty_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var employee = new Employee();

            //Assert
            Assert.That(employee, Has.Property("FullName"));
        }

        [Test]
        [Category("Models.Employee.Constructor")]
        public void ReturnStringJoiningFirstAndLastName_WhenInvoked()
        {
            //Arrange
            string firstName = "John";
            string lastName = "Doe";

            string expectedFullName = "John Doe";

            var employee = new Employee();
            employee.FirstName = firstName;
            employee.LastName = lastName;

            //Act
            //Assert
            Assert.AreEqual(expectedFullName, employee.FullName);
        }

        [Test]
        [Category("Models.Employee.Constructor")]
        public void InstantiateEmployeeWithJobTitleProperty_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var employee = new Employee();

            //Assert
            Assert.That(employee, Has.Property("JobTitle"));
        }

        [Test]
        [Category("Models.Employee.Constructor")]
        public void InstantiateEmployeeWithAddressIdProperty_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var employee = new Employee();

            //Assert
            Assert.That(employee, Has.Property("AddressId"));
        }

        [Test]
        [Category("Models.Employee.Constructor")]
        public void InstantiateEmployeeWithAddressProperty_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var employee = new Employee();

            //Assert
            Assert.That(employee, Has.Property("Address"));
        }

        [Test]
        [Category("Models.Employee.Constructor")]
        public void InstantiateEmployeeWithReportsToIdProperty_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var employee = new Employee();

            //Assert
            Assert.That(employee, Has.Property("ReportsToId"));
        }

        [Test]
        [Category("Models.Employee.Constructor")]
        public void InstantiateEmployeeWithReportsToProperty_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var employee = new Employee();

            //Assert
            Assert.That(employee, Has.Property("ReportsTo"));
        }
    }
}
