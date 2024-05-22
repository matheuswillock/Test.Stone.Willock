using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Stone.Willock.Infrastructure.Library;
using Test.Stone.Willock.Infrastructure.PostgreSQL.Repository;
using Test.Stone.Willock.Infrastructure.Services;

namespace Test.Stone.Willock.Infrastructure.DependencyInjections
{
    [ExcludeFromCodeCoverage]
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructures(this IServiceCollection services)
        {
            services.AddScoped<IOutput, Output>();
            services.AddScoped<IDiscountsServices, DiscountsServices>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
}
