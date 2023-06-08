using Application.DTOs;

namespace Application.Interfaces
{
    internal interface IRegisterService
    {
        Task RegisterOwner(RegisterRequestDTO dto);
    }
}
