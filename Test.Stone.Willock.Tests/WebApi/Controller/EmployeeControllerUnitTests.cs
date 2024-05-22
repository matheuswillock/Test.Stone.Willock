using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Stone.Willock.Application.UseCase;
using Test.Stone.Willock.Domain.EmployeeDTO;
using Test.Stone.Willock.Infrastructure.Library;
using Test.Stone.Willock.WebApi.Controllers;

namespace Test.Stone.Willock.Tests.WebApi.Controller
{
    public class EmployeeControllerUnitTests
    {
        private readonly Mock<IEmployeeUseCase> _employeeUseCaseMock;
        private readonly Mock<ILogger<EmployeeController>> _loggerMock;
        private readonly EmployeeController _controller;

        public EmployeeControllerUnitTests()
        {
            _employeeUseCaseMock = new Mock<IEmployeeUseCase>();
            _loggerMock = new Mock<ILogger<EmployeeController>>();
            _controller = new EmployeeController(_loggerMock.Object, _employeeUseCaseMock.Object);
        }

        [Fact]
        public async Task CreateEmployee_ReturnsOk_WhenResultIsValid()
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
            var outputMock = new Mock<IOutput>();
            outputMock.Setup(o => o.IsValid).Returns(true);
            outputMock.Setup(o => o.GetResult()).Returns(new { Success = true });
            _employeeUseCaseMock.Setup(eu => eu.CreateEmployee(It.IsAny<InputEmployeeToCreate>()))
                .ReturnsAsync(outputMock.Object);

            // Act
            var result = await _controller.CreateEmployee(input);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task CreateEmployee_ReturnsBadRequest_WhenResultIsInvalid()
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
            var outputMock = new Mock<IOutput>();
            outputMock.Setup(o => o.IsValid).Returns(false);
            outputMock.Setup(o => o.ErrorMessages).Returns(new[] { "Error" }.ToList());
            _employeeUseCaseMock.Setup(eu => eu.CreateEmployee(It.IsAny<InputEmployeeToCreate>()))
                .ReturnsAsync(outputMock.Object);

            // Act
            var result = await _controller.CreateEmployee(input);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);
            Assert.Equal("Error", badRequestResult.Value);
        }

        [Fact]
        public async Task CreateEmployee_ReturnsServerError_WhenExceptionIsThrown()
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
            _employeeUseCaseMock.Setup(eu => eu.CreateEmployee(It.IsAny<InputEmployeeToCreate>()))
                .ThrowsAsync(new Exception(exceptionMessage));

            // Act
            var result = await _controller.CreateEmployee(input);

            // Assert
            var serverErrorResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, serverErrorResult.StatusCode);
            Assert.Contains("An error occurred while creating the employee", serverErrorResult.Value.ToString());
        }

        [Fact]
        public async Task GetEmployeeById_ReturnsOk_WhenResultIsValid()
        {
            // Arrange
            var id = Guid.NewGuid();
            var outputMock = new Mock<IOutput>();
            outputMock.Setup(o => o.IsValid).Returns(true);
            outputMock.Setup(o => o.GetResult()).Returns(new { Success = true });
            _employeeUseCaseMock.Setup(eu => eu.GetEmployeeById(It.IsAny<Guid>()))
                .ReturnsAsync(outputMock.Object);

            // Act
            var result = await _controller.GetEmployeeById(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task GetEmployeeById_ReturnsBadRequest_WhenResultIsInvalid()
        {
            // Arrange
            var id = Guid.NewGuid();
            var outputMock = new Mock<IOutput>();
            outputMock.Setup(o => o.IsValid).Returns(false);
            outputMock.Setup(o => o.ErrorMessages).Returns(new[] { "Error" }.ToList());
            _employeeUseCaseMock.Setup(eu => eu.GetEmployeeById(It.IsAny<Guid>()))
                .ReturnsAsync(outputMock.Object);

            // Act
            var result = await _controller.GetEmployeeById(id);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);
            Assert.Equal("Error", badRequestResult.Value);
        }

        [Fact]
        public async Task GetEmployeeById_ReturnsServerError_WhenExceptionIsThrown()
        {
            // Arrange
            var id = Guid.NewGuid();
            var exceptionMessage = "Simulated exception";
            _employeeUseCaseMock.Setup(eu => eu.GetEmployeeById(It.IsAny<Guid>()))
                .ThrowsAsync(new Exception(exceptionMessage));

            // Act
            var result = await _controller.GetEmployeeById(id);

            // Assert
            var serverErrorResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, serverErrorResult.StatusCode);
            Assert.Contains("An error occurred while creating the employee", serverErrorResult.Value.ToString());
        }

        [Fact]
        public async Task GetEmployeeExtract_ReturnsOk_WhenResultIsValid()
        {
            // Arrange
            var id = Guid.NewGuid();
            var outputMock = new Mock<IOutput>();
            outputMock.Setup(o => o.IsValid).Returns(true);
            outputMock.Setup(o => o.GetResult()).Returns(new { Success = true });
            _employeeUseCaseMock.Setup(eu => eu.GetEmployeeExtract(It.IsAny<Guid>()))
                .ReturnsAsync(outputMock.Object);

            // Act
            var result = await _controller.GetEmployeeExtract(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task GetEmployeeExtract_ReturnsBadRequest_WhenResultIsInvalid()
        {
            // Arrange
            var id = Guid.NewGuid();
            var outputMock = new Mock<IOutput>();
            outputMock.Setup(o => o.IsValid).Returns(false);
            outputMock.Setup(o => o.ErrorMessages).Returns(new[] { "Error" }.ToList());
            _employeeUseCaseMock.Setup(eu => eu.GetEmployeeExtract(It.IsAny<Guid>()))
                .ReturnsAsync(outputMock.Object);

            // Act
            var result = await _controller.GetEmployeeExtract(id);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);
            Assert.Equal("Error", badRequestResult.Value);
        }

        [Fact]
        public async Task GetEmployeeExtract_ReturnsServerError_WhenExceptionIsThrown()
        {
            // Arrange
            var id = Guid.NewGuid();
            var exceptionMessage = "Simulated exception";
            _employeeUseCaseMock.Setup(eu => eu.GetEmployeeExtract(It.IsAny<Guid>()))
                .ThrowsAsync(new Exception(exceptionMessage));

            // Act
            var result = await _controller.GetEmployeeExtract(id);

            // Assert
            var serverErrorResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, serverErrorResult.StatusCode);
            Assert.Contains("An error occurred while creating the employee", serverErrorResult.Value.ToString());
        }

    }
}
