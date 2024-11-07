using timetableProject.Controllers;

namespace timetableProject.Services
{
    public class ClassService
    {
        public List<Class> GetList()
        {
            if(MangerDataContex._dataContex._Classes==null)
                MangerDataContex._dataContex._Classes= new List<Class>();
           return MangerDataContex._dataContex._Classes;
        }
        public Class GetClassId(int id)
        {
            if (MangerDataContex._dataContex._Classes == null)
                MangerDataContex._dataContex._Classes = new List<Class>();
            return MangerDataContex._dataContex._Classes.FirstOrDefault(cl => cl.ClassId == id);
        }
        public bool Update(int id,Class cl)
        {
            if (MangerDataContex._dataContex._Classes == null)
                MangerDataContex._dataContex._Classes = new List<Class>();
            Class c= MangerDataContex._dataContex._Classes.FirstOrDefault(cl=>cl.ClassId==id);
            if(c==null) return false;
            c.ClassId = id;
            c.ClassNumber=cl.ClassNumber;
            c.TotalWeekHours = cl.TotalWeekHours;
            c.Subjects = cl.Subjects;
            return true;
        }
        public bool RemoveItem(int id) {
            if (MangerDataContex._dataContex._Classes == null)
                MangerDataContex._dataContex._Classes = new List<Class>();
            Class cl = MangerDataContex._dataContex._Classes.FirstOrDefault(c => c.ClassId== id);
            if (cl == null)
            {
                return false;
            }
            MangerDataContex._dataContex._Classes.Remove(cl);
            return true;
        }
        public bool AddItem(Class cl) {
            if (MangerDataContex._dataContex._Classes == null)
                MangerDataContex._dataContex._Classes = new List<Class>();
            if (cl == null) return false;
            cl.TotalWeekHours = cl.Subjects.Sum(su => su.HoursPersWeek);
            cl.ClassId = MangerDataContex._dataContex._Classes.Max(c => c.ClassId) + 1;
            MangerDataContex._dataContex._Classes.Add(cl);
            return true;
        }

    }
}
