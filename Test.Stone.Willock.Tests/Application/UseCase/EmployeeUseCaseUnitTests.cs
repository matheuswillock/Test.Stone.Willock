using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Stone.Willock.Application.UseCase;
using Test.Stone.Willock.Domain;
using Test.Stone.Willock.Domain.EmployeeDTO;
using Test.Stone.Willock.Infrastructure.Library;
using Test.Stone.Willock.Infrastructure.PostgreSQL.Repository;
using Test.Stone.Willock.Infrastructure.Services;

namespace Test.Stone.Willock.Tests.Application.UseCase
{
    public class EmployeeUseCaseUnitTests
    {
        private readonly Mock<IEmployeeRepository> _employeeRepositoryMock;
        private readonly Mock<IDiscountsServices> _discountsServicesMock;
        private readonly Mock<ILogger<EmployeeUseCase>> _loggerMock;
        private readonly Mock<IOutput> _outputMock;
        private readonly EmployeeUseCase _employeeUseCase;

        public EmployeeUseCaseUnitTests()
        {
            _employeeRepositoryMock = new Mock<IEmployeeRepository>();
            _discountsServicesMock = new Mock<IDiscountsServices>();
            _loggerMock = new Mock<ILogger<EmployeeUseCase>>();
            _outputMock = new Mock<IOutput>();
            _employeeUseCase = new EmployeeUseCase(
                _employeeRepositoryMock.Object,
                _loggerMock.Object,
                _outputMock.Object,
                _discountsServicesMock.Object);
        }

        [Fact]
        public async Task CreateEmployee_ShouldReturnErrorMessage_WhenEmployeeAlreadyExists()
        {
            // Arrange
            var input = new InputEmployeeToCreate(
                "John",
                "Doe",
                "12345678912",
                "IT",
                5000,
                true,
                true,
                true
            );
            var existingEmployee = new Employee { Document = "12345678912" };

            _employeeRepositoryMock.Setup(repo => repo.GetByDocumentAsync(It.IsAny<string>()))
                .ReturnsAsync(existingEmployee);

            _outputMock.Setup(output => output.AddErrorMessage(It.IsAny<string>()));

            // Act
            var result = await _employeeUseCase.CreateEmployee(input);

            // Assert
            _employeeRepositoryMock.Verify(repo => repo.GetByDocumentAsync(It.IsAny<string>()), Times.Once);
            _employeeRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Employee>()), Times.Never);
            _outputMock.Verify(output => output.AddErrorMessage("Employee already exists"), Times.Once);
        }

        [Fact]
        public async Task CreateEmployee_ShouldCreateEmployee_WhenEmployeeDoesNotExist()
        {
            // Arrange
            var input = new InputEmployeeToCreate(
                "John",
                "Doe",
                "12345678912",
                "IT",
                5000,
                true,
                true,
                true
            );

            _employeeRepositoryMock.Setup(repo => repo.GetByDocumentAsync(It.IsAny<string>()))
                .ReturnsAsync((Employee)null);

            _employeeRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Employee>()));

            _outputMock.Setup(output => output.AddResult(It.IsAny<object>()));

            // Act
            var result = await _employeeUseCase.CreateEmployee(input);

            // Assert
            _employeeRepositoryMock.Verify(repo => repo.GetByDocumentAsync(It.IsAny<string>()), Times.Once);
            _employeeRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Employee>()), Times.Once);
            _outputMock.Verify(output => output.AddResult(It.IsAny<object>()), Times.Once);
        }

        [Fact]
        public async Task CreateEmployee_ShouldLogErrorAndReturnErrorMessage_WhenExceptionIsThrown()
        {
            // Arrange
            var input = new InputEmployeeToCreate(
                "John",
                "Doe",
                "12345678912",
                "IT",
                5000,
                true,
                true,
                true
            );

            var exceptionMessage = "Simulated exception";

            _employeeRepositoryMock.Setup(repo => repo.GetByDocumentAsync(It.IsAny<string>()))
                .ThrowsAsync(new Exception(exceptionMessage));

            _outputMock.Setup(output => output.AddErrorMessage(It.IsAny<string>()));

            // Act
            var result = await _employeeUseCase.CreateEmployee(input);

            // Assert
            _employeeRepositoryMock.Verify(repo => repo.GetByDocumentAsync(It.IsAny<string>()), Times.Once);

            _outputMock.Verify(output => output.AddErrorMessage(
                    It.Is<string>(msg => msg.Contains("RestaurantUseCase::CreateRestaurant - An Error occurred while creating the restaurant - error"))),
                Times.Once);
        }

        [Fact]
        public async Task GetEmployeeById_ShouldReturnErrorMessage_WhenEmployeeNotFound()
        {
            // Arrange
            var employeeId = Guid.NewGuid();

            _employeeRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Employee)null);

            _outputMock.Setup(output => output.AddErrorMessage(It.IsAny<string>()));

            // Act
            var result = await _employeeUseCase.GetEmployeeById(employeeId);

            // Assert
            _employeeRepositoryMock.Verify(repo => repo.GetByIdAsync(It.IsAny<Guid>()), Times.Once);
            _outputMock.Verify(output => output.AddErrorMessage("Employee not found"), Times.Once);
        }

        [Fact]
        public async Task GetEmployeeById_ShouldReturnEmployee_WhenEmployeeExists()
        {
            // Arrange
            var employeeId = Guid.NewGuid();
            var employee = new Employee { Id = employeeId };

            _employeeRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(employee);

            _outputMock.Setup(output => output.AddResult(It.IsAny<object>()));

            // Act
            var result = await _employeeUseCase.GetEmployeeById(employeeId);

            // Assert
            _employeeRepositoryMock.Verify(repo => repo.GetByIdAsync(It.IsAny<Guid>()), Times.Once);
            _outputMock.Verify(output => output.AddResult(It.IsAny<object>()), Times.Once);
        }

        [Fact]
        public async Task GetEmployeeById_ShouldLogErrorAndReturnErrorMessage_WhenExceptionIsThrown()
        {
            // Arrange
            var employeeId = Guid.NewGuid();
            var exceptionMessage = "Simulated exception";

            _employeeRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>()))
                .ThrowsAsync(new Exception(exceptionMessage));

            _outputMock.Setup(output => output.AddErrorMessage(It.IsAny<string>()));

            // Act
            var result = await _employeeUseCase.GetEmployeeById(employeeId);

            // Assert
            _employeeRepositoryMock.Verify(repo => repo.GetByIdAsync(It.IsAny<Guid>()), Times.Once);

            _outputMock.Verify(output => output.AddErrorMessage(
                It.Is<string>(msg => msg.Contains("An Error occurred while getting the employee"))), Times.Once);
        }

        [Fact]
        public async Task GetEmployeeExtract_ShouldReturnErrorMessage_WhenEmployeeNotFound()
        {
            // Arrange
            var employeeId = Guid.NewGuid();

            _employeeRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Employee)null);

            _outputMock.Setup(output => output.AddErrorMessage(It.IsAny<string>()));

            // Act
            var result = await _employeeUseCase.GetEmployeeExtract(employeeId);

            // Assert
            _employeeRepositoryMock.Verify(repo => repo.GetByIdAsync(It.IsAny<Guid>()), Times.Once);
            _outputMock.Verify(output => output.AddErrorMessage("Employee not found"), Times.Once);
        }

        [Fact]
        public async Task GetEmployeeExtract_ShouldLogErrorAndReturnErrorMessage_WhenExceptionIsThrown()
        {
            // Arrange
            var employeeId = Guid.NewGuid();
            var exceptionMessage = "Simulated exception";

            _employeeRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>()))
                .ThrowsAsync(new Exception(exceptionMessage));

            _outputMock.Setup(output => output.AddErrorMessage(It.IsAny<string>()));

            // Act
            var result = await _employeeUseCase.GetEmployeeExtract(employeeId);

            // Assert
            _employeeRepositoryMock.Verify(repo => repo.GetByIdAsync(It.IsAny<Guid>()), Times.Once);

            _outputMock.Verify(output => output.AddErrorMessage(
                    It.Is<string>(msg => msg.Contains("An Error occurred while getting the employee"))), Times.Once);
        }

        [Fact]
        public async Task GetEmployeeExtract_ShouldReturnExtract_WhenEmployeeExists()
        {
            // Arrange
            var employeeId = Guid.NewGuid();
            var employee = new Employee
            {
                Id = employeeId,
                GrossSalary = 10000,
                HealthPlan = true,
                DentalPlan = true,
                TransportVoucher = true
            };

            _employeeRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(employee);

            _discountsServicesMock.Setup(ds => ds.InssDiscount(It.IsAny<decimal>())).Returns(500);
            _discountsServicesMock.Setup(ds => ds.IncomeTaxDiscount(It.IsAny<decimal>())).Returns(1000);
            _discountsServicesMock.Setup(ds => ds.FgtsDiscount(It.IsAny<decimal>())).Returns(800);
            _discountsServicesMock.Setup(ds => ds.HealthPlan()).Returns(300);
            _discountsServicesMock.Setup(ds => ds.DentalPlan()).Returns(200);
            _discountsServicesMock.Setup(ds => ds.TransportVoucher(It.IsAny<decimal>())).Returns(150);

            _outputMock.Setup(output => output.AddResult(It.IsAny<object>()));

            // Act
            var result = await _employeeUseCase.GetEmployeeExtract(employeeId);

            // Assert
            _employeeRepositoryMock.Verify(repo => repo.GetByIdAsync(It.IsAny<Guid>()), Times.Once);
            _discountsServicesMock.Verify(ds => ds.InssDiscount(It.IsAny<decimal>()), Times.Once);
            _discountsServicesMock.Verify(ds => ds.IncomeTaxDiscount(It.IsAny<decimal>()), Times.Once);
            _discountsServicesMock.Verify(ds => ds.FgtsDiscount(It.IsAny<decimal>()), Times.Once);
            _discountsServicesMock.Verify(ds => ds.HealthPlan(), Times.Once);
            _discountsServicesMock.Verify(ds => ds.DentalPlan(), Times.Once);
            _discountsServicesMock.Verify(ds => ds.TransportVoucher(It.IsAny<decimal>()), Times.Once);
            _outputMock.Verify(output => output.AddResult(It.IsAny<object>()), Times.Once);
        }
    }
}
