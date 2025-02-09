using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Core.Entity;
using TimeTable.Core.IRepository;

namespace TimeTable.Data.Repository
{
    public class ClassSubjectRepository : IClassSubjectRepository
    {
        readonly DataContext _dataContext;
        public ClassSubjectRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool AddData(ClassSubjectEntity data)
        {
            try
            {
                var item = GetByIdData(data.ClassSubjectId);
                if (item != null) { return false; }
                _dataContext._ClassSubject.Add(data);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception ex) { 
                return false;
            }
        }

        public IEnumerable<ClassSubjectEntity> GetAllData()
        {
            return _dataContext._ClassSubject.ToList();
        }

        public ClassSubjectEntity? GetByIdData(int id)
        {
            return _dataContext._ClassSubject.Where(c=>c.ClassSubjectId == id).FirstOrDefault();
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
                _dataContext._ClassSubject.Remove(item);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateData(int id, ClassSubjectEntity value)
        {
            try{var item = GetByIdData(id);
            if (item == null) { return false; }
            item.SubjectId = value.SubjectId;
            item.HoursPersWeek = value.HoursPersWeek;
            item.ClassId = value.ClassId;
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
