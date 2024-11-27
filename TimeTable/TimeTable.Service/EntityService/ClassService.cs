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
    public class ClassService : IGenericService<ClassEntity>
    {
        readonly IGenericRepository<ClassEntity> _classRepository;
        public ClassService(IGenericRepository<ClassEntity> classRepository)
        {
            _classRepository = classRepository;
        }
        public bool AddItem(ClassEntity value)
        {
            var item = GetById(value.ClassId);
            if (item != null) { return false; }
            if(value.Subjects!=null)
                value.TotalWeekHours=value.Subjects.Sum(s=>s.HoursPersWeek);
            return _classRepository.AddData(value);
        }

        public ClassEntity? GetById(int id)
        {
            return _classRepository.GetByIdData(id);
        }

        public IEnumerable<ClassEntity> GetList()
        {
            return _classRepository.GetAllData();
        }

        public bool RemoveItem(int id)
        {
            return _classRepository.RemoveItemFromData(id);
        }

        public bool Update(int id, ClassEntity value)
        {
            var item = GetById(id);
            if (item == null) { return false; }
            value.Name = value.Name ?? item.Name;
            value.Subjects = value.Subjects ?? item.Subjects;
            value.ClassNumber=value.ClassNumber!=0?value.ClassNumber:item.ClassNumber;
            value.TotalWeekHours=value.Subjects.Sum(s=>s.HoursPersWeek);
            return _classRepository.UpdateData(id, value);
        }
    }
}
