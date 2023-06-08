namespace Domain.Entities
{
    public class Employee : User
    {
        public float? HourlyWage { get; set; }
        public List<Restaurant>? Jobs { get; set; }
        public List<WorkingDay>? WorkingDays { get; set; }
        public List<ShoppingList>? ShoppingLists { get; set; }
    }
}
