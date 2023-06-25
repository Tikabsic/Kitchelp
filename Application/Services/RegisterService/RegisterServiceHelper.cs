using Application.DTOs;
using Application.Interfaces;
using Application.Interfaces.RegisterService;
using Application.Interfaces.Repository;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using FluentValidation;

namespace Application.Services.RegisterService
{

    internal class RegisterServiceHelper : IRegisterServiceHelper
    {
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IValidator<RegisterRequest> _registerValidator;
        private readonly IValidator<RestaurantRegisterRequest> _restaurantValidator;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterServiceHelper
            (IRepositoryFactory repositoryFactory,
            IValidator<RegisterRequest> registerValidator,
            IValidator<RestaurantRegisterRequest> restaurantValidator,
            IMapper mapper,
            IPasswordHasher passwordHasher)
        {
            _repositoryFactory = repositoryFactory;
            _registerValidator = registerValidator;
            _restaurantValidator = restaurantValidator;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<bool> ValidateUserRequest(RegisterRequest dto)
        {
            var result = await _registerValidator.ValidateAsync(dto);

            if (!result.IsValid)
            {
                var errors = result.ToString();
                throw new BadValidationException(errors);
            }
            return true;
        }

        public async Task<bool> ValidateRestaurantRequest(RestaurantRegisterRequest dto)
        {
            var result = await _restaurantValidator.ValidateAsync(dto);

            if (!result.IsValid)
            {
                var errors = result.ToString();
                throw new BadValidationException(errors);
            }
            return true;
        }

        public async Task<bool> ValidateOwner(Guid ownerId)
        {
            var repository = _repositoryFactory.Create<Owner>();
            var owner = await repository.GetByIdAsync(ownerId);

            if (owner is null)
            {
                throw new NotFoundException(ownerId);
            }

            return true;
        }

        public async Task RegisterOwner(RegisterRequest dto)
        {
            var ownerRepository = _repositoryFactory.Create<Owner>();

            var newRestaurantOwner = _mapper.Map<Owner>(dto);
            newRestaurantOwner.Password = _passwordHasher.Hash(dto.Password);
            newRestaurantOwner.Role = Role.Owner;
            newRestaurantOwner.OverduePayments = false;
            newRestaurantOwner.Payments = 0.0;
            await ownerRepository.AddAsync(newRestaurantOwner);
            await ownerRepository.SaveChangesAsync();
        }

        public async Task RegisterEmployee(RegisterRequest dto, Guid restaurantId)
        {
            var restaurantRepository = _repositoryFactory.Create<Restaurant>();
            var restaurant = await restaurantRepository.GetByIdAsync(restaurantId);

            if (restaurant is null)
            {
                throw new NotFoundException(restaurantId);
            }

            var employeeRepository = _repositoryFactory.Create<Employee>();
            var restaurantEmployeeRepository = _repositoryFactory.Create<RestaurantEmployee>();

            var newEmployee = _mapper.Map<Employee>(dto);
            newEmployee.Password = _passwordHasher.Hash(dto.Password);

            var restaurantEmploye = new RestaurantEmployee()
            {
                Employee = newEmployee,
                EmployeeId = newEmployee.Id,
                Restaurant = restaurant,
                RestaurantId = restaurantId
            };

            await employeeRepository.AddAsync(newEmployee);
            await employeeRepository.SaveChangesAsync();

            await restaurantEmployeeRepository.AddAsync(restaurantEmploye);
            await restaurantEmployeeRepository.SaveChangesAsync();
        }

        public async Task RegisterRestaurant(Guid ownerId, RestaurantRegisterRequest dto)
        {

            var restaurantRepository = _repositoryFactory.Create<Restaurant>();

            var newRestaurant = _mapper.Map<Restaurant>(dto);
            newRestaurant.OwnerId = ownerId;
            newRestaurant.DateOfPayment = DateTime.Today.AddDays(31);

            await restaurantRepository.AddAsync(newRestaurant);
            await restaurantRepository.SaveChangesAsync();
        }
    }
}
