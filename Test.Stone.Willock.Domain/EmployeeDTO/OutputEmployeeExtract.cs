using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Stone.Willock.Domain.EmployeeDTO
{
    [ExcludeFromCodeCoverage]
    public record OutputEmployeeExtract(
        string MonthReference,
        decimal GrossSalary,
        decimal DiscountsTotal,
        decimal NetSalary,
        List<PayrollEntry> PayrollEntries
    );
}
