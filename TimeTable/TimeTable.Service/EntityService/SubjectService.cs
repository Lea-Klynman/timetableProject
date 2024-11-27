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
    public class SubjectService : IGenericService<SubjectEntity>
    {
        readonly IGenericRepository<SubjectEntity> _subjectRepository;
        public SubjectService(IGenericRepository<SubjectEntity> subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public bool AddItem(SubjectEntity value)
        {
            var item = GetById(value.SubjectId);
            if (item != null) {return false;}
            return _subjectRepository.AddData(value);
        }

        public SubjectEntity? GetById(int id)
        {
            return _subjectRepository.GetByIdData(id);
        }

        public IEnumerable<SubjectEntity> GetList()
        {
            return _subjectRepository.GetAllData();
        }

        public bool RemoveItem(int id)
        {
            return _subjectRepository.RemoveItemFromData(id);
        }

        public bool Update(int id, SubjectEntity value)
        {
            var item = GetById(id);
            if (item == null) {return false;}
            value.Name=value.Name ?? item.Name;
            return _subjectRepository.UpdateData(id,value);
        }
    }
}
