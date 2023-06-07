using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Warehouse
    {
        public Guid Id { get; set; }
        public Restaurant? Restaurant { get; set; }
        public Guid RestaurantId { get; set; }
        public List<Product>? Products { get; set; }

    }
}
