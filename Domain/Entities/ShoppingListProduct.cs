using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal class ShoppingListProduct
    {
        internal Guid Id { get; set; }
        internal ShoppingList? ShoppingList { get; set; }
        internal Guid ShoppingListId { get; set; }
        internal string? ProductName { get; set; }
        internal float? Quantity { get; set; }
    }
}
