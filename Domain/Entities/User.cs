

using Domain.Enums;

namespace Domain.Entities
{
    internal class User
    {
        internal Guid Id { get; set; }
        internal Role Role { get; set; }
        internal string? FirstName { get; set; }
        internal string? LastName { get; set; }
        internal int? DateOfBirth { get; set; }
        internal List<Restaurant>? Restaurants { get; set; }
        internal List<WorkingDay>? WorkingDays { get; set; }
        internal List<Chat>? Chats { get; set; }
        internal DateTime DateOfJoin { get; set; }
    }
}
