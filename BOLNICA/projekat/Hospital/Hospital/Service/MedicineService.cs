using Hospital.FileStorage.Interfaces;
using Hospital.Model;
using Hospital.Prikaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hospital.Service
{
    class MedicineService
    {
        private MedicineIFileStorage storageMedicine;
        private MedicineReviewIFileStorage storageReview;
        public MedicineService()
        {
            storageMedicine = new MedicineFileStorage("./../../../../Hospital/files/storageMedicine.json");
            storageReview = new MedicineReviewFileStorage("./../../../../Hospital/files/storageMedicineReview.json");
        }

        public int generateIdMedicineReview()
        {
            int ret = 0;

            MedicineReviewIFileStorage storage = new MedicineReviewFileStorage("./../../../../Hospital/files/storageMedicineReview.json");
            List<MedicineReview> all = storage.GetAll();

            foreach (MedicineReview medicineBig in all)
            {
                foreach (MedicineReview medicine in all)
                {
                    if (ret == medicine.Id)
                    {
                        ++ret;
                        break;
                    }
                }
            }
            return ret;
        }

        public void deleteMedicine(Medicine medicine, int idDoctor)
        {
            storageReview.Save(new MedicineReview(generateIdMedicineReview(), medicine.Id, idDoctor, ReviewType.brisanje, "", false));
            deleteFleg(medicine);
        }

        public void deleteFleg(Medicine medicine)
        {
            List<Medicine> all = storageMedicine.GetAll();
            foreach (Medicine medic in all)
            {
                if (medic.Id == medicine.Id)
                {
                    medic.Delete = true;
                    storageMedicine.SaveAll(all);
                    break;
                }
            }
        }

        internal void approvedMedicine(Review revision)
        {
            List<Medicine> all = storageMedicine.GetAll();
            foreach (Medicine medicine in all)
            {
                if (medicine.Id == revision.IdMedicine)
                {
                    medicine.Approved = true;
                    storageMedicine.SaveAll(all);
                    storageReview.DeleteById(revision.IdMedicineReview);
                    break;
                }
            }
        }

        public void sendMediciToRevision(Medicine newMedicine, int idDoctor)
        {
            storageMedicine.Save(newMedicine);
            storageReview.Save(new MedicineReview(generateIdMedicineReview(),newMedicine.Id,idDoctor,ReviewType.dodavanje,"",false));
        }
    }
}
