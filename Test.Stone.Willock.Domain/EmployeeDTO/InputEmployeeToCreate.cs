using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Stone.Willock.Domain.EmployeeDTO
{
    [ExcludeFromCodeCoverage]
    public record InputEmployeeToCreate(
        string FirstName,
        string LastName,
        string Document,
        string Department,
        decimal Salary,
        bool HealthPlan,
        bool DentalPlan,
        bool TransportVoucher
    );
}
