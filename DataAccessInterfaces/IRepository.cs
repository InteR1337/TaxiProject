using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    public interface IRepository<T>
    {
        T GetEntity(int id);
        List<T> GetEntities();
        void CreateEntity(T entity);
        void UpdatEntity(int id, T entity);
        void DeleteEntity(int id);
    }
}
