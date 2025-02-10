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
    public class TeacherService :ITeacherService
    {
        readonly IGenericRepository<TeacherEntity> _teacherRepository;
        private readonly IMapper _mapper;

        public TeacherService(IGenericRepository<TeacherEntity> teacherRepository , IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }
        public IEnumerable<TeacherDto> GetList()
        {
            return (IEnumerable<TeacherDto>)_mapper.Map<TeacherDto>( _teacherRepository.GetAllData());
        }
        public TeacherDto? GetById(int id)
        {
            return _mapper.Map<TeacherDto>( _teacherRepository.GetByIdData(id));
        }
        public TeacherDto AddItem(TeacherDto value)
        {
            if (!value.Id.IdString()) { return null; }
            var res= _teacherRepository.AddData( _mapper.Map<TeacherEntity>( value));
            return _mapper.Map<TeacherDto>(res);
        }

        public bool RemoveItem(int id)
        {
            return _teacherRepository.RemoveItemFromData(id);
        }

        public bool Update(int id, TeacherDto value)
        {      
            return _teacherRepository.UpdateData(id, _mapper.Map<TeacherEntity>( value));
        }
    }


}
