using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeTable.Core.Entity;
using TimeTable.Core.IRepository;

namespace TimeTable.Data.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        readonly DataContext _dataContext;
        readonly AvailabilityRepository _availabilityRepository;
        readonly TeacherClassSubjectRepository _classSubjectRepository;
        public TeacherRepository(DataContext dataContext)
        {
           _dataContext= dataContext;
        }
        public TeacherEntity AddData(TeacherEntity data)
        {
            try
            {
                var item = GetByIdData(data.TeacherId);
                if (item != null) { return null; }
                if(_dataContext._Teachers.Where(t=>t.Id==data.Id).Any()) {return null;}
                data.TotalWeeklyHours = data.Subjects != null ? data.Subjects.Sum(cs => cs.HoursPerWeek) : 0;
                foreach (var item1 in data.Availabilities)
                {
                    _availabilityRepository.AddData(item1);
                }
                if(data.Subjects!=null)
                foreach (var item1 in data.Subjects)
                {
                    _classSubjectRepository.AddData(item1);
                }
                _dataContext._Teachers.Add(data);

                _dataContext.SaveChanges();
                return data;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public IEnumerable<TeacherEntity> GetAllData()
        {
            return _dataContext._Teachers.Include(u=>u.Subjects ).Include(u=>u.Availabilities).ToList();
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
                foreach (var item1 in item.Availabilities)
                {
                    _availabilityRepository.RemoveItemFromData(item1.AvailabilityId);
                }
                if (item.Subjects != null)
                    foreach (var item1 in item.Subjects)
                    {
                        _classSubjectRepository.RemoveItemFromData(item1.TeacherClassSubjectId);
                    }
                _dataContext.SaveChanges();
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
                foreach (var item1 in item.Availabilities)
                {
                    _availabilityRepository.UpdateData(item1.AvailabilityId,item1);
                }
                if (item.Subjects != null)
                    foreach (var item1 in item.Subjects)
                    {
                        _classSubjectRepository.UpdateData(item1.TeacherClassSubjectId, item1);
                    }
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
