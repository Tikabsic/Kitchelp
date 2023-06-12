using Domain.Enums;

namespace Domain.Entities
{
    public abstract class User
    {
        public Guid Id { get; set; }
        public string? UserType { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Role Role { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? DateOfBirth { get; set; }
        public List<Chat>? Chats { get; set; }
        public DateTime DateOfJoin { get; set; } = DateTime.Now;
    }
}
