
using System.Reflection.Metadata;

namespace Domain.Entities
{
    internal class Restaurant
    {
        internal Guid Id { get; set; }
        internal string? RestaurantName { get; set; }
        internal User? RestaurantOwner { get; set; }
        internal List<User>? Employees { get; set; }
        internal DateTime DateOfJoin { get; set; }
        internal DateTime DateOfPayment { get; set; }
    }
}
