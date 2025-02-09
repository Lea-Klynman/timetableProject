using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Core.Entity;

namespace TimeTable.Core.Dtos
{
    public class AvailabilityDto
    {
        public int AvailabilityId { get; set; }
        public string DayOfWeek { get; set; }
        public string Unavailablehours { get; set; }
        public bool IsWholeDayOff { get; set; }
        public bool isMust { get; set; }
        public int TeacherId { get; set; }
        public TeacherEntity Teacher { get; set; }
    }
}
