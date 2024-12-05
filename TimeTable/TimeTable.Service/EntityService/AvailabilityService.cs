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
    public class AvailabilityService : IAvailabilityService
    {
        readonly IGenericRepository<AvailabilityEntity> _availabilityRepository;
        public AvailabilityService(IGenericRepository<AvailabilityEntity> availabilityRepository)
        {
            _availabilityRepository = availabilityRepository;
        }

        public bool AddItem(AvailabilityEntity value)
        {
            
            return _availabilityRepository.AddData(value);
        }

        public AvailabilityEntity? GetById(int id)
        {
            return _availabilityRepository.GetByIdData(id);
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
