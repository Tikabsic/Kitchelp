using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Owner : User
    {
        public List<Restaurant>? OwnedRestaurants { get; set; }
        public bool? OverduePayments { get; set; }
        public double? Payments { get; set; }
    }
}
