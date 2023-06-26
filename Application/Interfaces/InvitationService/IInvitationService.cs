namespace Application.Interfaces.InvitationService
{
    public interface IInvitationService
    {
        Task<bool> InviteNewEmployee(string employeeEmail, string employeeName, Guid restaurantId, Guid ownerId);
    }
}