using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Core.Entity
{
    [Table("Availability")]
    public class AvailabilityEntity
    {
        [Key]
        public int AvailabilityId { get; set; }
        public string DayOfWeek { get; set; }
        public string Unavailablehours { get; set; }
        public bool IsWholeDayOff { get; set; }
        public bool isMust { get; set; }
        public int TeacherId { get; set; }
        [ForeignKey(nameof(TeacherId))]
        public TeacherEntity Teacher { get; set; }


    }
}
