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
        private MedicineFileStorage storageMedicine;
        private MedicineReviewFileStorage storageReview;
        public MedicineService()
        {
            storageMedicine = new MedicineFileStorage();
            storageReview = new MedicineReviewFileStorage();
        }

        public int generateIdMedicineReview()
        {
            int ret = 0;

            MedicineReviewFileStorage storage = new MedicineReviewFileStorage();
            List<MedicineReview> all = storage.GetAll();

            foreach (MedicineReview medicineBig in all)
            {
                foreach (MedicineReview medicine in all)
                {
                    if (ret == medicine.IdMedicineReview)
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
            storageReview.Save(new MedicineReview(generateIdMedicineReview(), medicine.IdMedicine, idDoctor, ReviewType.brisanje, "", false));
        }

        internal void approvedMedicine(LekRevizija revision)
        {
            List<Medicine> all = storageMedicine.GetAll();
            foreach (Medicine medicine in all)
            {
                if (medicine.IdMedicine == revision.IdMedicine)
                {
                    medicine.Approved = true;
                    storageMedicine.SaveAll(all);
                    break;
                }
            }
        }

        public void sendMediciToRevision(Medicine newMedicine, int idDoctor)
        {
            storageMedicine.Save(newMedicine);
            storageReview.Save(new MedicineReview(generateIdMedicineReview(),newMedicine.IdMedicine,idDoctor,ReviewType.dodavanje,"",false));
        }
    }
}
