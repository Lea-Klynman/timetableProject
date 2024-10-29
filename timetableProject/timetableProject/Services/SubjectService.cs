namespace timetableProject.Services
{
    public class SubjectService
    {
        public List<Subject> Subjects { get; set; }
        public List<Subject> GetList() => Subjects;
        public Subject GetSubjectId(int id)
        {
            Subject su = Subjects.FirstOrDefault(s => s.SubjectId == id);
            return su;
        }
        public bool Update(int id, Subject cl)
        {
            Subject su = Subjects.FirstOrDefault(s => s.SubjectId == id);
            if (su == null) return false;
            su.SubjectId = id;
            su.Name = cl.Name;
            su.IsGroup = cl.IsGroup;
            return true;
        }
        public bool RemoveItem(int id)
        {
            Subject su = Subjects.FirstOrDefault(s => s.SubjectId == id);
            if (su == null)
            {
                return false;
            }
            Subjects.Remove(su);
            return true;
        }
        public bool AddItem(Subject su)
        {
            if (su == null) return false;
            Subjects.Add(su);
            return true;
        }

    }
}

