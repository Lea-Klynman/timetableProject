using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Core.Entity
{
    public class TeacherEntity
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
        public List<TeacherClassSubjectEntity> Subjects { get; set; }
        public List<AvailabilityEntity> Availabilities { get; set; }
        public int TotalWeeklyHours { get; set; }

    }
}
