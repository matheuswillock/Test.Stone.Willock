using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Stone.Willock.Domain.EmployeeDTO;
using Test.Stone.Willock.Infrastructure.Library;

namespace Test.Stone.Willock.Application.UseCase
{
    public interface IEmployeeUseCase
    {
        Task<IOutput> CreateEmployee(InputEmployeeToCreate input);

        Task<IOutput> GetEmployeeById(Guid id);

        Task<IOutput> GetEmployeeExtract(Guid id);

    }
}
