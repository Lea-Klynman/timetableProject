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
    public class SubjectService : ISubjectService
    {
        readonly IGenericRepository<SubjectEntity> _subjectRepository;
        public SubjectService(IGenericRepository<SubjectEntity> subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public bool AddItem(SubjectEntity value)
        {
            
            if(!_subjectRepository.AddData(value))
                return false;
            return true;
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
            
            if(! _subjectRepository.UpdateData(id,value))
                return false;
            return true;
        }
    }
}
