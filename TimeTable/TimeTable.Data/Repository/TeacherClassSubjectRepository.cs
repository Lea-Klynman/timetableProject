using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Core.Entity;
using TimeTable.Core.IRepository;

namespace TimeTable.Data.Repository
{
    public class TeacherClassSubjectRepository : ITeacherClassSubjectRepository
    {
        readonly DataContext _dataContext;
        public TeacherClassSubjectRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool AddData(TeacherClassSubjectEntity data)
        {
            try
            {
                var item = GetByIdData(data.TeacherClassSubjectId);
                if (item != null) { return false; }
                _dataContext._TeacherClassSubject.Add(data);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<TeacherClassSubjectEntity> GetAllData()
        {
            return _dataContext._TeacherClassSubject.ToList();
        }

        public TeacherClassSubjectEntity? GetByIdData(int id)
        {
            return _dataContext._TeacherClassSubject.Where(c=>c.TeacherClassSubjectId == id).FirstOrDefault();
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
                _dataContext._TeacherClassSubject.Remove(item);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateData(int id, TeacherClassSubjectEntity value)
        {
            try
            {
                var item = GetByIdData(id);
                if (item == null) { return false; }
                item.SubjectId = value.SubjectId;
                item.ClassId = value.ClassId;
                item.TeacherId = value.TeacherId;
                item.HoursPerWeek = value.HoursPerWeek;
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
