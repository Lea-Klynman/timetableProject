using System.ComponentModel.DataAnnotations.Schema;
using TimeTable.Core.Entity;

namespace TimeTable.Api.PostModels
{
    public class AvailabilityPostModel
    {
        public int AvailabilityId { get; set; }
        public string DayOfWeek { get; set; }
        public string Unavailablehours { get; set; }
        public bool IsWholeDayOff { get; set; }
        public bool isMust { get; set; }
        public int TeacherId { get; set; }
    }
}
