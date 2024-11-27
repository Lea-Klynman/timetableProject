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
    public class AvailabilityService : IGenericService<AvailabilityEntity>
    {
        readonly IGenericRepository<AvailabilityEntity> _availabilityRepository;
        public AvailabilityService(IGenericRepository<AvailabilityEntity> availabilityRepository)
        {
            _availabilityRepository = availabilityRepository;
        }

        public bool AddItem(AvailabilityEntity value)
        {
            var item = GetById(value.AvailabilityId);
            if (item != null) { return false; }
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
            var item = GetById(id);
            if (item == null) { return false; }
            value.DayOfWeek = value.DayOfWeek ?? item.DayOfWeek;
            return _availabilityRepository.UpdateData(id, value);
        }
    }
}
