using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTable.Core.IService
{
    public interface IGenericService <T>
    {
        IEnumerable<T> GetList();
        T? GetById(int id);
        bool Update(int id,T value);
        bool RemoveItem(int id);
        bool AddItem(T value);

    }
}
