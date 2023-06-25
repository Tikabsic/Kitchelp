
namespace Domain.Entities
{
    public class InvitationToken
    {
        public Guid Id { get; set; }
        public Guid RestaurantId { get; set; }
        public string? Token { get; set; }
    }
}
