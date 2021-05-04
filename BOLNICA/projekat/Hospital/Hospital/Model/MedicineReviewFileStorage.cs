using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    class MedicineReviewFileStorage
    {
        public List<MedicineReview> GetAll()
        {
            List<MedicineReview> all = new List<MedicineReview>();

            all = JsonConvert.DeserializeObject<List<MedicineReview>>(File.ReadAllText(@"./../../../../Hospital/files/storageMedicineReview.json"));

            return all;
        }

        public void Save(MedicineReview newMedicine)
        {
            List<MedicineReview> all = GetAll();

            all.Add(newMedicine);

            SaveAll(all);
        }

        public void SaveAll(List<MedicineReview> medicines)
        {
            using (StreamWriter file = File.CreateText(@"./../../../../Hospital/files/storageMedicineReview.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, medicines);
            }
        }

        public void Delete(MedicineReview medicine)
        {
            List<MedicineReview> all = GetAll();

            foreach (MedicineReview temp in all)
            {
                if (temp.IdMedicineReview== medicine.IdMedicineReview)
                {
                    all.Remove(temp);
                    break;
                }
            }
            SaveAll(all);
        }

        public void DeleteById(int id)
        {
            List<MedicineReview> all = GetAll();

            foreach (MedicineReview medicine in all)
            {
                if (medicine.IdMedicineReview == id)
                {
                    all.Remove(medicine);
                    break;
                }
            }
            SaveAll(all);
        }

        public MedicineReview FindById(int id)
        {
            List<MedicineReview> all = GetAll();
            MedicineReview ret = null;

            foreach (MedicineReview medicine in all)
            {
                if (medicine.IdMedicineReview == id)
                {
                    ret = medicine;
                    break;
                }
            }

            return ret;
        }

        public Boolean ExistsById(int id)
        {
            List<MedicineReview> all = GetAll();
            Boolean ret = false;

            foreach (MedicineReview medicine in all)
            {
                if (medicine.IdMedicineReview == id)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }
    }
}
