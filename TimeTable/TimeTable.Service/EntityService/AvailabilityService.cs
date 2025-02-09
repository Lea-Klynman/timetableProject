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
    public class AvailabilityService : IAvailabilityService
    {
        readonly IAvailabilityRepository _availabilityRepository;
        private readonly IMapper _mapper;
        public AvailabilityService(IAvailabilityRepository availabilityRepository,IMapper mapper)
        {
            _availabilityRepository = availabilityRepository;
            _mapper = mapper;
        }

        public bool AddItem(AvailabilityDto value)
        {
            
            return _availabilityRepository.AddData(_mapper.Map<AvailabilityDto>(value));
        }

        public AvailabilityDto? GetById(int id)
        {
            return _mapper.Map<AvailabilityDto>(_availabilityRepository.GetByIdData(id));
        }

        public IEnumerable<AvailabilityEntity> GetList()
        {
            return _availabilityRepository.GetAllData();
        }

        public bool RemoveItem(int id)
        {
            return _availabilityRepository.RemoveItemFromData(id);
        }

        public bool Update(int id, AvailabilityEntity value)
        {
            
            if (!_availabilityRepository.UpdateData(id, value))
                return false;
            return true;
        }
    }
}
