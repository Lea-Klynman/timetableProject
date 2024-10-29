using timetableProject.Controllers;

namespace timetableProject.Services
{
    public class ClassService
    {
        public List<Class> Classes { get; set; }= new List<Class>();
        public List<Class> GetList() => Classes;
        public Class GetClassId(int id)
        {
            Class c = Classes.FirstOrDefault(cl => cl.ClassId == id);
            return c;
        }
        public bool Update(int id,Class cl)
        {
            Class c=Classes.FirstOrDefault(cl=>cl.ClassId==id);
            if(c==null) return false;
            c.ClassId = id;
            c.ClassNumber=cl.ClassNumber;
            c.TotalWeekHours = cl.TotalWeekHours;
            c.Subjects = cl.Subjects;
            return true;
        }
        public bool RemoveItem(int id) {
            Class cl = Classes.FirstOrDefault(c => c.ClassId== id);
            if (cl == null)
            {
                return false;
            }
            Classes.Remove(cl);
            return true;
        }
        public bool AddItem(Class cl) { 
        if (cl == null) return false;
            cl.TotalWeekHours = cl.Subjects.Sum(su => su.HoursPersWeek);
            Classes.Add(cl);
            return true;
        }

    }
}
