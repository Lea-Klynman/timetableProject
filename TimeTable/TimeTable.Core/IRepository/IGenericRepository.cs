using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Core.IRepository
{
    public interface IGenericRepository <T>
    {
        IEnumerable<T> GetAllData();
        T? GetByIdData(int id);
        bool UpdateData(int id, T value);
        bool RemoveItemFromData(int id);
        T AddData(T data);
    }
}
