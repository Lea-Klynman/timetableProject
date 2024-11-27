using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Core.Entity;
using TimeTable.Core.IRepository;

namespace TimeTable.Data.Repository
{
    public class ClassRepository : IGenericRepository<ClassEntity>
    {
        readonly DataContext _dataContext;
        public ClassRepository(DataContext dataContext)
        {
            _dataContext= dataContext;
        }
        public bool AddData(ClassEntity data)
        {
            try
            {
                _dataContext._Classes.Add(data);
                _dataContext.SaveChange();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<ClassEntity> GetAllData()
        {
            return _dataContext._Classes;
        }

        public ClassEntity? GetByIdData(int id)
        {
            return _dataContext._Classes.Where(t => t.ClassId == id).FirstOrDefault();
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
                _dataContext._Classes.Remove(item);
                _dataContext.SaveChange();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateData(int id, ClassEntity value)
        {
            try
            {
                var item = GetByIdData(id);
                item.Name = value.Name;
                item.Subjects = value.Subjects;
                item.TotalWeekHours = value.TotalWeekHours;
                item.ClassNumber = value.ClassNumber;
                item.ClassId = id;
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
