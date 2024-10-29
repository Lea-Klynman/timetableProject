using System.Collections.Generic;

namespace timetableProject
{
    public class Class
    {
        public int ClassId { get; set; }
        public string Name { get; set; }
        public int ClassNumber { get; set; }
        public int TotalWeekHours { get; set; }
        public List<ClassSubject> Subjects { get; set; }

        

    }
}
