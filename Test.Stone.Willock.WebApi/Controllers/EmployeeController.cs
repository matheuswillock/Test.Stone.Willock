using Microsoft.AspNetCore.Mvc;
using Test.Stone.Willock.Application.UseCase;
using Test.Stone.Willock.Domain.EmployeeDTO;

namespace Test.Stone.Willock.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeUseCase _employeeUseCase;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeUseCase employeeUseCase)
        {
            _logger = logger;
            _employeeUseCase = employeeUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] InputEmployeeToCreate input)
        {
            try
            {
                var result = await _employeeUseCase.CreateEmployee(input);

                if (!result.IsValid)
                    return BadRequest(result.ErrorMessages.First());

                return Ok(result.GetResult());
            }
            catch (Exception error)
            {
                _logger.LogError($"EmployeeController::CreateEmployee - An Error occurred while creating the employee - error: {error}", error.Message);
                return StatusCode(500, $"An error occurred while creating the employee. Please try again later.\n Error: {error}");
            }
        }

        [HttpGet("/employee/{id}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute] Guid id)
        {
            try
            {
                var result = await _employeeUseCase.GetEmployeeById(id);

                if (!result.IsValid)
                    return BadRequest(result.ErrorMessages.First());

                return Ok(result.GetResult());
            }
            catch (Exception error)
            {
                _logger.LogError($"EmployeeController::CreateEmployee - An Error occurred while creating the employee - error: {error}", error.Message);
                return StatusCode(500, $"An error occurred while creating the employee. Please try again later.\n Error: {error}");
            }
        }

        [HttpGet("/employee/extract/{id}")]
        public async Task<IActionResult> GetEmployeeExtract([FromRoute] Guid id)
        {
            try
            {
                var result = await _employeeUseCase.GetEmployeeExtract(id);

                if (!result.IsValid)
                    return BadRequest(result.ErrorMessages.First());

                return Ok(result.GetResult());
            }
            catch (Exception error)
            {
                _logger.LogError($"EmployeeController::CreateEmployee - An Error occurred while creating the employee - error: {error}", error.Message);
                return StatusCode(500, $"An error occurred while creating the employee. Please try again later.\n Error: {error}");
            }
        }
    }
}
