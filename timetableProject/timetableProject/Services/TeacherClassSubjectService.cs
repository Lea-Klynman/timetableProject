using timetableProject.Controllers;

namespace timetableProject.Services
{
    public class TeacherClassSubjectService
    {
        public List<TeacherClassSubject> TCSes { get; set; }
        public List<TeacherClassSubject> GetList() => TCSes;
        public TeacherClassSubject GetTeacherClassSubjectId(int id)
        {
            TeacherClassSubject c = TCSes.FirstOrDefault(cl => cl.TeacherClassSubjectId == id);
            return c;
        }
        public bool Update(int id, TeacherClassSubject tcs)
        {
            TeacherClassSubject c = TCSes.FirstOrDefault(cl => cl.TeacherClassSubjectId == id);
            if (c == null) return false;
            c.TeacherClassSubjectId = id;
            c.ClassId = tcs.ClassId;
            c.TeacherId = tcs.TeacherId;
            c.SubjectId = tcs.SubjectId;
            c.HoursPerWeek = tcs.HoursPerWeek;
            return true;
        }
        public bool RemoveItem(int id)
        {
            TeacherClassSubject c = TCSes.FirstOrDefault(c => c.TeacherClassSubjectId == id);
            if (c == null)
            {
                return false;
            }
            TCSes.Remove(c);
            return true;
        }
        public bool AddItem(TeacherClassSubject tcs)
        {
            if (tcs == null) return false;
            TCSes.Add(tcs);
            return true;
        }
    }
}
