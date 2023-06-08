using Application.DTOs;
using Application.Interfaces;
using Application.Validation.RegisterValidator;
using Domain.Entities;
using Domain.Exceptions;
using FluentValidation;

namespace Application.Services.RegisterService
{
    internal class RegisterService : IRegisterService
    {
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IValidator<RegisterRequestDTO> _registerValidator;

        public RegisterService(IRepositoryFactory repositoryFactory,
                               RegisterValidator registerValidator)                             
        {
            _repositoryFactory = repositoryFactory;
            _registerValidator = registerValidator;
        }

        public async Task RegisterOwner(RegisterRequestDTO dto)
        {
            var ownerRepository = _repositoryFactory.Create<Owner>();
            var result = await _registerValidator.ValidateAsync(dto);

            if (!result.IsValid)
            {
                throw new BadValidationException("Something went wrong with validation.");
            }

        }
    }
}
