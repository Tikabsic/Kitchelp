using Application.DTOs;
using Application.Interfaces;
using FluentValidation;

namespace Application.Validation.RegisterValidator
{
    internal class RegisterValidator : AbstractValidator<RegisterRequestDTO>
    {
        public RegisterValidator(IAppDbContext dbContext)
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty();

            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var EmailInUse = dbContext.Users.Any(u => u.Email == value);

                    if(EmailInUse)
                    {
                        context.AddFailure("Email", "Email already taken.");
                    }
                });


            RuleFor(x => x.Password)
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]+$")
                .NotNull()
                .MinimumLength(8)
                .MaximumLength(16);

            RuleFor(c => c.ConfirmPassword)
                .Matches(c => c.Password);

            RuleFor(x => x.FirstName)
                .NotEmpty();

            RuleFor(x => x.LastName)
                .NotEmpty();
        }
    }
}
