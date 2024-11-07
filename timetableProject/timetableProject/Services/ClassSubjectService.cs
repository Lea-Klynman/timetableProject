using timetableProject.Controllers;

namespace timetableProject.Services
{
    public class ClassSubjectService
    {
        public List<ClassSubject> GetList() {
            if(MangerDataContex._dataContex._ClassSubject ==null)
                MangerDataContex._dataContex._ClassSubject=new List<ClassSubject>();
            return MangerDataContex._dataContex._ClassSubject; }
        public ClassSubject GetClassSubjectId(int id)
        {
            if (MangerDataContex._dataContex._ClassSubject == null)
                MangerDataContex._dataContex._ClassSubject = new List<ClassSubject>();
            ClassSubject cs = MangerDataContex._dataContex._ClassSubject.FirstOrDefault(c => c.ClassSubjectId == id);
            return cs;
        }
        public bool Update(int id, ClassSubject tcs)
        {
            if (MangerDataContex._dataContex._ClassSubject == null)
                MangerDataContex._dataContex._ClassSubject = new List<ClassSubject>();
            ClassSubject cs = MangerDataContex._dataContex._ClassSubject.FirstOrDefault(c => c.ClassSubjectId == id);
            if (cs == null) return false;
            cs.ClassSubjectId = id;
            cs.ClassId = tcs.ClassId;
            cs.SubjectId = tcs.SubjectId;
            return true;
        }
        public bool RemoveItem(int id)
        {
            if (MangerDataContex._dataContex._ClassSubject == null)
                MangerDataContex._dataContex._ClassSubject = new List<ClassSubject>();
            ClassSubject cs = MangerDataContex._dataContex._ClassSubject.FirstOrDefault(c => c.ClassSubjectId == id);
            if (cs == null)
            {
                return false;
            }
            MangerDataContex._dataContex._ClassSubject.Remove(cs);
            return true;
        }
        public bool AddItem(ClassSubject tcs)
        {
            if (MangerDataContex._dataContex._ClassSubject == null)
                MangerDataContex._dataContex._ClassSubject = new List<ClassSubject>();
            if (tcs == null) return false;
            tcs.ClassSubjectId = MangerDataContex._dataContex._ClassSubject.Max(c => c.ClassSubjectId) + 1;
            MangerDataContex._dataContex._ClassSubject.Add(tcs);
            return true;
        }
    
}
}
