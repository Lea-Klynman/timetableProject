﻿using System;
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
        readonly ClassSubjectRepository _subjectRepository;
        public ClassRepository(DataContext dataContext)
        {
            _dataContext= dataContext;
        }
        public bool AddData(ClassEntity data)
        {
            try
            {
                var item = GetByIdData(data.ClassId);
                if (item != null) { return false; }
                if (data.Subjects != null)
                    data.TotalWeekHours = data.Subjects.Sum(s => s.HoursPersWeek);
                if(data.Subjects != null)
                foreach (var item1 in data.Subjects)
                {
                    _subjectRepository.AddData(item1);
                }
                _dataContext._Classes.Add(data);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<ClassEntity> GetAllData()
        {
            return _dataContext._Classes.ToList();
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
                if (item.Subjects != null)
                {
                    foreach (var item1 in item.Subjects)
                    {
                        _subjectRepository.RemoveItemFromData(item1.ClassSubjectId);
                    }
                }
                _dataContext._Classes.Remove(item);
                _dataContext.SaveChanges();
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
                if (item == null) { return false; }  
                item.Name = value.Name ?? item.Name;
                item.Subjects = value.Subjects ?? item.Subjects;
                item.TotalWeekHours = item.Subjects.Sum(s => s.HoursPersWeek);
                item.ClassNumber = value.ClassNumber != 0 ? value.ClassNumber : item.ClassNumber;
                if(item.Subjects != null)
                {
                    foreach (var item2 in item.Subjects)
                    {
                        _subjectRepository.UpdateData(item2.ClassSubjectId, item2);
                    }
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
