using Hospital.FileStorage.Interfaces;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.FileStorage
{
    public class CheckupDataBase : ICheckupFileStorage
    {
        public void Delete(Checkup entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public bool ExistsById(int id)
        {
            throw new NotImplementedException();
        }

        public Checkup FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Checkup> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save(Checkup newEntity)
        {
            throw new NotImplementedException();
        }

        public void SaveAll(List<Checkup> entities)
        {
            throw new NotImplementedException();
        }
    }
}
