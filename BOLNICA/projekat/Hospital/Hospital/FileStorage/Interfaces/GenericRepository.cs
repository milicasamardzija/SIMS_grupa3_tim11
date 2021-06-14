 using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.FileStorage
{
   public interface GenericRepository<T> where T : Entity
    {
        List<T> GetAll();
        void Save(T newEntity);
        void SaveAll(List<T> entities);
        void DeleteById(int id);
        T FindById(int id);
    }
}
