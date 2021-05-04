using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void sendMediciToRevision(Medicine newMedicine, int idDoctor)
        {
            storageMedicine.Save(newMedicine);
            storageReview.Save(new MedicineReview(generateIdMedicineReview(),newMedicine.IdMedicine,idDoctor,ReviewType.dodavanje,"",false));
        }
    }
}
