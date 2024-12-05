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
                var item = GetByIdData(data.TeacherId);
                if (item != null) { return false; }
                if(_dataContext._Teachers.Where(t=>t.Id==data.Id).Any()) {return false;}
                data.TotalWeeklyHours = data.Subjects != null ? data.Subjects.Sum(cs => cs.HoursPerWeek) : 0;
                _dataContext._Teachers.Add(data);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<TeacherEntity> GetAllData()
        {
            return _dataContext._Teachers.ToList();
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
                _dataContext.SaveChanges();
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
                if (item == null)
                {
                    return false;
                }
  
                item.FirstName=value.FirstName ?? item.FirstName;
                item.LastName=value.LastName ?? item.LastName;
                item.Subjects = value.Subjects ?? item.Subjects;
                item.TotalWeeklyHours = item.Subjects.Sum(cs => cs.HoursPerWeek);
                item.Availabilities = value.Availabilities ?? item.Availabilities;
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
