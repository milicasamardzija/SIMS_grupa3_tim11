using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Hospital.DTO;

namespace Hospital.Service
{
    public class MedicineService1
    {
        public MedicineFileStorage medicineStorage;

        public MedicineService1()
        {
            medicineStorage = new MedicineFileStorage("./../../../../Hospital/files/storageMedicine.json");
        }

         public List<Medicine> getAll()
          {
              return medicineStorage.GetAll();
          }
    }
}
