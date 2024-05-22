using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Stone.Willock.Domain;

namespace Test.Stone.Willock.Infrastructure.PostgreSQL.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly TechnicalTestDbContext _context;

        public EmployeeRepository(TechnicalTestDbContext context)
        {
            _context = context;
        }

        public async Task<Employee?> GetByIdAsync(Guid id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<Employee?> GetByDocumentAsync(string document)
        {
            return await _context.Employees.FirstOrDefaultAsync(x => x.Document == document);
        }

        public async Task AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

    }
}
