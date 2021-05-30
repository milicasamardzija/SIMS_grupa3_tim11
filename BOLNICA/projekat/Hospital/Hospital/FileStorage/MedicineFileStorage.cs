using Hospital.FileStorage;
using Hospital.FileStorage.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class MedicineFileStorage : GenericFileStorage<Medicine>, MedicineIFileStorage
    {
        public MedicineFileStorage(String filePath) : base(filePath)
        {
        }

        public List<Medicine> loadReplacementMedicines(Medicine medicine)
        {
            List<Medicine> ret = new List<Medicine>();
            if (medicine != null)
            {
                foreach (int id in medicine.IdsMedicines)
                {
                    foreach (Medicine medicineReplacement in GetAll())
                    {
                        if (medicineReplacement.Id == id)
                        {
                            ret.Add(medicineReplacement);
                            break;
                        }
                    }
                }
            }
            return ret;
        }
        public List<Medicine> loadApprovedMedicines()
        {
            List<Medicine> ret = new List<Medicine>();
            foreach (Medicine medicine in GetAll())
            {
                if (medicine.Approved)
                {
                    ret.Add(medicine);
                }
            }
            return ret;
        }

    }
}
