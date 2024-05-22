using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Stone.Willock.Domain.EmployeeDTO;

namespace Test.Stone.Willock.Domain
{
    [ExcludeFromCodeCoverage]
    public class Employee
    {
        public Guid Id { get; set; } = new Guid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Department { get; set; }
        public decimal GrossSalary { get; set; }
        public DateTime AdmissionDate { get; set; }
        public bool HealthPlan { get; set; }
        public bool DentalPlan { get; set; }
        public bool TransportVoucher { get; set; }

        public Employee() { }

        public static Employee FromInputEmployeeToEmployee(InputEmployeeToCreate input)
        {
            var admissionDate = DateTime.SpecifyKind(DateTime.UtcNow.Date, DateTimeKind.Utc);

            return new Employee
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                Document = input.Document,
                Department = input.Department,
                GrossSalary = input.Salary,
                AdmissionDate = admissionDate,
                HealthPlan = input.HealthPlan,
                DentalPlan = input.DentalPlan,
                TransportVoucher = input.TransportVoucher
            };
        }

        public static OutputCreatedEmployee ToOutputCreatedEmployee(Employee employee)
        {
            return new OutputCreatedEmployee(
                employee.Id,
                $"{employee.FirstName} {employee.LastName}",
                employee.Document,
                employee.Department,
                employee.GrossSalary,
                employee.AdmissionDate.ToString("dd/MM/yyyy"),
                employee.HealthPlan,
                employee.DentalPlan,
                employee.TransportVoucher
            );
        }
    }
}
