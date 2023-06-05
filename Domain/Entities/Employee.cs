using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Employee : User
    {
        public float? HourlyWage { get; set; }
        public List<Restaurant>? Jobs { get; set; }
        public List<WorkingDay>? WorkingDays { get; set; }
    }
}
