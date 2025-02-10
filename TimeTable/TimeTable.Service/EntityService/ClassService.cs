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
    public class ClassService : IClassService
    {
        readonly IGenericRepository<ClassEntity> _classRepository;
        private readonly IMapper _mapper;
        public ClassService(IGenericRepository<ClassEntity> classRepository,IMapper mapper)
        {
            _classRepository = classRepository;
            _mapper = mapper;
        }
        public ClassDto AddItem(ClassDto value)
        {
            var res= _classRepository.AddData( _mapper.Map<ClassEntity>( value));
            return _mapper.Map<ClassDto>(res);
        }

        public ClassDto? GetById(int id)
        {          
            return _mapper.Map<ClassDto>( _classRepository.GetByIdData(id));
        }

        public IEnumerable<ClassDto> GetList()
        {
            return (IEnumerable<ClassDto>)_mapper.Map<ClassDto>( _classRepository.GetAllData());
        }

        public bool RemoveItem(int id)
        {
            return _classRepository.RemoveItemFromData(id);
        }

        public bool Update(int id, ClassDto value)
        {
            
            return _classRepository.UpdateData(id,_mapper.Map<ClassEntity>( value));
        }
    }
}
