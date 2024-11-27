using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Core.Entity;
using TimeTable.Core.IService;
using TimeTable.Core.IRepository;

namespace TimeTable.Service.EntityService
{
    public class TeacherService : IGenericService<TeacherEntity>
    {
        readonly IGenericRepository<TeacherEntity> _teacherRepository;
        public TeacherService(IGenericRepository<TeacherEntity> teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        public IEnumerable<TeacherEntity> GetList()
        {
            return _teacherRepository.GetAllData();
        }
        public TeacherEntity? GetById(int id)
        {
            return _teacherRepository.GetByIdData(id);
        }
        public bool AddItem(TeacherEntity value)
        {
            var item = _teacherRepository.GetByIdData(value.TeacherId);
            if (item != null) { return false; }
            value.TotalWeeklyHours = value.Subjects != null ? value.Subjects.Sum(cs => cs.HoursPerWeek) : 0;
            return _teacherRepository.AddData(value);
        }

        public bool RemoveItem(int id)
        {
            return _teacherRepository.RemoveItemFromData(id);
        }

        public bool Update(int id, TeacherEntity value)
        {
            var teacher = GetById(id);
            if (teacher == null)
            {
                return false;
            }
            value.FirstName = value.FirstName ?? teacher.FirstName;
            value.LastName = value.LastName ?? teacher.LastName;
            value.Id = value.Id ?? teacher.Id;
            value.Subjects = value.Subjects ?? teacher.Subjects;
            value.Availabilities = value.Availabilities ?? teacher.Availabilities;
            value.TotalWeeklyHours = value.Subjects.Sum(cs => cs.HoursPerWeek);
            return _teacherRepository.UpdateData(id, value);
        }
    }
}
