
namespace Domain.Entities
{
    public class Chat
    {
        public Guid Id { get; set; }
        public Guid CreatorId { get; set; }
        public User? Creator { get; set; }
        public Guid ReciverId { get; set; }
        public User? Revicer { get; set; }
        public List<ChatMessage>? Messages { get; set; }
    }
}
