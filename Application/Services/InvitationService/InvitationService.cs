using Application.Interfaces.InvitationService;

namespace Application.Services.InvitationService
{
    public class InvitationService : IInvitationService
    {
        private readonly IInvitationServiceHelper _invitationServiceHelper;

        public InvitationService(IInvitationServiceHelper invitationServiceHelper)
        {
            _invitationServiceHelper = invitationServiceHelper;
        }

        public async Task<bool> InviteNewEmployee(string employeeEmail, string employeeName, Guid restaurantId, Guid ownerId)
        {
            var request = await _invitationServiceHelper.VerifyRequest(restaurantId, ownerId);


            if (!request)
            {
                return false;
            }

            var token = await _invitationServiceHelper.GenerateInvitationToken(restaurantId);
            await _invitationServiceHelper.SendInvitationEmail(employeeEmail, employeeName, token);

            return true;
        }
    }
}
