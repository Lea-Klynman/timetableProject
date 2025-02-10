using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TimeTable.Core.Dtos;
using TimeTable.Core.Entity;
using TimeTable.Core.IRepository;
using TimeTable.Core.IService;

namespace TimeTable.Service.EntityService
{
    public class SubjectService : ISubjectService
    {
        readonly IGenericRepository<SubjectEntity> _subjectRepository;
        private readonly IMapper _mapper;

        public SubjectService(IGenericRepository<SubjectEntity> subjectRepository, IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }

        public SubjectDto AddItem(SubjectDto value)
        {

            var res = _subjectRepository.AddData(_mapper.Map<SubjectEntity>(value));
            return _mapper.Map<SubjectDto>(res); ;
        }

        public SubjectDto? GetById(int id)
        {
            return _mapper.Map<SubjectDto>( _subjectRepository.GetByIdData(id));
        }

        public IEnumerable<SubjectDto> GetList()
        {
            return (IEnumerable<SubjectDto>)_mapper.Map<SubjectDto>( _subjectRepository.GetAllData());
        }

        public bool RemoveItem(int id)
        {
            return _subjectRepository.RemoveItemFromData(id);
        }

        public bool Update(int id, SubjectDto value)
        {
            
            if(! _subjectRepository.UpdateData(id,_mapper.Map<SubjectEntity>( value)))
                return false;
            return true;
        }
    }
}
