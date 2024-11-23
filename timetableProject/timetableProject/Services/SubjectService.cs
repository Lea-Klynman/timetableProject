using timetableProject.DATA;
using timetableProject.DTO;

namespace timetableProject.Services
{
    public class SubjectService
    {
        public List<Subject> GetList() {
            if(MangerDataContex._dataContex._Subjects==null)
                MangerDataContex._dataContex._Subjects=new List<Subject>();
            return MangerDataContex._dataContex._Subjects;
        }
        public Subject GetSubjectId(int id)
        {
            if (MangerDataContex._dataContex._Subjects == null)
                MangerDataContex._dataContex._Subjects = new List<Subject>();
            Subject su = MangerDataContex._dataContex._Subjects.FirstOrDefault(s => s.SubjectId == id);
            return su;
        }
        public bool Update(int id, Subject cl)
        {
            if (MangerDataContex._dataContex._Subjects == null)
                MangerDataContex._dataContex._Subjects = new List<Subject>();
            Subject su = MangerDataContex._dataContex._Subjects.FirstOrDefault(s => s.SubjectId == id);
            if (su == null) return false;
            su.SubjectId = id;
            su.Name = cl.Name;
            su.IsGroup = cl.IsGroup;
            return true;
        }
        public bool RemoveItem(int id)
        {
            if (MangerDataContex._dataContex._Subjects == null)
                MangerDataContex._dataContex._Subjects = new List<Subject>();
            Subject su = MangerDataContex._dataContex._Subjects.FirstOrDefault(s => s.SubjectId == id);
            if (su == null)
            {
                return false;
            }
            MangerDataContex._dataContex._Subjects.Remove(su);
            return true;
        }
        public bool AddItem(Subject su)
        {
            if (MangerDataContex._dataContex._Subjects == null)
                MangerDataContex._dataContex._Subjects = new List<Subject>();
            if (su == null) return false;
            su.SubjectId= MangerDataContex._dataContex._Subjects.Max(s => s.SubjectId)+1;
            MangerDataContex._dataContex._Subjects.Add(su);
            return true;
        }

    }
}

