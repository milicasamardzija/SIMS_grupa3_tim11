using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class MedicineFileStorage
    {
        public List<Medicine> GetAll()
        {
            List<Medicine> all = new List<Medicine>();

            all = JsonConvert.DeserializeObject<List<Medicine>>(File.ReadAllText(@"./../../../../Hospital/files/storageMedicine.json"));

            return all;
        }

        public void Save(Medicine newMedicine)
        {
            List<Medicine> all = GetAll();

            all.Add(newMedicine);

            SaveAll(all);
        }

        public void SaveAll(List<Medicine> medicines)
        {
            using (StreamWriter file = File.CreateText(@"./../../../../Hospital/files/storageMedicine.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, medicines);
            }
        }

        public void Delete(Medicine medicine)
        {
            List<Medicine> all = GetAll();

            foreach (Medicine temp in all)
            {
                if (temp.IdMedicine == medicine.IdMedicine)
                {
                    all.Remove(temp);
                    break;
                }
            }
            SaveAll(all);
        }

        public void DeleteById(int id)
        {
            List<Medicine> all = GetAll();

            foreach (Medicine medicine in all)
            {
                if (medicine.IdMedicine == id)
                {
                    all.Remove(medicine);
                    break;
                }
            }
            SaveAll(all);
        }

        public Medicine FindById(int id)
        {
            List<Medicine> all = GetAll();
            Medicine ret = null;

            foreach (Medicine medicine in all)
            {
                if (medicine.IdMedicine == id)
                {
                    ret = medicine;
                    break;
                }
            }

            return ret;
        }

        public Boolean ExistsById(int id)
        {
            List<Medicine> all = GetAll();
            Boolean ret = false;

            foreach (Medicine medicine in all)
            {
                if (medicine.IdMedicine == id)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }
    }
}
