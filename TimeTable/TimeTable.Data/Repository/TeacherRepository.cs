using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Core.Entity;
using TimeTable.Core.IRepository;

namespace TimeTable.Data.Repository
{
    public class TeacherRepository : IGenericRepository<TeacherEntity>
    {
        readonly DataContext _dataContext;
        public TeacherRepository(DataContext dataContext)
        {
           _dataContext= dataContext;
        }
        public bool AddData(TeacherEntity data)
        {
            try
            {
                _dataContext._Teachers.Add(data);
                _dataContext.SaveChange();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<TeacherEntity> GetAllData()
        {
            return _dataContext._Teachers;
        }

        public TeacherEntity? GetByIdData(int id)
        {
            return _dataContext._Teachers.Where(t => t.TeacherId == id).FirstOrDefault();
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
                _dataContext._Teachers.Remove(item);
                _dataContext.SaveChange();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateData(int id, TeacherEntity value)
        {
            try
            {
                var item = GetByIdData(id);
                item.FirstName=value.FirstName;
                item.LastName=value.LastName;
                item.TotalWeeklyHours=value.TotalWeeklyHours;
                item.TeacherId = id;
                item.Subjects = value.Subjects;
                item.Availabilities = value.Availabilities;
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
