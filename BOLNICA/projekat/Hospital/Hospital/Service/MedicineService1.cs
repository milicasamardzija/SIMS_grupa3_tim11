using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Hospital.DTO;
using Hospital.FileStorage.Interfaces;

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

        public int generateIdMedicine()
        {
            int returnMedicine = 0;
            MedicineIFileStorage storage = new MedicineFileStorage("./../../../../Hospital/files/storageMedicine.json");
            ObservableCollection<Medicine> all = new ObservableCollection<Medicine>(storage.GetAll());
            foreach (Medicine medicine in all)
            {
                foreach (Medicine medicines in all)
                {
                    if (returnMedicine == medicines.Id)
                    {
                        ++returnMedicine;
                        break;
                    }
                }
            }
            return returnMedicine;
        }
    }
}
