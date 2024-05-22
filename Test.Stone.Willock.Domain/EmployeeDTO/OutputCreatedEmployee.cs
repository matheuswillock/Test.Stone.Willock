using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Stone.Willock.Domain.EmployeeDTO
{
    [ExcludeFromCodeCoverage]
    public record OutputCreatedEmployee(
        Guid Id,
        string FullName,
        string Document,
        string Department,
        decimal Salary,
        string AdmissionDate,
        bool HealthPlan,
        bool DentalPlan,
        bool TransportVoucher
    );
}
