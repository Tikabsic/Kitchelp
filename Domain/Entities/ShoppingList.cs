
namespace Domain.Entities
{
    public class ShoppingList
    {
        public Guid ListId { get; set; }
        public Restaurant? Restaurant { get; set; }
        public Guid RestaurantId { get; set; }
        public Employee? Author { get; set; }
        public Guid AuthorId { get; set; }
        public List<ShoppingListProduct>? Products { get; set; }
    }
}
