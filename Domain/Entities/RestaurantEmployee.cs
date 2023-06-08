namespace Domain.Entities
{
    public class RestaurantEmployee
    {
        public Employee? Employee { get; set; }
        public Guid EmployeeId { get; set; }
        public Restaurant? Restaurant { get; set; }
        public Guid RestaurantId { get; set; }
    }
}
