using Application.DTOs;
using FluentValidation;

namespace Application.Validation.RegisterValidator
{
    internal class RestaurantRegisterValidator : AbstractValidator<RestaurantRegisterRequest>
    {
        public RestaurantRegisterValidator()
        {
            RuleFor(x => x.Address)
                .MaximumLength(100)
                .NotEmpty();

            RuleFor(x => x.NIP)
                .Length(10)
                .NotEmpty();

            RuleFor(x => x.RestaurantName)
                .MaximumLength(100)
                .NotEmpty();
        }
    }
}
