using timetableProject.Controllers;

namespace timetableProject.Services
{
    public class ClassSubjectService
    {
        public List<ClassSubject> ClassSubject { get; set; }
        public List<ClassSubject> GetList() => ClassSubject;
        public ClassSubject GetClassSubjectId(int id)
        {
            ClassSubject cs = ClassSubject.FirstOrDefault(c => c.ClassSubjectId == id);
            return cs;
        }
        public bool Update(int id, ClassSubject tcs)
        {
            ClassSubject cs = ClassSubject.FirstOrDefault(c => c.ClassSubjectId == id);
            if (cs == null) return false;
            cs.ClassSubjectId = id;
            cs.ClassId = tcs.ClassId;
            cs.SubjectId = tcs.SubjectId;
            return true;
        }
        public bool RemoveItem(int id)
        {
            ClassSubject cs = ClassSubject.FirstOrDefault(c => c.ClassSubjectId == id);
            if (cs == null)
            {
                return false;
            }
            ClassSubject.Remove(cs);
            return true;
        }
        public bool AddItem(ClassSubject tcs)
        {
            if (tcs == null) return false;
            ClassSubject.Add(tcs);
            return true;
        }
    
}
}
