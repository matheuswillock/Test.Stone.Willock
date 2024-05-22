
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using Test.Stone.Willock.Infrastructure.PostgreSQL;
using Test.Stone.Willock.WebApi.Controllers.Validator;
using Test.Stone.Willock.Application.DependencyInjections;
using Test.Stone.Willock.Infrastructure.DependencyInjections;

namespace Test.Stone.Willock.WebApi
{
    [ExcludeFromCodeCoverage]
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers().AddFluentValidation(fv =>
                fv.RegisterValidatorsFromAssemblyContaining<EmployeeValidator>());

            builder.Services.AddDbContext<TechnicalTestDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddApplication();
            builder.Services.AddInfrastructures();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
