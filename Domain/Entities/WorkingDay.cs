using Domain.Enums;

namespace Domain.Entities
{
    public class WorkingDay
    {
        public Restaurant? Restaurant { get; set; }
        public Guid RestaurantId { get; set; }
        public Employee? Employee { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime DateOfWork { get; set; }
        public string? ShiftStartAt { get; set; }
        public string? ShiftEndAt { get; set; }
    }
}
