using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ShoppingListProduct
    {
        public Guid Id { get; set; }
        public ShoppingList? ShoppingList { get; set; }
        public Guid ShoppingListId { get; set; }
        public string? ProductName { get; set; }
        public float? Quantity { get; set; }
    }
}
