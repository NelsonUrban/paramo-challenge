using FluentValidation;
using Sat.Recruitment.Business.Dtos;

namespace Sat.Recruitment.Custom.Validatiors
{
    public class CreateUserValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidator()
        {
            RuleFor(u => u.Name).NotNull().WithMessage("The name is required");
            RuleFor(u => u.Money).NotNull().WithMessage("The money is required");
            RuleFor(u => u.Email).NotNull().WithMessage("The email must not be null").EmailAddress().WithMessage("The email has invalid format");
            RuleFor(u => u.Address).NotNull().WithMessage("The address is required");
            RuleFor(u => u.Phone).NotNull().WithMessage("The phone is required");
        }
    }
}
