using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Core.Entity;

namespace TimeTable.Core.Dtos
{
    public class TeacherDto
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
