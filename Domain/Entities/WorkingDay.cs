using Domain.Enums;

namespace Domain.Entities
{
    internal class WorkingDay
    {
        internal Restaurant? Restaurant { get; set; }
        internal Guid RestaurantId { get; set; }
        internal User? Employee { get; set; }
        internal Guid EmployeeId { get; set; }
        internal DateTime DateOfWork { get; set; }
        internal string? ShiftStartAt { get; set; }
        internal string? ShiftEndAt { get; set; }
    }
}
