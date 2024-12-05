using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Core.Entity
{
    public class TeacherEntity
    {
        [Key]
        public int TeacherId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Id { get; set; }
        public List<TeacherClassSubjectEntity> Subjects { get; set; }
        public List<AvailabilityEntity> Availabilities { get; set; }
        public int TotalWeeklyHours { get; set; }

    }
}
