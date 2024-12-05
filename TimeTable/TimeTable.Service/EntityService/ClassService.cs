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
    public class ClassService : IClassService
    {
        readonly IGenericRepository<ClassEntity> _classRepository;
        public ClassService(IGenericRepository<ClassEntity> classRepository)
        {
            _classRepository = classRepository;
        }
        public bool AddItem(ClassEntity value)
        {
            
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
            
            return _classRepository.UpdateData(id, value);
        }
    }
}
