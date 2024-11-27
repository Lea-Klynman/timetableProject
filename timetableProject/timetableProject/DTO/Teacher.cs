using System.Collections.Generic;
using timetableProject.Controllers;

namespace timetableProject.DTO
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
        public List<TeacherClassSubject> Subjects { get; set; }
        public List<Availability> Availabilities { get; set; }
        public int TotalWeeklyHours { get; set; }

    }
}
