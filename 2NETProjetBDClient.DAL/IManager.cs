using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2NETProjetBDClient.DAL
{
    public interface IManager <T>
    {
        T Add(T obj);
        T Edit(T obj);
        void Remove(T obj);
        T FindById(int Id);

        IEnumerable<T> FindAll(string search = null);
    }
}
