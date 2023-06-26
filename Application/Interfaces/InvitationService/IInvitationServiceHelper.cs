using Domain.Entities;

namespace Application.Interfaces.InvitationService
{
    public interface IInvitationServiceHelper
    {
        Task<bool> VerifyRequest(Guid restaurantId, Guid ownerId);
        Task<string> GenerateInvitationToken(Guid restaurantId);
        Task SendInvitationEmail(string employeeEmail,string employeeName, string invitationToken);
    }
}