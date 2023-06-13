using Application.DTOs;
using Application.Interfaces.RegisterService;

namespace Application.Services.RegisterService
{
    public class RegisterService : IRegisterService
    {
        private readonly IRegisterServiceHelper _registerServiceHelper;
        public RegisterService(IRegisterServiceHelper registerServiceHelper)
        {
            _registerServiceHelper = registerServiceHelper;
        }

        public async Task<bool> RegisterEmployee(RegisterRequestDTO dto, Guid restaurantId)
        {
            var request = await _registerServiceHelper.RegisterEmployee(dto, restaurantId);

            if (!request)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> RegisterOwner(RegisterRequestDTO dto)
        {
            var request = await _registerServiceHelper.RegisterOwner(dto);

            if (!request)
            {
                return false;
            }

            return true;
        }
    }
}
