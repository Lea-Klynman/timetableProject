using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTable.Core.Entity;
using TimeTable.Core.IRepository;

namespace TimeTable.Data.Repository
{
    public class SubjectRepository:IGenericRepository<SubjectEntity>
    {
        readonly DataContext _dataContext;
        public SubjectRepository(DataContext dataContext) {
            _dataContext= dataContext;
        }

        public bool AddData(SubjectEntity data)
        {
            try
            {
                var item = GetByIdData(data.SubjectId);
                if (item != null) { return false; }
                _dataContext._Subjects.Add(data);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<SubjectEntity> GetAllData()
        {
            return _dataContext._Subjects.ToList();
        }

        public SubjectEntity? GetByIdData(int id)
        {
            return _dataContext._Subjects.Where(s => s.SubjectId == id).FirstOrDefault();
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
                _dataContext._Subjects.Remove(item);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateData(int id, SubjectEntity value)
        {
            try
            {
                var item = GetByIdData(id);
                if (item == null) { return false; }
                value.Name = value.Name ?? item.Name;
                item.Name = value.Name;
                item.IsGroup = value.IsGroup;
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
