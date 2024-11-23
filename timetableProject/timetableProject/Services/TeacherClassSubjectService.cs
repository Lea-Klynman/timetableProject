using timetableProject.Controllers;
using timetableProject.DATA;
using timetableProject.DTO;

namespace timetableProject.Services
{
    public class TeacherClassSubjectService
    {
        public List<TeacherClassSubject> GetList() {
        if(MangerDataContex._dataContex._TeacherClassSubject==null)
                MangerDataContex._dataContex._TeacherClassSubject=new List<TeacherClassSubject>();
            return MangerDataContex._dataContex._TeacherClassSubject;

        }
        public TeacherClassSubject GetTeacherClassSubjectId(int id)
        {
            if (MangerDataContex._dataContex._TeacherClassSubject == null)
                MangerDataContex._dataContex._TeacherClassSubject = new List<TeacherClassSubject>();
            TeacherClassSubject c = MangerDataContex._dataContex._TeacherClassSubject.FirstOrDefault(cl => cl.TeacherClassSubjectId == id);
            return c;
        }
        public bool Update(int id, TeacherClassSubject tcs)
        {
            if (MangerDataContex._dataContex._TeacherClassSubject == null)
                MangerDataContex._dataContex._TeacherClassSubject = new List<TeacherClassSubject>();
            TeacherClassSubject c = MangerDataContex._dataContex._TeacherClassSubject.FirstOrDefault(cl => cl.TeacherClassSubjectId == id);
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
            if (MangerDataContex._dataContex._TeacherClassSubject == null)
                MangerDataContex._dataContex._TeacherClassSubject = new List<TeacherClassSubject>();
            TeacherClassSubject c = MangerDataContex._dataContex._TeacherClassSubject.FirstOrDefault(c => c.TeacherClassSubjectId == id);
            if (c == null)
            {
                return false;
            }
            MangerDataContex._dataContex._TeacherClassSubject.Remove(c);
            return true;
        }
        public bool AddItem(TeacherClassSubject tcs)
        {
            if (MangerDataContex._dataContex._TeacherClassSubject == null)
                MangerDataContex._dataContex._TeacherClassSubject = new List<TeacherClassSubject>();
            if (tcs == null) return false;
            tcs.TeacherId= MangerDataContex._dataContex._TeacherClassSubject.Max(c => c.TeacherId)+1;
            MangerDataContex._dataContex._TeacherClassSubject.Add(tcs);
            return true;
        }
    }
}
