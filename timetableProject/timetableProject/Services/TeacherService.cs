using timetableProject.Controllers;

namespace timetableProject.Services
{
    public class TeacherService
    {
        public List<Teacher> Teachers { get; set; } = new List<Teacher>();
        public List<Teacher> GetList() => Teachers;
        public Teacher GetTeacherId(int id)
        {
            Teacher teacher = Teachers.FirstOrDefault(t => t.TeacherId == id);
            return teacher;
        }
        public bool Update(int id, Teacher updatedTeacher)
        {
            Teacher teacher = Teachers.FirstOrDefault(t => t.TeacherId == id);
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
            Teacher teacher = Teachers.FirstOrDefault(t => t.TeacherId == id);
            if (teacher == null)
            {
                return false;
            }
            Teachers.Remove(teacher);
            return true;

        }
        public bool AddItem(Teacher teacher)
        {
            teacher.TotalWeeklyHours = teacher.Subjects.Sum(cs => cs.HoursPerWeek);
            Teachers.Add(teacher);
            return true;
        }
    }
}
