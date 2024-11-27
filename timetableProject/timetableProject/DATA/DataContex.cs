using timetableProject.DTO;

namespace timetableProject.DATA
{
    public class DataContex
    {
        public List<Availability> _Availabilities { get; set; }
        public List<Class> _Classes { get; set; }
        public List<ClassSubject> _ClassSubject { get; set; }
        public List<Subject> _Subjects { get; set; }
        public List<TeacherClassSubject> _TeacherClassSubject { get; set; }
        public List<Teacher> _Teachers { get; set; }




    }
}
