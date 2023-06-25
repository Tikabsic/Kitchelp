using Application.DTOs;
using Application.Interfaces.RegisterService;
using Domain.Entities;

namespace Application.Services.RegisterService
{
    public class RegisterService : IRegisterService
    {
        private readonly IRegisterServiceHelper _registerServiceHelper;
        public RegisterService(IRegisterServiceHelper registerServiceHelper)
        {
            _registerServiceHelper = registerServiceHelper;
        }

        public async Task<bool> RegisterEmployee(RegisterRequest dto, Guid restaurantId)
        {
            var validationResult = await _registerServiceHelper.ValidateUserRequest(dto);

            if (!validationResult)
            {
                return false;
            }

            await _registerServiceHelper.RegisterEmployee(dto, restaurantId);
            return true;
        }

        public async Task<bool> RegisterOwner(RegisterRequest dto)
        {
            var validationResult = await _registerServiceHelper.ValidateUserRequest(dto);

            if (!validationResult)
            {
                return false;
            }

            await _registerServiceHelper.RegisterOwner(dto);
            return true;
        }

        public async Task<bool> RegisterRestaurant(Guid ownerId,RestaurantRegisterRequest dto)
        {
            var ownerValidationResult = await _registerServiceHelper.ValidateOwner(ownerId);
            var restaurantValidationResult = await _registerServiceHelper.ValidateRestaurantRequest(dto);

            if (!ownerValidationResult ||
                !restaurantValidationResult)
            {
                return false;
            }

            await _registerServiceHelper.RegisterRestaurant(ownerId, dto);
            return true;
        }
    }
}
