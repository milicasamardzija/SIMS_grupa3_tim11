using Hospital.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.FileStorage
{
    public class GenericFileStorage<T> : GenericRepository<T> where T : Entity
    {
        private string path;

        public GenericFileStorage(string filePath)
        {
            this.path = filePath;
        }

        public List<T> GetAll()
        {
            List<T> all = new List<T>();

            all = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(@path));

            return all;
        }

        public void Save(T newEntity)
        {
            List<T> all = GetAll();

            all.Add(newEntity);

            SaveAll(all);
        }

        public void SaveAll(List<T> entities)
        {
            using (StreamWriter file = File.CreateText(@path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, entities);
            }
        }

        public void DeleteById(int id)
        {
            List<T> all = GetAll();

            foreach (T entities in all)
            {
                if (entities.Id == id)
                {
                    all.Remove(entities);
                    break;
                }
            }
            SaveAll(all);
        }

        public T FindById(int id)
        {
            List<T> all = GetAll();
            T ret = null;

            foreach (T entity in all)
            {
                if (entity.Id == id)
                {
                    ret = entity;
                    break;
                }
            }

            return ret;
        }

    }
}

