using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Core.Entity;
using TimeTable.Core.IRepository;

namespace TimeTable.Data.Repository
{
    public class AvailabilityRepository : IGenericRepository<AvailabilityEntity>
    {
        readonly DataContext _dataContext;
        public AvailabilityRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool AddData(AvailabilityEntity data)
        {
            try
            {
                _dataContext._Availabilities.Add(data);
                _dataContext.SaveChange();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<AvailabilityEntity> GetAllData()
        {
            return _dataContext._Availabilities;
        }

        public AvailabilityEntity? GetByIdData(int id)
        {
            return _dataContext._Availabilities.Where(t => t.AvailabilityId == id).FirstOrDefault();
        }

        public bool RemoveItemFromData(int id)
        {
            try
            {
                var item = GetByIdData(id);
                if (item == null)
                {
                    return false;
                }
                _dataContext._Availabilities.Remove(item);
                _dataContext.SaveChange();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool UpdateData(int id, AvailabilityEntity value)
        {
            try
            {
                var item = GetByIdData(id);
                item.DayOfWeek = value.DayOfWeek;
                item.IsWholeDayOff = value.IsWholeDayOff;
                item.isMust=value.isMust;
                item.Unavailablehours=value.Unavailablehours;
                item.AvailabilityId = id;
                _dataContext.SaveChange();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
