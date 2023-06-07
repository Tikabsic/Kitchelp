
namespace Domain.Entities
{
    public class Owner : User
    {
        public List<Restaurant>? OwnedRestaurants { get; set; }
        public bool? OverduePayments { get; set; }
        public double? Payments { get; set; }
    }
}
