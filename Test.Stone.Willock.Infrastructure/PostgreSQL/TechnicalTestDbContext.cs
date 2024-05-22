using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Stone.Willock.Domain;

namespace Test.Stone.Willock.Infrastructure.PostgreSQL
{
    [ExcludeFromCodeCoverage]
    public class TechnicalTestDbContext : DbContext
    {

        public TechnicalTestDbContext(DbContextOptions<TechnicalTestDbContext> options)
            : base(options)
        {
        }

        public TechnicalTestDbContext() : base(new DbContextOptionsBuilder<TechnicalTestDbContext>()
            .UseNpgsql("Host=localhost;Port=5432;Database=stone_db_postgres;Username=my_user;Password=my_pw")
            .Options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasKey(e => e.Id);
        }
    }
}
