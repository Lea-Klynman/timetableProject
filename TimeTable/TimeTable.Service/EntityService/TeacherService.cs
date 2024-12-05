using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Core.Entity;
using TimeTable.Core.IRepository;
using TimeTable.Core.IService;

    
namespace TimeTable.Service.EntityService
{
    public class TeacherService :ITeacherService
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
            if (!value.Id.IdString()) { return false; }
            return _teacherRepository.AddData(value);
        }

        public bool RemoveItem(int id)
        {
            return _teacherRepository.RemoveItemFromData(id);
        }

        public bool Update(int id, TeacherEntity value)
        {      
            return _teacherRepository.UpdateData(id, value);
        }
    }


}
