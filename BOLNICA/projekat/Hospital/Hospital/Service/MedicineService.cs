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

        public void sendMediciToRevision(Medicine newMedicine)
        {
            storageMedicine.Save(newMedicine);
       //     storageReview.Save(new MedicineReview(newMedicine));
        }
    }
}
