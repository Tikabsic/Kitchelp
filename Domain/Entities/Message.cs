
namespace Domain.Entities
{
    public class ChatMessage
    {
        public Guid Id { get; set; }
        public Guid ChatId { get; set; }
        public Chat? Chat { get; set; }
        public User? Author { get; set; }
        public Guid AuthorId { get; set; }
        public string? Message { get; set; }
    }
}
