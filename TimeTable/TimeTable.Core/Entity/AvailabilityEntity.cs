using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Core.Entity
{
    public class AvailabilityEntity
    {
        public int AvailabilityId { get; set; }
        public string DayOfWeek { get; set; }
        public string Unavailablehours { get; set; }
        public bool IsWholeDayOff { get; set; }
        public bool isMust { get; set; }

    }
}
