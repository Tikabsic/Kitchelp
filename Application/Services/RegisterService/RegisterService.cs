using Application.DTOs;
using Application.Interfaces.RegisterService;

namespace Application.Services.RegisterService
{
    internal class RegisterService : IRegisterService
    {
        private readonly IRegisterServiceHelper _registerServiceHelper;
        public RegisterService(IRegisterServiceHelper registerServiceHelper)                             
        {
            _registerServiceHelper = registerServiceHelper;
        }

        public async Task<bool> RegisterOwner(RegisterRequestDTO dto)
        {
            var request = await _registerServiceHelper.ValidateRequest(dto);

            if (!request)
            {
                return false;
            }

            await _registerServiceHelper.RegisterOwner(dto);

            return true;
        }
    }
}
