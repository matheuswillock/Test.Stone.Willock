using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Stone.Willock.Domain.EmployeeDTO;
using Test.Stone.Willock.Domain;
using Test.Stone.Willock.Infrastructure.Library;
using Test.Stone.Willock.Infrastructure.PostgreSQL.Repository;
using Test.Stone.Willock.Infrastructure.Services;

namespace Test.Stone.Willock.Application.UseCase
{
    public class EmployeeUseCase : IEmployeeUseCase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDiscountsServices _discountsServices;
        private readonly ILogger<EmployeeUseCase> _logger;
        private readonly IOutput _output;

        public EmployeeUseCase(IEmployeeRepository employeeRepository, ILogger<EmployeeUseCase> logger, IOutput output, IDiscountsServices discountsServices)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
            _output = output;
            _discountsServices = discountsServices;
        }

        public async Task<IOutput> CreateEmployee(InputEmployeeToCreate input)
        {
            try
            {
                var employee = Employee.FromInputEmployeeToEmployee(input);

                var documentAlreadyExists = await _employeeRepository.GetByDocumentAsync(employee.Document);

                if (documentAlreadyExists != null)
                {
                    _output.AddErrorMessage("Employee already exists");
                    return _output;
                }

                await _employeeRepository.AddAsync(employee);

                _output.AddResult(Employee.ToOutputCreatedEmployee(employee));

                _logger.LogInformation("EmployeeUseCase::CreateEmployee - Employee created successfully");

                return _output;
            }
            catch (Exception error)
            {
                _logger.LogError($"RestaurantUseCase::CreateRestaurant - An Error occurred while creating the restaurant - error: {error}", error.Message);
                _output.AddErrorMessage($"RestaurantUseCase::CreateRestaurant - An Error occurred while creating the restaurant - error: {error.Message}");
                return _output;
            }
        }

        public async Task<IOutput> GetEmployeeById(Guid id)
        {
            try
            {
                var employee = await _employeeRepository.GetByIdAsync(id);

                if (employee == null)
                {
                    _output.AddErrorMessage("Employee not found");
                    return _output;
                }

                _output.AddResult(Employee.ToOutputCreatedEmployee(employee));

                _logger.LogInformation("EmployeeUseCase::GetEmployeeById - Employee found successfully");

                return _output;
            }
            catch (Exception error)
            {
                _logger.LogError($"RestaurantUseCase::GetEmployeeById - An Error occurred while getting the employee - error: {error}", error.Message);
                _output.AddErrorMessage($"RestaurantUseCase::GetEmployeeById - An Error occurred while getting the employee - error: {error.Message}");
                return _output;
            }
        }

        public async Task<IOutput> GetEmployeeExtract(Guid id)
        {
            try
            {
                var employee = await _employeeRepository.GetByIdAsync(id);

                if (employee == null)
                {
                    _output.AddErrorMessage("Employee not found");
                    return _output;
                }

                List<PayrollEntry> payrollEntries = new();

                payrollEntries.Add(new PayrollEntry("Desconto", _discountsServices.InssDiscount(employee.GrossSalary), "INSS"));

                payrollEntries.Add(new PayrollEntry("Desconto", _discountsServices.IncomeTaxDiscount(employee.GrossSalary), "Imposto de Renda"));

                payrollEntries.Add(new PayrollEntry("Desconto", _discountsServices.FgtsDiscount(employee.GrossSalary), "FGTS"));

                if (employee.HealthPlan)
                {
                    payrollEntries.Add(new PayrollEntry("Desconto", _discountsServices.HealthPlan(), "Plano de saúde"));
                }

                if (employee.DentalPlan)
                {
                    payrollEntries.Add(new PayrollEntry("Desconto", _discountsServices.DentalPlan(), "Plano odontológico"));
                }

                if (employee.TransportVoucher)
                {
                    payrollEntries.Add(new PayrollEntry("Desconto", _discountsServices.TransportVoucher(employee.GrossSalary), "Vale transporte"));
                }

                decimal totalDiscounts = 0;
                foreach (var payrollEntry in payrollEntries)
                {
                    totalDiscounts += payrollEntry.EntryValue;
                }

                OutputEmployeeExtract outputEmployeeExtract = new(
                    DateTime.UtcNow.ToString("MMMM/yyyy"),
                    employee.GrossSalary,
                    totalDiscounts,
                    employee.GrossSalary - (totalDiscounts),
                    payrollEntries
                );

                _output.AddResult(outputEmployeeExtract);

                return _output;
            }
            catch (Exception error)
            {
                _logger.LogError($"RestaurantUseCase::GetEmployeeById - An Error occurred while getting the employee - error: {error}", error.Message);
                _output.AddErrorMessage($"RestaurantUseCase::GetEmployeeById - An Error occurred while getting the employee - error: {error.Message}");
                return _output;
            }
        }
    }
}
