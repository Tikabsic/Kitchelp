using Application.DTOs;
using Application.Interfaces;
using Application.Interfaces.RegisterService;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Application.Services.RegisterService
{

    internal class RegisterServiceHelper : IRegisterServiceHelper
    {
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IValidator<RegisterRequestDTO> _registerValidator;
        private readonly IMapper _mapper;

        public RegisterServiceHelper
            (IRepositoryFactory repositoryFactory,
            IValidator<RegisterRequestDTO> registerValidator,
            IMapper mapper)
        {
            _repositoryFactory = repositoryFactory;
            _registerValidator = registerValidator;
            _mapper = mapper;
        }

        public async Task<bool> ValidateRequest(RegisterRequestDTO dto)
        {
            var result = await _registerValidator.ValidateAsync(dto);

            if (!result.IsValid)
            {
                var errors = result.ToString();
                throw new BadValidationException(errors);
            }
            return true;
        }

        public async Task RegisterOwner(RegisterRequestDTO dto)
        {
            var ownerRepository = _repositoryFactory.Create<Owner>();

            var newRestaurantOwner = _mapper.Map<Owner>(dto);
            newRestaurantOwner.OverduePayments = false;
            newRestaurantOwner.Payments = 0.0;
            await ownerRepository.AddAsync(newRestaurantOwner);
            await ownerRepository.SaveChangesAsync();

            await Task.CompletedTask;
        }
    }
}
