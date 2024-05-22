using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Stone.Willock.Domain;

namespace Test.Stone.Willock.Infrastructure.PostgreSQL.Repository
{
    public interface IEmployeeRepository
    {
        Task<Employee?> GetByIdAsync(Guid id);
        Task<Employee?> GetByDocumentAsync(string document);
        Task AddAsync(Employee employee);
    }
}
