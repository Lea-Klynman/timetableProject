using timetableProject.Controllers;

namespace timetableProject.Services
{
    public class TeacherService
    {
        public List<Teacher> GetList() {
        if(MangerDataContex._dataContex._Teachers == null) 
                MangerDataContex._dataContex._Teachers = new List<Teacher>();
            return MangerDataContex._dataContex._Teachers;
        }
        public Teacher GetTeacherId(int id)
        {
            Teacher teacher = MangerDataContex._dataContex._Teachers.FirstOrDefault(t => t.TeacherId == id);
            return teacher;
        }
        public bool Update(int id, Teacher updatedTeacher)
        {
            if (MangerDataContex._dataContex._Teachers == null)
                MangerDataContex._dataContex._Teachers = new List<Teacher>();
            Teacher teacher = MangerDataContex._dataContex._Teachers.FirstOrDefault(t => t.TeacherId == id);
            if (teacher == null)
            {
                return false;
            }
            teacher.FirstName = updatedTeacher.FirstName;
            teacher.LastName = updatedTeacher.LastName;
            teacher.Subjects = updatedTeacher.Subjects;
            teacher.Availabilities = updatedTeacher.Availabilities;
            teacher.TotalWeeklyHours = updatedTeacher.Subjects.Sum(cs => cs.HoursPerWeek);
            return true;

        }
        public bool RemoveItem(int id)
        {
            if (MangerDataContex._dataContex._Teachers == null)
                MangerDataContex._dataContex._Teachers = new List<Teacher>();
            Teacher teacher = MangerDataContex._dataContex._Teachers.FirstOrDefault(t => t.TeacherId == id);
            if (teacher == null)
            {
                return false;
            }
            MangerDataContex._dataContex._Teachers.Remove(teacher);
            return true;

        }
        public bool AddItem(Teacher teacher)
        {
            if (MangerDataContex._dataContex._Teachers == null)
                MangerDataContex._dataContex._Teachers = new List<Teacher>();
            teacher.TotalWeeklyHours = teacher.Subjects.Sum(cs => cs.HoursPerWeek);
            teacher.TeacherId = MangerDataContex._dataContex._Teachers.Max(t => t.TeacherId) + 1;
            MangerDataContex._dataContex._Teachers.Add(teacher);
            return true;
        }
    }
}
