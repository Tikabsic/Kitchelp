
namespace Domain.Entities
{
    internal class ShoppingList
    {
        internal Guid ListId { get; set; }
        internal Restaurant? Restaurant { get; set; }
        internal Guid RestaurantId { get; set; }
        internal User? Author { get; set; }
        internal Guid AuthorId { get; set; }
        internal List<ShoppingListProduct>? Products { get; set; }
    }
}
