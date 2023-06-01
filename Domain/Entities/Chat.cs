
namespace Domain.Entities
{
    internal class Chat
    {
        internal Guid Id { get; set; }
        internal List<User>? Users { get; set; }
        internal List<ChatMessage>? Messages { get; set; }
    }
}
