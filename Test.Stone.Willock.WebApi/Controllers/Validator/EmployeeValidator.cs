using FluentValidation;
using System.Diagnostics.CodeAnalysis;
using Test.Stone.Willock.Domain.EmployeeDTO;

namespace Test.Stone.Willock.WebApi.Controllers.Validator
{
    public class EmployeeValidator : AbstractValidator<InputEmployeeToCreate>
    {
        [ExcludeFromCodeCoverage]
        public EmployeeValidator()
        {
            RuleFor(input => input.FirstName).NotEmpty().WithMessage("Name is required.");
            RuleFor(input => input.LastName).NotEmpty().WithMessage("Name is required.");
            RuleFor(input => input.Document)
                .NotEmpty().WithMessage("Document is required.")
                .Matches(@"^\d{11}$").WithMessage("Document must be a CPF without punctuation (xxxxxxxxxxx).");
            RuleFor(input => input.Department).NotEmpty().WithMessage("Department is required.");
            RuleFor(input => input.Salary)
                .NotEmpty().WithMessage("GrossSalary is required.")
                .GreaterThanOrEqualTo(100).WithMessage("GrossSalary must be at least $100.00");
        }
    }
}
