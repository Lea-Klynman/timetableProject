using timetableProject.Controllers;
using timetableProject.DATA;
using timetableProject.DTO;
using timetableProject.Interface;

namespace timetableProject.Services
{
    public class TeacherService
    { readonly ITeacherData _dataTeacher;
        public TeacherService(ITeacherData dataTeacher)
        {
            _dataTeacher = dataTeacher;
        }
        public List<Teacher> GetList() {
            var data = _dataTeacher.LoadData();
            if (data == null)
                return null;
            return data;
        }
        public Teacher GetTeacherId(int id)
        {
            var data = _dataTeacher.LoadData();
            if (data == null)
                return null;
            return data.Where(t => t.TeacherId == id).FirstOrDefault();
        }
        public bool Update(int id, Teacher updatedTeacher)
        {
            var data = _dataTeacher.LoadData();
            if (data == null)
                return false;
            Teacher teacher = data.Where(t => t.TeacherId == id).FirstOrDefault();
            if (teacher == null)
            {
                return false;
            }
            
            teacher.FirstName = updatedTeacher.FirstName ?? teacher.FirstName;
            teacher.LastName = updatedTeacher.LastName ?? teacher.LastName;
            teacher.Subjects = updatedTeacher.Subjects ?? teacher.Subjects;
            teacher.Availabilities = updatedTeacher.Availabilities ?? teacher.Availabilities;
          teacher.TotalWeeklyHours = teacher.Subjects.Sum(cs => cs.HoursPerWeek);
            return _dataTeacher.SaveData(data);

        }
        public bool RemoveItem(int id)
        {
            var data = _dataTeacher.LoadData();
            if (data == null)
                return false;
            Teacher teacher = data.Where(t => t.TeacherId == id).FirstOrDefault();
            if (teacher == null)
            {
                return false;
            }
            data.Remove(teacher);
            return _dataTeacher.SaveData(data);

        }
        public bool AddItem(Teacher teacher)
        {
            var data = _dataTeacher.LoadData();
            if (data == null)
                return false;
           teacher.TotalWeeklyHours = teacher.Subjects.Sum(cs => cs.HoursPerWeek);
            teacher.TeacherId = data.Max(t => t.TeacherId) + 1;
            data.Add(teacher);
            return _dataTeacher.SaveData(data);
        }
        
    }
}
