
namespace Domain.Entities
{
    public class Restaurant
    {
        public Guid Id { get; set; }
        public string? RestaurantName { get; set; }
        public Guid OwnerId { get; set; }
        public Owner? Owner { get; set; }
        public string? NIP { get; set; }
        public string? Address { get; set; }
        public List<Employee>? Employees { get; set; }
        public Warehouse? Warehouse { get; set; }
        public List<ShoppingList>? ShoppingLists { get; set; }
        public DateTime DateOfJoin { get; set; } = DateTime.Today;
        public DateTime DateOfPayment { get; set; }

    }
}
