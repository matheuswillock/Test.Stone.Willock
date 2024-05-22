using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Stone.Willock.Domain.EmployeeDTO
{
    [ExcludeFromCodeCoverage]
    public record PayrollEntry(
        string EntryType,
        decimal EntryValue,
        string Description
    );
}
