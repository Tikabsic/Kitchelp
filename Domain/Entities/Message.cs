
namespace Domain.Entities
{
    internal class ChatMessage
    {
        internal Guid Id { get; set; }
        internal Guid ChatId { get; set; }
        internal User? Author { get; set; }
        internal Guid AuthorId { get; set; }
        internal User? Reciver { get; set; }
        internal Guid ReciverId { get; set; }
        internal string? Message { get; set; }
    }
}
